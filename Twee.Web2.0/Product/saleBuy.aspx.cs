using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using log4net;
using System.Reflection;
using Twee.Comm;
using Twee.Mgr;
using Twee.Model;
using System.Data;

namespace TweebaaWebApp2.Product
{
    public partial class saleBuy : System.Web.UI.Page
    {
        public string cssPath = "../";
        public string pageTitle = "产品名称＋标签（tags）+ Limited offer ! PreOrder now at Tweebaa—一句宣传广告"; //"Buy Now";
        private Guid? userGuid;
        public string _userid = string.Empty;
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        Twee.Mgr.PrdPriceMgr pricesMgr = new Twee.Mgr.PrdPriceMgr();
        Twee.Mgr.PrdStoragMgr ruleMgr = new Twee.Mgr.PrdStoragMgr();//这里取库存表中的数据

        public string _priceArea = string.Empty;//价格区间

        public string _color = string.Empty;//规格颜色
        public string _ruleName = string.Empty;//规格名称
        public string _firstColor = string.Empty;
        public string _firstRuleStoreNum = "0";//首次加载计算第一个规格的库存
        public string _allColor = string.Empty;

        public string _jsonRuleAndColor = string.Empty;
        public string _jsonRuleAndPrice = string.Empty;
        public string _jsonRuleAndStorag = string.Empty;
        public string _jsonpriceMin = string.Empty;//每个规格的最小价格
        public string _jsonImageRuleID = string.Empty;  // rule ID of each image
        public bool _favorite = false;
        public int iRewardPoint;
        public Prd _model;
        public Guid _prdGuid;
        public string _imgUrl = string.Empty;
        public string _proid = string.Empty;

        public string _proRuleTitle = string.Empty;

        //public string _sCurVer = "0";
        /*
         * 
          <meta property="fb:app_id" content="154517488086938"/>
            <meta property="og:site_name" content="Tweebaa.com Ear Play Shop"/>
            <meta property="og:type" content="website"/>

                    <meta property="og:image" content="http://ccue.singtao.ca//Output/media/2015/11/surface_0.jpg" />
                <meta property="og:url" content="https://tweebaa.com/Product/saleBuy.aspx?id="/>
                <meta property="og:description" content="" />
 
         */
        public string _sRuleNameDisplayStyle = "display:block";   // do not display Rule Name if there is only one  and its name is not set. 

        public string sMetaTag = "";

        public int MobileBrowserFlag = 0;

