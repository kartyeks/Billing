using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Globalization;

namespace BillingManager
{
 public class MSExcel    {       
     Type ExcelType;        
     object ExcelApplication;        
     public object oBook;
     private object moApp;

     public MSExcel()        
     {            
         //Gets the type of the Excel application using prorame id            
       //  ExcelType = Type.GetTypeFromProgID("Excel.Application");            
         //Creating Excel application instance from the type            
         //Check the running processes using alt+ctrl+del            
      //   ExcelApplication = Activator.CreateInstance(ExcelType);        
     }        
     public void Open(string strFileName)        
     {            
       /*  object fileName = strFileName;            
         object readOnly = true;            
         object missing = System.Reflection.Missing.Value;            
         object[] oParams = new object[1];                        
         //Getting the WoorkBook collection [work Sheet collection]            
         object oDocs = ExcelApplication.GetType().InvokeMember("Workbooks",System.Reflection.BindingFlags.GetProperty,null,ExcelApplication,null,CultureInfo.InvariantCulture);
         oParams = new object[3];            
         oParams[0] = fileName;            
         oParams[1] = missing;            
         oParams[2] = readOnly;            
         //Open the first work sheet            
         oBook = oDocs.GetType().InvokeMember("Open", System.Reflection.BindingFlags.InvokeMethod,null,oDocs,oParams, CultureInfo.InvariantCulture);
         */

         // CREATE A GENERIC OBJECT VARIABLE & TRAP FOR EXCEL NOT INSTALLED
         try
         {
             System.Type moAppType;
             moAppType = System.Type.GetTypeFromProgID("Excel.Application");
             moApp = System.Activator.CreateInstance(moAppType);
             // KEEP IT HIDDEN FROM THE USER UNTIL WE USE IT
             moApp.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, moApp,
                 new object[] { false });
             // DECLARE & CREATE OUR WORKBOOK OBJECT
             // MAKE IT VISIBLE TO THE USER NOW
             moApp.GetType().InvokeMember("Visible", BindingFlags.IgnoreReturn | BindingFlags.Public |
                 BindingFlags.Static | BindingFlags.SetProperty, null, moApp, new object[] { true });
             // GET THE WORKBOOKS COLLECTION OF OUR APPLICATION OBJECT INSTANCE
             object oWBs = moApp.GetType().InvokeMember("Workbooks", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, moApp, null);
             // GET THE FIRST WORKBOOK IN COLLECTION
             object oWB = oWBs.GetType().InvokeMember("Open", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oWBs, new string[] { AppDomain.CurrentDomain.BaseDirectory + "ITEMSALESREPORT.xlsx" });
             // GET THE WORKSHEETS COLLECTION
             object oShts = oWB.GetType().InvokeMember("Worksheets", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oWB, null);
             // GET THE FIRST SHEET
             object oSht = oShts.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oShts, new object[] { 1 });
             // SAVE THE SHEET NAME
             string SheetName = oSht.GetType().InvokeMember("Name", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oSht, null).ToString();
             // GET THE CELLS COLLECTION
             object oCells = oSht.GetType().InvokeMember("Cells", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oSht, null);
             // INITIALIZE VARIABLE AS AN OBJECT
             object oCell = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oCells, new object[] { 1, 1 });
             // WRITE CURRENT DATE/TIME - CELL A1
             oCell.GetType().InvokeMember("Value2", BindingFlags.SetProperty, null, oCell,
                 new string[] { System.DateTime.Now.ToString() });
             // MAKE FIRST SHEET ACTIVE
             oSht.GetType().InvokeMember("Activate", BindingFlags.IgnoreReturn | BindingFlags.Public |
                 BindingFlags.Static | BindingFlags.InvokeMethod, null, oSht, null);
             // ENSURE VARIABLES ARE DESTROYED & RELEASED AS IT GOES OUT OF SCOPE
             SheetName = string.Empty;
             oCell = null;
             oCells = null;
             oSht = null;
             oShts = null;
             oWB = null;
             oWBs = null;
             // CALL THE GARBAGE COLLECT METHOD
             GC.Collect();
             GC.WaitForPendingFinalizers();
         }
         catch (Exception ex)
         {
            
         }

     }
     private object getCell(object oCells,int row,int col)
     {
        return oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oCells, new object[] { row, col });
     }
     public void Close()
     {            
         //Closing the work sheet            
        // oBook.GetType().InvokeMember("Close", System.Reflection.BindingFlags.InvokeMethod,null,oBook,null, CultureInfo.InvariantCulture);

         // CHECK IF EXCEL APPLICATION IS STILL INSTANCIATED
         if ((moApp != null) == true)
         {
             // CHECK IF INSTANCE HAS ANY OPEN WORKBOOKS
             object oWBs = moApp.GetType().InvokeMember("Workbooks", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, moApp, null);
             if (System.Convert.ToInt32(oWBs.GetType().InvokeMember("Count", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oWBs, null)) > 0)
             {
                 // CLOSE ALL OPEN WORKBOOKS & DONT SAVE THEM
                 // LOOP BACKWARDS SO INDEX INFORMATION WILL BE RELEVANT AS THEY CLOSE
                 for (int i = System.Convert.ToInt32(oWBs.GetType().InvokeMember("Count",
                     BindingFlags.InvokeMethod | BindingFlags.GetProperty, null, oWBs, null)); i >= 1; i--)
                 {
                     // moApp.Workbooks.Item(i).Close(false)
                     object oWB = oWBs.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                         BindingFlags.GetProperty, null, oWBs, new object[] { i });
                     /// .Close args: SaveChanges:=False, FileName:=vbNullString, RouteWorkbook:=False
                     oWB.GetType().InvokeMember("Close", BindingFlags.InvokeMethod, null, oWB,
                         new object[] { false, String.Empty, false });
                 }
             }
             // CLOSE OUR EXCEL APPLICATION OBJECT
             moApp.GetType().InvokeMember("Quit", BindingFlags.IgnoreReturn | BindingFlags.Instance |
                 BindingFlags.InvokeMethod, null, moApp, null);
         }
         // ENSURE ITS DESTROYED

         moApp = null;
         // ABSOLUTELY NONE OF OUR EXCEL INSTANCES WILL BE LEFT RUNNING
        
     }        
     public void Print()        
     {            
         //Printing the sheet            
        // oBook.GetType().InvokeMember("PrintOut", System.Reflection.BindingFlags.InvokeMethod,null,oBook,null, CultureInfo.InvariantCulture);

       
        
     }        
     public void Quit() 
     {            
         //Close the Excel application block            
         //Check the running processes using alt+ctrl+del            
         ExcelApplication.GetType().InvokeMember("Quit", System.Reflection.BindingFlags.InvokeMethod,null,ExcelApplication,null, CultureInfo.InvariantCulture);        
         
     }    
 }		
}
