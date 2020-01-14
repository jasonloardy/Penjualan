Imports MySql.Data.MySqlClient

Public Class FormBarang
    Public mode As String
    Public id_data As String
    Public from As String
    Public halaman As Integer = 1
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
        Try
            cmd = New MySqlCommand("SELECT kd_jenis,kd_satuan FROM tb_barang WHERE kd_barang = " & tbkdbarang.Text, konek)
            dr = cmd.ExecuteReader
            dr.Read()
            cbjenis.SelectedValue = dr.Item(0).ToString
            cbsatuan.SelectedValue = dr.Item(1).ToString
            dr.Close()
        Catch ex As Exception
        End Try
        
    End Sub

    Private Sub FormBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbpage.Text = "1"
        isigrid(tbpage.Text)
        isicb()
        reset()
    End Sub

    Sub isigrid(ByVal page As String)
        Dim jumlahitem As Integer = 30
        Dim index As Integer = jumlahitem * (page - 1)
        Dim param As String = "stok"
        If from = "penjualan" Then
            param = "stok-(SELECT COALESCE(SUM(qty),0) FROM tb_keranjang WHERE kd_barang = tb.kd_barang)"
        End If
        Dim query As String = "SELECT kd_barang,nama_barang,tj.nama_jenis,ts.nama_satuan,harga_beli,harga_jual, " _
                             & param & " FROM tb_barang tb " _
                             & "JOIN tb_jenis tj ON tb.kd_jenis = tj.kd_jenis JOIN tb_satuan ts ON tb.kd_satuan=ts.kd_satuan " _
                             & "WHERE (kd_barang LIKE @kd_barang OR nama_barang LIKE @nama_barang) " _
                             & "LIMIT " & index & ", " & jumlahitem
        cmd = New MySqlCommand(query, konek)
        cmd.Parameters.AddWithValue("@kd_barang", "%" + tbcari.Text + "%")
        cmd.Parameters.AddWithValue("@nama_barang", "%" + tbcari.Text + "%")
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dt = New DataTable
            dt.Load(dr)
            dgv.DataSource = dt
            dr.Close()
            cmd = New MySqlCommand("SELECT COUNT(*) FROM tb_barang WHERE (kd_barang LIKE @kd_barang OR nama_barang LIKE @nama_barang)", konek)
            cmd.Parameters.AddWithValue("@kd_barang", "%" + tbcari.Text + "%")
            cmd.Parameters.AddWithValue("@nama_barang", "%" + tbcari.Text + "%")
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
        cmd = New MySqlCommand("SELECT COUNT(*) FROM tb_barang", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        lbltotitem.Text = "Jumlah Item : " & dr.Item(0).ToString
        dr.Close()
    End Sub
    Sub judulgrid()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgv.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgv.Columns(0).DefaultCellStyle
        dgv.Columns(0).HeaderText = "Kd. Barang"
        dgv.Columns(0).Width = 95
        dgv.Columns(1).HeaderText = "Nama Barang"
        dgv.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(2).HeaderText = "Jenis"
        dgv.Columns(2).Width = 90
        dgv.Columns(3).HeaderText = "Satuan"
        dgv.Columns(3).Width = 60
        dgv.Columns(4).HeaderText = "Hrg. Beli"
        dgv.Columns(4).Width = 100
        dgv.Columns(4).DefaultCellStyle.Format = "c"
        If from = "penjualan" Then
            dgv.Columns(4).Visible = False
        End If
        dgv.Columns(5).HeaderText = "Hrg. Jual"
        dgv.Columns(5).Width = 100
        dgv.Columns(5).DefaultCellStyle.Format = "c"
        dgv.Columns(6).HeaderText = "Stok"
        dgv.Columns(6).Width = 50
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
        isigrid(tbpage.Text)
    End Sub
    Sub queryedit()
        Dim query As String = "UPDATE tb_barang SET nama_barang = @nama_barang, kd_jenis = @kd_jenis, " _
                            & "kd_satuan = @kd_satuan, harga_beli = @harga_beli, harga_jual = @harga_jual, " _
                            & "stok = @stok WHERE kd_barang = @kd_barang"
        QueryBarang(query, id_data, tbnamabarang.Text.ToUpper, cbjenis.SelectedValue, cbsatuan.SelectedValue,
                    tbhargabeli.Text, tbhargajual.Text, tbstok.Text)
        MsgBox("Berhasil edit data!", MsgBoxStyle.Information, "Informasi")
        isigrid(tbpage.Text)
    End Sub

    Sub queryhapus()
        cmd.CommandText = "SELECT * FROM " _
            & "(SELECT kd_barang FROM tb_pembelian_detail UNION SELECT kd_barang FROM tb_penjualan_detail) AS u " _
            & "WHERE u.kd_barang = '" & id_data & "'"
        cmd.Connection = konek
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then
            dr.Close()
            MsgBox("Barang tidak dapat dihapus!", 48, "Perhatian")
        Else
            dr.Close()
            Dim queryhapus As String = "DELETE FROM tb_barang WHERE kd_barang = '" & id_data & "'"
            Query(queryhapus)
            isigrid(tbpage.Text)
            MsgBox("Berhasil hapus data!", MsgBoxStyle.Information, "Informasi")
        End If
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
    Sub GridToTextBox()
        dgv.Refresh()
        If dgv.RowCount > 0 Then
            Dim baris As Integer
            With dgv
                baris = .CurrentRow.Index
                id_data = .Item(0, baris).Value
                tbkdbarang.Text = .Item(0, baris).Value
                tbnamabarang.Text = .Item(1, baris).Value
                cbjenis.Text = .Item(2, baris).Value
                cbsatuan.Text = .Item(3, baris).Value
                tbhargabeli.Text = .Item(4, baris).Value
                tbhargajual.Text = .Item(5, baris).Value
                tbstok.Text = .Item(6, baris).Value
            End With
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

    Private Sub dgv_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
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
        If from = "pembelian" Then
                insertkeranjang(tbkdbarang.Text, "pembelian")
                Me.Close()
        ElseIf from = "penjualan" Then
                insertkeranjang(tbkdbarang.Text, "penjualan")
                Me.Close()
        End If
    End Sub

    Private Sub FormBarang_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub
End Class