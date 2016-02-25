using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweebaaWebApp.MasterPages;
using Twee.Comm;
using System.Data;

namespace TweebaaWebApp.Product
{
    public partial class shopOrder : BasePage
    {
        public string _displaySaved = "block";
        public string _displayShop = "none";
        public string _addressCartGudid = "";
        public string _extractionTweebuck = "0.00";
        public string _shoppingPoint = "0.00";
        public string _shoppingPointMoney = "0.00";
        public int _TweebaaDefaultShipMethodID = ConfigParamter.iTweebaaDefaultShipMethodID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["cartids"] != null)
            {
                string cartIds = Request.QueryString["cartids"].ToString();
                string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                CookiesHelper cookie = new CookiesHelper();
                cookie.createCookie(keyShopCart, cartIds, 1);
            }

            Guid? userGuid;
            bool isLogion = CheckLogion(out userGuid);
            if (isLogion && userGuid != null)
            {
                Twee.Mgr.ProfitMgr profit = new Twee.Mgr.ProfitMgr();
                DataTable dt = profit.GetTweebuck(userGuid.Value);
                if (dt != null && dt.Rows.Count > 0)
                {
                    decimal extractionTweebuck = dt.Rows[0]["ExtractionTweebuck"].ToString().ToDecimal();//可使用的tweebucks
                    _extractionTweebuck = extractionTweebuck.ToString();
                }
                Twee.Mgr.UserGradeCalMgr grade = new Twee.Mgr.UserGradeCalMgr();
                Twee.Model.Usergrade gradeModel = grade.GetModel(userGuid.Value);
                if (gradeModel!=null)
                {
                    _shoppingPoint = gradeModel.shopingPoint.ToString();
                    _shoppingPointMoney = Math.Round((gradeModel.shopingPoint * ConfigParamter.shoppingPointRate).Value,2).ToString();
                }
               
            }
            if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "guest")
            {             

                _displaySaved = "none";
                _displayShop = "block";               
                return;
            }
            if (!isLogion)
            {
                Response.Redirect("../User/loginGuest.aspx?op=shopOrder");
            }
        }
    }
}