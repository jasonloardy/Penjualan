Imports MySql.Data.MySqlClient

Public Class FormDaftarPenjualanAntar
    Public from As String
    Private Sub FormDaftarPenjualanAntar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        isigridtrx()
    End Sub
    Sub isigridtrx()
        Dim query As String = "SELECT tj.tanggal, tj.kd_penjualan, tp.kd_pelanggan, tp.nama, tp.alamat, tp.no_telp " _
                            & "FROM tb_penjualan tj " _
                            & "JOIN tb_pelanggan tp ON tj.kd_pelanggan = tp.kd_pelanggan " _
                            & "WHERE tj.status = 'P'"
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
        dgvtrx.Columns(0).HeaderText = "Tanggal"
        dgvtrx.Columns(0).Width = 75
        dgvtrx.Columns(1).HeaderText = "Kd. Penjualan"
        dgvtrx.Columns(1).Width = 115
        dgvtrx.Columns(2).Visible = False
        dgvtrx.Columns(3).HeaderText = "Nama Pelanggan"
        dgvtrx.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvtrx.Columns(4).Visible = False
        dgvtrx.Columns(5).Visible = False
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgvtrx.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvtrx.ReadOnly = True
        dgvtrx.AllowUserToAddRows = False
    End Sub
    Sub isigridbarang(ByVal kd_penjualan As String)
        Dim query As String = "SELECT tjd.kd_barang, tb.nama_barang, ts.nama_satuan, tjd.qty, tjd.qty-tjd.ambil-COALESCE(SUM(tsjd.antar),0) " _
                            & "FROM tb_penjualan_detail tjd " _
                            & "JOIN tb_barang tb ON tjd.kd_barang = tb.kd_barang " _
                            & "JOIN tb_satuan ts ON tb.kd_satuan = ts.kd_satuan " _
                            & "LEFT JOIN tb_suratjalan tsj ON tjd.kd_penjualan = tsj.kd_penjualan " _
                            & "LEFT JOIN tb_suratjalan_detail tsjd ON tsj.kd_suratjalan = tsjd.kd_suratjalan AND tjd.kd_barang = tsjd.kd_barang " _
                            & "WHERE tjd.kd_penjualan = '" & kd_penjualan & "' " _
                            & "GROUP BY tjd.kd_barang"
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
        dgvbarang.Columns(4).HeaderText = "Sisa"
        dgvbarang.Columns(4).Width = 70
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

    Private Sub dgvtrx_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrx.CellClick
        Dim baris As Integer
        Dim kd_penjualan As String
        With dgvtrx
            baris = .CurrentRow.Index
            kd_penjualan = .Item(1, baris).Value
        End With
        isigridbarang(kd_penjualan)
    End Sub

    Private Sub dgvtrx_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvtrx.CellDoubleClick
        If from = "suratjalan" Then
            Dim baris As Integer
            With dgvtrx
                baris = .CurrentRow.Index
                simpandetail(.Item(1, baris).Value)
                FormSuratJalan.tbkdpenjualan.Text = .Item(1, baris).Value
                FormSuratJalan.tbkdpelanggan.Text = .Item(2, baris).Value
                FormSuratJalan.tbnama.Text = .Item(3, baris).Value
                FormSuratJalan.tbalamat.Text = .Item(4, baris).Value
                FormSuratJalan.tbnotelp.Text = .Item(5, baris).Value
            End With
            Me.Dispose()
        End If
    End Sub
End Class