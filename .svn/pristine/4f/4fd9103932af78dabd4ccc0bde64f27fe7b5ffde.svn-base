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
    public partial class AdmimManageStorage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }
        }
        private void GetData()
        {
            StoragMgr storag = new StoragMgr();
            DataTable dt = storag.MgeGetList(" ");
            gridData.DataSource = dt;
            gridData.DataBind();

        }

        protected void lkbDele_Click(object sender, EventArgs e)
        {
            StoragMgr storag = new StoragMgr();
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            Guid guid = new Guid(gridData.DataKeys[row].Value.ToString());
            bool resu = storag.MgeDelete(guid);
            if (resu)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('删除成功')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('删除失败')", true);
            }
            GetData();
        }


        //删除
        protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SendAreaMgr area = new SendAreaMgr();
            Guid guid = new Guid(gridData.DataKeys[e.RowIndex].Value.ToString());
            bool resu = area.MgeDelete(guid);
            if (resu)
            {
                //删除成功！
            }
            GetData();
        }
        /// <summary>
        /// 获取配送区域
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string GetSenaArea(string ids)
        {
            string areaStr = "";
            SendAreaMgr area = new SendAreaMgr();
            DataTable dt = area.MgeGetList("");
            var list = dt.AsEnumerable().Select(t => t.Field<Guid>("areaGuid")).ToList();
            string[] strIds = ids.Split(',');
            for (int i = 0; i < strIds.Length; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (strIds[i] == dt.Rows[j]["areaGuid"].ToString())
                    {
                        areaStr += "【" + dt.Rows[j]["areaName"].ToString() + "】 ";
                    }

                }
            }
            return areaStr;

        }     
    }
}