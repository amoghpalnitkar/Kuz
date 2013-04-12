Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Attenlist

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim connection As MySqlConnection
        Dim ds1, ds2, ds3, ds4, ds5, ds6, ds7 As New DataSet
        Dim adapter1, adapter2, adapter3, adapter4, adapter5, adapter6, adapter7 As MySqlDataAdapter
        Dim query1, query2, query3, query4, query5, query6, query7 As String

        Dim connstring As String

        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=anuj123"
        Dim yday As Date
        yday = Today.Date.AddDays(-1)

        'query1 = "select cow_cow_id from cow_breeding c, breeding b where c.breeding_idbreeding=b.idbreeding and b.preg_check_dateq='2012-09-21'"
        query1 = "select cow_cow_id from cow_breeding c, breeding b where c.breeding_idbreeding=b.idbreeding and b.preg_check_date='" + Today.Date.ToString("yyyy-MM-dd") + "'"
        query2 = "select c.cow_cow_id from cow_breeding c, breeding b where c.breeding_idbreeding=b.idbreeding and b.first_heat='" + Today.Date.ToString("yyyy-MM-dd") + "'"
        query3 = "select cow_cow_id from cow_milk c,milk_sessions ms,milk m,sessions s where c.milk_idmilk=m.idmilk and ms.milk_idmilk=m.idmilk and ms.session_id=s.session_id  and ms.dt='" + yday.ToString("yyyy-MM-dd") + "' and s.total<=0.8*m.avg_daily"
        query4 = "select cow_cow_id from cow_milk c,milk_sessions ms,milk m,sessions s where c.milk_idmilk=m.idmilk and ms.milk_idmilk=m.idmilk and ms.session_id=s.session_id  and ms.dt='" + yday.ToString("yyyy-MM-dd") + "' and s.total>=1.25*m.avg_daily"
        query5 = "select cow_cow_id from cow_breeding c, breeding b where c.breeding_idbreeding=b.idbreeding and b.calving_date='" + Today.Date.ToString("yyyy-MM-dd") + "'"
        query6 = "select c.cow_cow_id from cow_breeding c, breeding b where c.breeding_idbreeding=b.idbreeding and b.steamup='" + Today.Date.ToString("yyyy-MM-dd") + "'"
        query7 = "select c.cow_cow_id from cow_breeding c, breeding b where c.breeding_idbreeding=b.idbreeding and b.insemination_date='" + Today.Date.ToString("yyyy-MM-dd") + "'"

        connection = New MySqlConnection(My.Settings.mydbConnectionString)
        Try
            connection.Open()
            adapter1 = New MySqlDataAdapter(query1, connection)
            adapter2 = New MySqlDataAdapter(query2, connection)
            adapter3 = New MySqlDataAdapter(query3, connection)
            adapter4 = New MySqlDataAdapter(query4, connection)
            adapter5 = New MySqlDataAdapter(query5, connection)
            adapter6 = New MySqlDataAdapter(query6, connection)
            adapter7 = New MySqlDataAdapter(query7, connection)
            connection.Close()

            adapter1.Fill(ds1)

            ListBox1.DataSource = ds1.Tables(0)
            ListBox1.ValueMember = "cow_cow_id"

            adapter2.Fill(ds2)

            ListBox2.DataSource = ds2.Tables(0)
            ListBox2.ValueMember = "cow_cow_id"

            adapter3.Fill(ds3)

            ListBox3.DataSource = ds3.Tables(0)
            ListBox3.ValueMember = "cow_cow_id"

            adapter4.Fill(ds4)

            ListBox4.DataSource = ds4.Tables(0)
            ListBox4.ValueMember = "cow_cow_id"

            adapter5.Fill(ds5)

            ListBox5.DataSource = ds5.Tables(0)
            ListBox5.ValueMember = "cow_cow_id"

            adapter6.Fill(ds6)

            ListBox6.DataSource = ds6.Tables(0)
            ListBox6.ValueMember = "cow_cow_id"
            adapter7.Fill(ds7)

            ListBox7.DataSource = ds7.Tables(0)
            ListBox7.ValueMember = "cow_cow_id"

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'close button
        Me.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class