using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Twee.Model;
using Twee.Mgr;
using System.Linq;
using Twee.Comm;
using System.Data.SqlClient;
using System.Text;
using System.Collections;
using log4net;
using System.Reflection;
namespace Twee.Mgr
{
	/// <summary>
	/// wn_Profit
	/// </summary>
	public partial class ProfitMgr
	{
        ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly Twee.DataMgr.ProfitDataMgr mgr = new DataMgr.ProfitDataMgr();
        public ProfitMgr()
		{}

		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return mgr.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return mgr.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Twee.Model.Profit model)
		{
			return mgr.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Twee.Model.Profit model)
		{
			return mgr.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return mgr.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return mgr.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Twee.Model.Profit GetModel(int id)
		{
			
			return mgr.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Twee.Model.Profit GetModelByCache(int id)
		{
			
			string CacheKey = "wn_ProfitModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = mgr.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Twee.Model.Profit)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return mgr.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Twee.Model.Profit> GetModelList(string strWhere)
		{
			DataSet ds = mgr.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Twee.Model.Profit> DataTableToList(DataTable dt)
		{
			List<Twee.Model.Profit> modelList = new List<Twee.Model.Profit>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Twee.Model.Profit model;
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
			return mgr.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return mgr.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod

        #region  会员中心

        /// <summary>
        /// 根据会员id,获取会员的收益
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public DataTable GetHomeUserProfit(Guid userGuid, string type, string prdName, string sBeginDate, string sEndDate, int startIndex,int endIndex,out int tatalCount)
        {
            return mgr.GetHomeUserProfit(userGuid, type,  prdName, sBeginDate, sEndDate, startIndex,endIndex,out tatalCount);
        }
        /// <summary>
        /// 获取预收益或实际收益
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="preOrReal">0：预收益；1；实际收益（可提取）</param>
        /// <returns></returns>
        public DataTable GetPreOrRealProfit(Guid userGuid, int preOrReal)
        {
            return mgr.GetPreOrRealProfit(userGuid,preOrReal);

        }
        /// <summary>
        /// 后台管理会员的收益列表
        /// </summary>
        /// <param name="userGuid"></param>
        /// <returns></returns>
        public DataTable MgrGetUserProfit(Guid? userGuid, string email, string type, string state, string prdName, int startIndex, int endIndex, string startTime, string endTime, out int tatalCount)
        {
            return mgr.MgrGetUserProfit(userGuid, email, type,state, prdName, startIndex, endIndex, startTime, endTime,out tatalCount);

        }


        /// <summary>
        /// backend accept Cash Withdraw
        /// accept cash withdraw only when it is in request status
        /// </summary>
        public int MgeAcceptCashWithdraw(int iID)
        {
            return mgr.MgeAcceptCashWithdraw(iID);
        }

        /// <summary>
        /// backend reject Cash Withdraw
        /// Reject cash withdraw only when it is in request status
        /// </summary>
        public int MgeRejectCashWithdraw(int iID)
        {
            return mgr.MgeRejectCashWithdraw(iID);
        }

        /// <summary>
        /// backend reject Cash Withdraw
        /// Request cash withdraw only when it is in Invalid status
        /// put a rejected cash withdraw back to request status
        /// </summary>
        public int MgeRequestCashWithdraw(int iID)
        {
            return mgr.MgeRequestCashWithdraw(iID);
        }



        /// <summary>
        /// backend Get Cash Withdraw list
        /// </summary>
        public DataTable MgeGetCashWithdrawList(string sUserName, string sStatus, string sStartDate, string sEndDate, int iStartRow, int iEndRow, out int iTotalCount)
        {
            return mgr.MgeGetCashWithdrawList(sUserName, sStatus, sStartDate, sEndDate, iStartRow, iEndRow, out iTotalCount);
        }

        /// <summary>
        /// 用户已经领取的收益总和
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string HaveedShouYiSum(string userid)
        { 
        return mgr.HaveedShouYiSum(userid);
        }
         /// <summary>
        /// 用户还没有领取的收益总和
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public string NotHaveShouYiSum(string userid)
        {
            return mgr.NotHaveShouYiSum(userid);
        }
         /// <summary>
        /// 申请提现
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int ApplyCash(string ids)
        {
            return mgr.ApplyCash(ids);
        }
        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpdateState(int id, int state)
        {
            return mgr.UpdateState(id, state);
        }
        /// <summary>
        /// 查询当前提现总额
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string SelectApplyCash(string ids)
        {
            return mgr.SelectApplyCash(ids);
        }


        #endregion 


		#region  会员收益计算


        /// <summary>
        /// 发布者收益计算（订单支付完成之后，创建该条收益； 但在退货期过后才可以提现）
        /// </summary>
        /// <param name="userGuid"></param>
        //public void PublishProfitCal(Guid userGuid,string orderNo)
        //{
        //    try
        //    {
        //        OrderMgr orderMgr = new OrderMgr();
        //        DataTable dtOrder = orderMgr.GetOrderDetial(orderNo);
        //        foreach (DataRow dr in dtOrder.Rows)
        //        {
        //            Profit model = new Profit();
        //            model.type = "发布者";
        //            model.userId = userGuid;
        //            model.orderNo = orderNo;//收益订单
        //            model.money = dr["money"].ToString().ToDecimal();//收益金额
        //            model.prdId = dr["prdGuid"].ToString().ToGuid().Value;//收益产皮
        //            model.remark = "收益产品：" + dr["name"].ToString();//收益说明            
        //            model.state = 0;
        //            model.addTime = DateTime.Now;
        //            model.editTime = null;
        //            mgr.Add(model);
        //        }
        //        //var prdStr = dtOrder.AsEnumerable().Select(t => t.Field<string>("prdGuid")).ToList<string>();
        //    }
        //    catch (Exception)
        //    {                
        //        throw;
        //    }
            
        //}

       /// <summary>
        /// 【发布者收益】计算(事物实现)（订单支付完成之后，创建该条收益； 但在退货期过后才可以提现）
        /// SQL语句的哈希表（key为标识，value是该语句的SqlParameter[]）
       /// </summary>
       /// <param name="orderNo">订单号</param>
       /// <returns></returns>
        public bool PublishProfitCal(string orderNo)
        {
            try
            {              
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into wn_Profit(");
                strSql.Append("type,userId,money,prdId,orderNo,state,remark,addTime,editTime)");
                strSql.Append(" values (");
                strSql.Append("@type,@userId,@money,@prdId,@orderNo,@state,@remark,@addTime,@editTime)");

                OrderMgr orderMgr = new OrderMgr();
                DataTable dtOrder = orderMgr.GetOrderDetial(orderNo);
                Hashtable SQLStringList = new Hashtable();
                int i = 0;
                foreach (DataRow dr in dtOrder.Rows)
                {
                    UserGradeCalMgr user = new UserGradeCalMgr();
                    DataTable dtUser = user.GetUserGrade(dr["userGuid"].ToString().ToGuid().Value);
                    decimal ratio = dtUser.Rows[0]["pratio"].ToString().ToDecimal();
                    decimal pubRatio = ratio / 1000M;//该发布者当前发布佣金比例      

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
                    parameters[0].Value = "发布";
                    parameters[1].Value = dr["userGuid"].ToString().ToGuid().Value;//收益者id(即产品发布者id)
                    parameters[2].Value = dr["money"].ToString().ToDecimal() * pubRatio;//收益金额
                    parameters[3].Value = dr["prdGuid"].ToString().ToGuid().Value;//收益产品
                    parameters[4].Value = orderNo;
                    parameters[5].Value = 0;
                    parameters[6].Value = "Product：" + dr["name"].ToString();//收益说明    
                    parameters[7].Value = DateTime.Now;
                    parameters[8].Value = null;
                    SQLStringList.Add(i, parameters);
                    i += 1;
                }
                DbHelperSQL.ExecuteSqlTran(strSql.ToString(), SQLStringList);
                return true;
                //var prdStr = dtOrder.AsEnumerable().Select(t => t.Field<string>("prdGuid")).ToList<string>();
            }
            catch (Exception)
            {
                return false;
            }

        }

        /// <summary>
        /// 【评审者收益】计算(事物实现)（订单支付完成之后，创建该条收益； 但在退货期过后才可以提现）
        /// SQL语句的哈希表（key为标识，value是该语句的SqlParameter[]）
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public bool ReviewProfitCal(string orderNo)
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into wn_Profit(");
                strSql.Append("type,userId,money,prdId,orderNo,state,remark,addTime,editTime)");
                strSql.Append(" values (");
                strSql.Append("@type,@userId,@money,@prdId,@orderNo,@state,@remark,@addTime,@editTime)");

                OrderMgr orderMgr = new OrderMgr();
                DataTable dtOrder = orderMgr.GetOrderDetial(orderNo);
                Hashtable SQLStringList = new Hashtable();

                ReviewgradeparamMgr reviewParam = new ReviewgradeparamMgr();
                DataTable dtPararm = reviewParam.GetList("").Tables[0];
                decimal ratio = dtPararm.Rows[0]["commissionratio1"].ToString().ToDecimal();
                decimal reviewRatio = ratio / 1000M;//评审者佣金比例

                int i = 0;
                foreach (DataRow dr in dtOrder.Rows)
                {
                    ReviewMgr reviewMgr = new ReviewMgr();
                    DataTable dtReviewUser = reviewMgr.GetReviewUserByType(dr["prdGuid"].ToString().ToGuid().Value, 1);//该产品所有支持的评审者id
                    for (int j = 0; j < dtReviewUser.Rows.Count; j++)
                    {
                        //Profit model = new Profit();   
                        string sqlKey = i.ToString() + j.ToString();
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
                        parameters[0].Value = "评审";
                        parameters[1].Value = dtReviewUser.Rows[j]["userGuid"].ToString().ToGuid().Value;//收益者id(即产品发布者id)
                        parameters[2].Value = dr["money"].ToString().ToDecimal() * reviewRatio;//收益金额 
                        parameters[3].Value = dr["prdGuid"].ToString().ToGuid().Value;//收益产品
                        parameters[4].Value = orderNo;
                        parameters[5].Value = 0;
                        parameters[6].Value = "Product：" + dr["name"].ToString();//收益说明
                        parameters[7].Value = DateTime.Now;
                        parameters[8].Value = null;
                        SQLStringList.Add(sqlKey, parameters);
                    }
                    i += 1;
                }
                DbHelperSQL.ExecuteSqlTran(strSql.ToString(), SQLStringList);
                return true;    
            }
            catch (Exception)
            {
                return false;
            }       
        }

        /// <summary>
        /// 【分享者收益】将所有分享链接产生的可提取的订单收益 插入收益表
        /// </summary>
        /// <returns></returns>
        public bool ShareProfitCal()
        {
            try
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into wn_Profit(");
                strSql.Append("type,userId,money,prdId,orderNo,state,remark,addTime,editTime)");
                strSql.Append(" values (");
                strSql.Append("@type,@userId,@money,@prdId,@orderNo,@state,@remark,@addTime,@editTime)");

                ShareMgr shareMgr = new ShareMgr();
                DataTable dtOrder = shareMgr.GteShareOrder("2", "");//获取所有通过分享产生的可提取收益的订单相关信息
                Hashtable SQLStringList = new Hashtable();

                UserGradeCalMgr user = new UserGradeCalMgr();
                int i = 0;
                foreach (DataRow dr in dtOrder.Rows)
                {
                    DataTable dtUser = user.GetUserGrade(dr["shareUser"].ToString().ToGuid());//
                    decimal ratio = dtUser.Rows[0]["sratio"].ToString().ToDecimal();
                    decimal shareRatio = ratio / 1000M;//该分享者当前分享佣金比例 
                     
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
                        parameters[0].Value = "分享";
                        parameters[1].Value = dr["shareUser"].ToString().ToGuid().Value;//收益者id(即产品发布者id)
                        parameters[2].Value = dr["money"].ToString().ToDecimal() * shareRatio;//收益金额 
                        parameters[3].Value = dr["prdGuid"].ToString().ToGuid().Value;//收益产品
                        parameters[4].Value = dr["orderNo"].ToString();//收益的关联订单
                        parameters[5].Value = 2;//可提取状态
                        parameters[6].Value = "收益产品：" + dr["name"].ToString();//收益说明
                        parameters[7].Value = DateTime.Now;
                        parameters[8].Value = null;
                        SQLStringList.Add(i, parameters);
                   
                    i += 1;
                }
                DbHelperSQL.ExecuteSqlTran(strSql.ToString(), SQLStringList);
                return true;
            }
            catch (Exception)
            {
                return false;
            }       
        
        }

		#endregion  ExtensionMethod

        #region  ExtensionMethod
        /// <summary>
        /// 获取Tweebucks（不包括在途的和申请中的）
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public DataTable GetTweebuck(Guid userID)
        {
            return mgr.GetTweebuck(userID);
        }
        //将获得的收益(在退货期内的收益)
        public DataTable GetPendingTweebuck(Guid userID)
        {
            return mgr.GetPendingTweebuck(userID);
        }
        //申请中、已提取
        public DataSet GetTweebuckOther(Guid userID)
        {
            return mgr.GetTweebuckOther(userID);
        }

        //提现
        public bool AddProfitOut(Guid userId, int type, decimal money, string remark)
        {
            try
            {
                return mgr.AddProfitOut(userId, type, money, remark);
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        //提现列表
        public DataTable GetPayCash(string state,  int startIndex, int endIndex, out int tatalCount)
        {
            return mgr.GetPayCash( state,  startIndex, endIndex, out tatalCount);
        }
        //确认已支付
        public bool SureHavePay(int id)
        {
            return mgr.SureHavePay(id);
        }
        #endregion  ExtensionMethod
	}
}

