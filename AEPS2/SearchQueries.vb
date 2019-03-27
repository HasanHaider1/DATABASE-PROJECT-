Imports System.Data.SqlClient



Public Class SearchQueries

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub SearchQueries_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If String.IsNullOrEmpty(TextBox1.Text) = False And String.IsNullOrEmpty(TextBox2.Text) And String.IsNullOrEmpty(TextBox3.Text) Then
            Me.Hide()
            SearchByYear.Show()
        ElseIf String.IsNullOrEmpty(TextBox1.Text) And String.IsNullOrEmpty(TextBox2.Text) = False And String.IsNullOrEmpty(TextBox3.Text) Then
            Me.Hide()
            SearchByPanel.Show()
        ElseIf String.IsNullOrEmpty(TextBox1.Text) And String.IsNullOrEmpty(TextBox2.Text) And String.IsNullOrEmpty(TextBox3.Text) = False Then
            Me.Hide()
            SearchByStudentID.Show()
        End If

        Dim db As New DBconnection
        Dim dataTable As New DataTable
        If String.IsNullOrEmpty(TextBox1.Text) = False And String.IsNullOrEmpty(TextBox2.Text) And String.IsNullOrEmpty(TextBox3.Text) Then
            dataTable = db.SelectQuery("select ElectionRecord.Year, ElectionRecord.Date, 
            PanelInfo.PanelName as 'Winning Panel',
            ElectionRecord.TotalVotes as 'Registered Voters',
            ElectionRecord.VotesCasted, (ElectionRecord.TotalVotes - ElectionRecord.VotesCasted) as 'Votes Wasted', 
            StudentRecord.FirstName + StudentRecord.LastName as 'Candidate Name',CandidateInfo.Position
            from
            ElectionRecord, PanelInfo, CandidateInfo, StudentRecord
            where
            ElectionRecord.WinningPanel = PanelInfo.PanelID and
            PanelInfo.PanelID = CandidateInfo.PanelID and
            CandidateInfo.stdID = StudentRecord.StudentID
            and ElectionRecord.Year = '" + TextBox1.Text + "'")
        ElseIf String.IsNullOrEmpty(TextBox1.Text) And String.IsNullOrEmpty(TextBox2.Text) = False And String.IsNullOrEmpty(TextBox3.Text) Then
            dataTable = db.SelectQuery("select 
                PanelInfo.YearID as 'Election Year', 
                (StudentRecord.FirstName + StudentRecord.LastName) as 'Candidate Name', CandidateInfo.Position, 
                PanelInfo.Logo, PanelInfo.Manifesto
                from 
                PanelInfo, CandidateInfo, StudentRecord
                where 
                PanelInfo.PanelID = CandidateInfo.PanelID and
                CandidateInfo.stdID = StudentRecord.StudentID
                and  PanelInfo.PanelName= '" + TextBox2.Text + "'") 'Case sensitive
        ElseIf String.IsNullOrEmpty(TextBox1.Text) And String.IsNullOrEmpty(TextBox2.Text) And String.IsNullOrEmpty(TextBox3.Text) = False Then
            dataTable = db.SelectQuery("select 
                StudentRecord.FirstName + StudentRecord.LastName as 'Candidate Name', PanelInfo.PanelName, 
                StudentRecord.Batch as 'Batch Of', StudentRecord.Picture, PanelInfo.YearID as ' Election Year'
                from
                PanelInfo,StudentRecord,CandidateInfo
                where
                PanelInfo.PanelID = CandidateInfo.PanelID and
                CandidateInfo.stdID = StudentRecord.StudentID
                and StudentRecord.StudentID = '" + TextBox3.Text + "'")
        ElseIf String.IsNullOrEmpty(TextBox1.Text) = False And String.IsNullOrEmpty(TextBox2.Text) = False And String.IsNullOrEmpty(TextBox3.Text) Then
            dataTable = db.SelectQuery("select 
                PanelInfo.YearID as 'Election Year', 
                (StudentRecord.FirstName + StudentRecord.LastName) as 'Candidate Name', CandidateInfo.Position, 
                PanelInfo.Logo, PanelInfo.Manifesto
                from 
                PanelInfo, CandidateInfo, StudentRecord
                where 
                PanelInfo.PanelID = CandidateInfo.PanelID and
                CandidateInfo.stdID = StudentRecord.StudentID
                and  PanelInfo.PanelName= '" + TextBox2.Text + "'" +
                " and PanelInfo.YearID = '" + TextBox1.Text + "'")
        ElseIf String.IsNullOrEmpty(TextBox1.Text) And String.IsNullOrEmpty(TextBox2.Text) = False And String.IsNullOrEmpty(TextBox3.Text) = False Then
            dataTable = db.SelectQuery("select 
                PanelInfo.YearID as 'Election Year', 
                (StudentRecord.FirstName + StudentRecord.LastName) as 'Candidate Name', CandidateInfo.Position
                from 
                PanelInfo, CandidateInfo, StudentRecord
                where 
                PanelInfo.PanelID = CandidateInfo.PanelID and
                CandidateInfo.stdID = StudentRecord.StudentID
                and  PanelInfo.PanelName= '" + TextBox2.Text + "'" +
                " and StudentRecord.StudentID = '" + TextBox3.Text.ToString + "'")
        End If

        DataGridView1.DataSource = dataTable
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
        Form1.Show()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class