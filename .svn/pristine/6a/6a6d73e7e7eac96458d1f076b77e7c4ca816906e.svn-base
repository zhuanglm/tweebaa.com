using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
    public partial class CollageDesignProductDataMgr
    {
        public CollageDesignProductDataMgr()
        {
        }

        public int CheckCollageDesignValid(string sDesignID)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT  b.wnstat FROM    wn_CollageDesignProduct AS a LEFT OUTER JOIN     wn_prd AS b ON a.prdGuid = b.prdGuid WHERE        (a.CollageDesign_ID = " + sDesignID + ")");

            int iTotal = 0; 
            int iFailed = 0;
            int iStat = 0;
            using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
            {
                while (rdr.Read())
                {
                    iTotal++;
                    iStat = Convert.ToInt32(rdr["wnstat"]);
                    if (iStat == 7){
                        iFailed++;
                    }
                }
            }
            if (iTotal > 0)
            {
                if (iFailed / iTotal >= 0.5)
                {
                    //This Design is failed
                    iStat = 0;
                }
                else
                {
                    iStat = 1;
                }
            }
            else
            {
                iStat = 1;
            }
            return iStat;


        }
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
                if (row["hottip"] != null)
                {
                    model.hottip = row["hottip"].ToString();
                }
                if (row["fileurl"] != null)
                {
                    model.fileurl = row["fileurl"].ToString();
                }
                if (row["saleCount"] != null)
                {
                    model.saleCount = row["saleCount"].ToString().ToInt();
                }
                if (row["FavoriteCount"] != null)
                {
                    model.favoritecount = row["FavoriteCount"].ToString().ToInt();
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
        /// 获取预售区的产品列表
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetPrdSale(string prdName, string cate, string focusCateIDs, string state, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],TT.[userGuid],[cateGuid],[name],[addtime],[txtjj],[estimateprice],[saleprice], y.MinFinalSalePrice, TT.[wnstat],TT.[hottip],TT.[idx],[reviewendtime] ,[presaleendtime],[saleprice],[presaleforward],f.fileurl,s.saleCount, v.FavoriteCount FROM ( ");
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
            if (state == "2" || state == "3")
            {
                strSql.Append(" and wnstat=" + state);//预售中、销售中
            }
            else
            {
                strSql.Append(" and wnstat in(2,6,7,3) ");
            }
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                if (prdName.Contains(","))
                {
                    prdName=prdName.Replace(",", "','");
                    strSql.Append(" and prdGuid in('" + prdName + "')");
                }
                else
                {
                    strSql.Append(" and prdGuid='" + prdName + "'");
                }
            }
            if (!string.IsNullOrEmpty(cate.Trim()))
            {
                strSql.Append(" and cateGuid='" + cate + "'");
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join (select distinct b.prdGuid,c.saleCount from  dbo.wn_orderhead h left join dbo.wn_orderBody b on h.guid=b.headGuid   left join (select  prdGuid,COUNT(*) saleCount from  dbo.wn_orderBody group by prdGuid ) c on b.prdGuid=c.prdGuid) s on TT.prdGuid=s.prdGuid ");
            strSql.Append(" left join vw_ProductMinFinalSalePrice y on TT.prdGuid = y.prdGuid ");
            strSql.Append(" left join vw_ProductFavoriteCount v on TT.prdGuid = v.prdGuid ");
            strSql.Append(" where 1=1 ");

            // search for focus categories
            if (focusCateIDs != null && focusCateIDs != "")
            {
                strSql.Append(" and exists ( select * from wn_prdfocusCate x where x.prdGuid = TT.prdGuid and x.focusCateID in (" + focusCateIDs + "))");
            }

            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            if (!string.IsNullOrEmpty(orderby.Trim()) && !orderby.Contains("saleCount"))
            {
                strSql.Append("order by TT." + orderby);
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

        public DataTable GetDesignPrdShare(string prdName, string cate, string focusCateIDs, string state, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prdguid],TT.[userGuid],[cateGuid],[name],[addtime],[txtjj],[estimateprice],[saleprice],  y.minfinalsaleprice, TT.[wnstat],TT.[idx],[reviewendtime] ,[presaleendtime],[saleprice],f.fileurl,s.shareCount FROM ( ");
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
                // Search for tag or product name  tags are seperated by comma or spaces
                //string sNameLike = CommUtil.GetSqlLike("name", prdName.Trim());
                //string sTagLike = CommUtil.GetSqlLike("txtTag", prdName.Trim());
                if (prdName.Contains(","))
                {
                    prdName.Replace(",", "','");
                    strSql.Append(" and prdGuid in('" + prdName + "'");
                }
                else
                {
                    strSql.Append(" and prdGuid='"+prdName+"'");
                }
                
                //strSql.Append(" and name like '%" + prdName + "%'");
            }
            if (!string.IsNullOrEmpty(cate.Trim()))
            {
                strSql.Append(" and cateGuid='" + cate + "'");
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prdguid= f.prtguid ");
            strSql.Append(" left join (select prtguid,COUNT(prtguid) shareCount from  wn_share  group by prtguid ) s on TT.prdGuid=s.prtguid ");
            strSql.Append(" left join vw_ProductMinFinalSalePrice y on TT.prdGuid=y.prdguid ");

            strSql.Append(" where 1=1 ");

            // search for focus categories
            if (focusCateIDs != null && focusCateIDs != "")
            {
                strSql.Append(" and exists ( select * from wn_prdfocusCate x where x.prdGuid = TT.prdGuid and x.focusCateID in (" + focusCateIDs + "))");
            }

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

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.CollageDesignProduct model)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_CollageDesignProduct(");
            strSql.Append("CollageDesign_ID,prdGuid,iOrder)");
            strSql.Append(" values (");
            strSql.Append("@CollageDesign_ID,@prdGuid,@iOrder)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageDesign_ID", SqlDbType.Int,4),
                    new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@iOrder", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.guid;
            parameters[2].Value = model.iOrder;

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
        public bool Update(Twee.Model.CollageDesignProduct model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_CollageDesignProduct set ");
            strSql.Append("prdGuid=@prdGuid");
            strSql.Append(" where CollageDesign_ID=@CollageDesign_ID and iOrder=@iOrder");
            SqlParameter[] parameters = {
					new SqlParameter("@prdGuid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@CollageDesign_ID", SqlDbType.Int,4),
					new SqlParameter("@iOrder", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.guid;
            parameters[1].Value = model.id;
            parameters[2].Value = model.iOrder;
            

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
        public bool Delete(int CollageDesign_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_CollageDesignProduct ");
            strSql.Append(" where CollageDesign_ID=@CollageDesign_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@CollageDesign_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = CollageDesign_ID;

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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM wn_CollageDesignProduct ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
  /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.CollageDesignProduct DataRowToModel(DataRow row)
        {
            Twee.Model.CollageDesignProduct model = new Twee.Model.CollageDesignProduct();
            if (row != null)
            {
                if (row["CollageDesign_ID"] != null && row["CollageDesign_ID"].ToString() != "")
                {
                    model.id = int.Parse(row["CollageDesign_ID"].ToString());
                }
                if (row["prdGuid"] != null)
                {
                    model.guid = new Guid(row["prdGuid"].ToString());
                }
                if (row["iOrder"] != null)
                {
                    model.iOrder = short.Parse(row["iOrder"].ToString());
                }


            }
            return model;
        }
    }
}
