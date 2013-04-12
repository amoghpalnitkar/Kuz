Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO


Public Class Breeding
    Dim txt As String
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13, adapter14, adapter15, adp3 As MySqlDataAdapter
    Dim query1, query2, query3, query4, query5, query6 As String
    Dim connstring As String
    Dim cmd As MySqlCommand
    Dim changes As DataSet
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        General.Show()
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Measurements.Show()
        Close()
    End Sub

    Private Sub Breeding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mydate As Date
        Dim cnt, breedid As Integer
        Dim cowid As String

        'TextBox1.Text = Menu_tiles.TextBox1.Text
        cowid = Menu_tiles.TextBox1.Text
        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        Try
            connection.Open()
            adapter11 = New MySqlDataAdapter("select * from cattle where cattle_id='" & cowid & "'", connection)
            adapter11.Fill(ds1)
            Label22.Text = Str(ds1.Tables(0).Rows(0).Item(10))
            Label23.Text = Str(ds1.Tables(0).Rows(0).Item(11))
            Label24.Text = Str(ds1.Tables(0).Rows(0).Item(12))
            Label25.Text = Str(ds1.Tables(0).Rows(0).Item(13))

            adapter15 = New MySqlDataAdapter("select count(*) from cow where cow_id='" & cowid & "'", connection)
            adapter15.Fill(ds5)
            cnt = (ds5.Tables(0).Rows(0).Item(0))

            If cnt > 0 Then
                adapter = New MySqlDataAdapter("select * from cow where cow_id='" & cowid & "'", connection)
                adapter.Fill(ds)
                Label15.Text = (ds.Tables(0).Rows(0).Item(2))
                adp3 = New MySqlDataAdapter("select * from cow_breeding where cow_cow_id='" & cowid & "' order by breeding_idbreeding desc limit 0,1", connection)
                adp3.Fill(ds6)

                If Label15.Text = "Palpated Bred" Or Label15.Text = "Exposed" Then

                    breedid = ds6.Tables(0).Rows(0).Item(0)
                    adapter12 = New MySqlDataAdapter("select * from breeding where idbreeding =" & breedid, connection)
                    adapter12.Fill(ds2)
                    mydate = (ds2.Tables(0).Rows(0).Item(1))
                    Label19.Text = mydate.ToString("dd-MM-yyyy")
                    mydate = ds2.Tables(0).Rows(0).Item(2)
                    Label21.Text = mydate.ToString("dd-MM-yyyy")
                    mydate = ds2.Tables(0).Rows(0).Item(3)
                    Label20.Text = mydate.ToString("dd-MM-yyyy")
                    Label18.Text = (ds2.Tables(0).Rows(0).Item(5))
                    Label16.Text = (ds2.Tables(0).Rows(0).Item(6))

                End If

                adapter13 = New MySqlDataAdapter("select count(*) from cow_breeding where cow_cow_id='" & cowid & "'", connection)
                adapter13.Fill(ds3)
                cnt = (ds3.Tables(0).Rows(0).Item(0))

                If cnt > 0 Then
                    adapter14 = New MySqlDataAdapter("select * from breeding where idbreeding in (select breeding_idbreeding from cow_breeding where cow_cow_id='" & cowid & "')", connection)
                    adapter14.Fill(ds4)


                    For i = 0 To cnt - 1
                        mydate = ds4.Tables(0).Rows(i).Item(1)
                        DataGridView1.Rows.Add(mydate.ToString("dd-MM-yyyy"), (ds4.Tables(0).Rows(i).Item(5)), (ds4.Tables(0).Rows(i).Item(6)), (ds4.Tables(0).Rows(i).Item(4)))
                    Next
                End If
            End If





            'MsgBox("Successfully entered")
            connection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class