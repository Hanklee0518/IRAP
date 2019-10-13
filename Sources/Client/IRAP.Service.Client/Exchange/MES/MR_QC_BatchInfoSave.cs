/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 类 名 称：MR_QC_BatchInfoSave
// 文 件 名：MR_QC_BatchInfoSave
// 创 建 者：李智颖
// 创建日期：2019/10/13 22:25:06
// 版本	日期					修改人	
// v0.1	2019/10/13 22:25:06      李智颖
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
    /// 创建日期：2019/10/13 22:25:06
    /// 类    名：MR_QC_BatchInfoSave(保存批追数据)
    /// </summary>	
    public class MR_QC_BatchInfoSave : CustomWebAPICall
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="webAPIUrl">WebAPI地址</param>
        /// <param name="contentType">报文类型</param>
        /// <param name="clientID">渠道标识</param>
        public MR_QC_BatchInfoSave(
            string webAPIUrl,
            ContentType contentType,
            string clientID) : base(webAPIUrl, contentType, clientID)
        {
            moduleType = ModuleType.Exchange;
            ExCode = "IRAP_MES_MR_QC_BatchInfoSave";
        }

        /// <summary>
        /// 请求报文
        /// </summary>
        public MRQCBatchInfoSaveRequest Request { get; set; } = null;
        /// <summary>
        /// 响应报文
        /// </summary>
        public MRQCBatchInfoSaveResponse Response { get; private set; } = null;

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

            Response = Call<MRQCBatchInfoSaveResponse>(Request, out errorMsg);
        }
    }

    /// <summary>
	/// 命名空间：IRAP.Service.Client.Exchange.MES
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/13, 22:27:42
	/// 类    名：MRQCBatchInfoSaveRequest
	/// </summary>	
	public class MRQCBatchInfoSaveRequest : CustomRequest
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public override string ExCode => "IRAP_MES_MR_QC_BatchInfoSave";
        /// <summary>
        /// 容器编号
        /// </summary>
        public string NO { get; set; }
        /// <summary>
        /// 合格数
        /// </summary>
        public int GoodQty { get; set; }
        /// <summary>
        /// 不合格数
        /// </summary>
        public int NGQty { get; set; }
    }

    /// <summary>
	/// 命名空间：
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/13, 22:29:54
	/// 类    名：MRQCBatchInfoSaveResponse
	/// </summary>	
	public class MRQCBatchInfoSaveResponse : CustomResponse
    {
    }
}
