using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using AjaxPro;

namespace TweebaaWebApp2.Mgr.userMgr
{
    public partial class users : System.Web.UI.Page
    {
        public string _userStatus = "[{value:'--请选择--',text:'--请选择--'}]";

        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(users));
            var status = Twee.Comm.ConfigParamter.UserStatusDic;
            if (status != null && status.Count > 0)
            {
                StringBuilder st = new StringBuilder();
                foreach(var item in status)
                {
                    st.AppendFormat(",{0}value:'{2}',text:'{3}'{1}", "{", "}", item.Key, item.Value);
                }
                _userStatus = "[{value:'--请选择--',text:'--请选择--'}";
                _userStatus += st.ToString();
                _userStatus += "]";
            }
        }
        [AjaxPro.AjaxMethod]
        public string DeleteUser(string guid)
        {
            try
            {
                Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();
                bool b = mgr.Delete(guid.ToGuid().Value);
                if (b)
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