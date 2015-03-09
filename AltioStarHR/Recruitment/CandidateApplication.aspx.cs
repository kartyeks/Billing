using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using HRManager.Entity;
using HRManager.Entity.Recruitment;
using System.IO;
using IRCAKernel;

namespace AltioStarHR.Recruitment
{
    public partial class CandidateApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnSaveResult.Value = String.Empty;
            hdnCandIDFromGrid.Value = Request.QueryString["CandID"];
            hdnIsLogEmpManager.Value = Request.QueryString["ILEP"];
            ExtendedUserInfo objCurrUser = ((ExtendedUserInfo)HttpContext.Current.Session["userInfo"]);
            hdnLoggedUserID.Value = string.Concat(objCurrUser.UserId);

            string strDetails = objCurrUser.GroupID.ToString(); //This will contain RoleID and RoleName and Logintype
            String[] strSpit;
            strSpit = strDetails.Split('_');
            if (strSpit.Length != 0)
            {
                hdnRoleName.Value = strSpit[1];
                hdnLoginType.Value = strSpit[2];
            }

            if (IsPostBack)
                SaveCandidateApplication();
        }

        private void SaveCandidateApplication()
        {
            try
            {
                // Add or Update Candidate Details //
                int CandidateID = 0;
                Int32.TryParse(hdnCandIDFromGrid.Value, out CandidateID);

                MasterCandidate cand = new MasterCandidate(CandidateID);

                cand.ID = CandidateID;

                int TeamId = 0;
                Int32.TryParse(hdnTeamID.Value, out TeamId);
                cand.TeamID = TeamId;

                cand.CandidateType = hdnCandidateType.Value;

                cand.FirstName = firstname.Value;
                cand.MiddleName = middlename.Value;
                cand.LastName = lastname.Value;
                cand.CurrentEmployer = curentemployer.Value;

                if (hdnCarierStartDate.Value != "")
                {
                    DateTime StartDate = DateTime.Today;
                    StartDate = DateTime.ParseExact(hdnCarierStartDate.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    cand.CareerStartDate = StartDate;
                }
                else
                    cand.CareerStartDate = new DateTime(1900, 01, 01);

                cand.Experience = experience.Value;
                cand.TechnologyExpertise = expertiseintech.Value;
                cand.ContactNumber = contactno.Value;
                cand.EmailID = emailid.Value;

                int NoticePeriodInDays = 0;
                Int32.TryParse(noticeperiod.Value, out NoticePeriodInDays);

                cand.NoticePeriod = NoticePeriodInDays;
                cand.CurrentLocation = currentlocation.Value;
                cand.ReasonForChange = reason.Value;
                cand.OffersInHand = offers.Value;
                cand.RecruitmentType = hdnLoginType.Value;

                if (CandidateID == 0)
                    cand.CreatedBy = Convert.ToInt32(hdnLoggedUserID.Value);

                cand.ModifiedBy = Convert.ToInt32(hdnLoggedUserID.Value); 

                String FinalResult = String.Empty;
                String CandID = cand.Save();

                if (CandID != "0")
                {
                    // Get CandidateID from ADD or Update Candidate Details and Save Candidate Education Details //
                    String[] EduDet = hdnEducationDetails.Value.Split('~');
                    for (int g = 0; g < EduDet.Length; g++)
                    {
                        String[] EduRow = EduDet[g].Split('^');

                        int ID = 0;
                        Int32.TryParse(EduRow[1], out ID);

                        CandidateEducationDetails edu = new CandidateEducationDetails(ID);

                        edu.ID = ID;
                        edu.CandidateID = Convert.ToInt32(CandID);
                        edu.Education = EduRow[3];
                        edu.Stream = EduRow[4];
                        edu.University = EduRow[5];
                        edu.Year = Convert.ToInt32(EduRow[6]);
                        edu.Percentage = Convert.ToDouble(EduRow[7]);

                        FinalResult = edu.Save();
                    }

                    // Get CandidateID from ADD or Update Candidate Details and Save Candidate Resume in a folder //
                    HttpPostedFile RequestFiles0 = Request.Files[0];
                    string FileName = RequestFiles0.FileName;
                    if (FileName != string.Empty && FinalResult == String.Empty)
                    {
                        string strFile = System.IO.Path.GetFileName(FileName);

                        string SaveLocation = Server.MapPath("~/Resources") + "\\ResumeDownloads\\CandidateID_" + CandID + "_" + strFile;
                        if (System.IO.File.Exists(SaveLocation))
                        {
                            System.IO.File.SetAttributes(SaveLocation, System.IO.FileAttributes.Normal);
                        }
                        uploadresume.PostedFile.SaveAs(SaveLocation);
                        cand = new MasterCandidate(Convert.ToInt32(CandID));
                        cand.ResumeFilename = new FileInfo(RequestFiles0.FileName).Name.ToString();
                        cand.Save();
                    }
                }

                if (FinalResult == String.Empty && hdnCandIDFromGrid.Value == "0")
                {
                    hdnSaveResult.Value = "ADDED success";
                }
                else if (FinalResult == String.Empty && hdnCandIDFromGrid.Value != "0")
                {
                    hdnSaveResult.Value = "UPDATED success";
                }
                if (FinalResult == String.Empty && CandidateID == 0)
                {
                    int ManID = 0;
                    Int32.TryParse(hdnManagerID.Value, out ManID);
                    FinalResult = new RecruitmentNotification().CandidateCreationNotify(cand.ID, ManID, hdnLoginType.Value, hdnRoleName.Value);
                }
                
            }
            catch (Exception e)
            {
                IRCAExceptionHandler.HandleException(e);
            }
        }
    }
}
