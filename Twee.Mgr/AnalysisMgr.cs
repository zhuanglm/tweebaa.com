using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.DataMgr;

namespace Twee.Mgr
{
    public class AnalysisMgr
    {
        string key = System.Configuration.ConfigurationManager.AppSettings["strKey"].ToString();
        AnalysisDataMgr dataMgr = new DataMgr.AnalysisDataMgr();
        public string GetUserReg(string strKey)
        {           
            return  dataMgr.GetUserReg(key);
        }
        public string GetUserLog(string strKey)
        {           
            return dataMgr.GetUserLog(key);
        }
        public string GetUserReview(string strKey)
        {           
            return dataMgr.GetUserReview(key);
        }
    }
}
