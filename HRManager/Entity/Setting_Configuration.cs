using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRManager.DTO;
using HRManager.BusinessObjects;
using IRCAKernel;
using IRCA.Communication;
using IS91.Services.DataBlock;
using System.Collections;
using System.Data;


namespace HRManager.Entity
{
    public class Setting_Configuration : JGridDataObject
    {
        private int _ID;
        private String _Name;
        private String _Value;
       
        private int _CreatedBy;
        private DateTime _CreatedDate;
        private int _ModifiedBy;
        private DateTime _ModifiedDate;


        public int ID { get { return _ID; } set { _ID = value; } }
        public String Name { get { return _Name; } set { _Name = value; } }
        public String Value { get { return _Value; } set { _Value = value; } }
        
        public int CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        public DateTime CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        public int ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        public DateTime ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }

         public Setting_Configuration()
        {
        }
         public Setting_Configuration(int ID)
        {
            Update(new Setting_ConfigurationBusinessObject().GetSetting_Configuration(ID));
        }
         public void Update(Setting_Configurations DTO)
         {
             if (DTO != null)
             {
                 _ID = DTO.ID;
                 _Name = DTO.Name;
                 _Value = DTO.Value;
                 _ModifiedBy = DTO.ModifiedBy;
                 _ModifiedDate = DTO.ModifiedDate;
                 _CreatedBy = DTO.CreatedBy;
                 _CreatedDate = DTO.CreatedDate;
             }
         }
         private Setting_Configurations GetDTO()
         {
             Setting_Configurations DTO = new Setting_Configurations();
             DTO.ID = _ID;
             DTO.Name = _Name;
             DTO.Value = _Value;
             DTO.CreatedBy = _CreatedBy;
             DTO.CreatedDate = _CreatedDate;
             DTO.ModifiedBy = _ModifiedBy;
             DTO.ModifiedDate = _ModifiedDate;
             

             if (_ID == 0)
             {
                 DTO.CreatedBy = _CreatedBy;
                 DTO.CreatedDate = DateTime.Now;
             }
             DTO.ModifiedBy = _ModifiedBy;
             DTO.ModifiedDate = DateTime.Now;

             return DTO;
         }
         public String Validate()
         {
             return String.Empty;
         }
         public String Save()
         {
             String Status = Validate();
             if (Status != String.Empty)
             {
                 return Status;
             }
             try
             {
                 Setting_ConfigurationBusinessObject BO = new Setting_ConfigurationBusinessObject();
                 Setting_Configurations DTO = GetDTO();

                 if (_ID != 0)
                 {
                     BO.Update(DTO);
                 }
                 else
                 {
                     _ID = BO.Create(DTO);
                 }

                 return String.Empty;
             }
             catch (Exception ex)
             {
                 IRCAExceptionHandler.HandleException(ex);
                 return ex.Message;
             }
         }
         //public object GetGridData()
         //{
         //    return this;
         //}
         public static Setting_Configuration[] GetSettingConfiguration()
         {
             Setting_Configurations[] RolesDT = new Setting_ConfigurationBusinessObject().GetAllActiveSettingConfiguration();

             Setting_Configuration[] Roles = new Setting_Configuration[RolesDT.Length];

             for (int i = 0; i < Roles.Length; i++)
             {
                 Roles[i] = new Setting_Configuration();

                 Roles[i].Update(RolesDT[i]);
             }

             return Roles;
         }
         #region JGridDataObject Members

         public object GetGridData()
         {
             SettingConfigurationDetails SettingConfiguration = new SettingConfigurationDetails();
             SettingConfiguration.ID = _ID;
             SettingConfiguration.Name = _Name;
             SettingConfiguration.Value = "<input id='txt_" + _ID + "' type='text' value='" + _Value + "' class='textClass' style='background-color:lightgreen'></input>";
             return SettingConfiguration;
         }

         #endregion
        
    }
    public class SettingConfigurationDetails
    {
        public int ID;
        public String Name;
        public String Value;

    }
}
