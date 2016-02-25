using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.Comm;
using System.Data;
using System.Data.SqlClient;
using log4net;
using System.Reflection;
using System.IO;
using System.Configuration;


namespace Twee.DataMgr
{
    public class PageContentDataMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// backend Get all categories
        /// </summary>
        public DataTable MgeGetPageContentCate(bool bActiveOnly, int iStartRow, int iEndRow, out int iTotalCount)
        {
            StringBuilder sSqlComm = new StringBuilder();

            sSqlComm.Append(" SELECT ROW_NUMBER() OVER ( order by TT.PageContentCate_ID) as Row,  ");
            sSqlComm.Append("  TT.PageContentCate_ID, TT.PageContentCate_Name, TT.PageContentCate_IsActive from wn_PageContentCate as TT ");
            if (bActiveOnly)
            {
                sSqlComm.Append(" where TT.PageContent_Active = 1");
            }

            // retrieve total count
            StringBuilder sSql = new StringBuilder();
            iTotalCount = 0;
            sSql.Append("select count(*) from (");
            sSql.Append(sSqlComm.ToString());
            sSql.Append(") as t");

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iTotalCount = dt.Rows[0][0].ToString().ToInt();
                }
            }

            // retrieve data list
            sSql.Clear();
            sSql.Append("select * from (");
            sSql.Append(sSqlComm.ToString());
            sSql.Append(") as t");
            sSql.Append(" where t.Row between " + iStartRow.ToString() + " and " + iEndRow.ToString());

            ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }


        /// <summary>
        /// backend Get page content data
        /// </summary>
        public DataTable MgeGetPageContent(int iStartRow, int iEndRow, out int iTotalCount)
        {
            StringBuilder sSqlComm = new StringBuilder();

            sSqlComm.Append(" SELECT ROW_NUMBER() OVER ( order by TT.PageContent_PageTitle) as Row ");
            sSqlComm.Append(" ,TT.*, X.PageContentCate_Name from wn_PageContent TT ");
            sSqlComm.Append(" inner join wn_PageContentCate X on X.PageContentCate_ID = TT.PageContentCate_ID");

            // retrieve total count
            StringBuilder sSql = new StringBuilder();
            iTotalCount = 0;
            sSql.Append("select count(*) from (");
            sSql.Append(sSqlComm.ToString());
            sSql.Append(") as t");

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iTotalCount = dt.Rows[0][0].ToString().ToInt();
                }
            }

            // retrieve data list
            sSql.Clear();
            sSql.Append("select * from (");
            sSql.Append(sSqlComm.ToString());
            sSql.Append(") as t");
            sSql.Append(" where t.Row between " + iStartRow.ToString() + " and " + iEndRow.ToString());

            ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }


        //Add by Long for front end
        public DataTable GetPageContentInfoByPageID(string sID)
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append("SELECT * from wn_PageContent ");
            sSql.Append(" where PageContent_ID = '" + Twee.Comm.CommUtil.Quo(sID) + "'");

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }
        public DataTable GetPageContentInfoBySEOTitle(string  sPageSEOTitle)
        {

            StringBuilder sSql = new StringBuilder();

            sSql.Append("SELECT * from wn_PageContent ");
            sSql.Append(" where PageContent_SEOTitle = '" + Twee.Comm.CommUtil.Quo( sPageSEOTitle)+"'");

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }

        //Add by Long for Mobile App to get the News Release
        public DataTable GetNewsReleaseForMobileApp()
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append("SELECT top 10 PageContent_PageTitle,PageContent_SeoTitle,PageContent_UpdateDate from wn_PageContent ");
            sSql.Append(" where PageContentCate_ID=1 order by PageContent_UpdateDate desc");

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];

        }

        /// <summary>
        /// backend Get page content category info by ID
        /// </summary>
        public DataTable MgeGetPageContentCateInfo(string sPageContentCateID)
        {
            int iPageContentCateID = -1;
            if (!int.TryParse(sPageContentCateID, out iPageContentCateID)) return null;

            StringBuilder sSql = new StringBuilder();

            sSql.Append("SELECT * from wn_PageContentCate ");
            sSql.Append(" where PageContentCate_ID = " + iPageContentCateID.ToString());
 
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }

        /// <summary>
        /// backend Get all active category list
        /// </summary>
        public DataTable MgeGetPageContentCateList()
        {

            StringBuilder sSql = new StringBuilder();

            sSql.Append("SELECT * from wn_PageContentCate ");
            sSql.Append(" where PageContentCate_IsActive = 1" );

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }


        /// <summary>
        /// backend add page content category
        /// </summary>
        public int MgeAddPageContentCate(string sName, int iActive)
        {
 
            StringBuilder sSql = new StringBuilder();

            sSql.Append("insert into wn_PageContentCate(PageContentCate_Name, PageContentCate_IsActive)" );
            sSql.Append(" values(" );
            sSql.Append("'" + CommUtil.Quo(sName) + "', " + iActive.ToString() + ")");

            int iAffectedCnt = DbHelperSQL.ExecuteSql(sSql.ToString());
            return iAffectedCnt;
        }

        /// <summary>
        /// backend update page content category
        /// </summary>
        public int MgeUpdatePageContentCate(string sPageContentCateID, string sName, int iActive)
        {
            int iPageContentCateID = -1;
            if (!int.TryParse(sPageContentCateID, out iPageContentCateID)) return 0;

            StringBuilder sSql = new StringBuilder();

            sSql.Append("update wn_PageContentCate set");
            sSql.Append(" PageContentCate_Name='" + CommUtil.Quo(sName) + "',");
            sSql.Append(" PageContentCate_IsActive=" + iActive.ToString() );
            sSql.Append(" where PageContentCate_ID=" + iPageContentCateID.ToString());
            int iAffectedCnt = DbHelperSQL.ExecuteSql(sSql.ToString());
            return iAffectedCnt;
        }
        /// <summary>
        /// backend Delete page content category
        /// </summary>
        public int MgeDeletePageContentCate(string sPageContentCateID)
        {
            int iPageContentCateID = -1;
            if (!int.TryParse(sPageContentCateID, out iPageContentCateID)) return 0;


            StringBuilder sSql = new StringBuilder();
            // check if it is in using.
            sSql.Append("select count(*) from wn_PageContent ");
            sSql.Append(" where PageContentCate_ID=" + iPageContentCateID.ToString());
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if ( ds != null && ds.Tables.Count > 0 ) {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0) {
                    DataRow dr = dt.Rows[0];
                    // already in using in page content table, cannot be deleted
                    if ( dr[0].ToString().ToInt() > 0 ) return -1;
                }
            }

            sSql.Clear();
            sSql.Append("delete from wn_PageContentCate ");
            sSql.Append(" where PageContentCate_ID=" + iPageContentCateID.ToString());
            int iAffectedCnt = DbHelperSQL.ExecuteSql(sSql.ToString());
            return iAffectedCnt;
        }
        /// <summary>
        /// backend Get page content info by ID
        /// </summary>
        public DataTable MgeGetPageContentInfo(int iPageContentID)
        {
 
            StringBuilder sSql = new StringBuilder();

            sSql.Append("SELECT * from wn_PageContent ");
            sSql.Append(" where PageContent_ID = " + iPageContentID.ToString());

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }

        /// <summary>
        /// backend add page content
        /// </summary>
        public int MgeAddPageContent(int iPageContentCateID, string sPageTitle, string sPageDesc, string sSeoTitle, string sSeoKeyWord, string sSeoMetaTag)
        {

            StringBuilder sSql = new StringBuilder();

            sSql.Append("insert into wn_PageContent(PageContentCate_ID, PageContent_PageTitle, PageContent_PageDescription, PageContent_SeoTitle, PageContent_SeoKeyWord, PageContent_SeoMetaTag, PageContent_CreateDate, PageContent_UpdateDate)");
            sSql.Append(" values(");
            sSql.Append(iPageContentCateID.ToString() + ",");
            sSql.Append("'" + CommUtil.Quo(sPageTitle) + "', ");
            sSql.Append("'" + CommUtil.Quo(sPageDesc) + "', ");
            sSql.Append("'" + CommUtil.Quo(sSeoTitle) + "', ");
            sSql.Append("'" + CommUtil.Quo(sSeoKeyWord) + "', ");
            sSql.Append("'" + CommUtil.Quo(sSeoMetaTag) + "', ");
            sSql.Append(" getdate(), getdate())");

            int iAffectedCnt = DbHelperSQL.ExecuteSql(sSql.ToString());
            return iAffectedCnt;
        }

        /// <summary>
        /// backend update page content
        /// </summary>
        public int MgeUpdatePageContent(int iPageContentID, int iPageContentCateID, string sPageTitle, string sPageDesc, string sSeoTitle, string sSeoKeyWord, string sSeoMetaTag)
        {

            StringBuilder sSql = new StringBuilder();

            sSql.Append("update wn_PageContent set");
            sSql.Append(" PageContentCate_ID=" + iPageContentCateID.ToString() +",");
            sSql.Append(" PageContent_PageTitle='" + CommUtil.Quo(sPageTitle) + "',");
            sSql.Append(" PageContent_PageDescription='" + CommUtil.Quo(sPageDesc) + "',");
            sSql.Append(" PageContent_SeoTitle='" + CommUtil.Quo(sSeoTitle) + "',");
            sSql.Append(" PageContent_SeoKeyWord='" + CommUtil.Quo(sSeoKeyWord) + "',");
            sSql.Append(" PageContent_SeoMetaTag='" + CommUtil.Quo(sSeoMetaTag) + "',");
            sSql.Append(" PageContent_UpdateDate=getdate()");
            sSql.Append(" where PageContent_ID=" + iPageContentID.ToString());
            int iAffectedCnt = DbHelperSQL.ExecuteSql(sSql.ToString());
            return iAffectedCnt;
        }
        /// <summary>
        /// backend Delete page content
        /// </summary>
        public int MgeDeletePageContent(int iPageContentID)
        {

            StringBuilder sSql = new StringBuilder();
            sSql.Append("delete from wn_PageContent ");
            sSql.Append(" where PageContent_ID=" + iPageContentID.ToString());
            int iAffectedCnt = DbHelperSQL.ExecuteSql(sSql.ToString());
            return iAffectedCnt;
        }
 
    }
}
