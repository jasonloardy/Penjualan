Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class FormViewLaporanCR
    Dim cryReport As New ReportDocument
    Dim RepLocation = Path.GetFullPath( _
            Path.Combine(Application.StartupPath, "..\..\"))
    Sub pembelianharian(ByVal tanggal As Date)
        cryReport.Load(RepLocation & "CRPembelianHarian.rpt")
        CRViewer.ReportSource = cryReport
        cryReport.Refresh()
        cryReport.SetParameterValue("tanggal", tanggal)
    End Sub
    Sub penjualanharian(ByVal tanggal As Date)
        cryReport.Load(RepLocation & "CRPenjualanHarian.rpt")
        CRViewer.ReportSource = cryReport
        cryReport.Refresh()
        cryReport.SetParameterValue("tanggal", tanggal)
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles rbpembelian.CheckedChanged
        If rbharian.Checked And rbpembelian.Checked Then
            pembelianharian(dtpharian.Value)
        ElseIf rbharian.Checked And rbpenjualan.Checked Then
            penjualanharian(dtpharian.Value)
        End If
    End Sub

    Private Sub dtpharian_CloseUp(sender As Object, e As EventArgs) Handles dtpharian.CloseUp
        If rbharian.Checked And rbpembelian.Checked Then
            pembelianharian(dtpharian.Value)
        ElseIf rbharian.Checked And rbpenjualan.Checked Then
            penjualanharian(dtpharian.Value)
        End If
    End Sub
End Class