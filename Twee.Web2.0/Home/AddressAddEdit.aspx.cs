using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Home
{
    public partial class AddressAddEdit : System.Web.UI.Page
    {
        public string strComeFrom = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["from"]))
            {

            }
            else
            {
                //用户从Add 2 Cart 来，应该回到Checkout page
                strComeFrom =  Request["from"].ToString();
            }
        }
    }
}