using IRAP.Entities.RIMCS;
using IRAP.Global;
using IRAPORM;
using IRAPShared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IRAP.BL.RIMCS
{
    public class Asimco : IRAPBLLBase
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        public Asimco()
        {
            WriteLog.Instance.WriteLogFileName =
                MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        }

        /// <summary>
        /// 查询四班子项物料实时库存
        /// </summary>
        /// <param name="communityID"></param>
        /// <param name="tf482PK"></param>
        /// <param name="factID"></param>
        /// <param name="sysLogID"></param>
        /// <param name="errCode"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public IRAPJsonResult ufn_GetList_ERPRealTimeMaterialStore(
            int communityID,
            long tf482PK,
            long factID,
            long sysLogID,
            out int errCode,
            out string errText)
        {
            string strProcedureName = $"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                List<ERPRealTimeMaterialStore> datas = new List<ERPRealTimeMaterialStore>();

                #region 创建数据库调用参数组，并赋值
                IList<IDataParameter> paramList = new List<IDataParameter>();
                paramList.Add(new IRAPProcParameter("@CommunityID", DbType.Int32, communityID));
                paramList.Add(new IRAPProcParameter("@TF482PK", DbType.Int64, tf482PK));
                paramList.Add(new IRAPProcParameter("@FactID", DbType.Int64, factID));
                paramList.Add(new IRAPProcParameter("@SysLogID", DbType.Int64, sysLogID));
                WriteLog.Instance.Write(
                    $"调用函数 IRAPRIMCS..ufn_GetList_ERPRealTimeMaterialStore，参数："+
                    $"CommunityID={communityID}|TF482PK={tf482PK}|FactID={factID}|"+
                    $"SysLogID={sysLogID}",
                    strProcedureName);
                #endregion

                #region 执行数据库函数或存储过程
                try
                {
                    using (IRAPSQLConnection conn = new IRAPSQLConnection())
                    {
                        string strSQL = "SELECT * " +
                            "FROM IRAPRIMCS..ufn_GetList_ERPRealTimeMaterialStore(" +
                            "@CommunityID, @TF482PK, @FactID, @SysLogID) " +
                            "ORDER BY Ordinal";

                        IList<ERPRealTimeMaterialStore> lstDatas =
                            conn.CallTableFunc<ERPRealTimeMaterialStore>(strSQL, paramList);
                        datas = lstDatas.ToList();
                        errCode = 0;
                        errText = string.Format("调用成功！共获得 {0} 条记录", datas.Count);
                        WriteLog.Instance.Write(errText, strProcedureName);
                    }
                }
                catch (Exception error)
                {
                    errCode = 99000;
                    errText =
                        string.Format(
                            "调用 IRAPRIMCS..ufn_GetList_ERPRealTimeMaterialStore 函数发生异常：{0}",
                            error.Message);
                    WriteLog.Instance.Write(errText, strProcedureName);
                    WriteLog.Instance.Write(error.StackTrace, strProcedureName);
                }
                #endregion

                return Json(datas);
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
