using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Twee.Comm;

namespace TweebaaWebApp2
{
    public partial class SpinLucky : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //StringBuilder sSql = new StringBuilder();
            /*
            sSql.Append("select CONVERT(VARCHAR(10), regtime, 101) as [Date],  count(*) as Count  from wn_user");
            sSql.Append(" group by  CONVERT(VARCHAR(10), regtime, 101)");
            sSql.Append(" order by [Date] desc ");
             * */
            string sSql = "SELECT   top 10     a.username, b.SpinDate, c.AppPrize_Text";
            sSql = sSql + " FROM            wn_user AS a INNER JOIN ";
            sSql = sSql + " wn_MobileAppSpinLucky AS b ON a.guid = b.UserGuid LEFT OUTER JOIN ";
            sSql = sSql + "  wn_mobileAppPrize AS c ON b.Spin_PrizeID = c.AppPrize_ID ";
            sSql = sSql + " ORDER BY b.SpinDate DESC";
            DataSet ds = DbHelperSQL.Query(sSql);
            if (ds == null || ds.Tables.Count == 0)
            {

            }
            else
            {

                DataTable dt = ds.Tables[0];
                /*
                int iTotal = 0;
                if (dt != null) iTotal = dt.Rows.Count;
                labTotal.Text = iTotal.ToString();
                */
                gvwTrackingReport.DataSource = dt;
                gvwTrackingReport.DataBind();
            }
        }
        protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwTrackingReport.PageIndex = e.NewPageIndex;
            gvwTrackingReport.DataBind();
        }
    }
}