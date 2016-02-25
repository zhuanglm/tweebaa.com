using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.Data;
using Twee.Comm;
namespace TweebaaWebApp2.Home
{
    public partial class HomeProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Guid? userGuid = Twee.Comm.CommUtil.IsLogion();           

                //等级
                UserGradeCalMgr gradeCal = new UserGradeCalMgr();
                DataTable dt = gradeCal.GetUserGrade(userGuid);
            
                int iPublishLevel = Int32.Parse(dt.Rows[0]["publishgrade"].ToString());
                int iReviewLevel = Int32.Parse(dt.Rows[0]["reviewgrade"].ToString());
                string s = dt.Rows[0]["sharegrade"].ToString();
                if (s.Length < 1) s = "0";
                int iShareLevel = Int32.Parse(s);
                if (iPublishLevel == 0) iPublishLevel = 1;
                if (iReviewLevel == 0) iReviewLevel = 1;
                if (iShareLevel == 0) iShareLevel = 1;

            
                labSubLevel.Text = iPublishLevel.ToString();
                labEvaluateLevel.Text = iReviewLevel.ToString();
                labShareLevel.Text = iShareLevel.ToString();

                labSubPoint.Text = dt.Rows[0]["publishintegral"].ToString();
                labEvaluatePoint.Text = dt.Rows[0]["reviewintegral"].ToString();
                labSharePoint.Text = dt.Rows[0]["shareintegral"].ToString();

                labSubRat.Text = "0." + dt.Rows[0]["pratio"].ToString() + "%";
                labEvaluateRat.Text = "0." + dt.Rows[0]["rratio1"].ToString() + "%";           
                labShareRat.Text = dt.Rows[0]["sratio"].ToString().ToDecimal() / 10 + "%";

                Twee.Mgr.ProfitMgr profitMgr = new Twee.Mgr.ProfitMgr();
                DataTable dt2 = profitMgr.GetTweebuck(userGuid.Value);
                if (dt2 != null && dt2.Rows.Count > 0)
                {
                    decimal extractionTweebuck = dt2.Rows[0]["ExtractionTweebuck"].ToString().ToDecimal();//可使用的tweebucks
                    labSumCash.Text = extractionTweebuck.ToString();//当前总剩余可用tweebucks
                    labSumCash2.Text = labSumCash.Text;
                }


                Twee.Model.Usergrade userGrade = gradeCal.GetModel(userGuid.Value);
                labSumShop.Text = userGrade.shopingPoint.Value.ToString();
                labSumShop2.Text = Math.Round(userGrade.shopingPoint.Value * 0.0125M, 2).ToString();

            }
        }
    }
}