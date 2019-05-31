using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.MES
{
    /// <summary>
    /// IRAPMES..ufn_GetInfo_OpenPWO 函数返回的结果类
    /// </summary>
    public class OpenPWOInfoEx : OpenPWOInfo
    {
        /// <summary>
        /// 班次代码
        /// </summary>
        public string T126Code { get; set; } = "";
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; } = "";
        /// <summary>
        /// 工单类型代码
        /// </summary>
        public string PWOType { get; set; } = "";
        /// <summary>
        /// 产品生命阶段
        /// </summary>
        public int T102S1 { get; set; } = 0;

        public new OpenPWOInfoEx Clone()
        {
            return MemberwiseClone() as OpenPWOInfoEx;
        }
    }
}
