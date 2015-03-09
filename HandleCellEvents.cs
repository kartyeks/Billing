using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace BillingManager
{
    class KeyPressAwareDataGridView : DataGridView
    {

    protected Boolean blnNav = true;
    public event KeyEventHandler keyDownHook;  
    public event KeyPressEventHandler keyPressHook;
    protected override void OnControlAdded( ControlEventArgs e)
    {
        subscribeEvents(e.Control);
        base.OnControlAdded(e);
    }

    protected override void OnControlRemoved(ControlEventArgs e)
    {
        unsubscribeEvents(e.Control);
        base.OnControlRemoved(e);
    }

    protected override Boolean ProcessDataGridViewKey(KeyEventArgs e) 
    {
        Boolean procesedInternally = false;

        keyDownHook(this, e);
        procesedInternally = e.SuppressKeyPress;
        if (e.Handled)
        {
            if (procesedInternally)
                return true;
            else
                return base.ProcessDataGridViewKey(e);
        }
        if( e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
        {
            if(this.CurrentCell.ColumnIndex == 2)
            {
                if(this.CurrentRow!=null)
                {
                    ProcessRightKey(e.KeyData);
                    if (!this.IsCurrentCellDirty)
                    {
                        this.CurrentCell = this.CurrentRow.Cells[5];
                        ProcessF2Key(e.KeyData);
                    }
                    return true;
                }
            }
            else if (this.CurrentCell.ColumnIndex == 3)
            {
                if (this.CurrentCell.Value == null) { return false; }
                if (this.CurrentRow != null)
                {
                    ProcessRightKey(e.KeyData);
                    if (!this.IsCurrentCellDirty)
                    {
                        this.CurrentCell = this.CurrentRow.Cells[5];
                        ProcessF2Key(e.KeyData);
                    }
                    return true;
                }
            }
            else if( this.CurrentCell.ColumnIndex == 5)
            {
                double val=0;
                double.TryParse(string.Concat(CurrentCell.EditedFormattedValue), out val);
                if( val == 0)return base.ProcessDataGridViewKey(e);
                ProcessTabKey(e.KeyData);
                ProcessTabKey(e.KeyData);
                ProcessTabKey(e.KeyData);
                ProcessTabKey(e.KeyData);
                ProcessTabKey(e.KeyData);
                ProcessF2Key(e.KeyData);
                return true;
            }
            else
            {
                if( e.KeyCode == Keys.Enter)
                {
                    ProcessTabKey(e.KeyData);
                    return true;
                }
            }
        }


        if(procesedInternally)
            return true;
        else
            return base.ProcessDataGridViewKey(e);
        
    }

    protected override Boolean ProcessDialogKey(Keys keyData) 
    {
         Keys key = keyData & Keys.KeyCode;
        //' Handle the ENTER key as if it were a RIGHT ARROW key. 

        if(key == Keys.Enter || key == Keys.Tab)
        {
            if (CurrentCell.ColumnIndex == 2)
            {
                if(CurrentRow !=null)
                {
                    if (EditingControl.Text == "?")
                    {
                         return false;
                    }
                    ProcessRightKey(keyData);
                    if (!this.IsCurrentCellDirty)
                    {
                        CurrentCell = CurrentRow.Cells[3];
                        ProcessF2Key(keyData);
                        DataGridViewTextBoxEditingControl editControl = (DataGridViewTextBoxEditingControl)EditingControl;
                        if (editControl != null)
                        {
                            editControl.SelectionStart = 0;
                            editControl.SelectionLength = editControl.Text.Length;
                        }
                    }
                    return true;
                }
            }
            else if (CurrentCell.ColumnIndex == 3)
            {
                if (CurrentRow != null)
                {
                    if (EditingControl.Text == "?")
                    {
                        return false;
                    }
                    if (EditingControl.Text == "")
                    {
                        return false;
                    }
                    ProcessRightKey(keyData);
                    if (!this.IsCurrentCellDirty)
                    {
                        CurrentCell = CurrentRow.Cells[5];
                        ProcessF2Key(keyData);
                        DataGridViewTextBoxEditingControl editControl = (DataGridViewTextBoxEditingControl)EditingControl;
                        if (editControl != null)
                        {
                            editControl.SelectionStart = 0;
                            editControl.SelectionLength = editControl.Text.Length;
                        }
                    }
                    return true;
                }
            }
            else if( CurrentCell.ColumnIndex == 5)
            {
                double val=0;
                double.TryParse(string.Concat(CurrentCell.EditedFormattedValue), out val);
                if( val== 0)return base.ProcessDialogKey(keyData);
                ProcessTabKey(keyData);
                if (!this.IsCurrentCellDirty)
                {
                    ProcessTabKey(keyData);
                    ProcessTabKey(keyData);
                    ProcessTabKey(keyData);
                    ProcessTabKey(keyData);                  
                    ProcessF2Key(keyData);
                }
                return true;
            }
            else
            {
                if( key == Keys.Enter)
                {
                    ProcessTabKey(keyData);
                    return true;
                }

             
            }
        }

        return base.ProcessDialogKey(keyData);

    }

    private void subscribeEvents(Control control)
    {
                
        control.KeyDown +=new KeyEventHandler(control_KeyDown);
        control.KeyPress +=new KeyPressEventHandler(control_keyPress);
        control.ControlAdded+=new ControlEventHandler(control_ControlAdded); 
        control.ControlRemoved+=new ControlEventHandler(control_ControlRemoved);
        foreach(Control  innerControl in control.Controls)
        {
            subscribeEvents(innerControl);
        }
    }

    private void unsubscribeEvents(Control control)
    {
         control.KeyDown -=new KeyEventHandler(control_KeyDown);
        control.KeyPress -=new KeyPressEventHandler(control_keyPress);
        control.ControlAdded-=new ControlEventHandler(control_ControlAdded); 
        control.ControlRemoved-=new ControlEventHandler(control_ControlRemoved);
        foreach(Control  innerControl in control.Controls)
        {
            unsubscribeEvents(innerControl);
        }
    }

    private void control_ControlAdded(Object sender ,ControlEventArgs e)
    {
        subscribeEvents(e.Control);
    }

    private void control_ControlRemoved(Object sender, ControlEventArgs e )
    {
        unsubscribeEvents(e.Control);
    }

    private void control_KeyDown(object sender ,KeyEventArgs e )
    {
        keyDownHook(sender, e);
    }
    private void control_keyPress(Object sender ,KeyPressEventArgs e )
    {
        keyPressHook(sender, e);
    }
   

}
}

