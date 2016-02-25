using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp
{
    public partial class share : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string prdID = "d4cea5be-a41d-4334-b480-dbcd5231cd8f_2050a743-9063-49f0-9d28-ba4204d68df0";
            if (prdID.IndexOf("_") > 0)
            {
                prdID = prdID.Substring(0, prdID.IndexOf("_"));
            }

            string orderNum ="Twee"+ DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond;
            
        }
    }
}