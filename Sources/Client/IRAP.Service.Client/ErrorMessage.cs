/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 类 名 称：ErrorMessage
// 文 件 名：ErrorMessage
// 创 建 者：李智颖
// 创建日期：2019/10/10 12:19:20
// 版本	日期					修改人	
// v0.1	2019/10/10 12:19:20      李智颖
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Service.Client
{
    /// <summary>
    /// 命名空间：IRAP.Service.Client
    /// 创 建 者：李智颖
    /// 创建日期：2019/10/10 12:19:20
    /// 类    名：ErrorMessage（错误消息类）
    /// </summary>	
    public class ErrorMessage
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode { get; set; }
        /// <summary>
        /// 错误编号（0：没有错误）
        /// </summary>
        public int ErrCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrText { get; set; }
        /// <summary>
        /// 原始的请求报文
        /// </summary>
        public string SourceREQContent { get; set; }
        /// <summary>
        /// 原始的响应报文
        /// </summary>
        public string SourceRESPContent { get; set; }
    }
}
