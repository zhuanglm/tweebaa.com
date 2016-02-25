using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.Text;
using System.Data;
using Twee.Comm;

namespace TweebaaWebApp2.Mgr.proTypeMgr
{
    public partial class proCateAddMgr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string guid = Request.QueryString["guid"].ToNullString();
                string prtGuid = Request.QueryString["prtGuid"].ToNullString();
                string layer = Request.QueryString["layer"].ToNullString();

                BindType("0", "", parType0);//加载一级类别
                if (layer == "0")
                {
                    BindTypeByID0(guid, prtGuid, "0");//选中一级类别
                }

                if (layer == "1" && prtGuid != "")
                {
                    //BindType("1", prtGuid, parType1);//加载二级类别   
                    BindTypeByID0(guid, prtGuid, "1");//选中一级类别

                }
                if (layer == "2" && prtGuid != "")
                {
                    string rootGuid = GetRooPrtGuid(prtGuid);
                    BindTypeByID0(prtGuid, rootGuid, "1");//选中一级类别
                    BindType("1", rootGuid, parType1);//加载二级类别   
                    BindTypeByID0(guid, prtGuid, "2");//选中二级类别

                }

            }
        }
        /// <summary>
        /// 选中一级类别
        /// </summary>
        /// <param name="guid"></param>
        private void BindTypeByID0(string guid, string prtGuid, string layer)
        {
            PrdCateMgr prdCate = new PrdCateMgr();
            DataTable dt = prdCate.MgeGetPrdCateList("guid='" + guid + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                txtName.Value = dt.Rows[0]["name"].ToString();
                txtOrder.Value = dt.Rows[0]["idx"].ToString();

                if (layer == "0")
                {
                    parType0.Items[0].Selected = true;
                }
                else if (layer == "1" && prtGuid != "")
                {
                    if (parType0.Items.FindByValue(prtGuid) != null)
                    {
                        parType0.Items.FindByValue(prtGuid).Selected = true;
                    }
                }
                else if (layer == "2" && prtGuid != "")
                {
                    if (parType1.Items.FindByValue(prtGuid) != null)
                    {
                        parType1.Items.FindByValue(prtGuid).Selected = true;
                    }
                }

                btnAdd.Text = "修改";
            }
        }

        /// <summary>
        /// 绑定初始类别
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="prtGuid"></param>
        /// <param name="ddlType"></param>
        private void BindType(string layer, string prtGuid, DropDownList ddlType)
        {
            ddlType.Items.Clear();
            StringBuilder strWher = new StringBuilder("");
            if (!string.IsNullOrEmpty(layer))
            {
                strWher.Append(" layer=" + layer);
            }
            if (!string.IsNullOrEmpty(prtGuid))
            {
                strWher.Append(" and  prtGuid='" + prtGuid + "'");
            }
            //select guid,name,layer,prtGuid,idx,wnstate from dbo.wn_prdCate  where 1=1 
            PrdCateMgr prdCate = new PrdCateMgr();
            ddlType.DataTextField = "name";
            ddlType.DataValueField = "guid";
            ddlType.DataSource = prdCate.MgeGetPrdCateList(strWher.ToString());
            ddlType.DataBind();
            ddlType.Items.Insert(0, "无");

        }

        protected void parType_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindType("1", parType0.SelectedValue, parType1);

        }
        protected void parType1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string prtGuid = "";
            int layer = 0;
            if (parType0.SelectedIndex > 0)
            {
                layer = 1;
                prtGuid = parType0.SelectedValue;
            }
            if (parType1.SelectedIndex > 0)
            {
                layer = 2;
                prtGuid = parType1.SelectedValue;
            }

            PrdCateMgr prdCate = new PrdCateMgr();
            bool resu;
            if (btnAdd.Text == "修改")
            {
                if (!string.IsNullOrEmpty(Request.QueryString["guid"]))
                {
                    Guid guid = new Guid(Request.QueryString["guid"].ToString());
                    resu = prdCate.MgeUpdateCate(guid, txtName.Value.Trim(), layer, prtGuid, txtOrder.Value.ToInt());
                    if (resu == true)
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('修改成功')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('修改失败')", true);
                    }
                }

            }
            else
            {

                if (parType0.SelectedIndex == 0)
                {
                    resu = prdCate.MgeAddCate(Guid.NewGuid(), txtName.Value.Trim(), layer, null, txtOrder.Value.ToInt());
                }
                else
                {

                    resu = prdCate.MgeAddCate(Guid.NewGuid(), txtName.Value.Trim(), layer, prtGuid.ToString(), txtOrder.Value.ToInt());
                }
                if (resu == true)
                {

                    ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('添加成功')", true);
                }

            }
            if (parType0.SelectedIndex <= 0)
            {
                BindType("0", "", parType0);
            }
            else if (parType1.SelectedIndex <= 0)
            {
                BindType("1", "", parType1);
            }



        }

        /// <summary>
        /// 获取父级id
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        private string GetRooPrtGuid(string guid)
        {
            PrdCateMgr prdCate = new PrdCateMgr();
            DataTable dt = prdCate.MgeGetPrdCateList("guid='" + guid + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["prtGuid"].ToString();
            }
            return "";

        }
    }
}