Public Class Add_measure

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        tabadd_measure.n = tabadd_measure.DataGridView4.Rows.Add()
        'Dim days_treat As TimeSpan
        'Dim days_treat_int As Integer
        If tabadd_general.flag_2 = 1 Then
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(0).Value = DateTimePicker1.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(1).Value = TextBox1.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(2).Value = TextBox6.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(3).Value = TextBox3.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(4).Value = TextBox5.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(5).Value = TextBox4.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(6).Value = TextBox2.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(7).Value = TextBox8.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(8).Value = TextBox9.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(9).Value = TextBox7.Text
            tabadd_general.flag_2 = 0
            tabadd_measure.DataGridView4.Rows.RemoveAt(tabadd_measure.n)
        Else
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(0).Value = DateTimePicker1.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(1).Value = TextBox1.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(2).Value = TextBox6.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(3).Value = TextBox3.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(4).Value = TextBox5.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(5).Value = TextBox4.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(6).Value = TextBox2.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(7).Value = TextBox8.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(8).Value = TextBox9.Text
            tabadd_measure.DataGridView4.Rows.Item(tabadd_measure.n).Cells(9).Value = TextBox7.Text
        End If
        Close()
    End Sub

    Private Sub Add_measure_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If tabadd_measure.click_edit = 1 Then

            TextBox1.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(1).Value
            TextBox2.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(6).Value
            TextBox3.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(3).Value
            TextBox4.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(5).Value
            TextBox5.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(4).Value
            TextBox6.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(2).Value
            TextBox7.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(9).Value
            TextBox8.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(7).Value
            TextBox9.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(8).Value
            DateTimePicker1.Text = tabadd_measure.DataGridView4.Rows.Item(tabadd_general.ind_2).Cells(0).Value
        End If
    End Sub

    Private Sub Label11_Click(sender As System.Object, e As System.EventArgs) Handles Label11.Click

    End Sub
End Class