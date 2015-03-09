Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Graphics
Imports System.Threading
Class KeyPressAwareDataGridView
    Inherits DataGridView
    Protected Friend blnNav As Boolean = True
    Protected Overloads Overrides Sub OnControlAdded(ByVal e As ControlEventArgs)
        Me.subscribeEvents(e.Control)
        MyBase.OnControlAdded(e)
    End Sub

    Protected Overloads Overrides Sub OnControlRemoved(ByVal e As ControlEventArgs)
        Me.unsubscribeEvents(e.Control)
        MyBase.OnControlRemoved(e)
    End Sub

    Protected Overloads Overrides Function ProcessDataGridViewKey(ByVal e As KeyEventArgs) As Boolean
        Dim procesedInternally As Boolean = False

        'If keyDownHook IsNot Nothing Then
        RaiseEvent keyDownHook(Me, e)
        procesedInternally = e.SuppressKeyPress
        'End If
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            ' MsgBox(blnNav)
            ' If blnNav Then
            If Me.CurrentCell.ColumnIndex = 1 Then
                If Not Me.CurrentRow Is Nothing Then
                    Me.ProcessRightKey(e.KeyData)
                    Me.CurrentCell = Me.CurrentRow.Cells(5)
                    Me.ProcessF2Key(e.KeyData)
                    Return True
                End If
            ElseIf Me.CurrentCell.ColumnIndex = 5 Then
                If Val(Me.CurrentCell.EditedFormattedValue) = 0 Then Return MyBase.ProcessDataGridViewKey(e)
                Me.ProcessTabKey(e.KeyData)
                Me.ProcessTabKey(e.KeyData)
                Me.ProcessTabKey(e.KeyData)
                Me.ProcessF2Key(e.KeyData)
                Return True
            Else
                If e.KeyCode = Keys.Enter Then
                    Me.ProcessTabKey(e.KeyData)
                    Return True
                End If
                'If Me.CurrentCell.ColumnIndex <> 5 And Me.CurrentCell.ColumnIndex <> 6 Then
                '    Me.ProcessRightKey(e.KeyData)
                '    Return True
                'End If
            End If
            'Else
            '    blnNav = True
            '    Return True
            'End If
        End If


        If procesedInternally Then
            Return True
        Else
            Return MyBase.ProcessDataGridViewKey(e)
        End If
    End Function
    Protected Overrides Function ProcessDialogKey(ByVal keyData As Keys) As Boolean
        'Dim e As KeyEventArgs
        'RaiseEvent keyDownHook(Me, e.)
        ' Extract the key code from the key value. 
        Dim key As Keys = keyData And Keys.KeyCode
        ' Handle the ENTER key as if it were a RIGHT ARROW key. 

        If key = Keys.Enter Or key = Keys.Tab Then
            ' MsgBox(blnNav)
            'If blnNav Then
            If Me.CurrentCell.ColumnIndex = 1 Then
                If Not Me.CurrentRow Is Nothing Then
                    Me.ProcessRightKey(keyData)
                    Me.CurrentCell = Me.CurrentRow.Cells(5)
                    Me.ProcessF2Key(keyData)
                    Return True
                End If
            ElseIf Me.CurrentCell.ColumnIndex = 5 Then
                If Val(Me.CurrentCell.EditedFormattedValue) = 0 Then Return MyBase.ProcessDialogKey(keyData)
                Me.ProcessTabKey(keyData)
                Me.ProcessTabKey(keyData)
                Me.ProcessTabKey(keyData)
                ' MsgBox(key)
                Me.ProcessF2Key(keyData)
                Return True
            Else
                If key = Keys.Enter Then
                    Me.ProcessTabKey(keyData)
                    Return True
                End If

                'If Me.CurrentCell.ColumnIndex <> 5 And Me.CurrentCell.ColumnIndex <> 6 Then
                '    Me.ProcessRightKey(keyData)
                '    Return True
                'End If
            End If
            'Else
            '    blnNav = True
            '    Return True
            'End If
        End If

        Return MyBase.ProcessDialogKey(keyData)

    End Function

    Private Sub subscribeEvents(ByVal control As Control)
        AddHandler control.KeyDown, AddressOf Me.control_KeyDown
        AddHandler control.KeyPress, AddressOf Me.control_keyPress

        AddHandler control.ControlAdded, AddressOf Me.control_ControlAdded
        AddHandler control.ControlRemoved, AddressOf Me.control_ControlRemoved

        For Each innerControl As Control In control.Controls
            Me.subscribeEvents(innerControl)
        Next
    End Sub

    Private Sub unsubscribeEvents(ByVal control As Control)
        RemoveHandler control.KeyDown, AddressOf Me.control_KeyDown
        RemoveHandler control.KeyPress, AddressOf Me.control_keyPress

        RemoveHandler control.ControlAdded, AddressOf Me.control_ControlAdded
        RemoveHandler control.ControlRemoved, AddressOf Me.control_ControlRemoved

        For Each innerControl As Control In control.Controls
            Me.unsubscribeEvents(innerControl)
        Next
    End Sub

    Private Sub control_ControlAdded(ByVal sender As Object, ByVal e As ControlEventArgs)
        Me.subscribeEvents(e.Control)
    End Sub

    Private Sub control_ControlRemoved(ByVal sender As Object, ByVal e As ControlEventArgs)
        Me.unsubscribeEvents(e.Control)
    End Sub

    Private Sub control_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        RaiseEvent keyDownHook(sender, e)
    End Sub
    Private Sub control_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        RaiseEvent keyPressHook(sender, e)
    End Sub

    Public Event keyPressHook As KeyPressEventHandler
    Public Event keyDownHook As KeyEventHandler

End Class