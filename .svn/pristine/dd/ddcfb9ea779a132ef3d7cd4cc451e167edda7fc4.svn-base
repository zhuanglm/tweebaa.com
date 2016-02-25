using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Model;
using System.Text;
using Twee.Comm;
using System.Text;
using Twee.Comm;
using System.Xml.Linq;
using System.Data;
using System.Xml;

namespace TweebaaWebApp2.AjaxPages
{
    public partial class getPrdCate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["layer"]))
            {
                string layer = Request.QueryString["layer"].ToString();
                if (int.Parse(layer) == -1)
                {
                    GetPrdCateTree(); //Add by Long
                }
                else
                {

                    GetPrdCate();
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    BindPrdCate(Request.QueryString["id"].ToString());
                }
            }
           
        }

        private void GetPrdCateTree()
        {
            String strCacheFile = Server.MapPath("~" + "/cache/category.xml");
            //check file existings
            if (System.IO.File.Exists(strCacheFile))
            {
                //read the cache file
                //XmlTextReader reader = new XmlTextReader(strCacheFile);
                string contents = System.IO.File.ReadAllText(strCacheFile);
                Response.Write(contents);
            }
            else
            {
                StringBuilder strSql0 = new StringBuilder();
                strSql0.Append("SELECT  guid, name FROM wn_prdCate WHERE        (layer = 0) order by name");
                DataSet ds = DbHelperSQL.Query(strSql0.ToString());
                XElement xml = new XElement("ProductCategory");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //二级目录
                    //XElement xml_0 = new XElement("category_1");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //get total products from this category
                        String sPrdCount = "select count(*) as iTotal from wn_prd2cate where categuid1='" + ds.Tables[0].Rows[i]["guid"] + "'";
                        DataSet ds_prd = DbHelperSQL.Query(sPrdCount.ToString());
                        String sTotal = ds_prd.Tables[0].Rows[0]["iTotal"].ToString();

                        XElement XmlCatID = new XElement("category_1", new XAttribute("category_guid", ds.Tables[0].Rows[i]["guid"]), new XAttribute("category_count", sTotal), new XAttribute("category_name", ds.Tables[0].Rows[i]["name"]));
                        xml.Add(XmlCatID);

                        StringBuilder strSql1 = new StringBuilder();
                        strSql1.Append("SELECT    guid, name FROM   wn_prdCate WHERE   prtGuid='" + ds.Tables[0].Rows[i]["guid"] + "' order by name");
                        DataSet ds1 = DbHelperSQL.Query(strSql1.ToString());
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            //三级目录
                            for (int j = 0; j < ds1.Tables[0].Rows.Count; j++)
                            {
                                XElement XmlCatID1 = new XElement("category_2", new XAttribute("category_guid", ds1.Tables[0].Rows[j]["guid"]),
                                    new XAttribute("category_name", ds1.Tables[0].Rows[j]["name"]));
                                XmlCatID.Add(XmlCatID1);
                                StringBuilder strSql2 = new StringBuilder();

                                strSql2.Append("SELECT    guid, name FROM   wn_prdCate WHERE   prtGuid='" + ds1.Tables[0].Rows[j]["guid"] + "' order by name");
                                DataSet ds2 = DbHelperSQL.Query(strSql2.ToString());
                                for (int k = 0; k < ds2.Tables[0].Rows.Count; k++)
                                {
                                    XElement XmlCatID2 = new XElement("category_3", new XAttribute("category_guid", ds2.Tables[0].Rows[k]["guid"]),
                                        new XAttribute("category_name", ds2.Tables[0].Rows[k]["name"]));
                                    XmlCatID1.Add(XmlCatID2);


                                }
                            }
                        }
                    }

                }
                //context.Response.Write(sXMLTag);
                Response.Write(xml);
                xml.Save(strCacheFile);
            }
            //context.Response.Write(System.Environment.NewLine);          

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
                    if (prtGuid != "-1" && prtGuid !="undefined")  where += " and prtGuid='" + prtGuid + "'";
                }

                // cache first layer category jason
                XMLCache xmlCache = new XMLCache();
                string sCacheFile = "ProductCategoryLayer0_" + xmlCache.GetDateString();
                if (layer == "0")
                {
                    if (xmlCache.IsJsonFileExists(sCacheFile))
                    {
                        // Twee.Comm.CommHelper.WrtLog("111111111");
                        xmlCache.ReadCacheJson(this.Context, sCacheFile);
                        return;
                    }
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
                string sData = "[" + sb.ToString() + "]";
                Response.Write(sData);
                if (layer == "0")
                {
                    xmlCache.WriteJsonFile(Context, sData, sCacheFile);
                }
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

            // if no category is hidden 
            Guid levelOneGuid = (Guid)(CommUtil.GetDummyGuid().ToGuid());//一级类别
            Guid levelTwoGuid = (Guid)(CommUtil.GetDummyGuid().ToGuid());
            if (cateGuid != CommUtil.GetDummyGuid())
            {
            
                string where = " guid='"+cateGuid+"'";               
                Twee.Mgr.PrdCateMgr mgr = new Twee.Mgr.PrdCateMgr();
                List<PrdCate> listModel = mgr.GetModelList(where);

                PrdCate model = mgr.GetModel(cateGuid.ToGuid().Value);
                levelTwoGuid = model.prtGuid;//二级类别
                model = mgr.GetModel(levelTwoGuid);
                levelOneGuid = model.prtGuid;//一级类别
            }

            List<PrdCate> listModel0 = GetCateList(0, "");//得到一级列表
            List<PrdCate> listModel1 = GetCateList(1, levelOneGuid.ToString());//得到二级列表
            List<PrdCate> listModel2 = GetCateList(2, levelTwoGuid.ToString());//得到三级列表

            StringBuilder str1 = new StringBuilder("listModel0:[");
            for (int i = 0; i < listModel0.Count; i++)
            {
                string json = "{" + string.Format("id:'{0}',name:'{1}'", listModel0[i].guid, listModel0[i].name.Replace("'", "\\'")) + "}";
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
                string json = "{" + string.Format("id:'{0}',name:'{1}'", listModel1[i].guid, listModel1[i].name.Replace("'", "\\'")) + "}";
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
                string json = "{" + string.Format("id:'{0}',name:'{1}'", listModel2[i].guid, listModel2[i].name.Replace("'", "\\'")) + "}";
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