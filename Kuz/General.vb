Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO

Public Class General
    Public cow_calf As Integer
    Dim txt, txt1 As String
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13, adapter14, adapter15, adapter16, adapter17 As MySqlDataAdapter
    Dim query1, query2, query3, query4, query5, query6 As String
    Dim connstring As String
    Dim cmd As MySqlCommand
    Dim changes As DataSet
    Dim dob As TimeSpan
    Dim dob_int, dob_yrs, dob_days As Integer
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim mydate As Date
        Dim rp, cnt1, fs As Integer
        cow_calf = 0
        'connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=amogh123"
        'connection = New MySqlConnection(connstring)
        'Try
        'connection.Open()
        ' adapter = New MySqlDataAdapter("select * from sessions", connection)
        'connection.Close()
        'adapter.Fill(ds)
        'Label1.Text = Str(ds.Tables(0).Rows(0).Item(0))
        'Catch ex As Exception
        'MsgBox("Disconnected")
        'End Try
        TextBox1.Text = Menu_tiles.cowid
        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        Try
            connection.Open()
            adapter = New MySqlDataAdapter("select * from cattle where cattle_id='" & TextBox1.Text & "'", connection)
            adapter.Fill(ds)
            mydate = ds.Tables(0).Rows(0).Item(4)
            Label20.Text = (ds.Tables(0).Rows(0).Item(0))
            Label19.Text = (ds.Tables(0).Rows(0).Item(1))
            Label23.Text = (ds.Tables(0).Rows(0).Item(2))
            Label21.Text = (ds.Tables(0).Rows(0).Item(3))
            Label28.Text = mydate.ToString("dd-MM-yyyy")
            Label29.Text = (ds.Tables(0).Rows(0).Item(5))
            Label32.Text = (ds.Tables(0).Rows(0).Item(6))
            rp = ds.Tables(0).Rows(0).Item(8)
            If rp = 1 Then
                txt = "Raised"
                txt1 = "NA"
            Else
                txt = "Purchased"
                txt1 = Str(ds.Tables(0).Rows(0).Item(16))

            End If
            Label36.Text = txt
            Label33.Text = (ds.Tables(0).Rows(0).Item(14))
            Label24.Text = txt1
            Label30.Text = Str(ds.Tables(0).Rows(0).Item(17))
            Label26.Text = (ds.Tables(0).Rows(0).Item(18))
            Label37.Text = (ds.Tables(0).Rows(0).Item(19))
            If Label37.Text = "Calf" Or Label37.Text = "calf" Then
                cow_calf = 1
                Label43.Visible = True
                Label44.Visible = True
                adapter17 = New MySqlDataAdapter("select * from calf where calf_id='" & Menu_tiles.cowid & "'", connection)
                adapter17.Fill(ds7)
                fs = (ds7.Tables(0).Rows(0).Item(1))
                If fs = 1 Then
                    Label44.Text = "Active"
                Else
                    Label44.Text = "Not Active"

                End If
            
            End If
            Label31.Text = (ds.Tables(0).Rows(0).Item(20))
            adapter11 = New MySqlDataAdapter("select * from cattle_group where cattle_cattle_id='" & Menu_tiles.cowid & "'", connection)
            adapter11.Fill(ds1)
            Label22.Text = (ds1.Tables(0).Rows(0).Item(1))

            adapter16 = New MySqlDataAdapter("select count(*) from dam where cattle_cattle_id='" & Menu_tiles.cowid & "'", connection)
            adapter16.Fill(ds6)
            cnt1 = (ds6.Tables(0).Rows(0).Item(0))
            If cnt1 > 0 Then
                adapter12 = New MySqlDataAdapter("select * from dam where cattle_cattle_id='" & Menu_tiles.cowid & "'", connection)
                adapter12.Fill(ds2)
                Label25.Text = (ds2.Tables(0).Rows(0).Item(1))
            End If
            dob = (DateTime.Now) - mydate
            dob_int = dob.TotalDays
            dob_yrs = dob_int \ 365
            If dob_yrs = 0 Then
                dob_days = dob_int
            Else
                dob_days = dob_int Mod 365
            End If
            Label27.Text = dob_yrs & " year(s) " & dob_days & " days"
            'dairy

            adapter13 = New MySqlDataAdapter("select * from dairy where iddairy=(select dairy_iddairy from dairy_cattle where cattle_cattle_id='" & Menu_tiles.cowid & "')", connection)
            adapter13.Fill(ds3)
            Label38.Text = (ds3.Tables(0).Rows(0).Item(1))
            adapter14 = New MySqlDataAdapter("select * from person where idperson=(select person_idperson from owner where cattle_cattle_id='" & Menu_tiles.cowid & "')", connection)
            adapter14.Fill(ds4)
            Label35.Text = ds4.Tables(0).Rows(0).Item(2) & " " & ds4.Tables(0).Rows(0).Item(1)
            adapter15 = New MySqlDataAdapter("select * from person where idperson=(select person_idperson from breeder where cattle_cattle_id='" & Menu_tiles.cowid & "')", connection)
            adapter15.Fill(ds5)
            Label34.Text = ds5.Tables(0).Rows(0).Item(2) & " " & ds5.Tables(0).Rows(0).Item(1)
            Label37.Text = Str(ds.Tables(0).Rows(0).Item(17))

            connection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Breeding.Show()
        Close()
    End Sub

    Private Sub Label43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label43.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label27.Click

    End Sub
End Class