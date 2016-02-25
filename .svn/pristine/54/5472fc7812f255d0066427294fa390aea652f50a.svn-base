using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Twee.Mgr;
namespace TweebaaWebApp2
{
    public partial class t : System.Web.UI.Page
    {
        public string _sFullUrl ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["id"]))
            {
                _sFullUrl = "https://www.tweebaa.com";
                return;
            }
            int iShortUrlID = Request["id"].ToString().ToInt();
            ShareMgr mgr = new ShareMgr();
            _sFullUrl = mgr.GetFulltUrl(iShortUrlID);
            if (_sFullUrl.Substring(0, 10) == "localhost:") _sFullUrl = "http://" + _sFullUrl;
            else if (_sFullUrl.Substring(0, 6) != "https:") _sFullUrl = "https://" + _sFullUrl;
            // for test _sFullUrl = "https://www.tweebaa.com/Product/saleBuy.aspx?id=3d7aeec0-5ece-4fad-975c-a58ef9464af1";
            return;
        }
    }
}