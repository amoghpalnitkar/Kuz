Imports System.Drawing
Imports System.Data.SqlClient
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.IO
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office.Interop
Imports System
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security.Permissions




Public Class Home1
    Dim cntw As Integer
    Dim WithEvents cowidbinding As Binding
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3 As New DataSet
    Dim cnn As MySqlConnection

    Dim adapter, adapter11, adapter12, adapter13, adp1, adp2, adp3 As MySqlDataAdapter
    Dim query1, query2, query3, query4, query5, query6 As String
    Dim connstring As String
    Dim cmdBuilder As MySqlCommandBuilder
    Dim changes As DataSet
    Dim flag1 As Integer
    Dim cattles, group, cow, groups As New DataSet

    Dim MyConnection As System.Data.OleDb.OleDbConnection
    Dim ExcelDataSet As System.Data.DataSet
    Dim ExcelAdapter As System.Data.OleDb.OleDbDataAdapter

    Dim get_cattles As String
    Dim get_cow As String
    Dim get_groups As String
    Public xlapp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application



    Private Sub Home1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cntw = 0
        flag1 = 0
        'TODO: This line of code loads data into the 'MydbDataSet.milk_sessions' table. You can move, or remove it, as needed.
        ' Me.Milk_sessionsTableAdapter.Fill(Me.MydbDataSet.milk_sessions)
        Dim f2 As New Attenlist
        f2.Visible = True
        f2.TopMost = True

        Button7.Visible = False
        Button8.Visible = False
        TabControl3.Visible = True


        Label21.Text = Date.Now.ToString("MMM")
        Label22.Text = Date.Now.ToString("dd")

        Dim dt As Date
        Dim yesterdayDate As Date
        yesterdayDate = Date.Now.AddDays(-1)
        '  MsgBox(yesterdayDate.ToString("yyyy/MM/dd"))
        dt.ToString("yyyy/MM/dd")
        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=anuj123"

        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        Try
            connection.Open()
            adapter = New MySqlDataAdapter(" select sum(s.total) from sessions s,milk_sessions m where m.session_id=s.session_id and m.dt='" + dt.ToString("yyyy/MM/dd") + "'", connection)

            ' MsgBox(dt.ToString("yyyy/MM/dd"))
            connection.Close()
            adapter.Fill(ds)
            adapter.Dispose()
            Label13.Text = Str(ds.Tables(0).Rows(0).Item(0))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Try
            connection.Open()
            adapter = New MySqlDataAdapter(" select sum(s.total) from sessions s,milk_sessions m where m.session_id=s.session_id and m.dt='" + yesterdayDate.ToString("yyyy/MM/dd") + "'", connection)

            ' MsgBox(dt.ToString("yyyy/MM/dd"))
            connection.Close()
            adapter.Fill(ds)
            adapter.Dispose()
            Label14.Text = Str(ds.Tables(0).Rows(0).Item(0))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'contacts
        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=anuj123"
        query1 = "select * from person"
        query2 = "select *from dairy"
        query3 = "select * from places"

        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        Try
            connection.Open()
            adapter11 = New MySqlDataAdapter(query1, connection)
            adapter12 = New MySqlDataAdapter(query2, connection)
            adapter13 = New MySqlDataAdapter(query3, connection)
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        adapter11.Fill(ds1) 'person
        adapter12.Fill(ds2) 'dairy
        adapter13.Fill(ds3) 'places

        DataGridView1.Refresh()
        DataGridView1.RefreshEdit()
        DataGridView1.DataSource = ds1.Tables(0)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.Columns(1).HeaderText = "Last Name"
        DataGridView1.Columns(2).HeaderText = "First Name"
        DataGridView1.Columns(3).HeaderText = "Number"
        DataGridView1.Columns(4).HeaderText = "Address"
        DataGridView1.Columns(5).HeaderText = "Membership Id"


        DataGridView2.Refresh()
        DataGridView2.RefreshEdit()
        DataGridView2.DataSource = ds2.Tables(0)
        DataGridView2.Columns(0).Visible = False
        DataGridView2.Columns(1).HeaderText = "Name"
        DataGridView2.Columns(2).HeaderText = "Address"
        DataGridView2.Columns(3).HeaderText = "Number"

        DataGridView3.Refresh()
        DataGridView3.RefreshEdit()
        DataGridView3.DataSource = ds3.Tables(0)
        DataGridView3.Columns(0).Visible = False
        DataGridView3.Columns(1).HeaderText = "Type"
        DataGridView3.Columns(2).HeaderText = "Address"


        DataGridView1.ReadOnly = True
        DataGridView2.ReadOnly = True
        DataGridView3.ReadOnly = True
        Button21.Enabled = False
        Button22.Enabled = False
        Button23.Enabled = False
        Dim cnt1, cnt2, act1, act2 As New DataSet
        Dim adp4 As MySqlDataAdapter
        Dim count1 As String
        Dim count2 As String
        Dim active1 As String
        Dim active2 As String
        count1 = "select count(cattle_id) from cattle where cow_calf='Cow'"
        count2 = "select count(cattle_id) from cattle where cow_calf='Calf'"
        active1 = "select count(cattle_id) from cattle where cow_calf='Cow' AND status='Active'"
        active2 = "select count(cattle_id) from cattle where cow_calf='Calf' AND status='Active'"
        Try
            connection.Open()
            adp4 = New MySqlDataAdapter(count1, connection)
            adp3 = New MySqlDataAdapter(count2, connection)

            connection.Close()
            adp4.Fill(cnt1)
            adp3.Fill(cnt2)

            Label8.Text = Str(cnt1.Tables(0).Rows(0).Item(0))
            Label5.Text = Str(cnt2.Tables(0).Rows(0).Item(0))


        Catch ex As Exception

        End Try
        Try
            connection.Open()
            adp1 = New MySqlDataAdapter(active1, connection)
            adp2 = New MySqlDataAdapter(active2, connection)
            connection.Close()
            adp2.Fill(act2)
            adp1.Fill(act1)
            Label6.Text = Str(act2.Tables(0).Rows(0).Item(0)) ''
            Label7.Text = Str(act1.Tables(0).Rows(0).Item(0))

        Catch ex As Exception

        End Try

        'chart
        get_cattles = "select cattle_id from cattle"

        get_groups = "select idgroup from groups"
        connection.Open()
        adapter = New MySqlDataAdapter(get_cattles, connection)
        adapter11 = New MySqlDataAdapter(get_groups, connection)
        connection.Close()
        adapter.Fill(cattles)
        adapter11.Fill(groups)
        ComboBox4.DataSource = cattles.Tables(0)
        ComboBox4.ValueMember = "cattle_id"


        ComboBox2.DataSource = groups.Tables(0)
        ComboBox2.ValueMember = "idgroup"
        ComboBox1.DataSource = groups.Tables(0)
        ComboBox1.ValueMember = "idgroup"
      
        Dim durat(3) As String

        'durat(0) = "7 Days"
        'durat(1) = "30 Days"
        'durat(2) = "Month"
        'durat(3) = "Year"
        'ComboBox6.Enabled = False
        'ComboBox3.Items.Clear()
        'ComboBox3.Items.AddRange(durat)
        'tables

        ListBox2.Visible = False


        TabControl3.Controls.Remove(TabControl3.TabPages(1))
        TabControl3.Controls.Remove(TabControl3.TabPages(1))
        TabControl3.Controls.Remove(TabControl3.TabPages(1))
        TabControl3.Controls.Remove(TabControl3.TabPages(1))
        TabControl1.Controls.Remove(TabControl1.TabPages(0))

    End Sub

    Private Sub Button7_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.MouseHover
        ToolTip1.SetToolTip(Button7, "Remove cowcard")
    End Sub
    Private Sub Button1_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.MouseHover
        ToolTip1.SetToolTip(Button1, "New file")
    End Sub

    Private Sub Button2_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.MouseHover
        ToolTip1.SetToolTip(Button2, "Open file")
    End Sub

    Private Sub Button3_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.MouseHover
        ToolTip1.SetToolTip(Button3, "Save file")
    End Sub

    Private Sub Button4_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.MouseHover
        ToolTip1.SetToolTip(Button4, "Delete  file")
    End Sub

    Private Sub Button5_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.MouseHover
        ToolTip1.SetToolTip(Button5, "Print")
    End Sub

    Private Sub Button14_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.MouseHover
        ToolTip1.SetToolTip(Button14, "Exit")
    End Sub

    Private Sub Button6_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.MouseHover
        ToolTip1.SetToolTip(Button6, "Edit Cowcard")
    End Sub

    Private Sub Button8_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.MouseHover
        ToolTip1.SetToolTip(Button8, "Import data  from Excel")
    End Sub

    Private Sub Button9_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.MouseHover
        ToolTip1.SetToolTip(Button9, "Export data into Excel format")
    End Sub

    


    Private Sub Button13_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.MouseHover
        ToolTip1.SetToolTip(Button13, "About Us")
    End Sub

    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        'dairies update
        Try
            cmdBuilder = New MySqlCommandBuilder(adapter12)
            changes = ds2.GetChanges()
            If changes IsNot Nothing Then
                adapter12.Update(changes)
            End If
            MsgBox("Changes Done")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Button21.Enabled = False
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        'places update
        Try
            cmdBuilder = New MySqlCommandBuilder(adapter13)
            changes = ds3.GetChanges()
            If changes IsNot Nothing Then
                adapter13.Update(changes)
            End If
            MsgBox("Changes Done")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Button22.Enabled = False
    End Sub


    Private Sub Button23_Click(sender As System.Object, e As System.EventArgs) Handles Button23.Click
        'people update
        Try
            cmdBuilder = New MySqlCommandBuilder(adapter11)
            changes = ds1.GetChanges()
            If changes IsNot Nothing Then
                adapter11.Update(changes)
            End If
            MsgBox("Changes Done")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Button23.Enabled = False
    End Sub


    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        Me.Close()
    End Sub


    Private Sub Button24_Click(sender As System.Object, e As System.EventArgs) Handles Button24.Click
        'dairy edit

        DataGridView2.ReadOnly = False
        Button21.Enabled = True

    End Sub

    Private Sub Button25_Click(sender As System.Object, e As System.EventArgs) Handles Button25.Click
        'places edit

        DataGridView3.ReadOnly = False
        Button22.Enabled = True
    End Sub

    Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles Button27.Click
        'breeding parameters

        Dim f As New Form1
        f.Visible = True
        f.TopMost = True

    End Sub
    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        'contacts
        If TabControl3.TabPages.Contains(TabPage9) = False Then
            TabControl3.Controls.Add(TabPage9)
        End If
        TabControl3.SelectedTab = TabPage9
    End Sub

    Private Sub Button28_Click(sender As System.Object, e As System.EventArgs) Handles Button28.Click
        'close tab
        Dim i As Integer
        i = TabControl3.SelectedIndex
        If i <> 0 Then
            TabControl3.Controls.Remove(TabControl3.TabPages(i))
        End If
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        'lactations
        If TabControl3.TabPages.Contains(TabPage11) = False Then
            TabControl3.Controls.Add(TabPage11)
        End If
        TabControl3.SelectedTab = TabPage11
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        'table
        If TabControl3.TabPages.Contains(TabPage10) = False Then
            TabControl3.Controls.Add(TabPage10)
        End If
        TabControl3.SelectedTab = TabPage10

    End Sub

    Private Sub Button31_Click(sender As System.Object, e As System.EventArgs) Handles Button31.Click
        'milk production
        If TabControl3.TabPages.Contains(TabPage12) = False Then
            TabControl3.Controls.Add(TabPage12)
        End If
        TabControl3.SelectedTab = TabPage12
    End Sub

    

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        'home button
        TabControl3.SelectedTab = TabPage8
    End Sub



    Private Sub ComboBox3_SelectedValueChanged(sender As Object, e As System.EventArgs)
        '    If ComboBox3.SelectedItem = "Month" Then
        '        '  ComboBox6.Enabled = True
        '        Dim mnth(11) As String
        '        mnth(0) = "Jan"
        '        mnth(1) = "Feb"
        '        mnth(2) = "Mar"
        '        mnth(3) = "Apr"
        '        mnth(4) = "May"
        '        mnth(5) = "Jun"
        '        mnth(6) = "Jul"
        '        mnth(7) = "Aug"
        '        mnth(8) = "Sep"
        '        mnth(9) = "Oct"
        '        mnth(10) = "Nov"
        '        mnth(11) = "Dec"
        '        '   ComboBox6.Items.Clear()
        '        '  ComboBox6.Items.AddRange(mnth)

        '    End If
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs)
        get_cow = "select cow_id from cow"
        connection.Open()
        adapter11 = New MySqlDataAdapter(get_cow, connection)
        connection.Close()
        adapter11.Fill(cow)

    End Sub

    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs)
        get_cow = "select cow_id from cow"
        connection.Open()
        adapter11 = New MySqlDataAdapter(get_cow, connection)
        connection.Close()
        adapter11.Fill(cow)


    End Sub


    Private Sub ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        Dim lact As New DataSet
        Dim la As String
        'Chart1.Dispose()

        la = " Select milk_idmilk from cow_milk,milk where cow_cow_id='" + ComboBox4.Text + "'and milk_idmilk=idmilk"
        connection.Open()
        adapter = New MySqlDataAdapter(la, connection)
        connection.Close()
        adapter.Fill(lact)
        ListBox2.DataSource = lact.Tables(0)
        ListBox2.ValueMember = "milk_idmilk"
        Dim a As Integer
        Try
            a = lact.Tables(0).Rows.Count
        Catch ex As Exception

        End Try
        ListBox3.Items.Clear()

        For tem As Integer = 1 To a
            ListBox3.Items.Add(tem)
        Next


        
    End Sub



    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        'about us
        MsgBox("Kuz Cattle Management" & Chr(10) & Chr(13) & "Developed by : " & Chr(10) & Chr(13) & "Amogh Palnitkar" & Chr(10) & Chr(13) & "Anuj Deshpande" & Chr(10) & Chr(13) & "Sayali Lunkad" & Chr(10) & Chr(13) & "Sphoorti Joglekar" & Chr(10) & Chr(13) & "Vishakha Damle")

    End Sub


    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click

       Dim ds As New DataSet
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As New Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim sd1 As New SaveFileDialog

        Dim i As Integer
        Dim j As Integer
        Dim fname As String

        xlapp = New Microsoft.Office.Interop.Excel.Application

        xlWorkBook = xlapp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        If TabControl3.SelectedTab Is TabPage9 Then

            If TabControl4.SelectedTab Is TabPage14 Then
                fname = "person"
                'xlWorkBook = xlapp.Workbooks.Add(misValue)
                ''xlWorkBook = xlapp.Workbooks.Add(misValue)
                'xlWorkSheet = xlWorkBook.Sheets("sheet1")


                For i = 0 To DataGridView1.RowCount - 2
                    For j = 0 To DataGridView1.ColumnCount - 1
                        xlWorkSheet.Cells(1, j + 1) = DataGridView1.Columns.Item(j).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = _
                          DataGridView1(j, i).Value.ToString()
                        xlWorkSheet.Columns.AutoFit()
                    Next
                Next
                If sd1.ShowDialog = Windows.Forms.DialogResult.OK Then

                    xlWorkBook.SaveAs(sd1.FileName & ".xlsx")
                    xlWorkBook.Close(True, misValue, misValue)
                    xlapp.Quit()

                End If


            ElseIf TabControl4.SelectedTab Is TabPage15 Then
                fname = "places"
                'xlWorkBook = xlapp.Workbooks.Add(misValue)
                ''xlWorkBook = xlapp.Workbooks.Add(misValue)
                'xlWorkSheet = xlWorkBook.Sheets("sheet1")

                For i = 0 To DataGridView3.RowCount - 2
                    For j = 0 To DataGridView3.ColumnCount - 1
                        xlWorkSheet.Cells(1, j + 1) = DataGridView3.Columns.Item(j).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = _
                          DataGridView3(j, i).Value.ToString()
                        xlWorkSheet.Columns.AutoFit()
                    Next
                Next

                If sd1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'xlWorkSheet.SaveAs(sd1.FileName & ".xlsx")
                    xlWorkBook.SaveAs(sd1.FileName & ".xlsx")
                    xlWorkBook.Close(True, misValue, misValue)
                    xlapp.Quit()

                End If
            ElseIf TabControl4.SelectedTab Is TabPage16 Then
                fname = "dairy"
                'xlWorkBook = xlapp.Workbooks.Add(misValue)
                'xlWorkBook = xlapp.Workbooks.Add(misValue)
                'xlWorkSheet = xlWorkBook.Sheets("sheet1")

                For i = 0 To DataGridView2.RowCount - 2
                    For j = 0 To DataGridView2.ColumnCount - 1
                        xlWorkSheet.Cells(1, j + 1) = DataGridView2.Columns.Item(j).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = _
                          DataGridView2(j, i).Value.ToString()
                        xlWorkSheet.Columns.AutoFit()
                    Next
                Next

                If sd1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    'xlWorkSheet.SaveAs(sd1.FileName & ".xlsx")
                    xlWorkBook.SaveAs(sd1.FileName & ".xlsx")
                    xlWorkBook.Close(True, misValue, misValue)
                    xlapp.Quit()

                End If


            End If


        ElseIf TabControl3.SelectedTab Is TabPage10 Then

            'Dim xlApp As Excel.Application

            'xlApp = New Excel.ApplicationClass

            Dim cnt As Integer


            For i = 0 To DataGridView4.RowCount - 2
                cnt = 0
                For j = 0 To DataGridView4.ColumnCount - 1
                    If DataGridView4.Columns(j).Visible = True Then
                        cnt = cnt + 1
                        xlWorkSheet.Cells(1, cnt) = DataGridView4.Columns.Item(j).HeaderText
                        xlWorkSheet.Cells(i + 2, cnt) = _
                          DataGridView4(j, i).Value.ToString()
                        xlWorkSheet.Columns.AutoFit()
                    End If

                Next
            Next
            If sd1.ShowDialog = Windows.Forms.DialogResult.OK Then
                'xlWorkSheet.SaveAs(sd1.FileName & ".xlsx")
                xlWorkBook.SaveAs(sd1.FileName & ".xlsx")
                xlWorkBook.Close(True, misValue, misValue)
                xlapp.Quit()


            End If



        End If


        releaseObject(xlapp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlapp)
        xlapp = Nothing


        'GC.Collect()
        'GC.WaitForPendingFinalizers()
        'GC.Collect()
        'GC.WaitForPendingFinalizers()

    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


    Private Sub Button18_Click(sender As System.Object, e As System.EventArgs) Handles Button18.Click
        'people edit

        DataGridView1.ReadOnly = False
        Button23.Enabled = True
    End Sub

    Private Sub TreeView1_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles TreeView1.ItemDrag
        DoDragDrop(TreeView1.SelectedNode.Text, Forms.DragDropEffects.Copy)
    End Sub

    Private Sub DataGridView4_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles DataGridView4.DragEnter
        e.Effect = Forms.DragDropEffects.Copy

    End Sub
    Private Sub DataGridView4_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles DataGridView4.DragDrop
        Dim anuj As String
        TextBox2.Text = DirectCast(e.Data.GetData(GetType(String)), String)
        anuj = DirectCast(e.Data.GetData(GetType(String)), String)
        Dim i As Integer
        i = DataGridView4.Columns.Count

        ' MsgBox("value of i is : " + Str(i))


        For j As Integer = 1 To 20
            If e.Data.GetData(GetType(String)) = DataGridView4.Columns(j).HeaderText Then
                If j <> 9 Then
                    DataGridView4.Columns(j).Visible = True
                End If
            End If
        Next
        '  DataGridView4.Columns(1).HeaderText = DirectCast(e.Data.GetData(GetType(String)), String)



    End Sub




    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        'fetch data in tables
        Dim s As String
        Dim ta As New DataSet
        ' s = "select cattle_id,rfid,name from cattle,cattle_group where groups_idgroup=" + ComboBox1.Text + " and cattle_id=cattle_cattle_id ;"

        s = "select *from cattle,cattle_group where groups_idgroup='" + ComboBox1.Text + "';"


        adapter.Dispose()
        connection.Open()
        adapter = New MySqlDataAdapter(s, connection)
        connection.Close()
        Try
            adapter.Fill(ta)
            adapter.Dispose()

            DataGridView4.Refresh()
            DataGridView4.DataSource = ta.Tables(0)

            DataGridView4.Columns(1).HeaderText = "rfid"
            DataGridView4.Columns(2).HeaderText = "name"
            DataGridView4.Columns(3).HeaderText = "breed"
            DataGridView4.Columns(4).HeaderText = "dob"
            DataGridView4.Columns(5).HeaderText = "status"
            DataGridView4.Columns(6).HeaderText = "color"
            DataGridView4.Columns(7).HeaderText = "markings"
            DataGridView4.Columns(8).HeaderText = "raised_purchased"
            DataGridView4.Columns(10).HeaderText = "breed1"
            DataGridView4.Columns(11).HeaderText = "breed2"
            DataGridView4.Columns(12).HeaderText = "breed3"
            DataGridView4.Columns(13).HeaderText = "breed4"
            DataGridView4.Columns(14).HeaderText = "horns"
            DataGridView4.Columns(15).HeaderText = "ns_ai_et"
            DataGridView4.Columns(16).HeaderText = "bought_for"
            DataGridView4.Columns(17).HeaderText = "sold_for"
            DataGridView4.Columns(18).HeaderText = "sire"
            DataGridView4.Columns(19).HeaderText = "cow_calf"
            DataGridView4.Columns(20).HeaderText = "insurer"



            For cnt As Integer = 1 To ta.Tables(0).Columns.Count - 1

                DataGridView4.Columns(cnt).Visible = False
            Next

        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim milkpro As String
        Dim flag As Integer
        Dim dw As String
        dw = "Milk Production"
        flag = 0

        milkpro = "select ms.dt,sum(s.total) from sessions s ,milk_sessions ms where ms.session_id=s.session_id and s.session_id in (select ss.session_id from sessions ss, milk_sessions mss, cow_milk cm, cattle_group cg where cg.groups_idgroup='" + ComboBox2.Text + "' and cm.cow_cow_id=cg.cattle_cattle_id and mss.milk_idmilk=cm.milk_idmilk and mss.session_id=ss.session_id)group by ms.dt "


        Dim dsm As DataSet
        connection.Open()
        adapter = New MySqlDataAdapter(milkpro, connection)
        connection.Close()
        dsm = New DataSet
        adapter.Fill(dsm)
        adapter.Dispose()
        Dim dsmt As New DataTable

        Try
            Chart2.Series.Remove(Chart2.Series(dw))
        Catch ex As Exception
        End Try
        dsmt.Columns.Add("Day")
        dsmt.Columns.Add("Total")

        For i As Integer = 0 To dsm.Tables(0).Rows.Count - 1
            dsmt.Rows.Add(i, dsm.Tables(0).Rows(i).Item(1))

        Next
        Chart2.DataSource = dsmt
        Chart2.Series.Add(dw)
        Chart2.Series(dw).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart2.Series(dw).XValueMember = "Day"
        Chart2.Series(dw).YValueMembers = "Total"
    End Sub

    Private Sub ListBox2_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ListBox2.SelectedValueChanged
        Dim sa As New DataSet
        Dim str As String
        Dim lact As String
        str = "select ms.dt,s.total from sessions s, milk_sessions ms, milk m where m.idmilk = '" + ListBox2.Text + "' and m.idmilk=ms.milk_idmilk and ms.session_id=s.session_id order by ms.dt"
        connection.Open()
        adapter = New MySqlDataAdapter(str, connection)
        connection.Close()
        adapter.Fill(sa)
        adapter.Dispose()
        lact = "Lactation"
        Dim sat As New DataTable

        Try
            Chart1.Series.Remove(Chart1.Series(lact))
        Catch ex As Exception
        End Try
        sat.Columns.Add("Date")
        sat.Columns.Add("Total")

        For i As Integer = 0 To sa.Tables(0).Rows.Count - 1
            sat.Rows.Add(i, sa.Tables(0).Rows(i).Item(1))

        Next
        Chart1.DataSource = sat
        Chart1.Series.Add(lact)
        Chart1.Series(lact).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series(lact).XValueMember = "Date"
        Chart1.Series(lact).YValueMembers = "Total"

    End Sub

    
    Private Sub ListBox3_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ListBox3.SelectedValueChanged
        Dim k As Integer

        k = Val(ListBox3.SelectedIndex)

        ListBox2.SelectedIndex() = k

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; " + _
                               "Data Source=F:/milk.xlsx;Extended Properties=Excel 12.0;")
        Try
            ExcelAdapter = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
            ExcelAdapter.TableMappings.Add("Table", "Excel Data")
            ExcelDataSet = New System.Data.DataSet
            ExcelAdapter.Fill(ExcelDataSet)
            DataGridView4.DataSource = ExcelDataSet.Tables(0)
            MyConnection.Close()
        Catch ex As Exception
            ' MsgBox.Show("Error: " + ex.ToString, "Importing Excel", _
            ' MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Label19_Click(sender As System.Object, e As System.EventArgs)
        'Dim fa As New Menu_tiles
        'fa.Visible = True
        ' Menu_tiles.Show()

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Menu_tiles.Show()
    End Sub

    Private Sub TabPage15_Click(sender As System.Object, e As System.EventArgs) Handles TabPage15.Click

    End Sub

    Private Sub Label8_Click(sender As System.Object, e As System.EventArgs) Handles Label8.Click

    End Sub

  
    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        Menu_tiles.Show()
    End Sub

    Private Sub DataGridView4_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellContentClick

    End Sub
End Class