        public string strVideoCode = "";
        public string strMasterSliders = "";
        public string strCategoryLink;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
            //browserName = myBrowserCaps.Browser;
            if (((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice)
            {
                MobileBrowserFlag = 1;
            }

            string proid = "";
            //_sCurVer = CommUtil.GetCurrentVersion();

            if (string.IsNullOrEmpty(Request["id"]))
            {
                if (string.IsNullOrEmpty(HttpContext.Current.Items["id"].ToNullString()))
                {
                    Response.Write("<script type='text/javascript'>alert('bad request')</script>");
                    Response.Redirect("~/product/prdSaleAll.aspx");
                    return;
                }
                else
                {
                    proid = HttpContext.Current.Items["id"].ToString();
                    //Request["id"] = proid;
                }
            }
            else
            {

                proid = Request["id"].Trim();
            }

            userGuid = Twee.Comm.CommUtil.IsLogion();
            if (userGuid != null)
            {
                _userid = userGuid.ToString();
            }

            
            _proid = proid;

            string shareID = string.Empty;
            string prdID = Twee.Comm.CommUtil.GetUrlPrdId(_proid, out shareID);

            _prdGuid = (Guid)Twee.Comm.CommUtil.ToGuid(prdID);
            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();

            FileMgr fileMgr = new FileMgr();
            List<Twee.Model.File> listFile = fileMgr.GetModelList("prdguid='" + prdID + "'");
            if (listFile[0].fileurl.Length > 0 && listFile[0].fileurl.Substring(0, 1) == "/")
            {
                _imgUrl = "https://tweebaa.com" + listFile[0].fileurl;
            }
            else
            {
                _imgUrl = "https://tweebaa.com/" + listFile[0].fileurl;
            }
            //Add by Long 2016/01/22 for dynamic create master slider
            int i=0;
            for (i = 0; i < listFile.Count; i++)
            {
                if (!string.IsNullOrEmpty(listFile[i].fileurl))
                {
                    strMasterSliders = strMasterSliders + "<div class=\"ms-slide\" >";
                    strMasterSliders = strMasterSliders + "<img  class=\"ms-brd\"";
                    if (i == 0)
                    {
                        strMasterSliders = strMasterSliders + "itemprop=\"image\"";
                    }
                    strMasterSliders = strMasterSliders + "src=\"https://tweebaa.com" + listFile[i].fileurl.Replace("big", "mid") + "\" id=\"imgBig" + (i + 1);
                    strMasterSliders = strMasterSliders + "\" data-src=\"" + listFile[i].fileurl.Replace("big", "mid") + "\" alt=\"Tweebaa,com\">";
                    strMasterSliders = strMasterSliders + "<img class=\"ms-thumb\" id=\"imgSmall1" + (i + 1);
                    strMasterSliders = strMasterSliders + "\" src=\"https://tweebaa.com" + listFile[i].fileurl.Replace("big", "mid") + "\"  alt=\"Tweebaa.com\"></div>";
                }
            }
            for(i=listFile.Count;i<3;i++){
                strMasterSliders=strMasterSliders+"<div class=\"ms-slide\">";
                strMasterSliders=strMasterSliders+"<img src=\"/images/blank.gif\" id=\"imgBig"+(i+1)+"\" data-src=\"https://tweebaa.com"+listFile[0].fileurl.Replace("big","mid")+"\" alt=\"tweebaa.com\">";
                strMasterSliders =strMasterSliders + "<img class=\"ms-thumb\" id=\"imgSmall" + (i + 1) + "\" src=\"/images/blank.gif\" alt=\"thumb\"></div>";
            }




            // create the json of the Image RuleID
            StringBuilder jsonImageRuleID = new StringBuilder();
            foreach (var item in listFile)
            {
                if (string.IsNullOrEmpty(item.fileurl)) item.fileurl = string.Empty;

                int iRuleID = (item.ruleid == null)? -1:  (int)item.ruleid;
                string sFileURL  =  string.Empty;
                if (item.fileurl.Length > 0 && item.fileurl.Substring(0, 1) == "/")
                {
                    sFileURL = "https://tweebaa.com" + item.fileurl;
                }
                else
                {
                    sFileURL = "https://tweebaa.com/" + item.fileurl;
                }
                jsonImageRuleID.AppendFormat(",{2}\"FileURL\":\"{0}\",\"RuleID\":\"{1}\"{3}", sFileURL, iRuleID, "{", "}");
            }
            if (jsonImageRuleID.ToString().Length > 0)
            {
                _jsonImageRuleID += "[" + jsonImageRuleID.ToString().Substring(1) + "]";
            }
 
            _model = mgr.GetModel(_prdGuid);
            // check product status and redirect to corresponding page
            // 2015-11-09 By Jack Cao 
            if (_model.wnstat == (int)ConfigParamter.PrdSate.preSale)
            {
                Response.Redirect("~/Product/presaleBuy.aspx?id=" + _proid);
                return;
            }
            else if (_model.wnstat == (int)ConfigParamter.PrdSate.review)
            {
                Response.Redirect("~/Product/submitReview.aspx?id=" + _proid);
                return;
            }

            DataTable dtSEO = mgr.GetProductSEOMetaTags(_proid);

            if (_model.videoEmbed != null && _model.videoEmbed != "")
            {
                strVideoCode = _model.videoEmbed;
            }
            else if (_model.videoUrl != null && _model.videoUrl != "")
            {
               // LoadVideo(picPath + baseInfo.videoUrl);
                /*
                strVideoCode ="<embed type=\"application/x-shockwave-flash\" src=\"/css/PlayerLite.swf\" width=\"560\" height=\"320\" id=\"CuPlayerV4\" name=\"CuPlayerV4\" bgcolor=\"#000000\"";
                strVideoCode =strVideoCode +" quality=\"high\" allowfullscreen=\"true\" allowscriptaccess=\"always\" wmode=\"opaque\" salign=\"lt\" flashvars=\"videoDefault=";
                strVideoCode =strVideoCode +"https://tweebaa.com/"+_model.videoUrl+"&amp;autoHide=true&amp;hideType=fade&amp;autoStart=false&amp;holdImage=start.jpg&amp;startVol=60&amp;hideDelay=60&amp;bgAlpha=75\">";
                */
                strVideoCode = "<video id=\"prdVideo\" onClick=\"playPause();\" poster=\"/images/video_default.jpg\" width=\"560\" height=\"325\" controls=\"false\">";
                 strVideoCode = strVideoCode + "<source src=\"" + "https://tweebaa.com/" + _model.videoUrl + "\" type=\"video/mp4\">";
                strVideoCode =strVideoCode +"Sorry, your browser doesn't support embedded videos, ";
                strVideoCode =strVideoCode +"but don't worry, you can <a href=\"videofile.ogg\">download it</a>";
                strVideoCode =strVideoCode +"and watch it with your favorite video player!";
                strVideoCode =strVideoCode +"</video>";
             }


            strCategoryLink = mgr.CreateCategoryLinks(prdID);

            string strShortDesc = Twee.Comm.CommUtil.StripHTML(_model.txtjj);
            strShortDesc = Twee.Comm.CommUtil.Left(strShortDesc,100);

            //string sFacebookMetaTag = "";
            if (dtSEO != null)
            {
                sMetaTag = "<meta name=\"keywords\" content=\"" + dtSEO.Rows[0]["SEOMetaKeywords"].ToString() + " Earn Play Shop\">\n<meta name=\"description\" content=\"" + dtSEO.Rows[0]["SEOMetaDescription"].ToString() + "\">\n";

            }
            else
            {
                sMetaTag = "<meta name=\"keywords\" content=\"" + _model.name + " Earn Play Shop\">\n<meta name=\"description\" content=\"" + strShortDesc + "\">\n";
            }
             /*
            sFacebookMetaTag="<meta property=\"fb:app_id\" content=\"1591110677840145\"/>\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:site_name\" content=\"Tweebaa.com Ear Play Shop\"/>\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:type\" content=\"website\"/>\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:image\" content=\"" + _imgUrl.Replace("/big/", "/mid2/") + "\" />\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:url\" content=\"https://tweebaa.com/Product/saleBuy.aspx?id=" + _proid + "\"/>\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:description\" content=\"" + strShortDesc + "\" />";
            sMetaTag = sMetaTag + sFacebookMetaTag;*/
            decimal saleprice = _model.saleprice.Value;
            //string estimateprice = dt.Rows[0]["estimateprice"].ToString();
            //float price = saleprice;// float.Parse(saleprice);
           
            //////////Add by Long for extra Shopping Reward point if share
            if (saleprice <= 25)
            {
                iRewardPoint = 100;
            }
            else if (saleprice > 25 && saleprice <= 50)
            {
                iRewardPoint = 200;
            }
            else if (saleprice > 50 && saleprice <= 100)
            {
                iRewardPoint = 300;
            }
            else if (saleprice > 100 && saleprice <= 200)
            {
                iRewardPoint = 400;
            }
            else if (saleprice > 200 && saleprice <= 300)
            {
                iRewardPoint = 500;
            }
            else if (saleprice > 300 && saleprice <= 400)
            {
                iRewardPoint = 600;
            }
            else if (saleprice > 400)
            {
                iRewardPoint = 700;
            }
            //////////////////
            // when product is shared out, the proid has two parts  prdGuid + "_" + shareGuid
            //int iPos = proid.IndexOf('_') ;
            //if (iPos != -1)
            //{
            //    _proid = proid.Substring(0, iPos);
            //}

            try
            {
                #region get product favorate status of current user.

                Guid prdGuid = new Guid(prdID);



                if (userGuid != null)
                {
                    _favorite = new Twee.Mgr.FavoriteMgr().Exists(prdGuid, (System.Guid)userGuid);
                }
                #endregion

                #region 根据产品ID取供货表中已生效状态为4的唯一产品

                Twee.Model.proDetails details = new Twee.Mgr.proDetailsMgr().GetModelList(" state=" + (int)Twee.Comm.ConfigParamter.InventoryState.accepted + " and proid='" + prdID + "'").FirstOrDefault();
                if (details == null)
                {
                    Response.Write("<script type='text/javascript'>alert('bad request')</script>");
                    Response.Redirect("~/product/prdSaleAll.aspx");
                    return;
                }
                string userid = details.userid.Trim();

                //取规格
                List<Twee.Model.proRules> rules = new Twee.Mgr.proRulesMgr().GetModelList(" proid='" + prdID + "' and userid='" + userid + "'");
                if (rules != null && rules.Count > 0)
                {
                    var supplyTypeId = rules.First().proruletitle.Value;
                    var supplyType = new Twee.Mgr.proDetailsMgr().GetSupplyTypeById(supplyTypeId);
                    _proRuleTitle = supplyType.prodetailType;

                    //取规格ID集
                    List<int> ruleIds = rules.Select(s => s.id).ToList();
                    string _ruleIds = string.Empty;
                    ruleIds.ForEach(s => { _ruleIds += "," + s; });
                    //取规格名称，过滤重复
                    List<string> ruleNames = rules.Select(s => s.prorule.Trim()).Distinct().ToList();

                    #region 拼接规格与颜色的JSON
                    StringBuilder jsonRuleAndColor = new StringBuilder();
                    foreach (var item in rules)
                    {
                        jsonRuleAndColor.AppendFormat(",{2}\"ruleid\":\"{0}\",\"color\":\"{1}\"{3}", item.id.ToString(), item.procolor, "{", "}");
                    }
                    if (jsonRuleAndColor.ToString().Length > 0)
                    {
                        _jsonRuleAndColor += "[" + jsonRuleAndColor.ToString().Substring(1) + "]";
                    }
                    #endregion

                    #region 取该规格下的销售价格区间的JSON
                    var salePriceArea = new Twee.Mgr.PrdPriceMgr().GetModelList(" prdguid='" + proid + "' and ruleid in (" + _ruleIds.Substring(1) + ");");
                    StringBuilder jsonRuleAndPrice = new StringBuilder();
                    foreach (var item in salePriceArea)
                    {
                        jsonRuleAndPrice.AppendFormat(",{4}\"ruleid\":\"{0}\",\"from\":\"{1}\",\"to\":\"{2}\",\"price\":\"{3}\"{5}", item.ruleid, item.p1, item.p2, item.price, "{", "}");
                    }
                    if (jsonRuleAndPrice.ToString().Length > 0)
                    {
                        _jsonRuleAndPrice += "[" + jsonRuleAndPrice.ToString().Substring(1) + "]";
                    }

                    //获取每个规格的最大价格
                    if (salePriceArea != null && salePriceArea.Count > 0)
                    {
                        List<string> distintRuleIds = salePriceArea.Select(s => s.ruleid.ToString().Trim()).Distinct().ToList();
                        Dictionary<string, string> minPriceDic = new Dictionary<string, string>();
                        foreach (var ruleidTemp in distintRuleIds)
                        {
                            string min = salePriceArea.Where(s => s.ruleid.ToString().Trim() == ruleidTemp).Select(s => s.price).Max().ToString();
                            minPriceDic.Add(ruleidTemp, min);
                        }
                        StringBuilder tempMinPriceDic = new StringBuilder();
                        foreach (var dicitem in minPriceDic)
                        {
                            tempMinPriceDic.AppendFormat(",{0}\"ruleid\":\"{2}\",\"minprice\":\"{3}\"{1}", "{", "}", dicitem.Key, dicitem.Value);
                        }
                        if (tempMinPriceDic.ToString().Length > 0)
                        {
                            _jsonpriceMin = "[" + tempMinPriceDic.ToString().Substring(1) + "]";
                        }
                    }

                    #endregion

                    #region 规格与库存的JSON
                    var storags = new Twee.Mgr.PrdStoragMgr().GetModelList(" ruleid in (" + _ruleIds.Substring(1) + ")");
                    StringBuilder jsonRuleAndStorag = new StringBuilder();
                    foreach (var item in storags)
                    {
                        jsonRuleAndStorag.AppendFormat(",{2}\"ruleid\":\"{0}\",\"storage\":\"{1}\"{3}", item.ruleid, item.number, "{", "}");
                    }
                    if (jsonRuleAndStorag.ToString().Length > 0)
                    {
                        _jsonRuleAndStorag += "[" + jsonRuleAndStorag.ToString().Substring(1) + "]";
                    }
                    #endregion

                    #region 生成规格 HTML
                    //<span onclick="changeColor(this)" ruleid="21" class="jsclick on">33</span>
                    StringBuilder html_ruleName = new StringBuilder();
                    int rule_index = 0;
                    int itemStyleIndex = 0;
                    int itemColorIndex = 0;

                    // do not display rule name if there is only one rule and its name is not set. 
                    _sRuleNameDisplayStyle = "display:block";
                    if (ruleNames.Count == 1 ) {
                        if ( string.IsNullOrEmpty(ruleNames[0]) ) {
                            _sRuleNameDisplayStyle = "display:none";
                        }
                    }

                    foreach (string rule_name in ruleNames)
                    {
                        string temp_ruleidbyname = "";
                        rules.Where(s => s.prorule.Trim() == rule_name.Trim()).ToList().ForEach(s => { temp_ruleidbyname += "," + s.id; });
                        var temp_rules = rules.Where(s => s.prorule.Trim() == rule_name.Trim()).Select(s => s).ToList();
                        itemStyleIndex++;
                        if (rule_index == 0) //第一个规格默认选中
                        {
                            //html_ruleName.AppendFormat("<span onclick='_ChangeRule(this)' class=\"jsclick on\" ruleids='{1}'>{0}</span>", rule_name, temp_ruleidbyname.Substring(1));
                            html_ruleName.AppendFormat("<li><input onclick='_ChangeRule(this)' type='radio' id='size-" + itemStyleIndex + "' name='size' ruleids='{1}' checked ><label  style=\"font-size:small; width:auto; height:35px;padding:4px;\" for='size-" + itemStyleIndex + "'>{0}</label></li>", rule_name, temp_ruleidbyname.Substring(1));//-----------新版

                            //加载该规格的所有颜色
                            StringBuilder temp_color_first = new StringBuilder();
                            foreach (var t_rule in temp_rules)
                            {
                                itemColorIndex++;
                                string t_color = string.Empty;
                                if (string.IsNullOrEmpty(t_rule.procolor) || t_rule.procolor == "无")
                                {
                                    t_color = "";   // no color,  do no display anything Jack Cao 2015-11-06
                                }
                                if (t_rule.procolor == "#fff")
                                {
                                    //t_color = "white";
                                    //temp_color_first.AppendFormat("<div class=\"selectColor\" onclick=\"_ChangeColor(this)\" ruleid='{1}'><div style=\" background:{0}; font:8px;border:solid 1px gray; text-align:center;\">{2}</div></div>", t_rule.procolor, t_rule.id, t_color);

                                    temp_color_first.AppendFormat("<li><input type='radio' id='color-" + itemColorIndex + "' name='color' onclick=\"_ChangeColor('color-" + itemColorIndex + "', 'colorLabel-" + itemColorIndex + "')\" ruleid='{1}' checked ><label id='colorLabel-" + itemColorIndex + "' style=\" background:{0}; font:8px;border:solid 2px #555; text-align:center;\" for='color-" + itemColorIndex + "'>{2}</label></li>", t_rule.procolor, t_rule.id, t_color);//-----------新版


                                }
                                else
                                {
                                    //temp_color_first.AppendFormat("<div class=\"selectColor\" onclick=\"_ChangeColor(this)\" ruleid='{1}'><div style=\" background:{0}; font:8px; text-align:center;\">{2}</div></div>", t_rule.procolor, t_rule.id, t_color);
                                    temp_color_first.AppendFormat("<li><input type='radio' id='color-" + itemColorIndex + "' name='color' onclick=\"_ChangeColor('color-" + itemColorIndex + "', 'colorLabel-" + itemColorIndex + "')\" ruleid='{1}' checked ><label id='colorLabel-" + itemColorIndex + "' style=\" background:{0}; font:8px;text-align:center;\" for='color-" + itemColorIndex + "'>{2}</label></li>", t_rule.procolor, t_rule.id, t_color); //-----------新版
                                }

                            }
                            _firstColor = temp_color_first.ToString();

                            //加载该规格下的库存
                            var prdStoragList = new Twee.Mgr.PrdStoragMgr().GetModelList(" ruleid in (" + temp_ruleidbyname.Substring(1) + ")").ToList();
                            if (prdStoragList != null && prdStoragList.Count > 0)
                            {
                                _firstRuleStoreNum = prdStoragList.Select(s => s.number).Sum().ToString();
                            }
                        }
                        else
                        {
                            //html_ruleName.AppendFormat("<span onclick='_ChangeRule(this)' ruleids='{1}'>{0}</span>", rule_name, temp_ruleidbyname.Substring(1));
                            html_ruleName.AppendFormat("<li><input onclick='_ChangeRule(this)' type='radio' id='size-" + itemStyleIndex + "' name='size' ruleids='{1}'><label style=\"font-size:small; width:auto; height:35px;padding:4px;\" for='size-" + itemStyleIndex + "'>{0}</label></li>", rule_name, temp_ruleidbyname.Substring(1)); //-----------新版
                        }
                        rule_index++;
                    }
                    _ruleName = html_ruleName.ToString();
                    #endregion

                }

                #endregion

                #region 价格区间
                ////List<Twee.Model.PrdPrices> list = pricesMgr.GetEntityList(" prdguid='" + proid + "'");
                ////string temp = string.Empty;
                ////if (null != list && list.Count > 0)
                ////{
                ////    foreach (var item in list)
                ////    {
                ////        temp += ",{\"from\":\"" + item.p1 + "\",\"to\":\"" + item.p2 + "\",\"price\":\"" + item.price + "\"}";
                ////    }
                ////}
                ////if (!string.IsNullOrEmpty(temp))
                ////    _priceArea = "[" + temp.Substring(1) + "]";
                #endregion

                #region 颜色

                //Twee.Model.PrdStorag model = ruleMgr.GetModelByPrdId(Guid.Parse(proid));
                //string storeInfo = model.prostoreinfo;
                //if (string.IsNullOrEmpty(storeInfo))
                //{
                //    Response.Write("<script type='text/javascript'>alert('该产品尚未上架');</script>");
                //    return;
                //}

                //XmlDocument doc = new XmlDocument();
                //doc.LoadXml(storeInfo);

                ////查询规格节点
                //if (doc == null)
                //    return;

                //List<string> ruleNameList = new List<string>();
                //XmlNodeList ruleList = doc.SelectNodes("/rules/rule");
                //int index = 0;
                //foreach (XmlNode ruleNode in ruleList)
                //{
                //    var colorNodes = ruleNode.SelectNodes("color");
                //    if (index == 0)
                //    {
                //        _ruleName += "<span class=\"jsclick on\" ruleid=" + ruleNode.Attributes["id"].Value + " onclick=\"changeColor(this)\">" + ruleNode.Attributes["name"].Value + "</span>";
                //        int tempStoreNum = 0;
                //        foreach (XmlNode colorNode in colorNodes)
                //        {
                //            _firstColor += "<span ruleid=" + ruleNode.Attributes["id"].Value + " storenum=" + colorNode.Attributes["storenum"].Value + " class=\"jsclick js-preview\" style=\"cursor:pointer;background-color: " + colorNode.Attributes["val"].Value + "\" onclick=\"selectedFuc(this)\" ></span>";
                //            tempStoreNum += int.Parse(colorNode.Attributes["storenum"].Value);
                //        }
                //        _firstRuleStoreNum = tempStoreNum.ToString();
                //    }
                //    else
                //    {
                //        _ruleName += "<span class=\"jsclick\" ruleid=" + ruleNode.Attributes["id"].Value + " onclick=\"changeColor(this)\">" + ruleNode.Attributes["name"].Value + "</span>";
                //    }
                //    foreach (XmlNode colorNode in colorNodes)
                //    {
                //        _allColor += "<span ruleid=" + ruleNode.Attributes["id"].Value + " storenum=" + colorNode.Attributes["storenum"].Value + " class=\"jsclick js-preview\" style=\"cursor:pointer;background-color: " + colorNode.Attributes["val"].Value + "\" onclick=\"selectedFuc(this)\" ></span>";
                //    }
                //    index++;
                //}
                #endregion

                #region 产品访问记录

                /*CookiesHelper cookie = new Twee.Comm.CookiesHelper();
                if (userGuid != null)
                {
                    VistLog visit = new VistLog();
                    visit.prdID = prdID.ToString();
                    visit.userId = userGuid.ToString();
                    visit.addTime = DateTime.Now;
                    VistLogMgr visitMgr = new VistLogMgr();
                    visitMgr.Add(visit);
                }*/
                #endregion
            }
            catch (Exception ex)
            {
                log.Error("购买页面日志：" + System.DateTime.Now.ToString("yyyy-MM-dd hhmmss") + "  错误：  " + ex.Message);
                Response.Clear();
                //Response.Write("<script type='text/javascript'>alert('非常抱歉，该产品尚未上架!');</script>");
            }



        }
    }
}