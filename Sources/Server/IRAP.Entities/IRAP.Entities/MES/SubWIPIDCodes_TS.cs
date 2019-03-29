using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// 维修工位子在制品
    /// </summary>
    public class SubWIPIDCodes_TS
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 部件编号
        /// </summary>
        public string PartNumber { get; set; }
        /// <summary>
        /// 子在制品标识代码
        /// </summary>
        public string SubWIPIDCode { get; set; }
        /// <summary>
        /// 子在制品序列号
        /// </summary>
        public string SerialNumber { get; set; }
        /// <summary>
        /// 关联的事实编号
        /// </summary>
        public long LinkedFactID { get; set; }
        /// <summary>
        /// 生产任务种类叶标识
        /// </summary>
        public int PWOCategoryLeaf { get; set; }
        /// <summary>
        /// 产品族叶标识
        /// </summary>
        public int T132Leaf { get; set; }
    }
}
