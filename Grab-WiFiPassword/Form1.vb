Public Class Form1
    Const Quote As String = """"

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()


    End Sub

    Private Sub Grab()
        Dim Proc As New Process()
        With Proc.StartInfo
            .FileName = "cmd.exe"
            .Arguments = "/c for /f " & Quote & "skip=9 tokens=1,2 delims=:" & Quote & " %i in ('netsh wlan show profiles') do @echo %j | findstr -i -v echo | netsh wlan show profiles %j key=clear"
            .UseShellExecute = False
            .CreateNoWindow = True
            .RedirectStandardOutput = True
            .RedirectStandardError = True
        End With
        Proc.Start()
        While Not Proc.StandardOutput.EndOfStream
            rtbProfile.AppendText(Proc.StandardOutput.ReadLine() & vbNewLine)
        End While
        Proc.WaitForExit()
    End Sub

    Private Sub StartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartToolStripMenuItem.Click
        'rtbProfile.AppendText("for /f " & Quote & "skip=9 tokens=1,2 delims=:" & Quote & " %i in ('netsh wlan show profiles') do @echo %j | findstr -i -v echo | netsh wlan show profiles %j key=clear")
        Grab()
    End Sub
End Class
