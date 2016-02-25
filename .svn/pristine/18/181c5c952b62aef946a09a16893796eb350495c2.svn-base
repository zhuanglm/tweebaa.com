using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;

namespace TweebaaWebApp2.Manage
{
    public partial class admPrd : System.Web.UI.Page
    {
        private static int pageSize = ConfigParamter.pageSize;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //AspNetPager1.PageSize = ConfigParamter.pageSize;
                //BindData();
            }
        }
        //搜索
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            //BindData();      

        }
        //产品控件传参     0 全部，1评审区，2预售区，3销售区
        private void BindData()
        {
            // PrdMgr prd = new PrdMgr();   
            // string prdName=txtName.Value.Trim();
            // string user = txtUser.Value.Trim();
            // int index= AspNetPager1.CurrentPageIndex-1;
            // if (ddlType.SelectedIndex==0)
            // {
            //     Product0.GetAll(prdName, user, "",index);
            //     AspNetPager1.RecordCount = prd.GetListReviewCount(prdName, user, "");//总数
            // }
            // else if (ddlType.SelectedIndex==1)
            // {
            //     Product1.GetAll(prdName, user, "1", index);
            //     AspNetPager1.RecordCount = prd.GetListReviewCount(txtName.Value, txtUser.Value, "1");
            // }
            // else if (ddlType.SelectedIndex == 2)
            // {
            //     Product2.GetAll(prdName, user, "2", index);
            //     AspNetPager1.RecordCount = prd.GetListReviewCount(txtName.Value, txtUser.Value, "2");
            // }
            // else if (ddlType.SelectedIndex == 3)
            // {
            //     Product3.GetAll(prdName, user, "3", index);
            //     AspNetPager1.RecordCount = prd.GetListReviewCount(txtName.Value, txtUser.Value, "3");
            // }
            //// AspNetPager1.PageCount = AspNetPager1.RecordCount / AspNetPager1.PageSize;

            // this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, pageSize });
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AspNetPager1.CurrentPageIndex = 1;
            //BindData();
            //if (ddlType.SelectedIndex==0)
            //{
            //    Product0.Visible = true;
            //    Product1.Visible = false;
            //    Product2.Visible = false;
            //    Product3.Visible = false;
            //}
            //else if(ddlType.SelectedIndex==1)
            //{
            //    Product0.Visible = false;
            //    Product1.Visible = true;
            //    Product2.Visible = false;
            //    Product3.Visible = false;        
            //}
            // else if(ddlType.SelectedIndex==2)
            //{
            //    Product0.Visible = false;
            //    Product1.Visible = false;
            //    Product2.Visible = true;
            //    Product3.Visible = false;

            //}
            //else if (ddlType.SelectedIndex == 3)
            //{
            //    Product0.Visible = false;
            //    Product1.Visible = false;       
            //    Product2.Visible = false;
            //    Product3.Visible = true;

            //}
        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            //AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            //BindData();
        }
    }
}