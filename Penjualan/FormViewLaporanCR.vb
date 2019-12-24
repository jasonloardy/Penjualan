Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class FormViewLaporanCR
    Dim cryReport As New ReportDocument
    Dim RepLocation = Path.GetFullPath( _
            Path.Combine(Application.StartupPath, "..\..\"))
    Dim query As String
    Sub pembelianharian(ByVal tanggal As Date, ByVal tanggal2 As Date)
        query = "SELECT * FROM tb_pembelian WHERE tanggal BETWEEN '" & Format(tanggal, "yyyy-MM-dd") & "' AND '" & Format(tanggal2, "yyyy-MM-dd") & "' LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPembelianHarian.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tanggal", tanggal)
            cryReport.SetParameterValue("tanggal2", tanggal2)
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanharian(ByVal tanggal As Date, ByVal tanggal2 As Date)
        query = "SELECT * FROM tb_penjualan " _
              & "WHERE tanggal BETWEEN '" & Format(tanggal, "yyyy-MM-dd") & "' AND '" & Format(tanggal2, "yyyy-MM-dd") & "' LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanHarian.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tanggal", tanggal)
            cryReport.SetParameterValue("tanggal2", tanggal2)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN SEMUA PENJUALAN HARIAN"
            cryReport.RecordSelectionFormula = "{@jenis} = {@jenis}"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanlangsungharian(ByVal tanggal As Date, ByVal tanggal2 As Date)
        query = "SELECT tj.tanggal,sum(tjd.qty)-sum(tjd.ambil) as qty FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "GROUP by tj.kd_penjualan " _
              & "HAVING tj.tanggal BETWEEN '" & Format(tanggal, "yyyy-MM-dd") & "' AND '" & Format(tanggal2, "yyyy-MM-dd") & "' AND qty=0 " _
              & "LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanHarian.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tanggal", tanggal)
            cryReport.SetParameterValue("tanggal2", tanggal2)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN PENJUALAN LANGSUNG HARIAN"
            cryReport.RecordSelectionFormula = "{@jenis} = 'Langsung'"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanantarharian(ByVal tanggal As Date, ByVal tanggal2 As Date)
        query = "SELECT tj.tanggal,sum(tjd.qty)-sum(tjd.ambil) as qty FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "GROUP by tj.kd_penjualan " _
              & "HAVING tj.tanggal BETWEEN '" & Format(tanggal, "yyyy-MM-dd") & "' AND '" & Format(tanggal2, "yyyy-MM-dd") & "' AND qty>0 " _
              & "LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanHarian.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tanggal", tanggal)
            cryReport.SetParameterValue("tanggal2", tanggal2)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN PENJUALAN ANTAR HARIAN"
            cryReport.RecordSelectionFormula = "{@jenis} = 'Antar'"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub barangterjualharian(ByVal tanggal As Date, ByVal tanggal2 As Date)
        query = "SELECT t2.kd_barang, tbr.nama_barang, sum(t2.qty) FROM tb_penjualan t1 " _
            & "JOIN tb_penjualan_detail t2 ON t1.kd_penjualan = t2.kd_penjualan " _
            & "JOIN tb_barang tbr ON t2.kd_barang = tbr.kd_barang " _
            & "WHERE t1.tanggal BETWEEN '" & Format(tanggal, "yyyy-MM-dd") & "' AND '" & Format(tanggal2, "yyyy-MM-dd") & "' " _
            & "GROUP BY t2.kd_barang"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRBarang.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tgl1", tanggal)
            cryReport.SetParameterValue("tgl2", tanggal2)
            cryReport.SetParameterValue("transaksi", "penjualan")
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text17")
            txtObj.Text = "LAPORAN BARANG TERJUAL HARIAN"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub barangdibeliharian(ByVal tanggal As Date, ByVal tanggal2 As Date)
        query = "SELECT t2.kd_barang, tbr.nama_barang, sum(t2.qty) FROM tb_pembelian t1 " _
            & "JOIN tb_pembelian_detail t2 ON t1.kd_pembelian = t2.kd_pembelian " _
            & "JOIN tb_barang tbr ON t2.kd_barang = tbr.kd_barang " _
            & "WHERE t1.tanggal BETWEEN '" & Format(tanggal, "yyyy-MM-dd") & "' AND '" & Format(tanggal2, "yyyy-MM-dd") & "' " _
            & "GROUP BY t2.kd_barang"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRBarang.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tgl1", tanggal)
            cryReport.SetParameterValue("tgl2", tanggal2)
            cryReport.SetParameterValue("transaksi", "pembelian")
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text17")
            txtObj.Text = "LAPORAN BARANG DIBELI HARIAN"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles rbpembelian.CheckedChanged
        If rbharian.Checked And rbpembelian.Checked Then
            pembelianharian(dtp1.Value, dtp2.Value)
        End If
    End Sub

    Private Sub rbpenjualan_CheckedChanged(sender As Object, e As EventArgs) Handles rbpenjualan.CheckedChanged
        If rbharian.Checked And rbpenjualan.Checked Then
            penjualanharian(dtp1.Value, dtp2.Value)
        End If
    End Sub

    Private Sub rbpenjualanlangsung_CheckedChanged(sender As Object, e As EventArgs) Handles rbpenjualanlangsung.CheckedChanged
        If rbharian.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungharian(dtp1.Value, dtp2.Value)
        End If
    End Sub

    Private Sub rbpenjualanantar_CheckedChanged(sender As Object, e As EventArgs) Handles rbpenjualanantar.CheckedChanged
        If rbharian.Checked And rbpenjualanantar.Checked Then
            penjualanantarharian(dtp1.Value, dtp2.Value)
        End If
    End Sub

    Private Sub dtp1_CloseUp(sender As Object, e As EventArgs) Handles dtp1.CloseUp
        If rbharian.Checked And rbpembelian.Checked Then
            pembelianharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbpenjualan.Checked Then
            penjualanharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbpenjualanantar.Checked Then
            penjualanantarharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbbarangterjual.Checked Then
            barangterjualharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbbarangdibeli.Checked Then
            barangdibeliharian(dtp1.Value, dtp2.Value)
        End If
    End Sub

    Private Sub dtp2_CloseUp(sender As Object, e As EventArgs) Handles dtp2.CloseUp
        If rbharian.Checked And rbpembelian.Checked Then
            pembelianharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbpenjualan.Checked Then
            penjualanharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbpenjualanantar.Checked Then
            penjualanantarharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbbarangterjual.Checked Then
            barangterjualharian(dtp1.Value, dtp2.Value)
        ElseIf rbharian.Checked And rbbarangdibeli.Checked Then
            barangdibeliharian(dtp1.Value, dtp2.Value)
        End If
    End Sub

    Private Sub rbbarangterjual_CheckedChanged(sender As Object, e As EventArgs) Handles rbbarangterjual.CheckedChanged
        If rbharian.Checked And rbbarangterjual.Checked Then
            barangterjualharian(dtp1.Value, dtp2.Value)
        End If
    End Sub

    Private Sub rbbarangdibeli_CheckedChanged(sender As Object, e As EventArgs) Handles rbbarangdibeli.CheckedChanged
        If rbharian.Checked And rbbarangdibeli.Checked Then
            barangdibeliharian(dtp1.Value, dtp2.Value)
        End If
    End Sub
End Class