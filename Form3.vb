Imports System.IO
Imports System.Security.Principal

Public Class Form3

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            TextBox1.Text = "Ethernet"
        End If
        Try
            Dim r As String = """"
            Dim res As String = 0
            res = r + TextBox1.Text + r
            Dim comando As String = "powershell.exe" + " -command  " + """" + "& " + " { " + "Restart-NetAdapter -Name " + res + "}" + """"
            Dim SW As New StreamWriter("co.bat")
            SW.WriteLine("@echo off & min & mode 35,20 &  " + comando)
            SW.Close()
            SW.Dispose()
            Dim info As New ProcessStartInfo("co.bat")
            info.RedirectStandardOutput = True
            Dim processo As New Process()
            processo.StartInfo = info
            processo.StartInfo.UseShellExecute = False
            processo.Start()
            processo.WaitForExit()
            Dim retorno As String = processo.StandardOutput.ReadToEnd()
            Form1.ListBox1.Items.Add(retorno)
            Form1.ListBox1.Items.Add("Realizado !")
            Form1.ListBox1.Items.Add(" ")
            My.Computer.FileSystem.DeleteFile("co.bat")
            Me.Close()
        Catch ex As Exception
            Form1.ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
         Dim mPrincipal As WindowsPrincipal = New WindowsPrincipal(WindowsIdentity.GetCurrent)
        If mPrincipal.IsInRole(WindowsBuiltInRole.Administrator) = False Then
            MessageBox.Show("Você precisa executar esta aplicação como administrador", "É preciso ser uma administrador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End If
    End Sub
End Class