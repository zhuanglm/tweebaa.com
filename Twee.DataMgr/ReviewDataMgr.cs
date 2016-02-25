using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Twee.Comm;
using System.Data.SqlClient;

namespace Twee.DataMgr
{
    public class ReviewDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_review");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


       /// <summary>
        /// 增加一条数据,输出支持评审数
       /// </summary>
       /// <param name="model"></param>
       /// <param name="suportCount"></param>
       /// <returns></returns>
        public bool Add(Twee.Model.Review model, out int suportCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_review(");
            strSql.Append("guid,cmdtype,cmdtxt,edttime,userguid,prtguid,wnstat,cmdtype2)");
            strSql.Append(" values (");
            strSql.Append("@guid,@cmdtype,@cmdtxt,@edttime,@userguid,@prtguid,@wnstat,@cmdtype2);");
            //strSql.Append("select COUNT (*) from wn_review where userguid=@userguid and (cmdtype='1,3' or cmdtype='1' or cmdtype='3')");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@cmdtype", SqlDbType.NVarChar,10),
					new SqlParameter("@cmdtxt", SqlDbType.NVarChar,4000),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@wnstat", SqlDbType.Int,4),
					new SqlParameter("@cmdtype2", SqlDbType.Int,4)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.cmdtype;
            parameters[2].Value = model.cmdtxt;
            parameters[3].Value = model.edttime;
            parameters[4].Value = model.userguid;
            parameters[5].Value = model.prtguid;
            parameters[6].Value = model.wnstat;
            parameters[7].Value = model.cmdtype2;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //该产品的正支持人数
            suportCount = GetRecordCount("prtguid='" + model.prtguid + "' and (cmdtype2='1')");
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Review model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_review set ");
            strSql.Append("cmdtype=@cmdtype,");
            strSql.Append("cmdtxt=@cmdtxt,");
            strSql.Append("edttime=@edttime,");
            strSql.Append("userguid=@userguid,");
            strSql.Append("prtguid=@prtguid,");
            strSql.Append("wnstat=@wnstat,");
            strSql.Append("cmdtype2=@cmdtype2");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@cmdtype", SqlDbType.NVarChar,10),
					new SqlParameter("@cmdtxt", SqlDbType.NVarChar,4000),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@wnstat", SqlDbType.Int,4),
					new SqlParameter("@cmdtype2", SqlDbType.Int,4),
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = model.cmdtype;
            parameters[1].Value = model.cmdtxt;
            parameters[2].Value = model.edttime;
            parameters[3].Value = model.userguid;
            parameters[4].Value = model.prtguid;
            parameters[5].Value = model.wnstat;
            parameters[6].Value = model.cmdtype2;
            parameters[7].Value = model.guid;

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
        public bool Delete(Guid guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_review ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

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
        public bool DeleteList(string guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_review ");
            strSql.Append(" where guid in (" + guidlist + ")  ");
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
        /// <summary>
        /// Add by Long for load comments for this product mantishub:1285
        /// </summary>
        /// <param name="PrdGuid"></param>
        /// <returns></returns>
        public string GetProductCommentsTotal(string PrdGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) as iCount from wn_review where prtguid='" + PrdGuid + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.Rows[0];
                return dr["iCount"].ToString() + ":0";
            }
            else
                return "0:0";

        }
        public DataTable GetProductCommentsByPage(string PrdGuid, int iFirst, int iLast)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TT.*,convert(varchar(25), TT.edttime, 120) as AddDate, b.username");
            strSql.Append(" from (");
            strSql.Append(" SELECT ROW_NUMBER() OVER (order by edttime desc) as Row, a.* from wn_review a where PrtGuid='" + PrdGuid + "' ) as TT");
            strSql.Append(" left join wn_user b");
            strSql.Append(" on TT.UserGuid=b.guid");
            strSql.Append(" where  TT.Row between " + iFirst.ToString() + " and " + iLast.ToString());

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Review GetModel(Guid guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,cmdtype,cmdtxt,edttime,userguid,prtguid,wnstat,cmdtype2 from wn_review ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

            Twee.Model.Review model = new Twee.Model.Review();
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
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Review DataRowToModel(DataRow row)
        {
            Twee.Model.Review model = new Twee.Model.Review();
            if (row != null)
            {
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.guid = new Guid(row["guid"].ToString());
                }
                if (row["cmdtype"] != null && row["cmdtype"].ToString() != "")
                {
                    model.cmdtype = row["cmdtype"].ToString();
                }
                if (row["cmdtxt"] != null)
                {
                    model.cmdtxt = row["cmdtxt"].ToString();
                }
                if (row["edttime"] != null && row["edttime"].ToString() != "")
                {
                    model.edttime = DateTime.Parse(row["edttime"].ToString());
                }
                if (row["userguid"] != null && row["userguid"].ToString() != "")
                {
                    model.userguid = new Guid(row["userguid"].ToString());
                }
                if (row["prtguid"] != null && row["prtguid"].ToString() != "")
                {
                    model.prtguid = new Guid(row["prtguid"].ToString());
                }
                if (row["wnstat"] != null && row["wnstat"].ToString() != "")
                {
                    model.wnstat = int.Parse(row["wnstat"].ToString());
                }
                if (row["cmdtype2"] != null && row["cmdtype2"].ToString() != "")
                {
                    model.cmdtype2 = int.Parse(row["cmdtype2"].ToString());
                }
                if (row["reviewgrade"] != null && row["reviewgrade"].ToString() != "")
                {
                    model.reviewgrade = int.Parse(row["reviewgrade"].ToString());
                }

            
            }
            return model;
        }

        ///<summary>
        /// 得到会员中心【我的评审】对象实体
        /// </summary>
        public Twee.Model.MyReview DataRowToModel2(DataRow row)
        {
            Twee.Model.MyReview model = new Twee.Model.MyReview();
            if (row != null)
            {
                if (row["prtguid"] != null && row["prtguid"].ToString() != "")
                {
                    model.prtguid = row["prtguid"].ToString().ToGuid();
                }
                if (row["userGuid"] != null && row["userGuid"].ToString() != "")
                {
                    model.userGuid = row["userGuid"].ToString().ToGuid();
                }
                if (row["edttime"] != null && row["edttime"].ToString() != "")
                {
                    model.edttime = DateTime.Parse(row["edttime"].ToString());
                }
                if (row["reviewCount"] != null && row["reviewCount"].ToString() != "")
                {
                    model.reviewCount = int.Parse(row["reviewCount"].ToString());
                }
                if (row["name"] != null && row["name"].ToString() != "")
                {
                    model.name = row["name"].ToString();
                }
                if (row["estimateprice"] != null && row["estimateprice"].ToString() != "")
                {
                    model.estimateprice = row["estimateprice"].ToString().ToDecimal();
                }

                if (row["wnstat"] != null && row["wnstat"].ToString() != "")
                {
                    model.prdstat = row["wnstat"].ToString();
                }
                if (row["reviewendtime"] != null && row["reviewendtime"].ToString() != "")
                {
                    model.reviewendtime = row["reviewendtime"].ToString().ToDateTime();
                }
                if (row["presaleendtime"] != null && row["presaleendtime"].ToString() != "")
                {
                    model.presaleendtime = row["presaleendtime"].ToString().ToDateTime();
                }
                if (row["fileurl"] != null && row["fileurl"].ToString() != "")
                {
                    model.fileurl = row["fileurl"].ToString();
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
            strSql.Append("select guid,cmdtype,cmdtxt,edttime,userguid,prtguid,wnstat,cmdtype2 ");
            strSql.Append(" FROM wn_review ");
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
            strSql.Append(" guid,cmdtype,cmdtxt,edttime,userguid,prtguid,wnstat,cmdtype2 ");
            strSql.Append(" FROM wn_review ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM wn_review ");
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
                strSql.Append("order by T.guid desc");
            }
            strSql.Append(")AS Row, T.*, x.reviewgrade from wn_review T ");
            strSql.Append(" inner join wn_usergrade x on T.userguid = x.userguid");

            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "wn_review";
            parameters[1].Value = "guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        #region Extend

       /// <summary>
        /// 是否已经评审过该产品返回：0已经评价过该产品；1当天已评价10个产品；2可以评价
       /// </summary>
       /// <param name="prdguid"></param>
       /// <param name="userguid"></param>
       /// <returns></returns>
        public int HaveReviewed(Guid prdguid, Guid userguid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from wn_review ");
            strSql.Append(" where prtguid=@prtguid and userguid=@userguid; ");
            strSql.Append(" select COUNT(*) from  wn_review where DATEDIFF(dd,edttime,GETDATE())=0 and userguid =@userguid");
            SqlParameter[] parameters = {
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = prdguid;
            parameters[1].Value = userguid;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
            {
                return 0;//已经评价过该产品
            }
            if (ds != null && ds.Tables.Count > 1)
            {
                if (ds.Tables[1].Rows[0][0].ToString().ToInt()>=10)
                {
                    return 1;
                }
                return 2;
            }
            return 2;
        }

        /// <summary>
        /// Get reviewed YesNo answers to questions
        /// </summary>
        /// <param name="prdguid"></param>
        /// <param name="userguid"></param>
        /// <returns></returns>
        public string GetReviewedYesNo(Guid prdguid, Guid userguid, out string reviewComment)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select cmdtype, cmdtxt from wn_review ");
            strSql.Append(" where prtguid=@prtguid and userguid=@userguid ");
            SqlParameter[] parameters = {
                    new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16)};
            parameters[0].Value = prdguid;
            parameters[1].Value = userguid;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            string sYesNo = string.Empty;
            reviewComment = string.Empty;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                sYesNo = ds.Tables[0].Rows[0]["cmdtype"].ToString();
                reviewComment = ds.Tables[0].Rows[0]["cmdtxt"].ToString();
            }
            return sYesNo;
        }

        /// <summary>
        /// 根据产品id, 评审类型查询该评审类型的所有评审者：1表示支持进入销售的，0表示不支持进入销售的
        /// </summary>
        /// <param name="prdGuid">产品id</param>
        /// <param name="type">1表示支持进入销售的，0表示不支持进入销售的</param>
        /// <returns></returns>
        public DataTable GetReviewUserByType(Guid prdguid, int type)
        {
            string strSql = "";
            if (type==1)
            {
                strSql = "select  userguid from wn_review where (cmdtype2='1') and prtguid='"+prdguid+"' ";        
            }
            else if (type==0)
            {
                strSql = "select  userguid from wn_review where (cmdtype2='0') and prtguid='" + prdguid + "' "; 
            }
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds!=null&&ds.Tables.Count>0)
            {
                return ds.Tables[0];
            }
            return null;          
        
        }

        #region 会员中心
        /// <summary>
        /// 获取会员中心我的评审
        /// </summary>
        /// <param name="prdName"></param>
        /// <param name="state"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetMyReview(string userID, string prdName, string cate, string state, string orderby, int startIndex, int endIndex,string begTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.[prtguid],TT.[userGuid],TT.[edttime],reviewCount,cmdtxt,p.name,p.estimateprice,p.wnstat,p.reviewendtime ,p.presaleendtime, p.txtjj, f.fileurl, x.MinFinalSalePrice  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            strSql.Append("order by T.edttime desc" );
            strSql.Append(")AS Row, T.prtguid,T.userGuid,T.edttime,T.cmdtype,T.cmdtxt from wn_review T where 1=1 ");           
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and userGuid = '" + userID + "'");
            }
            if (!string.IsNullOrEmpty(begTime.Trim()))
            {
                //strSql.Append(" and edttime>='" + begTime + "'");
                string sBegDate = CommUtil.ToDBDateFormat(begTime);
                strSql.Append(" and edttime>='" + sBegDate + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                //strSql.Append(" and edttime<='" + endTime + "'");
                string sEndDate = CommUtil.ToDBDateFormat(endTime);
                strSql.Append(" and edttime<='" + sEndDate + " 23:59'");
            }           
            strSql.Append(" ) TT");
            strSql.Append(" left join  (select prtguid,fileurl from  [dbo].[wn_file] where idx=0 ) f on TT.prtguid= f.prtguid ");
            strSql.Append(" left join (select prdguid,name ,estimateprice,reviewendtime,presaleendtime,wnstat, txtjj from [dbo].[wn_prd]) p on TT.prtGuid=p.prdguid ");
            strSql.Append(" left join (select  prtguid,COUNT(*) reviewCount from wn_review  group by prtguid) c on TT.prtguid=c.prtguid");
            strSql.Append(" left join vw_ProductMinFinalSalePrice x on x.prdGuid = TT.prtGuid ");
            strSql.Append(" where 1=1 ");
            if (!string.IsNullOrEmpty(prdName.Trim()))
            {
                strSql.Append(" and p.name like '%" + prdName + "%'");
            }
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and p.wnstat=" + state);
            }
            else
            {
                strSql.Append(" and wnstat!=0 ");
            }
            strSql.AppendFormat(" and  TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;

        }

