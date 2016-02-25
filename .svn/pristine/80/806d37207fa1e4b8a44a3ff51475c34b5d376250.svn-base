using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Model;
using System.Text;
using Twee.Comm;

namespace TweebaaWebApp.AjaxPages
{
    public partial class getPrdCate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["layer"]))
            {
                GetPrdCate();
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    BindPrdCate(Request.QueryString["id"].ToString());
                }
            }
           
        }
        /// <summary>
        /// 获取类别列表
        /// </summary>
        private void GetPrdCate()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["layer"]))
            {
                string layer = Request.QueryString["layer"].ToString();

                string where = " layer=" + layer;
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    string prtGuid = Request.QueryString["id"].ToString().Trim();
                    if (prtGuid != "-1")  where += " and prtGuid='" + prtGuid + "'";
                }

                Twee.Mgr.PrdCateMgr mgr = new Twee.Mgr.PrdCateMgr();
                List<PrdCate> listModel = mgr.GetModelList(where);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < listModel.Count; i++)
                {
                    // the category name may contain single quote character, need to replace ' as \'
                    string json = "{" + string.Format("id:'{0}',name:'{1}'", listModel[i].guid, listModel[i].name.Replace("'","\\'")) + "}";
                    //sb.AppendFormat("{id:'{0}',name:'{1}'}", listModel[i].Id, listModel[i].First_kind_name);
                    sb.Append(json);
                    if (i != listModel.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                Response.Write("[" + sb.ToString() + "]");
            }               
        }

        /// <summary>
        /// 编辑产品时绑定类别
        /// </summary>
        private void BindPrdCate(string cateGuid)
        {

            if (string.IsNullOrEmpty(cateGuid)||cateGuid=="undefined")
            {
                Response.Write("");
                return;
            }

            // Now the category is hidden 
            if (cateGuid == "00000000-0000-0000-0000-000000000000")
            {
                Response.Write("");
                return;
            }
            
            string where = " guid='"+cateGuid+"'";               
            Twee.Mgr.PrdCateMgr mgr = new Twee.Mgr.PrdCateMgr();
            List<PrdCate> listModel = mgr.GetModelList(where);

            PrdCate model = mgr.GetModel(cateGuid.ToGuid().Value);
            Guid levelTwoGuid = model.prtGuid;//二级类别
            model = mgr.GetModel(levelTwoGuid);
            Guid levelOneGuid = model.prtGuid;//一级类别

            List<PrdCate> listModel0 = GetCateList(0, "");//得到一级列表
            List<PrdCate> listModel1 = GetCateList(1, levelOneGuid.ToString());//得到二级列表
            List<PrdCate> listModel2 = GetCateList(2, levelTwoGuid.ToString());//得到三级列表

            StringBuilder str1 = new StringBuilder("listModel0:[");
            for (int i = 0; i < listModel0.Count; i++)
            {
                string json = "{" + string.Format("id:'{0}',name:'{1}'", listModel0[i].guid, listModel0[i].name.Replace("'","\\'")) + "}";
                str1.Append(json);
                if (i != listModel0.Count - 1)
                {
                    str1.Append(",");
                }
            }
            str1.Append("]");
            StringBuilder str2 = new StringBuilder("listModel1:[");
            for (int i = 0; i < listModel1.Count; i++)
            {
                string json = "{" + string.Format("id:'{0}',name:'{1}'", listModel1[i].guid, listModel1[i].name.Replace("'","\\'")) + "}";
                str2.Append(json);
                if (i != listModel1.Count - 1)
                {
                    str2.Append(",");
                }
            }
            str2.Append("]");
            StringBuilder str3 = new StringBuilder("listModel2:[");
            for (int i = 0; i < listModel2.Count; i++)
            {
                string json = "{" + string.Format("id:'{0}',name:'{1}'", listModel2[i].guid, listModel2[i].name.Replace("'","\\'")) + "}";
                str3.Append(json);
                if (i != listModel2.Count - 1)
                {
                    str3.Append(",");
                }
            }
            str3.Append("]");
            string str4 = "listModel3:[{'levelOneGuid':'" + levelOneGuid + "','levelTwoGuid':'" + levelTwoGuid + "','levelThreeGuid':'" + cateGuid + "'}]";
            string resu = "{" + str1 + "," + str2 + "," + str3 + "," + str4 + "}";
            Response.Write(resu);
        }

        /// <summary>
        /// 根据当前类别ID获取父类的等同级别和类型的类别
        /// </summary>
        /// <param name="layer">要获取的类别级别</param>
        /// <param name="prtGuid">要获取的类别的父类别</param>
        /// <returns></returns>
        private List<PrdCate> GetCateList(int layer, string prtGuid)
        {
            Twee.Mgr.PrdCateMgr mgr = new Twee.Mgr.PrdCateMgr();
            List<PrdCate> listModel = null;
            if (layer==0)
            {
                listModel = mgr.GetModelList(" layer=0 ");
            }
            else if (layer == 1 && !string.IsNullOrEmpty(prtGuid))
            {
                listModel = mgr.GetModelList(" layer=1 and prtGuid='" + prtGuid + "'");
            }
            else if (layer == 2 && !string.IsNullOrEmpty(prtGuid))
            {
                listModel = mgr.GetModelList(" layer=2 and prtGuid='" + prtGuid + "'");
            }
            return listModel;
        
        }
    }
}