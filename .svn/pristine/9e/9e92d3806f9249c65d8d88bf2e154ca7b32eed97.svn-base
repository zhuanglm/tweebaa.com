using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace TweebaaWebApp2
{
    public partial class index_jan26 : System.Web.UI.Page
    {
        public string strShopHtml = "";
        public string strCollageHtml = "";
        public string strEvaluteHtml = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Twee.Comm.XMLCache cache = new Twee.Comm.XMLCache();
            string strDay = cache.GetDateString();
            
            if (cache.IsHTMLFileExists("Index_1_" + strDay))
            {
                strShopHtml = cache.ReadCacheHTML("Index_1_" + strDay);
                strCollageHtml = cache.ReadCacheHTML("Index_2_" + strDay);
                strEvaluteHtml = cache.ReadCacheHTML("Index_3_" + strDay);

            }
            else
            {

                Twee.Mgr.IndexMgr mgr = new Twee.Mgr.IndexMgr();
                DataSet ds = mgr.GetShopPrd();
                string sURL = "";
                string sImg = "";
                string sPrdName = "";
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                         DataRow dr = dt.Rows[i];

                         sImg = "https://tweebaa.com" + dr["fileurl"].ToString().Replace("/big/", "/mid/");
                         string favoriteClassID = "favoriteClass" + i.ToString();
                        float flMinSalePrice = float.Parse(dr["minfinalsaleprice"].ToString());
                        float flEstimateprice = float.Parse(dr["estimateprice"].ToString());
                        int iRewardPoint = Twee.Comm.CommUtil.getExtraShoppingRewardPoint(flMinSalePrice);
                        string favoriteFunc = "FavoritePrdOnOff('" + dr["prdGuid"].ToString() + "', '#" + favoriteClassID + "')";
                        string shareText = iRewardPoint.ToString();
                        string strShortDesc = dr["txtjj"].ToString();
                        strShortDesc = Twee.Comm.CommUtil.GetShortDesc(strShortDesc);
                        strShortDesc = HttpUtility.UrlPathEncode(strShortDesc);
                        strShortDesc = strShortDesc.Replace("\"", "&quot;");
                        sURL = "/Product/saleBuy.aspx?id=" + dr["prdGuid"].ToString();

                        /*
                         strHTML_Featured = strHTML_Featured + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\"></i> </a>";
                         * //<i class=\"icon-custom rounded-x  fa  fa-video-camera\"></i>
                                                strHTML_Featured = strHTML_Featured + "<a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\" ><i class=\"icon-custom rounded-x fa fa-share-alt\"></i></a>";
                        */
                        strShopHtml = strShopHtml +" <div class=\"col-md-4\">";
                        strShopHtml = strShopHtml +" <div class=\"product-img product-img-brd\">";
                        strShopHtml = strShopHtml + "<a href=\"" + sURL + "\"><img class=\"full-width img-responsive\" src=\""+sImg+"\" alt=\"\"></a>";
                        strShopHtml = strShopHtml + "<span class='add-to-cart'><a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\"><i class=\" icon-custom rounded-x fa fa-share-alt\"></i></a>";
                        strShopHtml = strShopHtml + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\"></i></a> <a href=\"" + sURL + "\"><i class=\"icon-custom rounded-x fa fa-shopping-cart\"></i></a></span>";
                        strShopHtml = strShopHtml +"</div>"; 
                        strShopHtml = strShopHtml +"<div class=\"product-description product-description-brd margin-bottom-30 h-auto\">";
                        strShopHtml = strShopHtml +"<div class=\"overflow-h\">";
                        strShopHtml = strShopHtml +"<div class=\"margin-bottom-10\">";
                        strShopHtml = strShopHtml + "<h4 class=\"title-price shop-price\"><a href=\"" + sURL + "\">"+dr["name"].ToString()+"</a></h4>";
                        strShopHtml = strShopHtml +"</div> <div class=\"product-price \"> <span class=\"like-icon-shop\">";
                        strShopHtml = strShopHtml + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><em id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\">";
                        strShopHtml = strShopHtml +"</em></a></span><!-- Small modal -->";
                        strShopHtml = strShopHtml + "<span class=\"like-icon-shop\"><a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\"><i class=\"fa fa-share-alt\"></i></a></span>";
                       // strShopHtml = strShopHtml + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\"></i> </a>";
                       // strShopHtml = strShopHtml + "<a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\" ><i class=\"icon-custom rounded-x fa fa-share-alt\"></i></a></span>";

                        strShopHtml = strShopHtml +"<!-- End Small Modal -->";               
                        strShopHtml = strShopHtml +"</div>";
                        strShopHtml = strShopHtml +"</div>";                         
                        strShopHtml = strShopHtml +"</div>";
                        strShopHtml = strShopHtml +"</div>";
                    }
                }
                DataSet dsCollage = mgr.GetCollageDesign();
                if (dsCollage != null)
                {
                    DataTable dt = dsCollage.Tables[0];
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        string s = dr["CollageDesign_ThumbnailFileName"].ToString();//.thumbnail;
                        if (!string.IsNullOrEmpty(s))
                        {
                            if (s.Length > 10 && s.Substring(0, 7) == "http://")
                            {
                                sImg = s;
                            }
                            else
                            {
                                sImg = "/upload/UploadImg" + s;
                            }
                        }
                        else
                        {
                            sImg = "/images/no-image.gif";
                        }
                        string sShareImg = "http://itweebaa.com" + sImg;
                        sURL = "/Product/CollageReview.aspx?design_id=" + dr["CollageDesign_ID"].ToString();
                        string strShortDesc = dr["CollageDesign_Inspiration"].ToString();
                        strShortDesc = Twee.Comm.CommUtil.GetShortDesc(strShortDesc);
                        strShortDesc = HttpUtility.UrlPathEncode(strShortDesc);

                        string strShareCollage = "ShareCollage(" + dr["CollageDesign_ID"].ToString() + ",'" + dr["CollageDesing_Title"].ToString() + "','" + sShareImg + "','CollageReview.aspx','" + strShortDesc + "')";

                        strCollageHtml = strCollageHtml+"<div class=\"col-md-4\">";
                        strCollageHtml = strCollageHtml+"<div class=\"product-img product-img-brd\">";
                        strCollageHtml = strCollageHtml+"<a href=\""+sURL+"\"><img onerror=\"this.src='"+sShareImg+"'\" class=\"full-width img-responsive\" src=\""+sImg+"\" alt=\"\"></a>";   
                        strCollageHtml = strCollageHtml+"<span class=\"add-to-cart add-share\"> <a href=\"javascript:void(0)\" onclick=\""+strShareCollage+"\">";
                        strCollageHtml = strCollageHtml+"<i class=\" icon-custom rounded-x fa fa-share-alt\"></i></a><a href=\"javascript:void(0)\" onclick=\"FavoriteCollage('"+dr["CollageDesign_ID"].ToString()+"')\">";
                        strCollageHtml = strCollageHtml+"<i class=\"icon-custom rounded-x fa fa-heart-o\"></i> </a></span>";
                        strCollageHtml = strCollageHtml+"</div>";
                        strCollageHtml = strCollageHtml+"<div class=\"product-description product-description-brd margin-bottom-30 h-auto\">";
                        strCollageHtml = strCollageHtml+"<div class=\"overflow-h\">";
                        strCollageHtml = strCollageHtml+"<div class=\"margin-bottom-10\">";
                        strCollageHtml = strCollageHtml + "<h4 class=\"title-price shop-price h-auto\"><a href=\"" + sURL + "\">" + dr["CollageDesing_Title"].ToString() + "</a></h4>";
                        strCollageHtml = strCollageHtml+"</div> <div class=\"product-price\"><span class=\"badge badge-blue rounded-2x\">Up to 10% Reward</span>";
                        strCollageHtml = strCollageHtml + "</div></div></div></div>";
                    }
                }
                DataSet dsEvalute = mgr.GetEvalutePrd();
                if (dsEvalute != null)
                {
                    DataTable dt = dsEvalute.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];

                        sImg = "https://tweebaa.com" + dr["fileurl"].ToString().Replace("/big/", "/mid/");
                        string favoriteClassID = "favoriteClass" + i.ToString();
                        float flMinSalePrice = 0.0f;
                        if (!string.IsNullOrEmpty(dr["minfinalsaleprice"].ToString()))
                        {
                            flMinSalePrice=float.Parse(dr["minfinalsaleprice"].ToString());
                        }
                        float flEstimateprice = float.Parse(dr["estimateprice"].ToString());
                        int iRewardPoint = Twee.Comm.CommUtil.getExtraShoppingRewardPoint(flMinSalePrice);
                        string favoriteFunc = "FavoritePrdOnOff('" + dr["prdGuid"].ToString() + "', '#" + favoriteClassID + "')";
                        string shareText = iRewardPoint.ToString();
                        string strShortDesc = dr["txtjj"].ToString();
                        strShortDesc = Twee.Comm.CommUtil.GetShortDesc(strShortDesc);
                        strShortDesc = HttpUtility.UrlPathEncode(strShortDesc);
                        strShortDesc = strShortDesc.Replace("\"", "&quot;");
                        sURL = "/Product/saleBuy.aspx?id=" + dr["prdGuid"].ToString();

                        /*
                         strHTML_Featured = strHTML_Featured + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\"></i> </a>";
                                                strHTML_Featured = strHTML_Featured + "<a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\" ><i class=\"icon-custom rounded-x fa fa-share-alt\"></i></a>";
                        */
                        strEvaluteHtml = strEvaluteHtml + " <div class=\"col-md-4\">";
                        strEvaluteHtml = strEvaluteHtml + " <div class=\"product-img product-img-brd\">";
                        strEvaluteHtml = strEvaluteHtml + "<a href=\"" + sURL + "\"><img class=\"full-width img-responsive\" src=\"" + sImg + "\" alt=\"\"></a>";
                        strEvaluteHtml = strEvaluteHtml + "<span class=\"add-to-cart add-evaluate\"><a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\"><i class=\" icon-custom rounded-x fa fa-share-alt\"></i></a>";
                        strEvaluteHtml = strEvaluteHtml + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\"></i></a> <a  href=\"" + sURL + "\"><i class=\"icon-custom rounded-x fa fa-check-square-o\"></i></a></span>";
                        strEvaluteHtml = strEvaluteHtml + "</div>";
                        strEvaluteHtml = strEvaluteHtml + "<div class=\"product-description product-description-brd margin-bottom-30 h-auto\">";
                        strEvaluteHtml = strEvaluteHtml + "<div class=\"overflow-h\">";
                        strEvaluteHtml = strEvaluteHtml + "<div class=\"margin-bottom-10\">";
                        strEvaluteHtml = strEvaluteHtml + "<h4 class=\"title-price shop-price\"><a href=\"" + sURL + "\">" + dr["name"].ToString() + "</a></h4>";
                        strEvaluteHtml = strEvaluteHtml + "</div> <div class=\"product-price \"><span class=\"badge badge-blue rounded-2x\">Chance to win free gift</span> <span class=\"like-icon-shop\">";
                        strEvaluteHtml = strEvaluteHtml + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><em id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\">";
                        strEvaluteHtml = strEvaluteHtml + "</em></a></span><!-- Small modal -->";
                        strEvaluteHtml = strEvaluteHtml + "<span class=\"like-icon-shop\"><a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\"><i class=\"fa fa-share-alt\"></i></a></span>";
                        // strEvaluteHtml = strEvaluteHtml + "<a href=\"javascript:void(0)\" onclick=\"" + favoriteFunc + "\"><i id=\"" + favoriteClassID + "\" class=\"icon-custom rounded-x fa fa-heart-o\"></i> </a>";
                        // strEvaluteHtml = strEvaluteHtml + "<a href=\"javascript:void(0)\" onclick=\"SharePrd('" + dr["prdGuid"].ToString() + "','" + dr["name"].ToString() + "','" + sImg + "','" + "saleBuy.aspx" + "','" + shareText + "','" + strShortDesc + "')\" ><i class=\"icon-custom rounded-x fa fa-share-alt\"></i></a></span>";

                        strEvaluteHtml = strEvaluteHtml + "<!-- End Small Modal -->";
                        strEvaluteHtml = strEvaluteHtml + "</div>";
                        strEvaluteHtml = strEvaluteHtml + "</div>";
                        strEvaluteHtml = strEvaluteHtml + "</div>";
                        strEvaluteHtml = strEvaluteHtml + "</div>";
                    }
                }                


                /*
                <div class="col-md-4">
                                <div class="product-img product-img-brd">
                                    <a href="#"><img class="full-width img-responsive" src="images/blog/5.jpg" alt=""></a>
                        
                                              <span class="add-to-cart add-evaluate" > <a href="#"><i class=" icon-custom rounded-x fa fa-share-alt"></i></a>
                           <a href="#"> <i class="icon-custom rounded-x fa fa-heart-o"></i> </a>
                           <a href="#"><i class="icon-custom rounded-x fa fa-check-square-o"></i></a>
                           </span>
                                </div> 
                                   <div class="product-description product-description-brd margin-bottom-30 h-auto">
                                    <div class="overflow-h">
                                          <div class="margin-bottom-10">
                                            <h4 class="title-price h-auto"><a href="shop-ui-inner.html">Double-breasted</a></h4>
                                       </div>    <div class="product-price">
                                 <span class="badge badge-blue rounded-2x">Chance to win free gift</span> 
                                            <span class="like-icon"><a data-original-title="Favorite" data-toggle="tooltip" data-placement="bottom" class="tooltips" href="#"><i class="fa fa-heart"></i></a></span>  
                                                      <!-- Small modal -->
                            <span class="like-icon" ><a data-toggle="modal" data-target=".bs-example-modal-sm"><i class="fa fa-share-alt"></i></a></span>
          
                            <!-- End Small Modal -->               
                                        </div>
                                    </div>                         
                                </div>
                            </div>*/

                cache.WriteCahceHTML(strShopHtml, "Index_1_" + strDay);
                cache.WriteCahceHTML(strCollageHtml, "Index_2_" + strDay);
                cache.WriteCahceHTML(strEvaluteHtml, "Index_3_" + strDay);
            }
             
        }
    }
}