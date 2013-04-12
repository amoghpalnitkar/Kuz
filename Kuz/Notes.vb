Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO


Public Class Notes

    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13 As MySqlDataAdapter
    Dim connstring As String
    Dim cmd As MySqlCommand
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Lactation.Show()
        Close()
    End Sub

    Private Sub Notes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt As Integer
        Dim mydate1 As Date
        Dim cowid As String

        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        cowid = Menu_tiles.TextBox1.Text

        Try
            connection.Open()
            adapter = New MySqlDataAdapter("select count(*) from cattle_notes where cattle_cattle_id='" & cowid & "'", connection)
            adapter.Fill(ds)
            cnt = (ds.Tables(0).Rows(0).Item(0))

            adapter11 = New MySqlDataAdapter("select * from notes where idnotes in (select notes_idnotes from cattle_notes where cattle_cattle_id='" & cowid & "')", connection)
            adapter11.Fill(ds1)


            For i = 0 To cnt - 1

                mydate1 = ds1.Tables(0).Rows(i).Item(2)
                DataGridView3.Rows.Add(mydate1.ToString("dd-MM-yyyy"), (ds1.Tables(0).Rows(i).Item(3)), (ds1.Tables(0).Rows(i).Item(1)))

            Next

            connection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick

    End Sub
End Class