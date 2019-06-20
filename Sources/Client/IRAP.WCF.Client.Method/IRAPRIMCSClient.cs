using IRAP.Entities.RIMCS;
using IRAP.Global;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IRAP.WCF.Client.Method
{
    public class IRAPRIMCSClient
    {
        private static string className =
            MethodBase.GetCurrentMethod().DeclaringType.FullName;

        private static IRAPRIMCSClient _instance = null;

        private IRAPRIMCSClient()
        {

        }

        public static IRAPRIMCSClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new IRAPRIMCSClient();
                return _instance;
            }
        }

        public void ufn_GetList_ERPRealTimeMaterialStore(
            int communityID,
            long tf482PK,
            long factID,
            long sysLogID,
            ref List<ERPRealTimeMaterialStore> datas,
            out int errCode,
            out string errText)
        {
            string strProcedureName =$"{className}.{MethodBase.GetCurrentMethod().Name}";

            WriteLog.Instance.WriteBeginSplitter(strProcedureName);
            try
            {
                datas.Clear();

                #region 将函数调用参数加入 HashTable 中
                Hashtable hashParams = new Hashtable();

                hashParams.Add("communityID", communityID);
                hashParams.Add("tf482PK", tf482PK);
                hashParams.Add("factID", factID);
                hashParams.Add("sysLogID", sysLogID);
                WriteLog.Instance.Write(
                    $"调用 ufn_GetList_ERPRealTimeMaterialStore 函数， " +
                    $"参数：CommunityID={communityID}|TF482PK={tf482PK}|" +
                    $"FactID={factID}|SysLogID={sysLogID}",
                    strProcedureName);
                #endregion

                #region 执行存储过程或者函数
                using (WCFClient client = new WCFClient())
                {

                    object rlt =
                        client.WCFRESTFul(
                            "IRAP.BL.RIMCS.dll",
                            "IRAP.BL.RIMCS.Asimco",
                            "ufn_GetList_ERPRealTimeMaterialStore",
                        hashParams,
                        out errCode,
                        out errText);
                    WriteLog.Instance.Write(
                        string.Format(
                            "({0}){1}", errCode, errText),
                        strProcedureName);

                    if (errCode == 0)
                    {
                        datas = rlt as List<ERPRealTimeMaterialStore>;
                    }
                }
                #endregion
            }
            catch (Exception error)
            {
                WriteLog.Instance.Write(error.Message, strProcedureName);
                errCode = -1001;
                errText = error.Message;
            }
            finally
            {
                WriteLog.Instance.WriteEndSplitter(strProcedureName);
            }
        }
    }
}
