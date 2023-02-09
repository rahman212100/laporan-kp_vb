Imports MySql.Data.MySqlClient
Public Class cari_data
    Private Sub cari_data_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiserver()
    End Sub
    Sub tampil_data()
        da = New MySqlDataAdapter("select * from data_tanah", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "data_tanah")
        Me.DataGridView1.DataSource = (ds.Tables("data_tanah"))
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Call tampil_data()
        da = New MySqlDataAdapter("select * from data_tanah where nama_wakif like '%" _
                                  & Me.TextBox1.Text & "%'", conn)
        ds = New DataSet
        'ds.Clear()
        da.Fill(ds, "data_tanah")
        DataGridView1.DataSource = (ds.Tables("data_tanah"))
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dasboard.Show()
        Me.Hide()
    End Sub
End Class