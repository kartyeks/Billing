using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS91.Services.DataBlock;

namespace HRManager.Communication.Request
{
    public class UpdateEmployeeRequest
    {
        public int EmployeeID;
        public int CandidateID;
        public string EMailID;
        public int DesignationID;
        public int RoleID;
        public int LocationID;
        public bool IsPermenant;
        public bool IsResigned;
        public bool IsRetired;
        public bool IsExtended;
        public bool IsProbationaryPeriod;
        public DateTime ProbationaryUpTo;
        public string Status;
        public int DepartmentID;
        public int BranchID;
        public int GradeID;
    }

    public class UpdateEmployeesRequest
    {
        public int ID;
        public int CandidateID;
        public int DepartmentID;
        public string EmpCode;
        public string EMailID;
        public int EmploymentType;
        public byte[] Photo;
        public string Status;
        public string BloodGroup;
        public int BranchID;
        public int GradeID;
        public int DesignationID;
        public DateTime DateOfJoining;
        public int ReprotingMgrID;
        public int FunctionalReportingTo;
        public int LoanApprover;
        public int UpdateBy;
        public DateTime ConfirmationDate;
        public DateTime ConfirmationDueDate;
        public int ReprotingMgrLocID;
        public int FunctionalReportingLocTo;

        //Candidate Personal Info
        public String CEMailID;
        public DateTime DOB;
        public String MaritialStatus;
        public String FatherName;
        public String PAddess;
        public String PStreet;
        public int PStateID;
        public String PCity;
        public String PZipCode;
        public String PPhoneNo;
        public String PMobileNumber;
        public String TStreet;
        public int TStateID;
        public String TCity;
        public String TAddess;
        public String TZipCode;
        public String MobileNumber;
        public String TelephoneNoRes;
        public String TelephoneNoOff;

        //Employee Bank Info
        public int EmpBankID;
        public int BankBranchID;
        public string AccountNumber;
        public int CreatedBy;
        public int ModifedBy;
        //Emplloyee Type History
        public DateTime TypeChangeDateTime;
        public string Reason;
        public DateTime RetirementDate;
        public string Graduate;
        public bool IsTechnical;
        public string Degree;
        // added by archana on 10/08/2012, for payroll generation fixings.
        public DateTime DesigDate;
        public DateTime DeptDate;
        public DateTime BranchDate;
        public DateTime GradeDate;

        public DateTime WeddingDay;
    }

    public class UpdateEmployeeFamilyRequest
    {
        public int ID;
        public int CandidateID;
        public int RelationID;
        public string Name;
        public DateTime DateOfBirth;
        public string Occupation;
        public string AnnualIncome;
        public Session DBSession;
    }

    public class UpdateEmployeePrevEmploymentRequest
    {
        public int ID;
        public int CandidateID;
        public double CTC;
        public string Designation;
        public string EmployerName;
        public DateTime EndDate;
        public string ResonForLeaving;
        public string Responsibilities;
        public DateTime StartDate;
        public double TakeHome;
    }

    public class UpdateEmployeeAcademicRequest
    {
        public int ID;
        public int CandidateID;
        public string Title;
        public string Institute;
        public string Subject;
        public double Percentage;
        public string Grade;
        public DateTime FromDate;
        public DateTime ToDate;
    }
    public class UpdateEmployeeTrainingRequest
    {
        public int ID;
        public int CandidateID;
        public string OrganizedBy;
        public string Duration;
        public string Subject;
        public string Certificate;
    }

    public class UpdateEmployeeShiftRequest
    {
        public int ID;
        public int EmpID;
        public string Shift;
    }

    public class EmployeeInfoRequest
    {
        public int CandidateID;
        public int EmployeeID;
        public int DesignationID;
    }
    public class EmployeeInfoByLocBraRequest
    {
        public int LocationID;
        public int BranchID;
        public int DepartmentID;
        public int Month;
        public int Year;
    }
    public class EmployeeInfoForOT
    {
        public int LocationID;
        public int BranchID;
        public int DepartmentID;
        public int Month;
        public int Year;
        public string EmployeeID;
    }

    public class EmployeeJoiningInfoByLocBraRequest
    {
        public int LocationID;
        public int BranchID;
        public string FromDate;
        public string ToDate;
    }
    public class EmployeeForLeaveBalance
    {
        public int BranchID;

    }

    public class EmployeeInfoForpolicy
    {
        public int LocationID;
        public int BranchID;
        public int DepartmentID;
        public int DesignationID;
        public int GradeID;

    }
    public class EmployeeDocuments
    {
        public int EmployeeID;
        public int ID;

    }
    public class TerminationEmpIDRequest
    {
        public int EmployeeID;

    }

    public class EmployeeOTDetails
    {
        public int ID;
        public int EmployeeID;
        public int OTMonth;
        public int OTYear;
        public double OTHours;
        public double OTWages;
        public double OTAmount;
        public int UpdateBy;
    }

    public class OvertimeList
    {
        public int LocationID;
        public int BranchID;
        public int DepartmentID;
        public int OTMonth;
        public int OTYear;

    }

    public class ReportingManager
    {
        public int AdmReportingMgrDesiID;
        public int FuncReportingMgrDesiID;
        public int BranchID;

    }
}
