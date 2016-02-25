using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp.Manage
{
    public partial class admPrdReviewMain : System.Web.UI.Page
    {
        private static int flag = 0;
        private static int pageSize = ConfigParamter.pageSize;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AspNetPager1.PageSize = pageSize;
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string prdGuid = Request.QueryString["id"].ToString();
                    BindData(prdGuid);
                }
                else
                {
                    BindData("");
                }
            }
        }

        protected void btnSerch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string prdGuid = Request.QueryString["id"].ToString();
                BindData(prdGuid);
            }
            else
            {
                BindData("");
            }

        }
        protected void btnAll_Click(object sender, EventArgs e)
        {
            flag = 1;
            BindData("");
        }


        // public void BindData(string strWhere1, string strWhere2,string order,int satrtIndex,int endIndex)
        public void BindData(string prdGuid)
        {
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startId = pageSize * pageIndex + 1;
            int endId = startId + pageSize - 1;

            string pName = txtName.Value.Trim();
            string date1 = txtDate1.Value.Trim();
            string date2 = txtDate2.Value.Trim();
            string type = ddlType.SelectedValue;

            string strWhere1 = " 1=1 ";
            string strWhere2 = " 1=1 ";
            if (!string.IsNullOrEmpty(prdGuid) && flag == 0)
            {
                strWhere1 += " and prtguid='" + prdGuid + "'";
            }
            if (!string.IsNullOrEmpty(type))
            {
                strWhere1 += " and cmdtype='" + type + "'";
            }
            if (!string.IsNullOrEmpty(date1))
            {
                strWhere1 += " and T.edttime>='" + date1 + "'";
            }
            if (!string.IsNullOrEmpty(date2))
            {
                strWhere1 += " and T.edttime<='" + date2 + "'";
            }
            if (!string.IsNullOrEmpty(pName))
            {
                strWhere2 = " p.name='" + pName + "'";
            }

            ReviewMgr review = new ReviewMgr();
            DataTable dt = review.MgeGetAllReview(strWhere1, strWhere2, "edttime", startId, endId);
            gridData.DataSource = dt;
            gridData.DataBind();

            AspNetPager1.RecordCount = review.MgeGetAllReviewCount(strWhere1, strWhere2);
            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindData("");
        }

        public string GetType(object type)
        {
            if (type != null)
            {
                switch (type.ToString())
                {
                    case "0":
                        return "支持";
                    case "1":
                        return "反对";
                    default:
                        return "";
                }
            }
            return "";


        }
    }
}