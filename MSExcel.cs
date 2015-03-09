using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Globalization;
using System.Data;

namespace BillingManager
{
 public class MSExcel    {       
     Type ExcelType;        
     object ExcelApplication;        
     public object oBook;
     private object moApp;
     private object oWB;
     private object oSht;
     object oCells;
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
              oWB = oWBs.GetType().InvokeMember("Open", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oWBs, new string[] { AppDomain.CurrentDomain.BaseDirectory + strFileName});
             // GET THE WORKSHEETS COLLECTION
             object oShts = oWB.GetType().InvokeMember("Worksheets", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oWB, null);
             // GET THE FIRST SHEET
             oSht = oShts.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oShts, new object[] { 1 });
             // SAVE THE SHEET NAME
             string SheetName = oSht.GetType().InvokeMember("Name", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oSht, null).ToString();
             // GET THE CELLS COLLECTION
             oCells = oSht.GetType().InvokeMember("Cells", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oSht, null);
             //return oCells;
             // INITIALIZE VARIABLE AS AN OBJECT
             /*object oCell = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oCells, new object[] { 1, 1 });
             // WRITE CURRENT DATE/TIME - CELL A1
             oCell.GetType().InvokeMember("Value2", BindingFlags.SetProperty, null, oCell,
                 new string[] { System.DateTime.Now.ToString() });*/
            /* SetCellValue(oCells, 1, 1, "test value");
             // MAKE FIRST SHEET ACTIVE
             oSht.GetType().InvokeMember("Activate", BindingFlags.IgnoreReturn | BindingFlags.Public |
                 BindingFlags.Static | BindingFlags.InvokeMethod, null, oSht, null);
             // ENSURE VARIABLES ARE DESTROYED & RELEASED AS IT GOES OUT OF SCOPE
             SheetName = string.Empty;
             
             oCells = null;
             oSht = null;
             oShts = null;
             oWB = null;
             oWBs = null;
             // CALL THE GARBAGE COLLECT METHOD
             GC.Collect();
             GC.WaitForPendingFinalizers();*/
         }
         catch (Exception ex)
         {
            
         }

     }
     private void SetCellValue(object oCells,int row,int col,object val)
     {
        object  oCell= oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oCells, new object[] { row, col });
        oCell.GetType().InvokeMember("Value2", BindingFlags.SetProperty, null, oCell,
              new object[] { val });
        AutoSizeColumn(oSht, Convert.ToChar(col + Convert.ToInt16('A') - 1).ToString());// + row.ToString()
        // parameters[0] := Convert.ToChar(column + Convert.ToInt16('A') - 1) + row.ToString();
       //  parameters[1] := Convert.ToChar(col2 + Convert.ToInt16('A') - 1) + row2.ToString();

        /* object cRng= oSht.GetType().InvokeMember("Range", BindingFlags.InvokeMethod |
                BindingFlags.GetProperty, null, oSht, new object[] { Convert.ToChar(col + Convert.ToInt16('A') - 1) + row.ToString(), Convert.ToChar(col + Convert.ToInt16('A') - 1) + row.ToString() });
         cRng.GetType().InvokeMember("EntireColumn.AutoFit", BindingFlags.InvokeMethod |
               BindingFlags.GetProperty, null, cRng, new object[] { true });*/
        oCell = null;
        //cRng = null;
     }
     public void AutoSizeColumn(object oWorkSheet, string ColumnName)
     {
         //Columns("A:A").EntireColumn.AutoFit
         object oColumn =
             oWorkSheet.GetType().InvokeMember("Columns", BindingFlags.GetProperty, null, oWorkSheet,
                                               new object[] { ColumnName + ":" + ColumnName });

         object oEntireColumn =
             oColumn.GetType().InvokeMember("EntireColumn", BindingFlags.GetProperty, null, oColumn, null);

         oEntireColumn.GetType().InvokeMember("AutoFit", BindingFlags.InvokeMethod, null, oEntireColumn, null);

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

     public void GetSalesSummaryReport(DataTable dtSumm, String header, string sumDet)
     {
         Open("SALESSUMMARYREPORT.xlsx");
         string fname = "";
                      
            /*if (datFrom.Year <= 1900)
                strH = "SALES SUMMARY REPORT As On " + datTo.ToString("dd/MM/yyyy");
            else
                strH = "SALES SUMMARY REPORT From " + datFrom.ToString("dd/MM/yyyy") + " To " + datTo.ToString("dd/MM/yyyy");*/
         SetCellValue(oCells, 4, 1, header);   
         int k = 6;
        object oCell1 = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oCells, new object[] { 4, 1});
        object oCell2 = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                 BindingFlags.GetProperty, null, oCells, new object[] { 4, 5});
         object RNG= oSht.GetType().InvokeMember("Range", BindingFlags.InvokeMethod |
                BindingFlags.GetProperty, null, oSht, new object[] { oCell1, oCell2 });
         RNG.GetType().InvokeMember("Merge", BindingFlags.InvokeMethod |
                BindingFlags.GetProperty, null, RNG, new object[] { true});
         if (sumDet == "1")
         {
             if (dtSumm != null)
             {
                 foreach (DataRow dr in dtSumm.Rows)
                 {
                     SetCellValue(oCells, k, 1, string.Concat(dr["ItemCode"]));
                     SetCellValue(oCells, k, 2, string.Concat(dr["ItemName"]));
                     SetCellValue(oCells, k, 3, string.Concat(dr["Quantity"]));
                     SetCellValue(oCells, k, 4, string.Concat(dr["Rate"]));
                     SetCellValue(oCells, k, 5, string.Concat(dr["Amount"]));
                     k++;
                 }
             }
             fname = "SALESSUMMARYREPORT" + Math.Abs(DateTime.Now.GetHashCode()).ToString() + ".xlsx";
         }
         else
         {
             if (dtSumm != null)
             {
                 foreach (DataRow dr in dtSumm.Rows)
                 {
                     SetCellValue(oCells, k, 1, string.Concat(dr["BillDate"]));
                     SetCellValue(oCells, k, 2, string.Concat(dr["LocationCode"]));
                     SetCellValue(oCells, k, 3, string.Concat(dr["Location"]));
                     SetCellValue(oCells, k, 4, string.Concat(dr["ItemCode"]));
                     SetCellValue(oCells, k, 5, string.Concat(dr["ItemName"]));
                     SetCellValue(oCells, k, 6, string.Concat(dr["Quantity"]));
                     SetCellValue(oCells, k, 7, string.Concat(dr["Rate"]));
                     SetCellValue(oCells, k, 8, string.Concat(dr["Amount"]));
                     k++;
                 }
             }
             fname = "SALESSUMMARYDETAILREPORT" + Math.Abs(DateTime.Now.GetHashCode()).ToString() + ".xlsx";
         }
     }

     public void GetItemSalesReport(DataTable dtSumm, String header, string sumDet)
     {
         
         string fname = "";
         string tname = "";
         if (sumDet == "1")
             tname = "ITEMSALESDETAILREPORT.xlsx";
         else
             tname = "ITEMSALESSUMMARYREPORT.xlsx";
         Open(tname);
        
          
         SetCellValue(oCells, 4, 1, header);
         int k = 6;
         object oCell1 = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                  BindingFlags.GetProperty, null, oCells, new object[] { 4, 1 });
         object oCell2 = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                  BindingFlags.GetProperty, null, oCells, new object[] { 4, 5 });
         object RNG = oSht.GetType().InvokeMember("Range", BindingFlags.InvokeMethod |
                BindingFlags.GetProperty, null, oSht, new object[] { oCell1, oCell2 });
         RNG.GetType().InvokeMember("Merge", BindingFlags.InvokeMethod |
                BindingFlags.GetProperty, null, RNG, new object[] { true });
         if (sumDet == "1")
         {
             if (dtSumm != null)
             {
                 foreach (DataRow dr in dtSumm.Rows)
                 {
                     SetCellValue(oCells, k, 1, string.Concat(dr["BillNo"]));
                     SetCellValue(oCells, k, 2, string.Concat(dr["BillDate"]));
                     SetCellValue(oCells, k, 3, string.Concat(dr["POS"]));
                     SetCellValue(oCells, k, 4, string.Concat(dr["AccountNumber"]));
                     SetCellValue(oCells, k, 5, string.Concat(dr["MemberName"]));
                     SetCellValue(oCells, k, 6, string.Concat(dr["ItemNo"]));
                     SetCellValue(oCells, k, 7, string.Concat(dr["ItemName"]));
                     SetCellValue(oCells, k, 8, string.Concat(dr["Unit"]));
                     SetCellValue(oCells, k, 9, string.Concat(dr["Quantity"]));
                     SetCellValue(oCells, k, 10, string.Concat(dr["Rate"]));
                     SetCellValue(oCells, k, 11, string.Concat(dr["Total"]));
                     SetCellValue(oCells, k, 12, string.Concat(dr["OTNo"]));
                     SetCellValue(oCells, k, 13, string.Concat(dr["BearerID"]));
                     SetCellValue(oCells, k, 14, string.Concat(dr["Counter"]));
                     k++;
                 }
             }
            }
            else
            {
                         foreach (DataRow dr in dtSumm.Rows)
                         {
                             SetCellValue(oCells, k, 1, string.Concat(dr["BillNo"]));
                             SetCellValue(oCells, k, 2, string.Concat(dr["BillDate"]));
                             SetCellValue(oCells, k, 3, string.Concat(dr["AccountNumber"]));
                             SetCellValue(oCells, k, 4, string.Concat(dr["MemberName"]));
                             SetCellValue(oCells, k, 5, string.Concat(dr["Total"]));
                             SetCellValue(oCells, k, 6, string.Concat(dr["POS"]));
                             SetCellValue(oCells, k, 7, string.Concat(dr["OTNo"]));
                             SetCellValue(oCells, k, 8, string.Concat(dr["BearerID"]));
                             SetCellValue(oCells, k, 9, string.Concat(dr["Counter"]));
                             k++;
                         }
            }
             fname = "ITEMSALESSUMMARYREPORT" + Math.Abs(DateTime.Now.GetHashCode()).ToString() + ".xlsx";
         }

     public void GetItemwiseSalesReport(DataTable dtSumm, String header)
     {
         
         string fname = "";
         string tname = "";
         
        
          
         tname = "ITEMWISESALESREPORT.xlsx";
         Open(tname);
         SetCellValue(oCells, 4, 1, header);
         int k = 6;
         object oCell1 = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                  BindingFlags.GetProperty, null, oCells, new object[] { 4, 1 });
         object oCell2 = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                  BindingFlags.GetProperty, null, oCells, new object[] { 4, 5 });
         object RNG = oSht.GetType().InvokeMember("Range", BindingFlags.InvokeMethod |
                BindingFlags.GetProperty, null, oSht, new object[] { oCell1, oCell2 });
         RNG.GetType().InvokeMember("Merge", BindingFlags.InvokeMethod |
                BindingFlags.GetProperty, null, RNG, new object[] { true });
        
          k = 6;
          
         foreach (DataRow dr in dtSumm.Rows)
         {
             SetCellValue(oCells, k, 1, string.Concat(dr["BillNo"]));
             SetCellValue(oCells, k, 2, string.Concat(dr["BillDate"]));
             SetCellValue(oCells, k, 3, string.Concat(dr["AccountNumber"]));
             SetCellValue(oCells, k, 4, string.Concat(dr["MemberName"]));
             SetCellValue(oCells, k, 5, string.Concat(dr["ItemNo"]));
             SetCellValue(oCells, k, 6, string.Concat(dr["ItemName"]));
             SetCellValue(oCells, k, 7, string.Concat(dr["Unit"]));
             SetCellValue(oCells, k, 8, string.Concat(dr["Quantity"]));
             SetCellValue(oCells, k, 9, string.Concat(dr["Rate"]));
             SetCellValue(oCells, k, 10, string.Concat(dr["Total"]));
             SetCellValue(oCells, k, 11, string.Concat(dr["OTNo"]));
             SetCellValue(oCells, k, 12, string.Concat(dr["BearerID"]));
             SetCellValue(oCells, k, 12, string.Concat(dr["Counter"]));
              k++;
         }
         fname = "ITEMWISESALESREPORT" + Math.Abs(DateTime.Now.GetHashCode()).ToString() + ".xlsx";
                   
         }


     public void GetStockSummaryReport(DataTable dtSumm, String header, string wval)
     {
         Open("STOCKREGISTER.xlsx");
         string fname = "";
          
         SetCellValue(oCells, 4, 1, header);
         int k = 6;
         object oCell1 = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                  BindingFlags.GetProperty, null, oCells, new object[] { 4, 1 });
         object oCell2 = oCells.GetType().InvokeMember("Item", BindingFlags.InvokeMethod |
                  BindingFlags.GetProperty, null, oCells, new object[] { 4, 5 });
         object RNG = oSht.GetType().InvokeMember("Range", BindingFlags.InvokeMethod |
                BindingFlags.GetProperty, null, oSht, new object[] { oCell1, oCell2 });
         RNG.GetType().InvokeMember("Merge", BindingFlags.InvokeMethod |
                BindingFlags.GetProperty, null, RNG, new object[] { true });
         int srno=0;
             if (dtSumm != null)
             {
                   string datVal = string.Empty;
                    int rcnt = dtSumm.Rows.Count;
                    double dblOpn = 0; double dblRec = 0; double dblIss = 0; double dblAdj = 0; double dblCls = 0;
                 foreach (DataRow dr in dtSumm.Rows)
                 {
                     SetCellValue(oCells, k, 1, srno);
                     SetCellValue(oCells, k, 2, string.Concat(dr["GroupName"]) + "(" + string.Concat(dr["GroupCode"]) + ")");
                     SetCellValue(oCells, k, 3, string.Concat(dr["ItemCode"]) );
                     SetCellValue(oCells, k, 4, string.Concat(dr["ItemName"]) );
                     SetCellValue(oCells, k, 5, string.Concat(dr["UnitName"]) );
                     dblOpn = 0;
                     double.TryParse(string.Concat(dr["OpeningBalanceBtl"]), out dblOpn);
                     SetCellValue(oCells, k, 6, Math.Round(dblOpn, 2).ToString());
                     dblOpn = 0;
                     double.TryParse(string.Concat(dr["OpeningBalance"]), out dblOpn);
                     SetCellValue(oCells, k, 7, Math.Round(dblOpn, 2).ToString());
                     dblRec = 0;
                     double.TryParse(string.Concat(dr["ReceivedQty"]), out dblRec);
                     SetCellValue(oCells, k, 8,Math.Round(dblRec, 2).ToString() );
                     dblIss = 0;
                     double.TryParse(string.Concat(dr["IssuedQty"]), out dblIss);
                     SetCellValue(oCells, k, 9,Math.Round(dblIss, 2).ToString() );
                     dblAdj = 0;
                     double.TryParse(string.Concat(dr["AdjustedQty"]), out dblAdj);
                     SetCellValue(oCells, k, 10,Math.Round(dblAdj, 2).ToString() );;
                     dblCls = 0;
                     double.TryParse(string.Concat(dr["ClosedBtl"]), out dblCls);
                     SetCellValue(oCells, k, 11,Math.Round(dblCls, 2).ToString() );;
                     dblCls = dblOpn + dblRec - dblIss + dblAdj;
                     SetCellValue(oCells, k, 12,Math.Round(dblCls, 2).ToString() );;
                     if (wval == "true")
                     {
                         dblCls = 0;
                         double.TryParse(string.Concat(dr["Rate"]), out dblCls);
                         SetCellValue(oCells, k, 13,Math.Round(dblCls, 2).ToString() );;
                         dblCls = 0;
                         double.TryParse(string.Concat(dr["FinalValue"]), out dblCls);
                         SetCellValue(oCells, k, 14,Math.Round(dblCls, 2).ToString() );;
                     }
                     k++;
                     srno++;
                 }
             }
             fname = "STOCKREGISTER" + Math.Abs(DateTime.Now.GetHashCode()).ToString() + ".xlsx";
          
         
     }

 }		
}