       /// <summary>
        /// 获取会员中心我的评审总数
       /// </summary>
       /// <param name="userID"></param>
       /// <param name="prdName"></param>
       /// <param name="cate"></param>
       /// <param name="state"></param>
       /// <param name="begTime"></param>
       /// <param name="endTime"></param>
       /// <returns></returns>
        public int GetMyReviewCount(string userID, string prdName, string cate, string state, string begTime, string endTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from wn_review r left join wn_prd p on r.prtguid=p.prdGuid where 1=1 ");
            if (!string.IsNullOrEmpty(state.Trim()))
            {
                strSql.Append(" and p.wnstat='" + state + "'");
            }
            if (!string.IsNullOrEmpty(userID.Trim()))
            {
                strSql.Append(" and r.userGuid = '" + userID + "'");
            }          
            if (!string.IsNullOrEmpty(begTime.Trim()))
            {
                string sBegTime = CommUtil.ToDBDateFormat(begTime);
                strSql.Append(" and r.edttime>='" + sBegTime + " 0:00'");
            }
            if (!string.IsNullOrEmpty(endTime.Trim()))
            {
                string sEndTime = CommUtil.ToDBDateFormat(endTime);
                strSql.Append(" and r.edttime<='" + endTime + " 23:59'");
            }           
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows[0][0].ToString().ToInt();
            }
            return 0;
        }


        /// <summary>
        /// 获取会员中心我的evaluate grand total of "Successful Rate" and "Earn Gifts"
        /// Total number of evaulated products with answer "Yes"
        /// Total number of promoted products (from test-sale, buy-now and etc) evaulated products with answer "Yes"
        /// total number of Evaluation gifts rewards
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataSet GetMyEvaluateGrandTotal(string userGuid)
        {
            StringBuilder sSql = new StringBuilder();
            // Total number of evaulated products with answer "Yes"
            sSql.Append( "select  count(distinct prtguid) from wn_review where (cmdtype2='1') and userguid='" + userGuid + "'; ");

            // Total number of promoted products (from test-sale, buy-now and etc) evaulated products with answer "Yes"
            sSql.Append("select  count(distinct a.prtguid) from wn_review a ");
            sSql.Append(" inner join wn_prd b on b.prdGuid= a.prtguid ") ;
            sSql.Append(" where a.cmdtype2='1' ");      // anwser to Yes
            sSql.Append("   and a.userguid='" + userGuid + "'");
            sSql.Append("   and b.wnstat in (") ;
            sSql.Append(((int)Comm.ConfigParamter.PrdSate.preSale).ToString() + ",");
            sSql.Append(((int)Comm.ConfigParamter.PrdSate.sale).ToString() + ",");
            sSql.Append(((int)Comm.ConfigParamter.PrdSate.saleFalse).ToString() + ",");
            sSql.Append(((int)Comm.ConfigParamter.PrdSate.waitSale).ToString() + ",");
            sSql.Append(((int)Comm.ConfigParamter.PrdSate.downSale).ToString() + ");");

            /// total number of Evaluation gifts rewards
            sSql.Append("select count(*) from wn_USerGiftReward ");
            sSql.Append(" where UserGuid ='" + userGuid + "'");

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            return ds;
        }


        #endregion
        #endregion

        #region 后台方法

        /// <summary>
        /// 查询评审记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="orderby"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable MgeGetAllReview(string strWhere1, string strWhere2, string orderby, int startIndex, int endIndex)
        {
            //select prtguid,u.username, cmdtype,cmdtxt,r.wnstat,r.edttime
            //    from dbo.wn_review r left join dbo.wn_user  u on r.userguid=u.guid

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT prtguid,u.username, cmdtype,cmdtxt,TT.wnstat,TT.edttime ,p.name  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.prdGuid desc");
            }
            strSql.Append(")AS Row, T.*  from dbo.wn_review T ");
            if (!string.IsNullOrEmpty(strWhere1.Trim()))
            {
                strSql.Append(" WHERE " + strWhere1);
            }
            strSql.Append(" ) TT left join dbo.wn_user  u on TT.userguid=u.guid  left join dbo.wn_prd p on TT.prtguid=p.prdGuid ");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            if (!string.IsNullOrEmpty(strWhere2.Trim()))
            {
                strSql.Append(" and " + strWhere2);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;


        }

        public int MgeGetAllReviewCount(string strWhere1, string strWhere2)
        {
            //select prtguid,u.username, cmdtype,cmdtxt,r.wnstat,r.edttime
            //    from dbo.wn_review r left join dbo.wn_user  u on r.userguid=u.guid


            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*)  FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");

            strSql.Append("order by T.prtguid desc");

            strSql.Append(")AS Row, T.*  from dbo.wn_review T ");
            if (!string.IsNullOrEmpty(strWhere1.Trim()))
            {
                strSql.Append(" WHERE " + strWhere1);
            }
            strSql.Append(" ) TT left join dbo.wn_user  u on TT.userguid=u.guid  left join dbo.wn_prd p on TT.prtguid=p.prdGuid ");
            strSql.Append(" WHERE 1=1 ");
            if (!string.IsNullOrEmpty(strWhere2.Trim()))
            {
                strSql.Append(" and " + strWhere2);
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
        /// 根据产品ID查询该产品的评审总数
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        public int GetReviewCountByProid(string proid)
        {
            string sql = "select count(1) from wn_review where prtGuid='"+proid+"';";
            return Convert.ToInt32(DbHelperSQL.GetSingle(sql.ToString()));
        }

        #endregion
    }
}
