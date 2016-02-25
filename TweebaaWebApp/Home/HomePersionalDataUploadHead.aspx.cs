using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;
using TweebaaWebApp.MasterPages;

namespace TweebaaWebApp.Home
{
    public partial class HomePersionalDataUploadHead : BasePage
    {
        private Guid? userGuid;
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
                string userEmail = new CookiesHelper().getCookie("jZvJvvjqCILHX7zjBWskQB");
                var userMgr = new UserMgr();
                var user = userMgr.GetModel(userGuid.Value, userEmail);

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];
                    if (!string.IsNullOrEmpty(file.FileName))
                    {
                        var directory = Server.MapPath("~/headimgs");
                        if (!Directory.Exists(directory))
                        {
                            Directory.CreateDirectory(directory);
                        }
                        var fileName = string.Format("{0}{1}", user.username, Path.GetExtension(file.FileName));
                        var path = Path.Combine(directory, fileName);
                        file.SaveAs(path);
                        if (userMgr.UpdateHeadImg(userGuid.Value.ToString(), "~/headimgs/" + fileName))
                        {
                            imgUserHead.ImageUrl = "../headimgs/" + fileName;
                            //Response.Write("~/headimgs/" + fileName);
                        }
                        else
                        {
                            //Response.Write("0");
                        }
                    }
                }
                else
                {
                    imgUserHead.ImageUrl = user.headimg;
                }
            }
        }
    }
}