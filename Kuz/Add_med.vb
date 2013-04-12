Public Class Add_med
    Public days_treat_int As Integer
   

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If tabadd_medi.click_edit = 1 Then
            ComboBox1.Text = tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(0).Value
            TextBox2.Text = tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(1).Value
            TextBox1.Text = tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(2).Value
            DateTimePicker1.Value = tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(3).Value
            DateTimePicker2.Value = tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(4).Value
            TextBox4.Text = tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(6).Value
            TextBox5.Text = tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(7).Value
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        If DateTime.Compare(DateTimePicker1.Value, DateTimePicker2.Value) > 0 Then
            MsgBox("Start Date must be before Stop Date!", , "Error!")
        Else
            tabadd_medi.n = tabadd_medi.DataGridView2.Rows.Add()
            Dim days_treat As TimeSpan
            If tabadd_general.flag_1 = 1 Then
                tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(0).Value = ComboBox1.Text
                tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(1).Value = TextBox2.Text
                tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(2).Value = TextBox1.Text
                tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(3).Value = DateTimePicker1.Value
                tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(4).Value = DateTimePicker2.Value
                days_treat = (DateTimePicker2.Value - DateTimePicker1.Value)
                days_treat_int = days_treat.TotalDays
                tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(5).Value = days_treat_int
                tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(6).Value = TextBox4.Text
                tabadd_medi.DataGridView2.Rows.Item(tabadd_general.ind_1).Cells(7).Value = TextBox5.Text
                tabadd_general.flag_1 = 0
                tabadd_medi.DataGridView2.Rows.RemoveAt(tabadd_medi.n)
            Else
                tabadd_medi.DataGridView2.Rows.Item(tabadd_medi.n).Cells(0).Value = ComboBox1.Text
                tabadd_medi.DataGridView2.Rows.Item(tabadd_medi.n).Cells(1).Value = TextBox1.Text
                tabadd_medi.DataGridView2.Rows.Item(tabadd_medi.n).Cells(2).Value = TextBox2.Text
                tabadd_medi.DataGridView2.Rows.Item(tabadd_medi.n).Cells(3).Value = DateTimePicker1.Value
                tabadd_medi.DataGridView2.Rows.Item(tabadd_medi.n).Cells(4).Value = DateTimePicker2.Value
                'Form1.DataGridView2.Rows.Item(Form1.ind_1).Cells(5).Value = TextBox3.Text
                days_treat = (DateTimePicker2.Value - DateTimePicker1.Value)
                days_treat_int = days_treat.TotalDays
                tabadd_medi.DataGridView2.Rows.Item(tabadd_medi.n).Cells(5).Value = days_treat_int
                tabadd_medi.DataGridView2.Rows.Item(tabadd_medi.n).Cells(6).Value = TextBox4.Text
                tabadd_medi.DataGridView2.Rows.Item(tabadd_medi.n).Cells(7).Value = TextBox5.Text
                'tabadd_general.flag_1 = 0
                'tabadd_medi.DataGridView2.Rows.RemoveAt(n)
            End If
            Close()
        End If
    End Sub

End Class