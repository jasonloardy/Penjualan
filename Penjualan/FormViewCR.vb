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
    Sub penjualan_langsung(ByVal kd_penjualan As String)
        cryReport.Load(RepLocation & "CRPenjualanLangsung.rpt")
        CRViewer.ReportSource = cryReport
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_penjualan", kd_penjualan)
    End Sub
    Sub penjualan_antar(ByVal kd_penjualan As String)
        cryReport.Load(RepLocation & "CRPenjualanAntar.rpt")
        CRViewer.ReportSource = cryReport
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_penjualan", kd_penjualan)
    End Sub
    Sub pembelian(ByVal kd_pembelian As String)
        cryReport.Load(RepLocation & "CRPembelian.rpt")
        CRViewer.ReportSource = cryReport
        cryReport.Refresh()
        cryReport.SetParameterValue("kd_pembelian", kd_pembelian)
    End Sub
End Class