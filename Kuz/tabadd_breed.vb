Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO


Public Class tabadd_breed
    Dim txt, txt2 As String
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13, adapter14, adapter15, adp3 As MySqlDataAdapter
    Dim query1, query2, query3, query4, query5, query6 As String
    Dim connstring As String
    Dim cmd As MySqlCommand
    Dim changes As DataSet
    Public changed1 As Integer

    Private Sub tabadd_breed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mydate As Date
        Dim cnt, breedid As Integer
        Dim cowid As String
        changed1 = 0
        If Menu_tiles.newflag = 0 Then
            cowid = Menu_tiles.TextBox1.Text
            connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
            connection = New MySqlConnection(My.Settings.mydbConnectionString)
            Try
                connection.Open()
                adapter11 = New MySqlDataAdapter("select * from cattle where cattle_id='" & cowid & "'", connection)
                adapter11.Fill(ds1)
                TextBox29.Text = Str(ds1.Tables(0).Rows(0).Item(10))
                TextBox28.Text = Str(ds1.Tables(0).Rows(0).Item(11))
                TextBox27.Text = Str(ds1.Tables(0).Rows(0).Item(12))
                TextBox26.Text = Str(ds1.Tables(0).Rows(0).Item(13))

                adapter15 = New MySqlDataAdapter("select count(*) from cow where cow_id='" & cowid & "'", connection)
                adapter15.Fill(ds5)
                cnt = (ds5.Tables(0).Rows(0).Item(0))

                If cnt > 0 Then
                    adapter = New MySqlDataAdapter("select * from cow where cow_id='" & cowid & "'", connection)
                    adapter.Fill(ds)
                    ComboBox9.Text = (ds.Tables(0).Rows(0).Item(2))
                    txt2 = ComboBox9.Text
                    adp3 = New MySqlDataAdapter("select * from cow_breeding where cow_cow_id='" & cowid & "' order by breeding_idbreeding desc limit 0,1", connection)
                    adp3.Fill(ds6)

                    If ComboBox9.Text = "Palpated Bred" Or ComboBox9.Text = "Exposed" Then
                        breedid = ds6.Tables(0).Rows(0).Item(0)
                        adapter12 = New MySqlDataAdapter("select * from breeding where idbreeding =" & breedid, connection)
                        adapter12.Fill(ds2)
                        mydate = (ds2.Tables(0).Rows(0).Item(1))
                        DateTimePicker4.Value = mydate

                        mydate = ds2.Tables(0).Rows(0).Item(2)
                        DateTimePicker2.Value = mydate

                        mydate = ds2.Tables(0).Rows(0).Item(3)
                        DateTimePicker3.Value = mydate
                        TextBox7.Text = (ds2.Tables(0).Rows(0).Item(5))
                        ComboBox10.Text = (ds2.Tables(0).Rows(0).Item(6))

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

        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        tabadd_measure.Show()
        Hide()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt2 <> ComboBox9.Text Then
            changed1 = 1
        End If

        If DateTimePicker2.Enabled = True Then
            Dim dt As DateTime
            dt = DateTimePicker3.Value
            'MsgBox(dt)
            If (DateTime.Compare(DateTimePicker3.Value, DateTimePicker2.Value) > 0) Or (DateTime.Compare(DateTimePicker3.Value, DateTimePicker4.Value) > 0) Then
                MsgBox("Date bred should be before palpation date or Expected Due Date", , "Error!")
            ElseIf (DateTime.Compare(DateTimePicker2.Value, DateTimePicker4.Value) > 0) Then
                MsgBox("Palpation Date should be before Expected Due Date", , "Error!")
            Else
                tabadd_medi.Show()
                Hide()
            End If

        Else
            tabadd_medi.Show()
            Hide()
        End If

    End Sub

   

    Private Sub ComboBox9_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        If ComboBox9.Text = "Not Exposed" Then
            DateTimePicker2.Enabled = False
            DateTimePicker3.Enabled = False
            DateTimePicker4.Enabled = False
            TextBox1.Enabled = False
            TextBox7.Enabled = False
            ComboBox10.Enabled = False

        Else
            DateTimePicker2.Enabled = True
            DateTimePicker3.Enabled = True
            DateTimePicker4.Enabled = True
            TextBox1.Enabled = True
            TextBox7.Enabled = True
            ComboBox10.Enabled = True


        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        tabadd_sessions.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        tabadd_lactation.Show()

    End Sub
End Class