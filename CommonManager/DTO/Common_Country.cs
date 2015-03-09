using System;
using System.Data;
using System.Collections;
using IS91.Services.DataBlock;
namespace CommonManager.DTO
{


      [Serializable()]
		public class Common_Country : TableMetadata
		{

                   public enum Common_CountryFields
                   {
                      ID,
                      Country
                  }


			    private DatabaseField[] _fields;

		    	public Common_Country()
			    {
					    _fields = new DatabaseField[2];
                    _fields[0] = new DatabaseField(DbType.Int32,"ID",true,true,null);
                    _fields[1] = new DatabaseField(DbType.String,"Country",false,false,null);
 
                        this.currentTableName = "Common_Country";


                  }


			public override DatabaseField[] TableFields 
			{
				get{ return _fields;}
				set{_fields = value;}
			}
          public Common_Country Clone()
          {
                 return this.Clone<Common_Country>();
          }

public System.Int32 ID
{
    get
    {
        return (System.Int32) this.GetField("ID").fieldValue; 
    }

    set
    {
          this.SetFieldValue("ID", value);
    }
}


public System.String Country
{
    get
    {
         object result = this.GetField("Country").fieldValue; 
         return (result != null) ? result.ToString() : String.Empty;
    }

    set
    {
          this.SetFieldValue("Country", value);
    }
}

}
}
