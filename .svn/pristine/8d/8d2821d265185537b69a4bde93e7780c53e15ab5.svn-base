using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace TweebaaWebApp2.Product
{
    public partial class SubmitForm : TweebaaWebApp2.MasterPages.BasePage
    {
        public string str = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            string temp = System.Web.HttpContext.Current.Server.MapPath("~") + @"Product/SubmitPrdTemp.htm";
            StreamReader srd = new StreamReader(temp, Encoding.GetEncoding("UTF-8"));
            str = srd.ReadToEnd();
            str = str.Substring(str.IndexOf("<div")).Replace("</body>", "").Replace("</html>", "");
        }
    }
}