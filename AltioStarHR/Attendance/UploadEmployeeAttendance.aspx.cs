using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using NPOI.XSSF.UserModel;
using NPOI.XSSF;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using HRManager.DTO;
using HRManager.BusinessObjects;
using HRManager.Entity;
using IRCAKernel;

namespace AltioStarHR.Attendance
{
    public partial class UploadEmployeeAttendance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                HttpPostedFile RequestFiles0 = Request.Files[0];
                string FileName = RequestFiles0.FileName;
                if (FileName != string.Empty)
                {
                    string strFile = Path.GetFileName(FileName);
                    string SaveLocation = Server.MapPath(Request.ApplicationPath) + @"\Resources\EmployeeAttendanceExcel\" + strFile;
                    RequestFiles0.SaveAs(SaveLocation);
                    UpdateAttendance(SaveLocation);
                }
            }
            else
            {
                hdnMonth.Value = Request.QueryString["comboMonth"];
                hdnYear.Value = Request.QueryString["comboYear"];
            }
        }

        private void UpdateAttendance(string MyFileName)
        {
            String Rslt = String.Empty;
            int Month = 0; int Year = 0; int Day = 0;
            Int32.TryParse(hdnYear.Value, out Year);
            Int32.TryParse(hdnMonth.Value, out Month);

            new Employee_Uploaded_AttandanceBusinessObject().DeleteExisitngMonthandYearData(Month, Year);
            try
            {
                int iLoopRows = 0; int rowCounter = 0;
                using (FileStream Xlfile = new FileStream(MyFileName, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook XLBook = new XSSFWorkbook(Xlfile);

                    ISheet LSheet = XLBook.GetSheetAt(0);
                    {
                        XSSFRow CurrentRow;
                        XSSFCell CurrentCell;

                        IEnumerator RowEnum = LSheet.GetRowEnumerator();

                        while (RowEnum.MoveNext())
                        {
                            iLoopRows++;

                            if (RowEnum.Current != null)
                            {
                                rowCounter++;
                                CurrentRow = (XSSFRow)RowEnum.Current;

                                for (Int32 iLoop = 0; iLoop < CurrentRow.Cells.Count; iLoop++)
                                {
                                    CurrentCell = (XSSFCell)CurrentRow.Cells[iLoop];

                                    if (CurrentCell.CellType == CellType.STRING && CurrentCell.StringCellValue == "LEV")
                                    {
                                        
                                        String EmpCode = CurrentRow.GetCell(0).StringCellValue;
                                        String EmpName = CurrentRow.GetCell(1).StringCellValue;
                                        String Date = LSheet.GetRow(0).GetCell(iLoop).NumericCellValue.ToString();
                                        Master_EmployeesBusinessObject oEmpBO = new Master_EmployeesBusinessObject();
                                        Master_Employees emp = oEmpBO.GetEmployeeDetByCode(EmpCode);

                                        if (emp != null)
                                        {
                                            Int32.TryParse(Date, out Day);
                                            DateTime dtAttd = new DateTime(Year, Month, Day);

                                            //int attID = oEmpBO.GetAttendanceID(emp.ID, dtAttd);
                                            
                                            EmployeeUploadedAttandance eua = new EmployeeUploadedAttandance();
                                            eua.ID = 0;
                                            eua.EmployeeID = emp.ID;
                                            eua.LeaveDate = dtAttd;
                                            eua.LeaveType = "";
                                            eua.Save();
                                        }
                                        Rslt = "DataThere";
                                    }
                                }
                            }
                        }
                    }
                    Xlfile.Close();
                }
                if(Rslt == String.Empty)
                    hdnSaveResult.Value = " No Data in uploaded file";
                else
                    hdnSaveResult.Value = " Attendance file uploaded successfully";
            }
            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
                hdnSaveResult.Value = "                  Error on UPLOAD \n Please Check the data in Uploaded file";
            }            
        }
    }
}
