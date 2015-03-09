Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports IS91.Services
Imports System.Drawing

Public Class SmartCardReader


    'Printer Helper
    Public Sub CustomPrintDocument(ByVal printContentBase64String As String, ByVal PrinterName As String)
        Try
            Dim objPS As New Printing.PageSettings
            PrinterName = objPS.PrinterSettings.PrinterName
            Dim SrcprintContentBase64String As String = IS91.Services.Common.Deserialize(printContentBase64String)
            PrintingHelper.SendStringToPrinter(PrinterName, SrcprintContentBase64String, Environment.MachineName & "_" & GetFileNameFromDate())
        Catch ex As Exception
            LogThis(ex)
            MsgBox("Printing Error. Please check your printer settings", Title:="ICMS Print Module")
        End Try
    End Sub


    'http://www.fredshack.com/docs/activex.html
    'Guru
    'ActiveX Class for Reading the Smart Card Device on the local machine and
    'intended to be used in a website or html page

    Const INVALID_SW1SW2 = -450
    Public isCardTypeACR38U As Boolean

    Dim retCode, Protocol, hContext, hCard, ReaderCount, nBytesRet As Long
    <VBFixedString(256)> Dim sReaderList As String = String.Empty
    Dim sReaderGroup As String = String.Empty
    Dim ConnActive, autoDet As Boolean
    Dim ioRequest As SCARD_IO_REQUEST
    Dim RdrState As SCARD_READERSTATE
    Dim SendLen, RecvLen As Long
    Dim SendBuff(0 To 255) As Byte
    Dim RecvBuff(0 To 255) As Byte
    Dim cbReaderText As String = String.Empty
    Dim CardTypeACR38U As Boolean

    Enum ReaderSelection
        Auto = 0
        Ask = 1
        Specific = 2
    End Enum

    Private Sub ClearBuffers()

        Dim index As Integer

        For index = 0 To 255
            RecvBuff(index) = &H0
            SendBuff(index) = &H0
        Next index

    End Sub

    Private Function TrimReaderList(ByVal item As String) As String

        Dim tmpstr() As String
        tmpstr = Split(item, vbNullChar, 5)
        Dim intx As Integer
        TrimReaderList = String.Empty

        For intx = 0 To UBound(tmpstr)
            If (tmpstr(intx) <> vbNullChar) And Trim(tmpstr(intx)) <> "" Then
                If (Asc(tmpstr(intx)) <> 0) Then
                    If intx = 0 Then
                        TrimReaderList = tmpstr(intx)
                    Else
                        TrimReaderList = TrimReaderList & vbNullChar & tmpstr(intx)
                    End If
                End If
            End If
        Next
        '     TrimReaderList = Join(tmpstr, Chr(167))
        '    TrimNull = Replace(item, " ", Chr(167))
        '    TrimNull = Replace(TrimNull, vbNullChar, " ")
        '    TrimNull = Replace(TrimNull, Chr(167), " ")
        Return Trim(TrimReaderList)
    End Function

    'guru
    Private Function GetAvailableReader(ByRef resultCount As Integer, ByVal xReaderSelectionType As ReaderSelection, Optional ByVal LookForindx As Integer = 0) As String


        sReaderList = StrDup(255, vbNullChar)
        ReaderCount = 255

        'Establish context
        retCode = SCardEstablishContext(SCARD_SCOPE_USER, 0, 0, hContext)

        If retCode <> SCARD_S_SUCCESS Then
            Call MsgBox(GetScardErrMsg(retCode))
            Return String.Empty
        End If

        ' 2. List PC/SC card readers installed in the system
        retCode = SCardListReaders(hContext, _
                                    sReaderGroup, _
                                    sReaderList, _
                                    ReaderCount)

        If retCode <> SCARD_S_SUCCESS Then
            Call MsgBox(GetScardErrMsg(retCode))
            Return String.Empty
        End If

        Dim sTemp() As String
        sTemp = Split(TrimReaderList(sReaderList), vbNullChar)
        resultCount = UBound(sTemp)

        'you have more readers to read from
        'but the caller has not passed correct details
        Select Case xReaderSelectionType
            Case ReaderSelection.Auto
                Return sTemp(0)
            Case ReaderSelection.Ask
                If resultCount < 1 Then
                    Return sTemp(0)
                End If

                Dim intx As Integer
                For intx = 0 To resultCount
                    If MsgBox("Do you want to read from " & sTemp(intx), vbYesNo) = vbYes Then
                        Return sTemp(intx)
                    End If
                Next
                Return sTemp(0)
            Case ReaderSelection.Specific
                Return sTemp(LookForindx)
        End Select
        Return String.Empty
    End Function


    Private Function Connect2Card() As Boolean

        Dim resultCount As Integer, LookForindx As Integer
        LookForindx = 0

        cbReaderText = GetAvailableReader(resultCount, ReaderSelection.Ask)

        If String.IsNullOrEmpty(cbReaderText) Then
            Return False
        End If

        Dim dwPrefProtocol As Long
        dwPrefProtocol = SCARD_PROTOCOL_T0 Or SCARD_PROTOCOL_T1

        Dim dwShareMode As Long
        dwShareMode = SCARD_SHARE_SHARED

        CardTypeACR38U = False
        If (InStr(UCase(cbReaderText), "ACS ACR38U") > 0) Then
            CardTypeACR38U = True
            '        dwPrefProtocol = 0
            '        dwShareMode = SCARD_SHARE_DIRECT
            Return True
        End If

        'Connect to reader using a shared connection
        retCode = SCardConnect(hContext, _
                               cbReaderText, _
                               dwShareMode, _
                               dwPrefProtocol, _
                               hCard, _
                               Protocol)

        If retCode <> SCARD_S_SUCCESS Then
            Call MsgBox(GetScardErrMsg(retCode))
            Return False
        Else
            Return True
            'Call MsgBox("Successful connection to " & cbReaderText)
        End If


    End Function

    Private Function AuthCard(ByVal Startb As Integer) As Boolean

        If CardTypeACR38U Then
            Return True
        End If

        Dim tempstr As String = String.Empty
        Dim index As Integer

        'Dim Startb As Integer
        'Startb = 1 'max "319"

        Call ClearBuffers()
        'Authentication command
        SendBuff(0) = &HFF                          'Class
        SendBuff(1) = &H86                          'INS
        SendBuff(2) = &H0                           'P1
        SendBuff(3) = &H0                           'P2
        SendBuff(4) = &H5                           'Lc
        SendBuff(5) = &H1                           'Byte 1 : Version number
        SendBuff(6) = &H0                           'Byte 2
        SendBuff(7) = Startb                        'Byte 3 : Block number

        SendBuff(8) = &H60                      'Byte 4 : Key Type A
        ' SendBuff(8) = &H61                      'Byte 4 : Key Type B

        SendBuff(9) = CInt("&H" & "0") 'Byte 5 : Key number

        SendLen = 10
        RecvLen = 2

        Dim outText1 As String = String.Empty
        Dim outText2 As String = String.Empty
        Dim outText3 As String = String.Empty

        retCode = SendAPDU(outText1, outText2, outText3)
        If retCode <> SCARD_S_SUCCESS Then
            Return False
        Else
            For index = 0 To RecvLen - 1
                tempstr = tempstr & Right$("00" & Hex(RecvBuff(index)), 2)
            Next index
            'Checking for response
            If tempstr = "9000" Then
                Return True
                'Call MsgBox("Authentication success")
            Else
                Return False
                Call MsgBox("Authentication failed")
            End If
        End If
    End Function

    Private Sub DisConnectCard()
        On Error Resume Next
        retCode = SCardDisconnect(hCard, SCARD_UNPOWER_CARD)
        retCode = SCardReleaseContext(hContext)
    End Sub


    Private Function ReadDefaultBlockSet(ByVal forBlock As Integer, ByVal blockSize As Integer) As Byte()
        Dim index As Integer
        Dim tempstr As String = String.Empty

        If blockSize > 16 Then
            blockSize = 16
        End If

        Call ClearBuffers()
        'Read Binary Block command
        SendBuff(0) = &HFF                              'Class
        SendBuff(1) = &HB0                              'INS
        SendBuff(2) = &H0                               'P1
        SendBuff(3) = CInt("&H" & forBlock) 'P2 : Block number
        SendBuff(4) = blockSize                  'Le : Number of bytes to read

        SendLen = 5
        RecvLen = blockSize + 2

        Dim outText1 As String = String.Empty
        Dim outText2 As String = String.Empty
        Dim outText3 As String = String.Empty

        retCode = SendAPDU(outText1, outText2, outText3)

        If retCode <> SCARD_S_SUCCESS Then
            Return Nothing
        Else
            For index = RecvLen - 2 To RecvLen - 1
                tempstr = tempstr & Right$("00" & Hex(RecvBuff(index)), 2)
            Next index
            'Check for response
            If tempstr = "9000" Then
                Return RecvBuff
            Else
                Call MsgBox("Read block error!")
            End If
        End If
        Return Nothing

    End Function

    Private Function WriteDefaultBlockSet(ByVal forBlock As Integer, ByVal wData As Byte()) As Boolean
        Dim index As Integer
        Dim tempstr As String = String.Empty

        Dim blockSize As Integer = 16

        Call ClearBuffers()
        'Read Binary Block command
        SendBuff(0) = &HFF                              'Class
        SendBuff(1) = &HD6                              'INS
        SendBuff(2) = &H0                               'P1
        SendBuff(3) = CInt("&H" & forBlock) 'P2 : Block number
        SendBuff(4) = blockSize                  'Le : Number of bytes to read

        Array.Copy(wData, 0, SendBuff, 5, wData.Length)

        SendLen = blockSize + 5
        RecvLen = &H2

        Dim outText1 As String = String.Empty
        Dim outText2 As String = String.Empty
        Dim outText3 As String = String.Empty

        retCode = SendAPDU(outText1, outText2, outText3)

        If retCode <> SCARD_S_SUCCESS Then
            Return False
        Else
            For index = RecvLen - 2 To RecvLen - 1
                tempstr = tempstr & Right$("00" & Hex(RecvBuff(index)), 2)
            Next index
            'Check for response
            If tempstr = "9000" Then
                Return True
            Else
                Call MsgBox("Write block error!")
            End If
        End If
        Return False

    End Function

    Private Sub WriteDefaultBlockData(ByVal wData As String)

        Dim BytesWriteCount As Integer
        Dim Bytes2Write() As Byte
        Dim BytesWritten As Integer
        Dim CurrentBlockNumber As Integer
        Dim CurrentBlockCapacity As Integer
        Dim index As Integer

        CurrentBlockNumber = 1
        wData = ASCIIEncoding.ASCII.GetString(BitConverter.GetBytes(Convert.ToInt16(wData.Length)), 0, 2) & wData
        Bytes2Write = ASCIIEncoding.ASCII.GetBytes(wData)
        BytesWriteCount = Bytes2Write.Length

        While (BytesWriteCount > 0)

            If ((CurrentBlockNumber + 1) Mod 4) = 0 Then
                CurrentBlockCapacity = 0
            Else
                CurrentBlockCapacity = 16
            End If

            If (CurrentBlockNumber = 1 Or (CurrentBlockNumber Mod 4) = 0) Then
                If Not AuthCard(CurrentBlockNumber) Then Return
            End If

            If CurrentBlockCapacity > 0 Then

                If BytesWriteCount < CurrentBlockCapacity Then
                    Dim BlockBytes2Write(BytesWriteCount - 1) As Byte
                    Array.Copy(Bytes2Write, BytesWritten, BlockBytes2Write, 0, BlockBytes2Write.Length)

                    WriteDefaultBlockSet(CurrentBlockNumber, BlockBytes2Write)
                    BytesWritten += BlockBytes2Write.Length
                Else
                    Dim BlockBytes2Write(CurrentBlockCapacity - 1) As Byte
                    Array.Copy(Bytes2Write, BytesWritten, BlockBytes2Write, 0, CurrentBlockCapacity)

                    WriteDefaultBlockSet(CurrentBlockNumber, BlockBytes2Write)
                    BytesWritten += CurrentBlockCapacity
                End If

                BytesWriteCount = BytesWriteCount - BytesWritten

            End If
            CurrentBlockNumber = CurrentBlockNumber + 1

        End While
        Return

    End Sub

    Private Function ReadDefaultBlockData() As String

        If CardTypeACR38U Then
            'call reader
            'check file
            'get/assign results
            Return String.Empty
        End If

        Dim BytesReadCount As Integer
        Dim BytesRead() As Byte
        Dim CurrentBlockNumber As Integer
        Dim CurrentBlockCapacity As Integer
        Dim DataStr As String = String.Empty
        Dim index As Integer

        CurrentBlockNumber = 1
        BytesRead = ReadDefaultBlockSet(1, 2)
        BytesReadCount = CInt(BytesRead(0)) + 2

        While (BytesReadCount > 0)

            If ((CurrentBlockNumber + 1) Mod 4) = 0 Then
                CurrentBlockCapacity = 0
            Else
                CurrentBlockCapacity = 16
            End If

            If (CurrentBlockNumber = 1 Or (CurrentBlockNumber Mod 4) = 0) Then
                If Not AuthCard(CurrentBlockNumber) Then Return String.Empty
            End If

            If CurrentBlockCapacity > 0 Then

                If BytesReadCount < CurrentBlockCapacity Then
                    BytesRead = ReadDefaultBlockSet(CurrentBlockNumber, BytesReadCount)
                Else
                    BytesRead = ReadDefaultBlockSet(CurrentBlockNumber, CurrentBlockCapacity)
                End If

                For index = 0 To RecvLen - 3
                    If CurrentBlockNumber = 1 Then
                        If index > 1 Then DataStr = DataStr & Right$(Chr(BytesRead(index)), 2)
                    Else
                        DataStr = DataStr & Right$(Chr(BytesRead(index)), 2)
                    End If
                Next index

                BytesReadCount = BytesReadCount - (RecvLen - 2)

            End If
            CurrentBlockNumber = CurrentBlockNumber + 1

        End While
        Return Replace(DataStr, Chr(0), "")

    End Function

    Private Function SendAPDU(ByRef outText1 As String, ByRef outText2 As String, ByRef outText3 As String) As Long

        Dim index As Integer
        Dim tempstr As String

        ioRequest.dwProtocol = Protocol
        ioRequest.cbPciLength = Len(ioRequest)

        tempstr = ""

        For index = 0 To SendLen - 1
            tempstr = tempstr & Right$("00" & Hex(SendBuff(index)), 2) & " "
        Next index

        outText1 = tempstr
        'Call MsgBox(tempstr)

        retCode = SCardTransmit(hCard, _
                                ioRequest, _
                                SendBuff(0), _
                                SendLen, _
                                ioRequest, _
                                RecvBuff(0), _
                                RecvLen)

        If retCode <> SCARD_S_SUCCESS Then
            outText2 = GetScardErrMsg(retCode)
            'Call MsgBox(GetScardErrMsg(retCode))
            Return retCode

        End If

        tempstr = ""

        For index = 0 To RecvLen - 1
            tempstr = tempstr & Right$("00" & Hex(RecvBuff(index)), 2) & " "
        Next index

        outText3 = tempstr
        'Call MsgBox(tempstr)
        Return retCode

    End Function

    'This Method writes Data String (upto 752 bytes) to the SmartCard from the device and
    'returns false if fails
    Public Function Write2SmartCard(ByVal SmartCardDataStr As String) As Boolean
        On Error Resume Next
        'Try


        Dim CardConnected As Boolean
        CardConnected = Connect2Card()
        If Not CardConnected Then
            Call DisConnectCard()
            Return False
        End If

        If Not AuthCard(1) Then
            Call DisConnectCard()
            MsgBox("Authentication Failure")
            Return String.Empty
        End If

        If CardTypeACR38U Then 'old card so no write operation supported
            Return False
        End If
        LogThis(String.Concat(DateTime.Now) + "(Before Write) : " + SmartCardDataStr)
        WriteDefaultBlockData(SmartCardDataStr)
        If Err.Number > 0 Then
            Return False
        End If
        LogThis(String.Concat(DateTime.Now) + "(After Write) : " + SmartCardDataStr)
        'Catch ex As Exception
        '    LogThis(ex)
        'End Try
        Return True

    End Function
    Public Function IsCardConnected() As Boolean
        On Error Resume Next
        Dim CardConnected As Boolean
        Return CardConnected = Connect2Card()

    End Function

    'This Method reads the SmartCard Data from the device and
    'returns the stored data as String
    Public Function ReadSmartCardDataStr() As String

        On Error Resume Next

        Dim CardConnected As Boolean

        CardConnected = Connect2Card()
        If Not CardConnected Then
            Call DisConnectCard()
            Return String.Empty
        End If

        isCardTypeACR38U = CardTypeACR38U

        'For "ACS ACR38U 0"
        If CardTypeACR38U Then

            If File.Exists("c:\BGCCARD\Success.txt") Then Kill("c:\BGCCARD\Success.txt")
            If File.Exists("c:\BGCCARD\Read.txt") Then Kill("c:\BGCCARD\Read.txt")

            ShellandWait("c:\BGCCARD\read.exe", "", 0, ProcessWindowStyle.Hidden)

            If File.Exists("c:\BGCCARD\Success.txt") Then
                'Success
                Dim sContent As String = Trim(File.ReadAllText("c:\BGCCARD\Read.txt"))

                If String.IsNullOrEmpty(sContent) Then
                    MsgBox("Could not read the card! Please try again.")
                    Return String.Empty
                Else
                    Return Trim(Split(sContent, "~")(14))
                End If

            Else
                MsgBox("Could not read the card! Please try again.")
                Return String.Empty
            End If
        End If

        If Not AuthCard(1) Then
            Call DisConnectCard()
            MsgBox("Authentication Failure")
            Return String.Empty
        End If

        Return ReadDefaultBlockData()

    End Function


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Call DisConnectCard()
    End Sub
End Class
