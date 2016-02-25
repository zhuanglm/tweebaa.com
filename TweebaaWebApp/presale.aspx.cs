using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;

namespace TweebaaWebApp
{
    public partial class presale : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Response.Redirect("/study.aspx");

            Twee.Mgr.ProfitMgr mgr = new Twee.Mgr.ProfitMgr();
            //Guid? user = "A4D9C4AA-DBE8-41E2-A1D2-0D1C6AADED4F".ToGuid();
            //mgr.PublishProfitCal("Twee201513163027984");
            mgr.ReviewProfitCal("Twee201513163027984");
        }
    }
}