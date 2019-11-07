Imports MySql.Data.MySqlClient

Public Class FormUtama

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
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
