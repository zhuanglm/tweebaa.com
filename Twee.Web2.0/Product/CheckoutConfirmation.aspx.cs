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
using Twee.Model;

namespace TweebaaWebApp2.Product
{
    public partial class CheckoutConfirmation : BasePage
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

        public string txtShippingAddrID;
        public string txtBillingAddrID;
         
        public string labBillingName;
        public string labBillingAddress;
        public string labBillingCountry;
        public string labBillingCountryID;
        public string labBillingProvinceID;
        public string labBillingZip;
        public string labBillingPhone;
        public string labBillingEmail;


        public string labShippingName;
        public string labShippingAddress;
        public string labShippingCountry;
        public string labShippingCountryID;
        public string labShippingProvinceID;
        public string labShippingZip;
        public string labShippingPhone;
        public string labShippingEmail;



        public int _TweebaaDefaultShipMethodID = ConfigParamter.iTweebaaDefaultShipMethodID;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (Request.QueryString["cartids"] != null)
            {
                string cartIds = Request.QueryString["cartids"].ToString();
                string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                CookiesHelper cookie = new CookiesHelper();
                cookie.createCookie(keyShopCart, cartIds, 1);
            }
            */
            ///create Billing Address
            ///
            try
            {
                //首先检查Request.Form["hidAddressId"]是否为空
                string txtFirstname = "";
                string txtLastname = "";
                string txtEmail = "";
                string txtPhone = "";
                string txtAddr1 = "";
                string txtAddr2 = "";
                string txtCity = "";
                string txtZip = "";
                string txtCountryID = "";
                string txtStateID = "";
                Twee.Mgr.UserAddressMgr mgr = new UserAddressMgr();
                txtBillingAddrID = "";
                if (Request.Form.AllKeys.Contains("hidAddressId"))
                {
                    txtShippingAddrID = Request.Form["hidAddressId"].ToString();
                    txtFirstname = Request.Form["billing_firstname"].ToString();
                    txtLastname = Request.Form["billing_lastname"].ToString();
                    txtEmail = Request.Form["billing_email"].ToString();
                    txtPhone = Request.Form["billing_phone"].ToString();
                    txtAddr1 = Request.Form["billing_address1"].ToString();
                    txtAddr2 = Request.Form["billing_address2"].ToString();
                    txtCity = Request.Form["billing_city"].ToString();
                    txtZip = Request.Form["billing_zip"].ToString();
                    txtCountryID = Request.Form["billing_country"].ToString();
                    txtStateID = Request.Form["billing_state"].ToString();
                }
                else
                {
                    //检查Cookie
                    if (Request.Cookies["hidAddressId"] != null)
                    {
                        txtShippingAddrID = Request.Cookies["hidAddressId"].Value;
                        //检查billing Address cookie

                        
                        /*
                        txtFirstname = Request.Form["billing_firstname"].ToString();
                        txtLastname = Request.Form["billing_lastname"].ToString();
                        txtEmail = Request.Form["billing_email"].ToString();
                        txtPhone = Request.Form["billing_phone"].ToString();
                        txtAddr1 = Request.Form["billing_address1"].ToString();
                        txtAddr2 = Request.Form["billing_address2"].ToString();
                        txtCity = Request.Form["billing_city"].ToString();
                        txtZip = Request.Form["billing_zip"].ToString();
                        txtCountryID = Request.Form["billing_country"].ToString();
                        txtStateID = Request.Form["billing_state"].ToString();*/
                    }
                    if (Request.Cookies["hidBillingAddressId"] != null)
                    {
                        txtBillingAddrID = Request.Cookies["hidBillingAddressId"].Value;
                        //Useraddress model1 = new Useraddress();
                        //model1 = mgr.GetModel(new Guid(txtBillingAddrID));
                        //u.guid,prtguid,provinceid,u.cityid,countyid,zip,address,address2,u.username,lastName,u.phone,tel,isfirst,addtime,p.ProName,city ,users.email,c.country ,u.email as guest_e_mail
                        DataTable dt = mgr.GetAddressByGuid(txtBillingAddrID);
                        DataRow dr = dt.Rows[0];
                        txtFirstname = dr["username"].ToString();
                        txtLastname = dr["lastName"].ToString();
                        if (dr["email"].ToString() == "")
                        {

                            txtEmail = dr["guest_e_mail"].ToString();
                        }
                        else
                        {
                            txtEmail = dr["email"].ToString();
                        }
                        txtPhone = dr["phone"].ToString();
                        txtAddr1 = dr["address"].ToString();
                        txtAddr2 = dr["address2"].ToString();
                        txtCity = dr["city"].ToString();
                        txtZip = dr["zip"].ToString();
                        txtCountryID = dr["countyid"].ToString();
                        txtStateID = dr["provinceid"].ToString();
                    }
                    else
                    {
                        
                    }
                }
                //txtBillingAddrID = Request.Form["hidBillingAddressId"].ToString();


                /*
                 * get state and country from database
                 */
                CountryMgr countryMgr = new CountryMgr();
                DataSet dsCountry = countryMgr.GetList("id=" + txtCountryID);
                ProvinceMgr stateMgr = new ProvinceMgr();
                DataSet dsSate = stateMgr.GetList("ProID=" + txtStateID);

                labBillingName=txtFirstname+" "+txtLastname;
                if (txtAddr2.Length > 0)
                {
                    if (dsSate.Tables[0].Rows.Count > 0)
                    {
                        labBillingAddress = txtAddr1 + " " + txtAddr2 + " <br> " + txtCity + " , " + dsSate.Tables[0].Rows[0]["ProName"].ToString();
                    }
                    else
                    {
                        labBillingAddress = txtAddr1 + " " + txtAddr2 + " <br> " + txtCity;
                    }
                }
                else
                {
                    if (dsSate.Tables[0].Rows.Count > 0)
                    {
                        labBillingAddress = txtAddr1 + " <br> " + txtCity + " , " + dsSate.Tables[0].Rows[0]["ProName"].ToString();
                    }
                    else
                    {
                        labBillingAddress = txtAddr1 + " <br> " + txtCity;
                    }
                 }
                 labBillingCountry = dsCountry.Tables[0].Rows[0]["country"].ToString();
                labBillingCountryID = txtCountryID;
                labBillingProvinceID = txtStateID;
                labBillingZip = txtZip;
                labBillingPhone = txtPhone;
                labBillingEmail = txtEmail;

                if (txtBillingAddrID.Length < 1)
                {
                    Useraddress model = new Useraddress();
                    model.address = txtAddr1;
                    model.address2 = txtAddr2;
                    model.city = txtCity;
                    model.countyid = txtCountryID.ToInt();
                    model.email = txtEmail;
                    model.lastName = txtLastname;
                    model.username = txtFirstname;
                    model.phone = txtPhone;
                    model.zip = txtZip;
                    model.provinceid = txtStateID.ToInt();


                    mgr.Add(model, out txtBillingAddrID);
                }

                //Fill shipping address and remove javascript loading address
                /*
                u.guid,prtguid,provinceid,u.cityid,countyid,zip,address,address2,u.username,lastName,u.phone,tel,isfirst,addtime,p.ProName,city ,users.email,c.country ,u.email as guest_e_mail
                 */
                DataTable dtShipping = mgr.GetAddressByGuid(txtShippingAddrID);
                DataRow drShipping = dtShipping.Rows[0];
                txtFirstname = drShipping["username"].ToString();
                txtLastname = drShipping["lastName"].ToString();
                txtEmail = drShipping["email"].ToString();
                if (txtEmail.Length < 3)
                {
                    txtEmail = drShipping["guest_e_mail"].ToString();
                }
                txtPhone = drShipping["phone"].ToString();
                txtAddr1 = drShipping["address"].ToString();
                txtAddr2 = drShipping["address2"].ToString();
                txtCity = drShipping["city"].ToString();
                txtZip = drShipping["zip"].ToString();
                txtCountryID = drShipping["countyid"].ToString();
                txtStateID = drShipping["provinceid"].ToString();


                labShippingName = txtFirstname + " " + txtLastname;
                if (txtAddr2.Length > 0)
                {
                    if (txtStateID.ToInt()>0)
                    {
                        labShippingAddress = txtAddr1 + " " + txtAddr2 + " <br> " + txtCity + " , " + drShipping["ProName"].ToString();
                    }
                    else
                    {
                        labShippingAddress = txtAddr1 + " " + txtAddr2 + " <br> " + txtCity;
                    }
                }
                else
                {
                    if (txtStateID.ToInt() > 0)
                    {
                        labShippingAddress = txtAddr1 + " <br> " + txtCity + " , " + drShipping["ProName"].ToString();
                    }
                    else
                    {
                        labShippingAddress = txtAddr1 + " <br> " + txtCity;
                    }
                }
                labShippingCountry = drShipping["country"].ToString();
                labShippingCountryID = txtCountryID;
                labShippingProvinceID = txtStateID;
                labShippingZip = txtZip;
                labShippingPhone = txtPhone;
                labShippingEmail = txtEmail;

            }
            catch (Exception e1)
            {
                Twee.Comm.CommUtil.GenernalErrorHandler(e1);
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
            /*
            if (!isLogion)
            {
                Response.Redirect("../User/loginGuest.aspx?op=shopOrder");
            }*/
        }
    }
}