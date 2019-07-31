using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MDM
{
    /// <summary>
    /// 指定产品的生产线或工作中心
    /// </summary>
    public class LineOrWorkCenterForAProduct
    {
        /// <summary>
        /// 序号(优先级)
        /// </summary>
        public int Ordinal { get; set; } = 0;
        /// <summary>
        /// 产线叶标识
        /// </summary>
        public int T134LeafID { get; set; } = 0;
        /// <summary>
        /// 产线代码
        /// </summary>
        public string T134Code { get; set; } = "";
        /// <summary>
        /// 产线名称
        /// </summary>
        public string T134Name { get; set; } = "";
        /// <summary>
        /// 工作中心叶标识
        /// </summary>
        public int T211LeafID { get; set; } = 0;
        /// <summary>
        /// 工作中心代码
        /// </summary>
        public string T211Code { get; set; } = "";
        /// <summary>
        /// 工作中心名称
        /// </summary>
        public string T211Name { get; set; } = "";
    }
}
