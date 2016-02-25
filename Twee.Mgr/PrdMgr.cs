﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twee.DataMgr;
using System.Reflection;
using log4net;
using System.Data;

namespace Twee.Mgr
{
    public class PrdMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        PrdDataMgr mgr = new PrdDataMgr();

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid prdGuid)
        {
            return mgr.Exists(prdGuid);
        }
        //Add by Long for create category link for product detail page

        public string CreateCategoryLinks(string strPrdGuid)
        {
            return mgr.CreateCategoryLinks(strPrdGuid);
        }
        //Add by Long 2015/12/28 for category page
        public string GetCategoryIDbyName(string cateName)
        {
            return mgr.GetCategoryIDbyName(cateName);
        }
        //Add by Long 2015/12/29 for sub category listings
        public DataTable GetSubCategoryList(string cateID)
        {
            return mgr.GetSubCategoryList(cateID);
        }
        //Add by Lance 2016/01/06 for get all category
        public DataSet GetCategorybyLevel(int catelvl)
        {
            return mgr.GetCategorybyLevel(catelvl);
        }
        public DataSet GetSubCtgryList(string cateID)
        {
            return mgr.GetSubCtgryList(cateID);
        }        
        //Add by Long For Product Rating & Comments
        public bool AddProductComments(string PrdGuid, string UserGuid, short Rate, string strComments)
        {
            return mgr.AddProductComments(PrdGuid, UserGuid, Rate, strComments);
        }
        public string GetProductCommentsTotal(string PrdGuid)
        {
            return mgr.GetProductCommentsTotal(PrdGuid);
        }
        public DataTable GetProductCommentsByPage(string PrdGuid, int iFirst, int iLast)
        {
            return mgr.GetProductCommentsByPage(PrdGuid, iFirst, iLast);
        }
        /// <summary>
        /// ////////////////
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <returns></returns>

        public string GetShortDescription(string prdGuid)
        {
            return mgr.GetShortDescription(prdGuid);
        }
        public bool Check_Shipping_Country(string ShipToID, string CountryID)
        {
            return mgr.Check_Shipping_Country(ShipToID, CountryID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.Prd model)
        {
            return mgr.Add(model);
        }

        /// <summary>
        /// save multiply 3 level categories of a product
        /// </summary>
        public bool SaveCate(string prdGuid, string sCate1List, string sCate2List, string sCate3List)
        {
            return mgr.SaveCate(prdGuid, sCate1List, sCate2List, sCate3List);
        }


        /// <summary>
        /// Get all categories of a product
        /// </summary>
        public DataTable GetPrdCate(string prdGuid)
        {
            return mgr.GetPrdCate(prdGuid);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Prd model)
        {
            return mgr.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int idx)
        {

            return mgr.Delete(idx);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid prdGuid)
        {

            return mgr.Delete(prdGuid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idxlist)
        {
            return mgr.DeleteList(idxlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Prd GetModel(Guid prdGuid)
        {
            return mgr.GetModel(prdGuid);
        }

        public DataTable GetProductTweebaaSKU(string s_prdGuid, string sRulesID)
        {
            return mgr.GetProductTweebaaSKU(s_prdGuid, sRulesID);
        }
        public DataTable GetProductTweebaaRulesExtra(string s_prdGuid,string sRulesID)
        {
            return mgr.GetProductTweebaaRulesExtra(s_prdGuid, sRulesID);

        }


        public DataTable GetProductShipToCountryInfo(string prdGuid)
        {
            return mgr.GetProductShipToCountryInfo(prdGuid);
        }

        /// <summary>
        /// 查询产品的最基本信息：名称、价格、图片
        /// </summary>
        public DataTable GetPrdBaseInfo(Guid prdGuid)
        {
            return mgr.GetPrdBaseInfo(prdGuid); ;
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Twee.Model.Prd GetModelByCache(Guid prdGuid)
        {

            string CacheKey = "wn_prdModel-" + prdGuid;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = mgr.GetModel(prdGuid);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Twee.Model.Prd)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return mgr.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return mgr.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.Prd> GetModelList(string strWhere)
        {
            DataSet ds = mgr.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Twee.Model.Prd> DataTableToList(DataTable dt)
        {
            List<Twee.Model.Prd> modelList = new List<Twee.Model.Prd>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Prd model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = mgr.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表（评审区产品）
        /// </summary>
        public List<Twee.Model.Prd> DataTableToList2(DataTable dt)
        {
            List<Twee.Model.Prd> modelList = new List<Twee.Model.Prd>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Prd model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = mgr.DataRowToModel2(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表（预售区产品）
        /// </summary>
        public List<Twee.Model.Prd> DataTableToList3(DataTable dt)
        {
            List<Twee.Model.Prd> modelList = new List<Twee.Model.Prd>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Prd model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = mgr.DataRowToModel3(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表（分享区区产品）
        /// </summary>
        public List<Twee.Model.Prd> DataTableToList4(DataTable dt)
        {
            List<Twee.Model.Prd> modelList = new List<Twee.Model.Prd>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Twee.Model.Prd model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = mgr.DataRowToModel4(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return mgr.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return mgr.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return mgr.GetList(PageSize,PageIndex,strWhere);
        //}


        /// <summary>
        /// Check if the Tweebaa SKU has al ready existed
        /// </summary>
        public bool IsTweebaaSKUExist(string sTweebaaSKU)
        {
            return mgr.IsTweebaaSKUExist(sTweebaaSKU);
        }


        #endregion  BasicMethod

        #region  ExtensionMethod
        /// <summary>
        /// 发布产品
        /// </summary>
        /// <param name="state">产品状态</param>
        /// <param name="txtName">产品名称</param>
        /// <param name="txtPrice">预估价格</param>
        /// <param name="txtVideoUrl">视频地址</param>
        /// <param name="txtCompanyName">供应商公司名称</param>
        /// <param name="txtIndustry">供应商行业</param>
        /// <param name="txtUrl">供应商网址</param>
        /// <param name="cateGuid">产品类别</param>
        /// <param name="txtTag">产品标签</param>
        /// <param name="txtjl">产品简介</param>
        /// <param name="txtDesc">产品详情</param>
        /// <param name="txtkr">生活问题</param>
        /// <param name="txtfa">解决方法</param>
        /// <param name="uploadfiles">产品缩略图</param>
        /// <param name="pricelist">产品价格区间</param>
        /// <param name="typelist">供应类型</param>
        /// <returns></returns>
        public bool AddPrd(int prdState, string name, decimal estimateprice, string videoUrl, string txtCompanyName,
            string txtIndustry, string txtUrl, string cateGuid, Guid userGuid, string txtTag, string txtjl, string txtDesc, string txtkr, string answer, string prdPic, string prdSupplyPrice, string prdSupplyWay,int prdMoq, out string result, out Guid prdGuid,string supplyPrice,
            int isSupplier, string supplierName, string supplierWebsite, string supplierPhone, string supplierEmail, string supplierAddress, int isUseTemp)
        {
            try
            {
                return mgr.AddPrd(prdState, name, estimateprice, videoUrl, txtCompanyName, txtIndustry, txtUrl, cateGuid, userGuid, txtTag, txtjl, txtDesc, txtkr, answer, prdPic, prdSupplyPrice, prdSupplyWay, prdMoq, out result, out  prdGuid, supplyPrice,
                    isSupplier, supplierName, supplierWebsite, supplierPhone, supplierEmail, supplierAddress, isUseTemp);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }


        }

        /// <summary>
        /// 发布产品
        /// </summary>
        /// <param name="state">产品状态</param>
        /// <param name="txtName">产品名称</param>
        /// <param name="txtPrice">预估价格</param>
        /// <param name="txtVideoUrl">视频地址</param>
        /// <param name="txtCompanyName">供应商公司名称</param>
        /// <param name="txtIndustry">供应商行业</param>
        /// <param name="txtUrl">供应商网址</param>
        /// <param name="cateGuid">产品类别</param>
        /// <param name="txtTag">产品标签</param>
        /// <param name="txtjl">产品简介</param>
        /// <param name="txtDesc">产品详情</param>
        /// <param name="txtkr">生活问题</param>
        /// <param name="txtfa">解决方法</param>
        /// <param name="uploadfiles">产品缩略图</param>
        /// <param name="pricelist">产品价格区间</param>
        /// <param name="typelist">供应类型</param>
        /// <returns></returns>
        public bool UpdatePrd(string name, decimal estimateprice, string videoUrl, string txtCompanyName,
            string txtIndustry, string txtUrl, Guid cateGuid, Guid userGuid, string txtTag, string txtjl, string txtDesc, string txtkr, string answer, string prdPic, string prdSupplyPrice, string prdSupplyWay,string supplyPrice,int prdMoq, 
            int isSupplier, string supplierName, string supplierWebsite, string supplierPhone, string supplierEmail, string supplierAddress, 
            Guid prdGuid,out string result)
        {
            try
            {
                return mgr.UpdatePrd(name, estimateprice, videoUrl, txtCompanyName,
            txtIndustry, txtUrl, cateGuid, userGuid, txtTag, txtjl, txtDesc, txtkr, answer, prdPic, prdSupplyPrice, prdSupplyWay, supplyPrice, prdMoq, 
            isSupplier,  supplierName,  supplierWebsite, supplierPhone, supplierEmail, supplierAddress,
            prdGuid, out  result);
              
              
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }

        }

        /// <summary>
        /// 修改产品状态
        /// </summary>
        /// <param name="prdState">产品状态</param>
        /// <param name="prdGuid">产品ID</param>
        /// <returns></returns>
        public bool UpdatePrdState(int prdState, Guid prdGuid)
        {
            try
            {
                return mgr.UpdatePrdState(prdState, prdGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }          

        }


         /// <summary>
        /// 获取评审区的产品列表
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetPrdReview(string prdName, string cate, string focusCateIDs, string prdCate1, string prdCate2, string prdCate3, string state, string orderby, int startIndex, int endIndex)
        {
            return  mgr.GetPrdReview(prdName,cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// get focus category
        /// </summary>
        /// <returns></returns>
        public DataTable GetFocusCate()
        {
            return mgr.GetFocusCate();
        }

        /// <summary>
        /// 获取预售区的产品列表
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetPrdSale(string prdName, string cate, string focusCateIDs, string prdCate1, string prdCate2, string prdCate3, string state, string orderby, int startIndex, int endIndex)
        {

            return mgr.GetPrdSale(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);
        }
        public DataTable GetShopIndexData1()
        {
            return mgr.GetShopIndexData1();
        }
        public DataTable GetShopIndexData2()
        {
            return mgr.GetShopIndexData2();
        }
        public DataTable GetShopIndexData3()
        {
            return mgr.GetShopIndexData3();
        }
        public DataTable GetShopIndexData4()
        {
            return mgr.GetShopIndexData4();
        }
        public DataTable GetShopIndexData5()
        {
            return mgr.GetShopIndexData5();
        }
        public DataTable MobileAppGetCollagePrd(string prdName, string cate, string focusCateIDs, string prdCate1, string prdCate2, string prdCate3, string state, string orderby, int startIndex, int endIndex)
        {
            return mgr.MobileAppGetCollagePrd(prdName, cate, focusCateIDs, prdCate1, prdCate2, prdCate3, state, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 获取分享区的产品列表
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetPrdShare(string prdName, string cate, string focusCateIDs, string prdCate1, string prdCate2, string prdCate3, string state, string orderby, int startIndex, int endIndex)
        {
            return mgr.GetPrdShare(prdName, cate, focusCateIDs, prdCate1,  prdCate2, prdCate3, state, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// if a user is the submitter of the product
        /// </summary>
        public bool IsUserSubmitter(Guid userGuid, Guid prdGuid)
        {
            return mgr.IsUserSubmitter(userGuid, prdGuid);
        }

        //Add by Long 2016/01/20 for product SEO
        public DataTable GetProductSEOMetaTags(string PrdGuid)
        {
            return mgr.GetProductSEOMetaTags(PrdGuid);
        }

        //add by Long for get product id from product na,e

        public string GetProductID(string prd_name)
        {
            return mgr.GetProductID(prd_name);



        }
        /// <summary>
        /// if a user is the evaluator of the product
        /// </summary>
        public bool IsUserEvaluator(Guid userGuid, Guid prdGuid)
        {
            return mgr.IsUserEvaluator(userGuid, prdGuid);
        }

        #region 会员中心

        /// <summary>
        ///  获取会员中心我的发布
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="prdName"></param>
        /// <param name="cate"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetMySubpllay(string userID, string prdName, string cate, string state, string orderby, int startIndex, int endIndex, string begTime, string endTime)
        {
            return mgr.GetMySubpllay(userID, prdName, cate, state, orderby, startIndex, endIndex,begTime, endTime);
        }

        /// <summary>
        /// 获取会员中心我的发布 grand total by status
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetMySuggestGrandTotal(string userGuid)
        {
            return mgr.GetMySuggestGrandTotal(userGuid);
        }

        /// <summary>
        /// 获取会员中心我的发布(记录总数)
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="prdName"></param>
        /// <param name="cate"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int GetMySubpllayCount(string userID, string prdName, string cate, string state,string begTime, string endTime)
        {
            return mgr.GetMySubpllayCount(userID, prdName, cate, state, begTime, endTime);
        }

        /// <summary>
        /// 获取会员中心我的收藏（预售中的产品的销售信息：已预售数量、金额、剩余时间）
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public DataTable GetHomeCollectionForSale(string prdGuid)
        {
            return mgr.GetHomeCollectionForSale(prdGuid);
        }

        #endregion 

        #endregion

        #region 后台方法

         /// <summary>
        /// Save Product Focus category 
        /// </summary>
        /// <returns></returns>
        public bool MgeSaveProducFocusCate(string sProductIDs, string sFocusCateIDs)
        {
            return mgr.MgeSaveProducFocusCate(sProductIDs, sFocusCateIDs);
        }
  
        /// <summary>
        /// Get Product Focus category Column Name List
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetFocusCateList()
        {
            return mgr.MgeGetFocusCateList();
        }

        /// <summary>
        /// Get Product Focus category Column Name List
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetFocusCateColumnNameList()
        {
            return mgr.MgeGetFocusCateColumnNameList();
        }

        /// <summary>
        /// Get Product Focus categoryList
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetProductFocusCateList(string sSearchKeyword, bool bSearchHasNotFocusCate, int iProductStatusId, int iStartIdx, int iEndIdx, out int iTotalCount)
        {
            return mgr.MgeGetProductFocusCateList(sSearchKeyword, bSearchHasNotFocusCate, iProductStatusId, iStartIdx, iEndIdx, out iTotalCount);
        }

        /// <summary>
        /// Update focus category
        /// </summary>
        /// <returns></returns>
        public string MgeUpdateFocusCate(string sID, string sName, string sNote, string sActive)
        {
            return mgr.MgeUpdateFocusCate(sID, sName, sNote, sActive);
        }

         /// <summary>
        /// add a new focus category
        /// </summary>
        /// <returns></returns>
        public string MgeAddFocusCate(string sName, string sNote, string sActive)
        {
            return mgr.MgeAddFocusCate(sName, sNote, sActive);
        }
        
        /// <summary>
        /// get focus category info
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetFocusCateInfo(string sFocusCateID)
        {
            return mgr.MgeGetFocusCateInfo(sFocusCateID);
        }
            
        /// <summary>
        /// get focus category
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetFocusCateList(int iStartIdx, int iEndIdx, out int iTotalCount)
        {
            return mgr.MgeGetFocusCateList(iStartIdx, iEndIdx, out iTotalCount);
        }

        /// <summary>
        /// 更新名称、预估价格、状态
        /// </summary>
        public bool MgeUpdatePrd(Guid prdGuid, int wnstat, string name, string cateGuid)
        {
           try
            {
                return mgr.MgeUpdatePrd(prdGuid, wnstat, name, cateGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }             
        }

        /// <summary>
        /// 根据产品id获取产品详情内容
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public DataTable MgeGetPrdInfoByID(string prdGuid)
        {
            try
            {
                return mgr.MgeGetPrdInfoByID(prdGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }             

        }
        /// <summary>
        /// 获取产品基本信息
        /// </summary>
        /// <param name="prdGuid">产品id</param>
        /// <param name="prdState">产品状态</param>
        /// <param name="sumCount">记录总数</param>
        /// <returns></returns>
        public DataTable MgeGetPrdBaseInfo(string state, string prdName, string prdGuid, string orderby, int startIndex, int endIndex, out int sumCount)
        {
            return mgr.MgeGetPrdBaseInfo(state, prdName, prdGuid, orderby, startIndex, endIndex, out  sumCount);
        }


        /// <summary>
        ///  获取可以导入仓库的产品信息：=等待上架中的产品(状态=6) + 并且是已经采纳供货的(状态=2)
        /// </summary>
        /// <param name="prdGuid">产品id</param>
        /// <param name="prdState">产品状态</param>
        /// <param name="sumCount">记录总数</param>
        /// <returns></returns>
        public DataTable MgeGetPrdSendToStorge(string prdName, string prdGuid, int startIndex, int endIndex, out int sumCount)
        {
            return mgr.MgeGetPrdSendToStorge(prdName, prdGuid, startIndex, endIndex, out sumCount);
        }
        /// <summary>
        /// 修改产品详情内容
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <param name="contInfo"></param>
        /// <returns></returns>
        public bool MgeUpdatePrdContent(Guid prdGuid, string contInfo, string videoUrl)
        {
            try
            {
                return mgr.MgeUpdatePrdContent(prdGuid, contInfo, videoUrl);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }             
        }

        /// <summary>
        /// 修改产品缩略图
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <param name="listPic"></param>
        /// <returns></returns>
        public bool MgeUpdatePrdFile(Guid prdGuid, List<string> listPic, string video)
        {
            try
            {
                return mgr.MgeUpdatePrdFile(prdGuid, listPic,video);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }           

        }

        /// <summary>
        /// 获取产品缩略图图片
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public DataTable MgeGetPrdPic(string prdGuid)
        {
            try
            {
                return mgr.MgeGetPrdPic(prdGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool MgeDelete(Guid prdGuid)
        {
            try
            {
                return mgr.MgeDelete(prdGuid);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         
        }

        /// <summary>
        /// 获得评审区产品数据列表
        /// </summary>
        public DataTable MgeGetListReview(string prdName, string userName, string state, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return mgr.MgeGetListReview(prdName, userName, state, orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         
        }

       

        ///// <summary>
        ///// 获得评审区产品数据列表
        ///// </summary>
        //public DataTable GetListReview(string strWhere1, string strWhere2, string orderby, int startIndex, int endIndex)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],[name],[question],[answer] ,[addtime],[estimateprice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime] ,f.fileurl,r.allcount,r.count0, r.count1,u.username  FROM ( ");
        //    strSql.Append(" SELECT ROW_NUMBER() OVER (");
        //    if (!string.IsNullOrEmpty(orderby.Trim()))
        //    {
        //        strSql.Append("order by T." + orderby);
        //    }
        //    else
        //    {
        //        strSql.Append("order by T.prdGuid desc");
        //    }
        //    strSql.Append(")AS Row, T.*  from wn_prd T ");
        //    if (!string.IsNullOrEmpty(strWhere1.Trim()))
        //    {
        //        strSql.Append(" WHERE " + strWhere1);
        //    }
        //    strSql.Append(" ) TT");
        //    strSql.Append(" left join  [dbo].[wn_file] f on TT.prdguid= f.prdguid ");
        //    strSql.Append(" left join (select prtguid,COUNT(*) allcount, count(case when cmdtype='0' then 'count0' end) count0, count(case when cmdtype='1' then 'count01' end) count1 from [dbo].[wn_review] group by prtguid ) r on TT.prdGuid=r.prtguid ");
        //    strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");

        //    strSql.Append(" where ");

        //    if (strWhere2.Trim() != "")
        //    {
        //        strSql.Append(strWhere2 + " and ");
        //    }
        //    strSql.AppendFormat("  TT.Row between {0} and {1}", startIndex, endIndex);

        //    DataSet ds = DbHelperSQL.Query(strSql.ToString());
        //    if (ds != null && ds.Tables.Count > 0)
        //    {
        //        return ds.Tables[0];
        //    }
        //    return null;
        //}

        /// <summary>
        /// 获得销售区产品数据列表
        /// </summary>
        public DataTable MgeGetListSale(string strWhere)
        {
            try
            {
                return mgr.MgeGetListSale(strWhere);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         
        }

        public DataTable MgeGetListSale(string prdName, string userName, string state, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return mgr.MgeGetListSale(prdName, userName, state, orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         
        }

        /// <summary>
        /// 获得产品数据总数
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="userName"></param>
        /// <param name="state">状态：空：全部；1：评审区；2：预售区；3：销售区</param>
        /// <returns></returns>
        public int MgeGetListReviewCount(string prdName, string userName, string state)
        {
            try
            {
                return mgr.MgeGetListReviewCount(prdName, userName, state);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         

        }

        /// <summary>
        /// 获取个人发布的所有产品
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable MgeGetPersonPublish(string strWhere, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return mgr.MgeGetPersonPublish(strWhere, orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         

        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int MgeGetRecordCount(string strWhere)
        {
            try
            {
                return mgr.MgeGetRecordCount(strWhere);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         

        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet MgeGetList(int top, string strWhere, string filedOrder)
        {
            try
            {
                return mgr.MgeGetList(top, strWhere, filedOrder);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         
        }

        /// <summary>
        /// get ship to country list of a product rule
        /// </summary>
        public DataTable MgeGetSKUShipToCountryList(int iRuleID)
        {
            return mgr.MgeGetSKUShipToCountryList(iRuleID);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet MgeGetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            try
            {
                return mgr.MgeGetListByPage(strWhere, orderby, startIndex, endIndex);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         
        }

        /// <summary>
        /// 获取产品价格
        /// </summary>
        /// <param name="prdId"></param>
        /// <returns></returns>
        public DataTable MgeGetPrdPrice(string prdId)
        {
            try
            {
                return mgr.MgeGetPrdPrice(prdId);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         

        }
        /// <summary>
        /// 添加价格
        /// </summary>
        /// <param name="prdId"></param>
        /// <returns></returns>
        public bool MgeAddPrdPrice(Guid prdId, int count1, int count2, decimal price)
        {

            try
            {
                return mgr.MgeAddPrdPrice(prdId, count1, count2, price);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         

        }


        /// <summary>
        /// 删除产品价格
        /// </summary>
        /// <param name="prdId"></param>
        /// <returns></returns>
        public bool MgeDeletPrdPrice(string prdId)
        {
            try
            {
                return mgr.MgeDeletPrdPrice(prdId);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }         

        }

        /// <summary>
        /// Get ship from info 
        /// </summary>
        /// <param name="ship from id"></param>
        /// <returns></returns
        public DataTable MgeGetShipFromInfo(int iShipFromID)
        {
            return mgr.MgeGetShipFromInfo(iShipFromID);
        }

        /// <summary>
        /// Get ship methods of a ship from  
        /// </summary>
        /// <param name="ship from id"></param>
        /// <returns></returns
        public DataTable MgeGetShipMethod(int iShipFromID)
        {
            return mgr.MgeGetShipMethod(iShipFromID);
        }
        #endregion

        #region 初审方法
        public DataTable InitGetListReview(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            try
            {
                return mgr.InitGetListReview(prdName, userName, state, cate, startTime, endTime, orderby, startIndex, endIndex, out totalCount);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            } 
        }
        /// <summary>
        /// 批量审核通过【lcs】
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int InitPassAll(string ids)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'", str);
            }
            return mgr.InitPassAll(sqlParams.ToString().Substring(1));
        }

        public int InitPassSingle(string id,string proname,string userid)
        {
            return mgr.InitPassSingle("'" + id + "'",proname,userid);
        }

        /// <summary>
        /// 拒绝通过
        /// </summary>
        /// <param name="proid"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool RefusePass(string proid, string proname, string userid, string reason)
        {
            return mgr.RefusePass(proid,proname,userid,reason);
        }
        #endregion

        #region 大众评审方法
        /// <summary>
        /// 获得评审区产品数据列表
        /// </summary>
        public DataTable MgeGetListReview(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            try
            {
                return mgr.MgeGetListReview(prdName, userName, state, cate, startTime, endTime, orderby, startIndex, endIndex, out totalCount);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }
        }

        /// <summary>
        /// 批量审核通过【lcs】
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int PassAll(string ids)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'",str);
            }
            return mgr.PassAll(sqlParams.ToString().Substring(1));
        }

        public int PassSingle(string proid, string reasonid, string exreason, string adminid)
        {
            return mgr.PassSingle("'" + proid + "'", reasonid, exreason,adminid);
        }

        #endregion

        #region 推易吧终审区方法
        /// <summary>
        /// 批量审核通过【lcs】
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int TweePassAll(string ids,out List<string> noInventoryIds)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'", str);
            }
            return mgr.TweePassAll(sqlParams.ToString().Substring(1),out noInventoryIds);
        }

        public int TweePassSingle(string id)
        {
            return mgr.TweePassSingle("'" + id + "'");
        }

        /// <summary>
        /// 获得评审区产品数据列表
        /// </summary>
        public DataTable TweeMgeGetListReview(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            try
            {
                return mgr.TweeMgeGetListReview(prdName, userName, state, cate, startTime, endTime, orderby, startIndex, endIndex, out totalCount);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }
        }

        /// <summary>
        /// 没能过理由
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int TweeNoPass(string id, string reason) {
            return mgr.TweeNoPass(id,reason);
        }

         /// <summary>
        /// 更新预售时间与预售目标
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="order"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int TweeSavePreSaleOrderAndTime(string ids,string prePrice, string order, string time)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'", str);
            }
            return mgr.TweeSavePreSaleOrderAndTime(sqlParams.ToString().Substring(1), prePrice,order, time);
        }

        #endregion

        #region 预售评审区方法
        /// <summary>
        /// 批量审核通过【lcs】
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int PreSalePassAll(string ids, string adminid)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'", str);
            }
            return mgr.PreSalePassAll(sqlParams.ToString().Substring(1), adminid);
        }

        public int PreSalePassSingle(string proid, string reasonid, string exreason, string adminid)
        {
            return mgr.PreSalePassSingle("'" + proid + "'",reasonid,exreason,adminid);
        }
        /// <summary>
        /// 设置热点产品
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public int SetHotProduct(string proids) {
            string[] array = proids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'", str);
            }
            return mgr.SetHotProduct(sqlParams.ToString().Substring(1));
        }

        /// <summary>
        /// 设置热点产品
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public int CancelHotProduct(string proids)
        {
            string[] array = proids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'", str);
            }
            return mgr.CancelHotProduct(sqlParams.ToString().Substring(1));
        }
        
    

        /// <summary>
        /// 获得评审区产品数据列表
        /// </summary>
        public DataTable PreSaleMgeGetListReview(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            try
            {
                return mgr.PreSaleMgeGetListSale(prdName, userName, state, cate, startTime, endTime, orderby, startIndex, endIndex, out totalCount);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }
        }

        /// <summary>
        /// 没能过理由
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int PreSaleNoPass(string id, string reason)
        {
            return mgr.PreSaleNoPass(id, reason);
        }

        #endregion

        #region 上架评审区方法
        /// <summary>
        /// 批量审核通过【lcs】
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int UpSalePassAll(string ids)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'", str);
            }
            return mgr.UpSalePassAll(sqlParams.ToString().Substring(1));
        }

        public int UpSalePassSingle(string id)
        {
            return mgr.UpSalePassSingle("'" + id + "'");
        }

        /// <summary>
        /// 获得评审区产品数据列表
        /// </summary>
        public DataTable UpMgeGetListReview(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            try
            {
                return mgr.UpMgeGetListSale(prdName, userName, state, cate, startTime, endTime, orderby, startIndex, endIndex, out totalCount);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }
        }

        /// <summary>
        /// 没能过理由
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public int UpSaleNoPass(string id, string reason)
        {
            return mgr.UpSaleNoPass(id, reason);
        }

        #endregion

        #region 销售区方法
        /// <summary>
        /// 批量下架产品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DownAll(string ids,string reason)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'", str);
            }
            return mgr.DownAll(sqlParams.ToString().Substring(1),reason);
        }
        /// <summary>
        /// 单个下架产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DownSingle(string id,string reason)
        {
            return mgr.DownSingle("'" + id + "'",reason);
        }

        /// <summary>
        /// 获得销售区产品数据列表
        /// </summary>
        public DataTable SaleingMgeGetList(string prdName, string tweebaaSku, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            try
            {
                return mgr.SaleingMgeGetList(prdName, tweebaaSku, userName, state, cate, startTime, endTime, orderby, startIndex, endIndex, out totalCount);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }
        }

        /// <summary>
        /// get sku details of products from backend
        /// </summary>
        public DataTable SKUMgeGetList(string prdName, string tweebaaSku, string sShipPartnerID, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            try
            {
                return mgr.SKUMgeGetList(prdName, tweebaaSku, sShipPartnerID, userName, state, cate, startTime, endTime, orderby, startIndex, endIndex, out totalCount);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }
        }


        /// <summary>
        /// get product image list
        /// </summary>
        public DataTable MgeGetProductImageList(string sPrdGuid)
        {
            return mgr.MgeGetProductImageList(sPrdGuid);
        }

        /// <summary>
        /// get product SKU list 
        /// </summary>
        public DataTable MgeGetProductSKUList(string sPrdGuid)
        {
            return mgr.MgeGetProductSKUList(sPrdGuid);
        }

        /// <summary>
        /// get product supply list 
        /// </summary>
        public DataTable MgeGetProductSupplyList(string sPrdGuid)
        {
            return mgr.MgeGetProductSupplyList(sPrdGuid);
        }

        /// <summary>
        /// get product sku details from back end
        /// </summary>
        public DataTable MgeGetProductSKUDetail(int iRuleID)
        {
            try
            {
                return mgr.MgeGetProductSKUDetail(iRuleID);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }
        }

        /// <summary>
        /// get product spec type list
        /// </summary>
        public DataTable MgeGetProductSpecTypeList()
        {
            try
            {
                return mgr.MgeGetProductSpecTypeList();
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }
        }

        /// <summary>
        /// Save SKU details of product from backend
        /// </summary>
        /// <returns></returns>
        public int MgeSaveProductSKUDetail(int iRuleID, string sTweebaaSKU, int iSpecTypeID, string sSpecName, string sWholesalePrice, int iMinimumStock, string sColor, string sWeight, string sPackageLength, string sPackageWidth, string sPackageHeight, string sPackageWeight)
        {
            try
            {
                return mgr.MgeSaveProductSKUDetail(iRuleID, sTweebaaSKU, iSpecTypeID, sSpecName, sWholesalePrice, iMinimumStock, sColor, sWeight, sPackageLength, sPackageWidth, sPackageHeight, sPackageWeight);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }

        }
        #endregion

        #region 上架区方法
        /// <summary>
        /// 批量上架产品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int UpAll(string ids, string reason)
        {
            string[] array = ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sqlParams = new StringBuilder();
            foreach (string str in array)
            {
                sqlParams.AppendFormat(",'{0}'", str);
            }
            return mgr.UpAll(sqlParams.ToString().Substring(1), reason);
        }
        /// <summary>
        /// 单个上架产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpSingle(string id, string reason)
        {
            return mgr.UpSingle("'" + id + "'", reason);
        }

        /// <summary>
        /// 获得上架区产品数据列表
        /// </summary>
        public DataTable DownMgeGetList(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            try
            {
                return mgr.DownMgeGetList(prdName, userName, state, cate, startTime, endTime, orderby, startIndex, endIndex, out totalCount);
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }
        }

        #endregion

    }
}