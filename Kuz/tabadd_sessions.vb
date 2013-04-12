Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO



Public Class tabadd_sessions

    Dim connection As MySqlConnection
    Dim connstring As String
    Dim ses_id, count As Integer
    Dim total_milk As Decimal


    Private Sub tabadd_lactation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker5.Enabled = False
        DateTimePicker6.Enabled = False
        DateTimePicker7.Enabled = False
        DateTimePicker8.Enabled = False
        DateTimePicker9.Enabled = False
        DateTimePicker10.Enabled = False
    End Sub

    Private Sub TextBox16_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox16.TextChanged
        DateTimePicker5.Enabled = True
    End Sub
    Private Sub TextBox17_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox17.TextChanged
        DateTimePicker6.Enabled = True
    End Sub

    Private Sub TextBox18_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox18.TextChanged
        DateTimePicker7.Enabled = True
    End Sub

    Private Sub TextBox19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox19.TextChanged
        DateTimePicker8.Enabled = True
    End Sub
    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox20.TextChanged
        DateTimePicker9.Enabled = True
    End Sub

    Private Sub TextBox21_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox21.TextChanged
        DateTimePicker10.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tabadd_notes.Show()
        Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        tabadd_medi.Show()
        Hide()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox16.Text = "" Or TextBox16.Enabled = False Then
            count = count + 1
            TextBox16.Text = "0"
            TextBox16.Enabled = False
        End If
        If TextBox17.Text = "" Or TextBox17.Enabled = False Then
            count = count + 1
            TextBox17.Text = "0"
            TextBox17.Enabled = False
        End If
        If TextBox18.Text = "" Or TextBox18.Enabled = False Then
            count = count + 1
            TextBox18.Text = "0"
            TextBox18.Enabled = False
        End If
        If TextBox19.Text = "" Or TextBox19.Enabled = False Then
            count = count + 1
            TextBox19.Text = "0"
            TextBox19.Enabled = False
        End If
        If TextBox20.Text = "" Or TextBox20.Enabled = False Then
            count = count + 1
            TextBox20.Text = "0"
            TextBox20.Enabled = False
        End If
        If TextBox21.Text = "" Or TextBox21.Enabled = False Then
            count = count + 1
            TextBox21.Text = "0"
            TextBox21.Enabled = False
        End If

        total_milk = Convert.ToDecimal(TextBox16.Text) + Convert.ToDecimal(TextBox17.Text) + Convert.ToDecimal(TextBox18.Text) + Convert.ToDecimal(TextBox19.Text) + Convert.ToDecimal(TextBox20.Text) + Convert.ToDecimal(TextBox21.Text)
        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        Try
            connection.Open()
            Dim cmd As MySqlCommand

            Dim ds1 As New DataSet
            Dim adapter1 As MySqlDataAdapter
            Dim adapt As MySqlDataAdapter
            Dim dataset1 As New DataSet
            Dim milk_id As Integer
            Dim ses_date As Date
            Dim mysql_ses_date As String

            adapter1 = New MySqlDataAdapter("select count(*) from sessions", connection)

            adapter1.Fill(ds1)
            ses_id = ds1.Tables(0).Rows(0).Item(0)
            'MsgBox(ses_id)
            ses_id = ses_id + 1

            
            If tabadd_lactation.lact_click = 1 Then
                tabadd_lactation.lact_click = 0
                adapt = New MySqlDataAdapter("select count(*) from milk", connection)
                adapt.Fill(dataset1)
                milk_id = dataset1.Tables(0).Rows(0).Item(0)
                milk_id = milk_id + 1
                'milk
                cmd = New MySqlCommand("insert into milk(idmilk,lactation_no,days_to_peak,peak_yield,total_milk,days_in_milk,avg_daily) values (" & milk_id & "," & Val(tabadd_lactation.ComboBox1.Text) & "," & 0 & "," & 0 & "," & 0 & "," & 0 & "," & 0 & ")", connection)
                cmd.ExecuteNonQuery()
                'cow_milk
                cmd = New MySqlCommand("insert into cow_milk(cow_cow_id,milk_idmilk) values ('" & tabadd_general.TextBox1.Text & "'," & milk_id & ")", connection)
                cmd.ExecuteNonQuery()
            Else

                adapt = New MySqlDataAdapter("select milk_idmilk from cow_milk where cow_cow_id='" & tabadd_general.TextBox1.Text & "' order by milk_idmilk desc limit 0,1 ", connection)
                adapt.Fill(dataset1)
                milk_id = dataset1.Tables(0).Rows(0).Item(0)
            End If
           


           

            ses_date = DateTimePicker5.Value
            mysql_ses_date = ses_date.Year & "-" & ses_date.Month & "-" & ses_date.Day

            'milk_sessions
            cmd = New MySqlCommand("insert into milk_sessions values ('" & mysql_ses_date & "'," & milk_id & "," & ses_id & ")", connection)
            cmd.ExecuteNonQuery()

            'sessions
            cmd = New MySqlCommand("insert into sessions values (" & ses_id & "," & Convert.ToDecimal(TextBox16.Text) & "," & Convert.ToDecimal(TextBox17.Text) & "," & Convert.ToDecimal(TextBox18.Text) & "," & Convert.ToDecimal(TextBox19.Text) & "," & Convert.ToDecimal(TextBox20.Text) & "," & Convert.ToDecimal(TextBox21.Text) & "," & total_milk & ")", connection)
            cmd.ExecuteNonQuery()
            connection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        MsgBox("Total Milk - " & Chr(10) & Chr(13) & total_milk)
        Close()

    End Sub
End Class