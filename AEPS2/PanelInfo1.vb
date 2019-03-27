Public Class PanelInfo1


    Private Sub PanelInfo1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button12.FlatAppearance.BorderSize = 0
        MaskedTextBox2.Text = CreateYear.TextBox1.Text.ToString()
        MaskedTextBox2.ReadOnly = True

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If String.IsNullOrEmpty(MaskedTextBox1.Text.ToString) Or
            String.IsNullOrEmpty(MaskedTextBox2.Text.ToString) Or
            String.IsNullOrWhiteSpace(MaskedTextBox1.Text.ToString) Or
            String.IsNullOrWhiteSpace(MaskedTextBox1.Text.ToString) Then

            MessageBox.Show("Please fill in the panel name first")
        Else
            Hide()
            RegisterPanel1.Show()
        End If


    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub

    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Label29.Visible = False
            PictureBox1.ImageLocation = OpenFileDialog1.FileName
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

        End If
    End Sub
End Class