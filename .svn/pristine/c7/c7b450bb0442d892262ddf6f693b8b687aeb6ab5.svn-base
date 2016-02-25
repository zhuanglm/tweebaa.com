using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace TweebaaWebApp2.Product
{
    public partial class Category : System.Web.UI.Page
    {


        public string strCateID = "";
        public string strKeyword = "";
        public string strLinks;
        public int iShowMain = 1;
        public string strCategoryCacheHTML = "";
        public int iCategoryLeval = 1;
        public string strCateIDLvl1 = "";
        public string strCateIDLvl2 = "";
        public string strCateIDLvl3 = "";



      



        protected void Page_Load(object sender, EventArgs e)
        {
            ///Product/Category.aspx/TV/idxxx
            string strCategory1 = "";
            string strCategory2 = "";
            string strCategory3 = "";
            string strFolder = Request.Path;
            //replace Children/Infant ==>Children%2fInfant
            strFolder = strFolder.Replace("Children/Infant", "Children and Infant");
            strFolder = strFolder.Replace("Green / Eco Products", "Green and Eco Products");

            //last char / ? remove it
            if (strFolder.Substring(strFolder.Length - 1, 1) == "/")
            {
                strFolder = strFolder.Substring(0, strFolder.Length - 1);
            }
            string[] folders = strFolder.Split('/');

            string strCategoryID1 = "";
            string strCategoryID2 = "";
            Twee.Mgr.PrdMgr mgr = new Twee.Mgr.PrdMgr();
            int iLength = folders.Length;
            if (iLength == 5)
            {
                //一级目录
                strCategory1 = folders[3];
                strCateID = folders[4];
                strCateIDLvl1 = strCateID;
                strLinks = "<li class=\"active\">" + Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 2) + "</li>";
                //strLinks = "<li class=\"active\">" + Name2URL(strCategory1) + "</li>";
                Twee.Comm.XMLCache cache = new Twee.Comm.XMLCache();
                //string strYear = cache.GetYearString();
                if (cache.IsHTMLFileExists("Category_" + strCateID))
                {
                    strCategoryCacheHTML = cache.ReadCacheHTML("Category_" + strCateID);
                }
                else
                {
                    DataTable dt = mgr.GetSubCategoryList(strCateID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strCategoryCacheHTML = strCategoryCacheHTML + "<div class='sub_category'><a href='/Product/Category.aspx/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 1)) + "/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(dt.Rows[i]["name"].ToString(), 1)) + "/" + strCateID + "/" + dt.Rows[i]["guid"] + "'>" + Twee.Comm.CommUtil.ReplaceSpecial(dt.Rows[i]["name"].ToString(), 1) + "</a></div>";
                        //strCategoryCacheHTML = strCategoryCacheHTML + "<div class='sub_category'><a href='/Product/Category.aspx/" + Name2URL(strCategory1) + "/" + Name2URL(dt.Rows[i]["name"].ToString()) + "/" + dt.Rows[i]["guid"] + "'>" + dt.Rows[i]["name"] + "</a></div>";
                    }
                    cache.WriteCahceHTML(strCategoryCacheHTML, "Category_" + strCateID);
                }
                iShowMain = 0;
                iCategoryLeval = 1;

            }
            if (iLength == 7)
            {
                //二级目录
                strCategory1 = folders[3];
                strCategory2 = folders[4];
                strCategoryID1 = folders[5];
                strCateID = folders[6];
                strCateIDLvl1 = strCategoryID1;
                strCateIDLvl2 = strCateID;
 
                //strCategoryID1 = mgr.GetCategoryIDbyName(ReplaceSpecial(strCategory1, 2));
                //strCategoryID1 = mgr.GetCategoryIDbyName(Name2URL(strCategory1));
                strLinks = "<li><a href=\"/Product/Category.aspx/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 1)) + "/" + strCategoryID1 + "\">" + Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 2) + "</a></li>" + "<li class=\"active\">" + Twee.Comm.CommUtil.ReplaceSpecial(strCategory2, 2) + "</li>";
                //strLinks = "<li><a href=\"/Product/Category.aspx/" + Name2URL(strCategory1) + "/" + strCategoryID1 + "\">" + Name2URL(strCategory1) + "</a></li>" + "<li class=\"active\">" + Name2URL(strCategory2) + "</li>";
                Twee.Comm.XMLCache cache = new Twee.Comm.XMLCache();
                //string strYear = cache.GetYearString();
                if (cache.IsHTMLFileExists("Category_" + strCateID))
                {
                    strCategoryCacheHTML = cache.ReadCacheHTML("Category_" + strCateID);
                }
                else
                {
                    DataTable dt = mgr.GetSubCategoryList(strCateID);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strCategoryCacheHTML = strCategoryCacheHTML + "<div class='sub_category'><a href='/Product/Category.aspx/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 1)) + "/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory2, 1)) + "/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(dt.Rows[i]["name"].ToString(), 1)) + "/" + strCategoryID1 + "/" + strCateID + "/" + dt.Rows[i]["guid"] + "'>" + Twee.Comm.CommUtil.ReplaceSpecial(dt.Rows[i]["name"].ToString(), 1) + "</a></div>";
                    }
                    cache.WriteCahceHTML(strCategoryCacheHTML, "Category_" + strCateID);
                }
                iShowMain = 0;
                iCategoryLeval = 2;
            }
            if (iLength == 9)
            {
                //三级目录
                strCategory1 = folders[3];
                strCategory2 = folders[4];
                strCategory3 = folders[5];
                strCategoryID1 = folders[6];
                strCategoryID2 = folders[7];
                strCateID = folders[8];
                strCateIDLvl1 = strCategoryID1;
                strCateIDLvl2 = strCategoryID2;
                strCateIDLvl3 = strCateID;
                strLinks = "<li><a href=\"/Product/Category.aspx/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 1)) + "/" + strCategoryID1 + "\">" + Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 2) + "</a></li><li><a href=\"/Product/Category.aspx/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 1)) + "/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory2, 1)) + "/" + strCategoryID1 + "/" + strCategoryID2 + "\">" + Twee.Comm.CommUtil.ReplaceSpecial(strCategory2, 2) + "</a></li>" + "<li class=\"active\">" + Twee.Comm.CommUtil.ReplaceSpecial(strCategory3, 2) + "</li>";
                strCategoryCacheHTML = "";
                iShowMain = 0;
                iCategoryLeval = 3;
            }
        }


    }
}