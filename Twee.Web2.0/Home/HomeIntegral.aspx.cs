using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using System.Data;

namespace TweebaaWebApp2.Home
{
    public partial class HomeIntegral : System.Web.UI.Page
    {
        public float f1;
        public float f2;
        public float f3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid? useGuid = CommUtil.IsLogion();
                if (useGuid != null)
                {
                    Twee.Mgr.UserGradeCalMgr mgr = new Twee.Mgr.UserGradeCalMgr();
                    DataTable dt = mgr.GetUserGrade(useGuid.Value);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //发布者
                        int iPublishLevel = Int32.Parse(dt.Rows[0]["publishgrade"].ToString());
                        if (iPublishLevel == 0) iPublishLevel = 1;
                        labPGrade.Text = iPublishLevel.ToString();//等级

                        //labPGrade.Text = dt.Rows[0]["publishgrade"].ToString();//等级
                        labPIntegral.Text = dt.Rows[0]["publishintegral"].ToString();//积分
                        //labPIntegralRemove.Text = dt.Rows[0][""].ToString();
                        labPRatio.Text = (dt.Rows[0]["pratio"].ToString().ToDecimal() / 100).ToString();//佣金比例


                        //评审者
                        int iReviewLevel = Int32.Parse(dt.Rows[0]["reviewgrade"].ToString());
                        if (iReviewLevel == 0) iReviewLevel = 1;
                        labRGrade.Text = iReviewLevel.ToString();//等级

                        //labRGrade.Text = dt.Rows[0]["reviewgrade"].ToString();//等级
                        labRIntegral.Text = dt.Rows[0]["reviewintegral"].ToString();//积分
                        //labRIntegralRemove.Text = dt.Rows[0][""].ToString();
                        labRRatio.Text = (dt.Rows[0]["rratio1"].ToString().ToDecimal() / 100).ToString();//佣金比例


                        //分享者
                        int iShareLevel = 0;
                        if (!DBNull.Value.Equals(dt.Rows[0]["sharegrade"])) iShareLevel = Int32.Parse(dt.Rows[0]["sharegrade"].ToString());
                        if (iShareLevel == 0) iShareLevel = 1;
                        labSGrade.Text = iShareLevel.ToString();//等级

                        //labSGrade.Text = dt.Rows[0]["sharegrade"].ToString();//等级
                        labSIntegral.Text = dt.Rows[0]["shareintegral"].ToString();//积分
                        //labSIntegralRemove.Text = dt.Rows[0][""].ToString();
                        labSRatio.Text = (dt.Rows[0]["sratio"].ToString().ToDecimal() / 10).ToString();//佣金比例
                        decimal iShoppingPoint = 0M;
                        if (!DBNull.Value.Equals(dt.Rows[0]["shopingpoint"])) iShoppingPoint = dt.Rows[0]["shopingpoint"].ToString().ToDecimal();
                        //labAvailablePoint.Text = iShoppingPoint.ToString();
                        //labSumShop2.Text = Math.Round(iShoppingPoint * 0.0125M, 2).ToString();

                        f1 = (float)iPublishLevel * 100 / 10;
                        f2 = (float)iReviewLevel * 100 / 10;
                        f3 = (float)iShareLevel * 100 / 10;

                    }
                }
            }

        }
    }
}