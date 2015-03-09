using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRCAKernel
{
    public class IRCADataStore
    {
        private static IRCADataStore _Instance;
        private String _AppBinFolder;

        public String AppBinFolder
        {
            get { return _AppBinFolder; }
            set { _AppBinFolder = value; }
        }

        public static IRCADataStore Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new IRCADataStore();
                }
                return _Instance;
            }

        }

        private IRCADataStore()
        {

        }
    }
}
