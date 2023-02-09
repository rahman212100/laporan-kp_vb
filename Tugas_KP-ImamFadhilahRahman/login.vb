Imports MySql.Data.MySqlClient
Public Class login
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Sub login()
        Try
            If TextBox1.Text = "" Or TextBox2.Text = "" Then
                MessageBox.Show("Isi username dan password terlebih dahulu!!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                koneksiserver()
                cmd = New MySqlCommand("select * from tbl_login where username = '" & TextBox1.Text & "' and password = '" & TextBox2.Text & "'", conn)
                rd = cmd.ExecuteReader
                rd.Read()
                If rd.HasRows Then

                    Me.Hide()
                        MessageBox.Show("Berhasil Login!", "SUKSES LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dasboard.Show()


                Else
                    MessageBox.Show("Akun anda belum terdaftar!!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        login()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        testkoneksi()

    End Sub

    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

