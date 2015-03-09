
using System;
using System.Collections.Generic;
using System.Text;
using NITGEN.SDK.NBioBSP;

namespace ICMSCaddieManager
{
    class NitGenFingerPrinting
    {
        private NBioAPI m_NBioAPI = null;
        private List<FingerPrintTemplate> _FPList = null;

        static NBioAPI.Type.HFIR hNewFIR;

        private static NitGenFingerPrinting _FP = null;

        public static NitGenFingerPrinting CreateNitGenFPR()
        {
            if (_FP == null)
            {
                _FP = new NitGenFingerPrinting();
            }

            return _FP;
        }

        private NitGenFingerPrinting()
        {
            m_NBioAPI = new NBioAPI();
            _FPList = new List<FingerPrintTemplate>();
        }

        public void Open()
        {
            m_NBioAPI.OpenDevice(NBioAPI.Type.DEVICE_ID.AUTO);
        }

        public void Close()
        {
           m_NBioAPI.CloseDevice(NBioAPI.Type.DEVICE_ID.AUTO);
        }

        public FingerPrintTemplate Enroll(String UserID)
        {
            FingerPrintTemplate Template = new FingerPrintTemplate() { PersonID = UserID };
               
            
            uint ret = m_NBioAPI.Enroll(out hNewFIR, null);
            
            if (ret != NBioAPI.Error.NONE)
            {
                Template.ErrorMessage = NITGEN.SDK.NBioBSP.NBioAPI.Error.GetErrorDescription(ret);
            }
            else
            {
                Template.TemplateString = hNewFIR.hFIR.ToString();
                Enroll(Template);
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

            NBioAPI.Type.HFIR hCapturedFIR;
            

            uint ret = m_NBioAPI.Capture(out hCapturedFIR);
            
            if (ret != NBioAPI.Error.NONE)
            {
                Template.ErrorMessage = NITGEN.SDK.NBioBSP.NBioAPI.Error.GetErrorDescription(ret);
            }
            else
            {
                Template.TemplateString = hCapturedFIR.hFIR.ToString();

            }

            return Template;
        }

        public bool Verify(FingerPrintTemplate CapturedTemplate)
        {
            if (!String.IsNullOrEmpty(CapturedTemplate.TemplateString))
            {
                bool IsMatch;

                NBioAPI.Type.HFIR CapturedHFIR = new NBioAPI.Type.HFIR();

                CapturedHFIR.hFIR = Convert.ToUInt32(CapturedTemplate.TemplateString);

                uint Error = m_NBioAPI.Verify(CapturedHFIR,out IsMatch,null);

                if (Error == NBioAPI.Error.NONE)
                {
                    return IsMatch;
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
                NBioAPI.Type.HFIR CapturedHFIR = new NBioAPI.Type.HFIR();

                CapturedHFIR.hFIR = Convert.ToUInt32(CapturedTemplate.TemplateString);

                NBioAPI.Type.HFIR EnrolledHFIR = new NBioAPI.Type.HFIR();

                EnrolledHFIR.hFIR = Convert.ToUInt32(EnrolledTemplate.TemplateString);
                
                bool IsMatch;

                uint Error = m_NBioAPI.VerifyMatch(EnrolledHFIR,CapturedHFIR, out IsMatch,null);

                if (Error == NBioAPI.Error.NONE)
                {
                    return IsMatch;
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
