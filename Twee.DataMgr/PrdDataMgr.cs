﻿using System;
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

    public class PrdDataMgr
    {
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid prdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_prd");
            strSql.Append(" where prdGuid=@prdGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = prdGuid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        //Add by Long for create category link for product detail page

        public string CreateCategoryLinks(string strPrdGuid)
        {
            string strSQL = "SELECT  cateGuid1, cateGuid2, cateGuid3 FROM  wn_Prd2Cate WHERE  prdGuid = '" + Twee.Comm.CommUtil.Quo( strPrdGuid )+ "'";
            DataSet ds = DbHelperSQL.Query(strSQL);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                strSQL = "select name from wn_prdCate where guid='" + ds.Tables[0].Rows[0]["cateGuid1"].ToString() + "'";
                object obj = DbHelperSQL.GetSingle(strSQL);
                string strCategory1 = obj.ToString();
                
                strSQL = "select name from wn_prdCate where guid='" + ds.Tables[0].Rows[0]["cateGuid2"].ToString() + "'";
                obj = DbHelperSQL.GetSingle(strSQL);
                string strCategory2 = obj.ToString();

                strSQL = "select name from wn_prdCate where guid='" + ds.Tables[0].Rows[0]["cateGuid3"].ToString() + "'";
                obj = DbHelperSQL.GetSingle(strSQL);
                string strCategory3 = obj.ToString();

                string strCategoryID1 = ds.Tables[0].Rows[0]["cateGuid1"].ToString();
                string strCategoryID2 = ds.Tables[0].Rows[0]["cateGuid2"].ToString();
                string strCategoryID3 = ds.Tables[0].Rows[0]["cateGuid3"].ToString();
                string strLinks = "<li><a href=\"/Product/Category.aspx/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 1)) + "/" + ds.Tables[0].Rows[0]["cateGuid1"].ToString() + "\">" + Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 2) + "</a></li><li><a href=\"/Product/Category.aspx/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory1, 1)) + "/" + Twee.Comm.CommUtil.Name2URL(Twee.Comm.CommUtil.ReplaceSpecial(strCategory2, 1)) + "/" + strCategoryID1 + "/" + strCategoryID2 + "\">" + Twee.Comm.CommUtil.ReplaceSpecial(strCategory2, 2) + "</a></li>" + "<li class=\"active\">" + Twee.Comm.CommUtil.ReplaceSpecial(strCategory3, 2) + "</li>";
                return strLinks;
            }
            else
            {
                return "";
            }
            return "";
        }


        //Add by Long for Product Special SEO meta tag
        public DataTable GetProductSEOMetaTags(string PrdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from wn_PrdSEO where PrdGuid='" + Twee.Comm.CommUtil.Quo(PrdGuid) + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }

        }

        //Add by Long For Product Rating & Comments
        public bool AddProductComments(string PrdGuid, string UserGuid, short Rate, string strComments)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_ProductRateReview(ProductGuid,UserGuid,Rates,Comments,ReviewDate) values('");
            strSql.Append(Twee.Comm.CommUtil.Quo(PrdGuid) + "','");
            strSql.Append(Twee.Comm.CommUtil.Quo(UserGuid) + "','");
            strSql.Append(Rate.ToString() + "','");
            strSql.Append(Twee.Comm.CommUtil.Quo(strComments) + "',getdate())");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            return true;
        }
        public string GetProductCommentsTotal(string PrdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as iCount,sum(Rates) as TotalRating from wn_ProductRateReview where ProductGuid='" + PrdGuid + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt= ds.Tables[0];
                DataRow dr = dt.Rows[0];
                return dr["iCount"].ToString() + ":" + dr["TotalRating"].ToString();
            }
            else
                return "0:0";
            
        }
        public DataTable GetProductCommentsByPage(string PrdGuid, int iFirst, int iLast)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TT.*,convert(varchar(25), TT.ReviewDate, 120) as AddDate, b.username");
            strSql.Append(" from (");
            strSql.Append(" SELECT ROW_NUMBER() OVER (order by ReviewDate desc) as Row, a.* from wn_ProductRateReview a where ProductGuid='"+PrdGuid+"' ) as TT");
            strSql.Append(" left join wn_user b");
            strSql.Append(" on TT.UserGuid=b.guid");
            strSql.Append(" where  TT.Row between " + iFirst.ToString() + " and " + iLast.ToString());

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        public string GetShortDescription(string prdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select txtjj from wn_prd");
            strSql.Append(" where prdGuid='" + prdGuid+"'");


            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        //Add by Long 
        public bool Check_Shipping_Country(string ShipToID, string CountryID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ShipFrom_ShipToCountries from wn_ShipFrom where ShipFrom_ID=" + ShipToID);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());

            strSql.Clear();
            strSql.Append("select code from wn_country where id=" + CountryID);
            object obj2 = DbHelperSQL.GetSingle(strSql.ToString());

            if (obj.ToString().ToUpper().Contains(obj2.ToString().ToUpper()))
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// save multiply 3 level categories of a product
        /// </summary>
        public bool SaveCate(string prdGuid, string sCate1GuidList, string sCate2GuidList, string sCate3GuidList)
        {
            DB db = new DB();
            List<string> arrCate1GUidList = sCate1GuidList.Split(',').ToList();
            List<string> arrCate2GUidList = sCate2GuidList.Split(',').ToList();
            List<string> arrCate3GUidList = sCate3GuidList.Split(',').ToList();

            db.DBConnect();
            db.DBBeginTrans();

            // delete all existing categories of this product
            string sSql = "delete from wn_Prd2Cate where prdGuid ='" + prdGuid + "'";
            int iRow = db.DBExecute(sSql);

            // insert all new categories
            for (int i = 0; i < arrCate1GUidList.Count(); i++)
            {
                sSql = "insert into wn_Prd2Cate(prdGuid, cateGuid1, cateGuid2, cateGuid3) values(" +
                       "'" + prdGuid + "','" + arrCate1GUidList[i] + "','" + arrCate2GUidList[i] + "','" + arrCate3GUidList[i] + "')";
                iRow = db.DBExecute(sSql);
            }
            db.DBCommitTrans();
            db.DBDisconnect();

            return true;
        }

        //Add by Long 2015/12/28 for category page
        public string GetCategoryIDbyName(string cateName)
        {

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("select guid from wn_prdCate where name=N'" + Twee.Comm.CommUtil.Quo(cateName) + "'");
            object obj = DbHelperSQL.GetSingle(strSql2.ToString());
            if (obj == null)
            {
                return "";
            }
            return obj.ToString();
        }
        public DataTable GetSubCategoryList(string cateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM wn_prdCate where prtGuid='" + cateID + "'" + " order by name");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            return ds.Tables[0];
        }
        //added by lance 2016/01/06
        public DataSet GetCategorybyLevel(int catelvl)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM wn_prdCate where layer='" + catelvl + "'" + " order by name");
            //DataSet ds = DbHelperSQL.Query(strSql.ToString());
            //return ds.Tables[0];
            return DbHelperSQL.Query(strSql.ToString());
        }
        public DataSet GetSubCtgryList(string cateID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM wn_prdCate where prtGuid='" + cateID + "'");
            //DataSet ds = DbHelperSQL.Query(strSql.ToString());
           // return ds.Tables[0];
            return DbHelperSQL.Query(strSql.ToString());
        }
        public string GetProductID(string prd_name)
        {
            string sID = string.Empty;
            int iPos = prd_name.LastIndexOf(@"-prdguid-");
            if (iPos == -1)
            {
                //wn_proDetails state =2
                StringBuilder strSql2 = new StringBuilder();
                strSql2.Append("select prdGuid from wn_prd a inner join wn_proDetails b on a.prdGuid=b.proid where b.state =2 and a.name=N'" + Twee.Comm.CommUtil.Quo(prd_name) + "'");
                object obj = new Object();
                obj = DbHelperSQL.GetSingle(strSql2.ToString());
                if (obj != null) sID = obj.ToString();
            }
            else
            {
                sID = prd_name.Substring(iPos + 9);
            }
            return sID;
        }

        /// <summary>
        /// Get all categories of a product
        /// </summary>
        public DataTable GetPrdCate(string prdGuid) {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select cateGuid1, cateGuid2, cateGuid3 from wn_Prd2Cate ");
            sSql.Append(" where prdGuid = '" + prdGuid + "'");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0 )
                return ds.Tables[0];
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.Prd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_prd(");
            strSql.Append("prdGuid,cateGuid,userGuid,name,edtTime,addtime,estimateprice,videoUrl, videoEmbed, wnstat,txtTag,txtinfo,reviewendtime,txtjj,question,answer, isSupplier, supplierName, supplierWebsite, supplierPhone, supplierEmail, supplierAddress, saleprice, ranking, MinAdvertisedPrice, presaleForward, presaleEndTime, ProductUploadBatchNo)");
            strSql.Append(" values (");
            strSql.Append("@prdGuid,@cateGuid,@userGuid,@name,@edtTime,@addtime,@estimateprice,@videoUrl, @videoEmbed,@wnstat,@txtTag,@txtinfo,@reviewendtime,@txtjj,@question,@answer, @isSupplier, @supplierName, @supplierWebsite, @supplierPhone, @supplierEmail, @supplierAddress,@saleprice, @ranking, @MinAdvertisedPrice, @presaleForward, @presaleEndTime, @ProductUploadBatchNo)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@cateGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@name", SqlDbType.NVarChar,250),
					new SqlParameter("@edtTime", SqlDbType.DateTime),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@estimateprice", SqlDbType.Decimal,8),
					new SqlParameter("@videoUrl", SqlDbType.NVarChar,1500),
					new SqlParameter("@videoEmbed", SqlDbType.NVarChar,1500),
					new SqlParameter("@wnstat", SqlDbType.TinyInt,1),
					new SqlParameter("@txtTag", SqlDbType.NVarChar,550),
					new SqlParameter("@txtinfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@reviewendtime", SqlDbType.DateTime),
					new SqlParameter("@txtjj", SqlDbType.NVarChar,4000),
					new SqlParameter("@question", SqlDbType.NVarChar,500),
                    new SqlParameter("@answer", SqlDbType.NVarChar,500),
					new SqlParameter("@isSupplier", SqlDbType.TinyInt),
					new SqlParameter("@supplierName", SqlDbType.NVarChar,250),
					new SqlParameter("@supplierWebsite", SqlDbType.NVarChar,512),
					new SqlParameter("@supplierPhone", SqlDbType.NVarChar,50),
					new SqlParameter("@supplierEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@supplierAddress", SqlDbType.NVarChar,250),
                    new SqlParameter("@saleprice", SqlDbType.Decimal,8),
					new SqlParameter("@ranking", SqlDbType.Int),
                    new SqlParameter("@MinAdvertisedPrice", SqlDbType.Decimal,8),
                    new SqlParameter("@presaleForward", SqlDbType.Int),
                    new SqlParameter("@presaleEndTime", SqlDbType.DateTime),
					new SqlParameter("@ProductUploadBatchNo", SqlDbType.TinyInt)};
            parameters[0].Value = model.prdGuid;
            parameters[1].Value = model.cateGuid;
            parameters[2].Value = model.userGuid;
            parameters[3].Value = model.name;
            parameters[4].Value = model.edtTime;
            parameters[5].Value = model.addtime;
            parameters[6].Value = model.estimateprice;
            parameters[7].Value = model.videoUrl;
            parameters[8].Value = model.videoEmbed;
            parameters[9].Value = model.wnstat;
            parameters[10].Value = model.txtTag;
            parameters[11].Value = model.txtinfo;
            parameters[12].Value = model.reviewendtime;
            parameters[13].Value = model.txtjj;
            parameters[14].Value = model.question;
            parameters[15].Value = model.answer;
            parameters[16].Value = model.isSupplier;
            parameters[17].Value = model.supplierName;
            parameters[18].Value = model.supplierWebsite;
            parameters[19].Value = model.supplierPhone;
            parameters[20].Value = model.supplierEmail;
            parameters[21].Value = model.supplierAddress;
            parameters[22].Value = model.saleprice;

            if (model.Ranking == null) model.Ranking = 0;
            parameters[23].Value = model.Ranking;

            parameters[24].Value = model.MinAdvertisedPrice;

            parameters[25].Value = model.presaleForward;
            parameters[26].Value = model.presaleendtime;


            if (model.UpLoadBatchNo == null) model.UpLoadBatchNo = -1;
            parameters[27].Value = model.UpLoadBatchNo;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Prd model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_prd set ");
            strSql.Append("cateGuid=@cateGuid,");
            strSql.Append("userGuid=@userGuid,");
            strSql.Append("name=@name,");
            strSql.Append("ranking=@ranking,");
            strSql.Append("edtTime=@edtTime,");
            strSql.Append("addtime=@addtime,");
            strSql.Append("estimateprice=@estimateprice,");
            strSql.Append("videoUrl=@videoUrl,");
            strSql.Append("wnstat=@wnstat,");
            strSql.Append("txtTag=@txtTag,");
            strSql.Append("txtinfo=@txtinfo,");
            strSql.Append("reviewendtime=@reviewendtime,");
            strSql.Append("txtjj=@txtjj,");
            strSql.Append("question=@question,");
            strSql.Append("answer=@answer,");
            strSql.Append("supplyPrice=@supplyPrice,");
            strSql.Append("isSupplier=@isSupplier,");
            strSql.Append("supplierName=@supplierName,");
            strSql.Append("supplierWebsite=@supplierWebsite,");
            strSql.Append("supplierPhone=@supplierPhone,");
            strSql.Append("supplierEmail=@supplierEmail,");
            strSql.Append("supplierAddress=@supplierAddress,");
            strSql.Append("saleprice=@saleprice,");
            strSql.Append("isFreeShipping=@isFreeShipping,");
            strSql.Append("isLimitedTime=@isLimitedTime,");
            strSql.Append("isComingSoon=@isComingSoon,");
            strSql.Append("IsFeaturedProduct=@IsFeaturedProduct,");
            strSql.Append("AllowCollage=@AllowCollage,");
            strSql.Append("DisplaySpecName=@DisplaySpecName,");
            strSql.Append("DisplaySpecColor=@DisplaySpecColor");
            strSql.Append(" where idx=@idx");
            SqlParameter[] parameters = {
					new SqlParameter("@cateGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@name", SqlDbType.NVarChar,250),
					new SqlParameter("@ranking", SqlDbType.Int),
					new SqlParameter("@edtTime", SqlDbType.DateTime),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@estimateprice", SqlDbType.Decimal,8),
					new SqlParameter("@videoUrl", SqlDbType.NVarChar,1500),
					new SqlParameter("@wnstat", SqlDbType.TinyInt,1),
					new SqlParameter("@txtTag", SqlDbType.NVarChar,550),
					new SqlParameter("@txtinfo", SqlDbType.NVarChar,-1),
					new SqlParameter("@reviewendtime", SqlDbType.DateTime),
					new SqlParameter("@txtjj", SqlDbType.NVarChar,-1),
					new SqlParameter("@question", SqlDbType.NVarChar,500),
					new SqlParameter("@answer", SqlDbType.NVarChar,1000),
                    new SqlParameter("@supplyPrice", SqlDbType.Decimal),
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@idx", SqlDbType.Int,4),
					new SqlParameter("@isSupplier", SqlDbType.TinyInt),
					new SqlParameter("@supplierName", SqlDbType.NVarChar, 250),
					new SqlParameter("@supplierWebsite", SqlDbType.NVarChar, 512),
					new SqlParameter("@supplierPhone", SqlDbType.NVarChar, 50),
					new SqlParameter("@supplierEmail", SqlDbType.NVarChar, 50),
					new SqlParameter("@supplierAddress", SqlDbType.NVarChar, 250),
                    new SqlParameter("@saleprice", SqlDbType.Decimal),                                        
                    new SqlParameter("@isFreeShipping", SqlDbType.Bit),
                    new SqlParameter("@isLimitedTime", SqlDbType.Bit),
                    new SqlParameter("@isComingSoon", SqlDbType.Bit) ,
                    new SqlParameter("@IsFeaturedProduct", SqlDbType.TinyInt),
                    new SqlParameter("@AllowCollage", SqlDbType.TinyInt),                    
                    new SqlParameter("@DisplaySpecName", SqlDbType.TinyInt),                    
                    new SqlParameter("@DisplaySpecColor", SqlDbType.TinyInt)                    
                                        };
            parameters[0].Value = model.cateGuid;
            parameters[1].Value = model.userGuid;
            parameters[2].Value = model.name;
            parameters[3].Value = model.Ranking;
            parameters[4].Value = model.edtTime;
            parameters[5].Value = model.addtime;
            parameters[6].Value = model.estimateprice;
            parameters[7].Value = model.videoUrl;
            parameters[8].Value = model.wnstat;
            parameters[9].Value = model.txtTag;
            parameters[10].Value = model.txtinfo;
            parameters[11].Value = model.reviewendtime;
            parameters[12].Value = model.txtjj;
            parameters[13].Value = model.question;
            parameters[14].Value = model.answer;
            parameters[15].Value = model.supplyPrice;
            parameters[16].Value = model.prdGuid;
            parameters[17].Value = model.idx;
            parameters[18].Value = model.isSupplier;
            parameters[19].Value = model.supplierName;
            parameters[20].Value = model.supplierWebsite;
            parameters[21].Value = model.supplierPhone;
            parameters[22].Value = model.supplierEmail;
            parameters[23].Value = model.supplierAddress;
            parameters[24].Value = model.saleprice;

            parameters[25].Value = model.IsFreeShipping;
            parameters[26].Value = model.IsLimitedTime;
            parameters[27].Value = model.IsComingSoon;
            parameters[28].Value = short.Parse(model.IsFeatured);
            parameters[29].Value = model.AllowCollage;
            parameters[30].Value = model.DisplaySpecName;
            parameters[31].Value = model.DisplaySpecColor;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int idx)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prd ");
            strSql.Append(" where idx=@idx");
            SqlParameter[] parameters = {
					new SqlParameter("@idx", SqlDbType.Int,4)
			};
            parameters[0].Value = idx;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid prdGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prd ");
            strSql.Append(" where prdGuid=@prdGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = prdGuid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idxlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prd ");
            strSql.Append(" where idx in (" + idxlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable GetProductTweebaaSKU(string s_prdGuid, string sRulesID)
        {
            StringBuilder strSql = new StringBuilder();

            if (sRulesID.Length > 0)
            {
                /*
                 SELECT     a.prdguid, MIN(a.price) AS MinFinalSalePrice
                FROM         dbo.wn_prdprice AS a INNER JOIN
                                      dbo.wn_proRules AS b ON b.id = a.ruleid AND b.proid = a.prdguid INNER JOIN
                                      dbo.wn_proDetails AS c ON c.userid = b.userid AND c.proid = b.proid
                WHERE     (c.state = 2)
                GROUP BY a.prdguid
                 */

                //strSql.Append("SELECT        a.id, a.prosku,a.IsCustomerFreeShip, b.ShipFrom_ShipToCountries");
                // strSql.Append(" FROM   wn_proRules AS a LEFT OUTER JOIN wn_ShipFrom AS b ON a.ShipFrom_ID = b.ShipFrom_ID");
                
                strSql.Append("SELECT        a.prdguid, b.prosku,b.IsCustomerFreeShip, d.ShipFrom_ShipToCountries");
                strSql.Append(" FROM            wn_prdprice AS a INNER JOIN");
                strSql.Append("                         wn_proRules AS b ON b.id = a.ruleid AND b.proid = a.prdguid INNER JOIN");
                strSql.Append("                         wn_proDetails AS c ON c.userid = b.userid AND c.proid = b.proid LEFT OUTER JOIN");
                strSql.Append("                         wn_ShipFrom AS d ON b.ShipFrom_ID = d.ShipFrom_ID");
                strSql.Append(" WHERE        (c.state = 2)");
                strSql.Append("  and    b.proid = '" + s_prdGuid + "' and b.id='" + sRulesID + "'");

            }
            else
            {
                //               strSql.Append("SELECT  top 1  a.id, a.prosku,a.IsCustomerFreeShip, b.ShipFrom_ShipToCountries");
                //               strSql.Append(" FROM  wn_proRules AS a LEFT OUTER JOIN wn_ShipFrom AS b ON a.ShipFrom_ID = b.ShipFrom_ID");
               
                  strSql.Append("SELECT        a.prdguid, b.prosku,b.IsCustomerFreeShip, d.ShipFrom_ShipToCountries");
                  strSql.Append(" FROM            wn_prdprice AS a INNER JOIN");
                  strSql.Append("                         wn_proRules AS b ON b.id = a.ruleid AND b.proid = a.prdguid INNER JOIN");
                  strSql.Append("                         wn_proDetails AS c ON c.userid = b.userid AND c.proid = b.proid LEFT OUTER JOIN");
                  strSql.Append("                         wn_ShipFrom AS d ON b.ShipFrom_ID = d.ShipFrom_ID");
                  strSql.Append(" WHERE        (c.state = 2)"); 
                  strSql.Append(" and b. proid = '" + s_prdGuid + "' order by b.id asc");



            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {

                return null;
            }
        }
        public DataTable GetProductTweebaaRulesExtra(string s_prdGuid,string sRulesID)
        {
            StringBuilder strSql = new StringBuilder();

            if (sRulesID.Length > 0)
            {
/*
 SELECT     a.prdguid, MIN(a.price) AS MinFinalSalePrice
FROM         dbo.wn_prdprice AS a INNER JOIN
                      dbo.wn_proRules AS b ON b.id = a.ruleid AND b.proid = a.prdguid INNER JOIN
                      dbo.wn_proDetails AS c ON c.userid = b.userid AND c.proid = b.proid
WHERE     (c.state = 2)
GROUP BY a.prdguid
 */

                //strSql.Append("SELECT        a.id, a.prosku,a.IsCustomerFreeShip, b.ShipFrom_ShipToCountries");
               // strSql.Append(" FROM   wn_proRules AS a LEFT OUTER JOIN wn_ShipFrom AS b ON a.ShipFrom_ID = b.ShipFrom_ID");
                /*
                strSql.Append("SELECT        a.prdguid, b.prosku,b.IsCustomerFreeShip, d.ShipFrom_ShipToCountries");
strSql.Append(" FROM            wn_prdprice AS a INNER JOIN");
strSql.Append("                         wn_proRules AS b ON b.id = a.ruleid AND b.proid = a.prdguid INNER JOIN");
strSql.Append("                         wn_proDetails AS c ON c.userid = b.userid AND c.proid = b.proid LEFT OUTER JOIN");
strSql.Append("                         wn_ShipFrom AS d ON b.ShipFrom_ID = d.ShipFrom_ID");
strSql.Append(" WHERE        (c.state = 2)");
                strSql.Append("  and    b.proid = '" + s_prdGuid + "' and b.id='" + sRulesID + "'");
                 * */
                strSql.Append("SELECT        b.Country_ID, b.Country_Code, b.Country_Name, b.ProductShipToCountry_IsFree");
                strSql.Append(" FROM            wn_proRules AS a INNER JOIN");
                strSql.Append("                         wn_ProductShipToCountry AS b ON a.userid = b.userGuid and a.proid=b.prdGuid");
                strSql.Append(" WHERE        (b.prdGuid = '" + s_prdGuid + "') AND (a.id = '" + sRulesID + "')");
            }
            else
            {
 //               strSql.Append("SELECT  top 1  a.id, a.prosku,a.IsCustomerFreeShip, b.ShipFrom_ShipToCountries");
 //               strSql.Append(" FROM  wn_proRules AS a LEFT OUTER JOIN wn_ShipFrom AS b ON a.ShipFrom_ID = b.ShipFrom_ID");
              /*  
                strSql.Append("SELECT        a.prdguid, b.prosku,b.IsCustomerFreeShip, d.ShipFrom_ShipToCountries");
                strSql.Append(" FROM            wn_prdprice AS a INNER JOIN");
                strSql.Append("                         wn_proRules AS b ON b.id = a.ruleid AND b.proid = a.prdguid INNER JOIN");
                strSql.Append("                         wn_proDetails AS c ON c.userid = b.userid AND c.proid = b.proid LEFT OUTER JOIN");
                strSql.Append("                         wn_ShipFrom AS d ON b.ShipFrom_ID = d.ShipFrom_ID");
                strSql.Append(" WHERE        (c.state = 2)"); 
                strSql.Append(" and b. proid = '" + s_prdGuid + "' order by b.id asc");
*/
            strSql.Append("SELECT DISTINCT a.Country_ID, a.Country_Code, a.Country_Name, a.ProductShipToCountry_IsFree, b.prosku");
            strSql.Append(" FROM            wn_ProductShipToCountry AS a INNER JOIN");
            strSql.Append("                         wn_proRules AS b ON b.proid = a.prdGuid INNER JOIN");
            strSql.Append("                         wn_proDetails AS c ON c.userid = b.userid AND c.proid = b.proid AND c.userid = a.userGuid");
            strSql.Append(" WHERE        (a.prdGuid = '" + s_prdGuid + "') AND (c.state = 2)");
            strSql.Append(" ORDER BY a.Country_ID");


            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {

                return null;
            }
        }


        public DataTable GetProductShipToCountryInfo(string sPrdGuid)
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append("select distinct a.Country_ID, a.Country_Code, a.Country_Name, ProductShipToCountry_IsFree");
            sSql.Append(" from wn_ProductShipToCountry a");
            sSql.Append(" inner join wn_proRules AS b on  b.proid = a.prdguid");
            sSql.Append(" inner join  wn_proDetails AS c ON c.userid = b.userid and c.proid = b.proid and c.userid = a.userGuid ");
            sSql.Append(" where a.prdguid ='" +  sPrdGuid + "'");
            sSql.Append("   and c.state = 2 ");
            sSql.Append(" order by a.Country_ID");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Prd GetModel(Guid prdGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 p.prdGuid,p.cateGuid,p.userGuid,p.name, p.ranking, p.IsFeaturedProduct,p.AllowCollage, p.edtTime,p.addtime,p.estimateprice,p.saleprice,p.videoUrl, p.videoEmbed, p.supplyPrice,p.moq, p.isSupplier, p.supplierName, p.supplierWebsite, p.supplierPhone, p.supplierEmail, p.supplierAddress, p.wnstat,p.idx,p.txtTag,p.txtinfo,p.reviewendtime,p.presaleendtime, p.presaleforward, DateDiff(Day, getdate(),p.presaleendtime) as presaleendday, DateDiff(Day, getdate(),p.reviewendtime) as reviewendday, p.txtjj,p.question,p.answer,p.isUseTemp, s.saleCount,p.isFreeShipping,p.isLimitedTime,p.isComingSoon, p.DisplaySpecName, p.DisplaySpecColor from wn_prd p");
            strSql.Append(" left join (select distinct b.prdGuid,c.saleCount from  dbo.wn_orderhead h left join dbo.wn_orderBody b on h.guid=b.headGuid   left join (select  prdGuid,COUNT(*) saleCount from  dbo.wn_orderBody group by prdGuid ) c on b.prdGuid=c.prdGuid) s on p.prdGuid=s.prdGuid ");

            strSql.Append(" where p.prdGuid=@prdGuid");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = prdGuid;

            Twee.Model.Prd model = new Twee.Model.Prd();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 查询产品的最基本信息：名称、价格、图片
        /// </summary>
        public DataTable GetPrdBaseInfo(Guid prdGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select p.prdGuid,p.cateGuid,p.userGuid,p.name,p.estimateprice,p.saleprice,p.wnstat,f.fileurl from wn_prd p");
            strSql.Append(" left join (select fileurl,prdguid from  [dbo].[wn_file] where idx=0 ) f on p.prdGuid= f.prdguid");
            strSql.Append(" where p.prdGuid=@prdGuid");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier)
			};
            parameters[0].Value = prdGuid;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Prd DataRowToModel(DataRow row)
        {
            Twee.Model.Prd model = new Twee.Model.Prd();
            if (row != null)
            {
                if (row["prdGuid"] != null && row["prdGuid"].ToString() != "")
                {
                    model.prdGuid = new Guid(row["prdGuid"].ToString());
                }
                if (row["cateGuid"] != null && row["cateGuid"].ToString() != "")
                {
                    model.cateGuid = new Guid(row["cateGuid"].ToString());
                }
                if (row["userGuid"] != null && row["userGuid"].ToString() != "")
                {
                    model.userGuid = new Guid(row["userGuid"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }

                model.Ranking = 1;
                if (row.Table.Columns.Contains("ranking"))
                {
                    if (row["ranking"] != null)
                    {
                        model.Ranking = row["ranking"].ToString().ToInt();
                    }
                }

                model.AllowCollage = 0;
                if (row.Table.Columns.Contains("AllowCollage"))
                {
                    if (row["AllowCollage"] != null)
                    {
                        model.AllowCollage = row["AllowCollage"].ToString().ToInt();
                    }
                }
                model.IsFeatured = "0";
                if (row.Table.Columns.Contains("IsFeaturedProduct"))
                {
                    if (row["IsFeaturedProduct"] != null)
                    {
                        model.IsFeatured = row["IsFeaturedProduct"].ToString();
                    }
                }

                if (row["edtTime"] != null && row["edtTime"].ToString() != "")
                {
                    model.edtTime = DateTime.Parse(row["edtTime"].ToString());
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
                if (row["estimateprice"] != null && row["estimateprice"].ToString() != "")
                {
                    model.estimateprice = decimal.Parse(row["estimateprice"].ToString());
                }
                if (row["saleprice"] != null && row["saleprice"].ToString() != "")
                {
                    model.saleprice = decimal.Parse(row["saleprice"].ToString());
                }
                if (row["videoUrl"] != null)
                {
                    model.videoUrl = row["videoUrl"].ToString();
                }
                if (row["videoEmbed"] != null)
                {
                    model.videoEmbed = row["videoEmbed"].ToString();
                }
                if (row["wnstat"] != null && row["wnstat"].ToString() != "")
                {
                    model.wnstat = int.Parse(row["wnstat"].ToString());
                }
                if (row["idx"] != null && row["idx"].ToString() != "")
                {
                    model.idx = int.Parse(row["idx"].ToString());
                }
                if (row["txtTag"] != null)
                {
                    model.txtTag = row["txtTag"].ToString();
                }
                if (row["txtinfo"] != null)
                {
                    model.txtinfo = row["txtinfo"].ToString();
                }
                if (row["reviewendtime"] != null && row["reviewendtime"].ToString() != "")
                {
                    model.reviewendtime = DateTime.Parse(row["reviewendtime"].ToString());
                    model.reviewendday = row["reviewendday"].ToString().ToInt();
                }
                if (row["presaleendtime"] != null && row["presaleendtime"].ToString() != "")
                {
                    model.presaleendtime = DateTime.Parse(row["presaleendtime"].ToString());
                }
                if (row["presaleendday"] != null && row["presaleendday"].ToString() != "")
                {
                    model.presaleendday = row["presaleendday"].ToString().ToInt();
                }
                if (row["presaleforward"] != null && row["presaleforward"].ToString() != "")
                {
                    model.presaleForward = row["presaleforward"].ToString().ToInt();
                }

                if (row["saleCount"] != null)
                {
                    model.saleCount = row["saleCount"].ToString().ToInt();
                }
                if (row["txtjj"] != null)
                {
                    model.txtjj = row["txtjj"].ToString();
                }
                if (row["question"] != null)
                {
                    model.question = row["question"].ToString();
                }
                if (row["answer"] != null)
                {
                    model.answer = row["answer"].ToString();
                }
                if (row["supplyPrice"] != null)
                {
                    model.supplyPrice = row["supplyPrice"].ToString().ToDecimal();
                }
                if (row["moq"] != null)
                {
                    model.moq = row["moq"].ToString().ToInt();
                }
                if (row["isSupplier"] != null)
                {
                    model.isSupplier = row["isSupplier"].ToString().ToInt();
                }
                if (row["supplierName"] != null)
                {
                    model.supplierName = row["supplierName"].ToString();
                }
                if (row["supplierWebsite"] != null)
                {
                    model.supplierWebsite = row["supplierWebsite"].ToString();
                }
                if (row["supplierPhone"] != null)
                {
                    model.supplierPhone = row["supplierPhone"].ToString();
                }
                if (row["supplierEmail"] != null)
                {
                    model.supplierEmail = row["supplierEmail"].ToString();
                }
                if (row["supplierAddress"] != null)
                {
                    model.supplierAddress = row["supplierAddress"].ToString();
                }
                if (row["isUseTemp"] != null)
                {    
                    model.isUseTemp = row["isUseTemp"].ToString() == "True" ? 1 : 0;
                }

                if (row["isFreeShipping"] != null)
                {
                    model.IsFreeShipping = row["isFreeShipping"].ToString() == "True" ? true : false;
                }
                if (row["isLimitedTime"] != null)
                {
                    model.IsLimitedTime = row["isLimitedTime"].ToString() == "True" ? true : false;
                }
                if (row["isComingSoon"] != null)
                {
                    model.IsComingSoon = row["isComingSoon"].ToString() == "True" ? true : false;
                }
                
                model.DisplaySpecName = 1;
                if (row["DisplaySpecName"] != null)
                {
                    if ( row["DisplaySpecName"].ToString().Trim() != string.Empty) 
                        model.DisplaySpecName = row["DisplaySpecName"].ToString().ToInt();
                }

                model.DisplaySpecColor = 1;
                if (row["DisplaySpecColor"] != null)
                {
                    if (row["DisplaySpecColor"].ToString().Trim() != string.Empty)
                        model.DisplaySpecColor = row["DisplaySpecColor"].ToString().ToInt();
                }

            }
            return model;
        }

        /// <summary>
        /// 得到:评审区产品实体
        /// </summary>
        public Twee.Model.Prd DataRowToModel2(DataRow row)
        {
            Twee.Model.Prd model = new Twee.Model.Prd();
            if (row != null)
            {
                if (row["prdGuid"] != null && row["prdGuid"].ToString() != "")
                {
                    model.prdGuid = new Guid(row["prdGuid"].ToString());
                }
                if (row["cateGuid"] != null && row["cateGuid"].ToString() != "")
                {
                    model.cateGuid = new Guid(row["cateGuid"].ToString());
                }
                if (row["userGuid"] != null && row["userGuid"].ToString() != "")
                {
                    model.userGuid = new Guid(row["userGuid"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
                if (row["estimateprice"] != null && row["estimateprice"].ToString() != "")
                {
                    model.estimateprice = decimal.Parse(row["estimateprice"].ToString());
                }
                if (row["wnstat"] != null && row["wnstat"].ToString() != "")
                {
                    model.wnstat = int.Parse(row["wnstat"].ToString());
                }
                if (row["idx"] != null && row["idx"].ToString() != "")
                {
                    model.idx = int.Parse(row["idx"].ToString());
                }
                if (row["txtjj"] != null)
                {
                    model.txtjj = row["txtjj"].ToString();
                }
                if (row["fileurl"] != null)
                {
                    model.fileurl = row["fileurl"].ToString();
                }
                if (row["reviewCount"] != null)
                {
                    model.reviewCount = row["reviewCount"].ToString().ToInt();
                }

            }
            return model;
        }

        /// <summary>
        /// 得到:预售区产品实体
        /// </summary>
        public Twee.Model.Prd DataRowToModel3(DataRow row)
        {
            Twee.Model.Prd model = new Twee.Model.Prd();
            if (row != null)
            {
                if (row["prdGuid"] != null && row["prdGuid"].ToString() != "")
                {
                    model.prdGuid = new Guid(row["prdGuid"].ToString());
                }
                if (row["cateGuid"] != null && row["cateGuid"].ToString() != "")
                {
                    model.cateGuid = new Guid(row["cateGuid"].ToString());
                }
                if (row["userGuid"] != null && row["userGuid"].ToString() != "")
                {
                    model.userGuid = new Guid(row["userGuid"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    //model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
                if (row["estimateprice"] != null && row["estimateprice"].ToString() != "")
                {
                    model.estimateprice = decimal.Parse(row["estimateprice"].ToString());
                }
                if (row["saleprice"] != null && row["saleprice"].ToString() != "")
                {
                    model.saleprice = decimal.Parse(row["saleprice"].ToString());
                }
                if (row["minfinalsaleprice"] != null && row["minfinalsaleprice"].ToString() != "")
                {
                    model.minfinalsaleprice = decimal.Parse(row["minfinalsaleprice"].ToString());
                }
 
                if (row["FavoriteCount"] != null && row["FavoriteCount"].ToString() != "")
                {
                    model.favoriteCount = row["FavoriteCount"].ToString().ToInt();
                }

                if (row["favoriteGuid"] != null && row["favoriteGuid"].ToString() != "")
                {
                    model.favoriteGuid = row["favoriteGuid"].ToString();
                }
                
                if (row["wnstat"] != null && row["wnstat"].ToString() != "")
                {
                    model.wnstat = int.Parse(row["wnstat"].ToString());
                }
                if (row["idx"] != null && row["idx"].ToString() != "")
                {
                    model.idx = int.Parse(row["idx"].ToString());
                }
                if (row["txtjj"] != null)
                {
                    model.txtjj = row["txtjj"].ToString();
                }
                if (row["hottip"] != null)
                {
                    model.hottip = row["hottip"].ToString();
                }
                if (row["isFreeShipping"] != null)
                {
                    model.IsFreeShipping = row["isFreeShipping"].ToString() == "True" ? true : false;
                }
                if (row["isLimitedTime"] != null)
                {
                    model.IsLimitedTime = row["isLimitedTime"].ToString() == "True" ? true : false;
                }
                if (row["isComingSoon"] != null)
                {
                    model.IsComingSoon = row["isComingSoon"].ToString() == "True" ? true : false;
                }
                if (row["fileurl"] != null)
                {
                    model.fileurl = row["fileurl"].ToString();
                }
                if (row["saleCount"] != null)
                {
                    model.saleCount = row["saleCount"].ToString().ToInt();
                }
                if (row["presaleforward"] != null)
                {
                    model.presaleForward = row["presaleforward"].ToString().ToInt();
                }
                if (row["presaleendtime"] != null)
                {
                    model.presaleendtime = row["presaleendtime"].ToString().ToDateTime();
                    if (model.presaleendtime != null)
                    {
                        TimeSpan ts = model.presaleendtime.Value - DateTime.Now;
                        model.presaleendday = ts.Days;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 得到:分享区产品实体
        /// </summary>
        public Twee.Model.Prd DataRowToModel4(DataRow row)
        {
            Twee.Model.Prd model = new Twee.Model.Prd();
            if (row != null)
            {
                if (row["prdGuid"] != null && row["prdGuid"].ToString() != "")
                {
                    model.prdGuid = new Guid(row["prdGuid"].ToString());
                }
                if (row["cateGuid"] != null && row["cateGuid"].ToString() != "")
                {
                    model.cateGuid = new Guid(row["cateGuid"].ToString());
                }
                if (row["userGuid"] != null && row["userGuid"].ToString() != "")
                {
                    model.userGuid = new Guid(row["userGuid"].ToString());
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
                if (row["estimateprice"] != null && row["estimateprice"].ToString() != "")
                {
                    model.estimateprice = decimal.Parse(row["estimateprice"].ToString());
                }
                if (row["saleprice"] != null && row["saleprice"].ToString() != "")
                {
                    model.saleprice = decimal.Parse(row["saleprice"].ToString());
                }
                if (row["minfinalsaleprice"] != null && row["minfinalsaleprice"].ToString() != "")
                {
                    model.minfinalsaleprice = decimal.Parse(row["minfinalsaleprice"].ToString());
                }

                if (row["wnstat"] != null && row["wnstat"].ToString() != "")
                {
                    model.wnstat = int.Parse(row["wnstat"].ToString());
                }
                if (row["idx"] != null && row["idx"].ToString() != "")
                {
                    model.idx = int.Parse(row["idx"].ToString());
                }
                if (row["txtjj"] != null)
                {
                    model.txtjj = row["txtjj"].ToString();
                }
                if (row["fileurl"] != null)
                {
                    model.fileurl = row["fileurl"].ToString();
                }
                if (row["shareCount"] != null)
                {
                    model.shareCount = row["shareCount"].ToString().ToInt();
                }

                if (row["favoriteGuid"] != null)
                {
                    model.favoriteGuid = row["favoriteGuid"].ToString();
                }

                if (row["presaleendtime"] != null)
                {
                    model.presaleendtime = row["presaleendtime"].ToString().ToDateTime();
                    if (model.presaleendtime != null)
                    {
                        TimeSpan ts = model.presaleendtime.Value - DateTime.Now;
                        model.presaleendday = ts.Days;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select prdGuid,cateGuid,userGuid,name,edtTime,addtime,estimateprice,saleprice,videoUrl,wnstat,idx,txtTag,txtinfo,reviewendtime,txtjj,question,answer ");
            strSql.Append(" FROM wn_prd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" prdGuid,cateGuid,userGuid,name,edtTime,addtime,estimateprice,saleprice,videoUrl,wnstat,idx,txtTag,txtinfo,reviewendtime,txtjj,question,answer ");
            strSql.Append(" FROM wn_prd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.idx desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wn_prd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "wn_prd";
            parameters[1].Value = "idx";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/


        #endregion  BasicMethod

        #region  ExtensionMethod
        /// <summary>
        /// 添加产品
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
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@result",SqlDbType.Int),
                    new SqlParameter("@guid", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@wnstat",prdState),
                    new SqlParameter("@txtName",name),
                    new SqlParameter("@txtPrice",estimateprice),
                    new SqlParameter("@txtVideoUrl",videoUrl),
                    new SqlParameter("@txtCompanyName",txtCompanyName),
                    new SqlParameter("@txtIndustry",txtIndustry),
                    new SqlParameter("@txtUrl",txtUrl),
                    new SqlParameter("@cateGuid",cateGuid),
                    new SqlParameter("@userguid", userGuid),
                    new SqlParameter("@txtTag", txtTag),
                    new SqlParameter("@txtjl", txtjl),
                    new SqlParameter("@txtDesc",txtDesc),
                    new SqlParameter("@txtkr",txtkr),
                    new SqlParameter("@txtfa", answer),
                    new SqlParameter("@uploadfiles",prdPic),
                    new SqlParameter("@pricelist",prdSupplyPrice),
                    new SqlParameter("@typelist",prdSupplyWay),
                    new SqlParameter("@supplyPrice",supplyPrice),
                    new SqlParameter("@moq",prdMoq),
                    new SqlParameter("@isSupplier",isSupplier),
                    new SqlParameter("@supplierName",supplierName),
                    new SqlParameter("@supplierWebsite",supplierWebsite),
                    new SqlParameter("@supplierPhone",supplierPhone),
                    new SqlParameter("@supplierEmail",supplierEmail),
                    new SqlParameter("@supplierAddress",supplierAddress),
                    new SqlParameter("@isUseTemp",isUseTemp)
                                    };
                parameters[0].Direction = ParameterDirection.Output;
                parameters[1].Direction = ParameterDirection.Output;
                DbHelperSQL.RunProcedure("[Prc_Prd_Add]", parameters);
                result = parameters[0].Value.ToString(); //返回值--方法1
                prdGuid = parameters[1].Value.ToString().ToGuid().Value;
                return result == "1" ? true : false;
            }
            catch (Exception ex)
            {
                log.Error("error", ex);
                throw;
            }


        }



        /// <summary>
        /// 修改产品
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
            Guid prdGuid, out string result)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@result",SqlDbType.Int),
                    new SqlParameter("@guid", prdGuid),               
                    new SqlParameter("@txtName",name),
                    new SqlParameter("@txtPrice",estimateprice),
                    new SqlParameter("@txtVideoUrl",videoUrl),
                    new SqlParameter("@txtCompanyName",txtCompanyName),
                    new SqlParameter("@txtIndustry",txtIndustry),
                    new SqlParameter("@txtUrl",txtUrl),
                    new SqlParameter("@cateGuid",cateGuid),
                    new SqlParameter("@userguid", userGuid),
                    new SqlParameter("@txtTag", txtTag),
                    new SqlParameter("@txtjj", txtjl),
                    new SqlParameter("@txtinfo",txtDesc),
                    new SqlParameter("@question",txtkr),
                    new SqlParameter("@answer", answer),
                    new SqlParameter("@uploadfiles",prdPic),
                    new SqlParameter("@pricelist",prdSupplyPrice),
                    new SqlParameter("@typelist",prdSupplyWay),
                    new SqlParameter("@supplyPrice",supplyPrice),
                    new SqlParameter("@moq",prdMoq),
                    new SqlParameter("@isSupplier",isSupplier),
                    new SqlParameter("@supplierName",supplierName),
                    new SqlParameter("@supplierWebsite",supplierWebsite),
                    new SqlParameter("@supplierPhone",supplierPhone),
                    new SqlParameter("@supplierEmail",supplierEmail),
                    new SqlParameter("@supplierAddress",supplierAddress)

                };
                parameters[0].Direction = ParameterDirection.Output;
                DbHelperSQL.RunProcedure("[Prc_Prd_Edt]", parameters);
                result = parameters[0].Value.ToString(); //返回值--方法1
                prdGuid = parameters[1].Value.ToString().ToGuid().Value;
                return result == "1" ? true : false;
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
            string strSql = "update dbo.wn_prd set wnstat=@wnstat,edtTime=GETDATE() where prdGuid=@prdGuid";
            SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@wnstat",SqlDbType.Int),
                    new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier)        
             };
            parameters[0].Value = prdState;
            parameters[1].Value = prdGuid;
            int resu = DbHelperSQL.ExecuteSql(strSql, parameters);
            return resu > 0 ? true : false;

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
            Guid? userGuid = CommUtil.IsLogion();
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],TT.[userGuid],[cateGuid],[name],[addtime],[txtjj],[estimateprice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime] ,f.fileurl,r.reviewCount, w.guid as favoriteGuid FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("reviewCount"))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (state == "1" || state == "4" || state == "5")
            {
                strSql.Append(" and wnstat=" + state);//大众评审中、推易吧终审中、终审失败
            }
            else if (state == "supply")
            {
                //strSql.Append(" and wnstat in(4,2) ");//竞价供货 = 预售产品+ 终审产品
                strSql.Append(" and wnstat=4 ");//竞价供货 = 预售产品+ 终审产品
            }
            else
            {
                strSql.Append(" and wnstat in(1,4,5)");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                // Search for tag or product name  tags are seperated by comma or spaces
                string sNameLike = CommUtil.GetSqlLike("name", prdName.Trim());
                string sTagLike = CommUtil.GetSqlLike("txtTag", prdName.Trim());
                strSql.Append(" and (( " + sNameLike + ") or (" + sTagLike + "))");
            }
            if (!string.IsNullOrEmpty(prdCate3.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + prdCate3 + "')");
            }
            else if (!string.IsNullOrEmpty(prdCate2.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + prdCate2 + "')");
            }
            else if (!string.IsNullOrEmpty(prdCate1.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + prdCate1 + "')");
            }

            // search for focus categories
            if (focusCateIDs != null && focusCateIDs != "")
            {
                strSql.Append(" and exists ( select * from wn_prdfocusCate x where x.prdGuid = T.prdGuid and x.focusCateID in (" + focusCateIDs + "))");
            }

            strSql.Append(" ) TT");

            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join (select prtguid,COUNT(*) reviewCount from [dbo].[wn_review]  group by prtguid ) r on TT.prdGuid=r.prtguid ");

            // get login user favorite status 
            if (userGuid != null)
            {
                strSql.Append(" left join ( select guid, prtguid from wn_favorite where userguid='" + userGuid.ToString() + "') w  on TT.prdGuid = w.prtguid ");
            }
            else
            {
                strSql.Append(" left join ( select guid, prtguid from wn_favorite where userguid= null) w  on TT.prdGuid = w.prtguid ");
            }

            strSql.Append(" where 1=1 ");


            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            if (orderby.Contains("reviewCount"))
            {
                strSql.AppendFormat(" order by r.reviewCount desc ");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        /// <summary>
        /// get focus category
        /// </summary>
        /// <returns></returns>
        public DataTable GetFocusCate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT focusCateID, name, note ");
            strSql.Append(" from wn_FocusCate where active=1");
            strSql.Append(" order by name");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// Check if the Tweebaa SKU has al ready existed
        /// </summary>
        public bool IsTweebaaSKUExist(string sTweebaaSKU)
        {
            string sSql = "select count(*) from wn_prorules where prosku='" + CommUtil.Quo(sTweebaaSKU) + "'";
            int iCnt = DbHelperSQL.QueryCount(sSql);
            return iCnt > 0 ? true : false;
        }


        /// <summary>
        /// Check if the user is the submitter of a product
        /// </summary>
        public bool IsUserSubmitter(Guid userGuid, Guid prdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_prd");
            strSql.Append(" where userGuid=@userGuid and prdGuid=@prdGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@userGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = userGuid;
            parameters[1].Value = prdGuid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// Check if the user is the evaluator of a product
        /// </summary>
        public bool IsUserEvaluator(Guid userGuid, Guid prdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_review");
            strSql.Append(" where userGuid=@userGuid and prtGuid=@prdGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@userGuid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = userGuid;
            parameters[1].Value = prdGuid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        public DataTable GetShopIndexData1()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from vw_ShopHomepage1 ");
            //strSql.Append("select * from vw_ShopHomepage6 ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }
        public DataTable GetShopIndexData2()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from vw_ShopHomepage2 ");
            //strSql.Append("select * from vw_ShopHomepage6 ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }
        public DataTable GetShopIndexData3()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from vw_ShopHomepage3 ");
            //strSql.Append("select * from vw_ShopHomepage6 ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }
        public DataTable GetShopIndexData4()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from vw_ShopHomepage4  ");
            //strSql.Append("select * from vw_ShopHomepage6 ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }
        public DataTable GetShopIndexData5()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from vw_ShopHomepage5 ");
            //strSql.Append("select * from vw_ShopHomepage6 ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

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
            Guid? userGuid = CommUtil.IsLogion();

            if (prdCate1 == "AboutUs.aspx" || prdCate1=="SendWholesaleInquiryEmail.aspx")
            {
                prdCate1 ="";
                Twee.Comm.CommHelper.WrtLog("AboutUs.aspx????");
            }
            if (prdCate2 == "AboutUs.aspx" || prdCate2 == "SendWholesaleInquiryEmail.aspx")
            {
                prdCate2 = "";
                Twee.Comm.CommHelper.WrtLog("AboutUs.aspx????");
            }
            if (prdCate3 == "AboutUs.aspx" || prdCate3 == "SendWholesaleInquiryEmail.aspx")
            {
                prdCate3 = "";
                Twee.Comm.CommHelper.WrtLog("AboutUs.aspx????");
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],TT.[userGuid],[cateGuid],[name],[addtime],[txtjj],[estimateprice],[saleprice], y.MinFinalSalePrice, TT.[wnstat],TT.[hottip],TT.[isFreeShipping],TT.[isLimitedTime],TT.[isComingSoon],TT.[idx],[reviewendtime] ,[presaleendtime],[saleprice],[presaleforward],f.fileurl,s.saleCount, v.FavoriteCount, w.guid as favoriteGuid FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("saleCount"))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (state == "2" || state == "3" )
            {
                strSql.Append(" and wnstat="+state);//预售中、销售中
            }  
            else
            {
                //strSql.Append(" and wnstat in(2,6,7,3) ");
                strSql.Append(" and wnstat in(2,3) ");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                // search by sku #
                if (CommUtil.IsTweebaaSku(prdName.Trim())) {
                    strSql.Append (" and prdGuid in ( select proid from wn_proRules where wn_proRules.prosku='" + prdName.Trim() +  "')"); 
                }
                else {
                    // Search for tag or product name  tags are seperated by comma or spaces
                    string sNameLike = CommUtil.GetSqlLike("name", prdName.Trim());
                    string sTagLike = CommUtil.GetSqlLike("txtTag", prdName.Trim());

                    //Add by Long 2015/12/22 base on Mantishub 1361
                    string sTxtInfo = CommUtil.GetSqlLike("txtinfo", prdName.Trim());
                    string txtjj = CommUtil.GetSqlLike("txtjj", prdName.Trim());

                    strSql.Append(" and (( " + sNameLike + ") or (" + sTagLike + ")" + " or (" + sTxtInfo + ")" + " or (" + sTxtInfo + "))");
                }
                //strSql.Append(" and name like '%" + prdName + "%'");
            }

            // search by 3 level categories
            if (!string.IsNullOrEmpty(prdCate3.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + prdCate3 + "')");
            }
            else if (!string.IsNullOrEmpty(prdCate2.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + prdCate2 + "')");
            }
            else if (!string.IsNullOrEmpty(prdCate1.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + prdCate1 + "')");
            }

            // search for focus categories
            if (focusCateIDs != null && focusCateIDs != "")
            {
                strSql.Append(" and exists ( select * from wn_prdfocusCate x where x.prdGuid = T.prdGuid and x.focusCateID in (" + focusCateIDs + "))");
            }
           
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join (select  prdGuid,COUNT(prdGuid) saleCount from  dbo.wn_orderBody b left join wn_orderhead h on b.headGuid=h.guid where h.wnstat in(1,2,3,-2,-3) group by b.prdGuid) s on TT.prdGuid=s.prdGuid ");
            strSql.Append(" left join vw_ProductMinFinalSalePrice y on TT.prdGuid = y.prdGuid ");
            strSql.Append(" left join vw_ProductFavoriteCount v on TT.prdGuid = v.prdGuid ");

            // get login user favorite status 
            if (userGuid != null)
            {
                strSql.Append(" left join ( select guid, prtguid from wn_favorite where userguid='" + userGuid.ToString() +  "') w  on TT.prdGuid = w.prtguid ");
            }
            else
            {
                strSql.Append(" left join ( select guid, prtguid from wn_favorite where userguid= null) w  on TT.prdGuid = w.prtguid ");
            }

            strSql.Append(" where 1=1 ");

 
            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("saleCount"))
            {
                strSql.Append(" order by TT." + orderby);
            }
            if (orderby.Contains("saleCount"))
            {
                strSql.AppendFormat(" order by s.saleCount desc ");
            }

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        public DataTable MobileAppGetCollagePrd(string prdName, string cate, string focusCateIDs, string prdCate1, string prdCate2, string prdCate3, string state, string orderby, int startIndex, int endIndex)
        {
            Guid? userGuid = CommUtil.IsLogion();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],TT.[userGuid],[cateGuid],[name],[addtime],[txtjj],[estimateprice],[saleprice], y.MinFinalSalePrice, TT.[wnstat],TT.[hottip],TT.[isFreeShipping],TT.[isLimitedTime],TT.[isComingSoon],TT.[idx],[reviewendtime] ,[presaleendtime],[saleprice],[presaleforward],f.fileurl,s.saleCount, v.FavoriteCount, w.guid as favoriteGuid FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("saleCount"))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where AllowCollage=1 and 1=1 ");
            if (state == "2" || state == "3")
            {
                strSql.Append(" and wnstat=" + state);//预售中、销售中
            }
            else
            {
                //strSql.Append(" and wnstat in(2,6,7,3) ");
                strSql.Append(" and wnstat in(2,3) ");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                // search by sku #
                if (CommUtil.IsTweebaaSku(prdName.Trim()))
                {
                    strSql.Append(" and prdGuid in ( select proid from wn_proRules where wn_proRules.prosku='" + prdName.Trim() + "')");
                }
                else
                {
                    // Search for tag or product name  tags are seperated by comma or spaces
                    string sNameLike = CommUtil.GetSqlLike("name", prdName.Trim());
                    string sTagLike = CommUtil.GetSqlLike("txtTag", prdName.Trim());
                    strSql.Append(" and (( " + sNameLike + ") or (" + sTagLike + "))");
                }
                //strSql.Append(" and name like '%" + prdName + "%'");
            }

            // search by 3 level categories
            if (!string.IsNullOrEmpty(prdCate3.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + prdCate3 + "')");
            }
            else if (!string.IsNullOrEmpty(prdCate2.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + prdCate2 + "')");
            }
            else if (!string.IsNullOrEmpty(prdCate1.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + prdCate1 + "')");
            }

            // search for focus categories
            if (focusCateIDs != null && focusCateIDs != "")
            {
                strSql.Append(" and exists ( select * from wn_prdfocusCate x where x.prdGuid = T.prdGuid and x.focusCateID in (" + focusCateIDs + "))");
            }

            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join (select  prdGuid,COUNT(prdGuid) saleCount from  dbo.wn_orderBody b left join wn_orderhead h on b.headGuid=h.guid where h.wnstat in(1,2,3,-2,-3) group by b.prdGuid) s on TT.prdGuid=s.prdGuid ");
            strSql.Append(" left join vw_ProductMinFinalSalePrice y on TT.prdGuid = y.prdGuid ");
            strSql.Append(" left join vw_ProductFavoriteCount v on TT.prdGuid = v.prdGuid ");

            // get login user favorite status 
            if (userGuid != null)
            {
                strSql.Append(" left join ( select guid, prtguid from wn_favorite where userguid='" + userGuid.ToString() + "') w  on TT.prdGuid = w.prtguid ");
            }
            else
            {
                strSql.Append(" left join ( select guid, prtguid from wn_favorite where userguid= null) w  on TT.prdGuid = w.prtguid ");
            }

            strSql.Append(" where 1=1 ");


            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("saleCount"))
            {
                strSql.Append(" order by TT." + orderby);
            }
            if (orderby.Contains("saleCount"))
            {
                strSql.AppendFormat(" order by s.saleCount desc ");
            }

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

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
            Guid? userGuid = CommUtil.IsLogion();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],TT.[userGuid],[cateGuid],[name],[addtime],[txtjj],[estimateprice],[saleprice],  y.minfinalsaleprice, TT.[wnstat],TT.[idx],[reviewendtime] ,[presaleendtime],[saleprice],f.fileurl,s.shareCount, w.guid as favoriteGuid FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("shareCount"))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (state == "2")
            {
                strSql.Append(" and wnstat in (2,6,7) ");
            }
            else if (state == "3")
            {
                strSql.Append(" and wnstat=3 ");
            }
            else
            {
                strSql.Append(" and wnstat in(2,6,7,3) ");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                // search by tweebaa sku #
                if (CommUtil.IsTweebaaSku(prdName.Trim()))
                {
                    strSql.Append(" and prdGuid in ( select proid from wn_proRules where wn_proRules.prosku='" + prdName.Trim() + "')");
                }
                else
                {
                    // Search for tag or product name  tags are seperated by comma or spaces
                    string sNameLike = CommUtil.GetSqlLike("name", prdName.Trim());
                    string sTagLike = CommUtil.GetSqlLike("txtTag", prdName.Trim());
                    strSql.Append(" and (( " + sNameLike + ") or (" + sTagLike + "))");
                    //strSql.Append(" and name like '%" + prdName + "%'");
                }
            }

            if (!string.IsNullOrEmpty(prdCate3.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + prdCate3 + "')");
            }
            else if (!string.IsNullOrEmpty(prdCate2.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + prdCate2 + "')");
            }
            else if (!string.IsNullOrEmpty(prdCate1.Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + prdCate1 + "')");
            }

            // search for focus categories
            if (focusCateIDs != null && focusCateIDs != "")
            {
                strSql.Append(" and exists ( select * from wn_prdfocusCate x where x.prdGuid = T.prdGuid and x.focusCateID in (" + focusCateIDs + "))");
            }

            strSql.Append(" ) TT");
            strSql.Append(" left join (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join (select prtguid,COUNT(prtguid) shareCount from  wn_share  group by prtguid ) s on TT.prdGuid=s.prtguid ");
            strSql.Append(" left join vw_ProductMinFinalSalePrice y on TT.prdGuid=y.prdguid ");

            // get login user favorite status 
            if (userGuid != null)
            {
                strSql.Append(" left join ( select guid, prtguid from wn_favorite where userguid='" + userGuid.ToString() + "') w  on TT.prdGuid = w.prtguid ");
            }
            else
            {
                strSql.Append(" left join ( select guid, prtguid from wn_favorite where userguid= null) w  on TT.prdGuid = w.prtguid ");
            }


            strSql.Append(" where 1=1 ");

            
            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("shareCount"))
            {
                strSql.Append("order by TT." + orderby);
            }
            if (orderby.Contains("shareCount"))
            {
                strSql.AppendFormat(" order by s.shareCount desc ");
            }

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        #region 会员中心

        /// <summary>
        /// 获取会员中心我的发布
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetMySubpllay(string userID, string prdName, string cate, string state, string orderby, int startIndex, int endIndex,string begTime,string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],TT.[userGuid],[cateGuid],[name],[addtime],[txtjj],[estimateprice],[saleprice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime] ,f.fileurl,r.reviewCount FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat="+state);
            }
            //else
            //{
            //    strSql.Append(" and wnstat!=0 ");
            //}
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and userGuid = '" + userID + "'");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
            if (!string.IsNullOrEmpty(cate.Trim()))
            {
                strSql.Append(" and cateGuid='" + cate + "'");
            }
            if (!string.IsNullOrEmpty(begTime.Trim()))
            {
                //strSql.Append(" and addtime>='" + begTime + "'");
                string sBegTime = CommUtil.ToDBDateFormat(begTime);
                strSql.Append(" and addtime>='" + sBegTime + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                //strSql.Append(" and addtime<='" + endTime + "'");
                string sEndTime = CommUtil.ToDBDateFormat(endTime);
                strSql.Append(" and addtime<='" + sEndTime + " 23:59'");
            }           
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join (select prtguid,COUNT(*) reviewCount from [dbo].[wn_review]  group by prtguid ) r on TT.prdGuid=r.prtguid ");
            strSql.Append(" where 1=1 ");
            strSql.AppendFormat(" and  TT.Row between {0} and {1} order by TT.edttime desc", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        /// <summary>
        /// 获取会员中心我的发布 grand total by status
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetMySuggestGrandTotal(string userGuid)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select wnstat as Product_Status, count(*) as Product_Count from  wn_prd ");
            sSql.Append("where 1=1 ");
            if (!string.IsNullOrEmpty(userGuid.Trim()))
            {
                sSql.Append(" and userguid = '" + userGuid + "'");
            }
            sSql.Append(" group by wnstat;");


            // select suggestion commission
            sSql.Append("select sum(money) as TotalSuggestCommission from wn_Profit ");
            sSql.Append(" where type='Submit Income' ");
            if (!string.IsNullOrEmpty(userGuid.Trim()))
            {
                sSql.Append(" and userId = '" + userGuid + "';");
            }
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            return ds;
        }


        /// <summary>
        /// 获取会员中心我的发布(记录总数)
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="prdName"></param>
        /// <param name="cate"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int GetMySubpllayCount(string userID, string prdName, string cate, string state, string begTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from  wn_prd  where 1=1 ");           
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat='" + state + "'");
            }            
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and userGuid = '" + userID + "'");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
            if (!string.IsNullOrEmpty(cate.Trim()))
            {
                strSql.Append(" and cateGuid='" + cate + "'");
            }
            if (!string.IsNullOrEmpty(begTime.Trim()))
            {
                string sBegTime = CommUtil.ToDBDateFormat(begTime);
                strSql.Append(" and addtime>='" + sBegTime + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                string sEndTime = CommUtil.ToDBDateFormat(endTime);
                strSql.Append(" and addtime<='" + sEndTime + " 23:59'");
            }      
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().ToInt();
            }
            return 0;

        }

        /// <summary>
        /// 获取会员中心我的收藏（预售中的产品的销售信息：已预售数量、金额、预售结束时间）
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public DataTable GetHomeCollectionForSale(string prdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[name],TT.[wnstat],[estimateprice],s.count,[estimateprice]*s.count as summoney,[reviewendtime] FROM wn_prd TT  ");
            strSql.Append(" left join (select distinct b.prdGuid,c.count from  dbo.wn_orderhead h left join dbo.wn_orderBody b on h.guid=b.headGuid   left join (select  prdGuid,COUNT(*) count from  dbo.wn_orderBody group by prdGuid ) c on b.prdGuid=c.prdGuid) s on TT.prdGuid=s.prdGuid ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(prdGuid))
            {
                strSql.Append(" and TT.prdguid='" + prdGuid + "'");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        #endregion



        #endregion

        #region 后台方法
        /// <summary>
        /// Get Product Focus category Column Name List
        /// </summary>
        /// <returns></returns>
        public bool MgeSaveProducFocusCate(string sProductIDs, string sFocusCateIDs)
        {
            string[] sProductIDList = sProductIDs.Split(',');
            string[] sFocusCateIDList = sFocusCateIDs.Split(',');

            DB db = new DB();
            db.DBConnect();
            db.DBBeginTrans();

            StringBuilder sSql = new StringBuilder();
            StringBuilder sSqlProductID = new StringBuilder();
            foreach (string sPrdID in sProductIDList)
            {
                sSql.Clear();
                sSql.Append("delete from wn_prdFocusCate where prdGuid = '" + sPrdID + "'");
                int iRet = db.DBExecute(sSql.ToString());

                if (sFocusCateIDs.Length > 0)
                {
                    foreach (string sFocusCateID in sFocusCateIDList)
                    {
                        sSql.Clear();
                        sSql.Append("insert into wn_prdFocusCate(prdGuid, focusCateID)");
                        sSql.Append(" values(");
                        sSql.Append("'" + sPrdID + "'," + sFocusCateID + ")");
                        iRet = db.DBExecute(sSql.ToString());
                    }
                }
            }
            db.DBCommitTrans();
            db.DBDisconnect();
            return true;        
        }

        /// <summary>
        /// Get Product Focus category Column Name List
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetFocusCateList()
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append("select * from wn_FocusCate");
             sSql.Append(" where Active = 1");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return (ds.Tables[0]);
            }
            return null;
        }
        /// <summary>
        /// Get Product Focus category Column Name List
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetFocusCateColumnNameList()
        {
            StringBuilder sSql = new StringBuilder();

            // focus cate column name =  ID + "_" + Name
            sSql.Append("select CONVERT(varchar, FocusCateID)  + '_' + Name as ColumnName from wn_FocusCate");
            sSql.Append(" where Active = 1");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return (ds.Tables[0]);
            }
            return null;
        }


        /// <summary>
        /// Get Product Focus categoryList
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetProductFocusCateList(string sSearchKeyword, bool bSearchHasNotFocusCate, int iProductStatusId, int iStartIdx, int iEndIdx, out int iTotalCount)
        {
            StringBuilder sSql = new StringBuilder();
            int iTotalFocusCate = 0;

            // get total count of focus category
            sSql.Append("select count(*) from wn_FocusCate");
            sSql.Append(" where active=1");
            DataTable dt;
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iTotalFocusCate = dt.Rows[0][0].ToString().ToInt();
                }
            }

            int iStartRow = (iStartIdx - 1) * iTotalFocusCate  + 1;
            int iEndRow = iEndIdx * iTotalFocusCate;

            string sSqlLikeProductName = string.Empty;
            string sSqlLikeProductTag = string.Empty;

            if (sSearchKeyword != string.Empty)
            {
                sSqlLikeProductName = CommUtil.GetSqlLike("a.name", sSearchKeyword);
                sSqlLikeProductTag = CommUtil.GetSqlLike("a.txtTag", sSearchKeyword);
            }

            // create common SQL
            StringBuilder sSqlComm = new StringBuilder();
            sSqlComm.Append("SELECT ROW_NUMBER()  over ( ORDER BY a.name, a.prdGuid, b.FocusCateID) as Row");
            sSqlComm.Append(" ,a.name as ProductName, a.prdGuid as ProductGuid, b.FocusCateID, b.Name AS FocusCateName, b.Note as FocusCateNote, c.FocusCateID AS ProductFocusCateID");
            sSqlComm.Append(" FROM wn_prd AS a CROSS JOIN wn_FocusCate AS b ");
            sSqlComm.Append(" LEFT OUTER JOIN wn_prdFocusCate AS c ON c.prdGuid = a.prdGuid AND c.focusCateID = b.FocusCateID");
            sSqlComm.Append(" where b.Active = 1");
            if (sSearchKeyword != string.Empty) {
                sSqlComm.Append(" and ((" + sSqlLikeProductName + ") or (" + sSqlLikeProductTag + "))");
            }
            if (bSearchHasNotFocusCate)
            {
                sSqlComm.Append(" and a.prdguid not in (select distinct prdguid from wn_prdFocusCate)");
            }
            if (iProductStatusId != -1)
            {
                sSqlComm.Append(" and a.wnstat =" + iProductStatusId.ToString());
            }
            // retrieve total count
            iTotalCount = 0;
            sSql.Clear();
            sSql.Append("select count(*) from (");
            sSql.Append(sSqlComm.ToString());
            sSql.Append(") as t");
            ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iTotalCount = dt.Rows[0][0].ToString().ToInt() / iTotalFocusCate ;  // because the join is a cross join of all focus categores
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
            dt = ds.Tables[0];
            if (dt.Rows.Count == 0) return null;

            // Create the Product-Focus Categories data list programly
            int i = 0;
            DataTable dtList = new DataTable();
            DataColumn dcRow = new DataColumn("Row");
            dcRow.DataType = System.Type.GetType("System.Int32");
            dtList.Columns.Add(dcRow);

            DataColumn dcProductName = new DataColumn("ProductName");
            dcProductName.DataType = System.Type.GetType("System.String");
            dtList.Columns.Add(dcProductName);

            DataColumn dcProductGuid = new DataColumn("ProductGuid");
            dcProductGuid.DataType = System.Type.GetType("System.String");
            dtList.Columns.Add(dcProductGuid);

            for (i = 0; i < iTotalFocusCate; i++)
            {
                DataRow dr = dt.Rows[i];
                string sFocusCateName = dr["FocusCateID"].ToString() + "_" + dr["FocusCateName"].ToString();
                DataColumn dc = new DataColumn(sFocusCateName);
                dc.DataType = System.Type.GetType("System.String");
                dtList.Columns.Add(dc);
            }

            // Pivot the data for all Product-Focus Categories
            DataRow newRow = dtList.NewRow(); 
            
            i = 0;
            foreach( DataRow dr in dt.Rows)
            {
                if (i == 0)
                {

                    dtList.Rows.Add(newRow);
                    newRow["Row"] = dr["Row"].ToString().ToInt();
                    newRow["ProductName"] = System.Net.WebUtility.HtmlEncode(dr["ProductName"].ToString());
                    newRow["ProductGuid"] = dr["ProductGuid"].ToString();
                }
                string sFocusCateName = dr["FocusCateID"].ToString() + "_" + dr["FocusCateName"].ToString();
                newRow[sFocusCateName] = "";
                if (dr["ProductFocusCateID"] != null) 
                {
                    if (dr["ProductFocusCateID"].ToString() != string.Empty ) 
                        newRow[sFocusCateName] = "Y";
                }

                if (++i >= iTotalFocusCate)
                {
                    newRow = dtList.NewRow();
                    i = 0;
                }
            }
            return dtList;

        }

        /// <summary>
        /// Update focus category
        /// </summary>
        /// <returns></returns>
        public string MgeUpdateFocusCate(string sID, string sName, string sNote, string sActive)
        {
            StringBuilder sSql = new StringBuilder();

            // check if the name exists
            sSql.Append("select count(*) from wn_FocusCate");
            sSql.Append(" where Name ='" + CommUtil.Quo(sName) + "'");
            sSql.Append("   and FocusCateID <> " + sID);
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    int iCnt = dt.Rows[0][0].ToString().ToInt();
                    if (iCnt > 0) return sName + " already existed!";
                }
            }

            // update 
            sSql.Append("update wn_FocusCate set ");
            sSql.Append(" Name ='" + CommUtil.Quo(sName) + "',");
            sSql.Append(" Note ='" + CommUtil.Quo(sNote) + "',");
            sSql.Append(" Active =" + CommUtil.Quo(sActive));
            sSql.Append(" where FocusCateID=" + sID);

            int iRet = DbHelperSQL.ExecuteSql(sSql.ToString());
            if (iRet == 1)
            {
                return sName + " has been updated successfully";
            }
            return "Failed to update the By Focus Category!";
        }


        /// <summary>
        /// get focus category
        /// </summary>
        /// <returns></returns>
        public string MgeAddFocusCate(string sName, string sNote, string sActive)
        {
            StringBuilder sSql = new StringBuilder();

            // check if the name exists
            sSql.Append("select count(*) from wn_FocusCate where Name ='" + CommUtil.Quo(sName) + "'");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if ( ds != null && ds.Tables.Count > 0) {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count >0 ) {
                    int iCnt = dt.Rows[0][0].ToString().ToInt();
                    if ( iCnt > 0 ) return sName + " already existed!"; 
                }
            }

            // insert 
            sSql.Append("insert into wn_FocusCate(Name, Note, Active)");
            sSql.Append(" values(");
            sSql.Append("'" +  CommUtil.Quo(sName) + "'," );
            sSql.Append("'" + CommUtil.Quo(sNote) + "',");
            sSql.Append( sActive + ")");

            int iRet  = DbHelperSQL.ExecuteSql(sSql.ToString());
            if (iRet == 1) {
                return sName + " has been added successfully"; 
            }
            return "Failed to add the new By Focus Category!";
        }

        /// <summary>
        /// get focus category
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetFocusCateInfo(string sFocusCateID)
        {
            StringBuilder sSql = new StringBuilder();

            // select total count
            sSql.Append("select * from wn_FocusCate");
            sSql.Append(" where FocusCateID=" + sFocusCateID);
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return (ds.Tables[0]);
            }
            return null;
        }



        /// <summary>
        /// get focus category
        /// </summary>
        /// <returns></returns>
        public DataTable MgeGetFocusCateList(int iStartIdx, int iEndIdx, out int iTotalCount)
        {
            StringBuilder sSql = new StringBuilder();

            iTotalCount = 0;
            
            // select total count
            sSql.Append("select count(*) from wn_FocusCate");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    iTotalCount = dt.Rows[0][0].ToString().ToInt();
                }
            }

            // select data list
            sSql.Clear();
            sSql.Append("select * from (");
            sSql.Append("select ROW_NUMBER() OVER (Order by Name) as Row, FocusCateID, Name, Note, Active ");
            sSql.Append(" from wn_FocusCate");
            sSql.Append(") as t ");
            sSql.Append("where t.Row between " + iStartIdx.ToString() + " and " +iEndIdx.ToString());

            ds = DbHelperSQL.Query(sSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        /// <summary>
        /// 更新名称、预估价格、状态
        /// </summary>
        public bool MgeUpdatePrd(Guid prdGuid, int wnstat, string name, string cateGuid)
        {
            StringBuilder strSql = new StringBuilder();

            SqlParameter[] parameters = {
            new SqlParameter("@name", SqlDbType.NVarChar,20),
            new SqlParameter("@wnstat", SqlDbType.Int,4),           
            new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
            new SqlParameter("@cateGuid", SqlDbType.UniqueIdentifier,16)                        
        };

            parameters[0].Value = name;
            parameters[1].Value = wnstat;
            parameters[2].Value = prdGuid;

            if (!string.IsNullOrEmpty(cateGuid))
            {
                Guid guid = new Guid(cateGuid);
                strSql.Append("update wn_prd set name=@name, wnstat=@wnstat,cateGuid=@cateGuid  where prdGuid=@prdGuid ");
                parameters[3].Value = guid;

            }
            else
            {
                strSql.Append("update wn_prd set name=@name, wnstat=@wnstat where prdGuid=@prdGuid ");
                parameters[3].Value = null;
            }

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据产品id获取产品详情内容
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public DataTable MgeGetPrdInfoByID(string prdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("  select videoUrl,txtinfo from  dbo.wn_prd where  prdGuid='{0}' ", prdGuid);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

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
            sumCount = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],TT.[userGuid],[cateGuid],[name],[addtime],[estimateprice],[saleprice],TT.[wnstat],[reviewendtime] ,[presaleendtime],[saleprice],f.fileurl FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("saleCount"))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (!string.IsNullOrEmpty(state))
            {
                strSql.Append(" and wnstat=" + state);
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" where 1=1 ");

            string countSql = strSql.ToString();

            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("saleCount"))
            {
                strSql.Append("order by TT." + orderby);
            }
            strSql.Append(";" + countSql);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                sumCount = ds.Tables[1].Rows.Count;
                return ds.Tables[0];
            }

            return null;
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
            sumCount = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.proid, TT.provideUser,TT.provideTime,prd.[name],prd.[addtime],prd.[estimateprice],prd.[saleprice],prd.[wnstat],prd.[reviewendtime] ,prd.[presaleendtime],[cateGuid],f.fileurl FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by createtime desc");
            strSql.Append(")AS Row,T.proid, T.userid provideUser,T.createtime provideTime  from wn_prodetails T where T.state=2 ");
            if (!string.IsNullOrEmpty(prdGuid.Trim()))
            {
                strSql.Append(" and T.proid ='" + prdGuid + "'");
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join wn_prd prd on TT.proid=prd.prdGuid");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on prd.prdguid= f.prtguid ");
            strSql.Append(" where prd.wnstat=6");
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and prd.name like '%" + prdName + "%'");
            }
            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            string countSql = " select count(*) from wn_prodetails where state=2;";
            strSql.Append(";" + countSql);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                sumCount = ds.Tables[1].Rows.Count;
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        ///  获取可以导入仓库的产品信息：=等待上架中的产品(状态=6) + 并且是已经采纳供货的(状态=2)
        /// </summary>
        /// <param name="prdGuid">产品id</param>
        /// <param name="prdState">产品状态</param>
        /// <param name="sumCount">记录总数</param>
        /// <returns></returns>
        public DataTable MgeGetPrdNeetToPurchase(string prdName, string prdGuid, int startIndex, int endIndex, out int sumCount)
        {
            sumCount = 0;
            return null;
        }


        /// <summary>
        /// 修改产品详情内容
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <param name="contInfo"></param>
        /// <returns></returns>
        public bool MgeUpdatePrdContent(Guid prdGuid, string contInfo, string videoUrl)
        {
            StringBuilder strSql = new StringBuilder();

            SqlParameter[] parameters = {
            new SqlParameter("@contInfo", SqlDbType.Text),     
            new SqlParameter("@videoUrl", SqlDbType.NVarChar,1500),    
            new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)                                  
        };
            parameters[0].Value = contInfo;
            parameters[1].Value = videoUrl;
            parameters[2].Value = prdGuid;
            strSql.Append("update dbo.wn_prd set txtinfo=@contInfo,videoUrl=@videoUrl where prdGuid=@prdGuid ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改产品缩略图
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <param name="listPic"></param>
        /// <returns></returns>
        public bool MgeUpdatePrdFile(Guid prdGuid, List<string> listPic,string video)
        {
            try
            {
                string strSql = "update wn_prd set videoUrl='" + video + "' where prdGuid='" + prdGuid + "'; delete from  dbo.wn_file  where prdguid='" + prdGuid + "'";
                int dele = DbHelperSQL.ExecuteSql(strSql);
                //if (dele > 0)
                //{
                    for (int i = 0; i < listPic.Count; i++)
                    {
                        SqlParameter[] parameters = new SqlParameter[4];
                        parameters[0] = new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier, 16);
                        parameters[1] = new SqlParameter("@fileurl", SqlDbType.NVarChar, 200);
                        parameters[2] = new SqlParameter("@idx", SqlDbType.Int);
                        parameters[3] = new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier, 16);

                        parameters[0].Value = prdGuid;
                        parameters[1].Value = listPic[i];
                        parameters[2].Value = i;
                        parameters[3].Value = prdGuid;
                        int rows = DbHelperSQL.ExecuteSql(" insert into dbo.wn_file (fileurl,idx,prdguid,prtguid)values(@fileurl,@idx,@prdguid,@prtguid)", parameters);
                    }
                //}
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 获取产品缩略图图片
        /// </summary>
        /// <param name="prdGuid"></param>
        /// <returns></returns>
        public DataTable MgeGetPrdPic(string prdGuid)
        {
            string sql = " select * from wn_file where prdguid='" + prdGuid + "'";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool MgeDelete(Guid prdGuid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_prd ");
            strSql.Append(" where prdGuid=@prdGuid ");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = prdGuid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获得评审区产品数据列表
        /// </summary>
        public DataTable MgeGetListReview(string prdName, string userName, string state, string orderby, int startIndex, int endIndex)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],[name],[addtime],[txtjj],[estimateprice],[supplyPrice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime] ,f.fileurl,r.allcount,r.count0, r.count1,u.username  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat='" + state + "'");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name='" + prdName + "'");
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join (select prtguid,COUNT(*) allcount, count(case when cmdtype2='1' then 'count1' end) count1, count(case when cmdtype2='0' then 'count0' end) count0 from [dbo].[wn_review] group by prtguid ) r on TT.prdGuid=r.prtguid ");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");

            strSql.Append(" where 1=1 ");

            if (userName.Trim() != "")
            {
                strSql.Append(" and username='" + userName + "'");
            }
            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  p.[prdguid],[cateGuid],[userGuid],[name],[txtjj] ,[addtime],[estimateprice],p.[wnstat],p.[idx],[txtTag],[reviewendtime] ,f.fileurl,s.count,u.username  ");
            strSql.Append(" FROM [dbo].[wn_prd] p ");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on p.prdguid= f.prtguid ");
            strSql.Append(" left join (select distinct b.prdGuid,c.count from  dbo.wn_orderhead h left join dbo.wn_orderBody b on h.guid=b.headGuid   left join (select  prdGuid,COUNT(*) count from  dbo.wn_orderBody group by prdGuid ) c on b.prdGuid=c.prdGuid) s on p.prdGuid=s.prdGuid ");
            strSql.Append(" left join [dbo].[wn_user] u on p.userGuid=u.guid ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        /// <summary>
        /// 旧版产品销售区
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="userName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable MgeGetListSale(string prdName, string userName, string state, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],[name],[txtjj],[addtime],[estimateprice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime] ,f.fileurl,s.count,u.username FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name='" + prdName + "'");
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join (select distinct b.prdGuid,c.count from  dbo.wn_orderhead h left join dbo.wn_orderBody b on h.guid=b.headGuid   left join (select  prdGuid,COUNT(*) count from  dbo.wn_orderBody group by prdGuid ) c on b.prdGuid=c.prdGuid) s on TT.prdGuid=s.prdGuid ");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");
            strSql.Append(" where 1=1 ");
            if (userName.Trim() != "")
            {
                strSql.Append(" and username='" + userName + "'");
            }
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and TT.wnstat='" + state + "'");
            }
            strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  count(*) ");
            strSql.Append(" FROM [dbo].[wn_prd] TT left join  [dbo].[wn_user] u on TT.userGuid=u.guid ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and TT.name='" + prdName + "'");
            }
            if (state != "")
            {
                strSql.Append(" and TT.[wnstat]=" + state);
            }
            if (userName.Trim() != "")
            {
                strSql.Append(" and username='" + userName + "'");
            }

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.prdGuid,TT.name,TT.addtime,TT.wnstat,TT.userGuid, f.fileurl  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.addtime desc");
            }
            strSql.Append(")AS Row, T.*  from dbo.wn_prd T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join (select fileurl,prdguid from dbo.wn_file where idx=1 ) f on TT.prdGuid=f.prdguid ");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }


            //select p.prdGuid,p.name,p.addtime,p.wnstat, f.fileurl 
            //from dbo.wn_prd p left join dbo.wn_file f on p.prdGuid=f.prdguid

        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int MgeGetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1)  FROM dbo.wn_prd T  ");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
            //select p.prdGuid,p.name,p.addtime,p.wnstat, f.fileurl 
            //from dbo.wn_prd p left join dbo.wn_file f on p.prdGuid=f.prdguid

        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet MgeGetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" prdGuid ");
            strSql.Append(" FROM wn_prd ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataTable MgeGetSKUShipToCountryList(int iRuleID)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("SELECT 1 AS selected, x.id, x.country, x.code, a.ProductShipToCountry_IsFree, x.sort_order");
            sSql.Append(" FROM wn_country x INNER JOIN");
            sSql.Append("      wn_ProductShipToCountry AS a ON x.id = a.Country_ID INNER JOIN");
            sSql.Append("      wn_proRules AS b ON b.proid = a.prdGuid AND b.userid = a.userGuid");
            sSql.Append(" WHERE b.id = " + iRuleID.ToString() );
            sSql.Append(" UNION");
            sSql.Append(" select 0 AS selected, id, country, code, 0, sort_order");
            sSql.Append(" FROM   wn_country ");
            sSql.Append(" WHERE (id NOT IN");
            sSql.Append("   (SELECT a.Country_ID");
            sSql.Append("   FROM wn_ProductShipToCountry AS a INNER JOIN");
            sSql.Append("       wn_proRules AS b ON b.proid = a.prdGuid AND b.userid = a.userGuid");
            sSql.Append("       WHERE b.id = " + iRuleID.ToString() + "))");
            sSql.Append("ORDER BY selected DESC, sort_order");  
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public DataTable MgeGetProductImageList(string sPrdGuid)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("SELECT fileguid,  fileurl as ImageURL, idx as ImageIdx, ruleid ");
            sSql.Append(" FROM wn_file");
            sSql.Append(" WHERE prdGUid = '" + sPrdGuid + "'");
            sSql.Append(" ORDER BY idx ");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public DataTable MgeGetProductSKUList(string sPrdGuid)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select a.id, a.prosku, c.prodetailType as SpecType, a.prorule as SpecName, a.color, a.WholesalePrice from wn_proRules a");
            sSql.Append(" inner join wn_proDetails b on b.proid = a.proid and b.userid = a.userid");
            sSql.Append(" inner join wn_proDetailSupplyType c on c.id = a.proruletitle");
            sSql.Append(" where a.proid ='" + sPrdGuid + "'");
            sSql.Append("   and b.state=2");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public DataTable MgeGetProductSupplyList(string sPrdGuid)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select a.id, a.prosku, a.color, a.prorule as SpecName, a.proMinimumStock, a.WholesalePrice, a.SupplierShipFee");
            sSql.Append(" ,a.SupplierSku, a.proWeight, a.PackageLength, a.PackageWidth, a.PackageHeight, a.PackageWeight ");
            sSql.Append(" ,b.state as SupplierStatus");
            sSql.Append(" ,c.prodetailType as SpecType");
            sSql.Append(" ,d.username as SupplierName, d.email as SupplierEmail");
            sSql.Append(" ,e.price as SalePrice");

            sSql.Append(" from wn_proRules a");
            sSql.Append(" left join wn_proDetails b on b.proid = a.proid and b.userid = a.userid");
            sSql.Append(" left join wn_proDetailSupplyType c on c.id = a.proruletitle");
            sSql.Append(" left join wn_user d on d.guid = a.userid");
            sSql.Append(" left join wn_prdPrice e on e.prdGuid = a.proid and e.ruleid = a.id and e.p1 <= 1 "); // basic sale price of this rule
            sSql.Append(" where a.proid ='" + sPrdGuid + "'");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }


        public DataTable MgeGetShipFromInfo(int iShipFromID)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select * from wn_ShipFrom") ;
            sSql.Append(" where ShipFrom_ID =" + iShipFromID.ToString());
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        public DataTable MgeGetShipMethod(int iShipFromID)
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append("SELECT b.ShipFrom_ID, a.* ");
            sSql.Append(" FROM   wn_ShipMethod AS a ");
            sSql.Append(" INNER JOIN wn_ShipFrom2ShipMethod AS b ON b.ShipMethod_ID = a.ShipMethod_ID ");
            sSql.Append(" where b.ShipFrom_ID =" + iShipFromID.ToString());
            sSql.Append("  order by a.ProductUploadBatchNo desc, a.ShipMethod_ShipToCountryID asc");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }





        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet MgeGetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取产品价格
        /// </summary>
        /// <param name="prdId"></param>
        /// <returns></returns>
        public DataTable MgeGetPrdPrice(string prdId)
        {
            if (!string.IsNullOrEmpty(prdId))
            {
                string strSql0 = "select count(*) from dbo.wn_prdprice where prdGuid='" + prdId + "'";
                DataSet ds = DbHelperSQL.Query(strSql0);
                if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    Guid guid = new Guid(prdId);
                    MgeAddPrdPrice(guid, 0, 0, 0M);
                }
                string strSql = "select a.prdGuid,name,b.p1,b.p2,b.price from  dbo.wn_prdprice b   left join dbo.wn_prd a on a.prdGuid=b.guid  where b.prdGuid='" + prdId + "' order by p1 asc";

                DataSet ds2 = DbHelperSQL.Query(strSql.ToString());
                if (ds2 != null && ds2.Tables.Count > 0)
                {
                    return ds2.Tables[0];
                }
            }
            return null;

        }
        /// <summary>
        /// 添加价格
        /// </summary>
        /// <param name="prdId"></param>
        /// <returns></returns>
        public bool MgeAddPrdPrice(Guid prdId, int count1, int count2, decimal price)
        {

            StringBuilder strSql = new StringBuilder("");
            strSql.Append("insert into  dbo.wn_prdprice([guid], prdguid,edttime,p1,p2,price) values");
            strSql.Append(" (@guid, @prdguid, @edttime, @p1, @p2, @price) ");

            SqlParameter[] parameters = {
				  new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
                  new SqlParameter("@prdguid", SqlDbType.UniqueIdentifier,16),
                  new SqlParameter("@edttime", SqlDbType.DateTime),
                  new SqlParameter("@p1", SqlDbType.Int),
                  new SqlParameter("@p2", SqlDbType.Int),
                  new SqlParameter("@price", SqlDbType.Decimal),
        };
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = prdId;
            parameters[2].Value = DateTime.Now;
            parameters[3].Value = count1;
            parameters[4].Value = count2;
            parameters[5].Value = price;

            int resu = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (resu > 0)
            {
                return true;
            }

            return false;

        }


        /// <summary>
        /// 删除产品价格
        /// </summary>
        /// <param name="prdId"></param>
        /// <returns></returns>
        public bool MgeDeletPrdPrice(string prdId)
        {
            if (!string.IsNullOrEmpty(prdId))
            {
                string strSql = "delete from dbo.wn_prdprice where prdguid='" + prdId + "'";
                int resu = DbHelperSQL.ExecuteSql(strSql);
                if (resu > 0)
                {
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Get Product SKU Detail
        /// </summary>
        /// <param name="rule ID"></param>
        /// <returns></returns>
        public DataTable MgeGetProductSKUDetail(int iRuleID)
        {
            string sSql = "select * from wn_prorules where id=" +  iRuleID.ToString();
            DataSet ds = DbHelperSQL.Query(sSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// Get Product Spec Type List
        /// </summary>
        /// <param name= none></param>
        /// <returns></returns>
        public DataTable MgeGetProductSpecTypeList()
        {
            string sSql = "select id as SpecTypeID, prodetailType as SpecTypeName from wn_proDetailSupplyType order by 2";
            DataSet ds = DbHelperSQL.Query(sSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        #region 初审区方法
        /// <summary>
        /// 获得评审区产品数据列表[lcs]
        /// </summary>
        public DataTable InitGetListReview(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {

            // format of the cate: [1st-level-cate, 2st-level-cate, 3rd-level-cate]
            if (cate == string.Empty) cate = ",,";
            List<string> cateList = cate.Split(',').ToList();

            string strSqlForCount = "select count(1) 'recordcount' from (";

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],TT.[name], TT.[ranking], [addtime],[txtjj],[estimateprice],[supplyPrice],[saleprice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime] ,f.fileurl,u.username,c.name as cname  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.addtime desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat='" + state + "'");
            }
            else
            {
                strSql.Append(" and (wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.check + "' or wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.checkFail + "') ");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
            //if (!string.IsNullOrEmpty(cate.Trim()))
            //{
            //    strSql.Append(" and cateGuid='" + cate.Trim() + "'");
            //}
            if (!string.IsNullOrEmpty(cateList[2].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + cateList[2] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[1].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + cateList[1] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[0].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + cateList[0] + "')");
            }


            if (!string.IsNullOrEmpty(startTime.Trim()) && !string.IsNullOrEmpty(endTime.Trim()))
            {
                strSql.Append(" and addtime between '" + startTime + "' and '" + endTime + "'");
            }

            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join  [dbo].[wn_prdCate] c on TT.cateGuid= c.guid ");
            //strSql.Append(" left join (select prtguid,COUNT(*) allcount, count(case when (cmdtype='1' or cmdtype='3' or cmdtype='1,3') then 'count0' end) count0, count(case when (cmdtype='2' or cmdtype='4' or cmdtype='2,4')  then 'count01' end) count1 from [dbo].[wn_review] group by prtguid ) r on TT.prdGuid=r.prtguid ");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");

            strSql.Append(" where 1=1 ");

            if (userName.Trim() != "")
            {
                strSql.Append(" and username like '%" + userName + "%'");
            }

            strSqlForCount += strSql.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                totalCount = int.Parse(count_temp);
            else
                totalCount = 0;

            strSql.AppendFormat(" and  TT.Row between {0} and {1} order by TT.edttime desc", startIndex, endIndex);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 批量审核通过进入大众评审区
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int InitPassAll(string ids)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.review + "' where prdGuid in (" + ids + ")";
            int res=DbHelperSQL.ExecuteSql(sql);
            //if (res > 0)
            //{
            //    string proSql = "select prdGuid, name,userGuid,u.email from wn_prd p left join wn_user u on p.userGuid=u.guid where p.prdGuid in (" + ids + ");";
            //    DataTable dt = DbHelperSQL.Query(proSql).Tables[0];
            //    if(dt!=null && dt.Rows.Count>0)
            //    {
            //        var emailList = from item in dt.AsEnumerable()
            //                        select new { 
            //                            proid=item.Field<Guid>("prdGuid"),
            //                            proname=item.Field<string>("name"),
            //                            userid = item.Field<Guid>("userGuid"),
            //                            useremail=item.Field<string>("email")
            //                        };
            //        var useridListDistinct = emailList.Select(s => s.userid).Distinct();
            //        string pro_name=string.Empty;
            //        string user_email=string.Empty;
            //        foreach (var id in useridListDistinct)
            //        {
                        
            //            emailList.Where(s => s.userid.ToString().Trim() == id.ToString().Trim()).Select(s => s.proname)
            //                .ToList().ForEach(s => { pro_name += ",[" + s + "]"; });
            //            if(pro_name.Length>0)
            //                pro_name=pro_name.Substring(1);
            //            user_email=emailList.Where(s=>s.userid.ToString().Trim()==id.ToString().Trim()).Select(s=>s.useremail).FirstOrDefault().ToString();
            //        }
            //        //SendEmailToSuccess(user_email,pro_name);
            //        string emailPath = AppDomain.CurrentDomain.BaseDirectory + "\\EmailTemplate\\checkEmail.html";
            //        string title = "your product has been approved ";
            //        Dictionary<string, string> replaceDic = new Dictionary<string, string>();
            //        replaceDic.Add("#url#", ConfigurationManager.AppSettings["webAppDomain"].Trim());
            //        replaceDic.Add("#useremail#", user_email);
            //        replaceDic.Add("#proname#", pro_name);
            //        Twee.Comm.Mailhelper.SendMailForProductStatus(emailPath, title, user_email, replaceDic);
            //    }
                
           // }
            return res;
        }
        /// <summary>
        /// 审核通过进入大众评审区
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int InitPassSingle(string id,string proname,string userid)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.review + "' where prdGuid=" + id + "";
            int res=DbHelperSQL.ExecuteSql(sql);
            if ( res> 0)
            {
                string userSql = "select username from wn_user where guid='" + userid + "'; "; //这里将之前的EMAIL改为username
                DataSet ds = DbHelperSQL.Query(userSql);
                string email = string.Empty;
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    email = ds.Tables[0].Rows[0][0]._ObjToString();
                }
                //SendEmailToSuccess(email,proname);
                string emailPath = AppDomain.CurrentDomain.BaseDirectory + "\\EmailTemplate\\toTweeBaaEvaluate.htm";
                string title = "your product has been approved ";
                Dictionary<string, string> replaceDic = new Dictionary<string, string>();
                replaceDic.Add("#url#",ConfigurationManager.AppSettings["webAppDomain"].Trim());
                replaceDic.Add("#useremail#",email);
                replaceDic.Add("#proid#", id.Replace("'",string.Empty));
                replaceDic.Add("#proname#",proname);
                Twee.Comm.Mailhelper.SendMailForProductStatus(emailPath,title,email,replaceDic);
            }
            return res;
        }

        /// <summary>
        /// 拒绝通过
        /// </summary>
        /// <param name="proid"></param>
        /// <param name="reason"></param>
        /// <returns></returns>
        public bool RefusePass(string proid, string proname,string userid,string reason)
        {
            try
            {
                string sql = "update wn_prd set stateremark='" + reason + "' ,wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.checkFail + "' where prdGuid='" + proid + "'";
                if (DbHelperSQL.ExecuteSql(sql) == 1)
                {
                    string userSql = "select email from wn_user where guid='" + userid + "'; ";
                    DataSet ds = DbHelperSQL.Query(userSql);
                    string email = string.Empty;
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        email = ds.Tables[0].Rows[0][0]._ObjToString();
                    }
                    if (!string.IsNullOrEmpty(email))
                    {
                        SendEmailToFail(email,proname);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void SendEmailToSuccess(string email,string proname)
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "\\EmailTemplate\\checkEmail.html";
            StreamReader sr = new StreamReader(configPath, Encoding.Default);
            StringBuilder str = new StringBuilder();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                str.Append(line.ToString());
            }
            string webAppDomain = ConfigurationManager.AppSettings["webAppDomain"].Trim();
            string htmlContent = str.ToString().Replace("#useremail#", email).Replace("#url#", webAppDomain).Replace("#proname#",proname);
            string title = "your products has passed !";
            Twee.Comm.Mailhelper.SendMail(title, htmlContent, email);
        }

        public void SendEmailToFail(string email, string proname)
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "\\EmailTemplate\\unCheckEmail.html";
            StreamReader sr = new StreamReader(configPath, Encoding.Default);
            StringBuilder str = new StringBuilder();
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                str.Append(line.ToString());
            }
            string webAppDomain = ConfigurationManager.AppSettings["webAppDomain"].Trim();
            string htmlContent = str.ToString().Replace("#useremail#", email).Replace("#url#", webAppDomain).Replace("#proname#",proname);
            string title = "your product [" + proname + "] hasn't verified !";
            Twee.Comm.Mailhelper.SendMail(title, htmlContent, email);
        }

        #endregion

        #region 大众评审区
        /// <summary>
        /// 获得评审区产品数据列表[lcs]
        /// </summary>
        public DataTable MgeGetListReview(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            // format of the cate: [1st-level-cate, 2st-level-cate, 3rd-level-cate]
            if (cate == string.Empty) cate = ",,";
            List<string> cateList = cate.Split(',').ToList();

            string strSqlForCount = "select count(1) 'recordcount' from (";

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],TT.[name], TT.[ranking], [addtime],[txtjj],[estimateprice],[supplyPrice],[saleprice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime] ,f.fileurl,r.allcount,r.count0, r.count1,u.username,c.name as cname  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat='" + state + "'");
            }
            else
            {
                strSql.Append(" and (wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.review + "' or wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.reviewFail + "') ");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
            //if (!string.IsNullOrEmpty(cate.Trim()))
            //{
            //    strSql.Append(" and cateGuid='" + cate.Trim() + "'");
            //}
            if (!string.IsNullOrEmpty(cateList[2].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + cateList[2] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[1].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + cateList[1] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[0].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + cateList[0] + "')");
            }

            if (!string.IsNullOrEmpty(startTime.Trim()) && !string.IsNullOrEmpty(endTime.Trim()))
            {
                strSql.Append(" and addtime between '" + startTime + "' and '" + endTime + "'");
            }

            if (userName.Trim() != "")
            {
                strSql.Append(" and userGuid in (select guid from wn_user where username like '%" + userName + "%' )"); 
                //strSql.Append(" and username like '%" + userName + "%'");
            }

            
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join  [dbo].[wn_prdCate] c on TT.cateGuid= c.guid ");
            strSql.Append(" left join (select prtguid,COUNT(*) allcount, count(case when (cmdtype2='1') then 'count1' end) count1, count(case when (cmdtype2='0')  then 'count0' end) count0 from [dbo].[wn_review] group by prtguid ) r on TT.prdGuid=r.prtguid ");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");

            strSql.Append(" where 1=1 ");


            strSqlForCount += strSql.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                totalCount = int.Parse(count_temp);
            else
                totalCount = 0;

            strSql.AppendFormat(" and  TT.Row between {0} and {1} order by TT.edttime desc", startIndex, endIndex);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 批量审核通过【lcs】
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int PassAll(string ids)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.tweeReview + "' where prdGuid in (" + ids + ")";
            return DbHelperSQL.ExecuteSql(sql);
        }

        public int PassSingle(string proid,string reasonid,string exreason,string adminid)
        {
            //插入通过理由
            Twee.Model.mgrProStatusLog statusLog = new Model.mgrProStatusLog();
            statusLog.adminid = adminid;
            statusLog.statusfrom = Convert.ToInt32(Twee.Comm.ConfigParamter.PrdSate.review);
            statusLog.statusto = Convert.ToInt32(Twee.Comm.ConfigParamter.PrdSate.tweeReview);
            statusLog.reasonid =Convert.ToInt32(reasonid);
            statusLog.exreason = exreason;
            statusLog.passtime = System.DateTime.Now;
            statusLog.proid = proid.Replace("'", string.Empty);
            if (new Twee.DataMgr.mgrProStatusLogDataMgr().Add(statusLog) > 0)
            {
                //改变产品状态
                string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.tweeReview + "' where prdGuid=" + proid + ";";
                return DbHelperSQL.ExecuteSql(sql);
            }
            else
            {
                return -200;
            }
        }
        #endregion

         /// <summary>
        /// get shopping reward points of a gift 
        /// </summary>
        private bool GetGiftInfo(int iGiftID, out int iShoppingRewardPoint, out string sEmailTemplate)
        {
            iShoppingRewardPoint = 0;
            sEmailTemplate = string.Empty;

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select gift_ShoppingRewardPoint, gift_EmailTemplate ");
            strSql.Append("from wn_gift ");
            strSql.Append("where gift_id=" + iGiftID);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                iShoppingRewardPoint = Int16.Parse(dt.Rows[0]["gift_ShoppingRewardPoint"].ToString());
                sEmailTemplate = dt.Rows[0]["gift_EmailTemplate"].ToString();
            }
            return true;
        }

        /// <summary>
        /// grant gift reward to 150th and 300th evaluators
        /// </summary>
        private bool GrantGiftReward(string prdID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (");
            strSql.Append("select Row_Number() over( order by a.edttime asc) as row, a.userguid,");
            strSql.Append("b.saleprice, b.name, ");
            strSql.Append("c.email, c.username, ");
            strSql.Append("d.MinFinalSalePrice ");
            strSql.Append("from wn_review a ");
            strSql.Append("inner join wn_prd b on a.prtGuid = b.prdGuid ");
            strSql.Append("inner join wn_user c on a.userGuid = c.guid "); 
            strSql.Append(" left join vw_ProductMinFinalSalePrice d on a.prtGuid = d.prdGuid ");
            strSql.Append("where a.prtguid=" + prdID );
            strSql.Append(") as T");
            strSql.Append("  where T.row=150 or T.row=300");
            //strSql.Append("  where T.row=1 or T.row=3"); 
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {

                    string userGuid = row["userguid"].ToString();

                    //jctest
                    //userGuid = "3cfca8d2-3cd8-4e1e-844d-5fffcb9047d9";

                    // not finish yet
                    int iGiftID = (int)(ConfigParamter.Gift.Product);
                    int iGiftSourceID = (int)(ConfigParamter.GiftSource.PassTestSale);
                    int iGiftStatusID = (int)(ConfigParamter.GiftStatus.Pending);
  
                    decimal dFinalSalePrice = Decimal.Parse(row["saleprice"].ToString());
                    if (!DBNull.Value.Equals(row["MinFinalSalePrice"])) { dFinalSalePrice = Decimal.Parse(row["MinFinalSalePrice"].ToString()); }

                    if (dFinalSalePrice <= 50)
                    {
                        // product gift
                        iGiftID = (int)(ConfigParamter.Gift.Product);
                        iGiftStatusID = (int)(ConfigParamter.GiftStatus.Pending);
                    }
                    else
                    {
                        // Shopping Reward Point
                        iGiftID = (int)(ConfigParamter.Gift.MerchandseCredit);
                        iGiftStatusID = (int)(ConfigParamter.GiftStatus.Shipped);
                    }

                    int iGiftShoppingRewardPoint = 0;
                    string sGiftEmailTemplate = string.Empty;
                    GetGiftInfo(iGiftID, out iGiftShoppingRewardPoint, out sGiftEmailTemplate);

                    // product gift reward
                    strSql.Clear();
                    strSql.Append("insert into wn_UserGiftReward(UserGuid, Gift_ID, ProductGuid, UserGiftReward_GrantUserGuid, UserGiftReward_GrantDate, UserGiftReward_Quantity, UserGiftReward_ShoppingRewardPoint, GiftSource_ID, GiftStatus_ID) ");
                    strSql.Append("values(");
                    strSql.Append("'" + row["userGuid"] + "',");
                    strSql.Append(iGiftID + ",");
                    strSql.Append(prdID + ",");
                    strSql.Append("'" + userGuid + "', getdate(), 1,");
                    strSql.Append(iGiftShoppingRewardPoint + ",");
                    strSql.Append(iGiftSourceID + ",");
                    strSql.Append(iGiftStatusID + ")");
                    int iAffectRow = DbHelperSQL.ExecuteSql(strSql.ToString());

                    StringBuilder strSqlSetRewardPoint = new StringBuilder();
                    if (iGiftShoppingRewardPoint > 0)
                    {
                        // add 4000 Shopping Reward Points to the user
                    }

                    // send email to user
                    if (!DBNull.Value.Equals(row["email"]))
                    {
                        string sEmailTo = row["email"].ToString();
                        
                        //jctest 
                        //sEmailTo = "lidecao@gmail.com";
                        
                        string sProductName = row["name"].ToString();
                       
                        string sProductLink = "<a href='https://tweebaa.com/Product/saleBuy.aspx?id=" + prdID.Replace("'", "") + "' >" + sProductName + "</a>";
                        string sTweebaaShopLink = "<a href='https://tweebaa.com/Product/prdSaleAll.aspx'>Click Here</a>";
                        string sUserShipAddressLink = "<a href='#'>Confirm Address</a>";

                        string sEmailBody = sGiftEmailTemplate;
                        sEmailBody = sEmailBody.Replace("@@ProductLink", sProductLink);
                        sEmailBody = sEmailBody.Replace("@@UserShipAddressLink", sUserShipAddressLink);
                        sEmailBody = sEmailBody.Replace("@@TweebaaShopLink", sTweebaaShopLink);
                        sEmailBody = sEmailBody.Replace("$$money", "$" + (iGiftShoppingRewardPoint/80).ToString());
                        sEmailBody = sEmailBody.Replace("$$point", iGiftShoppingRewardPoint.ToString());

                        sEmailBody = "Hi " + row["username"].ToString() + ",<br/><br/>" + sEmailBody + "<br/><br/>Thank you<br/>Tweebaa Inc.";

                        string sEmailSubject = "You’ve just received Tweebaa Reward!";

                        bool bSend = Twee.Comm.Mailhelper.SendMail(sEmailSubject, sEmailBody, sEmailTo);
                        if (!bSend) return false;

                    }
                }
            }            
            return true;
        }

        #region 推易吧评审区

        /// <summary>
        /// 获得评审区产品数据列表[lcs]
        /// </summary>
        public DataTable TweeMgeGetListReview(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {

            // format of the cate: [1st-level-cate, 2st-level-cate, 3rd-level-cate]
            if (cate == string.Empty) cate = ",,";
            List<string> cateList = cate.Split(',').ToList();

            string strSqlForCount = "select count(1) 'recordcount' from (";

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],TT.[name], TT.[ranking], [addtime],[txtjj],[stateremark],[estimateprice],[saleprice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime],[presaleforward],[presaleendtime] ,f.fileurl,r.allcount,r.count0, r.count1,u.username,c.name as cname  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat='" + state + "'"); //默认加载推易吧评审中的产品
            }
            else
            {
                strSql.Append(" and (wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.tweeReview + "' or wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.reviewFalse + "') ");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
            //if (!string.IsNullOrEmpty(cate.Trim()))
            //{
            //    strSql.Append(" and cateGuid='" + cate.Trim() + "'");
            //}
            if (!string.IsNullOrEmpty(cateList[2].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + cateList[2] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[1].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + cateList[1] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[0].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + cateList[0] + "')");
            }

            if (!string.IsNullOrEmpty(startTime.Trim()) && !string.IsNullOrEmpty(endTime.Trim()))
            {
                strSql.Append(" and addtime between '" + startTime + "' and '" + endTime + "'");
            }

            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join  [dbo].[wn_prdCate] c on TT.cateGuid= c.guid ");
            strSql.Append(" left join (select prtguid,COUNT(*) allcount, count(case when (cmdtype2='1') then 'count1' end) count1, count(case when (cmdtype2='0')  then 'count0' end) count0 from [dbo].[wn_review] group by prtguid ) r on TT.prdGuid=r.prtguid ");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");

            strSql.Append(" where 1=1 ");

            if (userName.Trim() != "")
            {
                strSql.Append(" and username='" + userName + "'");
            }

            strSqlForCount += strSql.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                totalCount = int.Parse(count_temp);
            else
                totalCount = 0;

            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 批量审核通过【lcs】
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int TweePassAll(string ids,out List<string> dic)
        {
             List<string> _ids = ids.Split(',').ToList().Select(s=>s.Replace("'",string.Empty)).ToList();
            Dictionary<string, string> list = HaveInventoryProductsIdForAll(ids);
            if (list == null || list.Count == 0)
            {
                dic = null;
                return -200;
            }
            if (_ids.Count == list.Count)
            {
                dic = null;
            }
            else
            {
                List<string> dicIds = list.Select(s => s.Key.Trim()).ToList();
                var chaji = _ids.Except(dicIds);
                List<string> temp = new List<string>();
                foreach (var c in chaji)
                {
                    temp.Add(c);
                }
                dic = temp;
            }

            string sql_ids = string.Empty;
            foreach (var item in list)
            { 
                sql_ids+=",'"+item.Key.Trim()+"'";
            }

            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.preSale + "' where prdGuid in (" + sql_ids.Substring(1) + ")";

            return DbHelperSQL.ExecuteSql(sql);
           
        }

        public int TweePassSingle(string id)
        {
            if (HaveInventoryProductsIdForSingle(id) && HaveTestSaleTarget(id))
            {
                string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.preSale + "' where prdGuid=" + id + "";
                //return DbHelperSQL.ExecuteSql(sql);
                int res = DbHelperSQL.ExecuteSql(sql);
                if (res > 0)
                {
                    string sqlQuery = "select p.prdGuid,p.name,u.username,u.email,u.guid from wn_prd p join wn_user u on p.userGuid=u.guid where p.prdGuid=" + id;
                    DataTable dt = DbHelperSQL.Query(sqlQuery).Tables[0];
                    if (dt == null || dt.Rows.Count == 0)
                        return -300;
                    //http://localhost:28156/Product/preSaleBuy.aspx?id=ac8bca8f-ff28-44d8-ac5e-fdb9eb24d6e9
                    string username = dt.Rows[0]["username"].ToString();
                    string email = dt.Rows[0]["email"].ToString();
                    string proname = dt.Rows[0]["name"].ToString();
                    string proid = dt.Rows[0]["prdGuid"].ToString();

                    string emailPath = AppDomain.CurrentDomain.BaseDirectory + "\\EmailTemplate\\toTestSale.htm";
                    string title = "Congratulations, you have products already through review into the test-sales";
                    Dictionary<string, string> replaceDic = new Dictionary<string, string>();
                    replaceDic.Add("#url#", ConfigurationManager.AppSettings["webAppDomain"].Trim());
                    replaceDic.Add("#username#", username);
                    replaceDic.Add("#proid#", id.Replace("'", string.Empty));
                    replaceDic.Add("#proname#", proname);
                    Twee.Comm.Mailhelper.SendMailForProductStatus(emailPath, title, email, replaceDic);
                }
                return res;
            }
            else
            {
                return -200;
            }
        }

        /// <summary>
        /// 检察是否有供货已采纳，返回已采纳的产品ID[批量]
        /// </summary>
        /// <param name="idString"></param>
        /// <returns></returns>
        public Dictionary<string,string> HaveInventoryProductsIdForAll(string idString)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            string sql = "select d.proid,d.state,p.name from wn_proDetails d ";
            sql += " left join wn_prd p on d.proid=p.prdGuid ";
            sql+=" where d.state='"+((int)Twee.Comm.ConfigParamter.InventoryState.draft).ToString()+"'  and  d.proid in ("+idString+")";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                var res = (from item in dt.AsEnumerable() select new { proid = item.Field<Guid>("proid").ToString(), proname = item.Field<string>("name") });
                foreach (var item in res)
                {
                    list.Add(item.proid,item.proname);
                }
            }
            return list;
        }

        /// <summary>
        /// 检察是否有供货已采纳，返回已采纳的产品ID[单个]
        /// </summary>
        /// <param name="idString"></param>
        /// <returns></returns>
        public bool HaveInventoryProductsIdForSingle(string idString)
        {
            string sql = "select proid,state from wn_proDetails where state='" + ((int)Twee.Comm.ConfigParamter.InventoryState.accepted).ToString() + "'  and proid=" + idString + "";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null)
                return false;
            if (ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
                return false;
            return true;
        }

        /// <summary>
        /// Check if test-sale target price and end date is set
        /// </summary>
        /// <param name="idString"></param>
        /// <returns></returns>
        public bool HaveTestSaleTarget(string idString)
        {
            string sql = "select presaleendtime, presaleforward from wn_prd where prdGuid =" + idString ;
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds == null)
                return false;
            if (ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)             
                return false;
            
            DataRow dr = ds.Tables[0].Rows[0];
            if (dr["presaleendtime"] == DBNull.Value || dr["presaleforward"] == DBNull.Value)
                return false;

            return true;
        }



        public int TweeNoPass(string id, string reason)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.reviewFalse + "',stateremark='" + reason + "'  where prdGuid='" + id + "'";
            return DbHelperSQL.ExecuteSql(sql);
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
            string sql = "update wn_prd set saleprice="+prePrice+", presaleendtime='" + time + "',presaleforward='" + order + "' where prdGuid in (" + ids + ");";
            return DbHelperSQL.ExecuteSql(sql);
        }

        #endregion

        #region 预售区

        public DataTable PreSaleMgeGetListSale(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {

            // format of the cate: [1st-level-cate, 2st-level-cate, 3rd-level-cate]
            if (cate == string.Empty) cate = ",,";
            List<string> cateList = cate.Split(',').ToList();

            string strSqlForCount = "select count(1) 'recordcount' from (";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],[saleprice],TT.[hottip],TT.[name],TT.[ranking],[txtjj],[stateremark],[addtime],[estimateprice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime],[presaleforward],[presaleendtime] ,f.fileurl,s.count,u.username,cc.name as cname FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");

            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat='" + state + "'");
            }
            else
            {
                strSql.Append(" and (wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.preSale + "' or wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.saleFalse + "') ");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
//            if (!string.IsNullOrEmpty(cate.Trim()))
//            {
//                strSql.Append(" and cateGuid='" + cate.Trim() + "'");
//            }
            if (!string.IsNullOrEmpty(cateList[2].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + cateList[2] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[1].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + cateList[1] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[0].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + cateList[0] + "')");
            }
            
            if (!string.IsNullOrEmpty(startTime.Trim()) && !string.IsNullOrEmpty(endTime.Trim()))
            {
                strSql.Append(" and addtime between '" + startTime + "' and '" + endTime + "'");
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join  [dbo].[wn_prdCate] cc on TT.cateGuid= cc.guid ");
            strSql.Append(" left join (select distinct b.prdGuid,c.count from  dbo.wn_orderhead h left join dbo.wn_orderBody b on h.guid=b.headGuid   left join (select  prdGuid,COUNT(*) count from  dbo.wn_orderBody group by prdGuid ) c on b.prdGuid=c.prdGuid) s on TT.prdGuid=s.prdGuid ");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");
            strSql.Append(" where 1=1 ");
            if (userName.Trim() != "")
            {
                strSql.Append(" and username like '%" + userName + "%'");
            }

            strSqlForCount += strSql.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                totalCount = int.Parse(count_temp);
            else
                totalCount = 0;

            strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 批量审核通过【lcs】
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int PreSalePassAll(string ids, string adminid)
        {
            

            // must past one by one
            string[] sIDArr = ids.Split(',');
            int iRet = 0;
            foreach (string id in sIDArr)
            {
                iRet = PreSalePassSingle(id, "pass all", "pass all", adminid);
                if (iRet < 0) break; 
            }

            return iRet;
            //string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.waitSale + "' where prdGuid in (" + ids + ")";
            //return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 设置热点产品
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public int SetHotProduct(string proids)
        {
            string sql = "update wn_prd set hottip='yes' where prdGuid in ("+proids+")";
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 设置热点产品
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public int CancelHotProduct(string proids)
        {
            string sql = "update wn_prd set hottip='no' where prdGuid in (" + proids + ")";
            return DbHelperSQL.ExecuteSql(sql);
        }

        public int PreSalePassSingle(string proid, string reasonid, string exreason, string adminid)
        {
           
            //插入通过理由
            Twee.Model.mgrProStatusLog statusLog = new Model.mgrProStatusLog();
            statusLog.adminid = adminid;
            statusLog.statusfrom = Convert.ToInt32(Twee.Comm.ConfigParamter.PrdSate.preSale);
            statusLog.statusto = Convert.ToInt32(Twee.Comm.ConfigParamter.PrdSate.waitSale);
            statusLog.reasonid =Convert.ToInt32(reasonid);
            statusLog.exreason = exreason;
            statusLog.passtime = System.DateTime.Now;
            statusLog.proid = proid.Replace("'", string.Empty);
            if (new Twee.DataMgr.mgrProStatusLogDataMgr().Add(statusLog) > 0)
            {
                string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.waitSale + "' where prdGuid=" + proid + "";
                int res = DbHelperSQL.ExecuteSql(sql);

                // grant gift reward to selected evaluaters
                if (res > 0)
                {
                    bool bOK = GrantGiftReward(proid);
                }
                return res;
            }
            else
            {
                return -200;
            }
        }

        public int PreSaleNoPass(string id, string reason)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.saleFalse + "',stateremark='" + reason + "'  where prdGuid='" + id + "'";
            return DbHelperSQL.ExecuteSql(sql);
        }

        #endregion

        #region 上架区

        public DataTable UpMgeGetListSale(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            // format of the cate: [1st-level-cate, 2st-level-cate, 3rd-level-cate]
            if (cate == string.Empty) cate = ",,";
            List<string> cateList = cate.Split(',').ToList();

            string strSqlForCount = "select count(1) 'recordcount' from (";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],[saleprice],TT.[name],TT.[ranking],[presaleforward],[txtjj],[stateremark],[addtime],[estimateprice],TT.[wnstat],TT.[idx],[txtTag],[reviewendtime] ,f.fileurl,s.count,u.username,cc.name as cname FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");

            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat='" + state + "'");
            }
            else
            {
                strSql.Append(" and (wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.waitSale + "' or wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.cannotSale + "') ");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
//            if (!string.IsNullOrEmpty(cate.Trim()))
//            {
//                strSql.Append(" and cateGuid='" + cate.Trim() + "'");
//            }

            if (!string.IsNullOrEmpty(cateList[2].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + cateList[2] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[1].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + cateList[1] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[0].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + cateList[0] + "')");
            }

            if (!string.IsNullOrEmpty(startTime.Trim()) && !string.IsNullOrEmpty(endTime.Trim()))
            {
                strSql.Append(" and addtime between '" + startTime + "' and '" + endTime + "'");
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join  [dbo].[wn_prdCate] cc on TT.cateGuid= cc.guid ");
            strSql.Append(" left join (select distinct b.prdGuid,c.count from  dbo.wn_orderhead h left join dbo.wn_orderBody b on h.guid=b.headGuid   left join (select  prdGuid,COUNT(*) count from  dbo.wn_orderBody group by prdGuid ) c on b.prdGuid=c.prdGuid) s on TT.prdGuid=s.prdGuid ");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");
            strSql.Append(" where 1=1 ");
            if (userName.Trim() != "")
            {
                strSql.Append(" and username like '%" + userName + "%'");
            }

            strSqlForCount += strSql.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                totalCount = int.Parse(count_temp);
            else
                totalCount = 0;

            strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 批量审核通过【lcs】
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int UpSalePassAll(string ids)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.sale + "' where prdGuid in (" + ids + ")";
            return DbHelperSQL.ExecuteSql(sql);
        }

        public int UpSalePassSingle(string id)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.sale + "' where prdGuid=" + id + "";
            int res=DbHelperSQL.ExecuteSql(sql);
            if (res>0)
            {
                string sqlQuery = "select p.prdGuid,p.name,u.username,u.email,u.guid from wn_prd p join wn_user u on p.userGuid=u.guid where p.prdGuid="+id;
                DataTable dt = DbHelperSQL.Query(sqlQuery).Tables[0];
                if (dt == null || dt.Rows.Count == 0)
                    return -200;
                //http://localhost:28156/Product/saleBuy.aspx?id=5e724b1b-d6a6-49a0-9681-0e757bfe6905
                string username = dt.Rows[0]["username"].ToString();
                string email = dt.Rows[0]["email"].ToString();
                string proname = dt.Rows[0]["name"].ToString();
                string proid = dt.Rows[0]["prdGuid"].ToString();

                string emailPath = AppDomain.CurrentDomain.BaseDirectory + "\\EmailTemplate\\toFinalSale.htm";
                string title = "Congratulations, you have products already through review into the final sales";
                Dictionary<string, string> replaceDic = new Dictionary<string, string>();
                replaceDic.Add("#url#", ConfigurationManager.AppSettings["webAppDomain"].Trim());
                replaceDic.Add("#username#", username);
                replaceDic.Add("#proid#", id.Replace("'", string.Empty));
                replaceDic.Add("#proname#", proname);
                Twee.Comm.Mailhelper.SendMailForProductStatus(emailPath, title, email, replaceDic);
            }
            return res;
        }

        public int UpSaleNoPass(string id, string reason)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.cannotSale + "',stateremark='" + reason + "'  where prdGuid='" + id + "'";
            return DbHelperSQL.ExecuteSql(sql);
        }


        #endregion

        #region all product sku 
        /// <summary>
        /// get SKU details of product frm backend
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="userName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable SKUMgeGetList(string prdName, string tweebaaSku, string  sShipPartnerID, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            // format of the cate: [1st-level-cate, 2st-level-cate, 3rd-level-cate]
            if (cate == string.Empty) cate = ",,";
            List<string> cateList = cate.Split(',').ToList();

            string strSqlForCount = "select count(1) 'recordcount' from (";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],TT.[name],TT.[ranking],TT.[stateremark],[addtime],TT.[wnstat],pc.name typeName,[reviewendtime] ,f.fileurl,s.sumCount,s.sumMoney,u.username ");
            strSql.Append(",TT.RuleID ,TT.TweebaaSku, TT.WholesalePrice, TT.MinimumQuantity, TT.ShipPartnerID, TT.SpecTypeName, TT.SpecName, TT.Color, TT.Weight,TT.PackageLength, TT.PackageWidth, TT.PackageHeight, TT.PackageWeight");
            strSql.Append(", TT.InventoryInfo_Available, TT.InventoryInfo_StockQuantityInConnecticut, TT.InventoryInfo_StockQuantityInNevada, TT.InventoryInfo_OtherQuantity, TT.InventoryInfo_CommittedQuantity, TT.InventoryInfo_AvailableQuantity, TT.InventoryInfo_LastUpdatedDate");
            strSql.Append(" FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*");
            strSql.Append(",PR.id as RuleID, PR.prosku as TweebaaSKU, PR.color, PR.proweight as Weight,  PR.PackageLength, PR.PackageWidth, PR.PackageHeight, PR.PackageWeight, PR.proMinimumStock as MinimumQuantity, PR.prorule as SpecName, PR.WholesalePrice, PR.ShipPartner_ID as ShipPartnerID, PDST.prodetailType as SpecTypeName ");
            strSql.Append(", INV.InventoryInfo_Available, INV.InventoryInfo_StockQuantityInConnecticut, INV.InventoryInfo_StockQuantityInNevada, INV.InventoryInfo_OtherQuantity, INV.InventoryInfo_CommittedQuantity, INV.InventoryInfo_AvailableQuantity, INV.InventoryInfo_LastUpdatedDate");

            strSql.Append(" from wn_prd T ");
            strSql.Append(" inner join wn_prorules PR on PR.proid = T.prdguid");
            strSql.Append(" inner join wn_proDetails PD on PD.userid = PR.userid AND PD.proid = PR.proid ");
            strSql.Append(" left join wn_proDetailSupplyType PDST on PDST.id = PR.proruletitle ");          // left join for SKU spec type
            strSql.Append(" left join wn_InventoryInfo INV on INV.InventoryInfo_ID = PR.InventoryInfo_ID ");    // left join inventory info   
            strSql.Append(" where PD.state=2 ");    // limited to the select supplier

            if (!string.IsNullOrEmpty(sShipPartnerID.Trim()))
            {
                strSql.Append(" and PR.ShipPartner_ID=" + sShipPartnerID);
            }

            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and T.wnstat='" + state + "'");
            }
            //else
            //{
            //    strSql.Append(" and T.wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.sale + "'");
            //}

            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and T.name like '%" + prdName + "%'");
            }
            //if (!string.IsNullOrEmpty(cate.Trim()))
            //{
            //    strSql.Append(" and cateGuid='" + cate.Trim() + "'");
            //}

            if (!string.IsNullOrEmpty(cateList[2].Trim()))
            {
                strSql.Append(" and T.prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + cateList[2] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[1].Trim()))
            {
                strSql.Append(" and T.prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + cateList[1] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[0].Trim()))
            {
                strSql.Append(" and T.prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + cateList[0] + "')");
            }

            if (!string.IsNullOrEmpty(startTime.Trim()) && !string.IsNullOrEmpty(endTime.Trim()))
            {
                strSql.Append(" and T.addtime between '" + startTime + "' and '" + endTime + "'");
            }

            if (userName.Trim() != "")
            {
                strSql.Append(" and T.userGuid in (select guid from wn_user where wn_user.username like '%" + CommUtil.Quo(userName) + "%')");
            }

            if (tweebaaSku.Trim() != string.Empty)
            {
                strSql.Append(" and T.prdGuid in (select proid from wn_proRules where wn_proRules.prosku like '%" + CommUtil.Quo(tweebaaSku) + "%')");
            }
            //if (!string.IsNullOrEmpty(state.Trim()))
            //{
            //    strSql.Append(" and TT.wnstat='" + state + "'");
            //}

            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join wn_prdCate pc on pc.guid=TT.cateGuid");
            strSql.Append(" left join (select prdGuid, ruleid, SUM(buydanJia*quantity) sumMoney,SUM(quantity) sumCount from  dbo.wn_orderBody where wn_orderBody.ShipOrder_ID is not null  group by prdGuid, ruleid) s on TT.prdGuid=s.prdGuid and TT.ruleid=s.ruleid");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");
            strSql.Append(" where 1=1 ");
            strSqlForCount += strSql.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                totalCount = int.Parse(count_temp);
            else
                totalCount = 0;
            strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        
        /// <summary>
        /// Save SKU details of product from backend
        /// </summary>
        /// <returns></returns>
        public int MgeSaveProductSKUDetail(int iRuleID, string sTweebaaSKU, int iSpecTypeID, string sSpecName, string sWholesalePrice, int iMinimumStock, string sColor, string sWeight, string sPackageLength, string sPackageWidth, string sPackageHeight, string sPackageWeight)
        {
            StringBuilder sSql = new StringBuilder();
            sSql.Append("update wn_prorules set");
            sSql.Append(" prosku='" + CommUtil.Quo(sTweebaaSKU) + "',");
            sSql.Append(" proruletitle=" + iSpecTypeID.ToString() + ",");
            sSql.Append(" prorule='" + CommUtil.Quo(sSpecName) + "',");
            sSql.Append(" WholeSalePrice='" + CommUtil.Quo(sWholesalePrice) + "',");
            sSql.Append(" proMinimumStock=" + iMinimumStock.ToString() + ",");
            sSql.Append(" color='" + CommUtil.Quo(sColor) + "',");
            sSql.Append(" proweight='" + CommUtil.Quo(sWeight) + "',");
            sSql.Append(" PackageLength='" + CommUtil.Quo(sPackageLength) + "',");
            sSql.Append(" PackageWidth='" + CommUtil.Quo(sPackageWidth) + "',");
            sSql.Append(" PackageHeight='" + CommUtil.Quo(sPackageHeight) + "',");
            sSql.Append(" PackageWeight='" + CommUtil.Quo(sPackageWeight) + "'");
            sSql.Append(" where id=" + iRuleID.ToString());
            int iCnt = DbHelperSQL.ExecuteSql(sSql.ToString());

            return iCnt;
        }

        #endregion
        #region 销售区方法

        /// <summary>
        /// 获取销售统计（后台），新版后台
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="userName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable SaleingMgeGetList(string prdName, string tweebaaSku, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            // format of the cate: [1st-level-cate, 2st-level-cate, 3rd-level-cate]
            if (cate == string.Empty) cate = ",,";
            List<string> cateList = cate.Split(',').ToList();

            string strSqlForCount = "select count(1) 'recordcount' from (";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],TT.[name],TT.[ranking],TT.[stateremark],[addtime],TT.[wnstat],pc.name typeName,[reviewendtime] ,f.fileurl,s.sumCount,s.sumMoney,u.username FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat='" + state + "'");
            }
            else
            {
                strSql.Append(" and wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.sale+"'");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
            //if (!string.IsNullOrEmpty(cate.Trim()))
            //{
            //    strSql.Append(" and cateGuid='" + cate.Trim() + "'");
            //}
 
            if (!string.IsNullOrEmpty(cateList[2].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + cateList[2] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[1].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + cateList[1] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[0].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + cateList[0] + "')");
            }

            if (!string.IsNullOrEmpty(startTime.Trim()) && !string.IsNullOrEmpty(endTime.Trim()))
            {
                strSql.Append(" and addtime between '" + startTime + "' and '" + endTime + "'");
            }

            if (userName.Trim() != "")
            {
                strSql.Append(" and userGuid in (select guid from wn_user where wn_user.username like '%" + CommUtil.Quo(userName) + "%')");
            }

            if (tweebaaSku.Trim() != string.Empty)
            {
                strSql.Append(" and prdGuid in (select proid from wn_proRules where wn_proRules.prosku like '%" + CommUtil.Quo(tweebaaSku) + "%')");
            }
            //if (!string.IsNullOrEmpty(state.Trim()))
            //{
            //    strSql.Append(" and TT.wnstat='" + state + "'");
            //}

            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join wn_prdCate pc on pc.guid=TT.cateGuid");
            strSql.Append(" left join (select prdGuid,SUM(buydanJia*quantity) sumMoney,SUM(quantity) sumCount from  dbo.wn_orderBody group by prdGuid) s on TT.prdGuid=s.prdGuid ");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");
            strSql.Append(" where 1=1 ");
            strSqlForCount += strSql.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                totalCount = int.Parse(count_temp);
            else
                totalCount = 0;
            strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        /// <summary>
        /// 批量下架产品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int DownAll(string ids,string reason)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.downSale + "' ,stateremark='"+reason+"' where prdGuid in (" + ids + ")";
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 单个下架产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DownSingle(string id,string reason)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.downSale + "' ,stateremark='" + reason + "'  where prdGuid=" + id + "";
            return DbHelperSQL.ExecuteSql(sql);
        }

        #endregion

        #region 下架区方法

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="userName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable DownMgeGetList(string prdName, string userName, string state, string cate, string startTime, string endTime, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            // format of the cate: [1st-level-cate, 2st-level-cate, 3rd-level-cate]
            if (cate == string.Empty) cate = ",,";
            List<string> cateList = cate.Split(',').ToList();

            string strSqlForCount = "select count(1) 'recordcount' from (";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],[cateGuid],[userGuid],TT.[name],TT.[ranking],TT.[stateremark],[addtime],TT.[wnstat],pc.name typeName,[reviewendtime] ,f.fileurl,s.sumCount,s.sumMoney,u.username FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from wn_prd T where 1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and wnstat='" + state + "'");
            }
            else
            {
                strSql.Append(" and wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.downSale + "'");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and name like '%" + prdName + "%'");
            }
            //if (!string.IsNullOrEmpty(cate.Trim()))
            //{
            //    strSql.Append(" and cateGuid='" + cate.Trim() + "'");
            //}
            if (!string.IsNullOrEmpty(cateList[2].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid3 ='" + cateList[2] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[1].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid2 ='" + cateList[1] + "')");
            }
            else if (!string.IsNullOrEmpty(cateList[0].Trim()))
            {
                strSql.Append(" and prdGuid in (");
                strSql.Append("  select prdGuid from wn_Prd2Cate where cateGuid1 ='" + cateList[0] + "')");
            }

            if (!string.IsNullOrEmpty(startTime.Trim()) && !string.IsNullOrEmpty(endTime.Trim()))
            {
                strSql.Append(" and addtime between '" + startTime + "' and '" + endTime + "'");
            }


            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join wn_prdCate pc on pc.guid=TT.cateGuid");
            strSql.Append(" left join (select prdGuid,SUM(buydanJia*quantity) sumMoney,SUM(quantity) sumCount from  dbo.wn_orderBody group by prdGuid) s on TT.prdGuid=s.prdGuid ");
            strSql.Append(" left join [dbo].[wn_user] u on TT.userGuid=u.guid ");
            strSql.Append(" where 1=1 ");
            if (userName.Trim() != "")
            {
                strSql.Append(" and username like '%" + userName + "%'");
            }
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and TT.wnstat='" + state + "'");
            }
            strSqlForCount += strSql.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                totalCount = int.Parse(count_temp);
            else
                totalCount = 0;
            strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        /// <summary>
        /// 批量上架产品
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int UpAll(string ids, string reason)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.waitSale + "' ,stateremark='" + reason + "' where prdGuid in (" + ids + ")";
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 单个上架产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UpSingle(string id, string reason)
        {
            string sql = "update wn_prd set wnstat='" + (int)Twee.Comm.ConfigParamter.PrdSate.waitSale + "' ,stateremark='" + reason + "'  where prdGuid=" + id + "";
            return DbHelperSQL.ExecuteSql(sql);
        }

        #endregion





        #endregion

    }
}
        