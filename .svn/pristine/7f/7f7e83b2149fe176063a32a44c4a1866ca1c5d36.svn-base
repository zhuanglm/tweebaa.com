using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Model;
using Twee.Comm;

namespace TweebaaWebApp2.Product
{
    public partial class prdReview : TweebaaWebApp2.MasterPages.BasePage
    {
        private Guid? userGuid;
        public string _userid = string.Empty;

        public string _proid = string.Empty;
        public string _passCount = string.Empty;//后台统计通过的人数
        public string _styleMarginLeft = string.Empty;//改变提示进度的位置
        public string _prdName = string.Empty;
        public string _prdDesc = string.Empty;
        public string _prdImageUrl = string.Empty;
        public Prd _model;
        public Guid _prdGuid;
        public string _imgUrl = string.Empty;
        public string _disabled = "";
        public string _placeholder = "Please includes your reason or suggestion, each person can only evaluate once. (Max 200 characters)";
        public string _sCurVer = "0";
        public string[] _sYesNoArr = { string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty };

        public string _sDispAlreadyEvaluated = "display:none";
        public string _sHideAlreadyEvaluated = "display:inline";
        public int _iProgress = 1;
        public bool _favorite = false;

        public string _sAlreadyEvaluatedMsg = "";
        public string sMetaTag = "";

        public string strVideoCode = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            _sCurVer = CommUtil.GetCurrentVersion();

            bool isLogion = CheckLogion(out userGuid);
            if (null != userGuid)
            {
                _userid = userGuid.ToString();
            }

            if (!string.IsNullOrEmpty(Request["id"]))
                _proid = Request["id"].ToString().Trim();

            string shareID = string.Empty;
            string prdID = Twee.Comm.CommUtil.GetUrlPrdId(_proid, out shareID);

            _prdGuid = (Guid)Twee.Comm.CommUtil.ToGuid(prdID);
            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();

            FileMgr file = new FileMgr();
            List<File> listFile = file.GetModelList("prdguid='" + prdID + "'");
            _imgUrl = "http://itweebaa.com/" + listFile[0].fileurl;

            _model = mgr.GetModel(_prdGuid);


            // check product status if it has been promoted to test-sale/buy-now then redirect to corresponding page
            // 2015-11-09 By Jack Cao 
            if (_model.wnstat == (int)ConfigParamter.PrdSate.sale)
            {
                Response.Redirect("~/product/saleBuy.aspx?id=" + _proid);
                return;
            }
            else if (_model.wnstat == (int)ConfigParamter.PrdSate.preSale)
            {
                Response.Redirect("~/product/presaleBuy.aspx?id=" + _proid);
                return;
            }
            string strShortDesc = Twee.Comm.CommUtil.StripHTML(_model.txtjj);
            strShortDesc = Twee.Comm.CommUtil.Left(strShortDesc, 100);
            string sFacebookMetaTag = "";
            sMetaTag = "<meta name=\"keywords\" content=\"" + _model.name + " Earn Play Shop\">\n<meta name=\"description\" content=\"" + strShortDesc + "\">\n";
            sFacebookMetaTag = "<meta property=\"fb:app_id\" content=\"1591110677840145\"/>\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:site_name\" content=\"Tweebaa.com Ear Play Shop\"/>\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:type\" content=\"website\"/>\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:image\" content=\"" + _imgUrl.Replace("/big/", "/mid2/") + "\" />\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:url\" content=\"https://tweebaa.com/Product/saleBuy.aspx?id=" + _proid + "\"/>\n";
            sFacebookMetaTag = sFacebookMetaTag + "<meta property=\"og:description\" content=\"" + strShortDesc + "\" />";
            sMetaTag = sMetaTag + sFacebookMetaTag;


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
                strVideoCode = strVideoCode + "Sorry, your browser doesn't support embedded videos, ";
                strVideoCode = strVideoCode + "but don't worry, you can <a href=\"videofile.ogg\">download it</a>";
                strVideoCode = strVideoCode + "and watch it with your favorite video player!";
                strVideoCode = strVideoCode + "</video>";
            }

            int passCount = new Twee.Mgr.ReviewMgr().GetReviewCountByProid(_proid);//后台统计得出
            int Count = 300;//后台设计的标准
            _passCount = passCount.ToString();

            _iProgress = (int)Math.Round((double)passCount * 100 / Count, 0);
            if (_iProgress < 1) _iProgress = 1;
            /*
                if (passCount < 100)
                {
                    percent = (double)(percent * 0.55);
                }
                else if (passCount <= 200 && passCount >= 100)
                {
                    percent = (double)(percent * 0.8);
                }
                else
                {
                    percent = (double)(percent * 0.9);
                }
                */

            if (userGuid != null)
            {
                _favorite = new Twee.Mgr.FavoriteMgr().Exists(_prdGuid, (System.Guid)userGuid);
            }

            if (userGuid != null)
            {
                ReviewMgr reviewMgr = new ReviewMgr();
                string reviewComment = string.Empty;
                int resu = reviewMgr.HaveReviewed(prdID.ToGuid().Value, userGuid.Value);

                if (resu == 0)
                {
                    _disabled = "disabled='disabled'";
                    //_placeholder = "You have evaluated the product.";
                    _sDispAlreadyEvaluated = "display:block";
                    _sHideAlreadyEvaluated = "display:none";
                    _sAlreadyEvaluatedMsg = "You have evaluated this product.";
                }
                else if (resu == 1)
                {
                    _disabled = "disabled='disabled'";
                    //_placeholder = "You have evaluated 10 products today.";
                    _sDispAlreadyEvaluated = "display:block";
                    _sHideAlreadyEvaluated = "display:none";
                    _sAlreadyEvaluatedMsg = "You have evaluated 10 products today.";
                }


                string sYesNo = reviewMgr.GetReviewedYesNo(prdID.ToGuid().Value, userGuid.Value, out reviewComment);
                if (!string.IsNullOrEmpty(sYesNo))
                {
                    List<int> iYesNoList = sYesNo.Split(',').Select(Int32.Parse).ToList();
                    foreach (int i in iYesNoList)
                    {
                        _sYesNoArr[i - 1] = " checked ";
                    }
                    _placeholder = reviewComment;
                }
            }
        }
    }
}