Imports MySql.Data.MySqlClient

Public Class FormUtama

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("id-ID")
        koneksi()
        resetkeranjang()
    End Sub

    Sub allclose()
        For Each aform As Form In Me.MdiChildren
            aform.Dispose()
        Next
    End Sub

    Private Sub JenisBarangToolStripMenuItem_Click(sender As Object, e As EventArgs)
        allclose()
        FormJenis.from = "utama"
        FormJenis.MdiParent = Me
        FormJenis.Dock = DockStyle.Fill
        FormJenis.Show()
    End Sub

    Private Sub SatuanToolStripMenuItem_Click(sender As Object, e As EventArgs)
        allclose()
        FormSatuan.from = "utama"
        FormSatuan.MdiParent = Me
        FormSatuan.Dock = DockStyle.Fill
        FormSatuan.Show()
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem.Click
        allclose()
        FormPenjualan.MdiParent = Me
        FormPenjualan.Dock = DockStyle.Fill
        FormPenjualan.Show()
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

    Private Sub DataSopirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataSopirToolStripMenuItem.Click
        allclose()
        FormSopir.from = "utama"
        FormSopir.MdiParent = Me
        FormSopir.Dock = DockStyle.Fill
        FormSopir.Show()
    End Sub

    Private Sub SuratJalanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SuratJalanToolStripMenuItem1.Click
        allclose()
        FormSuratJalan.MdiParent = Me
        FormSuratJalan.Dock = DockStyle.Fill
        FormSuratJalan.Show()
    End Sub

    Private Sub SuratJalanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuratJalanToolStripMenuItem.Click
        allclose()
        FormDaftarTransaksi.from = "ctksuratjalan"
        FormDaftarTransaksi.MdiParent = Me
        FormDaftarTransaksi.Dock = DockStyle.Fill
        FormDaftarTransaksi.Show()
    End Sub

    Private Sub PembelianToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PembelianToolStripMenuItem1.Click
        allclose()
        FormDaftarTransaksi.from = "ctkpembelian"
        FormDaftarTransaksi.MdiParent = Me
        FormDaftarTransaksi.Dock = DockStyle.Fill
        FormDaftarTransaksi.Show()
    End Sub

    Private Sub PenjualanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem1.Click
        allclose()
        FormDaftarTransaksi.from = "ctkpenjualan"
        FormDaftarTransaksi.MdiParent = Me
        FormDaftarTransaksi.Dock = DockStyle.Fill
        FormDaftarTransaksi.Show()
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem.Click
        allclose()
        FormViewLaporanCR.MdiParent = Me
        FormViewLaporanCR.Dock = DockStyle.Fill
        FormViewLaporanCR.Show()
    End Sub

    Private Sub JenisBarangToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles JenisBarangToolStripMenuItem1.Click
        allclose()
        FormJenis.from = "utama"
        FormJenis.MdiParent = Me
        FormJenis.Dock = DockStyle.Fill
        FormJenis.Show()
    End Sub

    Private Sub SatuanBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SatuanBarangToolStripMenuItem.Click
        allclose()
        FormSatuan.from = "utama"
        FormSatuan.MdiParent = Me
        FormSatuan.Dock = DockStyle.Fill
        FormSatuan.Show()
    End Sub

    Private Sub DaftarBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaftarBarangToolStripMenuItem.Click
        allclose()
        FormBarang.from = "utama"
        FormBarang.MdiParent = Me
        FormBarang.Dock = DockStyle.Fill
        FormBarang.Show()
    End Sub
End Class
