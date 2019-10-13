/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 类 名 称：CustomRequest
// 文 件 名：CustomRequest
// 创 建 者：李智颖
// 创建日期：2019/10/12 11:39:38
// 版本	日期					修改人	
// v0.1	2019/10/12 11:39:38      李智颖
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
    /// 创建日期：2019/10/12 11:39:38
    /// 类    名：CustomRequest(请求报文父类)
    /// </summary>	
    public abstract class CustomRequest
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public abstract string ExCode { get; }
        /// <summary>
        /// 社区标识
        /// </summary>
        public int CommunityID { get; set; } = 0;
        /// <summary>
        /// 系统登录标识
        /// </summary>
        public long SysLogID { get; set; } = 0;
        /// <summary>
        /// 访问令牌
        /// </summary>
        public string access_token { get; set; } = "";
    }
}
