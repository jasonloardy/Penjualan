Imports MySql.Data.MySqlClient

Public Class FormBarang
    Public mode As String
    Public id_data As String
    Public from As String
    Private Sub btnjenis_Click(sender As Object, e As EventArgs) Handles btnjenis.Click
        FormJenis.from = "barang"
        FormJenis.ShowDialog()
    End Sub

    Private Sub btnsatuan_Click(sender As Object, e As EventArgs) Handles btnsatuan.Click
        FormSatuan.from = "barang"
        FormSatuan.ShowDialog()
    End Sub

    Sub isicb()
        Dim q As String = "SELECT * FROM tb_jenis"
        cbjenis.DataSource = querycb(q)
        cbjenis.ValueMember = "kd_jenis"
        cbjenis.DisplayMember = "nama_jenis"

        q = "SELECT * FROM tb_satuan"
        cbsatuan.DataSource = querycb(q)
        cbsatuan.ValueMember = "kd_satuan"
        cbsatuan.DisplayMember = "nama_satuan"
    End Sub

    Private Sub FormBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        isigrid()
        isicb()
        reset()
    End Sub

    Sub isigrid()
        Dim query As String = "SELECT kd_barang,nama_barang,tj.nama_jenis,ts.nama_satuan,harga_beli,harga_jual,stok FROM tb_barang tb " _
                             & "JOIN tb_jenis tj ON tb.kd_jenis = tj.kd_jenis JOIN tb_satuan ts ON tb.kd_satuan=ts.kd_satuan"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgv.DataSource = ds.Tables(0)
            dgv.Refresh()
        Else
            dgv.DataSource = Nothing
        End If
        If dgv.RowCount > 0 Then
            'judulgrid()
        End If
    End Sub
    Sub judulgrid()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgv.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgv.Columns(0).DefaultCellStyle
        'dgv.Columns(0).HeaderText = "ID"
        'dgv.Columns(1).HeaderText = "Jenis Barang"
        'dgv.Columns(0).Width = 150
        'dgv.Columns(1).Width = 350
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub kode_barang()
        cmd = New MySqlCommand("SELECT kd_barang FROM tb_barang WHERE kd_barang LIKE 'B%'" _
                             & "ORDER BY kd_barang DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            tbkdbarang.Text = "B0000001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_barang").ToString, 7)) + 1
            If Len(hitung) = 1 Then
                tbkdbarang.Text = "B000000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdbarang.Text = "B00000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdbarang.Text = "B0000" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdbarang.Text = "B000" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdbarang.Text = "B00" & hitung
            ElseIf Len(hitung) = 6 Then
                tbkdbarang.Text = "B0" & hitung
            ElseIf Len(hitung) = 7 Then
                tbkdbarang.Text = "B" & hitung
            End If
        End If
        tbkdbarang.Enabled = False
        dr.Close()
    End Sub
    Sub bersih()
        tbkdbarang.Clear()
        tbnamabarang.Clear()
        cbjenis.SelectedIndex = -1
        cbsatuan.SelectedIndex = -1
        tbhargabeli.Clear()
        tbhargajual.Clear()
        tbstok.Clear()
    End Sub
    Sub reset()
        GroupBox2.Enabled = False
        bersih()
        btntambah.Enabled = True
        btntambah.Text = "Tambah"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub modesimpan()
        GroupBox2.Enabled = True
        btntambah.Enabled = True
        btntambah.Text = "Simpan"
        btnedit.Enabled = False
        btnhapus.Enabled = False
    End Sub
    Sub querytambah()
        Dim query As String = "INSERT INTO tb_barang VALUES (@kd_barang, @nama_barang, @kd_jenis, @kd_satuan, " _
                            & "@harga_beli, @harga_jual, @stok)"
        QueryBarang(query, tbkdbarang.Text, tbnamabarang.Text.ToUpper, cbjenis.SelectedValue, cbsatuan.SelectedValue,
                    tbhargabeli.Text, tbhargajual.Text, tbstok.Text)
        MsgBox("Berhasil tambah data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub
    Sub queryedit()
        Dim query As String = "UPDATE tb_barang SET nama_barang = @nama_barang, kd_jenis = @kd_jenis, " _
                            & "kd_satuan = @kd_satuan, harga_beli = @harga_beli, harga_jual = @harga_jual, " _
                            & "stok = @stok WHERE kd_barang = @kd_barang"
        QueryBarang(query, id_data, tbnamabarang.Text.ToUpper, cbjenis.SelectedValue, cbsatuan.SelectedValue,
                    tbhargabeli.Text, tbhargajual.Text, tbstok.Text)
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        isigrid()
    End Sub

    Sub queryhapus()
        Dim queryhapus As String = "DELETE FROM tb_barang WHERE kd_barang = " & id_data
        Query(queryhapus)
        isigrid()
        MsgBox("Berhasil hapus data!", MsgBoxStyle.Information, "Informasi")
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles chkbarcode.CheckedChanged
        If Not chkbarcode.Checked Then
            kode_barang()
        Else
            tbkdbarang.Clear()
            tbkdbarang.Enabled = True
            tbkdbarang.Focus()
        End If
    End Sub

    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        If btntambah.Text = "Tambah" Then
            mode = "tambah"
            modesimpan()
            bersih()
            kode_barang()
        Else
            If tbnamabarang.Text = "" Then
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

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim nhps As Integer
        nhps = MsgBox("Yakin hapus barang " & tbnamabarang.Text & " (" & tbkdbarang.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            queryhapus()
            reset()
        End If
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        reset()
    End Sub
End Class