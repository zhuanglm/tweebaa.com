using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TweebaaWebApp.MasterPages;
using Twee.Mgr;
using Twee.Model;
using Twee.Comm;

namespace TweebaaWebApp.Product
{
    public partial class submitReview : BasePage 
    {
        private Guid? userGuid;
        public string _userid = string.Empty;
       
        public string _proid = string.Empty;
        public string _leftMargin = string.Empty;//这里必须是一个百分比
        public string _passCount = string.Empty;//后台统计通过的人数
        public string _styleMarginLeft = string.Empty;//改变提示进度的位置
        public string _prdName = string.Empty;
        public string _prdDesc = string.Empty;
        public string _prdImageUrl = string.Empty;
        public Prd _model;
        public Guid _prdGuid ;
        public string _imgUrl = string.Empty;
        public string _disabled = "";
        public string _placeholder = "Please includes your reason or suggestion, each person can only evaluate once. (Max 200 characters)";
        public string _sCurVer = "0";
        public string[] _sYesNoArr = {string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty};

        public string _sDispAlreadyEvaluated = "display:none";
        public string _sAlreadyEvaluatedMsg = "";

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
            _imgUrl = "https://tweebaa.com/" + listFile[0].fileurl;
 
            _model = mgr.GetModel(_prdGuid);
 
            int passCount = new Twee.Mgr.ReviewMgr().GetReviewCountByProid(_proid);//后台统计得出
            int Count = 300;//后台设计的标准
            if (passCount == 0 || passCount>Count)
            {
                _leftMargin = "1%";//给出一个默认初始值以便显示进度条效果
                _passCount = passCount.ToString();
            }
            else if(passCount<=Count)
            {
                double temp = ((double)passCount) / Count;
                double percent = Math.Round(temp, 1);
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
                _leftMargin = (percent * 100).ToString() + "%";
                _passCount = passCount.ToString();
                if (passCount > 200) {
                    _styleMarginLeft = "margin-left:-80px;";
                }
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
                    _sAlreadyEvaluatedMsg = "You have evaluated the product.";
                }
                else if (resu == 1)
                {
                    _disabled = "disabled='disabled'";
                    //_placeholder = "You have evaluated 10 products today.";
                    _sDispAlreadyEvaluated = "display:block";
                    _sAlreadyEvaluatedMsg = "You have evaluated 10 products today.";
                }


                string sYesNo = reviewMgr.GetReviewedYesNo(prdID.ToGuid().Value, userGuid.Value, out reviewComment);
                if ( !string.IsNullOrEmpty(sYesNo))
                {
                    List<int> iYesNoList = sYesNo.Split(',').Select(Int32.Parse).ToList();
                    foreach (int i in iYesNoList)
                    {
                        _sYesNoArr[i - 1] = " checked ";
                    }
                    _placeholder = reviewComment;
                }
            }

            #region 产品访问记录

            CookiesHelper cookie = new Twee.Comm.CookiesHelper();
            if (userGuid != null)
            {
                VistLog visit = new VistLog();
                visit.prdID = prdID.ToString();
                visit.userId = userGuid.ToString();
                visit.addTime = DateTime.Now;
                VistLogMgr visitMgr = new VistLogMgr();
                visitMgr.Add(visit);
            }
            #endregion

        }
    }
}