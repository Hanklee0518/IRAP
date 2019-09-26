using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAP_MaterialRequestImport
{
    public class TParams
    {
        private static TParams _instance = null;

        public static TParams Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TParams();
                return _instance;
            }
        }

        private TParams() { }
    }
}
