Imports MySql.Data.MySqlClient

Public Class FormUtama

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        infotoko()
    End Sub

    Sub infotoko()
        cmd = New MySqlCommand("SELECT * FROM tb_info WHERE id = 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        lblNamaToko.Text = dr.Item("nama_toko").ToString()
        lblDeskripsi.Text = dr.Item("deskripsi").ToString()
        lblAlamat.Text = "Alamat : " & dr.Item("alamat").ToString()
        lblTelp.Text = "No. Telp : " & dr.Item("no_telp").ToString()
        dr.Close()
    End Sub

    Private Sub PengaturanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PengaturanToolStripMenuItem.Click
        FormPengaturan.ShowDialog()
    End Sub

    Private Sub DataBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataBarangToolStripMenuItem.Click
        'FormBarang.Size = New Size(850, 600)
        'FormBarang.GroupBox2.Visible = False
        FormBarang.ShowDialog()
    End Sub

    Private Sub JenisBarangToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JenisBarangToolStripMenuItem.Click
        FormJenis.from = "utama"
        FormJenis.ShowDialog()
    End Sub

    Private Sub SatuanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SatuanToolStripMenuItem.Click
        FormSatuan.ShowDialog()
    End Sub
End Class
