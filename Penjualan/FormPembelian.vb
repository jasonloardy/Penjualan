﻿Imports MySql.Data.MySqlClient

Public Class FormPembelian
    Public kd_barang As String
    Private Sub FormPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reset()
        tbkdbarang.Select()
    End Sub

    Sub kode_pembelian()
        cmd = New MySqlCommand("SELECT kd_pembelian FROM tb_pembelian WHERE kd_pembelian LIKE 'PBL%'" _
                             & "ORDER BY kd_pembelian DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        Dim currentDate As DateTime = DateTime.Now
        If Not dr.HasRows Then
            tbkdpembelian.Text = "PBL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "00001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_pembelian").ToString, 5)) + 1
            If Len(hitung) = 1 Then
                tbkdpembelian.Text = "PBL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "0000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdpembelian.Text = "PBL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdpembelian.Text = "PBL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "00" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdpembelian.Text = "PBL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "0" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdpembelian.Text = "PBL" & currentDate.ToString("yy") & currentDate.ToString("MM") & hitung
            End If
        End If
        tbkdpembelian.Enabled = False
        dr.Close()
    End Sub

    Private Sub btnsupplier_Click(sender As Object, e As EventArgs) Handles btnsupplier.Click
        FormSupplier.from = "pembelian"
        FormSupplier.ShowDialog()
    End Sub

    Private Sub btnbarang_Click(sender As Object, e As EventArgs) Handles btnbarang.Click
        FormBarang.from = "pembelian"
        FormBarang.ShowDialog()
        tbqty.Focus()
    End Sub
    Sub hitungtotalbarang()
        Dim total As Double = Val(tbqty.Text) * Val(tbhargabeli.Text)
        lbltotalbarang.Text = FormatCurrency(total)
    End Sub

    Private Sub tbqty_TextChanged(sender As Object, e As EventArgs) Handles tbqty.TextChanged
        hitungtotalbarang()
    End Sub

    Private Sub tbhargabeli_TextChanged(sender As Object, e As EventArgs) Handles tbhargabeli.TextChanged
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
        dgvkeranjang.Columns(5).Visible = False
        dgvkeranjang.Columns(6).HeaderText = "Hrg. Beli"
        dgvkeranjang.Columns(6).Width = 150
        dgvkeranjang.Columns(6).DefaultCellStyle.Format = "c"
        dgvkeranjang.Columns(7).HeaderText = "Total"
        dgvkeranjang.Columns(7).Width = 150
        dgvkeranjang.Columns(7).DefaultCellStyle.Format = "c"
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvkeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvkeranjang.ReadOnly = True
        dgvkeranjang.AllowUserToAddRows = False
    End Sub
    Sub inputkeranjang()
        Dim query As String = "INSERT INTO tb_keranjang (kd_barang, nama_barang, satuan, qty, ambil, harga, total)" _
                            & "VALUES (@kd_barang, @nama_barang, @satuan, @qty, @ambil, @harga, @total)"
        QueryKeranjang(query, kd_barang, lblnamabarang.Text, lblsatuan.Text, tbqty.Text, "", tbhargabeli.Text, Val(tbqty.Text) * Val(tbhargabeli.Text))
        isikeranjang()
        clearinput()
        tbkdbarang.Focus()
    End Sub

    Sub hitungtotal()
        Dim hitung As Integer
        For i = 0 To dgvkeranjang.RowCount - 1
            hitung += dgvkeranjang.Rows(i).Cells(7).Value
        Next
        lbltotal.Text = FormatCurrency(hitung)
    End Sub

    Private Sub btninput_Click(sender As Object, e As EventArgs) Handles btninput.Click
        inputkeranjang()
    End Sub

    Private Sub btnhapus_Click(sender As Object, e As EventArgs) Handles btnhapus.Click
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
        nhps = MsgBox("Yakin hapus barang " & nmbrg & " (" & kdbrg & ") ?", 48 + 4 + 256, "Konfirmasi")
        If nhps = 6 Then
            Dim queryhps As String = "DELETE FROM tb_keranjang WHERE no = " & no
            Query(queryhps)
            isikeranjang()
        End If
    End Sub
    Sub simpanpembelian()
        Dim simpan As String = "INSERT INTO tb_pembelian " _
                            & "VALUES ('" & tbkdpembelian.Text & "', '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & tbkdsupplier.Text & "')"
        Query(simpan)
        Dim simpandetail As String = "INSERT INTO tb_pembelian_detail (kd_pembelian, kd_barang, qty, harga) " _
                             & "SELECT '" & tbkdpembelian.Text & "', kd_barang, qty, harga FROM tb_keranjang"
        Query(simpandetail)
        MsgBox("Pembelian berhasil disimpan!", MsgBoxStyle.Information, "Informasi")
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Dim nplh As Integer
        nplh = MsgBox("Simpan Pembelian?", 48 + 4 + 256, "Konfirmasi")
        If nplh = 6 Then
            If tbkdsupplier.Text = "" Then
                MsgBox("Masukkan data supplier!", 16, "Perhatian")
            ElseIf dgvkeranjang.RowCount = 0 Then
                MsgBox("Data barang masih kosong!", 16, "Perhatian")
            Else
                simpanpembelian()
                reset()
            End If
        End If
    End Sub
    Sub reset()
        kode_pembelian()
        tbkdsupplier.Clear()
        tbnama.Clear()
        tbalamat.Clear()
        tbnotelp.Clear()
        lbltotal.Text = "0"
        clearinput()
        resetkeranjang()
        isikeranjang()
    End Sub

    Private Sub tbkdbarang_KeyDown(sender As Object, e As KeyEventArgs) Handles tbkdbarang.KeyDown
        If e.KeyCode = Keys.Enter Then
            insertkeranjangbeli(tbkdbarang.Text)
        End If
    End Sub

    Private Sub tbhargabeli_KeyDown(sender As Object, e As KeyEventArgs) Handles tbhargabeli.KeyDown
        If e.KeyCode = Keys.Enter Then
            inputkeranjang()
        End If
    End Sub
    Sub clearinput()
        tbkdbarang.Clear()
        lblnamabarang.Text = ""
        lblsatuan.Text = ""
        tbqty.Clear()
        tbhargabeli.Clear()
        lbltotalbarang.Text = "0"
    End Sub

    Private Sub tbqty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbqty.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub tbhargabeli_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbhargabeli.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class