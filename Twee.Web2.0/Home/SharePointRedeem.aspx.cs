using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp2.Home
{
    public partial class SharePointRedeem : TweebaaWebApp2.MasterPages.BasePage
    {
        private static int pageSize = 10;
        private Guid? userGuid;

        protected void Page_Load(object sender, EventArgs e)
        {
            bool isLogion = CheckLogion(out userGuid);
            if (null != userGuid)
            {
                // _userid = userGuid.ToString();
            }
            else
            {
                //go to user login
                var response = base.Response;
                response.Redirect("/User/login.aspx?op=SharePointRedeem");
            }
            if (!IsPostBack)
            {
                LoadData();
              //  BindData("", "", 0, "", "");
            }
        }

       
        
        private void LoadData()
        {
            //AspNetPager1.PageSize = pageSize;
            hidTotalPages.Value = pageSize.ToString();
            userGuid = Twee.Comm.CommUtil.IsLogion();

            //等级
            UserGradeCalMgr gradeCal = new UserGradeCalMgr();
           // Twee.Model.Usergrade userGrade = gradeCal.GetModel(userGuid.Value);
            DataTable dt = gradeCal.GetUserGrade(userGuid.Value);
            labAvailablePoints.Text = dt.Rows[0]["shareintegral"].ToString();
            labTotalRedeem.Text = gradeCal.GetUserTotalSharePointRedeem(userGuid.Value);
            /*
            Twee.Mgr.ProfitMgr mgr = new Twee.Mgr.ProfitMgr();
            //已经领取的收益                
            //string havedShouYiSum = mgr.HaveedShouYiSum(userGuid.ToString());
            //if (string.IsNullOrEmpty(havedShouYiSum))
            //    havedShouYiSum = "0";
            //还没有领取的收益
            //string notHaveShouYiSum = mgr.NotHaveShouYiSum(userGuid.ToString());
            //if (string.IsNullOrEmpty(notHaveShouYiSum))
            //    notHaveShouYiSum = "0";

            DataTable dtPending = mgr.GetPendingTweebuck(userGuid.Value);
            if (dtPending != null && dtPending.Rows.Count > 0)
            {
                labPendingTweebuck.Text = dtPending.Rows[0]["PendingTweebuck"].ToString();//将获取的收益
            }
            DataTable dt = mgr.GetTweebuck(userGuid.Value);
            decimal decAvailableBalance = 0m;
            if (dt != null && dt.Rows.Count > 0)
            {
                decimal extractionTweebuck = dt.Rows[0]["ExtractionTweebuck"].ToString().ToDecimal();//可使用的tweebucks
                labAvailableBalance.Text = extractionTweebuck.ToString();//当前总剩余可用tweebucks
                labAvailableBalanceValue.Text = extractionTweebuck.ToString();//当前总剩余可用tweebucks
                decAvailableBalance = extractionTweebuck.ToString().ToDecimal();
            }
            DataSet ds = mgr.GetTweebuckOther(userGuid.Value);
            if (ds.Tables.Count == 2)
            {
                decimal decApplication = 0m; //申请中
                decimal decExtracted = 0m;   //已提取
                if (ds.Tables[0].Rows[0][0].ToNullString() != "") decApplication = ds.Tables[0].Rows[0][0].ToNullString().ToDecimal();
                if (ds.Tables[1].Rows[0][0].ToNullString() != "") decExtracted = ds.Tables[1].Rows[0][0].ToNullString().ToDecimal();

                decimal decTotalWithDraw = decApplication + decExtracted;
                decimal decTotalEarn = decTotalWithDraw + decAvailableBalance;//总收益

                labTotalWithdraw.Text = decTotalWithDraw.ToString("#0.00");//已经提取
                labTotalWithdrawValue.Text = decTotalWithDraw.ToString("#0.00");

                labTotalEarn.Text = decTotalEarn.ToString("#0.00");//总收益
                labTotalEarnValue.Text = decTotalEarn.ToString("#0.00");


                //labApplication.Text = ds.Tables[0].Rows[0][0].ToNullString() == "" ? "0.00" : ds.Tables[0].Rows[0][0].ToNullString();//申请中
                //labApplicationValue.Text = ds.Tables[0].Rows[0][0].ToNullString() == "" ? "0.00" : ds.Tables[0].Rows[0][0].ToNullString();//申请中
                //labExtracted.Text = ds.Tables[1].Rows[0][0].ToNullString() == "" ? "0.00" : ds.Tables[1].Rows[0][0].ToNullString();//已提取
                //labExtractedValue.Text = ds.Tables[1].Rows[0][0].ToNullString() == "" ? "0.00" : ds.Tables[1].Rows[0][0].ToNullString();//已提取
            }
            */

        }
        

        /// <summary>
        /// 获取产品图片路径
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public string GetPic(string img)
        {
            string strHost = System.Configuration.ConfigurationManager.AppSettings["prdImgDomain"].ToString();
            img = strHost + img.Replace("big", "small");
            return img;
        }

        /// <summary>
        /// Escape string
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public string Escape(string s)
        {
            string sEncoded = HttpUtility.UrlEncode(s);
            return sEncoded;
        }

        //protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        //{
        //    AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        //    string type = "";
        //    if (ckb2.Checked)
        //    {
        //        type = "发布收益";
        //    }
        //    if (ckb3.Checked)
        //    {
        //        type = "评审收益";
        //    }
        //    if (ckb4.Checked)
        //    {
        //        type = "分享收益";
        //    }
        //    BindData(type, txtName.Value.Trim());
        //}

        //[AjaxPro.AjaxMethod]
        //public string ApplyCash(string ids)
        //{
        //    try
        //    {
        //        string[] idsArray = ids.Split(',');
        //        StringBuilder str = new StringBuilder();
        //        foreach (string item in idsArray)
        //        {
        //            str.AppendFormat(",'{0}'", item);
        //        }
        //        XmlDocument doc = new XmlDocument();
        //        string path = AppDomain.CurrentDomain.BaseDirectory + "App_Data/HomeConfig.xml";
        //        doc.Load(path);
        //        if (null == doc)
        //            return "error";
        //        XmlNode node = doc.SelectSingleNode("/home/config[@id='" + 1 + "']");
        //        decimal limitMoney = Convert.ToDecimal(node.Attributes["value"].Value);
        //        decimal selectMoney = Convert.ToDecimal(new Twee.Mgr.ProfitMgr().SelectApplyCash(str.ToString().Substring(1)));
        //        if (selectMoney > limitMoney)
        //            return "I'm sorry, the withdrawal of more than " + limitMoney.ToString() + " limit";
        //        new Twee.Mgr.ProfitMgr().ApplyCash(str.ToString().Substring(1));
        //        return "Congratulations, you have successfully apply for withdrawal";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "error";
        //    }
        //}

       

      
    }
}