using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Collections.Generic;//Please add references
namespace Twee.DataMgr
{
	/// <summary>
	/// 数据访问类:ProfitDataMgr
	/// </summary>
	public partial class ProfitDataMgr
	{
        public ProfitDataMgr()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("id", "wn_Profit"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wn_Profit");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Twee.Model.Profit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wn_Profit(");
			strSql.Append("type,userId,money,prdId,orderNo,state,remark,addTime,editTime)");
			strSql.Append(" values (");
			strSql.Append("@type,@userId,@money,@prdId,@orderNo,@state,@remark,@addTime,@editTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.NVarChar,20),
					new SqlParameter("@userId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@prdId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@orderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@editTime", SqlDbType.DateTime)};
			parameters[0].Value = model.type;
            parameters[1].Value = model.userId;
			parameters[2].Value = model.money;
            parameters[3].Value = model.prdId;
			parameters[4].Value = model.orderNo;
			parameters[5].Value = model.state;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.addTime;
			parameters[8].Value = model.editTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Twee.Model.Profit model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wn_Profit set ");
			strSql.Append("type=@type,");
			strSql.Append("userId=@userId,");
			strSql.Append("money=@money,");
			strSql.Append("prdId=@prdId,");
			strSql.Append("orderNo=@orderNo,");
			strSql.Append("state=@state,");
			strSql.Append("remark=@remark,");
			strSql.Append("addTime=@addTime,");
			strSql.Append("editTime=@editTime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@type", SqlDbType.NVarChar,20),
					new SqlParameter("@userId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@money", SqlDbType.Decimal,9),
					new SqlParameter("@prdId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@orderNo", SqlDbType.NVarChar,50),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.NVarChar,100),
					new SqlParameter("@addTime", SqlDbType.DateTime),
					new SqlParameter("@editTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.type;
			parameters[1].Value = model.userId;
			parameters[2].Value = model.money;
			parameters[3].Value = model.prdId;
			parameters[4].Value = model.orderNo;
			parameters[5].Value = model.state;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.addTime;
			parameters[8].Value = model.editTime;
			parameters[9].Value = model.id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_Profit ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_Profit ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		/// 得到一个对象实体
		/// </summary>
		public Twee.Model.Profit GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,type,userId,money,prdId,orderNo,state,remark,addTime,editTime from wn_Profit ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			Twee.Model.Profit model=new Twee.Model.Profit();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Twee.Model.Profit DataRowToModel(DataRow row)
		{
			Twee.Model.Profit model=new Twee.Model.Profit();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["type"]!=null)
				{
					model.type=row["type"].ToString();
				}
				if(row["userId"]!=null && row["userId"].ToString()!="")
				{
					model.userId= new Guid(row["userId"].ToString());
				}
				if(row["money"]!=null && row["money"].ToString()!="")
				{
					model.money=decimal.Parse(row["money"].ToString());
				}
				if(row["prdId"]!=null && row["prdId"].ToString()!="")
				{
					model.prdId= new Guid(row["prdId"].ToString());
				}
				if(row["orderNo"]!=null)
				{
					model.orderNo=row["orderNo"].ToString();
				}
				if(row["state"]!=null && row["state"].ToString()!="")
				{
					model.state=int.Parse(row["state"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["addTime"]!=null && row["addTime"].ToString()!="")
				{
					model.addTime=DateTime.Parse(row["addTime"].ToString());
				}
				if(row["editTime"]!=null && row["editTime"].ToString()!="")
				{
					model.editTime=DateTime.Parse(row["editTime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,type,userId,money,prdId,orderNo,state,remark,addTime,editTime ");
			strSql.Append(" FROM wn_Profit ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" id,type,userId,money,prdId,orderNo,state,remark,addTime,editTime ");
			strSql.Append(" FROM wn_Profit ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM wn_Profit ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from wn_Profit T ");
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
			parameters[0].Value = "wn_Profit";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod


        #region  会员中心

        /// <summary>
        /// 根据会员id,获取会员的收益
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public DataTable GetHomeUserProfit(Guid userGuid, string type, string prdName, string sBeginDate, string sEndDate, int startIndex, int endIndex, out int tatalCount)
        {
            string strSqlForCount = "select count(1) 'recordcount' from (";
            StringBuilder sbStr = new StringBuilder();
            string orderby = "addtime";
            sbStr.Append("select TT.id, TT.prdId, type,money,convert(varchar(25), TT.addTime, 120) as AddDate, TT.shareLevel,TT.CommissionRate,prd.name,prd.prdGuid, prd.txtjj, prd.addtime pubtime,f.fileurl,u.username from  ( ");
            sbStr.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sbStr.Append("order by T." + orderby);
            }
            else
            {
                sbStr.Append("order by T.id desc");
            }
            sbStr.Append(")AS Row, T.*  from wn_Profit T where userId='" + userGuid + "'");           
            sbStr.Append(" ) TT");
            sbStr.Append(" left join wn_prd prd  on  TT.prdId=prd.prdGuid");
            sbStr.Append(" left join wn_file  f on prd.prdGuid=f.prdguid");
            sbStr.Append(" left join wn_user u on TT.userId=u.guid");
            sbStr.Append(" where  f.idx=0");
            if (!string.IsNullOrEmpty(type))
            {
                sbStr.Append(" and type='"+type+"'");
            }
            if (!string.IsNullOrEmpty(prdName))
            {
                sbStr.Append(" and prd.name like '%" + prdName + "%'");
            }
            if (!string.IsNullOrEmpty(sBeginDate))
            {
                sbStr.Append(" and TT.addtime >='" + sBeginDate + " 0:00'");
            }
            if (!string.IsNullOrEmpty(sEndDate))
            {
                sbStr.Append(" and TT.addtime <='" + sEndDate + " 23:59'");
            }

            strSqlForCount += sbStr.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                tatalCount = int.Parse(count_temp);
            else
                tatalCount = 0;
            sbStr.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);

            DataSet ds = DbHelperSQL.Query(sbStr.ToString());
            if (ds!=null&&ds.Tables.Count>0)
            {
                return ds.Tables[0];
            }
            return null;
        
            //select p.prdId, type,money,p.addTime,prd.name,f.fileurl from wn_Profit  p 
            //left join wn_prd prd  on  p.prdId=prd.prdGuid
            //left join wn_file  f on prd.prdGuid=f.prdguid
            //where p.userId='' and f.idx=0
        
        }

        /// <summary>
        /// 获取预收益或实际收益
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="preOrReal">0：预收益；1；实际收益（可提取）</param>
        /// <returns></returns>
        public DataTable GetPreOrRealProfit(Guid userGuid,int preOrReal)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(p.money) from wn_Profit p left join wn_orderhead h on p.orderNo=h.guidno where  p.userId='"+userGuid.ToString()+"' and h.wnstat=3");
            if (preOrReal==0)
            {
                strSql.Append("and DATEDIFF(DD,h.addtime,GETDATE())<=7");
            }
            if (preOrReal==1)
            {
                strSql.Append("and DATEDIFF(DD,h.addtime,GETDATE())>7");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
           
        }

        /// <summary>
        /// 后台管理会员的收益列表
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        /// 
        public DataTable MgrGetUserProfit(Guid? userGuid,string email, string type, string state, string prdName, int startIndex, int endIndex,string startTime,string endTime,  out int tatalCount)
        {
           
            StringBuilder sbStr = new StringBuilder();
            string orderby = "addtime";
            sbStr.Append("select TT.id, TT.prdId, type,state,remark,money,orderNo,TT.addTime,prd.name,prd.prdGuid, f.fileurl,u.username,u.email from  ( ");
            sbStr.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sbStr.Append("order by T." + orderby);
            }
            else
            {
                sbStr.Append("order by T.id desc");
            }
            sbStr.Append(")AS Row, T.*  from wn_Profit T ");
            sbStr.Append(" ) TT");

            sbStr.Append(" left join wn_prd prd  on  TT.prdId=prd.prdGuid");
            sbStr.Append(" left join wn_file  f on prd.prdGuid=f.prdguid");
            sbStr.Append(" left join wn_user u on prd.userGuid=u.guid");
            sbStr.Append(" where f.idx=0");
           
            if (!string.IsNullOrEmpty(type))
            {
                sbStr.Append(" and type='" + type + "'");
            }
            if (!string.IsNullOrEmpty(state))
            {
                sbStr.Append(" and state=" + state );
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                sbStr.Append(" and TT.addTime >= '" + startTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                sbStr.Append(" and TT.addTime <= '" + endTime + "'");
            }
            if (!string.IsNullOrEmpty(prdName))
            {
                sbStr.Append(" and prd.name like '%" + prdName + "%'");
            }
            if (!string.IsNullOrEmpty(email))
            {
                sbStr.Append(" and u.email = '" + email + "'");
            }
            tatalCount = 0;
            sbStr.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);

            DataSet ds = DbHelperSQL.Query(sbStr.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        /// <summary>
        /// 用户已经领取的收益总和
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string HaveedShouYiSum(string userid)
        {
            //状态值为2表示已经领取了的收益
            string sql = "select sum(money) as shouyi from wn_profit where userid='" + userid + "' and state=2;";
            return DbHelperSQL.Query(sql).Tables[0].Rows[0]["shouyi"].ToString();
        }
        /// <summary>
        /// 用户还没有领取的收益总和
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string NotHaveShouYiSum(string userid)
        {
            //状态值为0表示还没有领取的收益
            string sql = "select sum(money) as shouyi from wn_profit where userid='" + userid + "' and state=0;";
            return DbHelperSQL.Query(sql).Tables[0].Rows[0]["shouyi"].ToString();
        }
        /// <summary>
        /// 申请提现
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int ApplyCash(string ids)
        {
            //状态为1表示申请提现
            string sql = "update wn_profit set state=1 where id in ("+ids+")";
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 修改状态
      /// </summary>
      /// <param name="ids"></param>
      /// <param name="state"></param>
      /// <returns></returns>
        public int UpdateState(int id, int state)
        {
            //状态为1表示申请提现
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int),
                    new SqlParameter("@state", SqlDbType.Int)
			};
            parameters[0].Value = id;
            parameters[1].Value = state;
            string sql = "update wn_profit set state=@state where id=@id";
            return DbHelperSQL.ExecuteSql(sql,parameters);
        }

        /// <summary>
        /// 查询当前提现总额
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string SelectApplyCash(string ids)
        {
            string sql = "select sum(money) as summoney from wn_profit where id in (" + ids + ")";
            return DbHelperSQL.Query(sql).Tables[0].Rows[0]["summoney"].ToString();
        }

        #endregion 

        #region  ExtensionMethod
        /// <summary>
        /// 获取Tweebucks（不包括在途的和申请中的，也不包括未过退货期的）
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetTweebuck(Guid userID)
        {
            SqlParameter[] parameters = {					
					new SqlParameter("@userId", SqlDbType.UniqueIdentifier,16)
					};
            parameters[0].Value = userID;
            //string strSql = "select tweebuck-(select case when SUM([money]) is  null then 0 else SUM([money]) end from wn_ProfitOut where userId=@userId and state=0) ExtractionTweebuck from  wn_usergrade where userguid=@userId";

            string strSql = "select tweebuck-(select case when SUM([money]) is  null then 0 else SUM([money]) end from wn_ProfitOut where userId=@userId and state=0)-(select case when SUM([money]) is  null then 0 else SUM([money]) end from wn_profit where userId=@userId and state=0  and DATEDIFF(DD,addTime,GETDATE())<=6) ExtractionTweebuck from  wn_usergrade where userguid=@userId";

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds!=null && ds.Tables.Count>0 )
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //将获得的收益(在退货期内的收益)
        public DataTable GetPendingTweebuck(Guid userID)
        {
            SqlParameter[] parameters = {					
					new SqlParameter("@userId", SqlDbType.UniqueIdentifier,16)
					};
            parameters[0].Value = userID;


            //Modify by Long for pending Tweebuck
            string strSql = "select pending_tweebuck as PendingTweebuck from wn_usergrade where userguid = @userId";
            //string strSql = "select case when SUM([money]) is  null then 0 else SUM([money]) end PendingTweebuck from wn_profit where userId=@userId and state=0  and DATEDIFF(DD,addTime,GETDATE())<=6";

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        //申请中、已提取
        public DataSet GetTweebuckOther(Guid userID)
        {
            SqlParameter[] parameters = {					
					new SqlParameter("@userId", SqlDbType.UniqueIdentifier,16)
					};
            parameters[0].Value = userID;
            string strSql = "select SUM([money]) from wn_ProfitOut where userId=@userId and state=" + ((int)Comm.ConfigParamter.CashWithdrawStatus.Request).ToString() + " ; " +
                            "select SUM([money]) from wn_ProfitOut where userId=@userId and state=" + ((int)Comm.ConfigParamter.CashWithdrawStatus.Accepted).ToString();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            return ds;
        }

        //申请提现
        public bool AddProfitOut(Guid userId,int type, decimal money,string remark)
        {
            try
            {
                string strSql = "insert into wn_profitOut (userId,[type],[money],[state],remark,addTime,editTime)values(@userId, @type, @money,@state,@remark,getdate(),getdate())";
                SqlParameter[] parameters = {					
					new SqlParameter("@userId", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@type", SqlDbType.TinyInt),
                    new SqlParameter("@money", SqlDbType.Decimal),
                    new SqlParameter("@state", SqlDbType.Int),
                    new SqlParameter("@remark", SqlDbType.NVarChar,50)
					};
                parameters[0].Value = userId;
                parameters[1].Value = type;
                parameters[2].Value = money;
                parameters[3].Value = (int)(Comm.ConfigParamter.CashWithdrawStatus.Request);
                parameters[4].Value = remark;
                DbHelperSQL.ExecuteSql(strSql, parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;               
            }
           
        }
        //提现列表
        public DataTable GetPayCash(string state, int startIndex, int endIndex, out int tatalCount)
        {
            string strSqlForCount = "select count(1) 'recordcount' from (";
            StringBuilder sbStr = new StringBuilder();
            string orderby = "addtime";
            sbStr.Append("select TT.id, TT.userId, TT.money,TT.state,TT.addTime,TT.editTime,TT.remark,u.username,u.paymentno from  ( ");
            sbStr.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                sbStr.Append("order by T." + orderby);
            }
            else
            {
                sbStr.Append("order by T.id desc");
            }
            sbStr.Append(")AS Row, T.*  from wn_ProfitOut T ");
            sbStr.Append(" ) TT");
            sbStr.Append(" left join wn_user u on TT.userId=u.guid");

            if (!string.IsNullOrEmpty(state))
            {
                sbStr.Append(" and TT.state=" + state);
            }          
            strSqlForCount += sbStr.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                tatalCount = int.Parse(count_temp);
            else
                tatalCount = 0;
            sbStr.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);

            DataSet ds = DbHelperSQL.Query(sbStr.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        //确认已支付
        public bool SureHavePay(int id)
        {
            string strSql = "update wn_ProfitOut set state=1 where id=" + id;
            int res = DbHelperSQL.ExecuteSql(strSql);
            if (res>0)
            {
                return true;
            }
            return false;
        }
        #endregion  ExtensionMethod

        #region Backend system

        /// <summary>
        /// backend accept Cash Withdraw
        /// accept cash withdraw only when it is in request status
        /// </summary>
        public int MgeAcceptCashWithdraw(int iID)
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append(" update wn_ProfitOut set ");
            sSql.Append("   state=" + ((int)(Comm.ConfigParamter.CashWithdrawStatus.Accepted)).ToString());
            sSql.Append("   ,editTime=getdate()");
            sSql.Append(" where id=" + iID.ToString());
            sSql.Append("   and state=" + ((int)(Comm.ConfigParamter.CashWithdrawStatus.Request)).ToString());
            int iAffectedRow = DbHelperSQL.ExecuteSql(sSql.ToString());

            return iAffectedRow;
        }

        /// <summary>
        /// backend reject Cash Withdraw
        /// Reject cash withdraw only when it is in request status
        /// </summary>
        public int MgeRejectCashWithdraw(int iID)
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append(" update wn_ProfitOut set ");
            sSql.Append("   state=" + ((int)(Comm.ConfigParamter.CashWithdrawStatus.Rejected)).ToString());
            sSql.Append("   ,editTime=getdate()");
            sSql.Append(" where id=" + iID.ToString());
            sSql.Append("   and state=" + ((int)(Comm.ConfigParamter.CashWithdrawStatus.Request)).ToString());
            int iAffectedRow = DbHelperSQL.ExecuteSql(sSql.ToString());

            return iAffectedRow;
        }

        /// <summary>
        /// backend reject Cash Withdraw
        /// Request cash withdraw only when it is in Invalid status
        /// put a rejected cash withdraw back to request status
        /// </summary>
        public int MgeRequestCashWithdraw(int iID)
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append(" update wn_ProfitOut set ");
            sSql.Append("   state=" + ((int)(Comm.ConfigParamter.CashWithdrawStatus.Request)).ToString());
            sSql.Append("   ,editTime=getdate()");
            sSql.Append(" where id=" + iID.ToString());
            sSql.Append("   and state=" + ((int)(Comm.ConfigParamter.CashWithdrawStatus.Rejected)).ToString());
            int iAffectedRow = DbHelperSQL.ExecuteSql(sSql.ToString());

            return iAffectedRow;
        }

        /// <summary>
        /// backend Get Cash Withdraw list
        /// </summary>
        public DataTable MgeGetCashWithdrawList(string sUserName, string sStatus, string sStartDate, string sEndDate, int iStartRow, int iEndRow, out int iTotalCount)
        {
            StringBuilder sSqlComm = new StringBuilder();

            sSqlComm.Append(" SELECT ROW_NUMBER() OVER ( order by TT.addTime) as Row ");
            sSqlComm.Append(" ,TT.*, X.username, X.email as useremail  from wn_ProfitOut TT ");
            sSqlComm.Append(" inner join wn_user X on X.guid = TT.userId");
            sSqlComm.Append(" where TT.type=" +  (int)(ConfigParamter.ProfitOutType.CashWithdraw));
            if (!string.IsNullOrEmpty(sUserName))
            {
                sSqlComm.Append(" and X.username like '%" +  CommUtil.Quo(sUserName) + "%'");
            }
            if (!string.IsNullOrEmpty(sStatus))
            {
                sSqlComm.Append(" and TT.state =" + sStatus );
            }
            if (!string.IsNullOrEmpty(sStartDate))
            {
                sSqlComm.Append(" and TT.addTime >= '" + sStartDate + " 0:00'" );
            }
            if (!string.IsNullOrEmpty(sEndDate))
            {
                sSqlComm.Append(" and TT.addTime <= '" + sEndDate + " 23:59'" );
            }

            // retrieve total count
            StringBuilder sSql = new StringBuilder();
            sSql.Append("select count(*) from (");
            sSql.Append(sSqlComm.ToString());
            sSql.Append(") as t");
            iTotalCount = DbHelperSQL.QueryCount(sSql.ToString());

            // retrieve data list
            sSql.Clear();
            sSql.Append("select * from (");
            sSql.Append(sSqlComm.ToString());
            sSql.Append(") as t");
            sSql.Append(" where t.Row between " + iStartRow.ToString() + " and " + iEndRow.ToString());

            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }
        #endregion
    }
}

