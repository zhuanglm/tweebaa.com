using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Reflection;
using TweebaaWebApp2.MasterPages;
using System.Web.Script.Serialization;
using Twee.Mgr;
using Twee.Model;
using Newtonsoft.Json;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class expressAjax : BasePage
    {
        private Guid? userGuid;
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion == false)
            {
                Response.Write("-1");
                return;
            }
            else
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string cartInfo = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(cartInfo);
                action = dic["action"].ToString();
                if (action == "add")
                {
                    AddExpress();
                }
                else if (action == "delet")
                {
                    DeletExpress();
                }
                else if (action == "query")
                {
                    QueryExpress();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void AddExpress()
        { 
        
        }
        /// <summary>
        /// 
        /// </summary>
        private void DeletExpress()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        private void QueryExpress()
        {
            try
            {
                Twee.Mgr.ExpressCompanyMgr mgr = new Twee.Mgr.ExpressCompanyMgr();
                List<Expresscompany> listModel = mgr.DataTableToList(mgr.GetAllList().Tables[0]);
                string data = JsonConvert.SerializeObject(listModel);
                Response.Clear();
                Response.Write(data);
            }
            catch (Exception)
            {
                Response.Write("");
            }
           
        }




    }
}