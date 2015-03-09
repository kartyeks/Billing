Option Strict Off
Imports System
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports IS91.Services
Imports System.Drawing

Public Class SmartCardReader
    Dim G_Cancel As Boolean
    Dim G_BlockNum As Byte
    Dim G_ReadType As String
    Dim G_dout(15) As Byte
    Dim BLCK As Byte
    Dim TempStr As String
    Dim G_rHandle As Integer
    Dim G_retcode As Integer
    Dim G_SID As Byte
    Dim G_Sec As Integer
    Dim G_pKey(5) As Byte

    'Printer Helper
    Public Sub CustomPrintDocument(ByVal printContentBase64String As String, ByVal PrinterName As String)
        Try
            Dim objPS As New Printing.PageSettings
            PrinterName = objPS.PrinterSettings.PrinterName
            Dim SrcprintContentBase64String As String = CStr(IS91.Services.Common.Deserialize(printContentBase64String))
            '  PrintingHelper.SendStringToPrinter(PrinterName, SrcprintContentBase64String, Environment.MachineName & "_" & GetFileNameFromDate())
        Catch ex As Exception
            '  LogThis(ex)
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

        Dim FirmwareVer(30) As Byte
        Dim infolen As Byte
        Dim FirmStr As String
        Dim ctr As Integer
        Dim FirmwareVer1(20) As Byte
        Dim ReaderStat As ACR120U.tReaderStatus

        'ACR120U.ACR120_Reset(G_rHandle)
        'Start of Routine
        G_rHandle = ACR120U.ACR120_Open(0)

        'Check if Handle is Valid
        If G_rHandle < 0 Then

            Return False
        Else


            'Get the DLL version the program is using
            'G_retcode = ACR120U.ACR120_RequestDLLVersion(infolen, FirmwareVer(0))

            'FirmStr = ""

            'For ctr = 0 To infolen - 1

            '    FirmStr = FirmStr + Chr(FirmwareVer(ctr))

            'Next


            ''Routine to get the firmware version.
            'G_retcode = ACR120U.ACR120_Status(G_rHandle, FirmwareVer1(0), ReaderStat)

            'FirmStr = ""

            'For ctr = 0 To infolen - 1
            '    If FirmwareVer1(ctr) <> 0 And FirmwareVer1(ctr) <> &HFF Then

            '        FirmStr = FirmStr + Chr(FirmwareVer1(ctr))

            '    End If
            'Next
            Dim ResultSN(11) As Byte
            Dim ResultTag As Byte
            Dim TagType(50) As Byte

            G_retcode = ACR120U.ACR120_Select(G_rHandle, TagType(0), ResultTag, ResultSN(0))
            If G_retcode < 0 Then
                Return False
            End If
           
            End If
            Return True
    End Function

    Private Function AuthCard(ByVal Startb As Integer) As Boolean


        Dim ResultSN(11) As Byte
        Dim ResultTag As Byte
        Dim TagType(50) As Byte

        G_retcode = ACR120U.ACR120_Select(G_rHandle, TagType(0), ResultTag, ResultSN(0))
        If G_retcode < 0 Then
            Return False
        End If

        G_Sec = 2
        Dim G_PhysicalSector As Integer = 2
        Dim G_vKeyType As Byte = ACR120U.KEYTYPES.ACR120_LOGIN_KEYTYPE_DEFAULT_F
        Dim G_StoredNum As Integer = 0
        'Dim G_pKey(6) As Byte
        'G_pKey(0) = &H1
        'G_pKey(1) = &H2
        'G_pKey(2) = &H3
        'G_pKey(3) = &H4
        'G_pKey(4) = &H5
        'G_pKey(5) = &H6
        'G_pKey(6) = &H7

        G_retcode = ACR120U.ACR120_Login(G_rHandle, &H2, G_vKeyType, 0, Nothing)
        If G_retcode < 0 Then
            Return False
        End If
        Return True
    End Function

    Private Sub DisConnectCard()
        On Error Resume Next
        G_retcode = ACR120U.ACR120_Close(G_rHandle)
        'retCode = SCardDisconnect(hCard, SCARD_UNPOWER_CARD)
        'retCode = SCardReleaseContext(hContext)
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

    Private Function WriteDefaultBlockData(ByVal wData As String) As Boolean
        Dim BLCK As Byte


       
        'If (wData.Length > 16) Then
        Dim arr As Integer = wData.Length / 16
        Dim k As Integer
        For k = 1 To arr
            Dim I As Int32
            BLCK = CByte("&H0" & k)
            Dim strWd As String = wData.Substring((k - 1) * 16, IIf((wData.Length - (k - 1) * 16) > 16, 16, (wData.Length - (k - 1) * 16)))
            Dim charArray As Char() = strWd.ToCharArray()

            If G_Sec > 31 Then
                BLCK = ((G_Sec - 32) * 16) + 128 + BLCK
            Else
                BLCK = G_Sec * 4 + BLCK
            End If

            G_BlockNum = BLCK
            G_ReadType = "ASC"
            ReDim G_dout(15)
            For I = 0 To charArray.Length - 1
                G_dout(I) = Convert.ToByte(charArray(I))
            Next

            G_retcode = ACR120U.ACR120_Write(G_rHandle, G_BlockNum, G_dout(0))
            If G_retcode < 0 Then
                Return False
            End If
        Next
        'End If

        Return True
    End Function

    Private Function ReadDefaultBlockData() As String

        Dim dataRead(15) As Byte
        Dim dStr As String
        Dim tmpStr As String
        Dim ctr As Byte
        dStr = ""
        tmpStr = ""
        'Show frmReadBlock
        Dim k As Integer
        For k = 1 To 2
            Dim I As Int32
            BLCK = CByte("&H0" & k)

            If G_Sec > 31 Then
                BLCK = ((G_Sec - 32) * 16) + 128 + BLCK
            Else
                BLCK = G_Sec * 4 + BLCK
            End If

            G_BlockNum = BLCK
            G_ReadType = "ASC"
            ReDim dataRead(15)
            'read specified block
            G_retcode = ACR120U.ACR120_Read(G_rHandle, G_BlockNum, dataRead(0))

            'check if retcode is error
            If G_retcode < 0 Then
                Return G_retcode
            End If
            tmpStr = ""
            For ctr = 0 To 15
                If dataRead(ctr) <> 0 Then
                    tmpStr = tmpStr + Chr(dataRead(ctr))
                End If
            Next
            If tmpStr = "" Then
                Return dStr
            End If
            dStr = dStr + tmpStr
        Next
        'convert bytes read to chosen option (e.g. AS HEX, AS ASCII)
       
        Return dStr

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
            Return False
        End If

       
        LogThis(String.Concat(DateTime.Now) + "(Before Write) : " + SmartCardDataStr)

        If Not WriteDefaultBlockData(SmartCardDataStr) Then
            G_retcode = ACR120U.ACR120_Close(G_rHandle)
            Return False
        End If
        LogThis(String.Concat(DateTime.Now) + "(After Write) : " + SmartCardDataStr)

        G_retcode = ACR120U.ACR120_Close(G_rHandle)
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

       

        If Not AuthCard(1) Then
            Call DisConnectCard()
            MsgBox("Authentication Failure")
            Return String.Empty
        End If

        Dim Str As String = ReadDefaultBlockData()
        G_retcode = ACR120U.ACR120_Close(G_rHandle)
        Return Str
    End Function


    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Call DisConnectCard()
    End Sub

End Class
