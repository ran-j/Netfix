Imports System.Diagnostics
Imports System.Management
Imports System.Net.Dns
Imports System.Net
Imports System.IO
Imports System.Net.NetworkInformation


Public Class Form1
    Dim processo As New Process

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            Try
                Dim SW As New StreamWriter("co.bat")
                SW.WriteLine("@echo off & mode 35,20 & ipconfig /flushdns")
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
                ListBox1.Items.Add(retorno)
                My.Computer.FileSystem.DeleteFile("co.bat")
                RadioButton1.Checked = False
            Catch ex As Exception
                ListBox1.Items.Add(ex.Message)
            End Try
        ElseIf RadioButton2.Checked = True Then
            Try
                Dim SW As New StreamWriter("co.bat")
                SW.WriteLine("@echo off & mode 35,20 & ipconfig /renew")
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
                ListBox1.Items.Add(retorno)
                My.Computer.FileSystem.DeleteFile("co.bat")
                RadioButton2.Checked = False
            Catch ex As Exception
                ListBox1.Items.Add(ex.Message)
            End Try
        ElseIf RadioButton3.Checked = True Then
            Try
                Dim SW As New StreamWriter("co.bat")
                SW.WriteLine("@echo off & mode 35,20 & ipconfig /release")
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
                ListBox1.Items.Add(retorno)
                My.Computer.FileSystem.DeleteFile("co.bat")
                RadioButton3.Checked = False
            Catch ex As Exception
                ListBox1.Items.Add(ex.Message)
            End Try
        ElseIf RadioButton4.Checked = True Then
            ListBox1.Items.Clear()
            Dim interfaces As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each ni As NetworkInterface In interfaces
                ListBox1.Items.Add("Nome: " & ni.Description)
            Next
            ListBox1.Items.Add(" ")
            RadioButton4.Checked = False

        ElseIf RadioButton5.Checked = True Then
            Dim tela As New Form2
            tela.Show()
            ListBox1.Items.Add("Aguardando dado...")
            ListBox1.Items.Add(" ")
            RadioButton5.Checked = False
        ElseIf RadioButton6.Checked = True Then
            Dim x() As System.Net.IPAddress = System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName())
            ListBox1.Items.Add("Ipv4: " + x(0).ToString)
            ListBox1.Items.Add(" ")
            RadioButton6.Checked = False
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Items.Add(" ")
        Try
            If My.Computer.Network.Ping("www.google.com.br", 10) Then
                Label1.Text = "Conexão Online"
            Else
                PictureBox2.Visible = True
                Label1.Text = "Conexão Offine"
            End If
        Catch ex As Exception
            PictureBox2.Visible = False
            Label1.Text = "Conexão Offine"
        End Try

        Timer1.Enabled = True
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If My.Computer.Network.IsAvailable = True Then
                'conectado.
                Label1.Text = "Conexão Online"
                PictureBox2.Visible = False
            Else
                PictureBox2.Visible = True
                Label1.Text = "Conexão Offine"
            End If
        Catch ex As Exception
            PictureBox2.Visible = True
            Label1.Text = "Conexão Offine"
        End Try
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Try
            Dim a As String = System.Net.Dns.GetHostEntry(My.Settings.ipv).HostName
            ListBox1.Items.Add(a)
        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try
    End Sub

    Private Sub ResolverDNSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResolverDNSToolStripMenuItem.Click

    End Sub

    Private Sub ResetarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetarToolStripMenuItem.Click
        ListBox1.Items.Add("Aguardando dados...")
        Form3.Show()
    End Sub

    Private Sub TestarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestarToolStripMenuItem.Click
        Try
            If My.Computer.Network.Ping("www.google.com.br", 10) Then
                ListBox1.Items.Add("Conexão Online")
            Else
                PictureBox2.Visible = True
                ListBox1.Items.Add("Conexão Offine")
            End If
        Catch ex As Exception
            PictureBox2.Visible = False
            ListBox1.Items.Add("Conexão Offine")
        End Try
    End Sub
End Class
