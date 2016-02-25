using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Product
{
    public partial class prdSaleAll : System.Web.UI.Page
    {
        public  string cssPath = "../";
        public string strCateID = "";
        public string strKeyword = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            // tag
            // iscustomerfreeship 1 \0  rule表
            // ship 挨着
            //产品类别
            if (!string.IsNullOrEmpty(Request["action"]))
            {
                string action = Request["action"];
                if (action == "search")
                {
                    strCateID = Request.Form["shopCategory"];
                    strKeyword = Request.Form["txtKeywords"];
                }
            }
        }
    }
}