/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SecuGen.SecuBSPPro.Windows;

namespace ICMSCaddieManager
{
    class SecuGenFingerPrinting
    {
        private SecuBSPMx _SecuBSP = null;
        private List<FingerPrintTemplate> _FPList = null;

        public SecuGenFingerPrinting()
        {
            _SecuBSP = new SecuBSPMx();
            _FPList = new List<FingerPrintTemplate>();
        }

        public void Open()
        {
            _SecuBSP.OpenDevice();
        }

        public void Close()
        {
            _SecuBSP.CloseDevice();
        }

        public FingerPrintTemplate Enroll(String UserID)
        {
            FingerPrintTemplate Template = new FingerPrintTemplate() { PersonID = UserID };

            BSPError Error = _SecuBSP.Enroll(UserID);

            if (Error == BSPError.ERROR_NONE)
            {
                Template.TemplateString = _SecuBSP.FIRTextData;
                Enroll(Template);
            }
            else
            {
                Template.ErrorMessage = Error.ToString();
            }

            return Template;
        }

        public FingerPrintTemplate Enroll(FingerPrintTemplate Template)
        {
            _FPList.Add(Template);

            return Template;
        }

        public FingerPrintTemplate Capture()
        {
            FingerPrintTemplate Template = new FingerPrintTemplate();
            BSPError Error = _SecuBSP.Capture(FIRPurpose.VERIFY);

            if (Error == BSPError.ERROR_NONE)
            {
                Template.TemplateString = _SecuBSP.FIRTextData;
            }
            else
            {
                Template.ErrorMessage = Error.ToString();
            }

            return Template;
        }

        public bool Verify(FingerPrintTemplate CapturedTemplate)
        {
            if (!String.IsNullOrEmpty(CapturedTemplate.TemplateString))
            {
                BSPError Error = _SecuBSP.Verify(CapturedTemplate.TemplateString);

                if (Error == BSPError.ERROR_NONE)
                {
                    return _SecuBSP.IsMatched;
                }
                else
                {
                    CapturedTemplate.ErrorMessage = "Template Match Unsuccessful";
                    return false;
                }
            }
            else
            {
                CapturedTemplate.ErrorMessage = "Invalid Template";
                return false;
            }
        }

        public bool Verify(FingerPrintTemplate CapturedTemplate, FingerPrintTemplate EnrolledTemplate)
        {
            if (!String.IsNullOrEmpty(CapturedTemplate.TemplateString))
            {
                BSPError Error = _SecuBSP.VerifyMatch(CapturedTemplate.TemplateString, EnrolledTemplate.TemplateString);

                if (Error == BSPError.ERROR_NONE)
                {
                    return _SecuBSP.IsMatched;
                }
                else
                {
                    CapturedTemplate.ErrorMessage = "Template Match Unsuccessful";

                    return false;
                }
            }
            else
            {
                CapturedTemplate.ErrorMessage = "Invalid Template";

                return false;
            }
        }

        public FingerPrintTemplate Identify(FingerPrintTemplate CapturedTemplate)
        {
            foreach (FingerPrintTemplate EnrolledTemplate in _FPList)
            {
                if (Verify(CapturedTemplate, EnrolledTemplate))
                {
                    return EnrolledTemplate;
                }
            }

            return null;
        }
    }

    class FingerPrintTemplate
    {
        public String PersonID;
        public String TemplateString;
        public String ErrorMessage = String.Empty;
    }
}
*/