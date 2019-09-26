using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entity.MDM
{
    public class ProductionLineOfProduct
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; }
        /// <summary>
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; }
        /// <summary>
        /// 产线名称
        /// </summary>
        public string T134Name { get; set; }

        public override string ToString()
        {
            return $"{T134Name}[{T134Code}]";
        }

        public ProductionLineOfProduct Clone()
        {
            return MemberwiseClone() as ProductionLineOfProduct;
        }
    }
}