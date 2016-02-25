﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using Twee.Comm;

namespace TweebaaWebApp.AjaxPages
{
    public partial class UpdatePwd : System.Web.UI.Page
    {
        Dictionary<string, object> dic = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();

            //System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
            //string userInfo = sr.ReadToEnd();
            //JavaScriptSerializer js = new JavaScriptSerializer();
            //dic = js.Deserialize<Dictionary<string, object>>(userInfo);

            if (Request["type"] != null)
            {
                ResetePwd();
            }
            else
            {
                //修改密码
                string userID = CommHelper.GetStrDecode(Request["id"].ToString());
                string email = Request["email"].ToString();
                string pwd = PasswordHelper.ToUpMd5(Request["pwd"].ToString());
                Guid guid = new Guid(userID);
                if (mgr.Exists(guid, email))
                {
                    bool resu = mgr.UpdatePwd(email, pwd);
                    if (resu)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }
            }          
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        public void ResetePwd()
        {
            Twee.Mgr.UserMgr mgr = new Twee.Mgr.UserMgr();

            string user = Request["user"].ToString();
            string pwd = Request["pwd"].ToString();
            string type = Request["type"].ToString();
            if (type == "email")
            {
                if (mgr.ExistsByID(user))
                {
                    bool resu = mgr.UpdatePwdByID(user, pwd);
                    if (resu)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }
            }
            else
            {
                if (mgr.Exists(user))
                {
                    bool resu = mgr.UpdatePwd(user, pwd, type);
                    if (resu)
                    {
                        Response.Write("success");
                    }
                    else
                    {
                        Response.Write("false");
                    }
                }

            }
            
        }

    }
}