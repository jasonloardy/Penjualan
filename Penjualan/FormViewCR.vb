Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class FormViewCR
    Dim cryReport As New ReportDocument
    Dim RepLocation = Path.GetFullPath( _
            Path.Combine(Application.StartupPath, "..\..\"))
    Sub suratjalan(ByVal kd_suratjalan As String)
        cryReport.Load(RepLocation & "CRSuratJalan.rpt")
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_suratjalan", kd_suratjalan)
        CRViewer.ReportSource = cryReport
    End Sub
    Sub penjualan_langsung(ByVal kd_penjualan As String)
        cryReport.Load(RepLocation & "CRPenjualanLangsung.rpt")
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_penjualan", kd_penjualan)
        CRViewer.ReportSource = cryReport
    End Sub
    Sub penjualan_antar(ByVal kd_penjualan As String)
        cryReport.Load(RepLocation & "CRPenjualanAntar.rpt")
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_penjualan", kd_penjualan)
        CRViewer.ReportSource = cryReport
    End Sub
    Sub pembelian(ByVal kd_pembelian As String)
        cryReport.Load(RepLocation & "CRPembelian.rpt")
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_pembelian", kd_pembelian)
        CRViewer.ReportSource = cryReport
    End Sub
End Class