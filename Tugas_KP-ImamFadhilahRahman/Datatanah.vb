Imports MySql.Data.MySqlClient
Public Class Datatanah
    Dim data_tanah
    Private Sub Datatanah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiserver()
        tampil_data()
        Button1.Text = "Simpan Data"
        Button2.Text = "Update Data"
        Button3.Text = "Hapus Data"
        Button4.Text = "Kembali"
    End Sub
    Sub tampil_data()
        da = New MySqlDataAdapter("select * from data_tanah", conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "data_tanah")
        Me.DataGridView1.DataSource = (ds.Tables("data_tanah"))
    End Sub
    Sub bersih()
        TB_No_Sertifikat.Text = ""
        TB_namawakif.Text = ""
        TB_Agama.Text = ""
        CB_jns_kelamin.Text = ""
        TB_luastanah.Text = ""
        TB_jmldokumen.Text = ""
        DateTimePicker1.Text = ""
        TB_alamat.Text = ""
        TB_Provinsi.Text = ""
        TB_kota.Text = ""
        TB_kecamatan.Text = ""
        tampil_data()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'simpan data
        If Me.TB_No_Sertifikat.Text = "" Or Me.TB_namawakif.Text = "" Or Me.TB_Agama.Text = "" Or Me.CB_jns_kelamin.Text = "" Or Me.TB_jmldokumen.Text = "" Or Me.TB_luastanah.Text = "" Or Me.DateTimePicker1.Text = "" Or Me.TB_alamat.Text = "" Or Me.TB_Provinsi.Text = "" Or Me.TB_kota.Text = "" Or Me.TB_kecamatan.Text = "" Then
            MsgBox("Maaf Data Anda Belum Lengkap")
        Else
            Dim simpan As String
            MsgBox("Data Anda Akan Disimpan")
            simpan = "insert into data_tanah (no_sertifikat, nama_wakif, agama, jenis_kelamin, luas_tanah, jumlah_dokumen, tgl_sertifikat, alamat, provinsi, kota, kecamatan)VALUES ('" & TB_No_Sertifikat.Text & "','" & TB_namawakif.Text & "','" & TB_Agama.Text & "','" & CB_jns_kelamin.Text & "','" & TB_luastanah.Text & "','" & TB_jmldokumen.Text & "','" & Format(Me.DateTimePicker1.Value, "yyyy-MM-dd") & "','" & TB_alamat.Text & "','" & TB_Provinsi.Text & "','" & TB_kota.Text & "','" & TB_kecamatan.Text & "')"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(simpan, conn)
            cmd.ExecuteNonQuery()
            tampil_data()
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        data_tanah = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TB_No_Sertifikat.Text = data_tanah
        TB_namawakif.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TB_Agama.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        CB_jns_kelamin.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TB_jmldokumen.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TB_luastanah.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        DateTimePicker1.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TB_alamat.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TB_Provinsi.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        TB_kota.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
        TB_kecamatan.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        dasboard.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'edit data
        If Me.TB_No_Sertifikat.Text = "" Or Me.TB_namawakif.Text = "" Or Me.TB_Agama.Text = "" Or Me.CB_jns_kelamin.Text = "" Or Me.TB_jmldokumen.Text = "" Or Me.TB_luastanah.Text = "" Or Me.DateTimePicker1.Text = "" Or Me.TB_alamat.Text = "" Or Me.TB_Provinsi.Text = "" Or Me.TB_kota.Text = "" Or Me.TB_kecamatan.Text = "" Then
            MsgBox("Maaf datanya tidak ada yang diupdate")
        Else
            Call koneksiserver()
            MsgBox("Anda akan mengupdate datanya")
            Dim edit As String = "update data_tanah set no_sertifikat ='" & Me.TB_No_Sertifikat.Text _
                                 & "', nama_wakif = '" & Me.TB_namawakif.Text _
                                 & "', agama ='" & Me.TB_Agama.Text _
                                 & "', jenis_kelamin ='" & Me.CB_jns_kelamin.Text _
                                 & "', jumlah_dokumen ='" & Me.TB_jmldokumen.Text _
                                 & "', luas_tanah ='" & Me.TB_luastanah.Text _
                                 & "', tgl_sertifikat ='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") _
                                 & "', alamat ='" & Me.TB_alamat.Text _
                                 & "', provinsi ='" & Me.TB_Provinsi.Text _
                                 & "', kota ='" & Me.TB_kota.Text _
                                 & "', kecamatan ='" & Me.TB_kecamatan.Text _
                                 & "' where no_sertifikat = '" _
                                 & Me.TB_No_Sertifikat.Text & "'"
            cmd = New MySql.Data.MySqlClient.MySqlCommand(edit, conn)
            cmd.ExecuteNonQuery()
            MsgBox("Edit Berhasil")
            tampil_data()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'hapus data
        If Me.TB_No_Sertifikat.Text = "" Or Me.TB_namawakif.Text = "" Or Me.TB_Agama.Text = "" Or Me.CB_jns_kelamin.Text = "" Or Me.TB_jmldokumen.Text = "" Or Me.TB_luastanah.Text = "" Or Me.DateTimePicker1.Text = "" Or Me.TB_alamat.Text = "" Or Me.TB_Provinsi.Text = "" Or Me.TB_kota.Text = "" Or Me.TB_kecamatan.Text = "" Then
            MsgBox("Maaf datanya tidak ada yang dihapus")
        Else
            If MessageBox.Show("Anda yakin akan menghapus datanya ??", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = "delete from data_tanah where no_sertifikat = '" & Me.TB_No_Sertifikat.Text & "'"
                cmd = New MySqlCommand(hapus, conn)
                cmd.ExecuteNonQuery()
                bersih()
            End If
        End If
    End Sub
End Class