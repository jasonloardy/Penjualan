Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class FormViewLaporanCR
    Dim cryReport As New ReportDocument
    Dim RepLocation = Path.GetFullPath( _
            Path.Combine(Application.StartupPath, "..\..\"))
    Dim query As String
    Sub pembelianharian(ByVal tanggal As Date)
        query = "SELECT * FROM tb_pembelian WHERE tanggal = '" & Format(tanggal, "yyyy-MM-dd") & "' LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPembelianHarian.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tanggal", tanggal)
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanharian(ByVal tanggal As Date)
        query = "SELECT * FROM tb_penjualan WHERE tanggal = '" & Format(tanggal, "yyyy-MM-dd") & "' LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanHarian.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tanggal", tanggal)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN SEMUA PENJUALAN HARIAN"
            cryReport.RecordSelectionFormula = "{@jenis} = {@jenis}"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanlangsungharian(ByVal tanggal As Date)
        query = "SELECT tj.tanggal,sum(tjd.qty)-sum(tjd.ambil) as qty FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "GROUP by tj.kd_penjualan " _
              & "HAVING tj.tanggal = '" & Format(tanggal, "yyyy-MM-dd") & "' AND qty=0 " _
              & "LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanHarian.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tanggal", tanggal)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN PENJUALAN LANGSUNG HARIAN"
            cryReport.RecordSelectionFormula = "{@jenis} = 'Langsung'"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Sub penjualanantarharian(ByVal tanggal As Date)
        query = "SELECT tj.tanggal,sum(tjd.qty)-sum(tjd.ambil) as qty FROM tb_penjualan tj " _
              & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
              & "GROUP by tj.kd_penjualan " _
              & "HAVING tj.tanggal = '" & Format(tanggal, "yyyy-MM-dd") & "' AND qty>0 " _
              & "LIMIT 1"
        If cekdata(query) Then
            cryReport.Load(RepLocation & "CRPenjualanHarian.rpt")
            cryReport.Refresh()
            cryReport.SetParameterValue("tanggal", tanggal)
            Dim txtObj As TextObject = cryReport.ReportDefinition.ReportObjects("text1")
            txtObj.Text = "LAPORAN PENJUALAN ANTAR HARIAN"
            cryReport.RecordSelectionFormula = "{@jenis} = 'Antar'"
            CRViewer.ReportSource = cryReport
        Else
            CRViewer.ReportSource = Nothing
            MsgBox("Data Kosong!")
        End If
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles rbpembelian.CheckedChanged
        If rbharian.Checked And rbpembelian.Checked Then
            pembelianharian(dtpharian.Value)
        End If
    End Sub

    Private Sub dtpharian_CloseUp(sender As Object, e As EventArgs) Handles dtpharian.CloseUp
        If rbharian.Checked And rbpembelian.Checked Then
            pembelianharian(dtpharian.Value)
        ElseIf rbharian.Checked And rbpenjualan.Checked Then
            penjualanharian(dtpharian.Value)
        ElseIf rbharian.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungharian(dtpharian.Value)
        ElseIf rbharian.Checked And rbpenjualanantar.Checked Then
            penjualanantarharian(dtpharian.Value)
        End If
    End Sub

    Private Sub rbpenjualan_CheckedChanged(sender As Object, e As EventArgs) Handles rbpenjualan.CheckedChanged
        If rbharian.Checked And rbpenjualan.Checked Then
            penjualanharian(dtpharian.Value)
        End If
    End Sub

    Private Sub rbpenjualanlangsung_CheckedChanged(sender As Object, e As EventArgs) Handles rbpenjualanlangsung.CheckedChanged
        If rbharian.Checked And rbpenjualanlangsung.Checked Then
            penjualanlangsungharian(dtpharian.Value)
        End If
    End Sub

    Private Sub rbpenjualanantar_CheckedChanged(sender As Object, e As EventArgs) Handles rbpenjualanantar.CheckedChanged
        If rbharian.Checked And rbpenjualanantar.Checked Then
            penjualanantarharian(dtpharian.Value)
        End If
    End Sub
End Class