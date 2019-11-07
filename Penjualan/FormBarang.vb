Imports MySql.Data.MySqlClient

Public Class FormBarang

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
        isicb()
        isigrid()
    End Sub

    Sub isigrid()
        Dim query As String = "SELECT kd_barang,nama_barang,tj.nama_jenis,ts.nama_satuan,harga_beli,harga_jual,stok FROM tb_barang tb " _
                             & "JOIN tb_jenis tj ON tb.jenis = tj.kd_jenis JOIN tb_satuan ts ON tb.satuan=ts.kd_satuan"
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
        'dgv.Columns(0).HeaderText = "ID"
        'dgv.Columns(1).HeaderText = "Jenis Barang"
        'dgv.Columns(0).Width = 150
        'dgv.Columns(1).Width = 350
        objAlternatingCellStyle.BackColor = Color.AliceBlue
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.ReadOnly = True
        dgv.AllowUserToAddRows = False
    End Sub
End Class