Imports MySql.Data.MySqlClient
Imports System.Data.SqlClient

Public Class FormSatuan
    Public mode As String
    Public id_data As String
    Public from As String
    Private Sub FormJenis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        isigrid()
        reset()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT * FROM tb_satuan"
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
        dgv.Columns(1).HeaderText = "Nama Satuan"
        dgv.Columns(0).Width = 150
        dgv.Columns(1).Width = 350
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub kode_satuan()
        cmd = New MySqlCommand("SELECT kd_satuan FROM tb_satuan ORDER BY kd_satuan DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            tbkdsatuan.Text = "S001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_satuan").ToString, 3)) + 1
            If Len(hitung) = 1 Then
                tbkdsatuan.Text = "S00" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdsatuan.Text = "S0" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdsatuan.Text = "S" & hitung
            End If
        End If
        dr.Close()
    End Sub
    Sub bersih()
        tbkdsatuan.Clear()
        tbnamasatuan.Clear()
    End Sub

    Sub reset()
        tbnamasatuan.Enabled = False
        bersih()
        btntambah.Enabled = True
        btntambah.Text = "Tambah"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub modesimpan()
        tbnamasatuan.Enabled = True
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
                tbkdsatuan.Text = .Item(0, baris).Value
                tbnamasatuan.Text = .Item(1, baris).Value
            End With
        End If
    End Sub
    Sub querytambah()
        Dim query As String = "INSERT INTO tb_satuan VALUES (@kd_satuan, @nama_satuan)"
        QuerySatuan(query, tbkdsatuan.Text, tbnamasatuan.Text.ToUpper)
        MsgBox("Berhasil tambah data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryedit()
        Dim query As String = "UPDATE tb_satuan SET nama_satuan = @nama_satuan WHERE kd_satuan = @kd_satuan"
        QuerySatuan(query, id_data, tbnamasatuan.Text.ToUpper)
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryhapus()
        cmd.CommandText = "SELECT * FROM tb_barang WHERE satuan = '" & id_data & "'"
        cmd.Connection = konek
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("Satuan tidak dapat dihapus!", 48, "Perhatian")
        Else
            dr.Close()
            Dim query As String = "DELETE FROM tb_satuan WHERE kd_satuan = @kd_satuan"
            QuerySatuan(query, id_data, "")
            isigrid()
            MsgBox("Berhasil hapus data!", MsgBoxStyle.Information, "Informasi")
        End If
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        If btntambah.Text = "Tambah" Then
            mode = "tambah"
            modesimpan()
            bersih()
            kode_satuan()
        Else
            If tbnamasatuan.Text = "" Then
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
        nhps = MsgBox("Yakin hapus satuan " & tbnamasatuan.Text & " (" & tbkdsatuan.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            queryhapus()
            reset()
        End If
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        reset()
    End Sub

    Private Sub FormSatuan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If from = "barang" Then
            FormBarang.isicb()
        End If
    End Sub
End Class