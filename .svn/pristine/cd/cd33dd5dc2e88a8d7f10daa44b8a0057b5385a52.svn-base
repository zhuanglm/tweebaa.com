using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Mgr;

namespace TweebaaWebApp2.Manage
{
    public partial class admPrdCate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                RpTypeBind();
            }

        }


        private void RpTypeBind()
        {

            PrdCateMgr prdCate = new PrdCateMgr();
            rptypelist1.DataSource = prdCate.MgeGetPrdCateList("layer=0 order by idx asc");
            rptypelist1.DataBind();


        }
        protected void rptypelist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            PrdCateMgr prdCate = new PrdCateMgr();
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("rptypelist2") as Repeater;
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                string typeid = rowv["guid"].ToString();
                rep.DataSource = prdCate.MgeGetPrdCateList("layer=1 and prtGuid='" + typeid + "' order by idx asc");
                rep.DataBind();
            }
        }

        [System.Web.Services.WebMethod]
        public static string DeleteCate(string id)
        {
            Guid guid = new Guid(id);
            PrdCateMgr prdCate = new PrdCateMgr();
            bool resu = prdCate.MgeDeleteCate(guid);
            if (resu == true)
            {
                return "删除成功!";
            }
            else
            {
                return "删除失败!";
            }


        }
    }
}