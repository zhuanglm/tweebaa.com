using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using System.Data;

namespace TweebaaWebApp2.Manage.Inventory
{
    public partial class InventorySearch : System.Web.UI.Page
    {
        private static int pageSize = ConfigParamter.pageSize;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStatus();
                BindGv();
            }
        }

        private void BindStatus() { 
           //从配置文件类中拿状态数据
            Dictionary<int, string> statusDic = Twee.Comm.ConfigParamter.InventoryStateConfig;
            ListItem first = new ListItem() { Value="-1", Text="--请选择--"};
            ddlStatus.Items.Add(first);
            foreach (var item in statusDic) {
                ListItem op = new ListItem { Value=item.Key.ToString(),Text=item.Value.ToString()};
                ddlStatus.Items.Add(op);
            }
        }

        private void BindGv() {
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startIndex = pageSize * pageIndex + 1;
            int endIndex = startIndex + pageSize - 1;
            string proName = txtproName.Value;
            string status = ddlStatus.SelectedValue == "-1" ? "" : ddlStatus.SelectedValue;
            string startTime = txtDateStart.Value;
            string endTime = txtDateEnd.Value;
            Twee.Mgr.proDetailsMgr mgr = new Twee.Mgr.proDetailsMgr();
            int tatalCount = 0;
            DataTable dt = mgr.GetInventoryByPage(proName, startTime, endTime, status, "createtime", startIndex, endIndex, out tatalCount).Tables[0];
            AspNetPager1.RecordCount = tatalCount;
            gvData.DataSource = dt;
            gvData.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindGv();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindGv();
        }

        public static string GetState(string keyVal) {
            var dic = Twee.Comm.ConfigParamter.InventoryStateConfig;
            return dic.Where(s => s.Key.ToString() == keyVal.Trim()).Select(s => s.Value.Trim()).FirstOrDefault();
        }

    }
}