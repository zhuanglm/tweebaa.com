using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Twee.Comm;


namespace Twee.DataMgr
{
    public class UserGradeCalDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_usergrade");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = guid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.Usergrade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_usergrade(");
            strSql.Append("guid,userguid,publishgrade,reviewgrade,sharegrade,publishintegral,reviewintegral,shareintegral,publishcount,reviewhcount,sharecount,updatetime)");
            strSql.Append(" values (");
            strSql.Append("@guid,@userguid,@publishgrade,@reviewgrade,@sharegrade,@publishintegral,@reviewintegral,@shareintegral,@publishcount,@reviewhcount,@sharecount,@updatetime)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@publishgrade", SqlDbType.Int,4),
					new SqlParameter("@reviewgrade", SqlDbType.Int,4),
					new SqlParameter("@sharegrade", SqlDbType.Int,4),
					new SqlParameter("@publishintegral", SqlDbType.Int,4),
					new SqlParameter("@reviewintegral", SqlDbType.Int,4),
					new SqlParameter("@shareintegral", SqlDbType.Int,4),
					new SqlParameter("@publishcount", SqlDbType.Int,4),
					new SqlParameter("@reviewhcount", SqlDbType.Int,4),
					new SqlParameter("@sharecount", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.userguid;
            parameters[2].Value = model.publishgrade;
            parameters[3].Value = model.reviewgrade;
            parameters[4].Value = model.sharegrade;
            parameters[5].Value = model.publishintegral;
            parameters[6].Value = model.reviewintegral;
            parameters[7].Value = model.shareintegral;
            parameters[8].Value = model.publishcount;
            parameters[9].Value = model.reviewhcount;
            parameters[10].Value = model.sharecount;
            parameters[11].Value = model.updatetime;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Twee.Model.Usergrade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_usergrade set ");           
            strSql.Append("publishgrade=@publishgrade,");
            strSql.Append("reviewgrade=@reviewgrade,");
            strSql.Append("sharegrade=@sharegrade,");
            strSql.Append("publishintegral=@publishintegral,");
            strSql.Append("reviewintegral=@reviewintegral,");
            strSql.Append("shareintegral=@shareintegral,");
            strSql.Append("publishcount=@publishcount,");
            strSql.Append("reviewhcount=@reviewhcount,");
            strSql.Append("sharecount=@sharecount,");
            strSql.Append("updatetime=@updatetime");
            strSql.Append(" where userguid=@userguid ");
            SqlParameter[] parameters = {
					new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@publishgrade", SqlDbType.Int,4),
					new SqlParameter("@reviewgrade", SqlDbType.Int,4),
					new SqlParameter("@sharegrade", SqlDbType.Int,4),
					new SqlParameter("@publishintegral", SqlDbType.Int,4),
					new SqlParameter("@reviewintegral", SqlDbType.Int,4),
					new SqlParameter("@shareintegral", SqlDbType.Int,4),
					new SqlParameter("@publishcount", SqlDbType.Int,4),
					new SqlParameter("@reviewhcount", SqlDbType.Int,4),
					new SqlParameter("@sharecount", SqlDbType.Int,4),
					new SqlParameter("@updatetime", SqlDbType.DateTime)
					};
            parameters[0].Value = model.userguid;
            parameters[1].Value = model.publishgrade;
            parameters[2].Value = model.reviewgrade;
            parameters[3].Value = model.sharegrade;
            parameters[4].Value = model.publishintegral;
            parameters[5].Value = model.reviewintegral;
            parameters[6].Value = model.shareintegral;
            parameters[7].Value = model.publishcount;
            parameters[8].Value = model.reviewhcount;
            parameters[9].Value = model.sharecount;
            parameters[10].Value = model.updatetime;          

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
            strSql.Append("delete from wn_usergrade ");
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
            strSql.Append("delete from wn_usergrade ");
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

        //Add by Long for Slot Machine
        public void SlotMachineSaveLuckyWinner(string userGuid, int iPrizeID)
        {

            using (SqlConnection conn = new SqlConnection(DbHelperSQL.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("[spSlotMachineSaveLuckyWinner]", conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] parameters = new SqlParameter[] { 
                            new SqlParameter("@userGuid",SqlDbType.UniqueIdentifier),
                            new SqlParameter("@prizeID",SqlDbType.Int), 
                            };

                        parameters[0].Value = userGuid.ToGuid();
                        parameters[1].Value = iPrizeID;

                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        CommHelper.WrtLog(ex.Message);
                        //intRes = "-97";//代码级错误
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        //Add by Long for Slot Machine
        public int SlotMachineUpdateCredit(string userGuid, int iUsedCredit)
        {

            StringBuilder strSql = new StringBuilder();

            //更新用户积分表
           // int iPoints = iCurrentCredit -iUsedCredit;
            strSql.Append("update dbo.wn_usergrade set  shareintegral=shareintegral- "+ iUsedCredit.ToString()+",sharegrade=( select top 1 grade from ");
            strSql.Append(" dbo.wn_sharegradeparam where shareintegral -"+iUsedCredit.ToString()+" >=integral order by grade desc ) where userguid='"+userGuid+"'");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            //type 3：分享积分
            strSql.Clear();
            strSql.Append("insert into wn_point(type,userId,point,remark,addTime,state) values(3,'");
            strSql.Append(userGuid + "','-" + iUsedCredit.ToString() + "','Slot Machine',getdate(),1)");
            DbHelperSQL.ExecuteSql(strSql.ToString());
            strSql.Clear();
            strSql.Append("select shareintegral from wn_usergrade where userguid='" + userGuid + "'");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return obj.ToString().ToInt();
            }
            else
            {
                return 0;
            }

        }

        //Add by Long for Share Point Redeem
        public DataTable GetHomeRedeemHistoryDetial(Guid userGuid, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.*,b.guidno from wn_SharePointRedeemHistory a left join wn_orderhead b on a.OrderHeadGuid=b.guid ");
            strSql.Append(string.Format(" where a.UserGuid='{0}'", userGuid));
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" " + strWhere);
            }
            strSql.Append(" order by RedeemDate desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public int GetHomeRedeemRecordCount(Guid userGuid,  string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT OrderHeadGuid,RedeemDate FROM dbo.wn_SharePointRedeemHistory  T where 1=1");


            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" " + strWhere);
            }
            strSql.AppendFormat(" and T.UserGuid='{0}'", userGuid.ToString().ToUpper());
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0].Rows.Count;
            }
            return 0;

        }
        public string GetUserTotalSharePointRedeem(Guid userguid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(PointsRedeem) as TotalRedeem from wn_SharePointRedeemHistory where UserGuid='" + userguid.ToString() + "'");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["TotalRedeem"].ToString();
            }
            else
            {
                return "0";
            }

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.Usergrade GetModel(Guid userguid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,userguid,publishgrade,reviewgrade,sharegrade,publishintegral,reviewintegral,shareintegral,publishcount,reviewhcount,sharecount,updatetime,tweebuck,shopingPoint from wn_usergrade ");
            strSql.Append(" where userguid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = userguid;

            Twee.Model.Usergrade model = new Twee.Model.Usergrade();
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
        public Twee.Model.Usergrade DataRowToModel(DataRow row)
        {
            Twee.Model.Usergrade model = new Twee.Model.Usergrade();
            if (row != null)
            {
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.guid = new Guid(row["guid"].ToString());
                }
                if (row["userguid"] != null && row["userguid"].ToString() != "")
                {
                    model.userguid = new Guid(row["userguid"].ToString());
                }
                if (row["publishgrade"] != null && row["publishgrade"].ToString() != "")
                {
                    model.publishgrade = int.Parse(row["publishgrade"].ToString());
                }
                if (row["reviewgrade"] != null && row["reviewgrade"].ToString() != "")
                {
                    model.reviewgrade = int.Parse(row["reviewgrade"].ToString());
                }
                if (row["sharegrade"] != null && row["sharegrade"].ToString() != "")
                {
                    model.sharegrade = int.Parse(row["sharegrade"].ToString());
                }
                if (row["publishintegral"] != null && row["publishintegral"].ToString() != "")
                {
                    model.publishintegral = int.Parse(row["publishintegral"].ToString());
                }
                if (row["reviewintegral"] != null && row["reviewintegral"].ToString() != "")
                {
                    model.reviewintegral = int.Parse(row["reviewintegral"].ToString());
                }
                if (row["shareintegral"] != null && row["shareintegral"].ToString() != "")
                {
                    model.shareintegral = int.Parse(row["shareintegral"].ToString());
                }
                if (row["publishcount"] != null && row["publishcount"].ToString() != "")
                {
                    model.publishcount = int.Parse(row["publishcount"].ToString());
                }
                if (row["reviewhcount"] != null && row["reviewhcount"].ToString() != "")
                {
                    model.reviewhcount = int.Parse(row["reviewhcount"].ToString());
                }
                if (row["sharecount"] != null && row["sharecount"].ToString() != "")
                {
                    model.sharecount = int.Parse(row["sharecount"].ToString());
                }
                if (row["updatetime"] != null && row["updatetime"].ToString() != "")
                {
                    //model.updatetime = DateTime.Parse(row["updatetime"].ToString());
                }
                if (row["tweebuck"] != null)
                {
                    model.tweebuck = row["tweebuck"].ToString().ToDecimal();
                }
                if (row["shopingPoint"] != null)
                {
                    model.shopingPoint = row["shopingPoint"].ToString().ToDecimal();
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
            strSql.Append("select guid,userguid,publishgrade,reviewgrade,sharegrade,publishintegral,reviewintegral,shareintegral,publishcount,reviewhcount,sharecount,updatetime ");
            strSql.Append(" FROM wn_usergrade ");
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
            strSql.Append(" guid,userguid,publishgrade,reviewgrade,sharegrade,publishintegral,reviewintegral,shareintegral,publishcount,reviewhcount,sharecount,updatetime ");
            strSql.Append(" FROM wn_usergrade ");
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
            strSql.Append("select count(1) FROM wn_usergrade ");
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
            strSql.Append(")AS Row, T.*  from wn_usergrade T ");
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
            parameters[0].Value = "wn_usergrade";
            parameters[1].Value = "guid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod

        /// <summary>
        /// 为推荐注册人增加分享积分(废弃)
        /// </summary>
        /// <param name="regiserGuid">新注册会员guid</param>
        /// <param name="addIntegral">奖励积分</param>
        /// <returns></returns>
        public bool UpdateShareIntegral(string regiserGuid,int addIntegral,out string tuijianID)
        {            
            tuijianID = "";
            string strSql = string.Format("update wn_usergrade set publishintegral=publishintegral+{0},reviewintegral=reviewintegral+{0},shareintegral=shareintegral+{0} where userguid=(select guid from wn_user where email=(select tuijieEmail from wn_user where guid='{1}'))", addIntegral, regiserGuid);
         
           // string strSql2 =string.Format("insert into wn_point([type],userid,remark,addtime,[state]) values ('{0}','{1}','{2}','{3}','{4}')","分享收益",)
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows>0)
            {
               DataSet ds = DbHelperSQL.Query(string.Format("select guid from wn_user where email=(select tuijieEmail from wn_user where guid='{0}')", regiserGuid));
               if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
               {
                   tuijianID = ds.Tables[0].Rows[0][0].ToString();
               }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 为推荐注册人增加积分三个区
        /// </summary>
        /// <param name="regiserGuid">注册用户id</param>
        /// <returns></returns>
        public bool UpdateShareIntegral(string regiserGuid)
        {
            try
            {
                string strsql = "User_TuijianIntegralCal";
                SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@regiserGuid",SqlDbType.UniqueIdentifier)              
            };
                paras[0].Value = regiserGuid.ToGuid().Value;
                paras[0].Direction = ParameterDirection.Input;              
                int count = DbHelperSQL.RunProcedure_NonQuery(strsql, paras);
                if (count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }
        #region 会员中心

        /// <summary>
        /// 根据会员id,查询会员的等级、积分、佣金比例
        /// </summary>
        /// <param name="userGuid">会员id为空时，返回所有人的</param>
        /// <returns></returns>
        public DataTable GetUserGrade(Guid? userGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select u.[userguid],u.[publishgrade],u.[publishintegral],u.[publishcount],u.[reviewgrade],u.[reviewintegral],u.[reviewhcount],u.[sharegrade] ,u.[shareintegral],u.[sharecount],u.[updatetime], u.shopingpoint, u.tweebuck, p.commissionratio pratio,r.commissionratio1 rratio1,r.commissionratio2 rratio2 ,r.commissionratio3 rratio3,s.commissionratio sratio");
            strSql.Append(" from dbo.wn_usergrade u ");
            strSql.Append(" left join dbo.wn_publishgradeparam p on u.publishgrade=p.grade");
            strSql.Append(" left join dbo.wn_reviewgradeparam r on u.reviewgrade=r.grade ");
            strSql.Append(" left join dbo.wn_sharegradeparam s on u.sharegrade=s.grade  ");
            if (userGuid!=null)
            {
                strSql.Append(string.Format(" where u.userguid='{0}'", userGuid.ToString()));
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        /// <summary>
        /// 根据会员id,查询会员的share等级、佣金比例
        /// </summary>
        /// <param name="userGuid">if userGUid is null return commission of share level 1</param>
        /// <returns></returns>
        public DataTable GetUserShareGrade(Guid? userGuid)
        {
            StringBuilder strSql = new StringBuilder();
            if (userGuid != null)
            {
                strSql.Append(" select u.[sharegrade], s.commissionratio sratio");
                strSql.Append(" from dbo.wn_usergrade u ");
                strSql.Append(" left join dbo.wn_sharegradeparam s on u.sharegrade=s.grade  ");
                if (userGuid != null)
                {
                    strSql.Append(string.Format(" where u.userguid='{0}'", userGuid.ToString()));
                }
            }
            else
            {
                strSql.Append(" select 1 as sharegrade,  s.commissionratio sratio");
                strSql.Append(" from dbo.wn_sharegradeparam s where s.grade = 1  ");
            }
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }      

        
        #endregion

        #region 后台方法
        /// <summary>
        /// 发布者者积分计算，在评审按钮下调用(第一版，已弃用)
        /// </summary>
        /// <param name="pubUserID">发布者ID</param>
        /// <param name="supportCount">评审正支持人数</param>
        /// <returns></returns>      
        public bool MgePublishIntegralCal(Guid pubUserID, int supportCount,Guid prdId)
        {
            try
            {
                string strsql = "User_PublishIntegralCal";
                SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@pubUserId",SqlDbType.UniqueIdentifier),
                new SqlParameter("@supportCount",SqlDbType.Int),
                new SqlParameter("@prdId",SqlDbType.UniqueIdentifier)
            };
                paras[0].Value = pubUserID;
                paras[0].Direction = ParameterDirection.Input;
                paras[1].Value = supportCount;
                paras[1].Direction = ParameterDirection.Input;
                paras[2].Value = prdId;
                paras[2].Direction = ParameterDirection.Input;
                int count = DbHelperSQL.RunProcedure_NonQuery(strsql, paras);
                if (count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                
            }
            return false;

        }

        /// <summary>
        /// 发布者者积分计算，在评审按钮下调用
        /// </summary>
        /// <param name="pubUserID">发布者ID</param>
        /// <param name="supportCount">评审正支持人数</param>
        /// <returns></returns>      
        public bool MgePublishIntegralCal(Guid pubUserID, Guid prdId,int prdState)
        {
            try
            {
                string strsql = "User_PublishIntegralCal";
                SqlParameter[] paras = new SqlParameter[] { 
                new SqlParameter("@pubUserId",SqlDbType.UniqueIdentifier),               
                new SqlParameter("@prdId",SqlDbType.UniqueIdentifier),
                new SqlParameter("@prdState",SqlDbType.Int)
            };
                paras[0].Value = pubUserID;
                paras[0].Direction = ParameterDirection.Input;             
                paras[1].Value = prdId;
                paras[1].Direction = ParameterDirection.Input;
                paras[2].Value = prdState;
                paras[2].Direction = ParameterDirection.Input;
                int count = DbHelperSQL.RunProcedure_NonQuery(strsql, paras);
                if (count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            return false;

        }

        /// <summary>
        /// 分享者积分计算，在分享链接被访问的时候调用（已经将该方法合并在 ShareDataMgr类中的 UpdateVisitCount 下）
        /// </summary>
        /// <param name="shareUserID">链接的分享者ID</param>
        /// <param name="visitCount">链接的访问数</param>
        /// <returns></returns>      
        public bool MgeShareIntegralCal(Guid shareUserID, int visitCount)
        {
            try
            {
                string strsql = "User_ShareIntegralCal";
                SqlParameter[] paras = new SqlParameter[] { 
             new SqlParameter("@shareUserID",SqlDbType.UniqueIdentifier),
              new SqlParameter("@visitCount",SqlDbType.Int),
            };
                paras[0].Value = shareUserID;
                paras[0].Direction = ParameterDirection.Input;
                paras[1].Value = visitCount;
                paras[1].Direction = ParameterDirection.Input;
                int count = DbHelperSQL.RunProcedure_NonQuery(strsql, paras);
                if (count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
               
            }
            return false;

        }
        /// <summary>
        /// 评审区积分计算，在产品状态更改的时候触发
        /// </summary>
        /// <param name="proId">被评审的产品ID</param>
        /// <param name="reviewResult">评审结果：0：未进入销售区；1：进入销售区</param>
        /// <returns></returns>
        public bool MgeReviewIntegralCal(Guid proId, int reviewResult)
        {
            try
            {
                string strsql = "User_ReviewIntegralCal";
                SqlParameter[] paras = new SqlParameter[] { 
             new SqlParameter("@proId",SqlDbType.UniqueIdentifier),
              new SqlParameter("@reviewResult",SqlDbType.Int),
            };
                paras[0].Value = proId;
                paras[0].Direction = ParameterDirection.Input;
                paras[1].Value = reviewResult;
                paras[1].Direction = ParameterDirection.Input;
                int count = DbHelperSQL.RunProcedure_NonQuery(strsql, paras);
                if (count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                
            }
            return false;


            //评审积分 = 活跃度 * 10 * 成功率 + 成功数 * 10
            //= 活跃度 *10 *（1- 失败率） + 成功数 * 10
            //活跃度：代表平均每天评审的项目个数；活跃度*10代表活跃度积分；
            //说明：得分来源 =   活跃度积分 + 成功评审积分，而活跃度积分是建立在成功率的基础上，相对上一版公式：活跃度积分=活跃度*10，扣掉了失           败的活跃度积分，保留了 成功的活跃度积分。
            //计算公式：
            //d : 成为会员总天数
            //a : 评审总次数
            //s : 评审成功次数
            //f : 评审失败次数
            //p : 最终积分
            //p= a/d * 10 * (s/a)+s*10 = s/d *10 + s*10

        }

        #endregion

        /// <summary>
        /// 修改购物者积分
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        public bool UpdateShopingPoint(string orderNo)
        {
            try
            {
                if (!string.IsNullOrEmpty(orderNo))
                {
                    SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@orderNo",SqlDbType.NVarChar,50)                    
                    };
                    paras[0].Value = orderNo;
                    int count = DbHelperSQL.RunProcedure_NonQuery("Shop_UpdateShopingPointAndTweebuck", paras);
                    if (count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SharePointRedeem(string orderNo)
        {

            try
            {
                if (!string.IsNullOrEmpty(orderNo))
                {
                    SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@orderNo",SqlDbType.NVarChar,50)                    
                    };
                    paras[0].Value = orderNo;
                    int count = DbHelperSQL.RunProcedure_NonQuery("spShopUseSharePointRedeem", paras);
                    if (count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 签到获得积分:每签到一次三个区各的1积分，连续签到7天，3个区各得10积分
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <returns></returns>
        public bool UserQianDaoIntegralCal(Guid userGuid,int point)
        {
            try
            {                
                SqlParameter[] paras = new SqlParameter[] { 
                     new SqlParameter("@userId",SqlDbType.UniqueIdentifier),
                     new SqlParameter("@point",SqlDbType.Int)        
                };
                paras[0].Value = userGuid;
                paras[1].Value = point;
                int count = DbHelperSQL.RunProcedure_NonQuery("User_QianDaoIntegralCal", paras);
                if (count > 0)
                {
                    return true;
                }               
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 查询已使用积分
        /// </summary>
        /// <param name="userID">用户id</param>
        /// <returns></returns>
        public DataTable GetUseShoppingPoint(string userID)
        {
            try
            {
                if (!string.IsNullOrEmpty(userID))
                {
                    SqlParameter[] paras = new SqlParameter[] { 
                       new SqlParameter("@userID",SqlDbType.UniqueIdentifier)                    
                    };
                    paras[0].Value = userID.ToGuid().Value;
                    DataSet ds = DbHelperSQL.Query("select SUM(userShopingAmount)  from wn_orderHead where userguid=@userID", paras);
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        return ds.Tables[0];
                    }
                }
                return null; ;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
