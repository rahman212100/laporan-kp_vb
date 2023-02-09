Imports MySql.Data.MySqlClient
Public Class datawakif
    Dim data_wakif
    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub datawakif_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiserver()
        tampil_data()
        Button1.Text = "Simpan Data"
        Button2.Text = "Update Data"
        Button3.Text = "Hapus Data"
        Button4.Text = "Kembali"
    End Sub
    Sub tampil_data()
        da = New MySqlDataAdapter("select * from data_wakif", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "data_wakif")
        Me.DataGridView1.DataSource = (ds.Tables("data_wakif"))
    End Sub
    Sub bersih()
        TB_id.Text = ""
        TB_namawakif.Text = ""
        TB_agama.Text = ""
        CB_jns_kelamin.Text = ""
        TB_tmp_lahir.Text = ""
        TB_alamat.Text = ""
        TB_provinsi.Text = ""
        TB_kota.Text = ""
        tampil_data()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Me.TB_namawakif.Text = "" Or Me.TB_agama.Text = "" Or Me.CB_jns_kelamin.Text = "" Or Me.TB_tmp_lahir.Text = "" Or Me.DateTimePicker1.Text = "" Or Me.TB_alamat.Text = "" Or Me.TB_provinsi.Text = "" Or Me.TB_kota.Text = "" Then
            MsgBox("Maaf Data Anda Belum Lengkap")
        Else
            Dim simpan As String
            'Dim id = 1
            MsgBox("Data Anda Akan Disimpan")
            simpan = "insert into data_wakif (nama_wakif, agama, jenis_kelamin, tempat_lahir, tgl_lahir, alamat, provinsi, kota)VALUES ('" & TB_namawakif.Text & "','" & TB_agama.Text & "','" & CB_jns_kelamin.Text & "','" & TB_tmp_lahir.Text & "','" & Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TB_alamat.Text & "','" & TB_provinsi.Text & "','" & TB_kota.Text & "')"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            tampil_data()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Me.TB_namawakif.Text = "" Or Me.TB_agama.Text = "" Or Me.CB_jns_kelamin.Text = "" Or Me.TB_tmp_lahir.Text = "" Or Me.DateTimePicker1.Text = "" Or Me.TB_alamat.Text = "" Or Me.TB_provinsi.Text = "" Or Me.TB_kota.Text = "" Then
            MsgBox("Maaf Data Anda Belum Lengkap")
        Else
            Call koneksiserver()
            MsgBox("Anda akan mengupdate datanya")
            Dim edit As String = "update data_wakif set nama_wakif ='" & Me.TB_namawakif.Text _
                                 & "', agama = '" & Me.TB_agama.Text _
                                 & "', jenis_kelamin ='" & Me.CB_jns_kelamin.Text _
                                 & "', tempat_lahir ='" & Me.TB_tmp_lahir.Text _
                                 & "', tgl_lahir ='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") _
                                 & "', alamat ='" & Me.TB_alamat.Text _
                                 & "', provinsi ='" & Me.TB_provinsi.Text _
                                 & "', kota ='" & Me.TB_kota.Text _
                                 & "' where id = '" _
                                 & Me.TB_id.Text & "'"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(edit, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Edit Berhasil")
            tampil_data()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        data_wakif = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TB_id.Text = data_wakif
        TB_namawakif.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TB_agama.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        CB_jns_kelamin.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TB_tmp_lahir.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TB_alamat.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TB_provinsi.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TB_kota.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Me.TB_namawakif.Text = "" Or Me.TB_agama.Text = "" Or Me.CB_jns_kelamin.Text = "" Or Me.TB_tmp_lahir.Text = "" Or Me.DateTimePicker1.Text = "" Or Me.TB_alamat.Text = "" Or Me.TB_provinsi.Text = "" Or Me.TB_kota.Text = "" Then
            MsgBox("Maaf Data Anda Belum Lengkap")
        Else
            If MessageBox.Show("Anda yakin akan menghapus datanya ??", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete from data_wakif where id = '" & Me.TB_id.Text & "'"
                cmd = New MySqlCommand(hapus, conn)
                cmd.ExecuteNonQuery()
                bersih()
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        dasboard.Show()
        Me.Hide()
    End Sub
End Class