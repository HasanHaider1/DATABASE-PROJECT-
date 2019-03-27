Public Class Login
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As New DBconnection
        Dim dataTable As New DataTable

        dataTable = db.SelectQuery("Select [UserID], [Password] from [Admin_UserId_Password] 
where [UserID] = '" + TextBox3.Text + "' and [Password] = '" + TextBox1.Text + "'")
        If dataTable.Rows.Count > 0 Then
            Close()
            CreateYear.Show()
        Else
            MessageBox.Show("Invalid userID Password!")
            TextBox1.Clear()
            TextBox3.Clear()
        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox1.UseSystemPasswordChar = False Then
            TextBox1.UseSystemPasswordChar = True
            Button2.BackgroundImage = My.Resources.eyeclosed
        ElseIf TextBox1.UseSystemPasswordChar = True Then
            TextBox1.UseSystemPasswordChar = False
            Button2.BackgroundImage = My.Resources.eyeopened

        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.FlatAppearance.BorderSize = 0

    End Sub
End Class