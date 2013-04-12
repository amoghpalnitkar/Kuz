Public Class Form1

    
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.born_insem
        TextBox2.Text = My.Settings.calved_insem
        TextBox3.Text = My.Settings.insem_calving
        TextBox4.Text = My.Settings.insem_pregc1
        TextBox5.Text = My.Settings.insem_pregc2
        Button2.Enabled = False
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'close
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'edit
        Button2.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'apply
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        Button2.Enabled = False
        My.Settings.born_insem = Val(TextBox1.Text)
        My.Settings.calved_insem = Val(TextBox2.Text)
        My.Settings.insem_calving = Val(TextBox3.Text)
        My.Settings.insem_pregc1 = Val(TextBox4.Text)
        My.Settings.insem_pregc2 = Val(TextBox5.Text)

    End Sub
End Class