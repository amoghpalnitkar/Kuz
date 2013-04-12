Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO

Public Class Measurements

    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13 As MySqlDataAdapter
    Dim connstring As String
    Dim cmd As MySqlCommand

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MydbDataSet.measurements' table. You can move, or remove it, as needed.

        Dim cnt As Integer
        Dim mydate As Date
        Dim cowid As String

        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        cowid = Menu_tiles.TextBox1.Text

        Try
            connection.Open()
            adapter = New MySqlDataAdapter("select count(*) from cattle_measurements where cattle_cattle_id='" & cowid & "'", connection)
            adapter.Fill(ds)
            cnt = (ds.Tables(0).Rows(0).Item(0))

            adapter11 = New MySqlDataAdapter("select * from measurements where idmeasure in (select measurements_idmeasure from cattle_measurements where cattle_cattle_id='" & cowid & "')", connection)
            adapter11.Fill(ds1)


            For i = 0 To cnt - 1

                mydate = ds1.Tables(0).Rows(i).Item(10)
                DataGridView4.Rows.Add(mydate.ToString("dd-MM-yyyy"), Str(ds1.Tables(0).Rows(i).Item(3)), Str(ds1.Tables(0).Rows(i).Item(2)), Str(ds1.Tables(0).Rows(i).Item(1)), Str(ds1.Tables(0).Rows(i).Item(4)), Str(ds1.Tables(0).Rows(i).Item(5)), Str(ds1.Tables(0).Rows(i).Item(6)), Str(ds1.Tables(0).Rows(i).Item(7)), Str(ds1.Tables(0).Rows(i).Item(8)), Str(ds1.Tables(0).Rows(i).Item(9)))

            Next

            connection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Breeding.Show()
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Medical.Show()
        Close()
    End Sub

    Private Sub DataGridView4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

    End Sub
End Class