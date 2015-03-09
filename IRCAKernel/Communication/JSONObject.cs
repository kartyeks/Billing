using System;
using System.Collections;
using System.Reflection;
using Jayrock.Json;
using Jayrock.Json.Conversion;
using System.Collections.Generic;
using System.Text;

namespace IRCAKernel.Communication
{
    public class JSONObject
    {
        protected IJsonExportable UnSerializedObject;

        /// <summary>
        /// Constructor
        /// </summary>
        public JSONObject()
            : this(null)
        {
        }

        public JSONObject(Object DataObject)
        {
            if (DataObject != null && DataObject is Array)
            {
                JsonArray ArrayObject = new JsonArray((Object[])DataObject);

                UnSerializedObject = ArrayObject;
            }
            else
            {
                UnSerializedObject = WrapJsonObject(DataObject);
            }
        }

        /// <summary>
        /// Constructor that takes a json string and creates a corresponding 
        /// object to access the properties of the json
        /// </summary>
        /// <param name="JsonString">Strin in JSON Notation</param>
        public JSONObject(String JsonString)
        {
            if (String.IsNullOrEmpty(JsonString))
            {
                UnSerializedObject = new JsonObject();
            }
            else
            {
                Object JSONObj = JsonConvert.Import(JsonString);

                if (JSONObj is JsonArray)
                {
                    UnSerializedObject = (JsonArray)JSONObj;
                }
                else
                {
                    UnSerializedObject = (JsonObject)JSONObj;
                }
            }
        }

        public virtual void SetProperty(String Property, Object Value)
        {
            if (null != Value)
            {
                String[] AttributeChain = Property.Split(new String[] { "." }, StringSplitOptions.None);

                JsonObject ThisObject = GetPropertyParent(AttributeChain, true);

                if (Value is String || Value is ValueType)
                {
                    SetObjectValue(ThisObject, AttributeChain[AttributeChain.Length - 1], Value);
                }
                else if (Value is Array)
                {
                    if (Value is String[] || Value is ValueType[])
                    {
                        SetObjectValue(ThisObject, AttributeChain[AttributeChain.Length - 1], Value);
                    }
                    else
                    {
                        SetObjectValue(ThisObject, AttributeChain[AttributeChain.Length - 1], GetJsonObjectArray((Object[])Value));
                    }
                }
                else
                {
                    IJsonExportable ValueObject = WrapJsonObject(Value);

                    if (ValueObject is JsonArray || ((JsonObject)ValueObject).Names.Count > 0)
                    {
                        SetObjectValue(ThisObject, AttributeChain[AttributeChain.Length - 1], ValueObject);
                    }
                    else
                    {
                        SetObjectValue(ThisObject, AttributeChain[AttributeChain.Length - 1], Value);
                    }
                }
            }
        }

        protected virtual Object[] GetJsonObjectArray(Object[] Values)
        {
            IJsonExportable[] JsonObjects = new IJsonExportable[Values.Length];

            for (int i = 0; i < JsonObjects.Length; i++)
            {
                JsonObjects[i] = WrapJsonObject(Values[i]);
            }

            return JsonObjects;
        }

