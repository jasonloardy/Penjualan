Imports MySql.Data.MySqlClient

Public Class FormPenjualan
    Public kd_barang As String
    Public harga_beli As Decimal
    Private Sub Formpenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reset()
        tbkdbarang.Select()
    End Sub

    Sub kode_penjualan()
        cmd = New MySqlCommand("SELECT kd_penjualan FROM tb_penjualan WHERE kd_penjualan LIKE 'PJL%'" _
                             & "ORDER BY kd_penjualan DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        Dim currentDate As DateTime = DateTime.Now
        If Not dr.HasRows Then
            tbkdpenjualan.Text = "PJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "00001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_penjualan").ToString, 5)) + 1
            If Len(hitung) = 1 Then
                tbkdpenjualan.Text = "PJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "0000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdpenjualan.Text = "PJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdpenjualan.Text = "PJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "00" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdpenjualan.Text = "PJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "0" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdpenjualan.Text = "PJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & hitung
            End If
        End If
        tbkdpenjualan.Enabled = False
        dr.Close()
    End Sub

    Private Sub btnPelanggan_Click(sender As Object, e As EventArgs) Handles btnpelanggan.Click
        FormPelanggan.from = "penjualan"
        FormPelanggan.ShowDialog()
    End Sub

    Private Sub btnbarang_Click(sender As Object, e As EventArgs) Handles btnbarang.Click
        FormBarang.from = "penjualan"
        FormBarang.ShowDialog()
        tbqty.Focus()
    End Sub
    Sub hitungtotalbarang()
        Dim total As Double = Val(tbqty.Text) * Val(tbhargajual.Text)
        lbltotalbarang.Text = FormatCurrency(total)
    End Sub

    Private Sub tbqty_TextChanged(sender As Object, e As EventArgs) Handles tbqty.TextChanged
        hitungtotalbarang()
    End Sub

    Private Sub tbhargabeli_TextChanged(sender As Object, e As EventArgs) Handles tbhargajual.TextChanged
        hitungtotalbarang()
    End Sub
    Sub isikeranjang()
        Dim query As String = "SELECT * FROM tb_keranjang"
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvkeranjang.DataSource = ds.Tables(0)
            dgvkeranjang.Refresh()
        Else
            dgvkeranjang.DataSource = Nothing
        End If
        If dgvkeranjang.RowCount > 0 Then
            judulgrid()
        End If
        hitungtotal()
    End Sub
    Sub judulgrid()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvkeranjang.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvkeranjang.Columns(0).DefaultCellStyle
        dgvkeranjang.Columns(0).Visible = False
        dgvkeranjang.Columns(1).HeaderText = "Kd. Barang"
        dgvkeranjang.Columns(1).Width = 150
        dgvkeranjang.Columns(2).HeaderText = "Nama Barang"
        dgvkeranjang.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvkeranjang.Columns(3).HeaderText = "Satuan"
        dgvkeranjang.Columns(3).Width = 150
        dgvkeranjang.Columns(4).HeaderText = "Qty"
        dgvkeranjang.Columns(4).Width = 100
        dgvkeranjang.Columns(5).HeaderText = "Ambil"
        dgvkeranjang.Columns(5).Width = 100
        If cbjenis.SelectedIndex = 0 Then
            dgvkeranjang.Columns(5).Visible = False
        ElseIf cbjenis.SelectedIndex = 1 Then
            dgvkeranjang.Columns(5).Visible = True
        End If
        dgvkeranjang.Columns(6).Visible = False
        dgvkeranjang.Columns(7).HeaderText = "Hrg. Jual"
        dgvkeranjang.Columns(7).Width = 150
        dgvkeranjang.Columns(7).DefaultCellStyle.Format = "c"
        dgvkeranjang.Columns(8).HeaderText = "Total"
        dgvkeranjang.Columns(8).Width = 150
        dgvkeranjang.Columns(8).DefaultCellStyle.Format = "c"
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvkeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvkeranjang.ReadOnly = True
        dgvkeranjang.AllowUserToAddRows = False
    End Sub
    Sub inputkeranjang()
        If kd_barang = "" Then
            MsgBox("Input dahulu item barang!", 16, "Perhatian")
        Else
            If Val(tbqty.Text) <= 0 Then
                MsgBox("Masukkan Qty!", 16, "Perhatian")
            Else
                cmd = New MySqlCommand("SELECT stok-(SELECT COALESCE(SUM(qty),0) FROM tb_keranjang where kd_barang = '" & kd_barang & "') AS stok" _
                             & " FROM tb_barang WHERE kd_barang = '" & kd_barang & "'", konek)
                dr = cmd.ExecuteReader
                dr.Read()
                Dim stok As Integer = dr.Item("stok").ToString
                dr.Close()
                If Val(tbqty.Text) > stok Then
                    MsgBox("Stok tidak cukup!", 16, "Informasi")
                Else
                    cmd = New MySqlCommand("SELECT no FROM tb_keranjang where kd_barang = '" & kd_barang & "'", konek)
                    dr = cmd.ExecuteReader
                    dr.Read()
                    If dr.HasRows Then
                        Dim update As String = "UPDATE tb_keranjang SET qty = qty + " & Val(tbqty.Text) & ", harga_jual = " & tbhargajual.Text _
                                             & ", total = qty * harga_jual WHERE no = " & dr.Item("no").ToString
                        dr.Close()
                        query(update)
                    Else
                        dr.Close()
                        Dim query As String = "INSERT INTO tb_keranjang (kd_barang, nama_barang, satuan, qty, ambil, harga_beli, harga_jual, total)" _
                                & "VALUES (@kd_barang, @nama_barang, @satuan, @qty, @ambil, @harga_beli, @harga_jual, @total)"
                        QueryKeranjang(query, kd_barang.ToUpper, lblnamabarang.Text, lblsatuan.Text, tbqty.Text, "", harga_beli,
                                       tbhargajual.Text, Val(tbqty.Text) * Val(tbhargajual.Text))
                    End If
                    kd_barang = ""
                    isikeranjang()
                    clearinput()
                    tbkdbarang.Focus()
                End If
            End If
        End If
    End Sub

    Sub hitungtotal()
        Dim hitung As Integer
        For i = 0 To dgvkeranjang.RowCount - 1
            hitung += dgvkeranjang.Rows(i).Cells(8).Value
        Next
        lbltotal.Text = FormatCurrency(hitung)
    End Sub

    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninput.Click
        inputkeranjang()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
        Try
            Dim baris As Integer
            Dim no As Integer
            Dim kdbrg As String
            Dim nmbrg As String
            With dgvkeranjang
                baris = .CurrentRow.Index
                no = .Item(0, baris).Value
                kdbrg = .Item(1, baris).Value
                nmbrg = .Item(2, baris).Value
            End With
            Dim nhps As Integer
            nhps = MsgBox("Hapus barang " & nmbrg & " (" & kdbrg & ") ?", 48 + 4 + 256, "Konfirmasi")
            If nhps = 6 Then
                Dim queryhps As String = "DELETE FROM tb_keranjang WHERE no = " & no
                Query(queryhps)
                isikeranjang()
            End If
        Catch ex As Exception
            MsgBox("Silahkan pilih item barang!", 16, "Perhatian")
        End Try
    End Sub
    Sub simpanpenjualan()
        Dim simpan As String = "INSERT INTO tb_penjualan " _
                            & "VALUES ('" & tbkdpenjualan.Text & "', '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & tbkdpelanggan.Text & "')"
        Query(simpan)
        If cbjenis.SelectedIndex = 0 Then
            Dim simpandetail As String = "INSERT INTO tb_penjualan_detail (kd_penjualan, kd_barang, qty, ambil, harga_beli, harga_jual) " _
                                        & "SELECT '" & tbkdpenjualan.Text & "', kd_barang, qty, qty, harga_beli, harga_jual FROM tb_keranjang"
            Query(simpandetail)
        ElseIf cbjenis.SelectedIndex = 1 Then
            Dim simpandetail As String = "INSERT INTO tb_penjualan_detail (kd_penjualan, kd_barang, qty, ambil, harga_beli, harga_jual) " _
                                        & "SELECT '" & tbkdpenjualan.Text & "', kd_barang, qty, ambil, harga_beli, harga_jual FROM tb_keranjang"
            Query(simpandetail)
        End If
        MsgBox("Penjualan berhasil disimpan!", MsgBoxStyle.Information, "Informasi")
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Dim nplh As Integer
        nplh = MsgBox("Simpan penjualan?", 48 + 4 + 256, "Konfirmasi")
        If nplh = 6 Then
            If tbkdpelanggan.Text = "" Then
                MsgBox("Masukkan data pelanggan!", 16, "Perhatian")
            ElseIf dgvkeranjang.RowCount = 0 Then
                MsgBox("Data barang masih kosong!", 16, "Perhatian")
            Else
                simpanpenjualan()
                reset()
            End If
        End If
    End Sub
    Sub reset()
        kode_penjualan()
        cbjenis.SelectedIndex = 0
        tbkdpelanggan.Clear()
        tbnama.Clear()
        tbalamat.Clear()
        tbnotelp.Clear()
        lbltotal.Text = FormatCurrency(0)
        clearinput()
        resetkeranjang()
        isikeranjang()
    End Sub

    Private Sub tbkdbarang_KeyDown(sender As Object, e As KeyEventArgs) Handles tbkdbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            insertkeranjang(tbkdbarang.Text, "penjualan")
        End If
    End Sub

    Private Sub tbhargabeli_KeyDown(sender As Object, e As KeyEventArgs) Handles tbhargajual.KeyDown
        If e.KeyCode = Keys.Enter Then
            inputkeranjang()
        End If
    End Sub
    Sub clearinput()
        tbkdbarang.Clear()
        lblnamabarang.Text = ""
        lblsatuan.Text = ""
        tbqty.Clear()
        tbhargajual.Clear()
        lbltotalbarang.Text = FormatCurrency(0)
    End Sub

    Private Sub tbqty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbqty.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub tbhargabeli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbhargajual.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cbjenis_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbjenis.SelectedIndexChanged
        isikeranjang()
    End Sub

    Private Sub tbqty_KeyDown(sender As Object, e As KeyEventArgs) Handles tbqty.KeyDown
        If e.KeyCode = Keys.Enter Then
            inputkeranjang()
        End If
    End Sub

    Private Sub dgvkeranjang_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvkeranjang.CellMouseDoubleClick
        Dim baris As Integer
        Dim no As Integer
        Dim kd_barang As String
        Dim qty As Integer
        Dim ambil As Integer
        Dim harga_jual As String
        With dgvkeranjang
            baris = .CurrentRow.Index
            no = .Item(0, baris).Value
            kd_barang = .Item(1, baris).Value
            qty = .Item(4, baris).Value
            ambil = .Item(5, baris).Value
            harga_jual = .Item(7, baris).Value
        End With
        If e.ColumnIndex = 4 And e.RowIndex > -1 Then
            Dim x As String
            x = InputBox("Masukkan jumlah Qty", "Perubahan Qty", qty)
            cmd = New MySqlCommand("SELECT stok FROM tb_barang where kd_barang = '" & kd_barang & "'", konek)
            dr = cmd.ExecuteReader
            dr.Read()
            Dim stok As Integer = dr.Item("stok").ToString
            dr.Close()
            If Val(x) > stok Then
                MsgBox("Stok tidak cukup!", 16, "Informasi")
            ElseIf x = "" Then
                Exit Sub
            Else
                updatekeranjang("qty", Val(x), no, "harga_jual")
            End If
        End If
        If e.ColumnIndex = 5 And e.RowIndex > -1 Then
            Dim x As String
            x = InputBox("Masukkan jumlah yang di-ambil", "Input Ambil", ambil)
            If Val(x) >= 0 And Val(x) <= qty Then
                updatekeranjang("ambil", Val(x), no, "harga_jual")
            Else
                MsgBox("Jumlah ambil tidak sesuai!", 16, "Perhatian")
            End If
        End If
        If e.ColumnIndex = 7 And e.RowIndex > -1 Then
            Dim x As String
            x = InputBox("Masukkan harga jual", "Perubahan Harga Jual", harga_jual)
            If x = "" Then
                Exit Sub
            Else
                updatekeranjang("harga_jual", Val(x), no, "harga_jual")
            End If
        End If
    End Sub

End Class