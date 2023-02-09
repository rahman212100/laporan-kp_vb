Imports MySql.Data.MySqlClient
Module koneksi
    Public conn As MySqlConnection
    Public cmd As MySqlCommand
    Public rd As MySqlDataReader
    Public da As MySqlDataAdapter
    Public ds As DataSet
    Public dtb As DataTable
    Public str As String

    Public Sub koneksiserver()
        str = "Server=localhost;user id = root;password=;database=db_arsipdata;Convert Zero Datetime=True"
        conn = New MySqlConnection(str)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Sub testkoneksi()
        str = "Server=localhost;user id = root;password=;database=db_arsipdata"
        conn = New MySqlConnection(str)
        Try
            If conn.State = ConnectionState.Closed Then
                conn.Open()
                MsgBox("Koneksi Tersambung", MsgBoxStyle.Information, "Informasi")
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Public Function SQLTable(ByVal Source As String) As DataTable
        Try
            Dim adp As New MySqlDataAdapter(Source, conn)
            Dim DT As New DataTable
            adp.Fill(DT)
            SQLTable = DT
        Catch ex As Exception
            MsgBox(ex.Message)
            SQLTable = Nothing
        End Try
    End Function
End Module
