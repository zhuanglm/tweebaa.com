using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Collections.Generic;//Please add references
namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:proDetailsDataMgr
    /// </summary>
    public partial class proDetailsDataMgr
    {
        public proDetailsDataMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_proDetails");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Twee.Model.proDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_proDetails(");
            strSql.Append("proid,proright,proaddress,proexample,proexampleprice,prosmallnum,promodelnum,prostock,stocknum,state,userid,createtime)");
            strSql.Append(" values (");
            strSql.Append("@proid,@proright,@proaddress,@proexample,@proexampleprice,@prosmallnum,@promodelnum,@prostock,@stocknum,@state,@userid,@createtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@proright", SqlDbType.Int,4),
					new SqlParameter("@proaddress", SqlDbType.NVarChar,50),
					new SqlParameter("@proexample", SqlDbType.Int,4),
					new SqlParameter("@proexampleprice", SqlDbType.Decimal,9),
					new SqlParameter("@prosmallnum", SqlDbType.NVarChar,50),
					new SqlParameter("@promodelnum", SqlDbType.NVarChar,50),
					new SqlParameter("@prostock", SqlDbType.Decimal,9),
					new SqlParameter("@stocknum", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
                    new SqlParameter("@createtime", SqlDbType.DateTime),
                                        };
            parameters[0].Value = model.proid;
            parameters[1].Value = model.proright;
            parameters[2].Value = model.proaddress;
            parameters[3].Value = model.proexample;
            parameters[4].Value = model.proexampleprice;
            parameters[5].Value = model.prosmallnum;
            parameters[6].Value = model.promodelnum;
            parameters[7].Value = model.prostock;
            parameters[8].Value = model.stocknum;
            parameters[9].Value = (int)Twee.Comm.ConfigParamter.InventoryState.draft;
            parameters[10].Value = model.userid;
            parameters[11].Value = System.DateTime.Now;

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

        public int Add2(Twee.Model.proDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_proDetails(");
            strSql.Append("proid,proright,proaddress,proexample,proexampleprice,prosmallnum,promodelnum,prostock,stocknum,state,userid,createtime, ProductUploadBatchNo)");
            strSql.Append(" values (");
            strSql.Append("@proid,@proright,@proaddress,@proexample,@proexampleprice,@prosmallnum,@promodelnum,@prostock,@stocknum,@state,@userid,@createtime, @ProductUploadBatchNo)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@proright", SqlDbType.Int,4),
					new SqlParameter("@proaddress", SqlDbType.NVarChar,50),
					new SqlParameter("@proexample", SqlDbType.Int,4),
					new SqlParameter("@proexampleprice", SqlDbType.Decimal,9),
					new SqlParameter("@prosmallnum", SqlDbType.NVarChar,50),
					new SqlParameter("@promodelnum", SqlDbType.NVarChar,50),
					new SqlParameter("@prostock", SqlDbType.Decimal,9),
					new SqlParameter("@stocknum", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
                    new SqlParameter("@createtime", SqlDbType.DateTime),
                    new SqlParameter("@ProductUploadBatchNo", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.proid;
            parameters[1].Value = model.proright;
            parameters[2].Value = model.proaddress;
            parameters[3].Value = model.proexample;
            parameters[4].Value = model.proexampleprice;
            parameters[5].Value = model.prosmallnum;
            parameters[6].Value = model.promodelnum;
            parameters[7].Value = model.prostock;
            parameters[8].Value = model.stocknum;
            parameters[9].Value = model.state;
            parameters[10].Value = model.userid;
            parameters[11].Value = System.DateTime.Now;
            if (model.UpLoadBatchNo == null) model.UpLoadBatchNo = -1;
            parameters[12].Value = model.UpLoadBatchNo;


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
        public bool Update(Twee.Model.proDetails model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_proDetails set ");
            strSql.Append("proid=@proid,");
            strSql.Append("proright=@proright,");
            strSql.Append("proaddress=@proaddress,");
            strSql.Append("proexample=@proexample,");
            strSql.Append("proexampleprice=@proexampleprice,");
            strSql.Append("prosmallnum=@prosmallnum,");
            strSql.Append("promodelnum=@promodelnum,");
            strSql.Append("prostock=@prostock,");
            strSql.Append("stocknum=@stocknum,");
            strSql.Append("state=@state,");
            strSql.Append("createtime=getdate(),");
            strSql.Append("userid=@userid");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@proright", SqlDbType.Int,4),
					new SqlParameter("@proaddress", SqlDbType.NVarChar,50),
					new SqlParameter("@proexample", SqlDbType.Int,4),
					new SqlParameter("@proexampleprice", SqlDbType.Decimal,9),
					new SqlParameter("@prosmallnum", SqlDbType.NVarChar,50),
					new SqlParameter("@promodelnum", SqlDbType.NVarChar,50),
					new SqlParameter("@prostock", SqlDbType.Decimal,9),
					new SqlParameter("@stocknum", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.proid;
            parameters[1].Value = model.proright;
            parameters[2].Value = model.proaddress;
            parameters[3].Value = model.proexample;
            parameters[4].Value = model.proexampleprice;
            parameters[5].Value = model.prosmallnum;
            parameters[6].Value = model.promodelnum;
            parameters[7].Value = model.prostock;
            parameters[8].Value = model.stocknum;
            parameters[9].Value = (int)Twee.Comm.ConfigParamter.InventoryState.draft;
            parameters[10].Value = model.userid;
            parameters[11].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_proDetails ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_proDetails ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.proDetails GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,proid,proright,proaddress,proexample,proexampleprice,prosmallnum,promodelnum,prostock,stocknum,state,userid,createtime from wn_proDetails ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.proDetails model = new Twee.Model.proDetails();
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
        /// 通过proid,userid搜索相应的产品详情
        /// </summary>
        /// <param name="proid"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
        public Twee.Model.proDetails GetModel(string proid, string userid) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,proid,proright,proaddress,proexample,proexampleprice,prosmallnum,promodelnum,prostock,stocknum,state,userid,createtime from wn_proDetails ");
            strSql.Append(" where proid=@proid and userid=@userid");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
                    new SqlParameter("@userid", SqlDbType.NVarChar,50)
			};
            parameters[0].Value = proid;
            parameters[1].Value = userid;
            Twee.Model.proDetails model = new Twee.Model.proDetails();
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
        public Twee.Model.proDetails DataRowToModel(DataRow row)
        {
            Twee.Model.proDetails model = new Twee.Model.proDetails();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["proid"] != null && row["proid"].ToString() != "")
                {
                    model.proid = row["proid"].ToString();
                }
                if (row["proright"] != null && row["proright"].ToString() != "")
                {
                    model.proright = int.Parse(row["proright"].ToString());
                }
                if (row["proaddress"] != null && row["proaddress"].ToString() != "")
                {
                    model.proaddress = row["proaddress"].ToString();
                }
                if (row["proexample"] != null && row["proexample"].ToString() != "")
                {
                    model.proexample = int.Parse(row["proexample"].ToString());
                }
                if (row["proexampleprice"] != null && row["proexampleprice"].ToString() != "")
                {
                    model.proexampleprice = decimal.Parse(row["proexampleprice"].ToString());
                }
                if (row["prosmallnum"] != null)
                {
                    model.prosmallnum = row["prosmallnum"].ToString();
                }
                if (row["promodelnum"] != null)
                {
                    model.promodelnum = row["promodelnum"].ToString();
                }
                if (row["prostock"] != null && row["prostock"].ToString() != "")
                {
                    model.prostock = decimal.Parse(row["prostock"].ToString());
                }
                if (row["stocknum"] != null && row["stocknum"].ToString() != "")
                {
                    model.stocknum = int.Parse(row["stocknum"].ToString());
                }
                if (row["state"] != null && row["state"].ToString() != "")
                {
                    model.state = int.Parse(row["state"].ToString());
                }
                if (row["userid"] != null && row["userid"].ToString() != "")
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = Convert.ToDateTime(row["createtime"].ToString());
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
            strSql.Append("select id,proid,proright,proaddress,proexample,proexampleprice,prosmallnum,promodelnum,prostock,stocknum,state,userid,createtime ");
            strSql.Append(" FROM wn_proDetails ");
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
            strSql.Append(" id,proid,proright,proaddress,proexample,proexampleprice,prosmallnum,promodelnum,prostock,stocknum,state,userid,createtime ");
            strSql.Append(" FROM wn_proDetails ");
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
            strSql.Append("select count(1) FROM wn_proDetails ");
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
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from wn_proDetails T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Twee.Model.proDetails> GetEntityListByPage(string strWhere, string orderby, int startIndex, int endIndex) {
            List<Twee.Model.proDetails> list = new List<Model.proDetails>();
            DataTable dt = GetListByPage(strWhere,orderby,startIndex,endIndex).Tables[0];
            foreach (DataRow row in dt.Rows) {
                list.Add(DataRowToModel(row));
            }

            return list;
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
            parameters[0].Value = "wn_proDetails";
            parameters[1].Value = "id";
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
        /// 分页获取竞价供货数据列表
        /// </summary>
        public DataSet GetInventoryByPage(string proName, string startTime, string endTime, string status, string orderby, int startIndex, int endIndex, out int totalCount)
        {
            string strSqlForCount = "select count(1) 'recordcount' from (";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.id, TT.proid,TT.userid,TT.createtime,TT.state,TT.name,usr.username FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*,sp.name  from wn_proDetails T  join wn_prd sp on T.proid=sp.prdGuid ");
            strSql.Append(" WHERE (1=1) ");
            if (!string.IsNullOrEmpty(proName))
            {
                strSql.AppendFormat(" and sp.name like '%{0}%'",proName);
            }
            if (!string.IsNullOrEmpty(startTime.Trim()) && !string.IsNullOrEmpty(endTime.Trim()))
            {
                strSql.AppendFormat(" and T.createtime between '{0}' and '{1}' ",startTime,endTime);
            }
            if (!string.IsNullOrEmpty(status) && status!="-1")
            {
                strSql.AppendFormat(" and T.state={0} ",status);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join wn_user usr on TT.userid=usr.guid ");
            strSql.Append(" where 1=1 ");
           
            strSqlForCount += strSql.ToString() + ") as a;";
            string count_temp = DbHelperSQL.Query(strSqlForCount).Tables[0].Rows[0]["recordcount"]._ObjToString();
            if (!string.IsNullOrEmpty(count_temp))
                totalCount = int.Parse(count_temp);
            else
                totalCount = 0;

            strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 采纳供货
        /// </summary>
        /// <param name="proid"></param>
        /// <param name="userid"></param>
        /// <param name="detailid"></param>
        /// <returns></returns>
        public string AcceptInventory(string proid, string userid, int detailid) {
            SqlConnection conn = new SqlConnection(Twee.Comm.DbHelperSQL.strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Prc_InventoryAccept";
            cmd.CommandType = CommandType.StoredProcedure;

             SqlParameter[] parameters = {
                    new SqlParameter("@proid", SqlDbType.NVarChar,50),
                    new SqlParameter("@userid", SqlDbType.NVarChar,50),
                    new SqlParameter("@proDetailsId", SqlDbType.Int),
                    new SqlParameter("@result", SqlDbType.Int),
                    };
             parameters[0].Value = proid;
             parameters[1].Value = userid;
             parameters[2].Value = detailid;
             parameters[3].Direction = ParameterDirection.Output;
             cmd.Parameters.Add(parameters[0]);
             cmd.Parameters.Add(parameters[1]);
             cmd.Parameters.Add(parameters[2]);
             cmd.Parameters.Add(parameters[3]);
             conn.Open();
             string res = cmd.ExecuteNonQuery().ToString();
             conn.Close();
             return parameters[3].Value.ToString();
            // return DbHelperSQL.RunProcedureOut("Prc_InventoryAccept", parameters, "result");
        }
        /// <summary>
        /// 拒绝采纳该产品供货单
        /// </summary>
        /// <param name="detailid"></param>
        /// <returns></returns>
        public int UnAcceptInventory(string detailid) {
            string sql = "update wn_proDetails set state="+(int)Twee.Comm.ConfigParamter.InventoryState.rejected+" where id="+detailid+";";
            return DbHelperSQL.ExecuteSql(sql);
        }
        /// <summary>
        /// 修改供货单的状态
        /// </summary>
        /// <param name="proid">产品id</param>
        /// <param name="userid">供应商id</param>
        /// <param name="state">状态</param>
        /// <returns></returns>
        public bool UpdateInventoryState(string proid, string userid,int state)
        {
            string sql = "update wn_proDetails set state=@state where proid=@proid,userid=@userid ";

               SqlParameter[] parameters = {
                    new SqlParameter("@proid", SqlDbType.NVarChar,50),
                    new SqlParameter("@userid", SqlDbType.NVarChar,50),
                    new SqlParameter("@state", SqlDbType.Int)                 
                    };
             parameters[0].Value = proid;
             parameters[1].Value = userid;
             parameters[2].Value = state;
            int count = DbHelperSQL.ExecuteSql(sql,parameters);
            return count > 0 ? true : false;
        }

        public List<Twee.Model.ProDetailSupplyType> GetSupplyTypeList()
        {
            List<Twee.Model.ProDetailSupplyType> list = new List<Model.ProDetailSupplyType>();
            string sql = "select * from wn_proDetailSupplyType";
            DataSet ds = DbHelperSQL.Query(sql.ToString());
            if (ds != null) 
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Twee.Model.ProDetailSupplyType model = new Model.ProDetailSupplyType();
                    model.id = Convert.ToInt32(row["id"]);
                    if (row["prodetailType"] != null && !string.IsNullOrEmpty( row["prodetailType"].ToString()))
                       model.prodetailType = row["prodetailType"].ToString();

                    if (row["remark"] != null && !string.IsNullOrEmpty(row["remark"].ToString()))
                       model.remark = row["remark"].ToString();

                    list.Add(model);
                }
            }
            return list;
        }

        public Twee.Model.ProDetailSupplyType GetSupplyTypeById(int id)
        {
            string sql = "select * from wn_proDetailSupplyType where id="+id.ToString();
            DataSet ds = DbHelperSQL.Query(sql.ToString());
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                Twee.Model.ProDetailSupplyType model = new Model.ProDetailSupplyType();
                DataRow row = dt.Rows[0];
                model.id = Convert.ToInt32(row["id"]);
                if (row["prodetailType"] != null && !string.IsNullOrEmpty(row["prodetailType"].ToString()))
                    model.prodetailType = row["prodetailType"].ToString();

                if (row["remark"] != null && !string.IsNullOrEmpty(row["remark"].ToString()))
                    model.remark = row["remark"].ToString();
                return model;
            }
            else
            {
                return null; 
            }
           
        }

        #endregion  ExtensionMethod
    }
}

