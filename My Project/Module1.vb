Imports System.Windows.Forms
Imports System.IO

Module Module1
    Private objProcessCompleted As Boolean
    Private WithEvents objProcess As System.Diagnostics.Process

    Public Function ShellandWait(ByVal Appfile As String, ByVal CommandLineArguments As String, ByRef objProcessExitCode As Integer, Optional ByVal Windstyle As ProcessWindowStyle = ProcessWindowStyle.Hidden, Optional ByVal RedirectStandardOutput As Boolean = False) As String
        If Trim(Path.GetExtension(Appfile)).ToLower().EndsWith("msi") Then
            '  "msiexec /i {msi path} /norestart /quiet"
            CommandLineArguments = String.Format(CommandLineArguments, """" & Appfile & """")
            Appfile = "msiexec.exe"
        End If
        Dim StrResultOut As String = String.Empty
        objProcessCompleted = False
        Try
            objProcess = New System.Diagnostics.Process
            objProcess.StartInfo.FileName = Appfile
            objProcess.StartInfo.Arguments = CommandLineArguments
            objProcess.StartInfo.WindowStyle = Windstyle
            If RedirectStandardOutput Then
                objProcess.StartInfo.RedirectStandardOutput = True
                objProcess.StartInfo.UseShellExecute = False
                objProcess.StartInfo.CreateNoWindow = True
            Else
                objProcess.StartInfo.RedirectStandardOutput = False
                objProcess.StartInfo.UseShellExecute = True
            End If
            objProcess.EnableRaisingEvents = True
            ' LogThis("WaitForExit - start " & Appfile & " " & CommandLineArguments)
            objProcess.Start()

            'objProcess.WaitForExit()
            'max 60 minutes
            Dim startTime As DateTime = Now
            Do While Not objProcessCompleted
                If Now > startTime.AddMinutes(60) Then
                    Exit Do
                End If
                Application.DoEvents()
                Threading.Thread.Sleep(100)
            Loop

            If RedirectStandardOutput Then
                Dim myStreamReader As StreamReader = objProcess.StandardOutput
                If Not IsNothing(myStreamReader) Then StrResultOut = myStreamReader.ReadToEnd()
            End If
            objProcessExitCode = objProcess.ExitCode
            'Free resources associated with this process
            ' LogThis("WaitForExit - end with ExitCode=" & objProcess.ExitCode.ToString() & " for " & Appfile & " " & CommandLineArguments)
            objProcess.Close()

        Catch ex As Exception
            'LogThis(ex, Appfile, CommandLineArguments)
            Throw
        Finally
            objProcessCompleted = False
            If Not objProcess Is Nothing Then
                objProcess = Nothing
            End If
        End Try
        Debug.Print(StrResultOut)
        Return StrResultOut
    End Function

    Private Sub objProcess_Exited(ByVal sender As Object, ByVal e As System.EventArgs) Handles objProcess.Exited
        objProcessCompleted = True
    End Sub
End Module
