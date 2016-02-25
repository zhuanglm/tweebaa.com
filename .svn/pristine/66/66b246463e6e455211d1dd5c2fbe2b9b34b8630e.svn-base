using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Mgr;

namespace TweebaaWebApp.Manage
{
    public partial class admPrdContentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string prdGuid = Request.QueryString["id"].ToString();
                    PrdMgr prd = new PrdMgr();
                    DataTable dt = prd.MgeGetPrdInfoByID(prdGuid);
                    if (dt.Rows.Count > 0)
                    {
                        txtDesc.InnerHtml = dt.Rows[0]["txtinfo"].ToString();
                    }
                    DataTable dtPic = prd.MgeGetPrdPic(prdGuid);
                    int count = dtPic.Rows.Count;
                    List<string> listUrl = new List<string>();
                    for (int i = 0; i < count; i++)
                    {
                        listUrl.Add("<img width='70' height='70' src='../" + dtPic.Rows[0]["fileurl"].ToString() + "'/><span class='dvTool' title='移出' onclick='$(this).prev().remove(); $(this).remove();load();'>X</span>");
                    }
                    if (count <= 5)
                    {
                        for (int j = 0; j < 5 - count; j++)
                        {
                            listUrl.Add("");
                        }
                    }
                    divPic0.InnerHtml = listUrl[0];
                    divPic1.InnerHtml = listUrl[1];
                    divPic2.InnerHtml = listUrl[2];
                    divPic3.InnerHtml = listUrl[3];
                    divPic4.InnerHtml = listUrl[4];

                    ScriptManager.RegisterStartupScript(this.UpdatePanel2, this.GetType(), "load", "load()", true);
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Guid guid = new Guid(Request.QueryString["id"].ToString());
            UpdatePic(guid);
            UpdatePrdContent(guid);

            ScriptManager.RegisterStartupScript(this.UpdatePanel2, this.GetType(), "load", "location.reload();", true);
        }

        /// <summary>
        /// 保存产品缩略图
        /// </summary>
        /// <param name="prdGuid"></param>
        private void UpdatePic(Guid prdGuid)
        {
            PrdMgr prd = new PrdMgr();
            string picStr = hidPic.Value.TrimStart(',');
            //prd.MgeUpdatePrdFile(prdGuid, picStr.Split(',').ToList<string>());
        }

        /// <summary>
        /// 保存产品详情
        /// </summary>
        /// <param name="prdGuid"></param>
        private void UpdatePrdContent(Guid prdGuid)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                PrdMgr prd = new PrdMgr();

                bool b = prd.MgeUpdatePrdContent(prdGuid, txtDesc.InnerHtml.ToString(), txtVideoUrl.Value.Trim());
                if (b)
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel2, this.GetType(), "alert1", "alert('修改成功')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.UpdatePanel2, this.GetType(), "alert2", "alert('修改失败')", true);
                }

            }

        }
    }
}