using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweebaaWebApp2.MasterPages;
using System.Data;
using Twee.Comm;
using Twee.Mgr;


namespace TweebaaWebApp2.Product
{
    public partial class shopOrder : BasePage
    {
        public string _displaySaved = "block";
        public string _displayShop = "none";
        public string _addressCartGudid = "";
        public string _extractionTweebuck = "0.00";
        public string _shoppingPoint = "0.00";
        public string _shoppingPointMoney = "0.00";

        //Add by Long for Share Point Redeem
        public string _sharePoint = "0.00";
        public string _sharePointMoney = "0.00";
        //Add by Long for Share Point Redeem EOF

        public bool _IsGuestChecout = false;

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
                if (gradeModel != null)
                {
                    //_shoppingPoint = gradeModel.shopingPoint.ToString();
                    //_shoppingPointMoney = Math.Round((gradeModel.shopingPoint * ConfigParamter.shoppingPointRate).Value, 2).ToString();

                    OrderMgr order = new OrderMgr();
                    decimal shoppingMoney = order.GetSumShopMoney(userGuid.ToString(), ConfigParamter.OrderStatus.Shipped);    //change 3 --2 
                    decimal used_shopping_money = order.GetSumUsedShoppingPointsMoney(userGuid.ToString());
                    // shopping gift reward
                    UserGiftRewardMgr giftMgr = new UserGiftRewardMgr();
                    int iGiftShoppingPoint = giftMgr.GetTotalShoppingRewardPoint(userGuid.ToString());
                    //decimal bonusShoppingPoint = order.GetBonusShoppingPoint(userGuid.ToString());
                    shoppingMoney += iGiftShoppingPoint;
                    //shoppingMoney += bonusShoppingPoint;
                    shoppingMoney = shoppingMoney - used_shopping_money * 80;

                    _shoppingPoint = Math.Round(shoppingMoney, 2).ToString("#0.00");
                    _shoppingPointMoney = Math.Round(shoppingMoney * 0.0125M, 2).ToString("#0.00");



                    _sharePoint = gradeModel.shareintegral.ToString();
                    _sharePointMoney = Math.Round((_sharePoint.ToInt() * 0.01), 2).ToString("#0.00");
                }

            }
            if (Request.QueryString["type"] != null && Request.QueryString["type"].ToString() == "guest")
            {

                _displaySaved = "none";
                _displayShop = "block";
                _IsGuestChecout = true;
                return;
            }
            if (!isLogion)
            {
                Response.Redirect("../User/loginGuest.aspx?op=shopOrder");
            }
        }

       
            //1. 非会员购买邮箱必输
            //2. 非会员订单状态支付后应显示代发货
            //3. 订单状态更改后发送邮件
        
    }
}