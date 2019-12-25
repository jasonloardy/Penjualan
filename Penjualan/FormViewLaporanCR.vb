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
    Sub penjualanbulanan(ByVal tahun As String, ByVal bulan As String)
        query = "SELECT tj.tanggal, tj.kd_penjualan, sum(tjd.qty*tjd.harga_jual), sum(tjd.qty*harga_beli) FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "WHERE YEAR(tj.tanggal) = " & tahun & " AND MONTH(tj.tanggal) = " & bulan _
              & " GROUP BY tj.tanggal, tj.kd_penjualan"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanBulanan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            cryReport.SetParameterValue("bulan", bulan)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN SEMUA PENJUALAN BULANAN"
            cryReport.RecordSelectionFormula = "{@jenis} = {@jenis}"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanantarbulanan(ByVal tahun As String, ByVal bulan As String)
        query = "SELECT tj.tanggal, tj.kd_penjualan, sum(tjd.qty*tjd.harga_jual), sum(tjd.qty*harga_beli), sum(tjd.qty)-sum(tjd.ambil) as qty FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "GROUP BY tj.tanggal, tj.kd_penjualan " _
              & "HAVING qty>0 AND YEAR(tj.tanggal) = " & tahun & " AND MONTH(tj.tanggal) = " & bulan
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanBulanan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            cryReport.SetParameterValue("bulan", bulan)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN PENJUALAN ANTAR BULANAN"
            cryReport.RecordSelectionFormula = "{@jenis} = 'Antar'"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanlangsungbulanan(ByVal tahun As String, ByVal bulan As String)
        query = "SELECT tj.tanggal, tj.kd_penjualan, sum(tjd.qty*tjd.harga_jual), sum(tjd.qty*harga_beli), sum(tjd.qty)-sum(tjd.ambil) as qty FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "GROUP BY tj.tanggal, tj.kd_penjualan " _
              & "HAVING qty=0 AND YEAR(tj.tanggal) = " & tahun & " AND MONTH(tj.tanggal) = " & bulan
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanBulanan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            cryReport.SetParameterValue("bulan", bulan)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN PENJUALAN LANGSUNG BULANAN"
            cryReport.RecordSelectionFormula = "{@jenis} = 'Langsung'"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub pembelianbulanan(ByVal tahun As String, ByVal bulan As String)
        query = "SELECT * FROM tb_pembelian WHERE YEAR(tanggal) = " & tahun & " AND MONTH(tanggal) = " & bulan & " LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPembelianBulanan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            cryReport.SetParameterValue("bulan", bulan)
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub barangterjualbulanan(ByVal tahun As String, ByVal bulan As String)
        query = "SELECT t2.kd_barang, tbr.nama_barang, sum(t2.qty) FROM tb_penjualan t1 " _
            & "JOIN tb_penjualan_detail t2 ON t1.kd_penjualan = t2.kd_penjualan " _
            & "JOIN tb_barang tbr ON t2.kd_barang = tbr.kd_barang " _
            & "WHERE YEAR(t1.tanggal) = " & tahun & " AND MONTH(t1.tanggal) = " & bulan _
            & " GROUP BY t2.kd_barang"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRBarangBulanan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            cryReport.SetParameterValue("bulan", bulan)
            cryReport.SetParameterValue("transaksi", "penjualan")
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text17")
            txtObj.Text = "LAPORAN BARANG TERJUAL BULANAN"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub barangdibelibulanan(ByVal tahun As String, ByVal bulan As String)
        query = "SELECT t2.kd_barang, tbr.nama_barang, sum(t2.qty) FROM tb_pembelian t1 " _
            & "JOIN tb_pembelian_detail t2 ON t1.kd_pembelian = t2.kd_pembelian " _
            & "JOIN tb_barang tbr ON t2.kd_barang = tbr.kd_barang " _
            & "WHERE YEAR(t1.tanggal) = " & tahun & " AND MONTH(t1.tanggal) = " & bulan _
            & " GROUP BY t2.kd_barang"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRBarangBulanan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            cryReport.SetParameterValue("bulan", bulan)
            cryReport.SetParameterValue("transaksi", "pembelian")
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text17")
            txtObj.Text = "LAPORAN BARANG DIBELI BULANAN"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub pembeliantahunan(ByVal tahun As String)
        query = "SELECT * FROM tb_pembelian WHERE YEAR(tanggal) = " & tahun & " LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPembelianTahunan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualantahunan(ByVal tahun As String)
        query = "SELECT tj.tanggal, tj.kd_penjualan, sum(tjd.qty*tjd.harga_jual), sum(tjd.qty*harga_beli) FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "WHERE YEAR(tj.tanggal) = " & tahun _
              & " GROUP BY tj.tanggal, tj.kd_penjualan"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanTahunan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN SEMUA PENJUALAN TAHUNAN"
            cryReport.RecordSelectionFormula = "{@jenis} = {@jenis}"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanlangsungtahunan(ByVal tahun As String)
        query = "SELECT tj.tanggal, tj.kd_penjualan, sum(tjd.qty*tjd.harga_jual), sum(tjd.qty*harga_beli), sum(tjd.qty)-sum(tjd.ambil) as qty FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "GROUP BY tj.tanggal, tj.kd_penjualan " _
              & "HAVING qty=0 AND YEAR(tj.tanggal) = " & tahun
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanTahunan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN PENJUALAN LANGSUNG TAHUNAN"
            cryReport.RecordSelectionFormula = "{@jenis} = 'Langsung'"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanantartahunan(ByVal tahun As String)
        query = "SELECT tj.tanggal, tj.kd_penjualan, sum(tjd.qty*tjd.harga_jual), sum(tjd.qty*harga_beli), sum(tjd.qty)-sum(tjd.ambil) as qty FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "GROUP BY tj.tanggal, tj.kd_penjualan " _
              & "HAVING qty>0 AND YEAR(tj.tanggal) = " & tahun
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanTahunan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN PENJUALAN ANTAR TAHUNAN"
            cryReport.RecordSelectionFormula = "{@jenis} = 'Antar'"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub barangterjualtahunan(ByVal tahun As String)
        query = "SELECT t2.kd_barang, tbr.nama_barang, sum(t2.qty) FROM tb_penjualan t1 " _
            & "JOIN tb_penjualan_detail t2 ON t1.kd_penjualan = t2.kd_penjualan " _
            & "JOIN tb_barang tbr ON t2.kd_barang = tbr.kd_barang " _
            & "WHERE YEAR(t1.tanggal) = " & tahun _
            & " GROUP BY t2.kd_barang"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRBarangTahunan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            cryReport.SetParameterValue("transaksi", "penjualan")
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text17")
            txtObj.Text = "LAPORAN BARANG TERJUAL TAHUNAN"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub barangdibelitahunan(ByVal tahun As String)
        query = "SELECT t2.kd_barang, tbr.nama_barang, sum(t2.qty) FROM tb_pembelian t1 " _
            & "JOIN tb_pembelian_detail t2 ON t1.kd_pembelian = t2.kd_pembelian " _
            & "JOIN tb_barang tbr ON t2.kd_barang = tbr.kd_barang " _
            & "WHERE YEAR(t1.tanggal) = " & tahun _
            & " GROUP BY t2.kd_barang"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRBarangTahunan.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tahun", tahun)
            cryReport.SetParameterValue("transaksi", "pembelian")
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text17")
            txtObj.Text = "LAPORAN BARANG DIBELI TAHUNAN"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles rbpembelian.CheckedChanged
        If rbharian.Checked And rbpembelian.Checked Then
            pembelianharian(dtp1.Value, dtp2.Value)
        ElseIf rbbulanan.Checked And rbpembelian.Checked Then
            pembelianbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbtahunan.Checked And rbpembelian.Checked Then
            pembeliantahunan(cbtahun.SelectedValue)
        End If
    End Sub

    Private Sub rbpenjualan_CheckedChanged(sender As Object, e As EventArgs) Handles rbpenjualan.CheckedChanged
        If rbharian.Checked And rbpenjualan.Checked Then
            penjualanharian(dtp1.Value, dtp2.Value)
        ElseIf rbbulanan.Checked And rbpenjualan.Checked Then
            penjualanbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbtahunan.Checked And rbpenjualan.Checked Then
            penjualantahunan(cbtahun.SelectedValue)
        End If
    End Sub

    Private Sub rbpenjualanlangsung_CheckedChanged(sender As Object, e As EventArgs) Handles rbpenjualanlangsung.CheckedChanged
        If rbharian.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungharian(dtp1.Value, dtp2.Value)
        ElseIf rbbulanan.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbtahunan.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungtahunan(cbtahun.SelectedValue)
        End If
    End Sub

    Private Sub rbpenjualanantar_CheckedChanged(sender As Object, e As EventArgs) Handles rbpenjualanantar.CheckedChanged
        If rbharian.Checked And rbpenjualanantar.Checked Then
            penjualanantarharian(dtp1.Value, dtp2.Value)
        ElseIf rbbulanan.Checked And rbpenjualanantar.Checked Then
            penjualanantarbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbtahunan.Checked And rbpenjualanantar.Checked Then
            penjualanantartahunan(cbtahun.SelectedValue)
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
        ElseIf rbbulanan.Checked And rbbarangterjual.Checked Then
            barangterjualbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbtahunan.Checked And rbbarangterjual.Checked Then
            barangterjualtahunan(cbtahun.SelectedValue)
        End If
    End Sub

    Private Sub rbbarangdibeli_CheckedChanged(sender As Object, e As EventArgs) Handles rbbarangdibeli.CheckedChanged
        If rbharian.Checked And rbbarangdibeli.Checked Then
            barangdibeliharian(dtp1.Value, dtp2.Value)
        ElseIf rbbulanan.Checked And rbbarangdibeli.Checked Then
            barangdibelibulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbtahunan.Checked And rbbarangdibeli.Checked Then
            barangdibelitahunan(cbtahun.SelectedValue)
        End If
    End Sub

    Private Sub rbbulanan_CheckedChanged(sender As Object, e As EventArgs) Handles rbbulanan.CheckedChanged
        If rbbulanan.Checked And rbpenjualan.Checked Then
            penjualanbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbpenjualanantar.Checked Then
            penjualanantarbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbpembelian.Checked Then
            pembelianbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbbarangterjual.Checked Then
            barangterjualbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbbarangdibeli.Checked Then
            barangdibelibulanan(dtp3.Value.Year, dtp3.Value.Month)
        End If
    End Sub

    Private Sub dtp3_CloseUp(sender As Object, e As EventArgs) Handles dtp3.CloseUp
        If rbbulanan.Checked And rbpenjualan.Checked Then
            penjualanbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbpenjualanantar.Checked Then
            penjualanantarbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbpembelian.Checked Then
            pembelianbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbbarangterjual.Checked Then
            barangterjualbulanan(dtp3.Value.Year, dtp3.Value.Month)
        ElseIf rbbulanan.Checked And rbbarangdibeli.Checked Then
            barangdibelibulanan(dtp3.Value.Year, dtp3.Value.Month)
        End If
    End Sub

    Private Sub rbtahunan_CheckedChanged(sender As Object, e As EventArgs) Handles rbtahunan.CheckedChanged
        If rbtahunan.Checked And rbpembelian.Checked Then
            pembeliantahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbpenjualan.Checked Then
            penjualantahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungtahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbpenjualanantar.Checked Then
            penjualanantartahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbbarangterjual.Checked Then
            barangterjualtahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbbarangdibeli.Checked Then
            barangdibelitahunan(cbtahun.SelectedValue)
        End If
    End Sub

    Private Sub FormViewLaporanCR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cb_tahun()
    End Sub
    Sub cb_tahun()
        Dim q As String = "(SELECT YEAR(tanggal) tahun FROM tb_pembelian) " _
                        & "UNION " _
                        & "(SELECT YEAR(tanggal) tahun FROM tb_penjualan) " _
                        & "ORDER BY tahun DESC"
        cbtahun.DataSource = querycb(q)
        cbtahun.ValueMember = "tahun"
        cbtahun.DisplayMember = "tahun"
    End Sub

    Private Sub cbtahun_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbtahun.SelectedIndexChanged
        If rbtahunan.Checked And rbpembelian.Checked Then
            pembeliantahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbpenjualan.Checked Then
            penjualantahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungtahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbpenjualanantar.Checked Then
            penjualanantartahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbbarangterjual.Checked Then
            barangterjualtahunan(cbtahun.SelectedValue)
        ElseIf rbtahunan.Checked And rbbarangdibeli.Checked Then
            barangdibelitahunan(cbtahun.SelectedValue)
        End If
    End Sub
End Class