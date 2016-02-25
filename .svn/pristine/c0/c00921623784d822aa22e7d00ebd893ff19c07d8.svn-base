using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;

namespace Twee.Mgr
{
    public class PageContentMgr
    {
        private readonly Twee.DataMgr.PageContentDataMgr mgr = new DataMgr.PageContentDataMgr();
        /// <summary>
        /// backend Get all categories
        /// </summary>
        public DataTable MgeGetPageContentCate(bool bActiveOnly, int iStartRow, int iEndRow, out int iTotalCount)
        {
            return mgr.MgeGetPageContentCate(bActiveOnly, iStartRow, iEndRow, out iTotalCount);
        }


        /// <summary>
        /// backend Get all active category list
        /// </summary>
        public DataTable MgeGetPageContentCateList()
        {
            return mgr.MgeGetPageContentCateList();
        }

        /// <summary>
        /// backend Get page content data
        /// </summary>
        public DataTable MgeGetPageContent(int iStartRow, int iEndRow, out int iTotalCount)
        {
            return mgr.MgeGetPageContent(iStartRow, iEndRow, out iTotalCount);
        }

        /// <summary>
        /// backend Get page content info by ID
        /// </summary>
        public DataTable MgeGetPageContentCateInfo(string sPageContentCateID)
        {
            return mgr.MgeGetPageContentCateInfo(sPageContentCateID);
        }

        /// <summary>
        /// backend add page content category
        /// </summary>
        public int MgeAddPageContentCate(string sName, int iActive)
        {
            return mgr.MgeAddPageContentCate(sName, iActive);
        }

        /// <summary>
        /// backend update page content category
        /// </summary>
        public int MgeUpdatePageContentCate(string sPageContentCateID, string sName, int iActive)
        {
            return mgr.MgeUpdatePageContentCate(sPageContentCateID, sName, iActive);        
        }

        /// <summary>
        /// backend Delete page content category
        /// </summary>
        public int MgeDeletePageContentCate(string sPageContentCateID)
        {
            return mgr.MgeDeletePageContentCate(sPageContentCateID);
        }

                //Add by Long for front end
        public DataTable GetPageContentInfoByPageID(string sID)
        {
            return mgr.GetPageContentInfoByPageID(sID);
        }
        public DataTable GetPageContentInfoBySEOTitle(string sPageSEOTitle)
        {
            return mgr.GetPageContentInfoBySEOTitle(sPageSEOTitle);
        }
        public DataTable getNewsReleaseForMobileApp()
        {
            return mgr.GetNewsReleaseForMobileApp();

        }
        /// <summary>
        /// backend Get page content info by ID
        /// </summary>
        public DataTable MgeGetPageContentInfo(int iPageContentID)
        {
            return mgr.MgeGetPageContentInfo(iPageContentID);
        }

        /// <summary>
        /// backend add page content
        /// </summary>
        public int MgeAddPageContent(int iPageContentCateID, string sPageTitle, string sPageDesc, string sSeoTitle, string sSeoKeyWord, string sSeoMetaTag)
        {
            return mgr.MgeAddPageContent(iPageContentCateID, sPageTitle, sPageDesc, sSeoTitle, sSeoKeyWord, sSeoMetaTag);
        }

        /// <summary>
        /// backend update page content
        /// </summary>
        public int MgeUpdatePageContent(int iPageContentID, int iPageContentCateID, string sPageTitle, string sPageDesc, string sSeoTitle, string sSeoKeyWord, string sSeoMetaTag)
        {
            return mgr.MgeUpdatePageContent(iPageContentID, iPageContentCateID, sPageTitle, sPageDesc, sSeoTitle, sSeoKeyWord, sSeoMetaTag);
        }
        /// <summary>
        /// backend Delete page content
        /// </summary>
        public int MgeDeletePageContent(int iPageContentID)
        {
            return mgr.MgeDeletePageContent(iPageContentID);
        }
    }
}
