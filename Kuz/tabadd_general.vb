Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO


Public Class tabadd_general
    Dim txt1 As String
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13, adapter14, adapter15, adapter16, adapter17 As MySqlDataAdapter
    Dim query1, query2, query3, query4, query5, query6 As String
    Dim connstring As String
    Dim cmd As MySqlCommand
    Dim changes As DataSet


    Public ind, changed As Integer
    Public flag As Integer
    Public ind_1, ind_2 As Integer
    Public flag_1, flag_2 As Integer
    Dim dob As TimeSpan
    Dim dob_int, dob_yrs, dob_days As Integer
    Dim txt, txt2 As String
    
    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
        If ComboBox1.Text = "Calf" Then
            CheckBox1.Enabled = True
        Else
            CheckBox1.Enabled = False
        End If
        
    End Sub
  
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        dob = (DateTime.Now) - DateTimePicker1.Value
        dob_int = dob.TotalDays
        dob_yrs = dob_int \ 365
        If dob_yrs = 0 Then
            dob_days = dob_int
        Else
            dob_days = dob_int Mod 365
        End If
        'Label23.Text = dob_yrs & " year(s) " & dob_days & " days"
    End Sub
   

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckBox1.Enabled = False
        changed = 0
        TextBox8.Enabled = False
        If Menu_tiles.newflag = 0 Then
            Dim mydate As Date
            Dim rp, cnt1, fs As Integer
            TextBox1.Enabled = False

            connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
            connection = New MySqlConnection(My.Settings.mydbConnectionString)
            Try
                connection.Open()
                adapter = New MySqlDataAdapter("select * from cattle where cattle_id='" & Menu_tiles.cowid & "'", connection)
                adapter.Fill(ds)
                mydate = ds.Tables(0).Rows(0).Item(4)
                TextBox1.Text = (ds.Tables(0).Rows(0).Item(0))
                TextBox3.Text = (ds.Tables(0).Rows(0).Item(1))
                TextBox2.Text = (ds.Tables(0).Rows(0).Item(2))
                ComboBox5.Text = (ds.Tables(0).Rows(0).Item(3))
                mydate = (ds.Tables(0).Rows(0).Item(4))
                DateTimePicker1.Value = mydate

                ComboBox7.Text = (ds.Tables(0).Rows(0).Item(5))
                ComboBox6.Text = (ds.Tables(0).Rows(0).Item(6))
                ComboBox8.Text = (ds.Tables(0).Rows(0).Item(14))
                TextBox4.Text = (ds.Tables(0).Rows(0).Item(18))
                TextBox7.Text = (ds.Tables(0).Rows(0).Item(20))

                rp = ds.Tables(0).Rows(0).Item(8)
                If rp = 1 Then
                    RadioButton1.Checked = True
                Else
                    RadioButton2.Checked = True


                End If

                TextBox8.Text = Str(ds.Tables(0).Rows(0).Item(16))                                           'bought

                TextBox6.Text = Str(ds.Tables(0).Rows(0).Item(17))              'sold

                ComboBox1.Text = (ds.Tables(0).Rows(0).Item(19))
                txt2 = ComboBox1.Text
                
                If ComboBox1.Text = "Calf" Then
                    adapter17 = New MySqlDataAdapter("select * from calf where calf_id='" & Menu_tiles.cowid & "'", connection)
                    adapter17.Fill(ds7)
                    fs = (ds7.Tables(0).Rows(0).Item(1))
                    If fs = 1 Then
                        CheckBox1.Checked = True
                    Else
                        CheckBox1.Checked = False

                    End If
                End If


                adapter11 = New MySqlDataAdapter("select * from cattle_group where cattle_cattle_id='" & Menu_tiles.cowid & "'", connection)
                adapter11.Fill(ds1)
                ComboBox11.Text = (ds1.Tables(0).Rows(0).Item(1))

                adapter16 = New MySqlDataAdapter("select count(*) from dam where cattle_cattle_id='" & Menu_tiles.cowid & "'", connection)
                adapter16.Fill(ds6)
                cnt1 = (ds6.Tables(0).Rows(0).Item(0))
                If cnt1 > 0 Then
                    adapter12 = New MySqlDataAdapter("select * from dam where cattle_cattle_id='" & Menu_tiles.cowid & "'", connection)
                    adapter12.Fill(ds2)
                    TextBox5.Text = (ds2.Tables(0).Rows(0).Item(1))
                End If
                
                'dairy

                adapter13 = New MySqlDataAdapter("select * from dairy where iddairy=(select dairy_iddairy from dairy_cattle where cattle_cattle_id='" & Menu_tiles.cowid & "')", connection)
                adapter13.Fill(ds3)
                ComboBox2.Text = (ds3.Tables(0).Rows(0).Item(1))

                'owner
                adapter14 = New MySqlDataAdapter("select * from person where idperson=(select person_idperson from owner where cattle_cattle_id='" & Menu_tiles.cowid & "')", connection)
                adapter14.Fill(ds4)
                ComboBox4.Text = ds4.Tables(0).Rows(0).Item(2) & " " & ds4.Tables(0).Rows(0).Item(1)

                'breeder
                adapter15 = New MySqlDataAdapter("select * from person where idperson=(select person_idperson from breeder where cattle_cattle_id='" & Menu_tiles.cowid & "')", connection)
                adapter15.Fill(ds5)
                ComboBox3.Text = ds5.Tables(0).Rows(0).Item(2) & " " & ds5.Tables(0).Rows(0).Item(1)


                'MsgBox("Successfully entered")
                connection.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
       
        Dim connection As MySqlConnection
        Dim ds4, ds1, ds2, ds3 As New DataSet
        Dim adapter1, adapter2 As MySqlDataAdapter
        Dim connstring As String
        Dim count1, i, cowid_pres, damid_pres As Integer
        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=vishakha"
        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        Try
            connection.Open()
            If txt2 <> ComboBox1.Text Then
                changed = 1
            End If
            adapter1 = New MySqlDataAdapter("select * from cattle", connection)
            adapter1.Fill(ds1)

            adapter2 = New MySqlDataAdapter("select count(*) from cattle", connection)
            adapter2.Fill(ds2)
            count1 = ds2.Tables(0).Rows(0).Item(0)

            If Menu_tiles.newflag = 1 Then

                While i < count1
                    If ds1.Tables(0).Rows(i).Item(0) = TextBox1.Text Then
                        cowid_pres = 1
                    End If
                    i = i + 1
                End While
                
            End If

            i = 0
            While i < count1
                If ds1.Tables(0).Rows(i).Item(0) = TextBox5.Text Then
                    damid_pres = 1
                End If
                i = i + 1
            End While


            If damid_pres = 0 Then
                MsgBox("Dam could not be found!", , "Error!")

            ElseIf cowid_pres = 1 Then
                MsgBox("Cow ID already present." & Chr(10) & Chr(10) & " Please enter different Cow ID", , "Error!")
            Else
                connection.Close()
                tabadd_measure.Show()
                Hide()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        'dairies

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Enabled = True Then
            TextBox8.Enabled = True
        End If

    End Sub
End Class