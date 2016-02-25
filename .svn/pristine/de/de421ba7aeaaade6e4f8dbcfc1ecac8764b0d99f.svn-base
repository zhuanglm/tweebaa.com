using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Model;

namespace TweebaaWebApp.Product
{
    public partial class CollageCreate : TweebaaWebApp.MasterPages.BasePage
    {
        public string templateHTML;
        private Guid? userGuid;
        public string _userid = string.Empty;
        public string _persent = string.Empty; //根据用户等级取分享比例
        public bool isLogion;
        public int templateID;

        protected void Page_Load(object sender, EventArgs e)
        {
            isLogion = CheckLogion(out userGuid);

            if (null != userGuid)
            {
                _userid = userGuid.ToString();
            }
            HttpCookie myTemplateID = new HttpCookie("templateID");
            myTemplateID = Request.Cookies["templateID"];

            // Read the cookie information and display it.
            if (myTemplateID != null && int.Parse(myTemplateID.Value.ToString()) > 0)
            {
               // Response.Write("<p>" + myTemplateID.Name + "<p>" + myTemplateID.Value);
                //get html from template
                Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                Twee.Model.CollageTemplate template = mgr.GetTemplateByID(myTemplateID.Value.ToString());
                templateHTML = template.innerHTML;
                templateID = template.id;
            }
            else
            {
                //get html from template
                string design_id = Request.QueryString["templateID"];
                if (design_id != null)
                {
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    Twee.Model.CollageTemplate template = mgr.GetTemplateByID(design_id);
                    templateHTML = template.innerHTML;
                    templateID = template.id;
                }
                else
                {
                    //get html from template
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    Twee.Model.CollageTemplate template = mgr.GetFirstRandom();
                    templateHTML = template.innerHTML;
                    templateID = template.id;
                }
            }

        }
    }
}