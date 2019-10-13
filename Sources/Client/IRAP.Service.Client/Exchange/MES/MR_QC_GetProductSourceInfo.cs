/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 类 名 称：MR_QC_GetProductSourceInfo
// 文 件 名：MR_QC_GetProductSourceInfo
// 创 建 者：李智颖
// 创建日期：2019/10/12 14:00:42
// 版本	日期					修改人	
// v0.1	2019/10/12 14:00:42      李智颖
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
    /// 创建日期：2019/10/12 14:00:42
    /// 类    名：MR_QC_GetProductSourceInfo(获取部件来源信息)
    /// </summary>	
    public class MR_QC_GetProductSourceInfo : CustomWebAPICall
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="webAPIUrl">WebAPI地址</param>
        /// <param name="contentType">报文类型</param>
        /// <param name="clientID">渠道标识</param>
        public MR_QC_GetProductSourceInfo(
            string webAPIUrl,
            ContentType contentType,
            string clientID) : base(webAPIUrl, contentType, clientID)
        {
            moduleType = ModuleType.Exchange;
            ExCode = "IRAP_MES_MR_QC_GetProductSourceInfo";
        }

        /// <summary>
        /// 请求报文
        /// </summary>
        public MRQCGetProductSourceInfoRequest Request { get; set; } = null;
        /// <summary>
        /// 响应报文
        /// </summary>
        public MRQCGetProductSourceInfoResponse Response { get; private set; } = null;

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

            Response = Call<MRQCGetProductSourceInfoResponse>(Request, out errorMsg);
        }
    }

    /// <summary>
	/// 命名空间：IRAP.Service.Client.Exchange.MES
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/12, 14:01:48
	/// 类    名：MRQCGetProductSourceInfoRequest
	/// </summary>	
	public class MRQCGetProductSourceInfoRequest : CustomRequest
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public override string ExCode => "IRAP_MES_MR_QC_GetProductSourceInfo";
        /// <summary>
        /// DMC码
        /// </summary>
        public string DMCNO { get; set; } = "";
    }

    /// <summary>
	/// 命名空间：IRAP.Service.Client.Exchange.MES
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/12, 14:03:49
	/// 类    名：MRQCGetProductSourceInfoResponse
	/// </summary>	
	public class MRQCGetProductSourceInfoResponse : CustomResponse
    {
        /// <summary>
        /// 总页码
        /// </summary>
        public int Total { get; set; } = 0;
        /// <summary>
        /// 返回的数据结构
        /// </summary>
        public MRQCGetProductSourceInfoDetail Output { get; set; } 
            = new MRQCGetProductSourceInfoDetail();
    }

    /// <summary>
	/// 命名空间：
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/12, 14:06:52
	/// 类    名：MRQCGetProductSourceInfoDetail
	/// </summary>	
	public class MRQCGetProductSourceInfoDetail
    {
        /// <summary>
        /// 产线信息
        /// </summary>
        public string ProductionLine { get; set; } = "";
    }
}

