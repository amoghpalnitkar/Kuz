Imports MySql.Data.MySqlClient
Imports System.Data
Imports System.IO
Public Class tabadd_notes
    Public edit_click, n As Integer
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3, ds4, ds5, ds6, ds7, ds8 As New DataSet
    Dim adapter, adapter1, adapter2, adapter3, adapter11, adapter22, adapter33, adapter34, adp3 As MySqlDataAdapter
    Dim query1, query2, query3, query4, query5, query6 As String
    Dim connstring As String
    Dim cmd As MySqlCommand
    Dim changes As DataSet
    Dim cowid As String

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        edit_click = 0
        Add_notes.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        edit_click = 1
        Add_notes.Show()
        tabadd_general.flag = 1

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DataGridView3.Rows.RemoveAt(tabadd_general.ind)
    End Sub

    Private Sub DataGridView3_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellContentClick
        Button2.Enabled = True
        '   Button3.Enabled = True
        tabadd_general.ind = DataGridView3.CurrentRow.Index
    End Sub

    Private Sub tabadd_notes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        '  Button3.Enabled = False
        Dim cnt As Integer

        Dim mydate1 As Date
        If Menu_tiles.newflag = 0 Then
            connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=anuj123"
            connection = New MySqlConnection(My.Settings.mydbConnectionString)
            cowid = Menu_tiles.TextBox1.Text

            Try
                connection.Open()
                adapter22 = New MySqlDataAdapter("select count(*) from cattle_notes where cattle_cattle_id='" & cowid & "'", connection)
                adapter22.Fill(ds4)
                cnt = (ds4.Tables(0).Rows(0).Item(0))

                adapter11 = New MySqlDataAdapter("select * from notes where idnotes in (select notes_idnotes from cattle_notes where cattle_cattle_id='" & cowid & "')", connection)
                adapter11.Fill(ds5)


                For i = 0 To cnt - 1

                    mydate1 = ds5.Tables(0).Rows(i).Item(2)
                    DataGridView3.Rows.Add(mydate1.ToString("MM/dd/yyyy"), (ds5.Tables(0).Rows(i).Item(3)), (ds5.Tables(0).Rows(i).Item(1)))

                Next

                connection.Close()

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        tabadd_medi.Show()
        Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=anuj123"
        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        Dim stat, medid, measureid, notesid, breedingid, medid1, measureid1, notesid1 As Integer
        Dim cattle_dob, start_date, stop_date, measure_date, notes_date, calving_date, palp_date, insem_date As Date
        Dim mysql_dob, mysql_start_date, mysql_stop_date, mysql_measure_date, mysql_notes_date, mysql_calving_date, mysql_palp_date, mysql_insem_date As String
        Dim chkbx, breedid As Integer
        Try
            connection.Open()

            If Menu_tiles.newflag = 0 Then
                cowid = Menu_tiles.TextBox1.Text
                If tabadd_general.RadioButton1.Checked = True Then
                    stat = 1
                Else
                    stat = 2
                End If

                If tabadd_general.CheckBox1.Checked = True Then
                    chkbx = 1
                Else
                    chkbx = 0
                End If
                cattle_dob = tabadd_general.DateTimePicker1.Value
                mysql_dob = cattle_dob.Year & "-" & cattle_dob.Month & "-" & cattle_dob.Day

                'cattle
                cmd = New MySqlCommand("Update cattle set name = '" & tabadd_general.TextBox2.Text & "', rfid= '" & tabadd_general.TextBox3.Text & "',cow_calf = '" & tabadd_general.ComboBox1.Text & "',sire= '" & tabadd_general.TextBox4.Text & "',status = '" & tabadd_general.ComboBox7.Text & "',breed= '" & tabadd_general.ComboBox5.Text & "', color = '" & tabadd_general.ComboBox6.Text & "',horns= '" & tabadd_general.ComboBox8.Text & "',raised_purchased = '" & stat & "', bought_for= " & Val(tabadd_general.TextBox8.Text) & ", sold_for = " & Val(tabadd_general.TextBox6.Text) & ",breed1= " & Val(tabadd_breed.TextBox26.Text) & ", breed2 = " & Val(tabadd_breed.TextBox27.Text) & ",breed3= " & Val(tabadd_breed.TextBox28.Text) & ",breed4 = " & Val(tabadd_breed.TextBox29.Text) & ", insurer= '" & tabadd_general.TextBox7.Text & "', markings= '" & tabadd_general.ComboBox6.Text & "',ns_ai_et = '" & tabadd_breed.ComboBox10.Text & "', dob= '" & mysql_dob & "' where cattle_id='" & tabadd_general.TextBox1.Text & "'", connection)
                'cmd = New MySqlCommand("insert into cattle(cattle_id,name,rfid,cow_calf,sire,status,breed,color,horns,raised_purchased,bought_for,sold_for,breed1,breed2,breed3,breed4,insurer,markings,ns_ai_et,dob)values('" & tabadd_general.TextBox1.Text & "','" & tabadd_general.TextBox2.Text & "','" & tabadd_general.TextBox3.Text & "','" & tabadd_general.ComboBox1.Text & "','" & tabadd_general.TextBox4.Text & "','" & tabadd_general.ComboBox7.Text & "','" & tabadd_general.ComboBox5.Text & "','" & tabadd_general.ComboBox6.Text & "','" & tabadd_general.ComboBox8.Text & "'," & stat & "," & Val(tabadd_general.TextBox8.Text) & "," & Val(tabadd_general.TextBox6.Text) & "," & Val(tabadd_breed.TextBox26.Text) & "," & Val(tabadd_breed.TextBox27.Text) & "," & Val(tabadd_breed.TextBox28.Text) & "," & Val(tabadd_breed.TextBox29.Text) & ",'" & tabadd_general.TextBox7.Text & "','" & tabadd_general.ComboBox6.Text & "','" & tabadd_breed.ComboBox10.Text & "','" & mysql_dob & "')", connection) ' "','" & ComboBox1.Text & "','" ' Val(TextBox6.Text) ' ,'" val( TextBox8.Text)  "','" & TextBox1.Text & '")", connection)
                cmd.ExecuteNonQuery()

                If tabadd_general.changed = 1 Then
                    If tabadd_general.ComboBox1.Text = "Cow" Then
                        cmd = New MySqlCommand("delete from calf where calf_id ='" & tabadd_general.TextBox1.Text & "'", connection)
                        cmd.ExecuteNonQuery()
                        cmd = New MySqlCommand("insert into cow (cow_id,preg_status) values ('" & tabadd_general.TextBox1.Text & "','" & tabadd_breed.ComboBox9.Text & "')", connection)
                        cmd.ExecuteNonQuery()
                    End If
                End If

                'calf/cow
                If tabadd_general.ComboBox1.Text = "Calf" Then
                    cmd = New MySqlCommand("Update calf set feeding_status = " & chkbx, connection)
                    cmd.ExecuteNonQuery()
                Else
                    cmd = New MySqlCommand("Update cow set preg_status = '" & tabadd_breed.ComboBox9.Text & "'", connection)
                    cmd.ExecuteNonQuery()
                End If

                ''dam
                cmd = New MySqlCommand("Update dam set cattle_cattle_id = '" & tabadd_general.TextBox1.Text & "',cattle_cattle_id1='" & tabadd_general.TextBox5.Text & "'where cattle_cattle_id='" & cowid & "'", connection)
                cmd.ExecuteNonQuery()

                If tabadd_breed.changed1 = 1 Then

                    If tabadd_breed.ComboBox9.Text = "Exposed" Then
                        'generate breeding ID
                        adapter3 = New MySqlDataAdapter("select count(*) from breeding", connection)
                        adapter3.Fill(ds3)
                        breedingid = ds3.Tables(0).Rows(0).Item(0)
                        breedingid = breedingid + 1

                        'generate breeding dates
                        calving_date = tabadd_breed.DateTimePicker4.Value
                        mysql_calving_date = calving_date.Year & "-" & calving_date.Month & "-" & calving_date.Day

                        palp_date = tabadd_breed.DateTimePicker2.Value
                        mysql_palp_date = palp_date.Year & "-" & palp_date.Month & "-" & palp_date.Day

                        insem_date = tabadd_breed.DateTimePicker3.Value
                        mysql_insem_date = insem_date.Year & "-" & insem_date.Month & "-" & insem_date.Day

                        'breeding
                        cmd = New MySqlCommand("insert into breeding(idbreeding,calving_date,preg_check_date,insemination_date,comment,bred_to,ns_ai) values (" & breedingid & ",'" & mysql_calving_date & "','" & mysql_palp_date & "','" & mysql_insem_date & "','" & tabadd_breed.TextBox1.Text & "','" & tabadd_breed.TextBox7.Text & "','" & tabadd_breed.ComboBox10.Text & "' )", connection)
                        cmd.ExecuteNonQuery()

                        ''cow_breeding
                        cmd = New MySqlCommand("insert into cow_breeding(cow_cow_id,breeding_idbreeding) values ('" & tabadd_general.TextBox1.Text & "'," & breedingid & ")", connection)
                        cmd.ExecuteNonQuery()
                    End If

                Else

                    If tabadd_breed.ComboBox9.Text <> "Not Exposed" Then
                        'generate breeding dates
                        calving_date = tabadd_breed.DateTimePicker4.Value
                        mysql_calving_date = calving_date.Year & "-" & calving_date.Month & "-" & calving_date.Day

                        palp_date = tabadd_breed.DateTimePicker2.Value
                        mysql_palp_date = palp_date.Year & "-" & palp_date.Month & "-" & palp_date.Day

                        insem_date = tabadd_breed.DateTimePicker3.Value
                        mysql_insem_date = insem_date.Year & "-" & insem_date.Month & "-" & insem_date.Day


                        adp3 = New MySqlDataAdapter("select * from cow_breeding where cow_cow_id='" & cowid & "' order by breeding_idbreeding desc limit 0,1", connection)
                        adp3.Fill(ds6)
                        breedid = ds6.Tables(0).Rows(0).Item(0)
                        'breeding
                        cmd = New MySqlCommand("Update breeding set calving_date='" & mysql_calving_date & "',preg_check_date='" & mysql_palp_date & "', insemination_date='" & mysql_insem_date & "',comment='" & tabadd_breed.TextBox1.Text & "',bred_to='" & tabadd_breed.TextBox7.Text & "', ns_ai='" & tabadd_breed.ComboBox10.Text & "'where idbreeding=" & breedid, connection)
                        cmd.ExecuteNonQuery()
                    End If

                End If



                Dim cnt1, j, k, medi As Integer

                If tabadd_medi.empty_medi = 0 Then
                    adapter33 = New MySqlDataAdapter("select count(*) from cattle_medical where cattle_cattle_id='" & cowid & "'", connection)
                    adapter33.Fill(ds7)
                    cnt1 = (ds7.Tables(0).Rows(0).Item(0))

                    If tabadd_medi.click_edit = 1 Then


                        k = cnt1
                        j = 0
                        While j < k
                            Dim adapter34 As MySqlDataAdapter
                            Dim ds8 As New DataSet

                            'generate start and stop date according to mysql
                            start_date = tabadd_medi.DataGridView2.Rows.Item(j).Cells(3).Value
                            mysql_start_date = start_date.Year & "-" & start_date.Month & "-" & start_date.Day

                            stop_date = tabadd_medi.DataGridView2.Rows.Item(j).Cells(4).Value
                            mysql_stop_date = stop_date.Year & "-" & stop_date.Month & "-" & stop_date.Day

                            adapter34 = New MySqlDataAdapter("select medical_idmedical from cattle_medical where cattle_cattle_id='" & cowid & "'", connection)
                            adapter34.Fill(ds8)
                            medi = (ds8.Tables(0).Rows(j).Item(0))

                            cmd = New MySqlCommand("Update medical set days_to_treat=" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(5).Value & ", dump_days=" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(6).Value & ",medications='" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(2).Value & "',performed_by='" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(1).Value & "',start_date='" & mysql_start_date & "',stop_date='" & mysql_stop_date & "',ailment='" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(0).Value & "',comments= '" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(7).Value & "'where idmedical=" & medi, connection)
                            cmd.ExecuteNonQuery()
                            j = j + 1
                        End While

                    Else

                        'generate medical id
                        adapter = New MySqlDataAdapter("select count(*) from medical", connection)
                        adapter.Fill(ds)
                        medid = ds.Tables(0).Rows(0).Item(0)
                        medid = medid + 1
                        medid1 = medid
                        k = tabadd_medi.n + 1
                        j = cnt1
                        While j < k
                            ''generate start and stop date according to mysql
                            start_date = tabadd_medi.DataGridView2.Rows.Item(j).Cells(3).Value
                            mysql_start_date = start_date.Year & "-" & start_date.Month & "-" & start_date.Day

                            stop_date = tabadd_medi.DataGridView2.Rows.Item(j).Cells(4).Value
                            mysql_stop_date = stop_date.Year & "-" & stop_date.Month & "-" & stop_date.Day

                            cmd = New MySqlCommand("insert into medical(idmedical,days_to_treat,dump_days,medications,performed_by,start_date,stop_date,ailment,comments) values (" & medid & "," & tabadd_medi.DataGridView2.Rows.Item(j).Cells(5).Value & ",'" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(6).Value & "','" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(2).Value & "','" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(1).Value & "','" & mysql_start_date & "','" & mysql_stop_date & "','" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(0).Value & "','" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(7).Value & "')", connection)
                            cmd.ExecuteNonQuery()
                            medid = medid + 1
                            j = j + 1
                        End While

                        'cattle_medical
                        k = tabadd_medi.n + 1
                        j = cnt1
                        While j < k
                            cmd = New MySqlCommand("insert into cattle_medical(cattle_cattle_id,medical_idmedical) values ('" & tabadd_general.TextBox1.Text & "'," & medid1 & ")", connection)
                            cmd.ExecuteNonQuery()
                            medid1 = medid1 + 1
                            j = j + 1
                        End While
                    End If
                End If

                Dim cnt2 As Integer
                If tabadd_measure.empty_measure = 0 Then
                    Dim adapter39 As MySqlDataAdapter
                    Dim ds9 As New DataSet


                    adapter39 = New MySqlDataAdapter("select count(*) from cattle_measurements where cattle_cattle_id='" & cowid & "'", connection)
                    adapter39.Fill(ds9)
                    cnt2 = (ds9.Tables(0).Rows(0).Item(0))

                    If tabadd_measure.click_edit = 1 Then

                        Dim measure_get_id As Integer
                        k = cnt2
                        j = 0
                        While j < k
                            Dim adapter34 As MySqlDataAdapter
                            Dim ds8 As New DataSet


                            'measurements date.
                            measure_date = tabadd_measure.DataGridView4.Rows.Item(j).Cells(0).Value
                            mysql_measure_date = measure_date.Year & "-" & measure_date.Month & "-" & measure_date.Day

                            adapter34 = New MySqlDataAdapter("select measurements_idmeasure from cattle_measurements where cattle_cattle_id='" & cowid & "'", connection)
                            adapter34.Fill(ds8)
                            measure_get_id = (ds8.Tables(0).Rows(j).Item(0))


                            cmd = New MySqlCommand("Update measurements set date='" & mysql_measure_date & "', height=" & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(3).Value) & ",adj_weight=" & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(2).Value) & ",act_weight=" & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(1).Value) & ",pelvic_horizontal=" & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(4).Value) & ",pelvic_vertical=" & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(5).Value) & ",scrotal_circ=" & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(6).Value) & ",adj_scrotal_area=" & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(9).Value) & ",hip_height=" & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(7).Value) & ",muscling=" & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(8).Value) & " where idmeasure=" & measure_get_id, connection)
                            cmd.ExecuteNonQuery()
                            j = j + 1
                        End While
                    Else
                        'generate measure ID
                        adapter1 = New MySqlDataAdapter("select count(*) from measurements", connection)
                        adapter1.Fill(ds1)
                        measureid = ds1.Tables(0).Rows(0).Item(0)
                        measureid = measureid + 1
                        measureid1 = measureid
                        k = tabadd_measure.n + 1
                        j = cnt2
                        While j < k

                            'measurements date.
                            measure_date = tabadd_measure.DataGridView4.Rows.Item(j).Cells(0).Value
                            mysql_measure_date = measure_date.Year & "-" & measure_date.Month & "-" & measure_date.Day
                            cmd = New MySqlCommand("insert into measurements(date,idmeasure,height,adj_weight,act_weight,pelvic_horizontal,pelvic_vertical,scrotal_circ,adj_scrotal_area,hip_height,muscling) values ('" & mysql_measure_date & "'," & measureid & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(3).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(2).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(1).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(4).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(5).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(6).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(9).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(7).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(8).Value) & ")", connection)
                            cmd.ExecuteNonQuery()
                            measureid = measureid + 1
                            j = j + 1
                        End While


                        'cattle_measurements
                        k = tabadd_measure.n + 1
                        j = cnt2
                        While j < k
                            cmd = New MySqlCommand("insert into cattle_measurements(cattle_cattle_id,measurements_idmeasure) values ('" & tabadd_general.TextBox1.Text & "'," & measureid1 & ")", connection)
                            cmd.ExecuteNonQuery()
                            measureid1 = measureid1 + 1
                            j = j + 1
                        End While

                    End If
                End If


                If DataGridView3.RowCount > 1 Then
                    Dim adapter49 As MySqlDataAdapter
                    Dim ds19 As New DataSet


                    adapter49 = New MySqlDataAdapter("select count(*) from cattle_notes where cattle_cattle_id='" & cowid & "'", connection)
                    adapter49.Fill(ds19)
                    cnt2 = (ds19.Tables(0).Rows(0).Item(0))
                    If Me.edit_click = 1 Then

                        Dim notes_get_id As Integer
                        k = cnt2
                        j = 0
                        While j < k
                            Dim adapter34 As MySqlDataAdapter
                            Dim ds8 As New DataSet

                            'notes date.
                            notes_date = DataGridView3.Rows.Item(j).Cells(0).Value
                            mysql_notes_date = notes_date.Year & "-" & notes_date.Month & "-" & notes_date.Day

                            adapter34 = New MySqlDataAdapter("select notes_idnotes from cattle_notes where cattle_cattle_id='" & cowid & "'", connection)
                            adapter34.Fill(ds8)
                            notes_get_id = (ds8.Tables(0).Rows(j).Item(0))

                            cmd = New MySqlCommand("Update notes set date='" & mysql_notes_date & "',comment= '" & DataGridView3.Rows.Item(j).Cells(2).Value & "',category= '" & DataGridView3.Rows.Item(j).Cells(1).Value & "'where idnotes=" & notes_get_id, connection)
                            cmd.ExecuteNonQuery()
                            j = j + 1
                        End While


                    Else
                        'generate notes ID
                        adapter2 = New MySqlDataAdapter("select count(*) from notes", connection)
                        adapter2.Fill(ds2)
                        notesid = ds2.Tables(0).Rows(0).Item(0)
                        notesid = notesid + 1
                        notesid1 = notesid
                        'notes
                        k = Me.n + 1
                        j = cnt2
                        While j < k
                            'generate mysql Date
                            notes_date = DataGridView3.Rows.Item(j).Cells(0).Value
                            mysql_notes_date = notes_date.Year & "-" & notes_date.Month & "-" & notes_date.Day

                            cmd = New MySqlCommand("insert into notes(idnotes,comment,date,category) values (" & notesid & ",'" & DataGridView3.Rows.Item(j).Cells(2).Value & "','" & mysql_notes_date & "','" & DataGridView3.Rows.Item(j).Cells(1).Value & "')", connection)
                            cmd.ExecuteNonQuery()
                            notesid = notesid + 1
                            j = j + 1
                        End While
                        'cattle_notes
                        k = Me.n + 1
                        j = cnt2
                        While j < k
                            cmd = New MySqlCommand("insert into cattle_notes (cattle_cattle_id,notes_idnotes) values ('" & tabadd_general.TextBox1.Text & "'," & notesid1 & ")", connection)
                            cmd.ExecuteNonQuery()
                            notesid1 = notesid1 + 1
                            j = j + 1
                        End While
                    End If

                End If

                'milk

                
                'groups
                'cmd = New MySqlCommand("insert into groups(idgroup,group_name) values (" & Val(tabadd_general.ComboBox11.Text) & ",'" & tabadd_general.TextBox1.Text & "')", connection)
                'cmd.ExecuteNonQuery()

                'cattle_groups
                cmd = New MySqlCommand("update cattle_group set groups_idgroup=" & Val(tabadd_general.ComboBox11.Text) & " where cattle_cattle_id= '" & cowid & "'", connection)
                cmd.ExecuteNonQuery()

                'dairy_cattle
                Dim dairyid As Integer
                Dim ds11 As New DataSet
                adapter11 = New MySqlDataAdapter("select iddairy from dairy where name ='" & tabadd_general.ComboBox2.Text & "'", connection)
                adapter11.Fill(ds11)
                dairyid = ds11.Tables(0).Rows(0).Item(0)

                cmd = New MySqlCommand("update dairy_cattle set dairy_iddairy = " & dairyid & " where cattle_cattle_id = '" & cowid & "'", connection)
                cmd.ExecuteNonQuery()

                'breeder
                cmd = New MySqlCommand("update breeder set person_idperson = " & tabadd_general.ComboBox3.SelectedIndex + 1 & " where cattle_cattle_id ='" & cowid & "'", connection)
                cmd.ExecuteNonQuery()

                'owner
                cmd = New MySqlCommand("update owner set person_idperson= " & tabadd_general.ComboBox4.SelectedIndex + 1 & " where cattle_cattle_id ='" & cowid & "'", connection)
                cmd.ExecuteNonQuery()

                Menu_tiles.newflag = 1
                Dim dec As Integer
                dec = MsgBox("Changes Saved!", MsgBoxStyle.OkOnly, "Save")
                

            Else
                If tabadd_general.RadioButton1.Checked = True Then
                    stat = 1
                Else
                    stat = 2
                End If

                If tabadd_general.CheckBox1.Checked = True Then
                    chkbx = 1
                Else
                    chkbx = 0
                End If
                cattle_dob = tabadd_general.DateTimePicker1.Value
                mysql_dob = cattle_dob.Year & "-" & cattle_dob.Month & "-" & cattle_dob.Day

                'cattle
                cmd = New MySqlCommand("insert into cattle(cattle_id,name,rfid,cow_calf,sire,status,breed,color,horns,raised_purchased,bought_for,sold_for,breed1,breed2,breed3,breed4,insurer,markings,ns_ai_et,dob)values('" & tabadd_general.TextBox1.Text & "','" & tabadd_general.TextBox2.Text & "','" & tabadd_general.TextBox3.Text & "','" & tabadd_general.ComboBox1.Text & "','" & tabadd_general.TextBox4.Text & "','" & tabadd_general.ComboBox7.Text & "','" & tabadd_general.ComboBox5.Text & "','" & tabadd_general.ComboBox6.Text & "','" & tabadd_general.ComboBox8.Text & "'," & stat & "," & Val(tabadd_general.TextBox8.Text) & "," & Val(tabadd_general.TextBox6.Text) & "," & Val(tabadd_breed.TextBox26.Text) & "," & Val(tabadd_breed.TextBox27.Text) & "," & Val(tabadd_breed.TextBox28.Text) & "," & Val(tabadd_breed.TextBox29.Text) & ",'" & tabadd_general.TextBox7.Text & "','" & tabadd_general.ComboBox6.Text & "','" & tabadd_breed.ComboBox10.Text & "','" & mysql_dob & "')", connection) ' "','" & ComboBox1.Text & "','" ' Val(TextBox6.Text) ' ,'" val( TextBox8.Text)  "','" & TextBox1.Text & '")", connection)
                cmd.ExecuteNonQuery()

                'groups
                cmd = New MySqlCommand("insert into groups(idgroup,group_name) values (" & Val(tabadd_general.ComboBox11.Text) & ",'" & tabadd_general.TextBox1.Text & "')", connection)
                'cmd.ExecuteNonQuery()

                'cattle_groups
                cmd = New MySqlCommand("insert into cattle_group(cattle_cattle_id,groups_idgroup) values ('" & tabadd_general.TextBox1.Text & "'," & Val(tabadd_general.ComboBox11.Text) & ")", connection)
                cmd.ExecuteNonQuery()

                'calf/cow
                If tabadd_general.ComboBox1.Text = "Calf" Then
                    cmd = New MySqlCommand("insert into calf(calf_id,feeding_status) values ('" & tabadd_general.TextBox1.Text & "'," & chkbx & ")", connection)
                    cmd.ExecuteNonQuery()
                Else
                    cmd = New MySqlCommand("insert into cow (cow_id,preg_status) values ('" & tabadd_general.TextBox1.Text & "','" & tabadd_breed.ComboBox9.Text & "')", connection)
                    cmd.ExecuteNonQuery()
                End If


                Dim j, k As Integer



                If tabadd_measure.empty_measure = 0 Then
                    'generate measure ID
                    adapter1 = New MySqlDataAdapter("select count(*) from measurements", connection)
                    adapter1.Fill(ds1)
                    measureid = ds1.Tables(0).Rows(0).Item(0)
                    measureid = measureid + 1
                    measureid1 = measureid

                    k = tabadd_measure.n + 1
                    j = 0
                    While j < k

                        'measurements date.
                        measure_date = tabadd_measure.DataGridView4.Rows.Item(j).Cells(0).Value
                        mysql_measure_date = measure_date.Year & "-" & measure_date.Month & "-" & measure_date.Day
                        cmd = New MySqlCommand("insert into measurements(date,idmeasure,height,adj_weight,act_weight,pelvic_horizontal,pelvic_vertical,scrotal_circ,adj_scrotal_area,hip_height,muscling) values ('" & mysql_measure_date & "'," & measureid & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(3).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(2).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(1).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(4).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(5).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(6).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(9).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(7).Value) & "," & Convert.ToDecimal(tabadd_measure.DataGridView4.Rows.Item(j).Cells(8).Value) & ")", connection)
                        cmd.ExecuteNonQuery()
                        measureid = measureid + 1
                        j = j + 1
                    End While

                    'cattle_measurements
                    k = tabadd_measure.n + 1
                    j = 0
                    While j < k
                        cmd = New MySqlCommand("insert into cattle_measurements(cattle_cattle_id,measurements_idmeasure) values ('" & tabadd_general.TextBox1.Text & "'," & measureid1 & ")", connection)
                        cmd.ExecuteNonQuery()
                        measureid1 = measureid1 + 1
                        j = j + 1
                    End While
                End If

                If tabadd_medi.empty_medi = 0 Then
                    'generate medical id
                    adapter = New MySqlDataAdapter("select count(*) from medical", connection)
                    adapter.Fill(ds)
                    medid = ds.Tables(0).Rows(0).Item(0)
                    medid = medid + 1
                    medid1 = medid

                    k = tabadd_medi.n + 1
                    j = 0
                    While j < k
                        ''generate start and stop date according to mysql
                        start_date = tabadd_medi.DataGridView2.Rows.Item(j).Cells(3).Value
                        mysql_start_date = start_date.Year & "-" & start_date.Month & "-" & start_date.Day

                        stop_date = tabadd_medi.DataGridView2.Rows.Item(j).Cells(4).Value
                        mysql_stop_date = stop_date.Year & "-" & stop_date.Month & "-" & stop_date.Day

                        cmd = New MySqlCommand("insert into medical(idmedical,days_to_treat,dump_days,medications,performed_by,start_date,stop_date,ailment,comments) values (" & medid & "," & tabadd_medi.DataGridView2.Rows.Item(j).Cells(5).Value & ",'" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(6).Value & "','" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(2).Value & "','" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(1).Value & "','" & mysql_start_date & "','" & mysql_stop_date & "','" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(0).Value & "','" & tabadd_medi.DataGridView2.Rows.Item(j).Cells(7).Value & "')", connection)
                        cmd.ExecuteNonQuery()
                        medid = medid + 1
                        j = j + 1
                    End While

                    'cattle_medical
                    k = tabadd_medi.n + 1
                    j = 0
                    While j < k
                        cmd = New MySqlCommand("insert into cattle_medical(cattle_cattle_id,medical_idmedical) values ('" & tabadd_general.TextBox1.Text & "'," & medid1 & ")", connection)
                        cmd.ExecuteNonQuery()
                        medid1 = medid1 + 1
                        j = j + 1
                    End While

                End If

                If DataGridView3.RowCount > 1 Then
                    'generate notes ID

                    adapter2 = New MySqlDataAdapter("select count(*) from notes", connection)
                    adapter2.Fill(ds2)
                    notesid = ds2.Tables(0).Rows(0).Item(0)
                    notesid = notesid + 1
                    notesid1 = notesid

                    'notes
                    k = n + 1
                    j = 0
                    While j < k
                        'generate mysql Date
                        notes_date = DataGridView3.Rows.Item(j).Cells(0).Value
                        mysql_notes_date = notes_date.Year & "-" & notes_date.Month & "-" & notes_date.Day

                        cmd = New MySqlCommand("insert into notes(idnotes,comment,date,category) values (" & notesid & ",'" & DataGridView3.Rows.Item(j).Cells(2).Value & "','" & mysql_notes_date & "','" & DataGridView3.Rows.Item(j).Cells(1).Value & "')", connection)
                        cmd.ExecuteNonQuery()
                        notesid = notesid + 1
                        j = j + 1
                    End While

                    'cattle_notes
                    k = n + 1
                    j = 0
                    While j < k
                        cmd = New MySqlCommand("insert into cattle_notes (cattle_cattle_id,notes_idnotes) values ('" & tabadd_general.TextBox1.Text & "'," & notesid1 & ")", connection)
                        cmd.ExecuteNonQuery()
                        notesid1 = notesid1 + 1
                        j = j + 1
                    End While
                End If


                'generate breeding ID
                adapter3 = New MySqlDataAdapter("select count(*) from breeding", connection)
                adapter3.Fill(ds3)
                breedingid = ds3.Tables(0).Rows(0).Item(0)
                breedingid = breedingid + 1

                'generate breeding dates
                calving_date = tabadd_breed.DateTimePicker4.Value
                mysql_calving_date = calving_date.Year & "-" & calving_date.Month & "-" & calving_date.Day

                palp_date = tabadd_breed.DateTimePicker2.Value
                mysql_palp_date = palp_date.Year & "-" & palp_date.Month & "-" & palp_date.Day

                insem_date = tabadd_breed.DateTimePicker3.Value
                mysql_insem_date = insem_date.Year & "-" & insem_date.Month & "-" & insem_date.Day

                If tabadd_breed.ComboBox9.Text <> "Not Exposed" Then
                    'breeding
                    cmd = New MySqlCommand("insert into breeding(idbreeding,calving_date,preg_check_date,insemination_date,comment,bred_to,ns_ai) values (" & breedingid & ",'" & mysql_calving_date & "','" & mysql_palp_date & "','" & mysql_insem_date & "','" & tabadd_breed.TextBox1.Text & "','" & tabadd_breed.TextBox7.Text & "','" & tabadd_breed.ComboBox10.Text & "' )", connection)
                    cmd.ExecuteNonQuery()

                    ''cow_breeding
                    cmd = New MySqlCommand("insert into cow_breeding(cow_cow_id,breeding_idbreeding) values ('" & tabadd_general.TextBox1.Text & "'," & breedingid & ")", connection)
                    cmd.ExecuteNonQuery()
                End If

                'dam
                cmd = New MySqlCommand("insert into dam(cattle_cattle_id,cattle_cattle_id1) values ('" & tabadd_general.TextBox1.Text & "','" & tabadd_general.TextBox5.Text & "')", connection)
                cmd.ExecuteNonQuery()

                'dairy_cattle
                Dim dairyid As Integer
                Dim ds11 As New DataSet
                adapter11 = New MySqlDataAdapter("select iddairy from dairy where name='" & tabadd_general.ComboBox2.Text & "'", connection)
                adapter11.Fill(ds11)
                dairyid = ds11.Tables(0).Rows(0).Item(0)

                cmd = New MySqlCommand("insert into dairy_cattle (cattle_cattle_id,dairy_iddairy) values ('" & tabadd_general.TextBox1.Text & "'," & dairyid & ")", connection)
                cmd.ExecuteNonQuery()

                'breeder
                cmd = New MySqlCommand("insert into breeder (cattle_cattle_id,person_idperson) values ('" & tabadd_general.TextBox1.Text & "'," & tabadd_general.ComboBox3.SelectedIndex + 1 & ")", connection)
                cmd.ExecuteNonQuery()

                'owner
                cmd = New MySqlCommand("insert into owner (cattle_cattle_id,person_idperson) values ('" & tabadd_general.TextBox1.Text & "'," & tabadd_general.ComboBox4.SelectedIndex + 1 & ")", connection)
                cmd.ExecuteNonQuery()

                MsgBox("Successfully Entered!")

            End If

            
            tabadd_breed.Close()
            tabadd_general.Close()
            tabadd_sessions.Close()
            tabadd_medi.Close()
            tabadd_measure.Close()
            Close()
            


            connection.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        
    End Sub
End Class