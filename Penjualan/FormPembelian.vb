Imports MySql.Data.MySqlClient

Public Class FormPembelian

    Private Sub FormPembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        kode_pembelian()
        resetkeranjang()
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
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_barang").ToString, 7)) + 1
            If Len(hitung) = 1 Then
                tbkdpembelian.Text = "B000000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdpembelian.Text = "B00000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdpembelian.Text = "B0000" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdpembelian.Text = "B000" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdpembelian.Text = "B00" & hitung
            ElseIf Len(hitung) = 6 Then
                tbkdpembelian.Text = "B0" & hitung
            ElseIf Len(hitung) = 7 Then
                tbkdpembelian.Text = "B" & hitung
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
        Dim total As Integer = Val(tbqty.Text) * Val(tbhargabeli.Text)
        lbltotalbarang.Text = total
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
        dgvkeranjang.Columns(3).Width = 100
        dgvkeranjang.Columns(4).HeaderText = "Qty"
        dgvkeranjang.Columns(4).Width = 100
        dgvkeranjang.Columns(5).Visible = False
        dgvkeranjang.Columns(6).HeaderText = "Hrg. Beli"
        dgvkeranjang.Columns(6).Width = 100
        dgvkeranjang.Columns(7).HeaderText = "Total"
        dgvkeranjang.Columns(7).Width = 100
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvkeranjang.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvkeranjang.ReadOnly = True
        dgvkeranjang.AllowUserToAddRows = False
    End Sub
    Sub inputkeranjang()
        Dim query As String = "INSERT INTO tb_keranjang (kd_barang, nama_barang, satuan, qty, ambil, harga, total)" _
                            & "VALUES (@kd_barang, @nama_barang, @satuan, @qty, @ambil, @harga, @total)"
        QueryKeranjang(query, tbkdbarang.Text, lblnamabarang.Text, lblsatuan.Text, tbqty.Text, "", tbhargabeli.Text, lbltotalbarang.Text)
        isikeranjang()
    End Sub

    Sub hitungtotal()
        Dim hitung As Integer
        For i = 0 To dgvkeranjang.RowCount - 1
            hitung += dgvkeranjang.Rows(i).Cells(7).Value
        Next
        lbltotal.Text = hitung
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
End Class