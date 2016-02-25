using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxPro;

namespace TweebaaWebApp.Mgr.proManager
{
    public partial class proTypeList : System.Web.UI.Page
    {
        Twee.Mgr.PrdCateMgr mgr = new Twee.Mgr.PrdCateMgr();
        public int pageSize = 30;
        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(proTypeList));
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            int pageIndex = AspNetPager1.CurrentPageIndex - 1;
            int startIndex = pageSize * pageIndex + 1;
            int endIndex = startIndex + pageSize - 1;
            string typeName = txtTypeName.Value.Trim();

            string where = " 1=1 ";
            if (!string.IsNullOrEmpty(typeName))
            {
                where += " and T.name like '%" + typeName + "%'";
            }
            
            AspNetPager1.RecordCount = mgr.GetRecordCount(string.Empty);
            var modelList = mgr.GetListByPage(where, "layer", startIndex, endIndex);
            Repeater1.DataSource = modelList;
            Repeater1.DataBind();
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            Bind();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Bind();
        }

        [AjaxPro.AjaxMethod]
        public string DeleteType(string guid)
        {
            if (string.IsNullOrEmpty(guid))
                return "fail";
            var id = Guid.Parse(guid);
            try
            {
                if (mgr.Delete(id))
                {
                    return "success";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

        [AjaxPro.AjaxMethod]
        public string UpdateTypeName(string guid, string name)
        {
            if (string.IsNullOrEmpty(guid) || string.IsNullOrEmpty(name))
                return "fail";
            try
            {
                if (mgr.UpdateTypeName(guid, name))
                {
                    return "success";
                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }

         [AjaxPro.AjaxMethod]
        public string GetSonTypeName(string parentId)
        { 
             List<string>list=mgr.GetSonTypeName(parentId);
             if (list == null || list.Count==0)
                 return "nodata";
             StringBuilder str = new StringBuilder();
             foreach (string s in list) {
                 str.AppendFormat("<tr><td class=\"title\">下一级类别：</td><td>{0}</td></tr>",s);
             }
             return str.ToString();
        }

    }
}