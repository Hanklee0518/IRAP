/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 类 名 称：MR_Scan
// 文 件 名：MR_Scan
// 创 建 者：李智颖
// 创建日期：2019/10/13 11:15:45
// 版本	日期					修改人	
// v0.1	2019/10/13 11:15:45      李智颖
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
    /// 创建日期：2019/10/13 11:15:45
    /// 类    名：MR_Scan
    /// </summary>	
    public class MR_Scan : CustomWebAPICall
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="webAPIUrl">WebAPI地址</param>
        /// <param name="contentType">报文类型</param>
        /// <param name="clientID">渠道标识</param>
        public MR_Scan(
            string webAPIUrl,
            ContentType contentType,
            string clientID) : base(webAPIUrl, contentType, clientID)
        {
            moduleType = ModuleType.Exchange;
            ExCode = "IRAP_MES_MR_Scan";
        }

        /// <summary>
        /// 请求报文
        /// </summary>
        public MRScanRequest Request { get; set; } = null;
        /// <summary>
        /// 响应报文
        /// </summary>
        public MRScanResponse Response { get; private set; } = null;

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

            Response = Call<MRScanResponse>(Request, out errorMsg);
        }
    }

    /// <summary>
	/// 命名空间：IRAP.Service.Client.Exchange.MES
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/13, 11:17:01
	/// 类    名：MRScanRequest
	/// </summary>	
	public class MRScanRequest : CustomRequest
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public override string ExCode => "IRAP_MES_MR_Scan";
        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode { get; set; } = "";
    }

    /// <summary>
	/// 命名空间：IRAP.Service.Client.Exchange.MES
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/13, 11:17:19
	/// 类    名：MRScanResponse
	/// </summary>	
	public class MRScanResponse : CustomResponse
    {
        public MRScanResponseDetail Output { get; set; } 
            = new MRScanResponseDetail();
    }

    /// <summary>
	/// 命名空间：
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/13, 11:27:03
	/// 类    名：MRScanResponseDetail
	/// </summary>	
	public class MRScanResponseDetail
    {
        public string ComponentType { get; set; } = "";
    }
}
