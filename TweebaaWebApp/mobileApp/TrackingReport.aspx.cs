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

namespace TweebaaWebApp.mobileApp
{
    public partial class TrackingReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            StringBuilder sSql = new StringBuilder();
            /*
            sSql.Append("select CONVERT(VARCHAR(10), regtime, 101) as [Date],  count(*) as Count  from wn_user");
            sSql.Append(" group by  CONVERT(VARCHAR(10), regtime, 101)");
            sSql.Append(" order by [Date] desc ");
             * */
            sSql.Append("select * from wn_MobileAppTracking");
            sSql.Append(" order by TrackingDate desc ");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
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