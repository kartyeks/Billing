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
using IS91.Services;
using System.Text;
using Authentication.BusinessObjects;

namespace AltioStarHR.Masters
{
    public partial class BulkDataUpload : System.Web.UI.Page
    {

        StringBuilder strB = new StringBuilder();
        string jScriptValidator = string.Empty;
        string strEmployeeCode = string.Empty;
        string strError = string.Empty;
        string strExcelFile = string.Empty;
        int totcnt = 0;
        int cnt = 0;
        string strRes = string.Empty;
        string strFile = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            if (IsPostBack)
            {
                HttpPostedFile RequestFiles0 = Request.Files[0];
                string FileName = RequestFiles0.FileName;
                if (FileName != string.Empty)
                {
                     strFile = Path.GetFileName(FileName);
                    string SaveLocation = Server.MapPath(Request.ApplicationPath) + @"\Resources\ExcelUpload\" + strFile;
                    RequestFiles0.SaveAs(SaveLocation);
                    UploadEmpData(SaveLocation);
                }
            }
        }

        private void UploadEmpData(string MyFileName)
        {
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);

            String Rslt = String.Empty;

            Master_Employees objEmp = null;
            Employee_OccupationDetails objEmpOcup = null;
            Employee_Salary objEmpSal = null;

            Master_EmployeeTypeBusinessObject objEmpTypeBO = new Master_EmployeeTypeBusinessObject();
            Master_MaritalStatusBusinessObject objMaritalBO = new Master_MaritalStatusBusinessObject();
            Master_CountryBusinessObject objCountryBO = new Master_CountryBusinessObject();
            Master_LocationBusinessObject objLocBO = new Master_LocationBusinessObject();
            Master_TeamBusinessObject objTeamBO = new Master_TeamBusinessObject();
            Hr_DesignationBusinessObject objDesigBO = new Hr_DesignationBusinessObject();


            Employee_OccupationDetailsBusinessObject objEmpOcupBO = new Employee_OccupationDetailsBusinessObject();
            Employee_SalaryBusinessObject objEmpSalBO = new Employee_SalaryBusinessObject();
            Master_EmployeesBusinessObject objEmpBO = new Master_EmployeesBusinessObject();

