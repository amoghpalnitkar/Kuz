Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO





Public Class tabadd_medi
    Public n, empty_medi As Integer
    Public click_edit As Integer
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13 As MySqlDataAdapter
    Dim connstring As String
    Dim cmd As MySqlCommand
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        click_edit = 0
        Add_med.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        click_edit = 1
        Add_med.Show()
        tabadd_general.flag_1 = 1

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGridView2.Rows.RemoveAt(tabadd_general.ind_1)
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        ' Button4.Enabled = True
        Button5.Enabled = True
        tabadd_general.ind_1 = DataGridView2.CurrentRow.Index
    End Sub

    Private Sub tabadd_medi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Button4.Enabled = False
        Button5.Enabled = False

        Dim cnt As Integer
        Dim cowid As String
        Dim mydate1, mydate2 As Date
        If Menu_tiles.newflag = 0 Then
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
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tabadd_breed.Show()
        Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView2.RowCount = 1 Then
            empty_medi = 1
        Else
            empty_medi = 0
        End If
        tabadd_notes.Show()
        Hide()
    End Sub
End Class