using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    public class OperationOfAProduct
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        public int T216LeafID { get; set; }
        public string T216Code { get; set; }
        public string T216Name { get; set; }
        public long C64ID { get; set; }
    }
}
