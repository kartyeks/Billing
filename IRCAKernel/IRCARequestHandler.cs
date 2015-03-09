using System;
using System.Collections.Generic;
using System.Reflection;
using IRCA.Communication;
using System.Text;

namespace IRCAKernel
{
    public abstract class IRCARequestHandler
    {
        protected static Dictionary<String,List<String>> _Commands;

        public IRCARequestHandler()
        {
            _Commands = new Dictionary<String, List<String>>();

            Assembly Assembly = Assembly.GetCallingAssembly();

            Type[] ClassTypes = Assembly.GetTypes();

            foreach (Type Tmp in ClassTypes)
            {
                if (Tmp.IsClass && typeof(WebAppCommands).IsAssignableFrom(Tmp))
                {
                    FieldInfo[] Info = Tmp.GetFields();

                    List<String> TmpList;

                    if (_Commands.ContainsKey(Tmp.Name))
                    {
                        TmpList = _Commands[Tmp.Name];
                    }
                    else
                    {
                        TmpList = new List<String>();
                        _Commands.Add(Tmp.Name, TmpList);
                    }


                    for (int i = 0; i < Info.Length; i++)
                    {
                        if (Info[i].DeclaringType == Tmp)
                        {
                            TmpList.Add(Info[i].GetValue(null).ToString());
                        }
                    }
                }
            }
        }

        public abstract String[] GetCommands();

        public abstract CommunicationObject ProcessRequest(String RequestCommand, String RequestData);
    }
}
