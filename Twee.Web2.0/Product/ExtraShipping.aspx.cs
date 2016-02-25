using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Mgr;
using Twee.Comm;

namespace TweebaaWebApp2.Product
{
    public partial class ExtraShipping : TweebaaWebApp2.MasterPages.BasePage
    {
        public string lblProductName;
        public string lblShippingAddr;
        public string _divForm="block";
        public string _divMessage = "none";
        public string lblProductID = "";
       // public string lblUserID = "";
        public string lblSKU;
        private Guid? userGuid;
        protected void Page_Load(object sender, EventArgs e)
        {
            //?proid=" + proid + "&sku="+sku+ "&userid=" + userGuid;
            if (!IsPostBack)
            {
                bool isLogion = CheckLogion(out userGuid);
                if (string.IsNullOrEmpty(Request["action"]))
                {
                    //This is redirect from other page
                    lblProductID = Request["proid"].ToString();
                    lblSKU = Request["sku"].ToString();

                    Twee.Mgr.PrdMgr mgr=new Twee.Mgr.PrdMgr();
                    DataSet ds = mgr.GetList("prdGuid='" + lblProductID+"'");
                    DataTable dt = ds.Tables[0];
                    lblProductName = dt.Rows[0]["name"].ToString();
                    //get user address
                    UserAddressMgr mgr1 = new UserAddressMgr();
                    DataTable dt1 = null;
                    if (userGuid != null)
                    {
                        //List<Useraddress> listData = mgr.GetModelList(" userguid='"+userGuid+"'");
                        //DataTable dt = mgr.GetList(" userguid='" + userGuid + "'").Tables[0];       
                        dt1 = mgr1.GetMyAddress(userGuid.Value);

                    }
                    else
                    {
                        CookiesHelper cookie = new CookiesHelper();
                        string keyAddress = System.Configuration.ConfigurationManager.AppSettings["cookieAddress"].ToString();
                        string addressCartGudid = cookie.getCookie(keyAddress);
                        if (!string.IsNullOrEmpty(addressCartGudid))
                        {
                            dt1 = mgr1.GetAddressByGuid(addressCartGudid);
                        }
                    }

                    //$("#labName").text(address.username);

                    string sUserName = dt1.Rows[0]["username"].ToString();
                    if (dt1.Rows[0]["lastName"] != null) sUserName = sUserName + " " + dt1.Rows[0]["lastName"].ToString();
                    //$("#labName").text(sUserName);

                    string sUserAddress = dt1.Rows[0]["address"].ToString();
                    if (dt1.Rows[0]["address2"] != null) sUserAddress = sUserAddress + " " + dt1.Rows[0]["address2"];

                    lblShippingAddr = sUserName + "<br>" + sUserAddress + dt1.Rows[0]["city"].ToString() + " , " + dt1.Rows[0]["ProName"].ToString() + " " + dt1.Rows[0]["country"].ToString() + " " + dt1.Rows[0]["zip"].ToString() +
                    "<br>"+"Tel: "+dt1.Rows[0]["tel"].ToString();

                    if (dt1.Rows[0]["email"] == null || dt1.Rows[0]["email"].ToString() == "") {
                       /// $("#labEmail").hide();
                    }
                    else {
                       // $("#labEmail").text(address.email);
                        lblShippingAddr =lblShippingAddr+"<br>E-mail: "+ dt1.Rows[0]["email"].ToString();
                    }
                }
                else
                {
                    /*
<input type="hidden" value="<%=lblProductID %>" name="lblProductID" />
<input type="hidden" value="<%=lblUserID %>" name="lblUserID" />
<input type="hidden" value="<%=lblShippingAddr %>" name="lblShippingAddr" />
<input type="hidden" value="<%=lblSKU %>" name="lblSKU" />*/

                    lblProductID = Request.Form["lblProductID"].ToString();
                    //lblUserID = Request.Form["lblUserID"].ToString();
                    lblShippingAddr = Request.Form["lblShippingAddr"].ToString();
                    lblSKU = Request.Form["lblSKU"].ToString();

                    string sTitle = "Shipping Fee Inquiry";
                    string sBody = "Prdouct Link:https://www.tweebaa.com/Product/saleBuy.aspx?id=" + lblProductID +"<br /> "+ Environment.NewLine;
                    sBody = sBody + " SKU#:" + lblSKU + "<br /> " + Environment.NewLine;
                    sBody = sBody + " Shipping Address:" + lblShippingAddr + "<br /> " + Environment.NewLine;

                    Twee.Comm.Mailhelper.SendMail(sTitle, sBody, "service@tweebaa.com");
                    _divForm = "none";
                     _divMessage = "block";
                }
            }
        }
    }
}