Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO






Public Class tabadd_measure
    Public n, empty_measure As Integer
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13 As MySqlDataAdapter
    Dim connstring As String
    Dim cmd As MySqlCommand
    Public click_edit As Integer
    Private Sub tabadd_measure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button8.Enabled = False
        '  Button7.Enabled = False
        Dim cnt As Integer
        Dim cowid As String

        Dim mydate As Date
        If Menu_tiles.newflag = 0 Then
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
                    DataGridView4.Rows.Add(mydate.ToString("MM/dd/yyyy"), Str(ds1.Tables(0).Rows(i).Item(3)), Str(ds1.Tables(0).Rows(i).Item(2)), Str(ds1.Tables(0).Rows(i).Item(1)), Str(ds1.Tables(0).Rows(i).Item(4)), Str(ds1.Tables(0).Rows(i).Item(5)), Str(ds1.Tables(0).Rows(i).Item(6)), Str(ds1.Tables(0).Rows(i).Item(7)), Str(ds1.Tables(0).Rows(i).Item(8)), Str(ds1.Tables(0).Rows(i).Item(9)))

                Next

                connection.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        click_edit = 0
        Add_measure.Show()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        click_edit = 1
        Add_measure.Show()
        tabadd_general.flag_2 = 1

    End Sub


    Private Sub DataGridView4_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick
        Button8.Enabled = True
        ' Button7.Enabled = True
        tabadd_general.ind_2 = DataGridView4.CurrentRow.Index

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView4.RowCount = 1 Then
            empty_measure = 1
        Else
            empty_measure = 0
        End If

        tabadd_breed.Show()
        Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tabadd_general.Show()
        Hide()
    End Sub


    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        click_edit = 1
        Add_measure.Show()
        tabadd_general.flag_2 = 1

    End Sub
End Class