        protected virtual IJsonExportable WrapJsonObject(Object Value)
        {
            IJsonExportable ReturnObject = null;

            if (null != Value)
            {
                if (Value is JSONObject)
                {
                    JSONObject ExternalWebObject = (JSONObject)Value;

                    if (ExternalWebObject.UnSerializedObject is JsonObject)
                    {
                        JsonObject JsonObject = new JsonObject();

                        JsonObject ExternalObject = (JsonObject)ExternalWebObject.UnSerializedObject;

                        JsonArray Names = ExternalObject.GetNamesArray();

                        for (int i = 0; i < Names.Count; i++)
                        {
                            String Name = Names[i].ToString();

                            SetObjectValue(JsonObject, Name, ExternalObject[Name]);
                        }

                        ReturnObject = JsonObject;
                    }
                    else if (ExternalWebObject.UnSerializedObject is JsonArray)
                    {
                        JsonArray ExternalArray = (JsonArray)ExternalWebObject.UnSerializedObject;

                        ReturnObject = ExternalArray;
                    }
                }
                else
                {
                    JsonObject JsonObject = new JsonObject();

                    ReturnObject = JsonObject;

                    Type ValueObjecType = Value.GetType();

                    List<MemberInfo> DataFieldList = new List<MemberInfo>();

                    DataFieldList.AddRange(ValueObjecType.GetFields(BindingFlags.Public | BindingFlags.Instance));
                    DataFieldList.AddRange(ValueObjecType.GetProperties(BindingFlags.Public | BindingFlags.Instance));


                    foreach (MemberInfo DataField in DataFieldList)
                    {
                        Object ValueObject;

                        if (DataField is FieldInfo)
                        {
                            ValueObject = ((FieldInfo)DataField).GetValue(Value);
                        }
                        else
                        {
                            if (((PropertyInfo)DataField).CanRead == false)
                            {
                                continue;
                            }
                            ValueObject = ((PropertyInfo)DataField).GetValue(Value, null);
                        }

                        if (ValueObject is ICollection)
                        {

                            ICollection ValueCollection = (ICollection)ValueObject;
                            Object[] ValueObjectArray = new Object[ValueCollection.Count];
                            ValueCollection.CopyTo(ValueObjectArray, 0);

                            if (ValueObjectArray.Length <= 0)
                            {
                                SetObjectValue(JsonObject, DataField.Name, GetJsonObjectArray(ValueObjectArray));
                            }
                            else if (ValueObjectArray[0] is string
                                 || ValueObjectArray[0] is System.Int16
                                 || ValueObjectArray[0] is System.Int32
                                 || ValueObjectArray[0] is System.Int64
                                 || ValueObjectArray[0] is System.Double
                                 || ValueObjectArray[0] is System.Boolean
                                 || ValueObjectArray[0] is System.DateTime
                                )
                            {
                                foreach (Object StringValue in ValueObjectArray)
                                {
                                    SetObjectValue(JsonObject, DataField.Name, ValueObjectArray);
                                }
                            }
                            else
                            {
                                SetObjectValue(JsonObject, DataField.Name, GetJsonObjectArray(ValueObjectArray));
                            }
                        }
                        else
                        {
                            SetObjectValue(JsonObject, DataField.Name, ValueObject);
                        }
                    }
                }
            }

            return (null == ReturnObject ? new JsonObject() : ReturnObject);
        }

        /// <summary>
        /// Gets a property from the json object.  Uses "." to act as a 
        /// separator for the property name.
        /// </summary>
        /// <param name="Property">Name of the property to be set.  Can
        /// contain multiple levels of properties ex: "Filters.Users.ID" represents
        /// a property "ID" of another property "Users" which is in turn a 
        /// property of "Filters"</param>
        /// <returns>Value assigned to the property</returns>
        public virtual String GetProperty(String Property)
        {
            String[] AttributeChain = Property.Split(new String[] { "." }, StringSplitOptions.RemoveEmptyEntries);

            JsonObject ThisObject = GetPropertyParent(AttributeChain, false);

            Object Value = (null != ThisObject ? ThisObject[AttributeChain[AttributeChain.Length - 1]] : null);

            return (null == Value ? null : Value.ToString());

        }

