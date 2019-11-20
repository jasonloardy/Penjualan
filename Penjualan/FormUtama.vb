Imports MySql.Data.MySqlClient

Public Class FormUtama

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        Me.MaximizeBox = False
    End Sub

    Sub allclose()
        For Each aform As Form In Me.MdiChildren
            aform.Dispose()
        Next
    End Sub

    Private Sub DataBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataBarangToolStripMenuItem.Click
        allclose()
        FormBarang.from = "utama"
        FormBarang.MdiParent = Me
        FormBarang.Dock = DockStyle.Fill
        FormBarang.Show()
    End Sub

    Private Sub JenisBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JenisBarangToolStripMenuItem.Click
        allclose()
        FormJenis.from = "utama"
        FormJenis.MdiParent = Me
        FormJenis.Dock = DockStyle.Fill
        FormJenis.Show()
    End Sub

    Private Sub SatuanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SatuanToolStripMenuItem.Click
        allclose()
        FormSatuan.from = "utama"
        FormSatuan.MdiParent = Me
        FormSatuan.Dock = DockStyle.Fill
        FormSatuan.Show()
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        allclose()
        FormBarang.from = "penjualan"
        FormBarang.MdiParent = Me
        FormBarang.Dock = DockStyle.Fill
        FormBarang.Show()
    End Sub

    Private Sub DataPelangganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPelangganToolStripMenuItem.Click
        allclose()
        FormPelanggan.from = "utama"
        FormPelanggan.MdiParent = Me
        FormPelanggan.Dock = DockStyle.Fill
        FormPelanggan.Show()
    End Sub

    Private Sub DataSupplierToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataSupplierToolStripMenuItem.Click
        allclose()
        FormSupplier.from = "utama"
        FormSupplier.MdiParent = Me
        FormSupplier.Dock = DockStyle.Fill
        FormSupplier.Show()
    End Sub

    Private Sub PembelianToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem.Click
        allclose()
        FormPembelian.MdiParent = Me
        FormPembelian.Dock = DockStyle.Fill
        FormPembelian.Show()
    End Sub
End Class
