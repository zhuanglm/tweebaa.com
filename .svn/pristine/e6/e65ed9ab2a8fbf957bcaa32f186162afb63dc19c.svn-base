using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage
{
    public partial class admCashLst : System.Web.UI.Page
    {
        private static int pageSize = ConfigParamter.pageSize;
        protected void Page_Load(object sender, EventArgs e)
        {
            gridData.Attributes.Add("style", "word-break:break-word;word-wrap:break-all;");
            if (!IsPostBack)
            {
                GetAll();
            }
        }
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            GetAll();
        }

        public void GetAll()
        {
            MoneyMgr money = new MoneyMgr();            
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startId = pageSize * pageIndex + 1;
            int endId = startId + pageSize - 1;


            DataTable dt = money.MgeGetListByPage("", txtName.Value.Trim(), txtEmail.Value.Trim(), ddlType.SelectedValue, txtDate1.Value.Trim(), txtDate2.Value.Trim(), ddlState.SelectedValue, startId, endId, "");
            if (dt != null)
            {
                gridData.DataSource = dt;
                gridData.DataBind();
            }

            AspNetPager1.RecordCount = money.MgeGetRecordCount("", txtName.Value.Trim(), txtEmail.Value.Trim(), ddlType.SelectedValue, txtDate1.Value.Trim(), txtDate2.Value.Trim(), ddlState.SelectedValue, startId, endId, "");

            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });

        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAll();
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAll();
        }
        protected void gridData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

            }
        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            GetAll();
        }
        public string GetState(string state)
        {
            switch (state)
            {
                case "0":
                    return "未提取";
                case "1":
                    return "已提取";
                case "-1":
                    return "已拒绝";
                default:
                    return "无";

            }


        }
    }
}