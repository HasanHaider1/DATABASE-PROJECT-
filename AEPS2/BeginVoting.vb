Public Class BeginVoting
    Dim db As New DBconnection
    Dim dt As New DataTable
    Dim db_date As Date
    Dim start_time As String
    Dim end_time As String
    Private Sub BeginVoting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt = db.SelectQuery("Select Top 1 [Date] from ElectionRecord order by [Year] desc")
        db_date = dt.Rows.Item(0).Item(0)
        MessageBox.Show("DataBase date: " + db_date.ToString() & vbNewLine & "Currect Date: " + Date.Now.ToString())
        If db_date < Date.Now Then
            Label9.Visible = False
            Label10.Visible = True
            ComboBox1.Enabled = False
            ComboBox2.Enabled = False
            ComboBox3.Enabled = False
            ComboBox4.Enabled = False
            ComboBox5.Enabled = False
            ComboBox6.Enabled = False
            Button1.Enabled = False
        Else
            Label9.Text = db_date.Date.Year.ToString()
            Label10.Visible = False
            ComboBox1.Enabled = True
            ComboBox2.Enabled = True
            ComboBox3.Enabled = True
            ComboBox4.Enabled = True
            ComboBox5.Enabled = True
            ComboBox6.Enabled = True
            Button1.Enabled = True

        End If
        'Label9.Text = CreateYear.TextBox1.Text

        For time_count As Integer = 1 To 12
            ComboBox1.Items.Add(time_count)
            ComboBox4.Items.Add(time_count)
        Next
        For time_count As Integer = 0 To 60
            ComboBox2.Items.Add(time_count)
            ComboBox5.Items.Add(time_count)
        Next

        ComboBox3.Items.Add("am")
        ComboBox6.Items.Add("am")
        ComboBox3.Items.Add("pm")
        ComboBox6.Items.Add("pm")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        start_time = ComboBox1.Text.ToString() + ":" + ComboBox2.Text.ToString() + " " + ComboBox3.Text.ToString()
        end_time = ComboBox4.Text.ToString() + ":" + ComboBox5.Text.ToString() + " " + ComboBox6.Text.ToString()

        db.InsertQuery("Exec ElectionTimmings '" + start_time + "' , '" + end_time + "', " + db_date.Date.Year.ToString())
        Close()

    End Sub
End Class