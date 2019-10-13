/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 类 名 称：CustomResponse
// 文 件 名：CustomResponse
// 创 建 者：李智颖
// 创建日期：2019/10/12 11:40:46
// 版本	日期					修改人	
// v0.1	2019/10/12 11:40:46      李智颖
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Service.Client.Contents
{
    /// <summary>
    /// 命名空间：IRAP.Service.Client.Contents
    /// 创 建 者：李智颖
    /// 创建日期：2019/10/12 11:40:46
    /// 类    名：CustomResponse(响应报文父类)
    /// </summary>	
    public class CustomResponse
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public string ExCode { get; set; } = "";
        /// <summary>
        /// 交易结果代码（0-交易成功；非0-交易失败）
        /// </summary>
        public int ErrCode { get; set; } = 0;
        /// <summary>
        /// 交易结果消息字符串
        /// </summary>
        public string ErrText { get; set; } = "";
    }
}
