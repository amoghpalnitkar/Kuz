Imports System.Data
Imports System.IO
Imports MySql.Data.MySqlClient




Public Class Menu_tiles

    Public cowid As String
    Public newflag As Integer
    Dim txt As String
    Dim connection As MySqlConnection
    Dim ds, ds1, ds2, ds3 As New DataSet
    Dim adapter, adapter11, adapter12, adapter13, adp1, adp2, adp3 As MySqlDataAdapter
    Dim query1, query2, query3, query4, query5, query6 As String
    Dim connstring As String
    Dim cmdBuilder As MySqlCommandBuilder
    Dim changes As DataSet
    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        General_tile.Image = ImageList1.Images.Item(0)
        Breeding_tile.Image = ImageList1.Images.Item(1)
        Lactation_Tile.Image = ImageList1.Images.Item(4)
        Notes_Tile.Image = ImageList1.Images.Item(5)
        Measurements_tile.Image = ImageList1.Images.Item(2)
        'PictureBox6.Image = ImageList1.Images.Item(5)
        Medical_Tile.Image = ImageList1.Images.Item(3)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles General_tile.Click
        cowid = TextBox1.Text
        General.Show()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Breeding_tile.Click
        Breeding.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        cowid = TextBox1.Text
        newflag = 0
        tabadd_general.Show()

    End Sub

    Private Sub Medical_Tile_Click(sender As System.Object, e As System.EventArgs) Handles Medical_Tile.Click
        Medical.Show()
    End Sub

    Private Sub Notes_Tile_Click(sender As System.Object, e As System.EventArgs) Handles Notes_Tile.Click
        Notes.Show()
    End Sub

    Private Sub Lactation_Tile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Lactation_Tile.Click
        Lactation.Show()
    End Sub

    Private Sub Measurements_tile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Measurements_tile.Click
        Measurements.Show()
    End Sub

    Private Sub General_tile_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles General_tile.MouseHover
        txt = "General"
        ToolTip1.SetToolTip(General_tile, txt)

    End Sub

    Private Sub Lactation_Tile_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Lactation_Tile.MouseHover
        txt = "Lactation"
        ToolTip1.SetToolTip(Lactation_Tile, txt)
    End Sub

    Private Sub Measurements_tile_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Measurements_tile.MouseHover
        txt = "Measurements"
        ToolTip1.SetToolTip(Measurements_tile, txt)
    End Sub

    Private Sub Medical_Tile_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Medical_Tile.MouseHover
        txt = "Medical"
        ToolTip1.SetToolTip(Medical_Tile, txt)
    End Sub

    Private Sub Notes_Tile_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Notes_Tile.MouseHover
        txt = "Notes"
        ToolTip1.SetToolTip(Notes_Tile, txt)
    End Sub

    Private Sub Breeding_tile_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Breeding_tile.MouseHover
        txt = "Breeding"
        ToolTip1.SetToolTip(Breeding_tile, txt)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        newflag = 1
        'TextBox1.Text = " "
        tabadd_general.Show()

    End Sub
End Class

