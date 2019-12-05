Imports MySql.Data.MySqlClient

Public Class FormDaftarTransaksi
    Public from As String
    Private Sub FormDaftarPenjualanAntar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        custom()
        isigridtrx()
    End Sub
    Sub custom()
        If from = "suratjalan" Then
            Me.Text = "Daftar Penjualan Pending"
            GroupBox2.Height = "537"
            dgvbarang.Height = "510"
            btncetak.Visible = False
        ElseIf from = "ctksuratjalan" Then
            Me.Text = "Daftar Surat Jalan"
        End If
    End Sub
    Sub isigridtrx()
        Dim query As String = ""
        If from = "suratjalan" Then
            query = "SELECT tj.kd_penjualan, tj.tanggal, tp.nama, tp.kd_pelanggan, tp.alamat, tp.no_telp " _
                  & "FROM tb_penjualan tj " _
                  & "JOIN tb_pelanggan tp ON tj.kd_pelanggan = tp.kd_pelanggan " _
                  & "WHERE tj.status = 'P'" _
                  & "ORDER BY tj.kd_penjualan DESC"
        ElseIf from = "ctksuratjalan" Then
            query = "SELECT tsj.kd_suratjalan, tsj.tanggal, tp.nama " _
                & "FROM tb_suratjalan tsj " _
                & "JOIN tb_penjualan tj ON tsj.kd_penjualan = tj.kd_penjualan " _
                & "JOIN tb_pelanggan tp ON tj.kd_pelanggan = tp.kd_pelanggan " _
                & "ORDER BY tsj.kd_suratjalan DESC"
        End If
        Dim da As New MySqlDataAdapter(query, konek)
        Dim ds As New DataSet()
        If da.Fill(ds) Then
            dgvtrx.DataSource = ds.Tables(0)
            dgvtrx.Refresh()
        Else
            dgvtrx.DataSource = Nothing
        End If
        If dgvtrx.RowCount > 0 Then
            judulgridtrx()
        End If
    End Sub
    Sub judulgridtrx()
        Dim objAlternatingCellStyle As New DataGridViewCellStyle()
        dgvtrx.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle
        Dim style As DataGridViewCellStyle = dgvtrx.Columns(0).DefaultCellStyle
        If from = "suratjalan" Then
            dgvtrx.Columns(0).HeaderText = "Kd. Penjualan"
            dgvtrx.Columns(3).Visible = False
            dgvtrx.Columns(4).Visible = False
            dgvtrx.Columns(5).Visible = False
        ElseIf from = "ctksuratjalan" Then
            dgvtrx.Columns(0).HeaderText = "Kd. Surat Jalan"
        End If
        dgvtrx.Columns(0).Width = 120
        dgvtrx.Columns(1).HeaderText = "Tanggal"
        dgvtrx.Columns(1).Width = 75
        dgvtrx.Columns(2).HeaderText = "Nama Pelanggan"
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
                & "WHERE tjd.kd_penjualan = '" & kd_trx & "'"
        ElseIf from = "ctksuratjalan" Then
            query = "SELECT tsjd.kd_barang, tb.nama_barang, ts.nama_satuan, tsjd.antar " _
                & "FROM tb_suratjalan_detail tsjd " _
                & "JOIN tb_barang tb ON tsjd.kd_barang = tb.kd_barang " _
                & "JOIN tb_satuan ts ON tb.kd_satuan = ts.kd_satuan " _
                & "WHERE tsjd.kd_suratjalan = '" & kd_trx & "'"
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
                                 & "WHERE tjd.kd_penjualan = '" & kd_penjualan & "'"
        Query(simpandetail)
    End Sub

    Private Sub dgvtrx_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrx.CellClick
        Dim baris As Integer
        Dim kd_trx As String
        With dgvtrx
            baris = .CurrentRow.Index
            kd_trx = .Item(0, baris).Value
        End With
        isigridbarang(kd_trx)
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
        End With
        If from = "ctksuratjalan" Then
            FormViewCR.suratjalan(kd_trx)
            FormViewCR.ShowDialog()
        End If
    End Sub
End Class