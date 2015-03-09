Imports System.Windows.Forms
Imports System.Web
Imports System.Security.Permissions
Imports System.Xml
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Imports System.Drawing.Printing

Public Class POSControl
    'Public WindowObject As HTMLWindow2Class
    Public WindowObject As Object
    Private bln As Boolean = False
    Dim blnValidItem As Boolean = True
    Public isCardTypeACR38U As Boolean 'for smartcard reader
    Dim blnEnter As Boolean = False
    Dim blnNewBill As Boolean = True
    Dim blnMemberValid As Boolean = False
    Dim blnBCancel As Boolean = False
    'Public blnPopup As Boolean = False
    Dim dvLst As DataView
    Public Function ReadSmartCardDataStr() As String 'for smartcard reader
        Dim memId As String
        Dim SCR As New SmartCardReader()
        memId = SCR.ReadSmartCardDataStr()
        isCardTypeACR38U = SCR.isCardTypeACR38U

        Return memId
    End Function


    Private Sub btnMember_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.System))
    End Sub

    Private Sub txtAccNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccNo.KeyDown

        Try
            If e.KeyCode = Windows.Forms.Keys.F2 Then
                WindowObject.execScript("onMemberPoup()")
                Exit Sub
            End If

            If e.KeyCode = Windows.Forms.Keys.Tab Or e.KeyCode = Keys.Enter Then
                ' WindowObject.document.all.item("hdnmemberid").value = ""
                WindowObject.document.all.item("hdnBillDate").value = dtBillDate.Value.ToString("dd/MM/yyyy HH:mm")
                If WindowObject.document.all.item("hdnCashCard").value = "true" Then
                    WindowObject.execScript("OnAccountChange('" + Replace(WindowObject.document.all.item("hdnMemberId").value, "\", "\\") + "', false)")
                Else
                    WindowObject.execScript("OnAccountChange('" + Replace(txtAccNo.Text, "\", "\\") + "', true)") 'using a/c no get the member details
                End If

                'If Not blnMemberValid Then Exit Sub
                'MsgBox(blnMemberValid)
                If e.KeyCode = Keys.Enter And blnMemberValid Then
                    blnEnter = True
                    txtOTNo.Focus()
                End If
            End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try

    End Sub
    Public Sub LoadTableInfo()
        On Error GoTo ErrProc
        Me.Focus()
        Dim arr As ArrayList
        Dim strTable As String
        If WindowObject.document.all.item("hdnEnableAccFld").value = "false" Then
            txtAccNo.Enabled = False
        End If
        If WindowObject.document.all.item("hdnEditOnlyAcNo").value = "true" Then
            LockControls()
            txtAccNo.Enabled = True
            ' tblBillCancel.Visible = True
            tblFinalize.Text = "Post(F7)"
            'tblFinalize.Enabled = False
        End If
        If WindowObject.document.all.item("hdnUser").Value = "1" Then
            Me.dtBillDate.Enabled = True
        Else
            Me.dtBillDate.Enabled = False
        End If
        strTable = WindowObject.document.all.item("hdnTableXML").value
        If strTable = "" Then
            Exit Sub
        End If

        Dim ar() As String = strTable.Split(",")
        Dim arrTable() As String
        Dim i As Int32 = 0
        Dim dtLst As New DataTable
        dtLst.Columns.Add(New DataColumn("TableID", Type.GetType("System.String")))
        dtLst.Columns.Add(New DataColumn("TableName", Type.GetType("System.String")))
        dtLst.PrimaryKey = New DataColumn() {dtLst.Columns(0)}
        Dim dr As DataRow = Nothing
        For Each Str As String In ar
            arrTable = Str.Split("-")
            If arrTable.Length > 1 Then
                '  cmbTable.Items.Add(New LstVal(arrTable(1), arrTable(0)))
                dr = dtLst.NewRow()
                dr(0) = arrTable(0)
                dr(1) = arrTable(1)
                dtLst.Rows.Add(dr)
            End If
        Next
        If Not dtLst Is Nothing Then
            dvLst = dtLst.DefaultView
            dvLst.Sort = "TableID"
        End If
        cmbTable.DataSource = dvLst
        cmbTable.DisplayMember = "TableName"
        cmbTable.ValueMember = "TableID"
        If cmbTable.Items.Count > 0 Then
            cmbTable.SelectedIndex = 0
        End If


        Dim bDate As Date
        Date.TryParseExact(WindowObject.document.all.item("hdnBillDate").value, "dd/MM/yyyy HH:mm", Nothing, Globalization.DateTimeStyles.None, bDate)
        Me.dtBillDate.Value = bDate
ErrProc:
        IS91.Services.Logger.LogThis(Err.GetException())
        Err.Clear()
        ' Resume Next
    End Sub
    Public Sub LoadMemberDetails()
        On Error GoTo ErrProc
        If WindowObject.document.all.item("hdnMemValid").value <> "0" Then
            txtAccNo.Focus()
            blnEnter = False
            WindowObject.document.all.item("hdnMemValid").value = "0"
            Exit Sub
        End If

        If WindowObject.document.all.item("hdnType").value = "dash" Then
            tblPost.Visible = False
            tblClear.Visible = False
            tblViewm.Visible = False
            tblReadcard.Visible = False
        Else
            tblPost.Visible = True
            tblClear.Visible = True
            tblViewm.Visible = True
            tblReadcard.Visible = True
        End If
        'MsgBox(WindowObject.document.all.item("hdnMemberAvailable").value)
        If WindowObject.document.all.item("hdnMemberAvailable").value = "false" Then
            blnMemberValid = False
            Exit Sub
        End If
        blnMemberValid = True
        If WindowObject.document.all.item("hdnMode").value <> "edit" And WindowObject.document.all.item("hdnMode").value <> "medit" Then
            Dim bDate As Date
            Date.TryParseExact(WindowObject.document.all.item("hdnBillDate").value, "dd/MM/yyyy HH:mm", Nothing, Globalization.DateTimeStyles.None, bDate)
            Me.dtBillDate.Value = bDate
        End If
        Me.label3.Text = WindowObject.document.all.item("hdnmyContrlName").value 'member name
        Me.label6.Text = WindowObject.document.all.item("hdnmyControlType").value 'member type
        ' Me.label7.Text = WindowObject.document.all.item("hdnmyControlAddr").value 'member addr
        Me.label8.Text = WindowObject.document.all.item("hdnmyContrlBalance").value  'member balance amt
        If WindowObject.document.all.item("hdnCashCard").value = "true" Then
            Me.txtAccNo.Text = "CashCard"
            If WindowObject.document.all.item("hdnDayCard").value = "true" Then
                Me.txtAccNo.Text = "DayCard"
            End If
        ElseIf WindowObject.document.all.item("hdnClubAcc").value = "true" Then
            Me.txtAccNo.Text = "CLUB A\C"
        Else
            Me.txtAccNo.Text = WindowObject.document.all.item("hdnmyControlCode").value 'member a/c no
        End If
        'WindowObject.document.all.item("hdnOldMemberAcc").value = Me.txtAccNo.Text
        'WindowObject.document.all.item("hdnOldMemberId").value = WindowObject.document.all.item("hdnMemberId").value
        'If WindowObject.document.all.item("hdnEditOnlyAcNo").value = "true" Then
        '    tblFinalize.Enabled = True
        'End If
        If WindowObject.document.all.item("hdnBillNo").value <> "" Then
            Me.lblBillNoDisplay.Text = WindowObject.document.all.item("hdnBillNo").value
        End If
        'Me.pictureBox1.ImageLocation = "http://localhost/ICMS2010/ImageHandler.ashx?mode=1&mid=" & Me.WindowObject.hdnMemberId.value
        'MsgBox(pictureBox1.ImageLocation)
        'MsgBox(Me.WindowObject.hdnphoto.value)
        If WindowObject.document.all.item("hdnTableID").value <> "" Then
            ' cmbTable.SelectedValue = WindowObject.document.all.item("hdnTableID").value
            SelectTable(WindowObject.document.all.item("hdnTableID").value)
        End If
        If WindowObject.document.all.item("hdnphoto").value <> "" Then
            Dim strm As IO.Stream = IS91.Services.Common.StreamFromBytes(IS91.Services.Common.BytesFromB64String(WindowObject.document.all.item("hdnphoto").value))
            Dim im As Image = New Bitmap(Image.FromStream(strm, True, True))
            pictureBox1.Image = im
            pictureBox1.Refresh()
            pictureBox1.Show()
            pictureBox1.Select()
        End If
        If WindowObject.document.all.item("hdnphoto1").value <> "" Then
            Dim strm As IO.Stream = IS91.Services.Common.StreamFromBytes(IS91.Services.Common.BytesFromB64String(WindowObject.document.all.item("hdnphoto1").value))
            Dim im As Image = New Bitmap(Image.FromStream(strm, True, True))
            PictureBox2.Image = im
            PictureBox2.Refresh()
            PictureBox2.Show()
            PictureBox2.Select()
        End If
        If WindowObject.document.all.item("hdnphoto2").value <> "" Then
            Dim strm As IO.Stream = IS91.Services.Common.StreamFromBytes(IS91.Services.Common.BytesFromB64String(WindowObject.document.all.item("hdnphoto2").value))
            Dim im As Image = New Bitmap(Image.FromStream(strm, True, True))
            PictureBox3.Image = im
            PictureBox3.Refresh()
            PictureBox3.Show()
            PictureBox3.Select()
        End If
        If WindowObject.document.all.item("hdnphoto3").value <> "" Then
            Dim strm As IO.Stream = IS91.Services.Common.StreamFromBytes(IS91.Services.Common.BytesFromB64String(WindowObject.document.all.item("hdnphoto3").value))
            Dim im As Image = New Bitmap(Image.FromStream(strm, True, True))
            PictureBox4.Image = im
            PictureBox4.Refresh()
            PictureBox4.Show()
            PictureBox4.Select()
        End If
        If WindowObject.document.all.item("hdnphoto4").value <> "" Then
            Dim strm As IO.Stream = IS91.Services.Common.StreamFromBytes(IS91.Services.Common.BytesFromB64String(WindowObject.document.all.item("hdnphoto4").value))
            Dim im As Image = New Bitmap(Image.FromStream(strm, True, True))
            PictureBox5.Image = im
            PictureBox5.Refresh()
            PictureBox5.Show()
            PictureBox5.Select()
        End If
        'If WindowObject.document.all.item("hdnTempBillAvailable").value = "true" Then
        '    tblFinalize.Enabled = False
        'End If
        If blnEnter Then
            txtOTNo.Focus()
            blnEnter = False
        End If
        'MsgBox(String.Concat(cmbTable.SelectedValue))
        'MsgBox(String.Concat(cmbTable.SelectedText))
        'MsgBox(String.Concat(cmbTable.SelectedIndex))

        'MsgBox(String.Concat(CType(cmbTable.SelectedItem, DataRowView)("TableID")))
        'MsgBox(String.Concat(cmbTable.Text))

        Exit Sub

ErrProc:
        IS91.Services.Logger.LogThis(Err.GetException())
        Err.Clear()
        Resume Next
    End Sub
    Public Sub ClearMemberDetails(ByVal bln As Boolean)

        Try

            'if member validation is false then clear the controls
            Me.label3.Text = ""
            Me.label6.Text = ""
            ' Me.label7.Text = ""
            Me.label8.Text = ""
            Me.txtAccNo.Text = ""
            WindowObject.document.all.item("hdnMemberId").value = ""
            WindowObject.document.all.item("hdnMember").value = ""
            WindowObject.document.all.item("hdnTableID").value = ""
            WindowObject.document.all.item("hdnMemberCode").value = ""
            WindowObject.document.all.item("hdnMemberAvailable").value = "false"
            WindowObject.document.all.item("hdnOldMemberAcc").value = ""
            WindowObject.document.all.item("hdnOldMemberId").value = ""
            If Not pictureBox1.Image Is Nothing Then
                pictureBox1.Image.Dispose()
                pictureBox1.Image = Nothing
                cmbTable.SelectedIndex = -1
                pictureBox1.Refresh()
            End If
            If Not PictureBox2.Image Is Nothing Then
                PictureBox2.Image.Dispose()
                PictureBox2.Image = Nothing
                ' cmbTable.SelectedIndex = -1
                PictureBox2.Refresh()
            End If
            If Not PictureBox3.Image Is Nothing Then
                PictureBox3.Image.Dispose()
                PictureBox3.Image = Nothing
                ' cmbTable.SelectedIndex = -1
                PictureBox3.Refresh()
            End If
            If Not PictureBox4.Image Is Nothing Then
                PictureBox4.Image.Dispose()
                PictureBox4.Image = Nothing
                ' cmbTable.SelectedIndex = -1
                PictureBox4.Refresh()
            End If
            If Not PictureBox5.Image Is Nothing Then
                PictureBox5.Image.Dispose()
                PictureBox5.Image = Nothing
                ' cmbTable.SelectedIndex = -1
                PictureBox5.Refresh()
            End If
            'MsgBox(blnMemberValid)
            blnMemberValid = False
            If bln Then
                Me.Focus()
                txtAccNo.Focus()
            End If


        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)

        End Try
    End Sub

    Private Sub txtStewCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtStewCode.KeyDown

        Try
            If e.KeyCode = Windows.Forms.Keys.F2 Then
                WindowObject.execScript("onStewardPoup()")
                Exit Sub
            End If

            If e.KeyCode = Windows.Forms.Keys.Tab Or e.KeyCode = Keys.Enter Then
                WindowObject.document.all.item("hdnStewardID").value = ""
                'WindowObject.execScript("OnStewCode('" + txtStewCode.Text + "')") 'get stewcode id
                ProcessStewardDetails()
                If e.KeyCode = Keys.Enter Then
                    blnEnter = True
                End If
            End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub
    Public Sub ClearStewCode()

        Try

            Me.txtStewCode.Text = ""
            lblstewnamedisplay.Text = ""
            WindowObject.document.all.item("hdnStewName").value = ""
            WindowObject.document.all.item("hdnStewardID").value = ""
            WindowObject.document.all.item("hdnSaveXml").value = ""
            WindowObject.document.all.item("hdnStewCode").value = ""
            Me.Focus()
            txtStewCode.Focus()
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub
    Public Sub LoadStewInfo()

        Try
            txtStewCode.Text = WindowObject.document.all.item("hdnStewCode").value
            lblstewnamedisplay.Text = WindowObject.document.all.item("hdnStewName").value 'by qty cell click calculate amt and display
            If blnEnter Then
                cmbTable.Focus()
            End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Private Sub grdBilling_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles grdBilling.CellBeginEdit
        lblItem.Visible = False
        If e.ColumnIndex <> 1 Then
            If Not blnValidItem Then
                If Me.grdBilling.CurrentRow Is Nothing Then Exit Sub
                Me.grdBilling.ClearSelection()
                Me.grdBilling.CurrentCell = Me.grdBilling.CurrentRow.Cells(1)
                Me.grdBilling.CurrentCell.Value = ""
                Me.grdBilling.CurrentRow.Cells(2).Value = ""
                Me.grdBilling.CurrentRow.Cells(3).Value = ""
                Me.grdBilling.CurrentRow.Cells(4).Value = ""
                Me.grdBilling.CurrentCell.Selected = True
                'Me.grdBilling.BeginEdit(False)
                '                SendKeys.Send("{F2}")

                'blnValidItem = True
            End If
        End If
        blnValidItem = True
        If Me.txtOTNo.Text = "" Then
            MsgBox("Enter OT Number")
            Me.grdBilling.CurrentRow.Cells(1).Value = ""
            Me.grdBilling.CurrentRow.Cells(2).Value = ""
            Me.grdBilling.CurrentRow.Cells(3).Value = ""
            Me.grdBilling.CurrentRow.Cells(4).Value = ""
            Me.Focus()
            grdBilling.ClearSelection()
            grdBilling.CurrentRow.Selected = False
            grdBilling.CurrentCell.Selected = False
            grdBilling.CurrentCell = Nothing
            Me.txtOTNo.Focus()
            Exit Sub
        End If
        If e.ColumnIndex = 1 Then
            lblItem.Visible = True
        End If
    End Sub

    Private Sub grdBilling_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBilling.CellClick
        'If Me.txtOTNo.Text = "" Then
        '    MsgBox("Enter OT Number")
        '    Me.grdBilling.CurrentCell.Selected = False
        '    Me.txtOTNo.Focus()
        '    Exit Sub

        'End If
    End Sub


    Private Sub grdBilling_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBilling.CellEndEdit

        Try
            If e.ColumnIndex = 1 Then
                If txtOTNo.Text <> "" Then
                

                    If WindowObject.document.all.item("hdnBAR").value = "true" Then
                        WindowObject.execScript("OTExists('" + txtOTNo.Text + "','" + WindowObject.document.all.item("hdnBillId").value + "')")
                        If WindowObject.document.all.item("hdnOTExists").value = "true" Then
                            Me.grdBilling.CurrentRow.Cells(1).Value = ""
                            Me.grdBilling.CurrentRow.Cells(5).Selected = False
                            'WindowObject.document.all.item("hdnOTExists").value = "false"
                            txtOTNo.Focus()
                            Exit Sub
                        End If
                    End If
                End If

                Me.grdBilling.CurrentRow.Cells(0).Value = Me.txtOTNo.Text
                'GetItems(grdBilling.CurrentCell.Value)
                ProcessItemDetails(grdBilling.CurrentCell.Value)
                'Me.grdBilling.CurrentRow.Cells(5).Selected = True
                'grdBilling.CurrentRow.Cells(5).Value = ""
            ElseIf e.ColumnIndex = 5 Then
                If (Me.grdBilling.CurrentRow.Cells(5).Value <> "") Then
                    'WindowObject.execScript("OnQty('" + grdBilling.CurrentCell.Value + "','" + Me.grdBilling.CurrentRow.Cells(4).Value + "')") 'on qty cell click
                    'Dim dblVal As Double = Math.Round(Val(grdBilling.CurrentCell.Value) * Val(Me.grdBilling.CurrentRow.Cells(4).Value), 2)
                    Dim dblVal As Double = Val(grdBilling.CurrentCell.Value) * Val(Me.grdBilling.CurrentRow.Cells(4).Value)
                    Dim blnDec As Boolean = False
                    If dblVal - Math.Floor(dblVal) > 0 Then
                        blnDec = True
                    End If
                    Me.grdBilling.CurrentRow.Cells(6).Value = dblVal 'IIf(blnDec, dblVal, Math.Round(dblVal))

                    'Me.grdBilling.CurrentRow.Cells(6).Value = IIf(blnDec, dblVal, Math.Round(dblVal))

                End If
            End If

        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Private Sub grdBilling_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBilling.CellEnter
        If e.ColumnIndex = 1 Then
            lblItem.Visible = True
        End If

        'grdBilling.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2
        'If e.ColumnIndex <> 1 Then
        '    If Not blnValidItem Then
        '        '  Me.grdBilling.blnNav = False
        '        blnValidItem = True
        '        grdBilling.CurrentCell = grdBilling.CurrentRow.Cells(1)
        '        grdBilling.CurrentCell.Selected = True
        '        '       grdBilling.EditMode = DataGridViewEditMode.EditOnEnter

        '        Exit Sub
        '    End If
        '    Me.grdBilling.blnNav = True
        'End If
    End Sub

    Private Sub grdBilling_CellLeave(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdBilling.CellLeave
        lblItem.Visible = False
        ' Try
        '    If e.ColumnIndex = 6 Then
        '        If Me.grdBilling.CurrentRow.Cells(2).Value <> "" Then
        '            If Me.grdBilling.CurrentRow.Cells(5).Value = "" Then
        '                MsgBox("Enter Quantity")
        '                Me.Focus()
        '                If Me.grdBilling.CurrentRow Is Nothing Then Exit Sub
        '                Me.grdBilling.ClearSelection()
        '                Me.grdBilling.CurrentCell = Me.grdBilling.CurrentRow.Cells(5)
        '                Me.grdBilling.CurrentCell.Value = ""
        '                Me.grdBilling.CurrentCell.Selected = True
        '                Exit Sub
        '            End If
        '            'Else
        '            'Me.grdBilling.CurrentRow.Cells(1).Selected = True
        '        End If

        '    End If

        'Catch ex As Exception
        '    IS91.Services.Logger.LogThis(ex)
        'End Try
    End Sub
    Public Sub InvalidItems()

        Try
            blnValidItem = False
            WindowObject.execScript("blnPopup=false;")
            '            blnPopup = False
            'Me.grdBilling.blnNav = False
            'MsgBox(grdBilling.CurrentCell.ColumnIndex)
            'Me.grdBilling.CurrentCell = Me.grdBilling.CurrentRow.Cells(1)
            'Me.grdBilling.CurrentCell.Value = ""
            'Me.grdBilling.CurrentRow.Cells(2).Value = ""
            'Me.grdBilling.CurrentRow.Cells(3).Value = ""
            'Me.grdBilling.CurrentRow.Cells(4).Value = ""
            'Me.grdBilling.CurrentCell.Selected = True
            'Me.grdBilling.BeginEdit(False)
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

   
 

    Private Sub grdBilling_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdBilling.KeyDown

        Try
            'If Me.txtOTNo.Text = "" Then
            '    MsgBox("Enter OT Number")
            '    grdBilling.CurrentRow.Selected = False
            '    grdBilling.CurrentCell.Selected = False
            '    grdBilling.CurrentCell = Nothing
            '    Me.txtOTNo.Focus()
            '    Exit Sub
            'End If

            If Me.grdBilling.CurrentRow.Cells(1).Selected = True Then
                If e.KeyCode = Windows.Forms.Keys.F10 Then

                    If txtOTNo.Text <> "" Then
                        WindowObject.execScript("OTExists('" + txtOTNo.Text + "','" + WindowObject.document.all.item("hdnBillId").value + "')")
                        If WindowObject.document.all.item("hdnOTExists").value = "true" Then
                            txtOTNo.Focus()
                            Exit Sub
                        End If
                    End If

                    Me.grdBilling.CurrentRow.Cells(0).Value = Me.txtOTNo.Text
                    '                    blnPopup = True
                    WindowObject.execScript("ItemPoup()")
                    Exit Sub
                End If
            End If
            'If Me.grdBilling.CurrentRow.Cells(5).Selected = True Then
            '    If e.KeyCode < 49 Or e.KeyCode > 57 Then
            '        Me.grdBilling.CurrentRow.Cells(5).Value = ""
            '        Me.grdBilling.CurrentRow.Cells(5).Selected = True
            '        Exit Sub
            '    End If
            'End If
            'If e.KeyCode = Windows.Forms.Keys.Tab Or e.KeyCode = Keys.Enter Then
            '    'e.Handled=True
            '    If Me.grdBilling.CurrentRow.Cells(5).Value = "" Then
            '        Me.grdBilling.CurrentRow.Cells(5).Selected = True
            '        Exit Sub
            '    End If
            '    If Me.grdBilling.CurrentRow.Cells(6).Selected = True Then
            '        Me.grdBilling.CurrentRow.Cells(1).Selected = True
            '        Exit Sub
            '    End If
            '    If Me.grdBilling.CurrentRow.Cells(1).Value = "" Then
            '        Me.grdBilling.CurrentRow.Cells(1).Selected = True
            '        Exit Sub
            '    End If
            'End If

        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub
    Public Sub GetItems(ByVal itemcode As Object)

        Try

            ' MsgBox(itemcode)
            'If blnPopup = True Then Return
            If String.Concat(itemcode).Contains("\") Then
                itemcode = Replace(itemcode, "\", "\\")
            End If
            WindowObject.execScript("GetItemInfo('" + itemcode + "')")

        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub
    Public Sub LoadItemDetails()

        Try
            'load grid row cell values after start datacall
            '            blnPopup = False

            Me.grdBilling.EndEdit()
            Me.grdBilling.CurrentRow.Cells(0).Value = Me.txtOTNo.Text
            Me.grdBilling.CurrentRow.Cells(1).Value = WindowObject.document.all.item("hdnItemCode").value
            Me.grdBilling.CurrentRow.Cells(2).Value = WindowObject.document.all.item("hdnItemName").value
            Me.grdBilling.CurrentRow.Cells(3).Value = WindowObject.document.all.item("hdnUnit").value
            Me.grdBilling.CurrentRow.Cells(4).Value = WindowObject.document.all.item("hdnRate").value
            Me.grdBilling.CurrentRow.Cells(7).Value = WindowObject.document.all.item("hdnItemID").value
            Me.grdBilling.CurrentRow.Cells(8).Value = WindowObject.document.all.item("hdnHRate").value
            Me.grdBilling.CurrentRow.Cells(9).Value = WindowObject.document.all.item("hdnBUnitId").value
            Me.grdBilling.CurrentRow.Cells(10).Value = WindowObject.document.all.item("hdnAQty").value
            Me.grdBilling.CurrentRow.Cells(11).Value = "0"
            Me.grdBilling.CurrentRow.Cells(12).Value = "0"
            Me.grdBilling.CurrentRow.Cells("SalesAccount").Value = WindowObject.document.all.item("hdnSalesAccount").value
            Me.grdBilling.CurrentRow.Cells("SalesTax").Value = WindowObject.document.all.item("hdnSalesTax").value
            Me.grdBilling.CurrentRow.Cells("CessTax").Value = WindowObject.document.all.item("hdnCessTax").value
            Me.grdBilling.CurrentRow.Cells("ServTax").Value = WindowObject.document.all.item("hdnServiceTax").value
            Me.grdBilling.CurrentRow.Cells("ServCharge").Value = WindowObject.document.all.item("hdnServiceCharge").value
            Me.grdBilling.CurrentRow.Cells("ENServCharge").Value = WindowObject.document.all.item("hdnENServiceCharges").value
            Me.grdBilling.CurrentCell = Me.grdBilling.CurrentRow.Cells(5)
            Me.grdBilling.CurrentCell.Selected = True
            Me.grdBilling.BeginEdit(False)
            WindowObject.execScript("blnPopup=false;")
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Public Sub LoadAmount()

        Try

            Me.grdBilling.CurrentRow.Cells(6).Value = WindowObject.document.all.item("hdnamount").value 'by qty cell click calculate amt and display
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Private Sub tblPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblPost.Click
        Try
            'txtOTNo.Focus()
            '  tblFinalize.Enabled = True

            If txtOTNo.Text = "" Then
                MsgBox("Enter OT Number")
                txtOTNo.Focus()
                Exit Sub
            End If
            If txtStewCode.Text = "" Then
                MsgBox("Enter Steward Code")
                txtStewCode.Focus()
                Exit Sub
            End If
            If txtAccNo.Text = "" Then
                MsgBox("Enter Member Account Number")
                txtAccNo.Focus()
                Exit Sub
            End If

            If WindowObject.document.all.item("hdnStewCode").value <> txtStewCode.Text Then
                'Me.WindowObject.hdnStewName.value = txtStewCode.Text
                'WindowObject.execScript("OnStewCode('" + txtStewCode.Text + "')")
                ProcessStewardDetails()
                If txtStewCode.Text = "" Then
                    Exit Sub
                End If
            End If
            If WindowObject.document.all.item("hdnMemberCode").value <> txtAccNo.Text Then
                ' Me.WindowObject.hdnMember.value = txtAccNo.Text
                If WindowObject.document.all.item("hdnCashCard").value = "true" Then
                    WindowObject.execScript("OnAccountChange('" + Replace(WindowObject.document.all.item("hdnMemberId").value, "\", "\\") + "', false)")
                Else
                    WindowObject.execScript("OnAccountChange('" + Replace(txtAccNo.Text, "\", "\\") + "', true )")
                End If

                If txtAccNo.Text = "" Then
                    Exit Sub
                End If
            End If

            'WindowObject.document.all.item("hdnTableID").value = String.Concat(cmbTable.SelectedValue)
                Me.Focus()
                lblstewnamedisplay.Focus()
                GetItemInfoXml()
                WindowObject.execScript("OnSave()")
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub
    Public Sub LockControls()
        Try
            Me.Focus()
            Me.txtAccNo.Enabled = False
            Me.txtStewCode.Enabled = False
            Me.txtOTNo.Enabled = False
            Me.grdBilling.Enabled = False
            Me.dtBillDate.Enabled = False
            cmbTable.Enabled = False
            Me.lblBillNoDisplay.Text = WindowObject.document.all.item("hdnBillNo").value
            lblBillNoDisplay.Focus()

        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub
    Public Sub BillDisplay()
        Try
            Me.Focus()
            Me.lblBillNoDisplay.Text = WindowObject.document.all.item("hdnBillNo").value
            blnNewBill = False
            txtAccNo.Focus()
            'lblBillNoDisplay.Focus()

        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub
    Public Sub UnLockControls()
        Try
            WindowObject.execScript("OnTime()")

            If WindowObject.document.all.item("hdnMode").value = "medit" Then Exit Sub
            If WindowObject.document.all.item("hdnEnableAccFld").value = "true" Then
                Me.txtAccNo.Enabled = True
            End If
            Me.txtStewCode.Enabled = True
            Me.txtOTNo.Enabled = True
            Me.grdBilling.Enabled = True
            '  Me.dtBillDate.Enabled = True
            If WindowObject.document.all.item("hdnUser").Value = "1" Then
                Me.dtBillDate.Enabled = True
            Else
                Me.dtBillDate.Enabled = False
            End If

            ClearMemberDetails(False)
            ClearStewCode()
            Me.txtOTNo.Text = ""
            WindowObject.document.all.item("hdnOTExists").value = ""
            WindowObject.document.all.item("hdnItemName").value = ""
            WindowObject.document.all.item("hdnUnit").value = ""
            WindowObject.document.all.item("hdnRate").value = ""
            WindowObject.document.all.item("hdnItemID").value = ""
            WindowObject.document.all.item("hdnHRate").value = ""
            WindowObject.document.all.item("hdnBUnitId").value = ""
            WindowObject.document.all.item("hdnAQty").value = ""
            WindowObject.document.all.item("hdnBillId").value = ""
            WindowObject.document.all.item("hdnMode").value = ""
            WindowObject.document.all.item("hdnOTNo").value = ""
            WindowObject.document.all.item("hdnphoto").value = ""
            WindowObject.document.all.item("hdnphoto1").value = ""
            WindowObject.document.all.item("hdnphoto2").value = ""
            WindowObject.document.all.item("hdnphoto3").value = ""
            WindowObject.document.all.item("hdnphoto4").value = ""
            Me.lblBillNoDisplay.Text = ""
            WindowObject.document.all.item("hdnBillNo").value = ""
            WindowObject.document.all.item("hdnTempBillAvailable").value = ""
            WindowObject.document.all.item("hdnTempSave").value = "false"
            WindowObject.document.all.item("hdnmyContrlBalance").value = ""
            WindowObject.document.all.item("hdnCancelReason").value = ""
            WindowObject.document.all.item("hdnOldMemberAcc").value = ""
            WindowObject.document.all.item("hdnEditOnlyAcNo").value = ""
            txtReason.Text = ""
            pnlAcChange.Visible = False
            pnlMain.Enabled = True
            grdBilling.Rows.Clear()
            cmbTable.Enabled = True
            '            blnPopup = False
            WindowObject.execScript("blnPopup=false;")
            Dim bDate As Date = Now()
            Date.TryParseExact(WindowObject.document.all.item("hdnBillDate").value, "dd/MM/yyyy HH:mm", Nothing, Globalization.DateTimeStyles.None, bDate)
            Me.dtBillDate.Value = bDate

            'dtBillDate.Value = Now()
            txtAccNo.Focus()
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Private Sub tblClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblClear.Click
        Try

            tblFinalize.Enabled = True
            UnLockControls()
            txtAccNo.Focus()
            WindowObject.execScript("OnClear()")
            blnNewBill = True
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub
    Public Sub GetItemInfoXml()
        Try

            Dim xml As String = "<?xml version='1.0' encoding='utf-8'?> <rows><row id='0'><column id='ItemID'></column>" & _
                                "<column id='OTNo' ></column>" & _
                                "<column id='ItemCode' ></column>" & _
                                "<column id='Item'></column>" & _
                                "<column id='sunitid' ></column>" & _
                                "<column id='bunitid' ></column>" & _
                                "<column id='Qty'></column>" & _
                                "<column id='Rate' ></column>" & _
                                "<column id='Amount'></column>" & _
                                "<column id='Happyhr'></column>" & _
                                "<column id='OpeningBlnce'></column>" & _
                                "<column id='oqty'></column>" & _
                                "<column id='itmslno'></column>" & _
                                "<column id='SalesAccount'></column>" & _
                                "<column id='SalesTax'></column>" & _
                                "<column id='CessTax'></column>" & _
                                "<column id='ServTax'></column>" & _
                                "<column id='ServCharge'></column>" & _
                                "<column id='ENServCharge'></column>" & _
                                "</row></rows> "

            Dim xmlDoc = New System.Xml.XmlDocument()
            xmlDoc.LoadXml(xml)

            Dim xNoRows As XmlNodeList = xmlDoc.SelectNodes("//rows/row")
            Dim k As Int32 = grdBilling.Rows.Count
            Dim rw As DataGridViewRow
            Dim blnVal As Boolean = False
            For i = 0 To k - 1
                rw = grdBilling.Rows(i)
                If Not IsNothing(rw) Then
                    If rw.Cells(7).Value <> String.Empty Then
                        blnVal = True
                        xmlDoc.SelectSingleNode("rows").AppendChild(xNoRows(0).CloneNode(True))
                    End If
                End If
            Next
            If WindowObject.document.all.item("hdnTempBillAvailable").value <> "true" Or WindowObject.document.all.item("hdnMode").value = "edit" Then
                If txtOTNo.Text = "" Then
                    MsgBox("Enter OT Number")
                    Me.grdBilling.CurrentRow.Cells(1).Value = ""
                    Me.grdBilling.CurrentRow.Cells(2).Value = ""
                    Me.grdBilling.CurrentRow.Cells(3).Value = ""
                    Me.grdBilling.CurrentRow.Cells(4).Value = ""
                    Me.Focus()
                    txtOTNo.Focus()
                    Exit Sub
                End If

                If Not blnVal Then
                    MsgBox("Enter Item Details")
                    Me.Focus()
                    WindowObject.document.all.item("hdnSaveXml").value = ""
                    Me.grdBilling.CurrentRow.Cells(1).Selected = True
                    Me.grdBilling.CurrentRow.Cells(1).Value = ""
                    Exit Sub
                End If
            End If
            xmlDoc.SelectSingleNode("rows").RemoveChild(xmlDoc.GetElementsByTagName("row").Item(0))
            Dim xRow As XmlNode
            Dim m As Int32
            m = 0
            Dim sTax As Decimal = 0
            Dim cTax As Decimal = 0
            Dim srTax As Decimal = 0
            Dim srChrge As Decimal = 0
            Dim ensrChrge As Decimal = 0
            Dim totAmt As Decimal = 0
            Dim totTax As Decimal = 0
            Dim netAmt As Decimal = 0
            For Each dr As DataGridViewRow In grdBilling.Rows
                xRow = xmlDoc.GetElementsByTagName("row").Item(m)
                If dr.Cells(7).Value <> String.Empty Then
                    xRow.Attributes("id").Value = dr.Cells(7).Value
                    xRow.SelectSingleNode("column[@id='OTNo']").InnerText = String.Concat(dr.Cells(0).Value)
                    xRow.SelectSingleNode("column[@id='ItemCode']").InnerText = String.Concat(dr.Cells(1).Value)
                    xRow.SelectSingleNode("column[@id='Item']").InnerText = dr.Cells(2).Value
                    xRow.SelectSingleNode("column[@id='Rate']").InnerText = dr.Cells(4).Value
                    xRow.SelectSingleNode("column[@id='Happyhr']").InnerText = "false" 'dr.Cells(7).Value
                    xRow.SelectSingleNode("column[@id='Qty']").InnerText = dr.Cells(5).Value
                    If Val(dr.Cells(5).Value) = 0 Then
                        MsgBox("Enter Quantity")
                        Me.Focus()
                        WindowObject.document.all.item("hdnSaveXml").value = ""
                        Me.grdBilling.CurrentRow.Cells(5).Selected = True
                        Me.grdBilling.CurrentRow.Cells(5).Value = ""
                        Exit Sub
                    End If
                    Dim strqty As String = dr.Cells(5).Value
                    Dim strrate As String = dr.Cells(4).Value
                    Dim qty As Decimal = 0
                    Dim rate As Decimal = 0
                    Dim amt As Decimal = 0
                    If Not IsNumeric(dr.Cells(5).Value) Then
                        MsgBox("Enter Quantity")
                        WindowObject.document.all.item("hdnSaveXml").value = ""
                        Exit Sub
                    End If
                    qty = CDec(strqty) ' CInt(strqty)
                    rate = CDec(strrate) ' CInt(strrate)
                    amt = qty * rate
                    dr.Cells(6).Value = String.Concat(amt)

                    xRow.SelectSingleNode("column[@id='Amount']").InnerText = dr.Cells(6).Value
                    xRow.SelectSingleNode("column[@id='sunitid']").InnerText = dr.Cells(9).Value
                    xRow.SelectSingleNode("column[@id='bunitid']").InnerText = dr.Cells(9).Value
                    xRow.SelectSingleNode("column[@id='oqty']").InnerText = dr.Cells(11).Value
                    xRow.SelectSingleNode("column[@id='itmslno']").InnerText = m + 1
                    xRow.SelectSingleNode("column[@id='SalesAccount']").InnerText = dr.Cells("SalesAccount").Value
                    sTax = amt * Val(dr.Cells("SalesTax").Value) / 100
                    xRow.SelectSingleNode("column[@id='SalesTax']").InnerText = String.Concat(sTax)
                    cTax = amt * Val(dr.Cells("CessTax").Value) / 100
                    xRow.SelectSingleNode("column[@id='CessTax']").InnerText = String.Concat(cTax)
                    srTax = amt * Val(dr.Cells("ServTax").Value) / 100
                    xRow.SelectSingleNode("column[@id='ServTax']").InnerText = String.Concat(srTax)
                    srChrge = amt * Val(dr.Cells("ServCharge").Value) / 100
                    xRow.SelectSingleNode("column[@id='ServCharge']").InnerText = String.Concat(srChrge)
                    ' ensrChrge = amt * Val(dr.Cells("EnServCharge").Value) / 100
                    ensrChrge = Val(dr.Cells("EnServCharge").Value) 'Added by archana for room card it'll not be in persentage
                    xRow.SelectSingleNode("column[@id='ENServCharge']").InnerText = String.Concat(ensrChrge)
                    m += 1
                    totAmt = totAmt + amt
                    totTax = totTax + sTax + cTax + srTax + srChrge + ensrChrge
                End If
            Next
            netAmt = Math.Round(totAmt + totTax, 0)
            WindowObject.document.all.item("hdnSaveXml").value = xmlDoc.OuterXml
            WindowObject.document.all.item("hdnBillDate").value = dtBillDate.Value.ToString("dd/MM/yyyy HH:mm")
            WindowObject.document.all.item("hdnBillDate").value = String.Concat(WindowObject.document.all.item("hdnBillDate").value).Replace("-", "/")
            WindowObject.document.all.item("hdnOTNo").value = txtOTNo.Text
            WindowObject.document.all.item("hdnTableID").value = String.Concat(CType(cmbTable.SelectedItem, DataRowView)("TableID"))  ' String.Concat(cmbTable.SelectedValue)
            WindowObject.document.all.item("hdnTotalAmount").value = String.Concat(totAmt)
            WindowObject.document.all.item("hdnTotalTax").value = String.Concat(totTax)
            WindowObject.document.all.item("hdnNetAmount").value = String.Concat(netAmt)
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Private Sub grdBilling_keyPressHook(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdBilling.keyPressHook
        If grdBilling.CurrentCell.ColumnIndex = 5 Then
            If Asc(e.KeyChar) = 8 Then Exit Sub
            If Asc(e.KeyChar) > 47 And Asc(e.KeyChar) < 58 Then Exit Sub
            e.Handled = True
        End If

    End Sub

    Private Sub grdBilling_keyDownHook(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grdBilling.keyDownHook
        If Me.grdBilling.CurrentCell.ColumnIndex = 1 Then

            If e.KeyCode = Windows.Forms.Keys.F10 Then

                'If blnPopup = True Then Return
                If txtOTNo.Text <> "" Then
                    WindowObject.execScript("OTExists('" + txtOTNo.Text + "','" + WindowObject.document.all.item("hdnBillId").value + "')")
                    If WindowObject.document.all.item("hdnOTExists").value = "true" Then
                        txtOTNo.Focus()
                        Exit Sub
                    End If
                End If

                Me.grdBilling.CurrentRow.Cells(0).Value = Me.txtOTNo.Text
                '                blnPopup = True
                WindowObject.execScript("ItemPoup()")
                Exit Sub
            End If

        End If
      
    End Sub

    
  
    Private Sub grdBilling_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles grdBilling.UserDeletedRow
        Try
            If WindowObject.document.all.item("hdnMode").value = "edit" Then
                WindowObject.document.all.item("hdnDelItems").value = WindowObject.document.all.item("hdnDelItems").value & "," & e.Row.Cells(7).Value
            End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Private Sub tblReadcard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblReadcard.Click
        Try

            WindowObject.execScript("OnSmartCard()")
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Private Sub tblViewm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblViewm.Click
        Try
            If WindowObject.document.all.item("hdnSaveXml").value <> "" Then
                Exit Sub
            End If
            WindowObject.document.all.item("hdnMember").value = txtAccNo.Text
            WindowObject.execScript("OnView()")
            tblFinalize.Enabled = True
            If WindowObject.document.all.item("hdnMemberAvailable").value = "true" Then
                txtOTNo.Focus()
            End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Public Sub LoadViewDetails()
        Try
            Dim cdates As DateTime
            Me.lblstewnamedisplay.Text = WindowObject.document.all.item("hdnStewName").value
            If WindowObject.document.all.item("hdnMode").value = "medit" Then
                Me.lblBillNoDisplay.Text = WindowObject.document.all.item("hdnBillNo").value
            End If


            Me.txtOTNo.Text = WindowObject.document.all.item("hdnOTNo").value
            Me.txtStewCode.Text = WindowObject.document.all.item("hdnStewCode").value
            Try

                If Trim(WindowObject.document.all.item("hdnBillNo").value) <> "" Then
                    If WindowObject.document.all.item("hdnTableID").value <> "" Then
                        ' cmbTable.SelectedValue = WindowObject.document.all.item("hdnTableID").value
                        SelectTable(WindowObject.document.all.item("hdnTableID").value)
                        cmbTable.Enabled = False
                    End If
                End If
            Catch ex As Exception
                IS91.Services.Logger.LogThis(ex)
            End Try
            Try
                DateTime.TryParseExact(WindowObject.document.all.item("hdnBillDate").value, "dd/MM/yyyy HH:mm", Nothing, Globalization.DateTimeStyles.None, cdates)
                Me.dtBillDate.Value = cdates
            Catch ex As Exception

            End Try
            LoadItemDetailsInEdit()
            If Trim(WindowObject.document.all.item("hdnMode").value) = "" Then
                txtOTNo.Text = ""
                txtOTNo.Focus()
            End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub
    Private Sub SelectTable(ByVal tblId As String)
        'MsgBox(tblId)
        If Not dvLst Is Nothing Then
            Dim dr As DataRowView() = dvLst.FindRows(tblId)
            If dr.Length > 0 Then
                cmbTable.SelectedItem = dr(0)

            End If
        End If
    End Sub
    Public Sub LoadItemDetailsInEdit()
        Try

            Dim xmlDoc = New System.Xml.XmlDocument()

            xmlDoc.LoadXml(WindowObject.document.all.item("hdnSaveXml").value)
            If xmlDoc.ChildNodes.Count = 0 Then Exit Sub
            Dim xNoRows As XmlNodeList = xmlDoc.SelectNodes("//rows/row")
            Dim xRow As XmlNode
            Dim m As Int32
            m = 0
            grdBilling.Rows.Clear()
            If xNoRows.Count > 0 Then
                grdBilling.Rows.Add(xNoRows.Count)
                For Each xRow In xNoRows
                    grdBilling.Rows(m).Cells(0).Value = xRow.ChildNodes(0).InnerText
                    grdBilling.Rows(m).Cells(1).Value = xRow.ChildNodes(1).InnerText
                    grdBilling.Rows(m).Cells(2).Value = xRow.ChildNodes(2).InnerText
                    grdBilling.Rows(m).Cells(3).Value = xRow.ChildNodes(3).InnerText
                    grdBilling.Rows(m).Cells(4).Value = xRow.ChildNodes(4).InnerText
                    grdBilling.Rows(m).Cells(5).Value = xRow.ChildNodes(5).InnerText
                    grdBilling.Rows(m).Cells(6).Value = xRow.ChildNodes(6).InnerText
                    grdBilling.Rows(m).Cells(7).Value = xRow.ChildNodes(7).InnerText
                    grdBilling.Rows(m).Cells(8).Value = xRow.ChildNodes(8).InnerText
                    grdBilling.Rows(m).Cells(9).Value = xRow.ChildNodes(9).InnerText
                    grdBilling.Rows(m).Cells(10).Value = xRow.ChildNodes(10).InnerText
                    grdBilling.Rows(m).Cells(11).Value = xRow.ChildNodes(11).InnerText
                    grdBilling.Rows(m).Cells(12).Value = xRow.ChildNodes(12).InnerText
                    grdBilling.Rows(m).Cells("SalesAccount").Value = xRow.ChildNodes(13).InnerText
                    grdBilling.Rows(m).Cells("SalesTax").Value = xRow.ChildNodes(14).InnerText
                    grdBilling.Rows(m).Cells("CessTax").Value = xRow.ChildNodes(15).InnerText
                    grdBilling.Rows(m).Cells("ServTax").Value = xRow.ChildNodes(16).InnerText
                    grdBilling.Rows(m).Cells("ServCharge").Value = xRow.ChildNodes(17).InnerText
                    grdBilling.Rows(m).Cells("ENServCharge").Value = xRow.ChildNodes(18).InnerText

                    'grdBilling.Rows(m).Cells(10).Value = xRow.ChildNodes(10).InnerText
                    'grdBilling.Rows(m).Cells(11).Value = xRow.ChildNodes(11).InnerText
                    m += 1
                Next
            End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try

    End Sub


    Private Sub tblFinalize_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblFinalize.Click
        Try
            If WindowObject.document.all.item("hdnEditOnlyAcNo").value = "true" Then
                'MsgBox(WindowObject.document.all.item("hdnOldMemberAcc").value)
                'MsgBox(txtAccNo.Text)
                If WindowObject.document.all.item("hdnOldMemberAcc").value <> txtAccNo.Text Then
                    grpBillCancel.Text = "Credit Account"
                    pnlAcChange.Visible = True
                    pnlMain.Enabled = False
                    If WindowObject.document.all.item("hdnOldMemberId").value = WindowObject.document.all.item("hdnMemberId").value Then
                        WindowObject.execScript("OnAccountChange('" + Replace(WindowObject.document.all.item("hdnMemberId").value, "\", "\\") + "', false)")
                    End If
                    'WindowObject.execScript("OnFinalSave()")
                End If

                Exit Sub
            End If

            If txtAccNo.Text <> String.Empty And WindowObject.document.all.item("hdnMemberId").value = "" Then
                If WindowObject.document.all.item("hdnMemberCode").value <> txtAccNo.Text Then
                    WindowObject.document.all.item("hdnBillDate").value = dtBillDate.Value.ToString("dd/MM/yyyy HH:mm")
                    If WindowObject.document.all.item("hdnCashCard").value = "true" Then
                        WindowObject.execScript("OnAccountChange('" + Replace(WindowObject.document.all.item("hdnMemberId").value, "\", "\\") + "', false)")
                    Else
                        WindowObject.execScript("OnAccountChange('" + Replace(txtAccNo.Text, "\", "\\") + "', true)") 'using a/c no get the member details
                    End If
                End If
            End If
            If WindowObject.document.all.item("hdnMode").Value = "medit" Then
                GetItemInfoXml()
                If WindowObject.document.all.item("hdnStewardID").value = "" Then
                    'WindowObject.execScript("OnStewCode('" + txtStewCode.Text + "')")
                    ProcessStewardDetails()
                End If
            Else
                If WindowObject.document.all.item("hdnBillId").Value = "" Then
                    If WindowObject.document.all.item("hdnMemberId").value <> "" Then
                        'WindowObject.execScript("OnStewCode('" + txtStewCode.Text + "')")
                        ProcessStewardDetails()
                        Me.Focus()
                        lblstewnamedisplay.Focus()
                        GetItemInfoXml()
                    End If
                Else
                    Me.Focus()
                    lblstewnamedisplay.Focus()
                    GetItemInfoXml()
                End If
                WindowObject.document.all.item("hdnMember").value = txtAccNo.Text

            End If
            If WindowObject.document.all.item("hdnSaveXml").value <> "" Then
                WindowObject.execScript("OnFinalSave()")
            End If

        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        'grdBilling.keyPressHook += new KeyEventHandler(myKeyEventHandlerProc); 
        Me.dtBillDate.Value = DateAndTime.Now
       
        'txtOTNo.Focus()
        ' Add any initialization after the InitializeComponent() call.


    End Sub

    Public Sub Close()
        WindowObject = Nothing
        MyBase.Finalize()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub txtAccNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccNo.KeyPress

    End Sub

    
    Private Sub txtAccNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccNo.Leave
        Try
            If txtAccNo.Text <> String.Empty Then
                ' WindowObject.document.all.item("hdnmemberid").value = ""
                If WindowObject.document.all.item("hdnMemberCode").value <> txtAccNo.Text Then
                    WindowObject.document.all.item("hdnBillDate").value = dtBillDate.Value.ToString("dd/MM/yyyy HH:mm")
                    If WindowObject.document.all.item("hdnCashCard").value = "true" Then
                        WindowObject.execScript("OnAccountChange('" + Replace(WindowObject.document.all.item("hdnMemberId").value, "\", "\\") + "', false)")
                    Else
                        WindowObject.execScript("OnAccountChange('" + Replace(txtAccNo.Text, "\", "\\") + "', true)") 'using a/c no get the member details
                    End If
                End If
                End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try

    End Sub

    Private Sub txtStewCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStewCode.Leave
        Try
            If txtStewCode.Text <> String.Empty Then
                If WindowObject.document.all.item("hdnStewCode").value <> txtStewCode.Text Then
                    ' WindowObject.execScript("OnStewCode('" + txtStewCode.Text + "')") 'get stewcode id
                    ProcessStewardDetails()
                End If
            End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

    Private Sub cmbTable_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTable.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Tab Or e.KeyCode = Keys.Enter Then
            grdBilling.Focus()
            If Not grdBilling.CurrentRow Is Nothing Then
                grdBilling.CurrentCell = grdBilling.CurrentRow.Cells(1)
                grdBilling.CurrentCell.Selected = True
                Try
                    grdBilling.BeginEdit(False)
                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub cmbTable_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTable.SelectedValueChanged
        ' MsgBox(cmbTable.SelectedItem)
        'WindowObject.document.all.item("hdnTableID").value = String.Concat(CType(cmbTable.SelectedItem, DataRowView)("TableID"))
    End Sub

    Private Sub POSControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If pnlReprint.Visible = True Then '
                pnlReprint.Visible = False
                pnlMain.Enabled = True
            End If
        End If
    End Sub


    Private Sub POSControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAccNo.Focus()
    End Sub
    Private Sub txtOTNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOTNo.KeyDown
        If e.KeyCode = Keys.Enter Then '
            txtStewCode.Focus()
        End If
    End Sub
 

    Private Sub grdBilling_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grdBilling.CellValidating
        Try
            If e.ColumnIndex = 5 Then
                If Me.grdBilling.CurrentRow.Cells(2).Value <> "" Then
                    'If grdBilling.IsCurrentCellDirty Then
                    '    grdBilling.EndEdit(DataGridViewDataErrorContexts.Commit)
                    'End If
                    Application.DoEvents()
                    If Val(String.Concat(e.FormattedValue)) = 0 Then
                        MsgBox("Enter Quantity")
                        e.Cancel = True
                        Exit Sub
                    End If
                    Application.DoEvents()
              
                End If

            End If
        Catch ex As Exception
            IS91.Services.Logger.LogThis(ex)
        End Try
    End Sub

   
    Private Sub tblRePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblRePrint.Click
        'WindowObject.execScript("ShowRePrint()")
        If grdBilling.IsCurrentCellInEditMode = True Then Exit Sub
        txtBillNumber.Text = ""
        pnlReprint.Visible = True
        pnlMain.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        pnlReprint.Visible = False
        pnlMain.Enabled = True
    End Sub

    Private Sub btnReprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprint.Click
        If txtBillNumber.Text = "" Then
            MsgBox("Enter Bill Number")
            Exit Sub
        End If
        WindowObject.execScript("OnReprint('" + txtBillNumber.Text + "')")
        pnlReprint.Visible = False
        pnlMain.Enabled = True
    End Sub

    Private Sub txtAccNo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccNo.Validated

    End Sub

    Private Sub txtAccNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtAccNo.Validating
        'MsgBox(blnMemberValid)
        If txtAccNo.Text <> "" And Not blnMemberValid Then
            txtAccNo.Text = ""
            blnEnter = False
            e.Cancel = True
            Exit Sub
        End If

        If blnEnter Then
            txtOTNo.Focus()
            blnEnter = False
        End If
    End Sub

    Private Sub tblBillCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tblBillCancel.Click
        'If WindowObject.document.all.item("hdnEditOnlyAcNo").value = "true" Then
        pnlAcChange.Visible = True
        pnlMain.Enabled = False
        blnBCancel = True
    End Sub

    Private Sub btnCCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCCancel.Click
        pnlAcChange.Visible = False
        pnlMain.Enabled = True
        blnBCancel = False
    End Sub

    Private Sub btnDone_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDone.Click
        If blnBCancel Then
            If MsgBox("Are you sure to Cancel this BILL:" & WindowObject.document.all.item("hdnBillNo").value, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Bill Cancel") = MsgBoxResult.No Then
                Exit Sub
            End If
            If txtReason.Text.Trim() = String.Empty Then
                MsgBox("Enter Reason For Bill Cancel", MsgBoxStyle.Information)
            End If
            WindowObject.document.all.item("hdnCancelReason").value = txtReason.Text
            WindowObject.execScript("OnBillCancel()")
        Else
            WindowObject.execScript("OnFinalSave()")
        End If
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''
    'Cache methods

    'OnStewCode
    Private DTSteward As DataTable = Nothing

    Private Sub ProcessStewardDetails()
        'First Check for cache
        If GetCacheData() Then

            Dim DTRows() As DataRow = DTSteward.Select("StewardCode='" & txtStewCode.Text & "'")
            If DTRows IsNot Nothing AndAlso DTRows.Length > 0 Then
                Dim DTRow As DataRow = DTRows(0)

                WindowObject.document.all.item("hdnStewardID").value = DTRow("StewardID")
                WindowObject.document.all.item("hdnStewName").value = DTRow("StewardName")
                WindowObject.document.all.item("hdnStewCode").value = DTRow("StewardCode")
                lblstewnamedisplay.Text = DTRow("StewardName")

            Else
                If txtStewCode.Text <> "" Then
                    MsgBox("Invalid Steward Code")
                    ClearStewCode()
                End If

            End If
        Else
            'no cache data, so try old one
            WindowObject.execScript("OnStewCode('" + Replace(txtStewCode.Text, "\", "\\") + "')") 'get stewcode id
        End If


    End Sub

    'GetItems
    Private DTItems As DataTable = Nothing
    Private Sub ProcessItemDetails(ByVal itemcode As Object)

        'First Check for cache
        If GetCacheData() Then

            Dim DTRows() As DataRow = DTItems.Select("ItemCode='" & itemcode & "'")
            If DTRows IsNot Nothing AndAlso DTRows.Length > 0 Then
                Dim DTRow As DataRow = DTRows(0)

                WindowObject.document.all.item("hdnItemCode").value = DTRow("ItemCode")
                WindowObject.document.all.item("hdnItemName").value = DTRow("ItemName")
                WindowObject.document.all.item("hdnUnit").value = DTRow("UnitName")
                If WindowObject.document.all.item("hdnItemCode").value.contains("H") Then
                    WindowObject.document.all.item("hdnRate").value = DTRow("HappyHourRate")
                Else
                    WindowObject.document.all.item("hdnRate").value = DTRow("Rate")
                End If


                WindowObject.document.all.item("hdnItemID").value = DTRow("ItemID")
                WindowObject.document.all.item("hdnHRate").value = DTRow("HappyHourRate")
                WindowObject.document.all.item("hdnBUnitId").value = DTRow("UnitID")
                'WindowObject.document.all.item("hdnAQty").value = DTRow("")
                LoadItemDetails()

            Else
                If itemcode <> "" Then
                    MsgBox("Invalid Item Code")
                    InvalidItems()
                End If

            End If
        Else
            'no cache data, so try old one
            GetItems(itemcode)
        End If


    End Sub

    Public StoreID As String = "1901154574"
    Private Function GetCacheData() As Boolean

        Try
            Dim StrEnCacheData As String = String.Empty

            'check inmemory
            If DTSteward IsNot Nothing AndAlso DTItems IsNot Nothing Then
                If DTSteward.Rows.Count > 0 AndAlso DTItems.Rows.Count > 0 Then Return True
            End If

            'check local cache file
            Dim DataCacheFile As String = Path.Combine(IS91.Services.Common.GetAppTemPath(), "ICMSPOSCacheDataFile-" & StoreID & ".fil")
            IS91.Services.LogThis(DataCacheFile)

            'Check if its older than 12 hrs
            If File.Exists(DataCacheFile) AndAlso Math.Abs(DateDiff(DateInterval.Hour, (New FileInfo(DataCacheFile).LastWriteTime), Now)) < 12 Then
                StrEnCacheData = IS91.Services.Common.FileReadAllText(DataCacheFile)
            End If

            'check if we have cache data or else try 2 get it
            If String.IsNullOrEmpty(StrEnCacheData) Then
                IS91.Services.LogThis("Getting Server Data for cache")
                StrEnCacheData = WindowObject.getXmlFileContent("cachedatahandler.ashx?storeid=" & StoreID)
            End If
            Dim tempDataset As DataSet = IS91.Services.Common.Deserialize(StrEnCacheData)
            If tempDataset IsNot Nothing Then
                DTItems = tempDataset.Tables("mItem")
                DTSteward = tempDataset.Tables("Stewards")
            End If

            If DTItems IsNot Nothing Then
                If Not DTItems.Columns.Contains("SalesTax") Then
                    Return False
                End If
            End If
            'check inmemory
            If DTSteward IsNot Nothing AndAlso DTItems IsNot Nothing Then
                If DTSteward.Rows.Count > 0 AndAlso DTItems.Rows.Count > 0 Then
                    File.WriteAllText(DataCacheFile, StrEnCacheData, System.Text.Encoding.UTF8)
                    Return True
                Else
                    'failed somewhere to get data
                    IS91.Services.LogThis("failed somewhere to get data @ 1")
                    Return False
                End If
            Else
                'failed somewhere to get data
                IS91.Services.LogThis("failed somewhere to get data @ 2")
                Return False
            End If

        Catch ex As Exception
            IS91.Services.LogThis(ex, "failed somewhere to get data @ 0")
            Return False
        End Try

    End Function

    Public Sub ClearDataCache()
        On Error Resume Next
        'check local cache file
        Dim DataCacheFile As String = Path.Combine(IS91.Services.Common.GetAppTemPath(), "ICMSPOSCacheDataFile-" & StoreID & ".fil")
        IS91.Services.LogThis("ClearDataCache", DataCacheFile)
        File.Delete(DataCacheFile)
    End Sub


End Class

Class LstVal
    ' a simple name value class
    Dim m_name As String
    Dim m_value As String
    Public Sub New(ByVal name As String, ByVal value As String)
        m_name = name
        m_value = value
    End Sub
    Public Property Name()
        Get
            Return m_value
        End Get
        Set(ByVal value)
            m_value = value
        End Set
    End Property

End Class
