/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 类 名 称：MR_GetSubComponentList
// 文 件 名：MR_GetSubComponentList
// 创 建 者：李智颖
// 创建日期：2019/10/12 12:20:17
// 版本	日期					修改人	
// v0.1	2019/10/12 12:20:17      李智颖
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRAP.Client.Global.Enums;
using IRAP.Service.Client.Contents;

namespace IRAP.Service.Client.Exchange.MES
{
    /// <summary>
    /// 命名空间：IRAP.Service.Client.Exchange.MES
    /// 创 建 者：李智颖
    /// 创建日期：2019/10/12 12:20:17
    /// 类    名：MR_GetSubComponentList(获取子件列表)
    /// </summary>	
    public class MR_GetSubComponentList : CustomWebAPICall
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="webAPIUrl">WebAPI地址</param>
        /// <param name="contentType">报文类型</param>
        /// <param name="clientID">渠道标识</param>
        public MR_GetSubComponentList(
            string webAPIUrl,
            ContentType contentType,
            string clientID) : base(webAPIUrl, contentType, clientID)
        {
            moduleType = ModuleType.Exchange;
            ExCode = "IRAP_MES_MR_GetSubComponentList";
        }

        /// <summary>
        /// 请求报文
        /// </summary>
        public MRGetSubComponentListRequest Request { get; set; } = null;
        /// <summary>
        /// 响应报文
        /// </summary>
        public MRGetSubComponentListResponse Response { get; private set; } = null;

        /// <summary>
        /// 发送请求报文并接收响应报文
        /// </summary>
        /// <param name="errorMsg">交易执行结果对象</param>
        protected override void Communicate(out ErrorMessage errorMsg)
        {
            if (Request == null)
            {
                Exception error =
                    new Exception("请求报文未实例化");
                errorMsg =
                    new ErrorMessage()
                    {
                        ErrCode = 999999,
                        ErrText = error.Message,
                    };
                return;
            }

            Response = Call<MRGetSubComponentListResponse>(Request, out errorMsg);
        }
    }

    /// <summary>
    /// 命名空间：IRAP.Service.Client.Exchange.MES
    /// 创 建 者：李智颖
    /// 创建日期：2019/10/12 12:22:13
    /// 类    名：MRGetSubComponentListRequest
    /// </summary>	
    public class MRGetSubComponentListRequest : CustomRequest
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public override string ExCode => "IRAP_MES_MR_GetSubComponentList";
        /// <summary>
        /// DMC码
        /// </summary>
        public string DMCNO { get; set; } = "";
    }

    /// <summary>
    /// 命名空间：IRAP.Service.Client.Exchange.MES
    /// 创 建 者：李智颖
    /// 创建日期：2019/10/12, 12:57:06
    /// 类    名：MRGetSubComponentListResponse
    /// </summary>	
    public class MRGetSubComponentListResponse : CustomResponse
    {
        /// <summary>
        /// 子件列表
        /// </summary>
        public List<MRGetSubComponetListOutputDetail> Output { get; set; }
            = new List<MRGetSubComponetListOutputDetail>();
    }

    /// <summary>
	/// 命名空间：IRAP.Service.Client.Exchange.MES
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/12, 13:00:45
	/// 类    名：MRGetSubComponetListOutputDetail
	/// </summary>	
	public class MRGetSubComponetListOutputDetail
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// 唯一号(DMC码/容器号)
        /// </summary>
        public string NO { get; set; }
        /// <summary>
        /// 批次号
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// 类型（精追/批追)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 检测结果(报废/释放)
        /// </summary>
        public string QCStatus { get; set; }
    }
}
