using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jayrock.Json;
using System.Configuration;
using IRCAKernel.Communication;

namespace IRCA.Communication
{
    /// <summary>
    /// Class encapsulating Json convertions routines
    /// </summary>
    public class CommunicationObject : JSONObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CommunicationObject()
            : this(null)
        {
        }

        public CommunicationObject(Object DataObject)
            : base(DataObject)
        {
        }

        /// <summary>
        /// Constructor that takes a json string and creates a corresponding 
        /// object to access the properties of the json
        /// </summary>
        /// <param name="JsonString">Strin in JSON Notation</param>
        public CommunicationObject(String JsonString)
            : base(JsonString)
        {
        }

        /// <summary>
        /// Overridden Method
        /// </summary>
        public override void SetObjectValue(JsonObject JsonObject, String Name, Object Value)
        {
            //if (Value is String)
            //{
            //    Value = HttpUtility.HtmlEncode((String)Value);
            //}

            base.SetObjectValue(JsonObject, Name, Value);
        }

        public static String GetJsonStringResponse(CommunicationObject Response)
        {
            int MaxJsonLength = 0;

            if (Response != null)
            {
                String ResponseString = Response.ToString();

                if (MaxJsonLength == 0)
                {
                    MaxJsonLength = 1000000;
                }

                if (ResponseString.Length > MaxJsonLength)
                {
                    Response = new CommunicationObject();

                    Response.SetProperty(WebResponse.ResponseCommand, WebAppCommands.ERROR);
                    Response.SetProperty(WebResponse.Message, "Requested Data size exceeded the limit set on the server");
                    Response.SetProperty(WebResponse.MessageDetail, "Request data size - " + ResponseString.Length);
                    ResponseString = Response.ToString();
                }

                return ResponseString;
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
