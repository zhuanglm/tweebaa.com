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
    public partial class admPrdSpec : System.Web.UI.UserControl
    {
        string pguid = "";
        Guid guid;
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
                pguid = Request.QueryString["id"].ToString();
                guid = new Guid(pguid);
                PrdSpecMgr spec = new PrdSpecMgr();

                DataTable dtSpec = spec.MgeGetList(pguid);
                if (dtSpec.Rows.Count == 0)
                {
                    DataRow dr = dtSpec.NewRow();
                    dtSpec.Rows.Add(dr);
                }
                repPrice.DataSource = dtSpec;
                repPrice.DataBind();

            }

        }

        public void SaveData()
        {
            try
            {

                string pguid = Request.QueryString["id"].ToString();
                Guid guidprd = new Guid(pguid);
                PrdSpecMgr spec = new PrdSpecMgr();

                //保存规格

                spec.MgeDelete(guidprd);
                string data = txtData2.Value;//1,2,3;11,22,33;
                string colorData = txtColor.Value;

                string[] strData = data.Split(';');
                string[] strColor = colorData.Split(';');
                for (int i = 0; i < strData.Length - 1; i++)
                {
                    string[] rowData = strData[i].Split(',');
                    for (int j = 0; j < strColor.Length - 1; j++)
                    {
                        //多个颜色分开插入
                        //string[] rowColor = strColor[j].Split(',');
                        //for (int f = 0; f < rowColor.Length; f++)
                        //{
                        //    Guid colorGuid = new Guid(rowColor[f].ToString());
                        //    spec.Add(guidprd, colorGuid, rowData[0].ToString(), rowData[1].ToString(), rowData[2].ToString().ToInt());
                        //}               

                    }
                    //多个颜色一起插入
                    if (string.IsNullOrEmpty(rowData[0]) || string.IsNullOrEmpty(rowData[1].ToString()))
                    {
                        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('请输入规格名成和规格值')", true);
                        return;
                    }
                    spec.MgeAdd(guidprd, strColor[i], rowData[0].ToString(), rowData[1].ToString(), rowData[2].ToString().ToInt());

                }
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert1", "alert('修改成功')", true);

            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "alert2", "alert('修改成功')", true);

            }


        }

        protected void repPrice_DataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int ret = 0;
                CheckBoxList ckbColor = e.Item.FindControl("ckbColor2") as CheckBoxList;
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                //for (int i = 0; i < ckbColor.Items.Count; i++)
                //{
                //    ckbColor.Items[i].Attributes.Add("onclick", "javascript:onchecked('" + ckbColor.Items[i].Value + "',this.checked);");
                //}



                string specname = rowv["specname"].ToString();
                string specvalue = rowv["specvalue"].ToString();


                PrdSpecMgr spec = new PrdSpecMgr();
                DataTable dtSpecColor = spec.MgeGetSpecColor(guid, specname, specvalue);

                //绑定产品颜色
                PrdColorMgr color = new PrdColorMgr();
                DataTable dtPrdColor = color.MgeGetPrdColor(pguid);
                ckbColor.DataTextField = "colorname";
                ckbColor.DataValueField = "colorguid";
                ckbColor.DataSource = dtPrdColor;
                ckbColor.DataBind();



                //foreach (DataRow dr in dtSpecColor.Rows)
                //{
                //    string specColor = dr["colorguid"].ToString();
                //    if (!string.IsNullOrEmpty(specColor))
                //    {
                //        var resu = from rowc in dtPrdColor.AsEnumerable() where rowc["colorguid"] == specColor select rowc;
                //        if (resu != null)
                //        {
                //            ckbColor.Items.FindByValue(specColor).Selected = true;
                //        }
                //    }

                //}

                foreach (DataRow dr in dtSpecColor.Rows)
                {
                    string[] specColors = dr["colorguid"].ToString().Split(',');
                    for (int i = 0; i < specColors.Length; i++)
                    {
                        string specColor = specColors[i].ToString();
                        if (!string.IsNullOrEmpty(specColor))
                        {
                            var resu = from rowc in dtPrdColor.AsEnumerable() where rowc["colorguid"] == specColor select rowc;
                            if (resu != null)
                            {
                                if (ckbColor.Items.FindByValue(specColor) != null)
                                {
                                    ckbColor.Items.FindByValue(specColor).Selected = true;
                                }

                            }
                        }

                    }

                }

                string checkListValue = "";
                string checkListText = "";
                for (int i = 0; i < ckbColor.Items.Count; i++)
                {
                    checkListValue += ckbColor.Items[i].Value + ",";
                    checkListText += ckbColor.Items[i].Text + ",";
                }
                checkListText = checkListText.TrimEnd(',');
                checkListValue = checkListValue.TrimEnd(',');
                //由于checkboxlist在前台html页面表现中没有value属性，导致js无法获取选种的value值
                //这里用程序来添加value和text属性
                ckbColor.Attributes["ListValue"] = checkListValue;
                ckbColor.Attributes["ListText"] = checkListText;


            }

        }
    
    }
}