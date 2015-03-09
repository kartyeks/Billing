using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using IS91.Services.DataBlock;
using System.Data;
using HRManager.DTOEXT;
using IRCAKernel;

namespace HRManager.BusinessObjects
{
    public partial class Employee_Uploaded_AttandanceBusinessObject
    {
        public Employee_Uploaded_Attandance[] GetEmployeeUploadedAttendance()
        {
            const String Qry = " SELECT * FROM Employee_Uploaded_Attandance";

            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            exQry.Query = string.Format(Qry);

            DataTable dt = EE.ExecuteDataTable(exQry);

            Employee_Uploaded_Attandance[] data = new Employee_Uploaded_Attandance[dt.Rows.Count];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new Employee_Uploaded_Attandance();
                data[i].ID = (int)dt.Rows[i]["ID"];
                data[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                data[i].LeaveDate = (DateTime)dt.Rows[i]["LeaveDate"];
                data[i].LeaveType = (String)dt.Rows[i]["LeaveType"];
            }

            return data;
        }

        public Employee_Uploaded_AttandanceEXT[] GetUploadedAttendanceAndEmpData(int Month, int year)
        {
            ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
            ExecutionQuery exQry = new ExecutionQuery();

            const String Qry1 = " IF EXISTS (SELECT * FROM Employee_Uploaded_Attandance WHERE Month(LeaveDate) = {0} AND Year(LeaveDate) = {1})"
                                + " SELECT 0"
                                + " ELSE"
                                + " SELECT 1";

            exQry.Query = string.Format(Qry1, Month, year);
            bool IsDataThere = string.Concat(EE.ExecuteScalar(exQry)) == "0";

            const String Qry = " SELECT "
                                + "    (FirstName + ' ' + LastName + ' ' + MiddleName) EmployeeName "
                                + "    ,EmpCode "
                                + "    ,ISNULL(TeamName,'')TeamName "
                                + "    ,Count(A.EmployeeID) LeaveCount"
                                + " FROM Master_Employees B "
                                + " {2} JOIN Employee_Uploaded_Attandance A"
                                + "     ON A.EmployeeID = B.ID AND Month(A.LeaveDate) = {0} AND Year(A.LeaveDate) = {1}"
                                + " LEFT JOIN Employee_OccupationDetails EOD "
                                + "     ON EOD.EmployeeID = B.ID AND EOD.IsActive = 1"
                                + " LEFT JOIN Master_Team MT "
	                            + "     ON MT.ID = EOD.TeamID "
                                + " WHERE  B.IsActive = 1 and IsDeleted = 0"
                                + " GROUP BY "
	                            + "     (FirstName + ' ' + LastName + ' ' + MiddleName) "
                                + "     ,EmpCode "
	                            + "     ,TeamName "
                                + " Order BY EmpCode Asc";

            if ((Month == 0 && year == 0) || IsDataThere == false)
                exQry.Query = string.Format(Qry, Month, year, "INNER");
            else
                exQry.Query = string.Format(Qry, Month, year, "LEFT");

            DataTable dt = EE.ExecuteDataTable(exQry);

            Employee_Uploaded_AttandanceEXT[] data = new Employee_Uploaded_AttandanceEXT[dt.Rows.Count];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new Employee_Uploaded_AttandanceEXT();
                //data[i].ID = (int)dt.Rows[i]["ID"];
                //data[i].EmployeeID = (int)dt.Rows[i]["EmployeeID"];
                //data[i].LeaveDate = (DateTime)dt.Rows[i]["LeaveDate"];
                //data[i].LeaveType = (String)dt.Rows[i]["LeaveType"];

                data[i].EmpName = (String)dt.Rows[i]["EmployeeName"];
                data[i].EmpCode = (String)dt.Rows[i]["EmpCode"];
                data[i].Team = (String)dt.Rows[i]["TeamName"];
                data[i].LeaveCount = (int)dt.Rows[i]["LeaveCount"];
                data[i].CurrentMonth = GetFullMonthName(Month);
                data[i].CurrentYear = year;

                if (Month == 1 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
                    data[i].TotalDays = 31;

                else if (Month == 2)
                {
                    if (year % 4 == 0)
                        data[i].TotalDays = 29;
                    else
                        data[i].TotalDays = 28;
                }

                else
                    data[i].TotalDays = 30;

                data[i].DaysWorked = data[i].TotalDays - data[i].LeaveCount;
            }

            return data;
        }

        private String GetFullMonthName(int MonthNo)
        {
            String MonthName = "";
            if (MonthNo == 1)
                MonthName = "January";
            else if (MonthNo == 2)
                MonthName = "February";
            else if (MonthNo == 3)
                MonthName = "March";
            else if (MonthNo == 4)
                MonthName = "April";
            else if (MonthNo == 5)
                MonthName = "May";
            else if (MonthNo == 6)
                MonthName = "June";
            else if (MonthNo == 7)
                MonthName = "July";
            else if (MonthNo == 8)
                MonthName = "August";
            else if (MonthNo == 9)
                MonthName = "September";
            else if (MonthNo == 10)
                MonthName = "October";
            else if (MonthNo == 11)
                MonthName = "November";
            else if (MonthNo == 12)
                MonthName = "December";

            return MonthName;
        }

        public int DeleteExisitngMonthandYearData(int Month, int Year)
        {
            try
            {
                const String Qry = " Delete From Employee_Uploaded_Attandance Where Month(LeaveDate) = {0} AND Year(LeaveDate) = {1}";

                ExecutionEngine EE = ExecutionEngine.CreateNewExecutionEngine(Configuration.DatabaseServerType, Configuration.ConnectionString);
                ExecutionQuery exQry = new ExecutionQuery();
                exQry.Query = string.Format(Qry, Month, Year);
                return EE.ExecuteNonQuery(exQry);
            }
            catch (Exception w)
            {
                IRCAExceptionHandler.HandleException(w);
                return 0;
            }
        }
    }
}
