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
    Sub query(ByVal query As String)
        Try
            Call koneksi()
            Using cmd As New MySqlCommand
                cmd.CommandText = query
                cmd.Connection = konek
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, 16, "Error")
        End Try
    End Sub
    Function querycb(ByVal query As String)
        da = New MySqlDataAdapter(query, konek)
        Dim dt As New DataTable()
        da.Fill(dt)
        Return dt
    End Function
End Module
