Public Class Form2
    Dim r As String = """"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Digite o número de IP")
        Else
            My.Settings.ipv = r + TextBox1.Text + r
            Form1.Timer2.Enabled = True
            Me.Close()
        End If
    End Sub
End Class