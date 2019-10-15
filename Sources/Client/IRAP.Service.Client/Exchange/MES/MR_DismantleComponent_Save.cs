/*----------------------------------------------------------------
// Copyright © 2019 Hanklee rights reserved. 
// CLR 版本：4.0.30319.42000
// 类 名 称：MR_DismantleComponent_Save
// 文 件 名：MR_DismantleComponent_Save
// 创 建 者：李智颖
// 创建日期：2019/10/12 13:08:52
// 版本	日期					修改人	
// v0.1	2019/10/12 13:08:52      李智颖
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
    /// 创建日期：2019/10/12 13:08:52
    /// 类    名：MR_DismantleComponent_Save(提交拆解检测结果)
    /// </summary>	
    public class MR_DismantleComponent_Save : CustomWebAPICall
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="webAPIUrl">WebAPI地址</param>
        /// <param name="contentType">报文类型</param>
        /// <param name="clientID">渠道标识</param>
        public MR_DismantleComponent_Save(
            string webAPIUrl,
            ContentType contentType,
            string clientID) : base(webAPIUrl, contentType, clientID)
        {
            moduleType = ModuleType.Exchange;
            ExCode = "IRAP_MES_MR_DismantleComponent_Save";
        }

        /// <summary>
        /// 请求报文
        /// </summary>
        public MRDismantleComponentSaveRequest Request { get; set; } = null;
        /// <summary>
        /// 响应报文
        /// </summary>
        public MRDismantleComponentSaveResponse Response { get; private set; } = null;

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

            Response = Call<MRDismantleComponentSaveResponse>(Request, out errorMsg);
        }
    }

    /// <summary>
	/// 命名空间：IRAP.Service.Client.Exchange.MES
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/12, 13:10:28
	/// 类    名：MRDismantleComponentSaveRequest
	/// </summary>	
	public class MRDismantleComponentSaveRequest : CustomRequest
    {
        /// <summary>
        /// 交易代码
        /// </summary>
        public override string ExCode => "IRAP_MES_MR_DismantleComponent_Save";
        /// <summary>
        /// DMCNO
        /// </summary>
        public string DMCNO { get; set; } = "";
        /// <summary>
        /// 检测结果(报废/释放)
        /// </summary>
        public List<MRDismantleComponentSaveRequestDetail> ComponentList { get; set; }
            = new List<MRDismantleComponentSaveRequestDetail>();
    }

    /// <summary>
	/// 命名空间：
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/13, 19:48:39
	/// 类    名：MRDismantleComponentSaveRequestDetail
	/// </summary>	
	public class MRDismantleComponentSaveRequestDetail
    {
        /// <summary>
        /// 唯一码
        /// </summary>
        public string NO { get; set; } = "";
        /// <summary>
        /// 操作(报废/释放)
        /// </summary>
        public string QCStatus { get; set; } = "";
    }

    /// <summary>
	/// 命名空间：IRAP.Service.Client.Exchange.MES
	/// 创 建 者：李智颖
	/// 创建日期：2019/10/12, 13:12:39
	/// 类    名：MRDismantleComponentSaveResponse
	/// </summary>	
	public class MRDismantleComponentSaveResponse : CustomResponse
    {
    }
}
