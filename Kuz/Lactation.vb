Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO

Public Class Lactation
    Dim txt As String
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3, ds4, ds5 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13, adapter14, adapter15 As MySqlDataAdapter
    Dim query1, query2, query3, query4, query5, query6 As String
    Dim connstring As String
    Dim cmd As MySqlCommand
    Dim changes As DataSet
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Medical.Show()
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Notes.Show()
        Close()
    End Sub

    Private Sub Lactation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cnt, i, milkid As Integer
        Dim cowid As String

        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        cowid = Menu_tiles.TextBox1.Text
       

        Try
            connection.Open()

            adapter15 = New MySqlDataAdapter("select count(*) from cow where cow_id='" & cowid & "'", connection)
            adapter15.Fill(ds5)
            cnt = (ds5.Tables(0).Rows(0).Item(0))


            If cnt > 0 Then
                adapter = New MySqlDataAdapter("select * from cow where cow_id='" & cowid & "'", connection)
                adapter.Fill(ds)
                txt = (ds.Tables(0).Rows(0).Item(2))

                If txt <> "Not Exposed" Then
                    adapter13 = New MySqlDataAdapter("select count(*) from cow_milk where cow_cow_id='" & cowid & "'", connection)
                    adapter13.Fill(ds3)
                    cnt = ds3.Tables(0).Rows(0).Item(0)
                    If cnt > 0 Then
                        adapter11 = New MySqlDataAdapter("select milk_idmilk from cow_milk where cow_cow_id='" & cowid & "'", connection)
                        adapter11.Fill(ds1)
                        milkid = ds1.Tables(0).Rows(cnt - 1).Item(0)

                        adapter12 = New MySqlDataAdapter("select * from milk where idmilk='" & milkid & "'", connection)
                        adapter12.Fill(ds2)
                        Label5.Text = Str(ds2.Tables(0).Rows(0).Item(1))
                        Label8.Text = Str(ds2.Tables(0).Rows(0).Item(4))
                        Label9.Text = Str(ds2.Tables(0).Rows(0).Item(6))
                        Label10.Text = Str(ds2.Tables(0).Rows(0).Item(3))
                        Label11.Text = Str(ds2.Tables(0).Rows(0).Item(2))
                        Label12.Text = Str(ds2.Tables(0).Rows(0).Item(5))
                        'MsgBox("Successfully entered")


                        adapter14 = New MySqlDataAdapter("select * from milk where idmilk in(select milk_idmilk from cow_milk where cow_cow_id= '" & cowid & "')", connection)
                        adapter14.Fill(ds4)
                        For i = 0 To cnt - 1
                            DataGridView2.Rows.Add(Str(ds4.Tables(0).Rows(i).Item(1)), Str(ds4.Tables(0).Rows(i).Item(6)), Str(ds4.Tables(0).Rows(i).Item(4)), Str(ds4.Tables(0).Rows(i).Item(3)), Str(ds4.Tables(0).Rows(i).Item(2)), Str(ds4.Tables(0).Rows(i).Item(5)))
                        Next
                    End If
                   
                End If
            End If

            connection.Close()


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub Chart1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class