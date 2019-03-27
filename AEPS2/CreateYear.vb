Public Class CreateYear
    Dim db As New DBconnection
    Dim dataTable As New DataTable
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim table_name As String
        'Dim info As String
        'Dim dr As DataRow
        'Dim flag As Boolean
        'flag = False
        If String.IsNullOrEmpty(TextBox1.Text.ToString) Then
            MessageBox.Show("Fill in the election Year first!")
        Else
            dataTable = db.SelectQuery("Select [Year] from ElectionRecord where [Year] = '" + TextBox1.Text + "'")
            If DataTable.Rows.Count > 0 Then

                MessageBox.Show("ELECTION RECORD FOR YEAR " + TextBox1.Text + " ALREADY EXISTS!")
                TextBox1.Clear()
            Else
                If (DateTimePicker1.Value.Date.Year.ToString = TextBox1.Text.ToString) And (DateTimePicker1.Value.Date > Date.Now.Date) Then
                    Dim result As Integer = MessageBox.Show("Are you sure you want to create a new election? It cannot be deleted later.", "Alert", MessageBoxButtons.YesNo)
                    If result = DialogResult.Yes Then
                        TextBox1.ReadOnly = True
                        db.InsertQuery("Insert into ElectionRecord([Year],[Date]) values('" + TextBox1.Text.ToString + "','" + DateTimePicker1.Value.Date.ToShortDateString + "')")
                        Button1.Enabled = True
                        MessageBox.Show("Election Record for the year " +
                        TextBox1.Text.ToString + " successfully created!" & vbNewLine &
                        " Scheduled for: " + DateTimePicker1.Value.Date.ToShortDateString & vbNewLine &
                        "You can set the start and end time of the election anytime by clicking on the begin election on the home screen")
                        table_name = "ElectionRecord" + TextBox1.Text.ToString()
                        'MessageBox.Show("Create Table " + table_name + " 
                        '( Counting int identity(0,1) primary key,
                        'ElectionYear int Foreign key References ElectionRecord([Year]),
                        'StudentID varchar(50) Foreign key references StudentRecord(StudentID),
                        'Panel int Foreign key references PanelInfo(PanelID),
                        'Date_Time DateTime not null
                        ')")
                        db.CreateQuery("Create Table " + table_name + " 
                        ( Counting int identity(0,1) primary key,
                        ElectionYear int Foreign key References ElectionRecord([Year]),
                        StudentID varchar(50) Foreign key references StudentRecord(StudentID),
                        Panel int Foreign key references PanelInfo(PanelID),
                        Date_Time DateTime not null
                        )")

                    ElseIf result = DialogResult.No Then
                        TextBox1.Clear()
                    Else
                        MessageBox.Show("the years are not consistent")
                    End If
                End If
            End If
        End If
        
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelInfo1.Show()
        'RegisterPanel1.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PanelInfo2.Show()
        'RegisterPanel2.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub CreateYear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Enabled = False
        Button2.Enabled = False
        'Button5.Enabled = False

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        BeginVoting.Label10.Visible = False
        BeginVoting.ComboBox1.Enabled = True
        BeginVoting.ComboBox2.Enabled = True
        BeginVoting.ComboBox3.Enabled = True
        BeginVoting.ComboBox4.Enabled = True
        BeginVoting.ComboBox5.Enabled = True
        BeginVoting.ComboBox6.Enabled = True
        BeginVoting.Button1.Enabled = True

        Close()

    End Sub
End Class