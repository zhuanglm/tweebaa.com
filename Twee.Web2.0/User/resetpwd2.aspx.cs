using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Comm;

namespace TweebaaWebApp2.User
{
    public partial class resetpwd2 : System.Web.UI.Page
    {
     protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    labEmail.Text = Request.QueryString["id"].ToString();
                }
            }           
            
        }

        protected void SendEmail(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string email = Request["id"].ToNullString();
                    UserMgr userMgr = new UserMgr();
                    List<Twee.Model.User> list = userMgr.GetModelList(" email='" + email + "'");
                    if (list != null && list.Count > 0)
                    {
                        Twee.Model.User user = list[0];
                        bool b = Mailhelper.SendFindPassEmail(user.username,email, user.guid.ToString());
                        if (b)
                        {
                            Response.Write("<script>alert('Has been sent, please check it again')</script>");
                            return;
                        }
                        else
                        {
                            Response.Write("<script>alert('Send failed')</script>");
                            return;
                        }

                    }
                    Response.Write("<script>alert('Send failed')</script>");
                    return;
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Send failed')</script>");
                throw;
            }         
        }
       
    }
    
}