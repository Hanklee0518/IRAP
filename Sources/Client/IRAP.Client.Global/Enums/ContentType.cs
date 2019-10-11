/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 枚举名称：ContentType
// 文 件 名：ContentType
// 创 建 者：李智颖
// 创建日期：2019/10/10 12:12:39
// 版本	日期					修改人	
// v0.1	2019/10/10 12:12:39      李智颖
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IRAP.Client.Global.Enums
{
    /// <summary>
    /// 命名空间：IRAP.Client.Global.Enums
    /// 创 建 者：李智颖
    /// 创建日期：2019/10/10 12:12:39
    /// 枚举名称：ContentType
    /// </summary>	
    [Flags()]
    public enum ContentType
    {
        /// <summary>
        /// JSON格式的报文
        /// </summary>
        [Description("JSON格式的报文")]
        json = 1,
        /// <summary>
        /// XML格式的报文
        /// </summary>
        [Description("XML格式的报文")]
        xml,
    }
}
