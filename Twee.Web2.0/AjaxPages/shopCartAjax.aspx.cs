﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Model;
using Twee.Comm;
using TweebaaWebApp2.MasterPages;
using System.Web.Script.Serialization;
using log4net;
using System.Reflection;
using System.Data;
using Newtonsoft.Json;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class shopCartAjax : BasePage
    {
        private Guid? userGuid;
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string action = "";
        Dictionary<string, object> dic = null;
        protected void Page_Load(object sender, EventArgs e)
        {
                bool isLogion = CheckLogion(out userGuid);               
                System.IO.StreamReader sr = new System.IO.StreamReader(Request.InputStream);
                string cartInfo = sr.ReadToEnd();
                JavaScriptSerializer js = new JavaScriptSerializer();
                dic = js.Deserialize<Dictionary<string, object>>(cartInfo);
                action = dic["action"].ToString();
                if (action == "GetProvinceTax")
                {
                    GetProvinceTax();
                    return;
                }
 
                if (action == "GetShipFeeListByWeight")
                {
                    QueryShipFeeListByWeight();
                    return;
                }
                else if (action == "GetDropShipperShipFeeList")
                {
                    QueryDropShipperShipFeeList();
                    return;
                }
                else if (action == "GetDropShipperFlatShipFee")
                {
                    QueryDropShipperFlatShipFee();
                    return;
                }
                else if (action == "GetProductShipToCountryFree")
                {
                    QueryProductShipToCountryFree();
                    return;
                }
                else if (action == "SetShipMethod")
                {
                    SetShipMethod();
                    return;
                }
            
                if (dic.Keys.Contains("ruleid") && dic["ruleid"].ToString() == "")
                {
                    Response.Write("-2");
                    return;
                }
                if (action == "add")
                {
                    AddShopCart();
                }
                else if (action == "query")
                {
                    QueryShopCart();
                }
                //bool isLogion = CheckLogion(out userGuid);
                //if (isLogion == false)
                //{
                //    Response.Write("-1");
                //    return;
                //}
                else if (action == "buynow")
                {
                    AddShopCartPaynow();
                }
                else if (action == "delet")
                {
                    DeletShopCart();
                    //DeletShopCartList();
                }
                else if (action == "deletlist")
                {
                    //DeletShopCart();
                    DeletShopCartList();
                }                
                else if (action == "AddNum")
                {
                    AddNum();
                }
                else if (action == "check_shipping_country")
                {
                    Check_Shipping_Country();
                }
                else if (action == "check_shipping_country_ex")
                {

                    Check_Shipping_Country_ex();
                }
                else if (action == "check_shipping_country_ex2")
                {

                    Check_Shipping_Country_ex2();
                }
            
        }
        private void Check_Shipping_Country_ex2()
        {
            string sProId = dic["proId"].ToString();
            string sProsku = dic["prosku"].ToString();
            string sCountryID = dic["CountryId"].ToString();
            //用户登录状态添加购物车
            if (userGuid != null)
            {
                //Add by Long for shipping country limit
                PrdMgr prdMgr = new PrdMgr();

                DataTable dt = prdMgr.GetProductTweebaaRulesExtra(sProId, dic["RulesID"].ToString());
                //string s_shipTo = dt.Rows[0]["ShipFrom_ShipToCountries"].ToString();// USA,CA
                string s_shipTo = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    s_shipTo = s_shipTo + dt.Rows[i]["Country_Name"].ToString() + ",";
                }
                s_shipTo = s_shipTo.ToUpper();
                //get user country id
                UserMgr userMgr = new UserMgr();
                UserAddressMgr mgr1 = new UserAddressMgr();
                DataTable dt1 = mgr1.GetMyAddress(userGuid.Value);

                //判断这个用户是否是获得了shipping fee，再次返回的用户
                string sRet = userMgr.CheckCustomShippingFee(sProId, dt1.Rows[0]["address"].ToString(), dt1.Rows[0]["city"].ToString(), dt1.Rows[0]["ProName"].ToString(), dt1.Rows[0]["country"].ToString(), dt1.Rows[0]["zip"].ToString());
                float flFee = float.Parse(sRet);
                if (flFee > 0)
                {

                    Response.Write(sRet);
                    return;
                }
                else
                {   //没有这个用户
                    Twee.Mgr.CountryMgr countryMgr=new CountryMgr();
                    Twee.Model.Country country = countryMgr.GetModel(sCountryID.ToInt());
                    string country_code = country.country;// userMgr.GetCountryCode(userGuid.ToString());
                    if (country_code.Length == 0)
                    {
                        Response.Write("-2");
                        return;
                    }
                    country_code = country_code.ToUpper();

                    //判断这个用户是否是获得 Custom Shipping Fee


                    if (!s_shipTo.Contains(country_code))
                    {
                        Response.Write("-1");
                        return;
                    }
                }
            }
            else
            {
                //用户没有登录 ?GuestCheckout ?

                CookiesHelper cookie = new CookiesHelper();
                string keyAddress = System.Configuration.ConfigurationManager.AppSettings["cookieAddress"].ToString();
                string addressCartGudid = cookie.getCookie(keyAddress);
                if (!string.IsNullOrEmpty(addressCartGudid))
                {
                    PrdMgr prdMgr = new PrdMgr();

                    DataTable dt = prdMgr.GetProductTweebaaRulesExtra(sProId, dic["RulesID"].ToString());
                    //string s_shipTo = dt.Rows[0]["ShipFrom_ShipToCountries"].ToString();// USA,CA
                    string s_shipTo = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        s_shipTo = s_shipTo + dt.Rows[i]["Country_Name"].ToString() + ",";
                    }

                    s_shipTo = s_shipTo.ToUpper();

                    UserMgr userMgr = new UserMgr();
                    UserAddressMgr mgr1 = new UserAddressMgr();
                    DataTable dt1 = mgr1.GetAddressByGuid(addressCartGudid);

                    string sRet = userMgr.CheckCustomShippingFee(sProId, dt1.Rows[0]["address"].ToString(), dt1.Rows[0]["city"].ToString(), dt1.Rows[0]["ProName"].ToString(), dt1.Rows[0]["country"].ToString(), dt1.Rows[0]["zip"].ToString());
                    float flFee = float.Parse(sRet);
                    if (flFee > 0)
                    {

                        Response.Write(sRet);
                        return;
                    }
                    else
                    {   //没有这个用户
                        Twee.Mgr.CountryMgr countryMgr = new CountryMgr();
                        Twee.Model.Country country = countryMgr.GetModel(sCountryID.ToInt());
                        string country_code = country.country;// dt1.Rows[0]["country"].ToString();
                        if ("United States" == country_code) country_code = "USA";

                        if (country_code.Length == 0)
                        {
                            Response.Write("-2");
                            return;
                        }
                        country_code = country_code.ToUpper();

                        //判断这个用户是否是获得 Custom Shipping Fee


                        if (!s_shipTo.Contains(country_code))
                        {
                            Response.Write("-1");
                            return;
                        }
                    }
                }
                else
                {
                    //这应该是用户没有登录，而且在GuestCheckout的时候没有输入地址,应该返回正确
                    // Response.Write("-1");
                }
            }
        }
        private void Check_Shipping_Country_ex()
        {
            string sProId = dic["proId"].ToString();
            string sProsku = dic["prosku"].ToString();

             //用户登录状态添加购物车
            if (userGuid != null)
            {
                //Add by Long for shipping country limit
                PrdMgr prdMgr = new PrdMgr();

                DataTable dt = prdMgr.GetProductTweebaaRulesExtra(sProId, dic["RulesID"].ToString());
                //string s_shipTo = dt.Rows[0]["ShipFrom_ShipToCountries"].ToString();// USA,CA
                string s_shipTo = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    s_shipTo = s_shipTo + dt.Rows[i]["Country_Name"].ToString() + ",";
                }
                s_shipTo = s_shipTo.ToUpper();
                //get user country id
                UserMgr userMgr = new UserMgr();
                UserAddressMgr mgr1 = new UserAddressMgr();
                DataTable dt1 = mgr1.GetMyAddress(userGuid.Value);

                //判断这个用户是否是获得了shipping fee，再次返回的用户
                string sRet = userMgr.CheckCustomShippingFee(sProId, dt1.Rows[0]["address"].ToString(), dt1.Rows[0]["city"].ToString(), dt1.Rows[0]["ProName"].ToString(), dt1.Rows[0]["country"].ToString(), dt1.Rows[0]["zip"].ToString());
                float flFee = float.Parse(sRet);
                if (flFee>0)
                {

                    Response.Write(sRet);
                    return;
                }
                else
                {   //没有这个用户
                    string country_code = userMgr.GetCountryCode(userGuid.ToString());
                    if (country_code.Length == 0)
                    {
                        Response.Write("-2");
                        return;
                    }
                    country_code = country_code.ToUpper();

                    //判断这个用户是否是获得 Custom Shipping Fee


                    if (!s_shipTo.Contains(country_code))
                    {
                        Response.Write("-1");
                        return;
                    }
                }
            }
            else
            {
                //用户没有登录 ?GuestCheckout ?

                CookiesHelper cookie = new CookiesHelper();
                string keyAddress = System.Configuration.ConfigurationManager.AppSettings["cookieAddress"].ToString();
                string addressCartGudid = cookie.getCookie(keyAddress);
                if (!string.IsNullOrEmpty(addressCartGudid))
                {
                    PrdMgr prdMgr = new PrdMgr();

                    DataTable dt = prdMgr.GetProductTweebaaRulesExtra(sProId, dic["RulesID"].ToString());
                    //string s_shipTo = dt.Rows[0]["ShipFrom_ShipToCountries"].ToString();// USA,CA
                    string s_shipTo = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        s_shipTo = s_shipTo + dt.Rows[i]["Country_Name"].ToString() + ",";
                    }

                    s_shipTo = s_shipTo.ToUpper();

                    UserMgr userMgr = new UserMgr();
                    UserAddressMgr mgr1 = new UserAddressMgr();
                    DataTable dt1 = mgr1.GetAddressByGuid(addressCartGudid);

                    string sRet = userMgr.CheckCustomShippingFee(sProId, dt1.Rows[0]["address"].ToString(), dt1.Rows[0]["city"].ToString(), dt1.Rows[0]["ProName"].ToString(), dt1.Rows[0]["country"].ToString(), dt1.Rows[0]["zip"].ToString());
                    float flFee = float.Parse(sRet);
                    if (flFee > 0)
                    {

                        Response.Write(sRet);
                        return;
                    }
                    else
                    {   //没有这个用户
                        string country_code = dt1.Rows[0]["country"].ToString();
                        if ("United States" == country_code) country_code = "USA";

                        if (country_code.Length == 0)
                        {
                            Response.Write("-2");
                            return;
                        }
                        country_code = country_code.ToUpper();

                        //判断这个用户是否是获得 Custom Shipping Fee


                        if (!s_shipTo.Contains(country_code))
                        {
                            Response.Write("-1");
                            return;
                        }
                    }
                }
                else
                {
                    //这应该是用户没有登录，而且在GuestCheckout的时候没有输入地址,应该返回正确
                   // Response.Write("-1");
                }
            }
        }

        private void Check_Shipping_Country()
        {
            string sShipID = dic["shipToId"].ToString();
            string sCountryID = dic["CountryID"].ToString();
            Twee.Mgr.PrdMgr mgr = new PrdMgr();
            if (mgr.Check_Shipping_Country(sShipID, sCountryID))
            {
                Response.Write("1");//成功
            }
            else
            {
                Response.Write("0");//成功
            }
        }
        /// <summary>
        /// 添加到购物车按钮事件
        /// </summary>
        private void AddShopCart()
        {
            try
            {
                string prdID = dic["prdguid"].ToString();//产品id
                string shareUrlId = "";//分享链接的id
                prdID = CommUtil.GetUrlPrdId(prdID, out shareUrlId);
                ShoppingcartMgr mgr = new ShoppingcartMgr();
                Shoppingcart shoppingcart = new Shoppingcart();
                shoppingcart.prdguid = prdID.ToGuid().Value;
                shoppingcart.quantity = dic["quantity"].ToString().ToInt();
                shoppingcart.userguid = userGuid == null ? Guid.Empty : userGuid.Value;
                shoppingcart.edttime = DateTime.Now;
                shoppingcart.ruleid = dic["ruleid"].ToString().ToInt(); //选购产品的规格id

                if (!string.IsNullOrEmpty(shareUrlId))
                {
                    shoppingcart.shareId = shareUrlId.ToGuid().Value;//分享链接的id
                }
                else
                {
                    shoppingcart.shareId = null;
                }

                //用户登录状态添加购物车
                if (userGuid != null)
                {
                    //Add by Long for shipping country limit
                    PrdMgr prdMgr = new PrdMgr();
                    /* modify by Long 2016/01/20 as Shipping Can be different country
                    DataTable dt = prdMgr.GetProductTweebaaRulesExtra(prdID, dic["ruleid"].ToString());
                    string s_shipTo = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        s_shipTo = s_shipTo + dt.Rows[i]["Country_Name"].ToString() + ",";
                    }
                    //string s_shipTo = dt.Rows[0]["ShipFrom_ShipToCountries"].ToString();// USA,CA

                    s_shipTo = s_shipTo.ToUpper();
                     * */
                    //get user country id
                    UserMgr userMgr=new UserMgr();
                    UserAddressMgr mgr1 = new UserAddressMgr();
                    DataTable dt1 = mgr1.GetMyAddress(userGuid.Value);

                    //判断这个用户是否是获得了shipping fee，再次返回的用户
                    /*
                    float flFee = 0.0f;
                    if (dt1.Rows.Count > 0)
                    {
                        string sRet = userMgr.CheckCustomShippingFee(prdID, dt1.Rows[0]["address"].ToString(), dt1.Rows[0]["city"].ToString(), dt1.Rows[0]["ProName"].ToString(), dt1.Rows[0]["country"].ToString(), dt1.Rows[0]["zip"].ToString());
                        flFee=float.Parse(sRet);
                    }
                    if (flFee > 0)
                    {
                        

                    }
                    else
                    {
                        //没有这个用户
                        string country_code = userMgr.GetCountryCode(userGuid.ToString());
                        if (country_code.Length == 0)
                        {
                            Response.Write("10");
                            return;
                        }
                        country_code = country_code.ToUpper();

                        //判断这个用户是否是获得 Custom Shipping Fee


                        if (!s_shipTo.Contains(country_code))
                        {
                            Response.Write("9");
                            return;
                        }
                    }
                     * */
                    //



                    string cartGuid = mgr.CheckIsInChart(userGuid.ToString(), prdID, shoppingcart.ruleid.Value);
                    if (!string.IsNullOrEmpty(cartGuid))
                    {
                        //该产品在购物车已经存在，改变其数量
                        bool resu = mgr.AddShoupCartNum(cartGuid, dic["quantity"].ToString().ToInt());
                        if (resu)
                        {
                            Response.Write("1");
                            return;
                        }
                        Response.Write("0");
                        return;
                    }
                    else
                    {
                        //该产品在购物车不存在， 插入数据                      
                        bool b = mgr.Add(shoppingcart);
                        if (b)
                        {
                            Response.Write("1");//成功
                            return;
                        }
                        Response.Write("0");//失败
                    }
                }
                else
                {
                    //用户没有登录
                    CookiesHelper cookie = new CookiesHelper();
                    string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                    string shopCartCookie = cookie.getCookie(keyShopCart);
                    //string cartIDs=shopCartCookie.spl
                    //根据购物车cookie id和 prdid判断是否产品已经在未登录购物车存在
                    if (!string.IsNullOrEmpty(shopCartCookie))
                    {
                        string dataCartGuid = mgr.CheckIsInChartNotLogin(shopCartCookie, shoppingcart.prdguid.ToString(), (int)shoppingcart.ruleid);
                       if (!string.IsNullOrEmpty(dataCartGuid))
                       {
                           bool resu = mgr.AddShoupCartNum(dataCartGuid, dic["quantity"].ToString().ToInt());
                           if (resu)
                           {
                               Response.Write("1");//成功
                               return;
                           }
                           Response.Write("0");
                       }
                       else
                       {
                           string cartGuid = string.Empty;
                           bool b = mgr.Add(shoppingcart, out cartGuid);
                           if (b)
                           {
                               string shopCartValue = "";
                               if (string.IsNullOrEmpty(shopCartCookie))
                               {
                                   //shopCartValue = "[{'prdid':'" + prdID + "','ruleid':'" + dic["ruleid"].ToString() + "'}]";
                                   shopCartValue = "'" + cartGuid + "'";
                               }
                               else
                               {
                                   shopCartValue = shopCartCookie + ",'" + cartGuid + "'";
                               }
                               if (cookie.createCookie(keyShopCart, shopCartValue, 7))
                               {
                                   Response.Write("1");//成功
                                   return;
                               }
                               Response.Write("0");
                           }
                           Response.Write("0");
                       }
                      
                    }
                    else
                    {
                        string cartGuid = string.Empty;
                        bool b = mgr.Add(shoppingcart, out cartGuid);
                        if (b)
                        {
                            string shopCartValue = "";
                            if (string.IsNullOrEmpty(shopCartCookie))
                            {
                                //shopCartValue = "[{'prdid':'" + prdID + "','ruleid':'" + dic["ruleid"].ToString() + "'}]";
                                shopCartValue = "'" + cartGuid + "'";
                            }
                            else
                            {
                                shopCartValue = shopCartCookie + ",'" + cartGuid + "'";
                            }
                            if (cookie.createCookie(keyShopCart, shopCartValue, 7))
                            {
                                Response.Write("1");//成功
                                return;
                            }
                            Response.Write("0");
                        }
                        Response.Write("0");
                    }              
                }
            }
            catch (Exception e)
            {
                Response.Write("0");
                Twee.Comm.CommUtil.GenernalErrorHandler(e);
            }

        }

        /// <summary>
        /// 立即购买按钮事件,先添加到购物车，然后跳转到结算页面
        /// </summary>
        private void AddShopCartPaynow()
        {
            try
            {
                if (dic["ruleid"].ToString() == "")
                {
                    Response.Write("-2");
                    return;
                }
                string prdID = dic["prdguid"].ToString();//产品id
                string shareUrlId = "";//分享链接的id
                prdID = CommUtil.GetUrlPrdId(prdID, out shareUrlId);

                ShoppingcartMgr mgr = new ShoppingcartMgr();
                Shoppingcart shoppingcart = new Shoppingcart();
                shoppingcart.prdguid = prdID.ToGuid().Value;
                shoppingcart.quantity = dic["quantity"].ToString().ToInt();
                shoppingcart.userguid = userGuid.Value;
                shoppingcart.edttime = DateTime.Now;
                shoppingcart.ruleid = dic["ruleid"].ToString().ToInt(); ;//选购产品的规格id
                if (!string.IsNullOrEmpty(shareUrlId))
                {
                    shoppingcart.shareId = shareUrlId.ToGuid().Value;//分享链接的id
                }
                else
                {
                    shoppingcart.shareId = null;
                }
                string cartGuid = "";
                bool b = mgr.Add(shoppingcart, out cartGuid);
                Response.Write(cartGuid);
            }
            catch (Exception)
            {
                Response.Write("0");
            }

        }

        /// <summary>
        /// 单个删除购物车
        /// </summary>
        private void DeletShopCart()
        {
            try
            {
                ShoppingcartMgr mgr = new ShoppingcartMgr();
                Shoppingcart shoppingcart = new Shoppingcart();
                Guid cartGuid = dic["cartGuid"].ToString().ToGuid().Value;
                shoppingcart.edttime = DateTime.Now;
                bool b = mgr.Delete(cartGuid);
                if (b)
                {
                    CookiesHelper cookie = new CookiesHelper();
                    string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                    string shopCartCookie = cookie.getCookie(keyShopCart);
                    if (!string.IsNullOrEmpty(shopCartCookie))
                    {
                        List<string> ids = shopCartCookie.Split(',').ToList<String>();
                        ids.Remove("'" + cartGuid.ToString() + "'");
                        string newStr = string.Empty;
                        foreach (var id in ids)
                        {
                            newStr +=  id + ",";
                        }
                        cookie.createCookie(keyShopCart, newStr.TrimEnd(','), 7);
                        
                    }                   
                    Response.Write("1");//成功
                    return;
                }
                Response.Write("0");//失败
            }
            catch (Exception)
            {
                Response.Write("0");
            }

        }

        /// <summary>
        /// 批量删除购物车
        /// </summary>
        private void DeletShopCartList()
        {
            try
            {
                ShoppingcartMgr mgr = new ShoppingcartMgr();
                Shoppingcart shoppingcart = new Shoppingcart();
                string cartGuids = "'" + dic["cartGuid"].ToString().Replace(",", "','") + "'";
                bool b = mgr.DeleteList(cartGuids);
                if (b)
                {
                    Response.Write("1");//成功
                    return;
                }
                Response.Write("0");//失败
            }
            catch (Exception)
            {
                Response.Write("0");
            }

        }

        /// <summary>
        /// 查询购物车
        /// </summary>
        private void QueryShopCart()
        {
            string shopCart = string.Empty;
            if (dic.Keys.Contains("cartids") == true && dic["cartids"].ToString() != "undefined"&&dic["cartids"].ToString() != "")
            {
                //shopCart = CommHelper.GetStrDecode(dic["cartids"].ToString());
                shopCart = "";
            }
            else
            {
                CookiesHelper cookie = new CookiesHelper();
                string keyShopCart = System.Configuration.ConfigurationManager.AppSettings["cookieShopCart"].ToString();
                shopCart = cookie.getCookie(keyShopCart);
            }
            QueryByCartIds(shopCart, userGuid);
            return;
            
            //string state = dic["state"].ToNullString();
            //ShoppingcartMgr mgr = new ShoppingcartMgr();
            //Shoppingcart shoppingcart = new Shoppingcart();
            //DataTable dt = mgr.GetMyShopCart(state, userGuid.Value);
            //if (dt == null || dt.Rows.Count == 0)
            //{
            //    Response.Write("");
            //    return;
            //}            
            //string prdInfo = JsonConvert.SerializeObject(dt);
            //Response.Write(prdInfo);

        }
        /// <summary>
        /// 根据购物车选择要结算的商品的 cartid查询
        /// </summary>
        /// <param name="cartids"></param>
        private void QueryByCartIds(string cartids,Guid? userGuid)
        {
            ShoppingcartMgr mgr = new ShoppingcartMgr();
            DataTable dt = mgr.GetMyCheckedShopCart(cartids, userGuid);
            if (dt == null || dt.Rows.Count == 0)
            {
                Response.Write("");
                return;
            }
            //List<Shoppingcart> listShoppingcart = mgr.DataTableToList2(dt);
            string prdInfo = JsonConvert.SerializeObject(dt);
            Response.Write(prdInfo);

        }

        /// <summary>
        /// 修改购物车数量
        /// </summary>
        private void AddNum()
        {
            if (dic.Keys.Contains("guid") == true && dic["guid"].ToString() != "" && dic.Keys.Contains("number") == true && dic["number"].ToString() != "")
            {
                ShoppingcartMgr mgr = new ShoppingcartMgr();
                bool b = mgr.UpdateShoupCartNum(dic["guid"].ToString(), dic["number"].ToString().ToInt());
                if (b)
                {
                    Response.Write("1");
                    return;
                }
                Response.Write("0");
            }
        }

        /// <summary>
        /// query shipping fee by weight 
        /// <param name="cartids"></param>
        private void QueryShipFeeListByWeight()
        {
            if (dic.Keys.Contains("weight") != true || dic["weight"].ToString() == "" ||
                dic.Keys.Contains("countryid") != true || dic["countryid"].ToString() == "" ||
                dic.Keys.Contains("zip") != true || dic["zip"].ToString() == "" )
            {
                Response.Write("0");
                return;
            }

            string sWeight = dic["weight"].ToString();
            string sCountryID = dic["countryid"].ToString();
            string sZip = dic["zip"].ToString();

            ShoppingcartMgr mgr = new ShoppingcartMgr();
            DataTable dt = mgr.GetShipFeeListByWeight(sWeight, sCountryID, sZip);
            if (dt == null || dt.Rows.Count == 0)
            {
                Response.Write("0");
                return;
            }
            string shipFeeInfo = JsonConvert.SerializeObject(dt);
            Response.Write(shipFeeInfo);

        }

        /// <summary>
        /// query drop-shipper shipping fee list 
        /// <param name=""></param>
        private void QueryDropShipperShipFeeList()
        {
            if (dic.Keys.Contains("countryid") != true || dic["countryid"].ToString() == "" ||
                dic.Keys.Contains("totalprice") != true || dic["totalprice"].ToString() == "" ||
                dic.Keys.Contains("shipfromid") != true || dic["shipfromid"].ToString() == "")
            {
                Response.Write("0");
                return;
            }

            string sCountryID = dic["countryid"].ToString();
            string sTotalPrice = dic["totalprice"].ToString();
            int iShipFromID = dic["shipfromid"].ToString().ToInt();

            ShoppingcartMgr mgr = new ShoppingcartMgr();
            DataTable dt = mgr.GetDropShipperShipFeeList(sCountryID, sTotalPrice, iShipFromID);
            if (dt == null || dt.Rows.Count == 0)
            {
                Response.Write("0");
                return;
            }
            string shipFeeInfo = JsonConvert.SerializeObject(dt);
            Response.Write(shipFeeInfo);
        }

        /// <summary>
        /// query drop-shipper flat shipping fee 
        /// <param name=""></param>
        private void QueryDropShipperFlatShipFee()
        {
            if (dic.Keys.Contains("countryid") != true || dic["countryid"].ToString() == "" ||
                dic.Keys.Contains("totalprice") != true || dic["totalprice"].ToString() == "" )
            {
                Response.Write("0");
                return;
            }

            string sCountryID = dic["countryid"].ToString();
            string sTotalPrice = dic["totalprice"].ToString();
 
            ShoppingcartMgr mgr = new ShoppingcartMgr();
            decimal  dFlatShipFee = mgr.GetDropShipperFlatShipFee(sCountryID, sTotalPrice);
            Response.Write(dFlatShipFee.ToString("#0.00"));
        }

        /// <summary>
        /// query product ship to country free 
        /// <param name=""></param>
        private void QueryProductShipToCountryFree()
        {
            if (dic.Keys.Contains("countryid") != true || dic["countryid"].ToString() == "" ||
                dic.Keys.Contains("ruleid") != true || dic["ruleid"].ToString() == "")
            {
                Response.Write("0");
                return;
            }

            int iCountryID = int.Parse(dic["countryid"].ToString());
            int iRuleID = int.Parse(dic["ruleid"].ToString());

            ShoppingcartMgr mgr = new ShoppingcartMgr();

            // iFree  1:Free shipping to the country  0: not free shipping 
            int iFree = mgr.GetProductShipToCountryFree(iCountryID, iRuleID);
            Response.Write(iFree.ToString());
        }


       

        /// <summary>
        /// Get Province Tax 
        /// <summary>
        private void GetProvinceTax()
        {
            if (dic.Keys.Contains("countryid") != true || dic["countryid"].ToString() == "" ||
                dic.Keys.Contains("provinceid") != true || dic["provinceid"].ToString() == "")
            {
                Response.Write("0");
                return;
            }

            string sCountryID = dic["countryid"].ToString();
            string sProvinceID = dic["provinceid"].ToString();

            ShoppingcartMgr mgr = new ShoppingcartMgr();
            DataTable dt = mgr.GetProvinceTax(sCountryID, sProvinceID);
            if (dt == null || dt.Rows.Count == 0)
            {
                Response.Write("0");
                return;
            }
            string taxInfo = JsonConvert.SerializeObject(dt);
            Response.Write(taxInfo);
        }

        /// <summary>
        /// Set ship method of a product in a shopping cart 
        /// <summary>
        private void SetShipMethod()
        {
 
            if (dic.Keys.Contains("cartid") != true || dic["cartid"].ToString() == "")
            {
                Response.Write("");
                return;
            }
            if (dic.Keys.Contains("prdid") != true || dic["prdid"].ToString() == "")
            {
                Response.Write("");
                return;
            }
            if (dic.Keys.Contains("shipmethodid") != true || dic["shipmethodid"].ToString() == "")
            {
                Response.Write("");
                return;
            }
            if (dic.Keys.Contains("shipfee") != true || dic["shipfee"].ToString() == "")
            {
                Response.Write("");
                return;
            }

            string sCartID = dic["cartid"].ToString();
            string sPrdID = dic["prdid"].ToString();
            int iShipMethodID = dic["shipmethodid"].ToString().ToInt();
            string sShipFee = dic["shipfee"].ToString();

            ShoppingcartMgr mgr = new ShoppingcartMgr();
            bool bOK = mgr.SetShipMethod(sCartID, sPrdID, iShipMethodID, sShipFee);
            if (bOK)
            {
                Response.Write("1");
                return;
            }
            Response.Write("0");
        }
    }
}