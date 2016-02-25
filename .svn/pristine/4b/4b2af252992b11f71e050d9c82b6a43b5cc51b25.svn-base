using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;
using Twee.Mgr;


namespace TweebaaWebApp.Manage.Ascx
{
    public partial class admPrdBaseInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetData();
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            GetData();
        }

        public void GetData()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                string pguid = Request.QueryString["id"].ToString();
                PrdMgr prd = new PrdMgr();
                DataTable dtPrd = prd.MgeGetListSale(" p.prdguid='" + pguid + "'");
                DataTable dtPrice = prd.MgeGetPrdPrice(pguid);
                if (dtPrd != null && dtPrd.Rows.Count > 0)
                {
                    txtName.Text = dtPrd.Rows[0]["name"].ToString();
                    ListItem liState = ddlType.Items.FindByValue(dtPrd.Rows[0]["wnstat"].ToString());
                    if (liState != null)
                    {
                        ddlType.Items.FindByValue(dtPrd.Rows[0]["wnstat"].ToString()).Selected = true;
                    }
                }

                repPrice.DataSource = dtPrice;
                repPrice.DataBind();
                BindPrdType();

                PrdColorMgr color = new PrdColorMgr();
                ckbColor.DataTextField = "colorname";
                ckbColor.DataValueField = "colorguid";
                DataTable dtAllColor = color.MgeGetAllColor();
                ckbColor.DataSource = dtAllColor;
                ckbColor.DataBind();

                DataTable dtPrdColor = color.MgeGetPrdColor(pguid);
                foreach (DataRow dr in dtPrdColor.Rows)
                {
                    string pcolor = dr["colorguid"].ToString();
                    var resu = from rowc in dtAllColor.AsEnumerable() where rowc["colorguid"] == pcolor select rowc;
                    if (resu != null)
                    {
                        ckbColor.Items.FindByValue(pcolor).Selected = true;
                    }
                }

            }

        }

        public void SaveData()
        {
            try
            {
                //屏蔽：-1   评审：1  预售： 2  销售： 3

                string pguid = Request.QueryString["id"].ToString();
                Guid guidprd = new Guid(pguid);
                string prdName = txtName.Text.Trim();//产品名称
                int prdState = ddlType.SelectedValue.ToInt();//所在分区
                string prdCate = "";
                if (ddlType1.SelectedIndex != 0 && ddlType2.SelectedIndex != 0)
                {
                    prdCate = ddlType2.SelectedValue;
                }
                else if (ddlType1.SelectedIndex != 0 && ddlType2.SelectedIndex == 0)
                {
                    prdCate = ddlType1.SelectedValue;//产品类别
                }

                PrdMgr prd = new PrdMgr();
                prd.MgeUpdatePrd(guidprd, prdState, prdName, prdCate);

                //保存价格
                prd.MgeDeletPrdPrice(pguid);
                string data = txtData.Value;//1,2,3;11,22,33;
                string[] strData = data.Split(';');
                // string[] strSpecColor = txtColor.Value.Split(',');

                for (int i = 0; i < strData.Length - 1; i++)
                {
                    string[] rowData = strData[i].Split(',');
                    prd.MgeAddPrdPrice(guidprd, rowData[0].ToInt(), rowData[1].ToInt(), rowData[2].ToDecimal());
                }
                //for (int i = 0; i < table1.Rows.Count; i++)
                //{
                //    HtmlTableCell txtCount1 = table1.Rows[i].Cells[1].Controls[0] as HtmlTableCell;
                //    HtmlTableCell txtCount2 = table1.Rows[i].Cells[1].Controls[1] as HtmlTableCell;
                //    HtmlTableCell txtPrice = table1.Rows[i].Cells[2].Controls[0] as HtmlTableCell;
                //    prd.AddPrdPrice(pguid, txtCount1.InnerText.ToInt(), txtCount2.InnerText.ToInt(), txtPrice.InnerText.ToDecimal());
                //}
                //保存颜色
                
                PrdColorMgr prdColor = new PrdColorMgr();
                prdColor.MgeDeletePrdColor(pguid, "");
                List<string> listColor = new List<string>();
                for (int i = 0; i < ckbColor.Items.Count; i++)
                {
                    if (ckbColor.Items[i].Selected == true)
                    {
                        listColor.Add(ckbColor.Items[i].Value);
                        Guid guid1 = new Guid(ckbColor.Items[i].Value);
                        prdColor.MgeAddPrdColor(guidprd, guid1, ckbColor.Items[i].Text);
                    }
                }

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('保存成功')", true);
            }
            catch (Exception)
            {

                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('保存失败')", true);
            }


        }
        /// <summary>
        /// 一级分类
        /// </summary>
        /// <param name="pguid"></param>
        private void BindPrdType()
        {
             PrdCateMgr cate = new PrdCateMgr();
             DataTable dtCate1 = cate.MgeGetPrdCateList(" layer=0");
            ddlType1.DataTextField = "name";
            ddlType1.DataValueField = "guid";
            ddlType1.DataSource = dtCate1;
            ddlType1.DataBind();
            ddlType1.Items.Insert(0, "选择一级类别");

        }
        /// <summary>
        /// 二级分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrdCateMgr cate = new PrdCateMgr();
            DataTable dtCate1 = cate.MgeGetPrdCateList(" prtGuid='" + ddlType1.SelectedValue + "'");
            ddlType2.DataTextField = "name";
            ddlType2.DataValueField = "guid";
            ddlType2.DataSource = dtCate1;
            ddlType2.DataBind();
            ddlType2.Items.Insert(0, "选择二级类别");
        }
    }
}