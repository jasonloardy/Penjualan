Imports MySql.Data.MySqlClient

Public Class FormSuratJalan

    Private Sub btnpenjualan_Click(sender As Object, e As EventArgs) Handles btnpenjualan.Click
        FormDaftarPenjualanAntar.from = "suratjalan"
        FormDaftarPenjualanAntar.ShowDialog()
    End Sub

    Private Sub tbkdpenjualan_TextChanged(sender As Object, e As EventArgs) Handles tbkdpenjualan.TextChanged
        isigrid()
    End Sub
    Sub reset()
        resetkeranjangantar()
        kode_suratjalan()
        tbkdpenjualan.Clear()
        tbkdpelanggan.Clear()
        tbnama.Clear()
        tbalamat.Clear()
        tbnotelp.Clear()
        tbkdsopir.Clear()
        tbnamasopir.Clear()
    End Sub
    Sub kode_suratjalan()
        cmd = New MySqlCommand("SELECT kd_suratjalan FROM tb_suratjalan WHERE kd_suratjalan LIKE 'SJL%'" _
                             & "ORDER BY kd_suratjalan DESC LIMIT 1", konek)
        dr = cmd.ExecuteReader
        dr.Read()
        Dim currentDate As DateTime = DateTime.Now
        If Not dr.HasRows Then
            tbkdsuratjalan.Text = "SJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "00001"
        Else
            Dim hitung As String = Val(Microsoft.VisualBasic.Right(dr.Item("kd_suratjalan").ToString, 5)) + 1
            If Len(hitung) = 1 Then
                tbkdsuratjalan.Text = "SJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "0000" & hitung
            ElseIf Len(hitung) = 2 Then
                tbkdsuratjalan.Text = "SJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "000" & hitung
            ElseIf Len(hitung) = 3 Then
                tbkdsuratjalan.Text = "SJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "00" & hitung
            ElseIf Len(hitung) = 4 Then
                tbkdsuratjalan.Text = "SJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & "0" & hitung
            ElseIf Len(hitung) = 5 Then
                tbkdsuratjalan.Text = "SJL" & currentDate.ToString("yy") & currentDate.ToString("MM") & hitung
            End If
        End If
        tbkdsuratjalan.Enabled = False
        dr.Close()
    End Sub
    Sub resetkeranjangantar()
        Dim queryreset As String = "TRUNCATE TABLE tb_keranjang_antar"
        Query(queryreset)
        isigrid()
    End Sub
    Sub isigrid()
        Dim query As String = "SELECT * FROM tb_keranjang_antar"
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
        dgv.Columns(0).Visible = False
        dgv.Columns(1).HeaderText = "Kd. Barang"
        dgv.Columns(1).Width = 150
        dgv.Columns(2).HeaderText = "Nama Barang"
        dgv.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv.Columns(3).HeaderText = "Satuan"
        dgv.Columns(3).Width = 100
        dgv.Columns(4).HeaderText = "Qty"
        dgv.Columns(4).Width = 70
        dgv.Columns(5).HeaderText = "Sisa"
        dgv.Columns(5).Width = 70
        dgv.Columns(6).HeaderText = "Antar"
        dgv.Columns(6).Width = 70
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub

    Private Sub dgv_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgv.CellMouseDoubleClick
        Dim baris As Integer
        Dim no As Integer
        Dim sisa As Integer
        Dim antar As Integer
        With dgv
            baris = .CurrentRow.Index
            no = .Item(0, baris).Value
            sisa = .Item(5, baris).Value
            antar = .Item(6, baris).Value
        End With
        If e.ColumnIndex = 6 And e.RowIndex > -1 Then
            Dim x As String
            x = InputBox("Masukkan jumlah yang di-antar", "Input Antar", antar)
            If Val(x) >= 0 And Val(x) <= sisa Then
                updatekeranjangantar(no, Val(x))
            Else
                MsgBox("Jumlah antar tidak sesuai!", 16, "Perhatian")
            End If
        End If
    End Sub
    Sub updatekeranjangantar(ByVal no As Integer, ByVal antar As Integer)
        Dim update As String = "UPDATE tb_keranjang_antar SET antar = " & antar _
                             & " WHERE no = " & no
        Query(update)
        isigrid()
    End Sub

    Private Sub btnsopir_Click(sender As Object, e As EventArgs) Handles btnsopir.Click
        FormSopir.from = "suratjalan"
        FormSopir.ShowDialog()
    End Sub
    Sub simpansuratjalan()
        Dim simpan As String = "INSERT INTO tb_suratjalan " _
                            & "VALUES ('" & tbkdsuratjalan.Text & "', '" & Format(dtptanggal.Value, "yyyy-MM-dd") & "', '" & tbkdpenjualan.Text & "', " _
                            & "'" & tbalamat.Text & "', '" & tbnotelp.Text & "', '" & tbnamasopir.Text & "')"
        Query(simpan)
        Dim simpandetail As String = "INSERT INTO tb_suratjalan_detail (kd_suratjalan, kd_barang, antar) " _
                             & "SELECT '" & tbkdsuratjalan.Text & "', kd_barang, antar FROM tb_keranjang_antar"
        Query(simpandetail)
        MsgBox("Surat Jalan berhasil disimpan!", MsgBoxStyle.Information, "Informasi")
    End Sub

    Private Sub btnsimpan_Click(sender As Object, e As EventArgs) Handles btnsimpan.Click
        Dim nplh As Integer
        nplh = MsgBox("Simpan Surat Jalan?", 48 + 4 + 256, "Konfirmasi")
        If nplh = 6 Then
            If tbkdpenjualan.Text = "" Then
                MsgBox("Masukkan data penjualan!", 16, "Perhatian")
            ElseIf tbkdsopir.Text = "" Then
                MsgBox("Masukkan data sopir!", 16, "Perhatian")
            Else
                simpansuratjalan()
                reset()
            End If
        End If
    End Sub

    Private Sub FormSuratJalan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        reset()
    End Sub
End Class