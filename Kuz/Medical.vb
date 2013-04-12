Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO



Public Class Medical

    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13 As MySqlDataAdapter
    Dim connstring As String
    Dim cmd As MySqlCommand
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Lactation.Show()
        Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Measurements.Show()
        Close()
    End Sub

    Private Sub Medical_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt As Integer
        Dim cowid As String
        Dim mydate1, mydate2 As Date
        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        cowid = Menu_tiles.TextBox1.Text

        Try
            connection.Open()
            adapter = New MySqlDataAdapter("select count(*) from cattle_medical where cattle_cattle_id='" & cowid & "'", connection)
            adapter.Fill(ds)
            cnt = (ds.Tables(0).Rows(0).Item(0))

            adapter11 = New MySqlDataAdapter("select * from medical where idmedical in (select medical_idmedical from cattle_medical where cattle_cattle_id='" & cowid & "')", connection)
            adapter11.Fill(ds1)


            For i = 0 To cnt - 1

                mydate1 = ds1.Tables(0).Rows(i).Item(5)
                mydate2 = ds1.Tables(0).Rows(i).Item(6)
                DataGridView2.Rows.Add((ds1.Tables(0).Rows(i).Item(7)), (ds1.Tables(0).Rows(i).Item(4)), (ds1.Tables(0).Rows(i).Item(3)), mydate1.ToString("MM/dd/yyyy"), mydate2.ToString("MM/dd/yyyy"), Str(ds1.Tables(0).Rows(i).Item(1)), Str(ds1.Tables(0).Rows(i).Item(2)), (ds1.Tables(0).Rows(i).Item(8)))

            Next

            connection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class