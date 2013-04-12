Public Class Add_notes


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        tabadd_notes.n = tabadd_notes.DataGridView3.Rows.Add()
        If tabadd_general.flag = 1 Then
            tabadd_notes.DataGridView3.Rows.Item(tabadd_general.ind).Cells(0).Value = DateTimePicker1.Value
            tabadd_notes.DataGridView3.Rows.Item(tabadd_general.ind).Cells(1).Value = TextBox1.Text
            tabadd_notes.DataGridView3.Rows.Item(tabadd_general.ind).Cells(2).Value = TextBox2.Text
            tabadd_general.flag = 0
            tabadd_notes.DataGridView3.Rows.RemoveAt(tabadd_notes.n)
        Else
            tabadd_notes.DataGridView3.Rows.Item(tabadd_notes.n).Cells(0).Value = DateTimePicker1.Value
            tabadd_notes.DataGridView3.Rows.Item(tabadd_notes.n).Cells(1).Value = TextBox1.Text
            tabadd_notes.DataGridView3.Rows.Item(tabadd_notes.n).Cells(2).Value = TextBox2.Text
        End If
        Close()
    End Sub


    Private Sub Add_notes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If tabadd_notes.edit_click = 1 Then
            DateTimePicker1.Value = tabadd_notes.DataGridView3.Rows.Item(tabadd_general.ind).Cells(0).Value
            TextBox1.Text = tabadd_notes.DataGridView3.Rows.Item(tabadd_general.ind).Cells(1).Value
            TextBox2.Text = tabadd_notes.DataGridView3.Rows.Item(tabadd_general.ind).Cells(2).Value
        End If
    End Sub
End Class