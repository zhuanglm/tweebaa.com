using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TweebaaWebApp2.Product
{
    public partial class ShopIndex : System.Web.UI.Page
    {
        public string strHTML_Featured = "";
        public string strHTML_Latest = "";
        public string strHTML_FreeShipping = "";
        public string strHTML_TestSale = "";
        public string strHTML_InventorShop = "";
       // public string strHTML_OurBrand = "";
        /*
         * Inventor
         * Attipas
CamoBands
Coverplug
JacketRackit
JustForKiix
Knucklestrutz
Risegear
Zippys
Icerays
         */
        protected void Page_Load(object sender, EventArgs e)
        {


            //Read from cache
            Twee.Comm.XMLCache cache = new Twee.Comm.XMLCache();
            string strDay = cache.GetMonthString();
            if (cache.IsHTMLFileExists("ShopIndex_1_" + strDay))
            {
                strHTML_Featured = cache.ReadCacheHTML("ShopIndex_1_" + strDay);
                strHTML_Latest = cache.ReadCacheHTML("ShopIndex_2_" + strDay);
                strHTML_FreeShipping= cache.ReadCacheHTML("ShopIndex_3_" + strDay);
                strHTML_TestSale= cache.ReadCacheHTML("ShopIndex_4_" + strDay);
                strHTML_InventorShop= cache.ReadCacheHTML("ShopIndex_5_" + strDay);
               // strHTML_OurBrand = cache.ReadCacheHTML("ShopIndex_6_" + strDay);
            }
            else
            {
                //create the HTML
                Twee.Mgr.PrdMgr mgr=new Twee.Mgr.PrdMgr();
                DataTable dt1 = mgr.GetShopIndexData1();
                //string strHTML1 = "";
                CreateHtml(dt1,1);
                DataTable dt2 = mgr.GetShopIndexData2();
                //string strHTML1 = "";
                CreateHtml(dt2,2);
                DataTable dt3 = mgr.GetShopIndexData3();
                //string strHTML1 = "";
                CreateHtml(dt3,3);
                DataTable dt4 = mgr.GetShopIndexData4();
                //string strHTML1 = "";
                CreateHtml(dt4,4);
                DataTable dt5 = mgr.GetShopIndexData5();
                //string strHTML1 = "";
                CreateHtml(dt5,5);
                /*
                    string[] brandURL = { "saleBuy.aspx?id=670bdf26-a935-4643-ac0e-ba24c2249107", "presaleBuy.aspx?id=3e0dfa46-2dc2-4622-bd9f-0139aebbb875", 
                                            "presaleBuy.aspx?id=b43ddcc8-d233-4d2e-aba1-28b5b6189c48", "saleBuy.aspx?id=3d7aeec0-5ece-4fad-975c-a58ef9464af1", 
                                            "presaleBuy.aspx?id=7ed21a8d-67cf-43e8-b667-f857d80cc434", "saleBuy.aspx?id=2e43ae47-8e7d-4696-aac6-2cfee5af99a5" };
                    string[] brandIMG = {"07.png","08.png","09.png","10.png","11.png","12.png"};

                    for (int i = 0; i < brandURL.Length; i++)
                    {
                        strHTML_OurBrand = strHTML_OurBrand + "<li class=\"item first-child\">";
                        strHTML_OurBrand = strHTML_OurBrand + "<a href=\"/Product/" + brandURL[i] + "\"><img src=\"/images/clients/" + brandIMG[i] + "\" alt=\"\"></a>";
                        strHTML_OurBrand = strHTML_OurBrand + "</li>";
                    }*/
                    cache.WriteCahceHTML(strHTML_Featured, "ShopIndex_1_" + strDay);
                    cache.WriteCahceHTML(strHTML_Latest, "ShopIndex_2_" + strDay);
                    cache.WriteCahceHTML(strHTML_FreeShipping, "ShopIndex_3_" + strDay);
                    cache.WriteCahceHTML(strHTML_TestSale, "ShopIndex_4_" + strDay);
                    cache.WriteCahceHTML(strHTML_InventorShop, "ShopIndex_5_" + strDay);
                   // cache.WriteCahceHTML(strHTML_OurBrand, "ShopIndex_6_" + strDay);
                }
                 
            }

        private void CreateHtml(DataTable dt,int iFlag){
            string sURL = "";
            string sImg = "";
            string sPrdName = "";
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                   // int iFlag = int.Parse(dr["flag"].ToString());
                    sImg = "http://tweebaa.com/" + dr["fileurl"].ToString().Replace("/big/", "/mid/");
                    string favoriteClassID = "favoriteClass" + i.ToString();
                    float flMinSalePrice = float.Parse(dr["minfinalsaleprice"].ToString());
                    float flEstimateprice = float.Parse(dr["estimateprice"].ToString());

                    string favoriteFunc = "FavoritePrdOnOff('" + dr["prdGuid"].ToString() + "', '#" + favoriteClassID + "')";
                    int iRewardPoint = Twee.Comm.CommUtil.getExtraShoppingRewardPoint(flMinSalePrice);
                    string shareText = iRewardPoint.ToString();
                    string strShortDesc = dr["txtjj"].ToString();
                    strShortDesc = Twee.Comm.CommUtil.GetShortDesc(strShortDesc);
                    strShortDesc = HttpUtility.UrlPathEncode(strShortDesc);
                    strShortDesc = strShortDesc.Replace("\"", "&quot;");

                    //Featured Products
                    string strPreSaleInfo = "";
                    if (dr["wnstat"].ToString() == "2")
                    {
                        string saleCount = string.IsNullOrEmpty(dr["saleCount"].ToString()) ? "0" : dr["saleCount"].ToString();
                        sURL = "/Product/presaleBuy.aspx?id=" + dr["prdGuid"].ToString();
                        var testSaleProgress = (int.Parse(saleCount) / int.Parse(dr["presaleforward"].ToString())) * 100;
                        if (testSaleProgress < 1) testSaleProgress = 1;
                        if (testSaleProgress > 100) testSaleProgress = 100;
                        var testSaleLeftCount = int.Parse(dr["presaleforward"].ToString()) - int.Parse(saleCount);
                        string saleTime = dr["presaleendtime"].ToString();
                        int time = 0;
                        if (!string.IsNullOrEmpty(saleTime))
                        {
                            DateTime d1 = DateTime.Now;
                            DateTime d2 = DateTime.Parse(saleTime);
                            time= (d2 - d1).Days;
                            
                        }
                        // left days
                        var leftDays = "";
                        if (time <= 0) leftDays = " Time Over";
                        else leftDays = " Days left: " + time;

                        strPreSaleInfo = strPreSaleInfo + "<span class=\"time\"><i class=\"fa fa-clock-o\"></i> " + leftDays + "</span>";
                        strPreSaleInfo = strPreSaleInfo + "  <div class=\"progress progress-u progress-xxs\">";
                        strPreSaleInfo = strPreSaleInfo + "    <div class=\"progress-bar progress-bar-dark\" role=\"progressbar\" aria-valuenow=\"" + testSaleProgress + "\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: " + testSaleProgress + "%\">";
                        strPreSaleInfo = strPreSaleInfo + "    </div>";
                        strPreSaleInfo = strPreSaleInfo + "  </div>";
                        strPreSaleInfo = strPreSaleInfo + "  <h3 class=\"heading-xs\">Test-Sale  ";
                        strPreSaleInfo = strPreSaleInfo + "<span class=\"pull-right\">Units left: " + testSaleLeftCount + "</span></h3>";
                    }
                    else
                    {
                        sURL = "/Product/saleBuy.aspx?id=" + dr["prdGuid"].ToString();
                    }
                    string strReadMore = Twee.Comm.CommUtil.GetShortDesc(dr["txtjj"].ToString()) +"...Read more";
                    if (iFlag == 1)
                    {
                        sPrdName = dr["name"].ToString();
                        
                        strHTML_Featured = strHTML_Featured + "<li class=\"item\">";
                        strHTML_Featured = strHTML_Featured + "<div class=\"product-img product-img-brd\">";
                        strHTML_Featured = strHTML_Featured + "<a href=\"" + sURL + "\"><img class=\"full-width img-responsive\" src=\"" + sImg + "\"></a>";
                        strHTML_Featured = strHTML_Featured + "<span class=\"add-to-cart\">";
                        strHTML_Featured = strHTML_Featured + "<a href=\"" + sURL + "\"><i class=\"icon-custom rounded-x fa fa-shopping-cart\"></i></a>";
                        strHTML_Featured = strHTML_Featured + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\"></i> </a>";
                        strHTML_Featured = strHTML_Featured + "<a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\" ><i class=\"icon-custom rounded-x fa fa-share-alt\"></i></a>";
                        //strHTML_Featured=strHTML_Featured+"<div class=\"promotion\"><span class=\"new-product\"> NEW</span> <span class=\"discount\">15% OFF</span></div>";
                        strHTML_Featured = strHTML_Featured + "</span>";
                        strHTML_Featured = strHTML_Featured + "</div>";
                        strHTML_Featured = strHTML_Featured + "<div class=\"product-description product-description-brd margin-bottom-30\">";
                        strHTML_Featured = strHTML_Featured + "<div class=\"overflow-h\">";
                        strHTML_Featured = strHTML_Featured + "<div class=\"margin-bottom-10\">";
                        strHTML_Featured = strHTML_Featured + "<h4 class=\"title-price shop-price\"><a href=\"" + sURL + "\">" + dr["name"].ToString() + "</a></h4>";
                        strHTML_Featured = strHTML_Featured + "</div>";
                        //strHTML_Featured = strHTML_Featured + "<span class=\"gender\"><a href=\"" + sURL + "\">" + strReadMore + "</a></span></div>";
                        if (flMinSalePrice != flEstimateprice)
                        {
                            strHTML_Featured = strHTML_Featured + "<div class=\"product-price margin-bottom-5\"><span class=\"title-price-shop\">$" + flMinSalePrice.ToString("0.00") + "</span> <span class=\"title-price line-through\">$" + flEstimateprice.ToString("0.00") + "</span>";
                        }
                        else
                        {
                            strHTML_Featured = strHTML_Featured + "<div class=\"product-price margin-bottom-5\"><span class=\"title-price-shop\">$" + flMinSalePrice.ToString("0.00") + "</span>";

                        }
                        if (dr["wnstat"].ToString() == "2")
                        {
                            strHTML_Featured = strHTML_Featured + strPreSaleInfo;
                        }
                        strHTML_Featured = strHTML_Featured + "</div>";
                        /*
                        strHTML_Featured=strHTML_Featured+"<ul class=\"list-inline product-ratings\">";
                        strHTML_Featured=strHTML_Featured+"<li><i class=\"rating-selected fa fa-star\"></i></li>";
                        strHTML_Featured=strHTML_Featured+"<li><i class=\"rating-selected fa fa-star\"></i></li>";
                        strHTML_Featured=strHTML_Featured+"<li><i class=\"rating-selected fa fa-star\"></i></li>";
                        strHTML_Featured=strHTML_Featured+"<li><i class=\"rating fa fa-star\"></i></li>";
                        strHTML_Featured=strHTML_Featured+"<li><i class=\"rating fa fa-star\"></i></li>";
                        strHTML_Featured=strHTML_Featured+"<li class=\"like-icon\"><a href=\"#\"><i class=\"fa fa-shopping-cart icon-mds\"></i></a></li>";
                        strHTML_Featured=strHTML_Featured+"</ul>"; */
                        strHTML_Featured = strHTML_Featured + "</div>";
                        strHTML_Featured = strHTML_Featured + "</div>";
                        strHTML_Featured = strHTML_Featured + "</li>";
                    }

                    //Latest Products
                    if (iFlag == 2)
                    {
                       // sURL = "/Product/SaleBuy.aspx?id=" + HttpUtility.UrlPathEncode(dr["prdGuid"].ToString());
                        strHTML_Latest = strHTML_Latest + "<li class=\"item\">";
                        strHTML_Latest = strHTML_Latest + "<div class=\"product-img product-img-brd\">";
                        strHTML_Latest = strHTML_Latest + "<a href=\"" + sURL + "\"><img class=\"full-width img-responsive\" src=\"" + sImg + "\"></a>";
                        strHTML_Latest = strHTML_Latest + "<span class=\"add-to-cart\">";
                        strHTML_Latest = strHTML_Latest + "<a href=\"" + sURL + "\"><i class=\"icon-custom rounded-x fa fa-shopping-cart\"></i></a>";
                        strHTML_Latest = strHTML_Latest + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\"></i> </a>";
                        strHTML_Latest = strHTML_Latest + "<a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\" ><i class=\"icon-custom rounded-x fa fa-share-alt\"></i></a>";
                        //strHTML_Latest=strHTML_Latest+"<div class=\"promotion\"><span class=\"new-product\"> NEW</span> <span class=\"discount\">15% OFF</span></div>";
                        strHTML_Latest = strHTML_Latest + "</span>";
                        strHTML_Latest = strHTML_Latest + "</div>";
                        strHTML_Latest = strHTML_Latest + "<div class=\"product-description product-description-brd margin-bottom-30\">";
                        strHTML_Latest = strHTML_Latest + "<div class=\"overflow-h\">";
                        strHTML_Latest = strHTML_Latest + "<div class=\"margin-bottom-10\">";
                        strHTML_Latest = strHTML_Latest + "<h4 class=\"title-price shop-price\"><a href=\"" + sURL + "\">" + dr["name"].ToString() + "</a></h4>";
                         strHTML_Latest = strHTML_Latest + "</div>";
                       // strHTML_Latest = strHTML_Latest + "<span class=\"gender\"><a href=\"" + sURL + "\">" + strReadMore + "</a></span></div>";
                        if (flMinSalePrice != flEstimateprice)
                        {
                            strHTML_Latest = strHTML_Latest + "<div class=\"product-price margin-bottom-5\"><span class=\"title-price-shop\">$" + flMinSalePrice.ToString("0.00") + "</span> <span class=\"title-price line-through\">$" + flEstimateprice.ToString("0.00") + "</span>";
                        }
                        else
                        {
                            strHTML_Latest = strHTML_Latest + "<div class=\"product-price margin-bottom-5\"><span class=\"title-price-shop\">$" + flMinSalePrice.ToString("0.00") + "</span>";

                        }
                        if (dr["wnstat"].ToString() == "2")
                        {
                            strHTML_Latest = strHTML_Latest + strPreSaleInfo;
                        }
                        strHTML_Latest = strHTML_Latest + "</div>";
                        /*
                        strHTML_Latest=strHTML_Latest+"<ul class=\"list-inline product-ratings\">";
                        strHTML_Latest=strHTML_Latest+"<li><i class=\"rating-selected fa fa-star\"></i></li>";
                        strHTML_Latest=strHTML_Latest+"<li><i class=\"rating-selected fa fa-star\"></i></li>";
                        strHTML_Latest=strHTML_Latest+"<li><i class=\"rating-selected fa fa-star\"></i></li>";
                        strHTML_Latest=strHTML_Latest+"<li><i class=\"rating fa fa-star\"></i></li>";
                        strHTML_Latest=strHTML_Latest+"<li><i class=\"rating fa fa-star\"></i></li>";
                        strHTML_Latest=strHTML_Latest+"<li class=\"like-icon\"><a href=\"#\"><i class=\"fa fa-shopping-cart icon-mds\"></i></a></li>";
                        strHTML_Latest=strHTML_Latest+"</ul>"; */
                        strHTML_Latest = strHTML_Latest + "</div>";
                        strHTML_Latest = strHTML_Latest + "</div>";
                        strHTML_Latest = strHTML_Latest + "</li>";
                    }
                    if (iFlag == 3) //Free Shipping
                    {
                       // sURL = "/Product/SaleBuy.aspx?id=" + HttpUtility.UrlPathEncode(dr["prdGuid"].ToString());
                        strHTML_FreeShipping = strHTML_FreeShipping + "<div class=\"thumb-product\">";
                        strHTML_FreeShipping = strHTML_FreeShipping + "<a href=\"" + sURL + "\"><img class=\"thumb-product-img\" src=\"" + sImg + "\" alt=\"\"></a>";
                        strHTML_FreeShipping = strHTML_FreeShipping + "<div class=\"thumb-product-in\">";
                        strHTML_FreeShipping = strHTML_FreeShipping + "<h4><a href=\"" + sURL + "\">" + dr["name"].ToString() + "</a></h4>";
                        //strHTML_FreeShipping = strHTML_FreeShipping + "<span class=\"thumb-product-type\">Footwear - Oxfords</span>";
                        strHTML_FreeShipping = strHTML_FreeShipping + "</div>";
                        strHTML_FreeShipping = strHTML_FreeShipping + "<ul class=\"list-inline overflow-h\">";
                        if (flMinSalePrice != flEstimateprice)
                        {
                            strHTML_FreeShipping = strHTML_FreeShipping + "<li class=\"thumb-product-price line-through\">$" + flEstimateprice.ToString("0.00") + "</li>";
                        }
                        strHTML_FreeShipping = strHTML_FreeShipping + "<li class=\"thumb-product-price\">$" + flMinSalePrice.ToString("0.00") + "</li>";

                        strHTML_FreeShipping = strHTML_FreeShipping + "<li class=\"thumb-product-purchase\"><a href=\"" + sURL + "\"><i class=\"fa fa-shopping-cart\"></i></a> | <a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"fa fa-heart-o\"></i> </a></li>";
                        strHTML_FreeShipping = strHTML_FreeShipping + "</ul>";
                        strHTML_FreeShipping = strHTML_FreeShipping + "</div>";
                    }

                    if (iFlag == 4) //Test Sale
                    {
                       // sURL = "/Product/preSaleBuy.aspx?id=" + HttpUtility.UrlPathEncode(dr["prdGuid"].ToString());
                        strHTML_TestSale = strHTML_TestSale + "<div class=\"thumb-product\">";
                        strHTML_TestSale = strHTML_TestSale + "<a href=\"" + sURL + "\"><img class=\"thumb-product-img\" src=\"" + sImg + "\" alt=\"\"></a>";
                        strHTML_TestSale = strHTML_TestSale + "<div class=\"thumb-product-in\">";
                        strHTML_TestSale = strHTML_TestSale + "<h4><a href=\"" + sURL + "\">" + dr["name"].ToString() + "</a></h4>";
                        //strHTML_TestSale = strHTML_TestSale + "<span class=\"thumb-product-type\">Footwear - Oxfords</span>";
                        strHTML_TestSale = strHTML_TestSale + "</div>";
                        strHTML_TestSale = strHTML_TestSale + "<ul class=\"list-inline overflow-h\">";
                        if (flMinSalePrice != flEstimateprice)
                        {
                            strHTML_TestSale = strHTML_TestSale + "<li class=\"thumb-product-price line-through\">$" + flEstimateprice.ToString("0.00") + "</li>";
                        }
                        strHTML_TestSale = strHTML_TestSale + "<li class=\"thumb-product-price\">$" + flMinSalePrice.ToString("0.00") + "</li>";
                        strHTML_TestSale = strHTML_TestSale + "<li class=\"thumb-product-purchase\"><a href=\"" + sURL + "\"><i class=\"fa fa-shopping-cart\"></i></a> | <a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"fa fa-heart-o\"></i> </a></li>";
                        strHTML_TestSale = strHTML_TestSale + "</ul>";
                        strHTML_TestSale = strHTML_TestSale + "</div>";
                    }
                    if (iFlag == 5) // Inventor Shop
                    {
                      //  sURL = "/Product/SaleBuy.aspx?id=" + HttpUtility.UrlPathEncode(dr["prdGuid"].ToString());
                        strHTML_InventorShop = strHTML_InventorShop + "<div class=\"thumb-product\">";
                        strHTML_InventorShop = strHTML_InventorShop + "<a href=\"" + sURL + "\"><img class=\"thumb-product-img\" src=\"" + sImg + "\" alt=\"\"></a>";
                        strHTML_InventorShop = strHTML_InventorShop + "<div class=\"thumb-product-in\">";
                        strHTML_InventorShop = strHTML_InventorShop + "<h4><a href=\"" + sURL + "\">" + dr["name"].ToString() + "</a></h4>";
                        //strHTML_InventorShop = strHTML_InventorShop + "<span class=\"thumb-product-type\">Footwear - Oxfords</span>";
                        strHTML_InventorShop = strHTML_InventorShop + "</div>";
                        strHTML_InventorShop = strHTML_InventorShop + "<ul class=\"list-inline overflow-h\">";
                        if (flMinSalePrice != flEstimateprice)
                        {
                            strHTML_InventorShop = strHTML_InventorShop + "<li class=\"thumb-product-price line-through\">$" + flEstimateprice.ToString("0.00") + "</li>";
                        }
                        strHTML_InventorShop = strHTML_InventorShop + "<li class=\"thumb-product-price\">$" + flMinSalePrice.ToString("0.00") + "</li>";
                        strHTML_InventorShop = strHTML_InventorShop + "<li class=\"thumb-product-purchase\"><a href=\"" + sURL + "\"><i class=\"fa fa-shopping-cart\"></i></a> | <a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"fa fa-heart-o\"></i> </a></li>";
                        strHTML_InventorShop = strHTML_InventorShop + "</ul>";
                        strHTML_InventorShop = strHTML_InventorShop + "</div>";
                    }
                    /*
                    if (iFlag == 6)
                    {
                        strHTML_OurBrand = strHTML_OurBrand + "<li class=\"item first-child\">";
                        strHTML_OurBrand = strHTML_OurBrand + "<a href=\"" + sURL + "\"><img src=\"" + sImg + "\" alt=\"\"></a>";
                        strHTML_OurBrand = strHTML_OurBrand + "</li>";

                    }*/


                } 

        }

        }
    }
}