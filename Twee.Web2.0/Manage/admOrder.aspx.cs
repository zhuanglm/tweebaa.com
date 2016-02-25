using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp2.Manage
{
    public partial class admOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            BindData();
            //}

        }
        //搜索
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            //StringBuilder strWhere=new StringBuilder(" 1=1 ");
            //DateTime? beginTime=txtTime1.Text.ToDateTime();
            //DateTime? endTime=txtTime2.Text.ToDateTime();

            //if (beginTime!=null)
            //{
            //  strWhere.Append(" and a.addtime>='"+beginTime+"'"); 
            //}
            //if (endTime!=null)
            //{
            //  strWhere.Append(" and a.addtime<='"+endTime+"'"); 
            //}
            //if (txtCode.Text!="")
            //{
            //    string txt=txtCode.Text.Trim();
            //    if (ddlType.SelectedValue=="0")
            //    {
            //      strWhere.Append(" and a.guidno='"+txt+"'"); 
            //    }
            //    if (ddlType.SelectedValue=="1")
            //    {
            //      strWhere.Append(" and c.username='"+txt+"'"); 
            //    }
            //    if (ddlType.SelectedValue=="2")
            //    {
            //      strWhere.Append(" and a.reciveName='"+txt+"'"); 
            //    }

            //}
            //BindData(strWhere.ToString());

        }
        //导出
        protected void btnOutput_Click(object sender, EventArgs e)
        {


        }


        //订单控件传参    
        private void BindData()
        {
            //0 未支付，1待发货，2已发货，3已完成，-1 已作废

            Orders0.state = "";
            Orders1.state = "0";
            Orders2.state = "1";
            Orders3.state = "2";
            Orders4.state = "3";
            Orders5.state = "-1";
        }  
    }
}