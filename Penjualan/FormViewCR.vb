Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class FormViewCR
    Dim cryReport As New ReportDocument
    Dim RepLocation = Path.GetFullPath( _
            Path.Combine(Application.StartupPath, "..\..\"))
    Sub suratjalan(ByVal kd_suratjalan As String)
        cryReport.Load(RepLocation & "CRSuratJalan.rpt")
        CRViewer.ReportSource = cryReport
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_suratjalan", kd_suratjalan)
    End Sub
End Class