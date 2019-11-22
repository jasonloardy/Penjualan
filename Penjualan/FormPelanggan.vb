Imports MySql.Data.MySqlClient

Public Class FormPelanggan
    Public mode As String
    Public id_data As String
    Public from As String
    Public halaman As Integer = 1

    Private Sub FormBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbpage.Text = "1"
        isigrid(tbpage.Text)
        reset()
    End Sub

    Sub isigrid(ByVal page As String)
        Dim jumlahitem As Integer = 50
        Dim index As Integer = jumlahitem * (page - 1)
        Dim query As String = "SELECT * FROM tb_pelanggan " _
                             & "WHERE (kd_pelanggan LIKE @kd_pelanggan OR nama LIKE @nama) " _
                             & "LIMIT " & index & ", " & jumlahitem
        cmd = New MySqlCommand(query, konek)
        cmd.Parameters.AddWithValue("@kd_pelanggan", "%" + tbcari.Text + "%")
        cmd.Parameters.AddWithValue("@nama", "%" + tbcari.Text + "%")
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dt = New DataTable
            dt.Load(dr)
            dgv.DataSource = dt
            dr.Close()
            cmd = New MySqlCommand("SELECT COUNT(*) FROM tb_pelanggan WHERE (kd_pelanggan LIKE @kd_pelanggan OR nama LIKE @nama)", konek)
            cmd.Parameters.AddWithValue("@kd_pelanggan", "%" + tbcari.Text + "%")
            cmd.Parameters.AddWithValue("@nama", "%" + tbcari.Text + "%")
            dr = cmd.ExecuteReader
            dr.Read()
            halaman = Math.Ceiling(dr.Item(0).ToString / jumlahitem)
            dr.Close()
            lbltotpage.Text = " / " & halaman
        Else
            dr.Close()
            dgv.DataSource = Nothing
            tbpage.Text = "1"
            lbltotpage.Text = " / 0"
        End If
        If dgv.RowCount > 0 Then
            judulgrid()
        End If
        paging()
        cmd = New MySqlCommand("SELECT COUNT(*) FROM tb_pelanggan", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        lbltotitem.Text = "Jumlah Pelanggan : " & dr.Item(0).ToString
        dr.Close()
    End Sub
    Sub judulgrid()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgv.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgv.Columns(0).DefaultCellStyle
        dgv.Columns(0).HeaderText = "Kd. Pelanggan"
        dgv.Columns(0).Width = 115
        dgv.Columns(1).HeaderText = "Nama Pelanggan"
        dgv.Columns(1).Width = 200
        dgv.Columns(2).HeaderText = "Alamat"
        dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(3).HeaderText = "No. Telepon"
        dgv.Columns(3).Width = 150
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
    Sub kode_pelanggan()
        cmd = New MySqlCommand("SELECT kd_pelanggan FROM tb_pelanggan WHERE kd_pelanggan LIKE 'P%'" _
                             & "ORDER BY kd_pelanggan DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            tbkdpelanggan.Text = "PL000001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_pelanggan").ToString, 6)) + 1
            If Len(hitung) = 1 Then
                tbkdpelanggan.Text = "PL00000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdpelanggan.Text = "PL0000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdpelanggan.Text = "PL000" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdpelanggan.Text = "PL00" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdpelanggan.Text = "PL0" & hitung
            ElseIf Len(hitung) = 6 Then
                tbkdpelanggan.Text = "PL" & hitung
            End If
        End If
        dr.Close()
    End Sub
    Sub bersih()
        tbkdpelanggan.Clear()
        tbnama.Clear()
        tbalamat.Clear()
        tbnotelp.Clear()
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
        Dim query As String = "INSERT INTO tb_pelanggan VALUES (@kd, @nama, @alamat, @no_telp)"
        QueryPelSup(query, tbkdpelanggan.Text, tbnama.Text.ToUpper, tbalamat.Text.ToUpper, tbnotelp.Text.ToUpper)
        MsgBox("Berhasil tambah data!", MsgBoxStyle.Information, "Informasi")
        isigrid(tbpage.Text)
    End Sub
    Sub queryedit()
        Dim query As String = "UPDATE tb_pelanggan SET nama = @nama, alamat = @alamat, no_telp = @no_telp " _
                            & "WHERE kd_pelanggan = @kd"
        QueryPelSup(query, id_data, tbnama.Text.ToUpper, tbalamat.Text.ToUpper, tbnotelp.Text.ToUpper)
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        isigrid(tbpage.Text)
    End Sub

    Sub queryhapus()
        Dim queryhapus As String = "DELETE FROM tb_pelanggan WHERE kd_pelanggan = '" & id_data & "'"
        Query(queryhapus)
        isigrid(tbpage.Text)
        MsgBox("Berhasil hapus data!", MsgBoxStyle.Information, "Informasi")
    End Sub
    Private Sub btntambah_Click(sender As Object, e As EventArgs) Handles btntambah.Click
        If btntambah.Text = "Tambah" Then
            mode = "tambah"
            modesimpan()
            bersih()
            kode_pelanggan()
        Else
            If tbnama.Text = "" Then
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
    Sub GridToTextBox()
        dgv.Refresh()
        If dgv.RowCount > 0 Then
            Dim baris As Integer
            With dgv
                baris = .CurrentRow.Index
                id_data = .Item(0, baris).Value
                tbkdpelanggan.Text = .Item(0, baris).Value
                tbnama.Text = .Item(1, baris).Value
                tbalamat.Text = .Item(2, baris).Value
                tbnotelp.Text = .Item(3, baris).Value
            End With
        End If
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        mode = "edit"
        modesimpan()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Dim nhps As Integer
        nhps = MsgBox("Yakin hapus pelanggan " & tbnama.Text & " (" & tbkdpelanggan.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            queryhapus()
            reset()
        End If
    End Sub

    Private Sub btnbatal_Click(sender As Object, e As EventArgs) Handles btnbatal.Click
        reset()
    End Sub

    Private Sub dgv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellEnter
        reset()
        GridToTextBox()
        btntambah.Enabled = False
        btnedit.Enabled = True
        btnhapus.Enabled = True
    End Sub

    Private Sub tbpage_TextChanged(sender As Object, e As EventArgs) Handles tbpage.TextChanged
        If Not (tbpage.Text = "" Or Val(tbpage.Text) > halaman) Then
            isigrid(tbpage.Text)
        End If
    End Sub
    Sub paging()
        If tbpage.Text = halaman Then
            btnnext.Enabled = False
        Else
            btnnext.Enabled = True
        End If
        If tbpage.Text = "1" Then
            btnprev.Enabled = False
        Else
            btnprev.Enabled = True
        End If
    End Sub

    Private Sub btnfirst_Click(sender As Object, e As EventArgs) Handles btnfirst.Click
        tbpage.Text = "1"
    End Sub

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        tbpage.Text = tbpage.Text - 1
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        tbpage.Text = tbpage.Text + 1
    End Sub

    Private Sub btnlast_Click(sender As Object, e As EventArgs) Handles btnlast.Click
        tbpage.Text = halaman
    End Sub

    Private Sub tbcari_TextChanged(sender As Object, e As EventArgs) Handles tbcari.TextChanged
        tbpage.Text = "1"
        isigrid(1)
    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If from = "penjualan" Then
            Dim nplh As Integer
            nplh = MsgBox("Masukkan pelanggan " & tbnama.Text & " (" & tbkdpelanggan.Text & ") ?", 48 + 4 + 256, "Konfirmasi")
            If nplh = 6 Then
                FormPenjualan.tbkdpelanggan.Text = tbkdpelanggan.Text
                FormPenjualan.tbnama.Text = tbnama.Text
                FormPenjualan.tbalamat.Text = tbalamat.Text
                FormPenjualan.tbnotelp.Text = tbnotelp.Text
                Me.Close()
            End If
        End If
    End Sub
End Class