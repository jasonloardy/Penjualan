Imports MySql.Data.MySqlClient

Public Class FormPengaturan

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        queryedit()
    End Sub

    Private Sub FormPengaturan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        infotoko()
    End Sub

    Sub infotoko()
        cmd = New MySqlCommand("SELECT * FROM tb_info WHERE id = 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        tbNamaToko.Text = dr.Item("nama_toko").ToString()
        tbDeskripsi.Text = dr.Item("deskripsi").ToString()
        tbAlamat.Text = dr.Item("alamat").ToString()
        tbNoTelp.Text = dr.Item("no_telp").ToString()
        dr.Close()
    End Sub

    Sub queryedit()
        Dim stredit As String = "UPDATE tb_info SET nama_toko = '" & tbNamaToko.Text.ToUpper & "',deskripsi = '" & tbDeskripsi.Text.ToUpper & "'," _
                              & "alamat = '" & tbAlamat.Text.ToUpper & "',no_telp = '" & tbNoTelp.Text & "' WHERE id = 1"
        query(stredit)
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        infotoko()
        FormUtama.infotoko()
    End Sub
End Class