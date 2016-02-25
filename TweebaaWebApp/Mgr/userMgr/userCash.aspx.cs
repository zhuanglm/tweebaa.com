using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

namespace TweebaaWebApp.Mgr.userMgr
{
    public partial class userCash : System.Web.UI.Page
    {
        public  string state = "未提取";
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(userCash));
        }

        /// <summary>
        /// 批准申请
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod]
        public string Approval(int id,int state)
        {
            try
            {
                var res = new Twee.Mgr.ProfitMgr().UpdateState(id, state);
                if (res > 0)
                    return "success";              
                else
                    return "fail";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }
    }
}