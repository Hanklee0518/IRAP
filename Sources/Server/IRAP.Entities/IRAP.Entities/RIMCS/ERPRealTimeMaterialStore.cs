using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRAP.Entities.RIMCS
{
    public class ERPRealTimeMaterialStore
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int Ordinal { get; set; } = 0;
        /// <summary>
        /// 物料代码
        /// </summary>
        public string MaterialCode { get; set; } = "";
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialDesc { get; set; } = "";
        /// <summary>
        /// 仓储地点代码
        /// </summary>
        public string SiteCode { get; set; } = "";
        /// <summary>
        /// ERP库位代码
        /// </summary>
        public string ERPStoreLoc { get; set; } = "";
        /// <summary>
        /// ERP储位代码
        /// </summary>
        public string T106AltCode { get; set; } = "";
        /// <summary>
        /// 生产批次号
        /// </summary>
        public string LotNumber { get; set; } = "";
        /// <summary>
        /// 生产日期
        /// </summary>
        public string MFGDate { get; set; } = "";
        /// <summary>
        /// 收料批次号
        /// </summary>
        public string RecvBatchNo { get; set; } = "";
        /// <summary>
        /// 实时库存
        /// </summary>
        public decimal QtyInStore { get; set; } = 0;
        /// <summary>
        /// 供应商寄售库存
        /// </summary>
        public decimal QtyConsigned { get; set; } = 0;
        /// <summary>
        /// 放大数量级
        /// </summary>
        public int QtyScale { get; set; } = 0;
        /// <summary>
        /// 实时库存金额
        /// </summary>
        public decimal AmtInStore { get; set; } = 0;
        /// <summary>
        /// 寄售库存金额
        /// </summary>
        public decimal AmtConsigned { get; set; } = 0;
        /// <summary>
        /// 金额放大数量级
        /// </summary>
        public int AmtScale { get; set; } = 0;
    }
}
