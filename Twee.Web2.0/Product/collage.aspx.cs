using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Product
{
    public partial class collage : TweebaaWebApp2.MasterPages.BasePage
    {
        public string templateHTML;
        private Guid? userGuid;
        public string _userid = string.Empty;
        public string _persent = string.Empty; //根据用户等级取分享比例
        public bool isLogion;
        public int templateID;

        public static bool IsIphone()
        {
            bool result = false;

            if ((HttpContext.Current != null) && (HttpContext.Current.Request != null) && (HttpContext.Current.Request.UserAgent != null))
            {
                result = (HttpContext.Current.Request.UserAgent.ToLower().Contains("iphone"));
            }

            return result;

        }

        public static bool IsIpad()
        {
            bool result = false;

            if ((HttpContext.Current != null) && (HttpContext.Current.Request != null) && (HttpContext.Current.Request.UserAgent != null))
            {
                result = (HttpContext.Current.Request.UserAgent.ToLower().Contains("ipad"));
            }

            return result;

        }
        public static bool IsAndroid()
        {
            bool result = false;

            if ((HttpContext.Current != null) && (HttpContext.Current.Request != null) && (HttpContext.Current.Request.UserAgent != null))
            {
                result = (HttpContext.Current.Request.UserAgent.ToLower().Contains("android"));
            }

            return result;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsAndroid())
            {
                Response.Redirect("/Product/collage_download_android.aspx");
                return;
            }
            if (IsIphone() || IsIpad())
            {
                Response.Redirect("/Product/collage_download_iphone.aspx");
                return;
            }
            Response.AppendHeader("Access-Control-Allow-Origin", "*");

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
                /*
                Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                Twee.Model.CollageTemplate template = mgr.GetTemplateByID(myTemplateID.Value.ToString());
                templateHTML = template.innerHTML;
                templateID = template.id;*/
            }
            else
            {
                //get html from template
                string design_id = Request.QueryString["templateID"];
                if (design_id != null)
                {
                    /*
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    Twee.Model.CollageTemplate template = mgr.GetTemplateByID(design_id);
                    templateHTML = template.innerHTML;
                    templateID = template.id;*/
                }
                else
                {
                    //get html from template
                    /*
                    Twee.Mgr.CollageTemplateMgr mgr = new CollageTemplateMgr();
                    Twee.Model.CollageTemplate template = mgr.GetFirstRandom();
                    templateHTML = template.innerHTML;
                    templateID = template.id;*/
                }
            }
        }
    }
}