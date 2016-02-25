using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Product
{
    public partial class prdReviewAll : TweebaaWebApp2.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string _popbox = "none;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool isLogion = CheckLogion(out userGuid);
                if (isLogion == false)
                {
                    //check cookies
                    HttpCookie myCookie = new HttpCookie("EvaluatorsPopup");
                    myCookie = Request.Cookies["EvaluatorsPopup"];

                    try
                    {
                        // Read the cookie information and display it.

                        if (myCookie != null && int.Parse(myCookie.Value.ToString()) > 0)
                        {
                            //design_id = myDesignID.Value.ToString();
                        }
                        else
                        {
                            _popbox = "block;";
                        }
                    }
                    catch (Exception e1)
                    {

                    }
                }
            }
        }
    }
}