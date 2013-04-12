Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.IO
Public Class Contacts
    Dim connection As MySqlConnection
    Dim ds1, ds2, ds3 As New DataSet
    Dim adapter1, adapter2, adapter3 As MySqlDataAdapter
    Dim query1, query2, query3 As String
    Dim connstring As String

    Private Sub periperals_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        

        connstring = "Data Source=localhost; Initial Catalog=mydb; User ID=root; Password=anuj123"
        query1 = "select * from person"
        query2 = "select * from dairy"
        query3 = "select * from places"

        connection = New MySqlConnection(connstring)
        Try
            connection.Open()
            adapter1 = New MySqlDataAdapter(query1, connection)
            adapter2 = New MySqlDataAdapter(query2, connection)
            adapter3 = New MySqlDataAdapter(query3, connection)
            connection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        adapter1.Fill(ds1)
        DataGridView1.Refresh()
        DataGridView1.DataSource = ds1.Tables(0)
        DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.False


        adapter2.Fill(ds2)
        adapter3.Fill(ds3)
    End Sub
End Class