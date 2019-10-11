/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 枚举名称：ModuleType
// 文 件 名：ModuleType
// 创 建 者：李智颖
// 创建日期：2019/10/10 12:17:11
// 版本	日期					修改人	
// v0.1	2019/10/10 12:17:11      李智颖
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace IRAP.Service.Client.Enums
{
    /// <summary>
    /// 命名空间：IRAP.Service.Client.Enums
    /// 创 建 者：李智颖
    /// 创建日期：2019/10/10 12:17:11
    /// 枚举名称：ModuleType
    /// </summary>	
    [Flags()]
    public enum ModuleType
    {
        /// <summary>
        /// 授权认证级别
        /// </summary>
        [Description("授权认证类别")]
        OpenAuth =1,
        /// <summary>
        /// 数据交换类别
        /// </summary>
        [Description("数据交换类别")]
        Exchange,
    }
}
