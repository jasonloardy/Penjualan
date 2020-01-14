Imports MySql.Data.MySqlClient

Public Class FormSopir
    Public mode As String
    Public id_data As String
    Public from As String

    Private Sub FormSopir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigrid()
        reset()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT * FROM tb_sopir"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgv.DataSource = ds.Tables(0)
            dgv.Refresh()
        Else
            dgv.DataSource = Nothing
        End If
        If dgv.RowCount > 0 Then
            judulgrid()
        End If
    End Sub
    Sub judulgrid()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgv.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgv.Columns(0).DefaultCellStyle
        dgv.Columns(0).HeaderText = "ID"
        dgv.Columns(1).HeaderText = "Nama Sopir"
        dgv.Columns(0).Width = 150
        dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub kode_sopir()
        cmd = New MySqlCommand("SELECT kd_sopir FROM tb_sopir ORDER BY kd_sopir DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            tbkdsopir.Text = "SR01"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_sopir").ToString, 2)) + 1
            If Len(hitung) = 1 Then
                tbkdsopir.Text = "SR0" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdsopir.Text = "SR" & hitung
            End If
        End If
        dr.Close()
    End Sub
    Sub bersih()
        tbkdsopir.Clear()
        tbnamasopir.Clear()
    End Sub
    Sub reset()
        tbnamasopir.Enabled = False
        bersih()
        btntambah.Enabled = True
        btntambah.Text = "Tambah"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub modesimpan()
        tbnamasopir.Enabled = True
        btntambah.Enabled = True
        btntambah.Text = "Simpan"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub GridToTextBox()
        dgv.Refresh()
        If dgv.RowCount > 0 Then
            Dim baris As Integer
            With dgv
                baris = .CurrentRow.Index
                id_data = .Item(0, baris).Value
                tbkdsopir.Text = .Item(0, baris).Value
                tbnamasopir.Text = .Item(1, baris).Value
            End With
        End If
    End Sub
    Sub querytambah()
        Dim query As String = "INSERT INTO tb_sopir VALUES (@kd_sopir, @nama_sopir)"
        Querysopir(query, tbkdsopir.Text, tbnamasopir.Text.ToUpper)
        MsgBox("Berhasil tambah data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryedit()
        Dim query As String = "UPDATE tb_sopir SET nama_sopir = @nama_sopir WHERE kd_sopir = @kd_sopir"
        Querysopir(query, id_data, tbnamasopir.Text.ToUpper)
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryhapus()
        cmd.CommandText = "SELECT * FROM tb_suratjalan WHERE sopir = '" & id_data & "'"
        cmd.Connection = konek
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("Sopir tidak dapat dihapus!", 48, "Perhatian")
        Else
            dr.Close()
            Dim query As String = "DELETE FROM tb_sopir WHERE kd_sopir = @kd_sopir"
            Querysopir(query, id_data, "")
            isigrid()
            MsgBox("Berhasil hapus data!", MsgBoxStyle.Information, "Informasi")
        End If
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        If btntambah.Text = "Tambah" Then
            mode = "tambah"
            modesimpan()
            bersih()
            kode_sopir()
        Else
            If tbnamasopir.Text = "" Then
                MsgBox("Lengkapi data yang kosong!", 16, "Informasi")
            Else
                If mode = "tambah" Then
                    querytambah()
                    reset()
                Else
                    queryedit()
                    reset()
                End If
            End If
        End If
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        mode = "edit"
        modesimpan()
    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        reset()
        GridToTextBox()
        btntambah.Enabled = False
        btnedit.Enabled = True
        btnhapus.Enabled = True
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim nhps As Integer
        nhps = MsgBox("Yakin hapus sopir " & tbnamasopir.Text & " (" & tbkdsopir.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            queryhapus()
            reset()
        End If
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        reset()
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If from = "suratjalan" Then
            FormSuratJalan.tbkdsopir.Text = tbkdsopir.Text
            FormSuratJalan.tbnamasopir.Text = tbnamasopir.Text
            Me.Close()
        End If
    End Sub
End Class