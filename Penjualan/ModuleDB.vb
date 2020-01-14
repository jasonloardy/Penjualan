Imports MySql.Data.MySqlClient

Module ModuleDB
    Public strkon As String = "server=localhost;user=root;database=db_toko;Convert Zero Datetime=True"
    Public konek As MySqlConnection = New MySqlConnection(strkon)
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public cmd As New MySqlCommand
    Public dt As DataTable
    Public dr As MySqlDataReader
    Public dtgl As String
    Public Function koneksi() As Boolean
        Try
            If konek.State = ConnectionState.Closed Then
                konek.Open()
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("Koneksi ke database bermasalah!", 48, "Perhatian")
            Application.Exit()
            Return False
        End Try
    End Function
    Sub QueryJenis(ByVal query As String, ByVal kd_jenis As String, ByVal nama_jenis As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_jenis", kd_jenis)
                cmd.Parameters.AddWithValue("@nama_jenis", nama_jenis)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub QuerySatuan(ByVal query As String, ByVal kd_satuan As String, ByVal nama_satuan As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_satuan", kd_satuan)
                cmd.Parameters.AddWithValue("@nama_satuan", nama_satuan)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub QuerySopir(ByVal query As String, ByVal kd_sopir As String, ByVal nama_sopir As String, ByVal status As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_sopir", kd_sopir)
                cmd.Parameters.AddWithValue("@nama_sopir", nama_sopir)
                cmd.Parameters.AddWithValue("@status", status)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub QueryBarang(ByVal query As String, ByVal kd_barang As String, ByVal nama_barang As String,
                    ByVal kd_jenis As String, ByVal kd_satuan As String, ByVal harga_beli As String,
                    ByVal harga_jual As String, ByVal stok As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_barang", kd_barang)
                cmd.Parameters.AddWithValue("@nama_barang", nama_barang)
                cmd.Parameters.AddWithValue("@kd_jenis", kd_jenis)
                cmd.Parameters.AddWithValue("@kd_satuan", kd_satuan)
                cmd.Parameters.AddWithValue("@harga_beli", harga_beli)
                cmd.Parameters.AddWithValue("@harga_jual", harga_jual)
                cmd.Parameters.AddWithValue("@stok", stok)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub QueryPelSup(ByVal query As String, ByVal kd As String, ByVal nama As String,
                    ByVal alamat As String, ByVal no_telp As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd", kd)
                cmd.Parameters.AddWithValue("@nama", nama)
                cmd.Parameters.AddWithValue("@alamat", alamat)
                cmd.Parameters.AddWithValue("@no_telp", no_telp)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub QueryKeranjang(ByVal query As String, ByVal kd_barang As String, ByVal nama_barang As String,
                    ByVal satuan As String, ByVal qty As String, ByVal ambil As String, ByVal harga_beli As String,
                    ByVal harga_jual As String, ByVal total As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Parameters.AddWithValue("@kd_barang", kd_barang)
                cmd.Parameters.AddWithValue("@nama_barang", nama_barang)
                cmd.Parameters.AddWithValue("@satuan", satuan)
                cmd.Parameters.AddWithValue("@qty", qty)
                cmd.Parameters.AddWithValue("@ambil", ambil)
                cmd.Parameters.AddWithValue("@harga_beli", harga_beli)
                cmd.Parameters.AddWithValue("@harga_jual", harga_jual)
                cmd.Parameters.AddWithValue("@total", total)
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub Query(ByVal query As String)
        Try
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub resetkeranjang()
        Dim queryreset As String = "TRUNCATE TABLE tb_keranjang"
        Query(queryreset)
    End Sub
    Sub insertkeranjang(ByVal kd_barang As String, ByVal from As String)
        Try
            Using cmd As New MySqlCommand("SELECT tb.nama_barang, ts.nama_satuan, tb.harga_beli, tb.harga_jual FROM tb_barang tb JOIN tb_satuan ts ON tb.kd_satuan = ts.kd_satuan " _
                             & "WHERE tb.kd_barang = @kd_barang", konek)
                cmd.Parameters.AddWithValue("@kd_barang", kd_barang)
                dr = cmd.ExecuteReader
                dr.Read()
                If dr.HasRows Then
                    If from = "pembelian" Then
                        FormPembelian.kd_barang = kd_barang
                        FormPembelian.tbkdbarang.Text = kd_barang
                        FormPembelian.lblnamabarang.Text = dr.Item("nama_barang").ToString
                        FormPembelian.lblsatuan.Text = dr.Item("nama_satuan").ToString
                        FormPembelian.tbqty.Focus()
                    ElseIf from = "penjualan" Then
                        FormPenjualan.kd_barang = kd_barang
                        FormPenjualan.tbkdbarang.Text = kd_barang
                        FormPenjualan.lblnamabarang.Text = dr.Item("nama_barang").ToString
                        FormPenjualan.lblsatuan.Text = dr.Item("nama_satuan").ToString
                        FormPenjualan.harga_beli = dr.Item("harga_beli").ToString
                        FormPenjualan.tbhargajual.Text = dr.Item("harga_jual").ToString
                        FormPenjualan.tbqty.Focus()
                    End If
                Else
                    MsgBox("Barang Tidak Ditemukan!", 16, "Perhatian")
                End If
                dr.Close()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Sub updatekeranjang(ByVal param As String, ByVal param2 As Integer, ByVal no As Integer, ByVal harga As String)
        If harga = "harga_beli" Then
            Dim update As String = "UPDATE tb_keranjang SET " & param & " = " & param2 _
                                 & ", total = qty * " & harga & " WHERE no = " & no
            Query(update)
            FormPembelian.isikeranjang()
        ElseIf harga = "harga_jual" Then
            Dim update As String = "UPDATE tb_keranjang SET " & param & " = " & param2 _
                                 & ", total = qty * " & harga & " WHERE no = " & no
            Query(update)
            FormPenjualan.isikeranjang()
        End If
    End Sub
    Function querycb(ByVal query As String)
        da = New MySqlDataAdapter(query, konek)
        Dim dt As New DataTable()
        da.Fill(dt)
        Return dt
    End Function
    Function cekdata(ByVal query As String)
        cmd = New MySqlCommand(query, konek)
        dr = cmd.ExecuteReader
        dr.Read()
        Dim hasRows As Boolean = dr.HasRows
        dr.Close()
        Return hasRows
    End Function
End Module
