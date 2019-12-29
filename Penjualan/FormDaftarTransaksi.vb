Imports MySql.Data.MySqlClient

Public Class FormDaftarTransaksi
    Public from As String
    Public status As Char
    Public halaman As Integer = 1
    Private Sub FormDaftarPenjualanAntar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        custom()
        tbpage.Text = "1"
        isigridtrx(tbpage.Text)
    End Sub
    Sub custom()
        If from = "suratjalan" Then
            Me.Text = "Daftar Penjualan Pending"
            GroupBox2.Height = "537"
            dgvbarang.Height = "510"
            btncetak.Visible = False
        ElseIf from = "ctksuratjalan" Then
            Me.Text = "Daftar Surat Jalan"
        ElseIf from = "ctkpenjualan" Then
            Me.Text = "Daftar Penjualan"
        ElseIf from = "ctkpembelian" Then
            Me.Text = "Daftar Pembelian"
        End If
    End Sub
    Sub isigridtrx(ByVal page As String)
        Dim query As String = ""
        Dim querycari As String = ""
        If from = "suratjalan" Then
            query = "SELECT tj.kd_penjualan, tj.tanggal, tp.nama, tp.kd_pelanggan, tp.alamat, tp.no_telp " _
                  & "FROM tb_penjualan tj " _
                  & "JOIN tb_pelanggan tp ON tj.kd_pelanggan = tp.kd_pelanggan " _
                  & "WHERE tj.status = 'P' AND (tj.kd_penjualan LIKE @param1 OR tp.nama LIKE @param2) " _
                  & "ORDER BY tj.kd_penjualan DESC"
            querycari = "SELECT COUNT(*) FROM tb_penjualan tj " _
                        & "JOIN tb_pelanggan tp ON tj.kd_pelanggan = tp.kd_pelanggan " _
                        & "WHERE tj.status = 'P' AND (tj.kd_penjualan LIKE @param1 OR tp.nama LIKE @param2)"
            isigridtrx2(page, query, querycari)
        ElseIf from = "ctksuratjalan" Then
            query = "SELECT tsj.kd_suratjalan, tsj.tanggal, tp.nama " _
                & "FROM tb_suratjalan tsj " _
                & "JOIN tb_penjualan tj ON tsj.kd_penjualan = tj.kd_penjualan " _
                & "JOIN tb_pelanggan tp ON tj.kd_pelanggan = tp.kd_pelanggan " _
                & "WHERE (tsj.kd_suratjalan LIKE @param1 OR tp.nama LIKE @param2) " _
                & "ORDER BY tsj.kd_suratjalan DESC"
            querycari = "SELECT COUNT(*) FROM tb_suratjalan tsj " _
                        & "JOIN tb_penjualan tj ON tsj.kd_penjualan = tj.kd_penjualan " _
                        & "JOIN tb_pelanggan tp ON tj.kd_pelanggan = tp.kd_pelanggan " _
                        & "WHERE (tsj.kd_suratjalan LIKE @param1 OR tp.nama LIKE @param2)"
            isigridtrx2(page, query, querycari)
        ElseIf from = "ctkpenjualan" Then
            query = "SELECT tj.kd_penjualan, tj.tanggal, tp.nama, IF(sum(tjd.qty-tjd.ambil)>0,'Antaran','Langsung') AS Status " _
                & "FROM tb_penjualan tj " _
                & "JOIN tb_pelanggan tp ON tj.kd_pelanggan = tp.kd_pelanggan " _
                & "JOIN tb_penjualan_detail tjd ON tj.kd_penjualan = tjd.kd_penjualan " _
                & "GROUP BY tj.kd_penjualan " _
                & "HAVING (tj.kd_penjualan LIKE @param1 OR tp.nama LIKE @param2) " _
                & "ORDER BY tj.kd_penjualan DESC"
            querycari = "SELECT COUNT(*) FROM tb_penjualan tj " _
                        & "JOIN tb_pelanggan tp ON tj.kd_pelanggan = tp.kd_pelanggan " _
                        & "WHERE (tj.kd_penjualan LIKE @param1 OR tp.nama LIKE @param2)"
            isigridtrx2(page, query, querycari)
        ElseIf from = "ctkpembelian" Then
            query = "SELECT tb.kd_pembelian, tb.tanggal, tsp.nama, tb.kd_bukti AS 'Kd. Bukti' " _
                & "FROM tb_pembelian tb " _
                & "JOIN tb_supplier tsp ON tb.kd_supplier = tsp.kd_supplier " _
                & "WHERE (tb.kd_pembelian LIKE @param1 OR tsp.nama LIKE @param2) " _
                & "ORDER BY tb.kd_pembelian DESC"
            querycari = "SELECT COUNT(*) FROM tb_pembelian tb " _
                        & "JOIN tb_supplier tsp ON tb.kd_supplier = tsp.kd_supplier " _
                        & "WHERE (tb.kd_pembelian LIKE @param1 OR tsp.nama LIKE @param2)"
            isigridtrx2(page, query, querycari)
        End If
    End Sub
    Sub isigridtrx2(ByVal page As String, ByVal query As String, ByVal querycari As String)
        Dim jumlahitem As Integer = 1
        Dim index As Integer = jumlahitem * (page - 1)
        cmd = New MySqlCommand(query & " LIMIT " & index & "," & jumlahitem, konek)
        cmd.Parameters.AddWithValue("@param1", "%" + tbcari.Text + "%")
        cmd.Parameters.AddWithValue("@param2", "%" + tbcari.Text + "%")
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dt = New DataTable
            dt.Load(dr)
            dgvtrx.DataSource = dt
            dr.Close()
            cmd = New MySqlCommand(querycari, konek)
            cmd.Parameters.AddWithValue("@param1", "%" + tbcari.Text + "%")
            cmd.Parameters.AddWithValue("@param2", "%" + tbcari.Text + "%")
            dr = cmd.ExecuteReader
            dr.Read()
            halaman = Math.Ceiling(dr.Item(0).ToString / jumlahitem)
            dr.Close()
            lbltotpage.Text = " / " & halaman
        Else
            dr.Close()
            dgvtrx.DataSource = Nothing
            tbpage.Text = "1"
            lbltotpage.Text = " / 0"
        End If
        If dgvtrx.RowCount > 0 Then
            judulgridtrx()
        End If
        paging()
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
    Sub judulgridtrx()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvtrx.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvtrx.Columns(0).DefaultCellStyle
        If from = "suratjalan" Then
            dgvtrx.Columns(0).HeaderText = "Kd. Penjualan"
            dgvtrx.Columns(2).HeaderText = "Nama Pelanggan"
            dgvtrx.Columns(3).Visible = False
            dgvtrx.Columns(4).Visible = False
            dgvtrx.Columns(5).Visible = False
        ElseIf from = "ctksuratjalan" Then
            dgvtrx.Columns(0).HeaderText = "Kd. Surat Jalan"
            dgvtrx.Columns(2).HeaderText = "Nama Pelanggan"
        ElseIf from = "ctkpenjualan" Then
            dgvtrx.Columns(0).HeaderText = "Kd. Penjualan"
            dgvtrx.Columns(2).HeaderText = "Nama Pelanggan"
        ElseIf from = "ctkpembelian" Then
            dgvtrx.Columns(0).HeaderText = "Kd. Pembelian"
            dgvtrx.Columns(2).HeaderText = "Nama Supplier"
        End If
        dgvtrx.Columns(0).Width = 120
        dgvtrx.Columns(1).HeaderText = "Tanggal"
        dgvtrx.Columns(1).Width = 75
        dgvtrx.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvtrx.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvtrx.ReadOnly = True
        dgvtrx.AllowUserToAddRows = False
    End Sub
    Sub isigridbarang(ByVal kd_trx As String)
        Dim query As String = ""
        If from = "suratjalan" Then
            query = "SELECT tjd.kd_barang, tb.nama_barang, ts.nama_satuan, tjd.qty, tjd.qty-tjd.ambil-COALESCE(SUM(tsjd.antar),0) " _
                & "FROM tb_penjualan_detail tjd " _
                & "JOIN tb_barang tb ON tjd.kd_barang = tb.kd_barang " _
                & "JOIN tb_satuan ts ON tb.kd_satuan = ts.kd_satuan " _
                & "LEFT JOIN tb_suratjalan tsj ON tjd.kd_penjualan = tsj.kd_penjualan " _
                & "LEFT JOIN tb_suratjalan_detail tsjd ON tsj.kd_suratjalan = tsjd.kd_suratjalan AND tjd.kd_barang = tsjd.kd_barang " _
                & "WHERE tjd.kd_penjualan = '" & kd_trx & "' " _
                & "GROUP BY tjd.kd_barang"
        ElseIf from = "ctksuratjalan" Then
            query = "SELECT tsjd.kd_barang, tb.nama_barang, ts.nama_satuan, tsjd.antar " _
                & "FROM tb_suratjalan_detail tsjd " _
                & "JOIN tb_barang tb ON tsjd.kd_barang = tb.kd_barang " _
                & "JOIN tb_satuan ts ON tb.kd_satuan = ts.kd_satuan " _
                & "WHERE tsjd.kd_suratjalan = '" & kd_trx & "'"
        ElseIf from = "ctkpenjualan" Then
            query = "SELECT tjd.kd_barang, tb.nama_barang, ts.nama_satuan, tjd.qty, tjd.ambil, tjd.harga_jual " _
                & "FROM tb_penjualan_detail tjd " _
                & "JOIN tb_barang tb ON tjd.kd_barang = tb.kd_barang " _
                & "JOIN tb_satuan ts ON tb.kd_satuan = ts.kd_satuan " _
                & "WHERE tjd.kd_penjualan = '" & kd_trx & "'"
        ElseIf from = "ctkpembelian" Then
            query = "SELECT tbd.kd_barang, tbr.nama_barang, ts.nama_satuan, tbd.qty, tbd.harga " _
                & "FROM tb_pembelian_detail tbd " _
                & "JOIN tb_barang tbr ON tbd.kd_barang = tbr.kd_barang " _
                & "JOIN tb_satuan ts ON tbr.kd_satuan = ts.kd_satuan " _
                & "WHERE tbd.kd_pembelian = '" & kd_trx & "'"
        End If
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvbarang.DataSource = ds.Tables(0)
            dgvbarang.Refresh()
        Else
            dgvbarang.DataSource = Nothing
        End If
        If dgvbarang.RowCount > 0 Then
            judulgridbarang()
        End If
    End Sub
    Sub judulgridbarang()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvbarang.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvbarang.Columns(0).DefaultCellStyle
        dgvbarang.Columns(0).HeaderText = "Kd. Barang"
        dgvbarang.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvbarang.Columns(1).HeaderText = "Nama Barang"
        dgvbarang.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvbarang.Columns(2).HeaderText = "Satuan"
        dgvbarang.Columns(2).Width = 70
        dgvbarang.Columns(3).HeaderText = "Qty"
        dgvbarang.Columns(3).Width = 70
        If from = "suratjalan" Then
            dgvbarang.Columns(4).HeaderText = "Sisa"
            dgvbarang.Columns(4).Width = 70
        ElseIf from = "ctkpenjualan" Then
            dgvbarang.Columns(4).HeaderText = "Ambil"
            dgvbarang.Columns(4).Width = 70
            dgvbarang.Columns(5).HeaderText = "Hrg. Jual"
            dgvbarang.Columns(5).Width = 140
            dgvbarang.Columns(5).DefaultCellStyle.Format = "c"
            If dgvtrx.Item(3, dgvtrx.CurrentRow.Index).Value = "Antaran" Then
                dgvbarang.Columns(4).Visible = True
            Else
                dgvbarang.Columns(4).Visible = False
            End If
        ElseIf from = "ctkpembelian" Then
            dgvbarang.Columns(4).HeaderText = "Hrg. Beli"
            dgvbarang.Columns(4).Width = 140
            dgvbarang.Columns(4).DefaultCellStyle.Format = "c"
        End If
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvbarang.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvbarang.ReadOnly = True
        dgvbarang.AllowUserToAddRows = False
    End Sub
    Sub simpandetail(ByVal kd_penjualan As String)
        FormSuratJalan.resetkeranjangantar()
        Dim simpandetail As String = "INSERT INTO tb_keranjang_antar (kd_barang, nama_barang, satuan, qty, sisa, antar) " _
                                 & "SELECT tjd.kd_barang, tb.nama_barang, ts.nama_satuan, tjd.qty, tjd.qty-tjd.ambil-COALESCE(SUM(tsjd.antar),0) , tjd.qty-tjd.ambil-COALESCE(SUM(tsjd.antar),0) " _
                                 & "FROM tb_penjualan_detail tjd " _
                                 & "JOIN tb_barang tb ON tjd.kd_barang = tb.kd_barang " _
                                 & "JOIN tb_satuan ts ON tb.kd_satuan = ts.kd_satuan " _
                                 & "LEFT JOIN tb_suratjalan tsj ON tjd.kd_penjualan = tsj.kd_penjualan " _
                                 & "LEFT JOIN tb_suratjalan_detail tsjd ON tsj.kd_suratjalan = tsjd.kd_suratjalan AND tjd.kd_barang = tsjd.kd_barang " _
                                 & "WHERE tjd.kd_penjualan = '" & kd_penjualan & "' " _
                                 & "GROUP BY tjd.kd_barang"
        Query(simpandetail)
    End Sub

    Private Sub dgvtrx_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrx.CellDoubleClick
        If from = "suratjalan" Then
            Dim baris As Integer
            With dgvtrx
                baris = .CurrentRow.Index
                simpandetail(.Item(0, baris).Value)
                FormSuratJalan.tbkdpenjualan.Text = .Item(0, baris).Value
                FormSuratJalan.tbkdpelanggan.Text = .Item(3, baris).Value
                FormSuratJalan.tbnama.Text = .Item(2, baris).Value
                FormSuratJalan.tbalamat.Text = .Item(4, baris).Value
                FormSuratJalan.tbnotelp.Text = .Item(5, baris).Value
            End With
            Me.Close()
        End If
    End Sub

    Private Sub FormDaftarTransaksi_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub btncetak_Click(sender As Object, e As EventArgs) Handles btncetak.Click
        Dim baris As Integer
        Dim kd_trx As String
        With dgvtrx
            baris = .CurrentRow.Index
            kd_trx = .Item(0, baris).Value
            If from = "ctkpenjualan" Then
                Dim status As String = .Item(3, baris).Value
            End If
        End With
        If from = "ctksuratjalan" Then
            FormViewCR.suratjalan(kd_trx)
            FormViewCR.ShowDialog()
        ElseIf from = "ctkpenjualan" Then
            If status = "Antaran" Then
                FormViewCR.penjualan_antar(kd_trx)
            Else
                FormViewCR.penjualan_langsung(kd_trx)
            End If
            FormViewCR.ShowDialog()
        ElseIf from = "ctkpembelian" Then
            FormViewCR.pembelian(kd_trx)
            FormViewCR.ShowDialog()
        End If
    End Sub

    Private Sub dgvtrx_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrx.CellEnter
        Dim baris As Integer
        Dim kd_trx As String
        With dgvtrx
            baris = .CurrentRow.Index
            kd_trx = .Item(0, baris).Value
        End With
        isigridbarang(kd_trx)
    End Sub

    Private Sub tbpage_TextChanged(sender As Object, e As EventArgs) Handles tbpage.TextChanged
        If Not (tbpage.Text = "" Or Val(tbpage.Text) > halaman) Then
            isigridtrx(tbpage.Text)
        End If
    End Sub

    Private Sub btnnext_Click(sender As Object, e As EventArgs) Handles btnnext.Click
        tbpage.Text = tbpage.Text + 1
    End Sub

    Private Sub btnprev_Click(sender As Object, e As EventArgs) Handles btnprev.Click
        tbpage.Text = tbpage.Text - 1
    End Sub

    Private Sub btnfirst_Click(sender As Object, e As EventArgs) Handles btnfirst.Click
        tbpage.Text = "1"
    End Sub

    Private Sub btnlast_Click(sender As Object, e As EventArgs) Handles btnlast.Click
        tbpage.Text = halaman
    End Sub

    Private Sub tbcari_TextChanged(sender As Object, e As EventArgs) Handles tbcari.TextChanged
        tbpage.Text = "1"
        isigridtrx(tbpage.Text)
    End Sub
End Class