        /// <summary>
        /// Returns the JsonObject which is the parent of the property named.
        /// </summary>
        /// <param name="AttributeChain">Represents the list of properties
        /// in the sequence in which they have been defined in the property name</param>
        /// <param name="CreateIfNotExisting">Indicates whether a node has to be created
        /// if requested and not found to exist.  Typically for set operations it will be 
        /// true and false for get operations</param>
        /// <returns>JsonObject which is a parent of the last level of properties
        /// defined</returns>
        private JsonObject GetPropertyParent(String[] AttributeChain, bool CreateIfNotExisting)
        {
            JsonObject ThisObject = (JsonObject)UnSerializedObject;

            try
            {
                for (int i = 0; i < AttributeChain.Length - 1; i++)
                {
                    JsonObject NewObject = (JsonObject)ThisObject[AttributeChain[i]];

                    if (null == NewObject)
                    {
                        if (CreateIfNotExisting)
                        {
                            NewObject = new JsonObject();
                            SetObjectValue(ThisObject, AttributeChain[i], NewObject);
                        }
                        else
                        {
                            ThisObject = null;

                            // if a node is not to be created there is no further search possible
                            break;
                        }
                    }

                    ThisObject = NewObject;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return ThisObject;
        }

        public virtual void UpdateDataObject(Object DataObject)
        {
            UpdateDataObject("", DataObject);
        }

        public virtual Object GetArrayDataObject(Type DataType)
        {
            JsonObject[] JsonObjects = new JsonObject[((JsonArray)UnSerializedObject).Count];
            Array Data = Array.CreateInstance(DataType, ((JsonArray)UnSerializedObject).Length);

            if (DataType == typeof(System.Int32))
            {
                for (int i = 0; i < JsonObjects.Length; i++)
                {
                    String DataStr = ((JsonArray)UnSerializedObject).ToArray()[i].ToString();
                    if (DataType == typeof(System.Int32))
                    {
                        Data.SetValue(Convert.ToInt32(DataStr), i);
                    }
                }
            }
            else if (DataType == typeof(System.String))
            {
                for (int i = 0; i < JsonObjects.Length; i++)
                {
                    String DataStr = ((JsonArray)UnSerializedObject).ToArray()[i].ToString();
                    if (DataType == typeof(System.String))
                    {
                        Data.SetValue(Convert.ToString(DataStr), i);
                    }
                }
            }
            else
            {
                for (int i = 0; i < JsonObjects.Length; i++)
                {
                    JsonObjects[i] = ((JsonArray)UnSerializedObject).GetObject(i);

                    JSONObject Obj = new JSONObject(JsonObjects[i].ToString());

                    Object DataObj = Activator.CreateInstance(DataType);

                    Obj.UpdateDataObject(DataObj);

                    Data.SetValue(DataObj, i);
                }
            }

            return Data;
        }

        /// <summary>
        /// Updates the data object from the values in this request object
        /// </summary>
        /// <param name="DataPropertyName">Name of the property in the request object that contains
        /// the values for this particular data object</param>
        /// <param name="DataObject">Data object to be populated with the values</param>
        public virtual void UpdateDataObject(String DataPropertyName, Object DataObject)
        {
            List<MemberInfo> DataFieldList = new List<MemberInfo>();

            DataFieldList.AddRange(DataObject.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance));
            DataFieldList.AddRange(DataObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance));

            foreach (MemberInfo DataField in DataFieldList)
            {
                String Value = GetProperty(DataPropertyName + "." + DataField.Name);

                Type FieldType = null;
                Object DataValue = null;

                if (DataField is PropertyInfo)
                {
                    FieldType = ((PropertyInfo)DataField).PropertyType;
                }
                else if (DataField is FieldInfo)
                {
                    FieldType = ((FieldInfo)DataField).FieldType;
                }

                if (null != Value)
                {
                    if (FieldType == typeof(System.Int32))
                    {
                        int i = 0;
                        int.TryParse(Value, out i);
                        DataValue = i;
                    }
                    else if (FieldType == typeof(System.Int16))
                    {
                        short i = 0;
                        short.TryParse(Value, out i);
                        DataValue = i;
                    }
                    else if (FieldType == typeof(System.String))
                    {
                        DataValue = Value;
                    }
                    else if (FieldType == typeof(System.Boolean))
                    {
                        if (Value == "0" || Value == "1")
                        {
                            DataValue = (Value == "1" ? true : false);
                        }
                        else
                        {
                            bool i = false;
                            bool.TryParse(Value, out i);
                            DataValue = i;
                        }
                    }
                    else if (FieldType == typeof(System.Double))
                    {
                        double i = 0;
                        double.TryParse(Value, out i);
                        DataValue = i;
                    }
                    else if (FieldType == typeof(System.DateTime))
                    {
                        DateTime i = new DateTime(1900, 01, 01);
                        DateTime.TryParse(Value, out i);
                        DataValue = i;
                    }
                    else if (FieldType == typeof(System.Byte[]))
                    {
                        System.IO.FileInfo fn = new System.IO.FileInfo(Value);
                        byte[] uploadData = null;
                        long _NumBytes = fn.Length;
                        System.IO.FileStream fs = new System.IO.FileStream(Value, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                        System.IO.BinaryReader _BinaryReader = new System.IO.BinaryReader(fs);
                        uploadData = _BinaryReader.ReadBytes(Convert.ToInt32(_NumBytes));
                        fs.Close();
                        fs.Dispose();
                        _BinaryReader.Close();

                        DataValue = uploadData;
                    }
                    else if (FieldType.BaseType.Name == "Array")
                    {
                        JSONObject ArrayObj = new JSONObject(Value);

                        Object ArrayData = ArrayObj.GetArrayDataObject(FieldType.GetElementType());

                        DataValue = ArrayData;
                    }
                    else
                    {
                        JSONObject Obj = new JSONObject(Value);

                        DataValue = Activator.CreateInstance(FieldType);

                        Obj.UpdateDataObject(DataValue);

                    }
                }

                if (DataValue != null)
                {
                    if (DataField is PropertyInfo)
                    {
                        ((PropertyInfo)DataField).SetValue(DataObject, DataValue, null);
                    }
                    else if (DataField is FieldInfo)
                    {
                        ((FieldInfo)DataField).SetValue(DataObject, DataValue);
                    }
                }
            }
        }

        /// <summary>
        /// Sets the given value against the given name into the specified json object
        /// </summary>
        /// <param name="Object">Json Object</param>
        /// <param name="name">Name Key</param>
        /// <param name="value">Value</param>
        public virtual void SetObjectValue(JsonObject JsonObject, String Name, Object Value)
        {
            if (Value is DateTime)
            {
                Value = ((DateTime)Value).ToString("yyyy-MM-dd hh:mm:ss.sss");
            }

            JsonObject.Put(Name, Value);
        }

        /// <summary>
        /// Overridden Method
        /// </summary>
        public override String ToString()
        {
            return UnSerializedObject.ToString();
        }
    }
}