            DateTime dob = DateTime.Today;
            DateTime doj = DateTime.Today;
            string strStateID = string.Empty;
            int emptypeID = 0;
            int maritalID = 0;
            int countryID = 0;
            int locationID = 0;
            int teamID = 0;
            int designationID = 0;
            int employeeID = 0;
            try
            {
                int iLoopRows = 0; int rowCounter = 0; int CNT = 0;
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
                            try
                            {



                                iLoopRows++;
                                if (iLoopRows == 1) continue;

                                if (RowEnum.Current != null)
                                {
                                    rowCounter++;
                                    CurrentRow = (XSSFRow)RowEnum.Current;

                                    //for (Int32 iLoop = 0; iLoop < CurrentRow.Cells.Count; iLoop++)
                                    //{
                                    CurrentCell = (XSSFCell)CurrentRow.Cells[0];
                                    totcnt++;
                                    employeeID = 0;
                                    dob = new DateTime(1900, 1, 1);
                                    doj = new DateTime(1900, 1, 1);
                                    string strEmployeeCode = CurrentRow.GetCell(0).StringCellValue;
                                    if (strEmployeeCode == string.Empty)
                                    {
                                        strB.Append(strEmployeeCode + " Invalid Employee Code  not uploaded\n\r");
                                        continue;
                                    }
                                    if (new Master_EmployeesBusinessObject().IsEmployeeCodeExists(strEmployeeCode))
                                    {
                                        strB.Append(strEmployeeCode + "  Employee Code already Exists\n\r");
                                        continue;
                                    }
                                    objEmp = new Master_Employees();
                                    objEmp.EmpCode = strEmployeeCode;

                                    string stremptypeID = new Setting_ConfigurationBusinessObject().GetEmployeeTypeID(CurrentRow.GetCell(1).StringCellValue);
                                    if (stremptypeID == string.Empty)
                                    {
                                        strB.Append(strEmployeeCode + " Invalid employee type not uploaded\n\r");
                                        continue;
                                    }
                                    Int32.TryParse(stremptypeID, out emptypeID);
                                    objEmp.EmployeeTypeID = emptypeID;
                                    objEmp.FirstName = CurrentRow.GetCell(2).StringCellValue;
                                    if (objEmp.FirstName == string.Empty)
                                    {
                                        strB.Append(strEmployeeCode + "  First Name is empty not uploaded\n\r");
                                        continue;
                                    }
                                    objEmp.LastName = CurrentRow.GetCell(3).StringCellValue;
                                    if (objEmp.LastName == string.Empty)
                                    {
                                        strB.Append(strEmployeeCode + "  Last Name is empty not uploaded \n\r");
                                        continue;
                                    }
                                    objEmp.PersonalEmailID = CurrentRow.GetCell(4).StringCellValue;
                                    try
                                    {
                                        dob = CurrentRow.GetCell(5).DateCellValue;
                                        if (CurrentRow.GetCell(5).DateCellValue.ToString() == string.Empty)
                                        {
                                            strB.Append(strEmployeeCode + "  DOB is empty not uploaded \n\r");
                                            continue;
                                        }
                                    }
                                    catch (Exception exd)
                                    {
                                        Logger.LogThis(exd);
                                        strB.Append(strEmployeeCode + "  Date of Birth is invalid not uploaded \n\r");
                                        continue;
                                    }
                                    if (dob.Year < 1900)
                                    {
                                        strB.Append(strEmployeeCode + "  Date of Birth is invalid not uploaded \n\r");
                                        continue;
                                    }
                                    objEmp.DOB = dob;
                                    objEmp.Gender = CurrentRow.GetCell(6).StringCellValue;
                                    if (objEmp.Gender == string.Empty)
                                    {
                                        strB.Append(strEmployeeCode + "  Gender is empty not uploaded \n\r");
                                        continue;
                                    }
                                    if (objEmp.Gender.Length > 1) objEmp.Gender = objEmp.Gender.Substring(0, 1);

                                    string strmaritalID = new Setting_ConfigurationBusinessObject().GetMaritalStatusID(CurrentRow.GetCell(7).StringCellValue);
                                    if (!strEmployeeCode.Contains('C'))
                                    {
                                        if (strmaritalID == string.Empty)
                                        {
                                            strB.Append(strEmployeeCode + " Invalid marital status not uploaded \n\r");
                                            continue;
                                        }
                                    }
                                    Int32.TryParse(strmaritalID, out maritalID);
                                    objEmp.MaritalStatusID = maritalID;
                                    objEmp.PermanentAddress = CurrentRow.GetCell(8).StringCellValue;
                                    if (!strEmployeeCode.Contains('C'))
                                    {
                                        if (CurrentRow.GetCell(8).StringCellValue.ToString() == string.Empty)
                                        {
                                            strB.Append(strEmployeeCode + "  Permanent Address is empty not uploaded \n\r");
                                            continue;
                                        }
                                    }
                                    objEmp.CurrentAddress = CurrentRow.GetCell(9).StringCellValue;
                                    if (!strEmployeeCode.Contains('C'))
                                    {
                                        if (CurrentRow.GetCell(9).StringCellValue.ToString() == string.Empty)
                                        {
                                            strB.Append(strEmployeeCode + "  Current Address is empty not uploaded \n\r");
                                            continue;
                                        }
                                    }
                                    if (CurrentRow.GetCell(10).CellType == CellType.NUMERIC)
                                        objEmp.MobileNumber = string.Concat(CurrentRow.GetCell(10).NumericCellValue);
                                    else
                                        objEmp.MobileNumber = CurrentRow.GetCell(10).StringCellValue;
                                    if (!strEmployeeCode.Contains('C'))
                                    {
                                        if (objEmp.MobileNumber == string.Empty)
                                        {
                                            strB.Append(strEmployeeCode + "  Mobile Number is empty not uploaded \n\r");
                                            continue;
                                        }
                                    }
                                    if (CurrentRow.GetCell(11).CellType == CellType.NUMERIC)
                                        objEmp.EmergencyContactNumber = string.Concat(CurrentRow.GetCell(11).NumericCellValue);
                                    else
                                        objEmp.EmergencyContactNumber = CurrentRow.GetCell(11).StringCellValue;
                                    objEmp.IsActive = true;
                                    objEmp.CreatedBy = int.Parse(objCurrUser.UserId.ToString());
                                    objEmp.CreatedDate = DateTime.Now;
                                    objEmp.IsDeleted = false;
                                    byte[] photo = null;
                                    photo = new byte[1000 * 1000 * 3];
                                    objEmp.Photo = photo;
                                    objEmp.ModifiedBy = 0;
                                    objEmp.ModifiedDate = DateTime.Now;
                                 
                                    employeeID = objEmpBO.Create(objEmp);

                                    if (employeeID != 0)
                                    {
                                        CNT++;
                                        try
                                        {
                                            objEmpOcup = new Employee_OccupationDetails();
                                            //ADDING INTO EMPLOYEE_OCCUPATIONAL TABLE WITH EMPLOYEEID
                                            objEmpOcup.EmployeeID = employeeID;
                                            string strcountyID = new Setting_ConfigurationBusinessObject().GetCountryID(CurrentRow.GetCell(12).StringCellValue);
                                            if (strcountyID == string.Empty)
                                            {
                                                strB.Append(strEmployeeCode + " Invalid country  \n\r");
                                                continue;
                                            }
                                            Int32.TryParse(strcountyID, out countryID);
                                            objEmpOcup.CountryID = countryID;

                                            string strlocationID = new Setting_ConfigurationBusinessObject().GetLocationID(CurrentRow.GetCell(13).StringCellValue);
                                            if (strlocationID == string.Empty)
                                            {
                                                strB.Append(strEmployeeCode + " Invalid location   \n\r");
                                                continue;
                                            }
                                            Int32.TryParse(strlocationID, out locationID);
                                            objEmpOcup.LocationID = locationID;

                                            try
                                            {
                                                doj = CurrentRow.GetCell(14).DateCellValue;
                                                if (CurrentRow.GetCell(14).DateCellValue.ToString() == string.Empty)
                                                {
                                                    strB.Append(strEmployeeCode + " Invalid DOJ   \n\r");
                                                    continue;
                                                }
                                            }
                                            catch (Exception exd)
                                            {
                                                Logger.LogThis(exd);
                                                strB.Append(strEmployeeCode + "  Date of joining is invalid not uploaded\n\r");
                                                continue;
                                            }
                                            if (doj.Year < 1900)
                                            {
                                                strB.Append(strEmployeeCode + "  Date of joining is invalid not uploaded \n\r");
                                                continue;
                                            }
                                                                                      
                                          string  extdt = CurrentRow.GetCell(21).DateCellValue.ToString();
                                            if (extdt == "01/01/0001 00:00:00")
                                            {
                                                objEmpOcup.ExitDate = Convert.ToDateTime("1900-01-01");
                                            }
                                            else
                                            {
                                                objEmpOcup.ExitDate = CurrentRow.GetCell(21).DateCellValue;
                                            }
                                            if (CurrentRow.GetCell(20).StringCellValue == "")
                                            {
                                                objEmpOcup.TypeOfExitID = 0;
                                            }
                                            else
                                            {
                                                int exitid = 0;
                                                string strexitid = new Setting_ConfigurationBusinessObject().GetExitTypeID(CurrentRow.GetCell(20).StringCellValue);
                                                if (strexitid == string.Empty)
                                                {
                                                    strB.Append(strEmployeeCode + " Invalid Exit Type   \n\r");
                                                   
                                                }
                                                Int32.TryParse(strexitid, out exitid);
                                             
                                                objEmpOcup.TypeOfExitID = exitid;
                                            }
                                            objEmpOcup.LocationID = locationID;
                                            objEmpOcup.JoiningDate = doj;
                                            if (CurrentRow.GetCell(15) == null)
                                            {
                                                objEmpOcup.EmailID = string.Empty;
                                            }
                                            else
                                            {
                                                objEmpOcup.EmailID = CurrentRow.GetCell(15).StringCellValue;
                                            }
                                            double leavecnt = 0;
                                            double.TryParse(string.Concat(CurrentRow.GetCell(16).NumericCellValue), out leavecnt);
                                            if (CurrentRow.GetCell(16).DateCellValue.ToString() == string.Empty)
                                            {
                                                strB.Append(strEmployeeCode + " Invalid leave count   \n\r");
                                                continue;
                                            }
                                            objEmpOcup.LeavesCount = leavecnt;

                                            string strTeamID = new Setting_ConfigurationBusinessObject().GetTeamID(string.Concat(CurrentRow.GetCell(17).StringCellValue));
                                            if (strTeamID == string.Empty)
                                            {
                                                strB.Append(strEmployeeCode + " Invalid team \n\r");
                                                continue;
                                            }
                                            Int32.TryParse(strTeamID, out teamID);
                                        
                                            objEmpOcup.TeamID = teamID;
                                            string strdesigID = new Setting_ConfigurationBusinessObject().GetDesignationID(string.Concat(CurrentRow.GetCell(18).StringCellValue));
                                            if (strdesigID == string.Empty)
                                            {
                                                strB.Append(strEmployeeCode + " Invalid designation  \n\r");
                                                continue;
                                            }
                                            Int32.TryParse(strdesigID, out designationID);
                                            objEmpOcup.DesignationID = designationID;
                                    
                                            objEmpOcup.IsActive = true;
                                            objEmpOcup.ActivatedBy = int.Parse(objCurrUser.UserId.ToString());
                                            objEmpOcup.ActivatedDate = DateTime.Now;
                                            objEmpOcupBO.Create(objEmpOcup);
                                            try
                                            {
                                                if (CurrentRow.GetCell(21).DateCellValue.ToString() != "01/01/0001 00:00:00")
                                                {
                                                    Master_Employees objemp1 = new Master_EmployeesBusinessObject().GetMaster_Employees(employeeID);
                                                    if (objemp1 != null)
                                                    {
                                                        objemp1.IsActive = false;
                                                        new Master_EmployeesBusinessObject().Update(objemp1);
                                                    }

                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                Logger.LogThis(ex);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            IS91.Services.Logger.LogThis(ex);
                                        }
                                        //ADD  User Details
                                        if (CurrentRow.GetCell(19).StringCellValue != string.Empty)
                                        {
                                            try
                                            {
                                                CommonManager.Entity.User objUser = new CommonManager.Entity.User();
                                                objUser.EmployeeID = employeeID;
                                                objUser.LoginName = string.Concat(CurrentRow.GetCell(19).StringCellValue);
                                                objUser.IsActive = true;
                                                objUser.IsChangePassword = false;
                                                objUser.IsLocked = false;
                                                objUser.LastLoginTime = new DateTime(1900, 01, 01);
                                                objUser.InvalidLoginCount = 0;
                                                objUser.LoginType = "EMP";
                                                objUser.ModifiedBy = 0;
                                                objUser.ModifiedDate = new DateTime(1900, 01, 01); ;
                                                objUser.Password = "";
                                                objUser.UserID = 0;
                                                objUser.SaveUser();
                                            }
                                            catch (Exception ex)
                                            {
                                                Logger.LogThis(ex);
                                            }
                                        }

                                    }
                                    else
                                    {

                                    }

                                    //}
                                }
                            }
                            catch (Exception ex)
                            {
                                IS91.Services.Logger.LogThis(ex);
                            }
                        }
                    }
                    if (CNT > 0)
                    {
                        jScriptValidator = "<script> alert('Employee Data Uploaded Sccessfully.(" + string.Concat(CNT) + " of " + string.Concat(rowCounter) + ")');";
                        
                        jScriptValidator += " </script>";


                    }
                    Xlfile.Close();
                }
              
            }
            catch (Exception ee)
            {
                IRCAExceptionHandler.HandleException(ee);
              //  hdnSaveResult.Value = "                  Error on UPLOAD \n Please Check the data in Uploaded file";
                jScriptValidator = "<script> alert('Data is not correct in the uploaded file,Error occured while uploading data.');";
                jScriptValidator += " </script>";
            }
            finally
            {
                jScriptValidator += " <script> ";
                if (strB.Length > 0)
                {
                    long tcks = DateTime.Now.Ticks;
                    string filname = strFile + "_Log" + tcks.ToString() + ".txt";
                    System.IO.TextWriter w = new System.IO.StreamWriter(Server.MapPath(HttpContext.Current.Request.ApplicationPath) + @"\Resources\LogFiles\" + filname);
                    w.Write(strB.ToString());
                    w.Flush();
                    w.Close();
                    jScriptValidator += " var left = (screen.width / 2)-100;var top = (screen.height / 2)-100;var wnd=window.open('../Resources/LogFiles/" + filname + "','wndEmployeeLog','width=400,height=200,resizable=yes,location=no,,menubar=no,scrollbars=yes,left='+left + ',top=' + top );wnd.document.title = 'Employee Data Upload Log';";
                }
                jScriptValidator += "window.returnValue=true;window.close();";
                jScriptValidator += " </script>";
                ClientScript.RegisterStartupScript(this.GetType(), "regJSval", jScriptValidator);
            }
        }
    }
}
