Imports System.IO
Public Class RegisterPanel2
    Public listPos As New List(Of String) 'Stores the 4 position titles
    'Public stdInfoP1 As New List(Of String)
    Public db As New DBconnection
    Public dataTable As New DataTable
    Public content As String 'Stores the data temporarily
    Public position As String 'Stores the position applied for
    Public dt As New DataTable
    Public years As New List(Of String) 'stores the batch years of current 4 years
    Public stdP1 As String
    Dim imagepath = "D:\Inara\Habib University\3rd Sem\Database\Project\Images"

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ComboBox1.Items.Clear()


        dataTable = db.SelectQuery("Select * from StudentRecord where StudentID Like '" + TextBox1.Text + "'")
        'If the student Id exists then do the following:
        If dataTable.Rows.Count > 0 Then
            If RegisterPanel1.stdInfoP1.Contains(TextBox1.Text.ToString) Then
                MessageBox.Show("Student already a member of the panel")
                TextBox3.Clear()
            Else

                'Add the full name in the name combo box
                content = (dataTable.Rows.Item(0).Item("FirstName").ToString) + " " + (dataTable.Rows.Item(0).Item("LastName").ToString)
                TextBox5.Text = content


                'Add the batch in the combo box of Batch and determine the position that the 
                'student can apply for based of the batch year. Add position in Applied for combo box
                content = (dataTable.Rows.Item(0).Item("Batch").ToString)
                If content = years.Item(0).ToString Then
                    ComboBox1.Items.Add(listPos.Item(0).ToString)
                ElseIf content = years.Item(1).ToString Or content = years.Item(2).ToString Then
                    ComboBox1.Items.Clear()
                    ComboBox1.Items.Add(listPos.Item(0).ToString)
                    ComboBox1.Items.Add(listPos.Item(1).ToString)
                    ComboBox1.Items.Add(listPos.Item(2).ToString)
                    ComboBox1.Items.Add(listPos.Item(3).ToString)
                ElseIf content = years.Item(3).ToString Then
                    ComboBox1.Items.Clear()
                    ComboBox1.Items.Add(listPos.Item(1).ToString)
                    ComboBox1.Items.Add(listPos.Item(2).ToString)
                    ComboBox1.Items.Add(listPos.Item(3).ToString)
                End If
                TextBox6.Text = content


                'Store the studentID and Batch chosen for panel in stdP1 string
                stdP1 = TextBox1.Text.ToString + "~" + content

                'Load the major,gender and CGPA in the corresponding combo boxes
                content = (dataTable.Rows.Item(0).Item("Major").ToString)
                TextBox7.Text = content
                content = (dataTable.Rows.Item(0).Item("Gender").ToString)
                stdP1 = stdP1 + "~" + content
                TextBox8.Text = content
                content = (dataTable.Rows.Item(0).Item("CGPA").ToString)
                'If CGPA is lower than 2.67 then:
                If content < "2.67" Then
                    MessageBox.Show("Inavlid Candidate! GPA lower than 2.67")
                    Button3.Enabled = True
                    TextBox1.Clear()
                    TextBox5.Clear()
                    TextBox6.Clear()
                    TextBox7.Clear()
                    TextBox8.Clear()
                    TextBox9.Clear()
                    ComboBox1.Items.Clear()
                Else
                    TextBox9.Text = content
                End If
            End If
        Else
            MessageBox.Show("Invalid Id")
            TextBox1.Clear()

        End If

        'Add student already chosen in list
        RegisterPanel1.stdInfoP1.Add(TextBox1.Text.ToString)
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim temp As String
        temp = TextBox1.Text

        If (String.IsNullOrEmpty(temp)) Or (String.IsNullOrWhiteSpace(temp)) Or (ComboBox1.SelectedIndex = -1) Then

            MessageBox.Show("Fill all the boxes!")
        Else
            Dim result As Integer = MessageBox.Show("Are you sure of the selection! the member cannot be edited again", "confirmation", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Button4.Enabled = True
                GroupBox1.Enabled = False
            ElseIf result = DialogResult.No Then
                GroupBox1.Enabled = True

            End If
            Button4.Enabled = True

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ComboBox2.Items.Clear()
        dataTable = db.SelectQuery("Select * from StudentRecord where StudentID Like '" + TextBox3.Text + "'")
        'If the student Id exists then do the following:
        If dataTable.Rows.Count > 0 Then
            If RegisterPanel1.stdInfoP1.Contains(TextBox3.Text.ToString) Then
                MessageBox.Show("Student already a member of the panel")
                TextBox3.Clear()
            Else
                'Add the full name in the name combo box
                content = (dataTable.Rows.Item(0).Item("FirstName").ToString) + " " + (dataTable.Rows.Item(0).Item("LastName").ToString)
                TextBox16.Text = content


                'Add the batch in the combo box of Batch and determine the position that the 
                'student can apply for based of the batch year. Add position in Applied for combo box
                content = (dataTable.Rows.Item(0).Item("Batch").ToString)
                If content = years.Item(0).ToString Then
                    ComboBox2.Items.Add(listPos.Item(0).ToString)
                ElseIf content = years.Item(1).ToString Or content = years.Item(2).ToString Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add(listPos.Item(0).ToString)
                    ComboBox2.Items.Add(listPos.Item(1).ToString)
                    ComboBox2.Items.Add(listPos.Item(2).ToString)
                    ComboBox2.Items.Add(listPos.Item(3).ToString)
                ElseIf content = years.Item(3).ToString Then
                    ComboBox2.Items.Clear()
                    ComboBox2.Items.Add(listPos.Item(1).ToString)
                    ComboBox2.Items.Add(listPos.Item(2).ToString)
                    ComboBox2.Items.Add(listPos.Item(3).ToString)
                End If
                TextBox15.Text = content

                If ComboBox2.Items.Contains(ComboBox1.SelectedItem) Then
                    ComboBox2.Items.Remove(ComboBox1.SelectedItem)
                End If
                'Store the studentID and Batch chosen for panel in stdP1 string
                stdP1 = TextBox1.Text.ToString + "~" + content

                'Load the major,gender and CGPA in the corresponding combo boxes
                content = (dataTable.Rows.Item(0).Item("Major").ToString)
                If TextBox7.Text.ToString = content Then
                    MessageBox.Show("A student of " + content + " major has already been chosen!")
                    Button3.Enabled = True
                    TextBox3.Clear()
                    TextBox16.Clear()
                    TextBox15.Clear()
                    TextBox14.Clear()
                    TextBox13.Clear()
                    TextBox12.Clear()
                    ComboBox2.Items.Clear()
                    Exit Sub
                Else
                    TextBox14.Text = content
                End If

                content = (dataTable.Rows.Item(0).Item("Gender").ToString)
                stdP1 = stdP1 + "~" + content
                TextBox13.Text = content
                content = (dataTable.Rows.Item(0).Item("CGPA").ToString)
                'If CGPA is lower than 2.67 then:
                If content < "2.67" Then
                    MessageBox.Show("Inavlid Candidate! GPA lower than 2.67")
                    Button3.Enabled = True
                    TextBox3.Clear()
                    TextBox16.Clear()
                    TextBox15.Clear()
                    TextBox14.Clear()
                    TextBox13.Clear()
                    TextBox12.Clear()
                    ComboBox2.Items.Clear()
                Else
                    TextBox12.Text = content
                End If
                Button10.Enabled = True
            End If
        Else
            MessageBox.Show("Invalid Id")
            TextBox3.Clear()

            'Add student already chosen in list
            RegisterPanel1.stdInfoP1.Add(TextBox3.Text.ToString)
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim temp As String
        temp = TextBox3.Text

        If (String.IsNullOrEmpty(temp)) Or (String.IsNullOrWhiteSpace(temp)) Or (ComboBox2.SelectedIndex = -1) Then

            MessageBox.Show("Fill all the boxes!")
        Else
            Dim result As Integer = MessageBox.Show("Are you sure of the selection! the member cannot be edited again", "confirmation", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Button5.Enabled = True
                GroupBox3.Enabled = False
            End If

        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        dataTable = db.SelectQuery("Select * from StudentRecord where StudentID Like '" + TextBox2.Text + "'")
        'If the student Id exists then do the following:
        If dataTable.Rows.Count > 0 Then
            If RegisterPanel1.stdInfoP1.Contains(TextBox2.Text.ToString) Then
                MessageBox.Show("Student already a member of the panel")
                TextBox2.Clear()
            Else
                'Add the full name in the name combo box
                content = (dataTable.Rows.Item(0).Item("FirstName").ToString) + " " + (dataTable.Rows.Item(0).Item("LastName").ToString)
                TextBox22.Text = content


                'Add the batch in the combo box of Batch and determine the position that the 
                'student can apply for based of the batch year. Add position in Applied for combo box
                content = (dataTable.Rows.Item(0).Item("Batch").ToString)
                If content = years.Item(0).ToString Then
                    ComboBox3.Items.Add(listPos.Item(0).ToString)
                ElseIf content = years.Item(1).ToString Or content = years.Item(2).ToString Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add(listPos.Item(0).ToString)
                    ComboBox3.Items.Add(listPos.Item(1).ToString)
                    ComboBox3.Items.Add(listPos.Item(2).ToString)
                    ComboBox3.Items.Add(listPos.Item(3).ToString)
                ElseIf content = years.Item(3).ToString Then
                    ComboBox3.Items.Clear()
                    ComboBox3.Items.Add(listPos.Item(1).ToString)
                    ComboBox3.Items.Add(listPos.Item(2).ToString)
                    ComboBox3.Items.Add(listPos.Item(3).ToString)
                End If
                TextBox21.Text = content

                If ComboBox3.Items.Contains(ComboBox1.SelectedItem) Then
                    ComboBox3.Items.Remove(ComboBox1.SelectedItem)
                End If
                If ComboBox3.Items.Contains(ComboBox2.SelectedItem) Then
                    ComboBox3.Items.Remove(ComboBox2.SelectedItem)
                End If


                'Load the major,gender and CGPA in the corresponding combo boxes
                content = (dataTable.Rows.Item(0).Item("Major").ToString)
                If TextBox7.Text.ToString = content Or TextBox14.Text.ToString = content Then
                    MessageBox.Show("A student of " + content + " major has already been chosen!")
                    Button3.Enabled = True
                    TextBox2.Clear()
                    TextBox22.Clear()
                    TextBox21.Clear()
                    TextBox20.Clear()
                    TextBox19.Clear()
                    TextBox18.Clear()
                    ComboBox3.Items.Clear()
                    Exit Sub
                Else
                    TextBox20.Text = content
                End If

                content = (dataTable.Rows.Item(0).Item("Gender").ToString)
                TextBox19.Text = content
                If (TextBox8.Text = TextBox19.Text) And (TextBox13.Text = TextBox19.Text) Then
                    MessageBox.Show("A panel cannot have more than 2 " + TextBox19.Text + "members")
                    TextBox2.Clear()
                    TextBox22.Clear()
                    TextBox21.Clear()
                    TextBox20.Clear()
                    TextBox19.Clear()
                    TextBox18.Clear()
                    ComboBox3.Items.Clear()
                    Exit Sub
                End If


                content = (dataTable.Rows.Item(0).Item("CGPA").ToString)
                'If CGPA is lower than 2.67 then:
                If content < "2.67" Then
                    MessageBox.Show("Inavlid Candidate! GPA lower than 2.67")
                    'Button3.Enabled = True
                    TextBox2.Clear()
                    TextBox22.Clear()
                    TextBox21.Clear()
                    TextBox20.Clear()
                    TextBox19.Clear()
                    TextBox18.Clear()
                    ComboBox3.Items.Clear()
                Else
                    TextBox18.Text = content
                End If
            End If
            Button8.Enabled = True
        Else
            MessageBox.Show("Invalid Id")
            TextBox2.Clear()

            'Add student already chosen in list
            RegisterPanel1.stdInfoP1.Add(TextBox2.Text.ToString)
        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim temp As String
        temp = TextBox2.Text

        If (String.IsNullOrEmpty(temp)) Or (String.IsNullOrWhiteSpace(temp)) Or (ComboBox3.SelectedIndex = -1) Then

            MessageBox.Show("Fill all the boxes!")
        Else
            Dim result As Integer = MessageBox.Show("Are you sure of the selection! the member cannot be edited again", "confirmation", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Button6.Enabled = True
                GroupBox2.Enabled = False
            End If

        End If
        'Button6.Enabled = True

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        dataTable = db.SelectQuery("Select * from StudentRecord where StudentID Like '" + TextBox4.Text + "'")
        'If the student Id exists then do the following:
        If dataTable.Rows.Count > 0 Then
            If RegisterPanel1.stdInfoP1.Contains(TextBox4.Text.ToString) Then
                MessageBox.Show("Student already a member of the panel")
                TextBox4.Clear()
            Else
                'Add the full name in the name combo box
                content = (dataTable.Rows.Item(0).Item("FirstName").ToString) + " " + (dataTable.Rows.Item(0).Item("LastName").ToString)
                TextBox28.Text = content


                'Add the batch in the combo box of Batch and determine the position that the 
                'student can apply for based of the batch year. Add position in Applied for combo box
                content = (dataTable.Rows.Item(0).Item("Batch").ToString)
                If content = years.Item(0).ToString Then
                    ComboBox4.Items.Add(listPos.Item(0).ToString)
                ElseIf content = years.Item(1).ToString Or content = years.Item(2).ToString Then
                    ComboBox4.Items.Clear()
                    ComboBox4.Items.Add(listPos.Item(0).ToString)
                    ComboBox4.Items.Add(listPos.Item(1).ToString)
                    ComboBox4.Items.Add(listPos.Item(2).ToString)
                    ComboBox4.Items.Add(listPos.Item(3).ToString)
                ElseIf content = years.Item(3).ToString Then
                    ComboBox4.Items.Clear()
                    ComboBox4.Items.Add(listPos.Item(1).ToString)
                    ComboBox4.Items.Add(listPos.Item(2).ToString)
                    ComboBox4.Items.Add(listPos.Item(3).ToString)
                End If
                TextBox27.Text = content

                If ComboBox4.Items.Contains(ComboBox1.SelectedItem) Then
                    ComboBox4.Items.Remove(ComboBox1.SelectedItem)
                End If
                If ComboBox4.Items.Contains(ComboBox2.SelectedItem) Then
                    ComboBox4.Items.Remove(ComboBox2.SelectedItem)
                End If
                If ComboBox4.Items.Contains(ComboBox3.SelectedItem) Then
                    ComboBox4.Items.Remove(ComboBox3.SelectedItem)
                End If


                'Load the major,gender and CGPA in the corresponding combo boxes
                content = (dataTable.Rows.Item(0).Item("Major").ToString)
                If TextBox7.Text.ToString = content Or TextBox14.Text.ToString = content Or TextBox20.Text.ToString = content Then
                    MessageBox.Show("A student of " + content + " major has already been chosen!")
                    Button6.Enabled = True
                    TextBox4.Clear()
                    TextBox28.Clear()
                    TextBox27.Clear()
                    TextBox26.Clear()
                    TextBox25.Clear()
                    TextBox24.Clear()
                    ComboBox4.Items.Clear()
                    Exit Sub
                Else
                    TextBox26.Text = content
                End If

                content = (dataTable.Rows.Item(0).Item("Gender").ToString)
                TextBox25.Text = content
                If ((TextBox8.Text = TextBox25.Text) And (TextBox13.Text = TextBox25.Text)) Or ((TextBox8.Text = TextBox25.Text) And (TextBox19.Text = TextBox25.Text)) Or ((TextBox13.Text = TextBox25.Text) And (TextBox19.Text = TextBox25.Text)) Then
                    MessageBox.Show("A panel cannot have more than 2 " + TextBox19.Text + "members")
                    TextBox4.Clear()
                    TextBox28.Clear()
                    TextBox27.Clear()
                    TextBox26.Clear()
                    TextBox25.Clear()
                    TextBox24.Clear()
                    ComboBox4.Items.Clear()
                    Exit Sub
                End If


                content = (dataTable.Rows.Item(0).Item("CGPA").ToString)
                'If CGPA is lower than 2.67 then:
                If content < "2.67" Then
                    MessageBox.Show("Inavlid Candidate! GPA lower than 2.67")
                    'Button3.Enabled = True
                    TextBox4.Clear()
                    TextBox28.Clear()
                    TextBox27.Clear()
                    TextBox26.Clear()
                    TextBox25.Clear()
                    TextBox24.Clear()
                    ComboBox4.Items.Clear()
                Else
                    TextBox24.Text = content
                End If
            End If
            Button9.Enabled = True
        Else
            MessageBox.Show("Invalid Id")
            TextBox4.Clear()

            'Add student already chosen in list
            RegisterPanel1.stdInfoP1.Add(TextBox4.Text.ToString)
        End If

    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim temp As String
        temp = TextBox4.Text

        If (String.IsNullOrEmpty(temp)) Or (String.IsNullOrWhiteSpace(temp)) Or (ComboBox3.SelectedIndex = -1) Then

            MessageBox.Show("Fill all the boxes!")
        Else
            Dim result As Integer = MessageBox.Show("Are you sure of the selection! the member cannot be edited again", "confirmation", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Button2.Enabled = True
                GroupBox4.Enabled = False
            End If

        End If
        'Button6.Enabled = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim srcFile As String
        Dim dstFile As String
        Dim panelID As Integer


        dstFile = "D:\Inara\Habib University\3rd Sem\Database\Project\Images\"



        srcFile = PanelInfo2.PictureBox1.ImageLocation
        MessageBox.Show("path: " + srcFile)
        dstFile = dstFile + PanelInfo2.MaskedTextBox1.Text.ToString + PanelInfo2.MaskedTextBox2.Text.ToString + ".jpg"
        File.Copy(srcFile, dstFile)
        dataTable = db.SelectQuery("Select top 1 PanelID from PanelInfo order by PanelID desc")
        panelID = dataTable.Rows.Item(0).Item(0)
        panelID = panelID + 1

        ' query = "Insert into PanelInfo(PanelID,PanelName,Manifesto,YearID,Logo) values('" + panelID.ToString + "','" + MaskedTextBox1.Text.ToString + "','" + RichTextBox1.Text.ToString + "','" + MaskedTextBox2.Text.ToString + "','" + dstFile + "')"
        ' MessageBox.Show(query)
        db.InsertQuery("EXEC AddPanelInfo " + panelID.ToString() + ",'" + PanelInfo2.MaskedTextBox1.Text.ToString + "' , '" + PanelInfo2.RichTextBox1.Text.ToString + "' , '" + PanelInfo2.MaskedTextBox2.Text.ToString + "' , '" + dstFile + "'")
        'Inserting member details in the database
        db.InsertQuery("EXEC AddCandidateInfo " + panelID.ToString() + " , '" + TextBox1.Text.ToString() + "', '" + ComboBox1.Text.ToString() + "'")
        db.InsertQuery("EXEC AddCandidateInfo " + panelID.ToString() + " , '" + TextBox3.Text.ToString() + "', '" + ComboBox2.Text.ToString() + "'")
        db.InsertQuery("EXEC AddCandidateInfo " + panelID.ToString() + " , '" + TextBox2.Text.ToString() + "', '" + ComboBox3.Text.ToString() + "'")
        db.InsertQuery("EXEC AddCandidateInfo " + panelID.ToString() + " , '" + TextBox4.Text.ToString() + "', '" + ComboBox4.Text.ToString() + "'")

        CreateYear.Button2.Enabled = True
        Close()
        RegisterPanel1.Close()
        CreateYear.Button1.Enabled = False
        CreateYear.Button2.Enabled = False
        CreateYear.Button3.Enabled = False
        CreateYear.Button5.Enabled = True



    End Sub

    Private Sub RegisterPanel2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dt = db.SelectQuery("Select Distinct top 4 Batch from StudentRecord order by Batch desc")
        For i As Integer = 0 To 3
            years.Add(dt.Rows.Item(i).Item(0).ToString())
        Next

        listPos.Add("Secretary")
        listPos.Add("President")
        listPos.Add("Vice President")
        listPos.Add("Treasurer")

        Button2.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        Button10.Enabled = False
    End Sub
End Class
