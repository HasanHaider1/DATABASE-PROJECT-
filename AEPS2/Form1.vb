Public Class Form1


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Login2.Show()
        'RegistrationPanel1.Show()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Instructions.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Login.Show()
        'RegisterPanel1.Show()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        SearchQueries.Show()

    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click


    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If (PictureBox2.Visible = True) Then
            PictureBox2.Visible = False
            PictureBox5.Visible = True
        ElseIf (PictureBox5.Visible = True) Then
            PictureBox5.Visible = False
            PictureBox4.Visible = True
        ElseIf (PictureBox4.Visible = True) Then
            PictureBox4.Visible = False
            PictureBox3.Visible = True
        ElseIf (PictureBox3.Visible = True) Then
            PictureBox3.Visible = False
            PictureBox6.Visible = True
        ElseIf (PictureBox6.Visible = True) Then
            PictureBox6.Visible = False
            PictureBox7.Visible = True
        ElseIf (PictureBox7.Visible = True) Then
            PictureBox7.Visible = False
            PictureBox8.Visible = True

        ElseIf (PictureBox8.Visible = True) Then
            PictureBox8.Visible = False
            PictureBox9.Visible = True

        ElseIf (PictureBox9.Visible = True) Then
            PictureBox9.Visible = False
            PictureBox10.Visible = True

        ElseIf (PictureBox10.Visible = True) Then
            PictureBox10.Visible = False
            PictureBox11.Visible = True

        ElseIf (PictureBox11.Visible = True) Then
            PictureBox11.Visible = False
            PictureBox2.Visible = True
        End If
    End Sub
End Class
