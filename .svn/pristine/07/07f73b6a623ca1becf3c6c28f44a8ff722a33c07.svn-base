using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using log4net;
using System.Reflection;
using System.Text;
using Twee.Comm;

namespace TweebaaWebApp.AjaxPages
{
    public partial class indexAjax : System.Web.UI.Page
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadInfo();
        }
        /// <summary>
        /// 首页三个区的最新动态
        /// </summary>
        private void LoadInfo()
        {
            string prd = LoadPrd();
            Twee.Mgr.IndexMgr mgr = new Twee.Mgr.IndexMgr();
            DataSet ds = mgr.GetInfo();
            if (ds.Tables.Count==3)
            {
                string strInfo1 = JsonConvert.SerializeObject(ds.Tables[0]);
                string strInfo2 = JsonConvert.SerializeObject(ds.Tables[1]);
                string strInfo3 = JsonConvert.SerializeObject(ds.Tables[2]);
                string data = strInfo1 + "@" + strInfo2 + "@" + strInfo3+ "@" + prd;
                Response.Write(data);
            }         
          
        }

        /// <summary>
        /// 首页显示产品
        /// </summary>
        private string LoadPrd()
        {
            /// 【屏蔽:-1】【草稿:0】【评审中(大众):1】【预售中:2】【销售中:3】；
            /// 【评审中(推易吧):4】【评审失败(推易吧):5】【等待上架:6】【预售失败:7】
            Twee.Mgr.IndexMgr mgr = new Twee.Mgr.IndexMgr();
            DataSet ds = mgr.GetPrd();           
            if (ds != null && ds.Tables.Count == 4)
            {
                //string data =JsonConvert.SerializeObject(ds);
            }
            string data = JsonConvert.SerializeObject(ds);
            string imgpath = System.Configuration.ConfigurationManager.AppSettings["prdImgDomain"].ToString();
            data = "[" + JsonConvert.SerializeObject(ds) + ",{imgDoman:" + "\"" + imgpath + "\"}" + "]";
            return data;

        
        }
            
    }
}