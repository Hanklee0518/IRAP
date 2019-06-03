using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.APS
{
    public class MaterialATP
    {
        /// <summary>
        /// 物料可供生产数量
        /// </summary>
        public long ATPQty { get; set; } = 0;
        public string EstimatedATPTime { get; set; } = "";

        public override string ToString()
        {
            return "ATP 检查结果";
        }

        public MaterialATP Clone()
        {
            return MemberwiseClone() as MaterialATP;
        }
    }
}
