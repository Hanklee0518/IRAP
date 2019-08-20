using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    public class WIFile
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string RemotePath { get; set; }
        public string WIFileName { get; set; }

        public WIFile Clone()
        {
            return MemberwiseClone() as WIFile;
        }
    }
}
