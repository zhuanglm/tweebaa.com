using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Collections.Generic;//Please add references
namespace Twee.DataMgr
{
    /// <summary>
    /// 数据访问类:proRulesDataMgr
    /// </summary>
    public partial class proRulesDataMgr
    {
        public proRulesDataMgr()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_proRules");
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
        public int Add(Twee.Model.proRules model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_proRules(");
            strSql.Append("proid,userid,proruletitle,prorule,prostock,prosku, suppliersku, probulk,proweight, prolength, prowidth, proheight, probox,prosize,proboxweight, proboxlength, proboxwidth, proboxheight, color,barcode,createtime,ShipFrom_ID,ShipPartner_ID, ProductUploadBatchNo,SupplierShipFee,IsCustomerFreeShip, packageweight, packagelength, packagewidth, packageheight, wholesaleprice, SupplierShipMethodName)");
            strSql.Append(" values (");
            strSql.Append("@proid,@userid,@proruletitle,@prorule,@prostock,@prosku, @suppliersku, @probulk,@proweight, @prolength, @prowidth, @proheight, @probox,@prosize,@proboxweight,@proboxlength, @proboxwidth, @proboxheight, @color,@barcode,@createtime,@ShipFrom_ID,@ShipPartner_ID, @ProductUploadBatchNo,@SupplierShipFee,@IsCustomerFreeShip, @packageweight, @packagelength, @packagewidth,@packageheight, @wholesaleprice, @SupplierShipMethodName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@proruletitle", SqlDbType.Int,4),
					new SqlParameter("@prorule", SqlDbType.NVarChar,50),
					new SqlParameter("@prostock", SqlDbType.NVarChar,50),
					new SqlParameter("@prosku", SqlDbType.NVarChar,50),
					new SqlParameter("@suppliersku", SqlDbType.NVarChar,50),
					new SqlParameter("@probulk", SqlDbType.NVarChar,50),
					new SqlParameter("@proweight", SqlDbType.NVarChar,50),
					new SqlParameter("@prolength", SqlDbType.NVarChar,50),
					new SqlParameter("@prowidth", SqlDbType.NVarChar,50),
					new SqlParameter("@proheight", SqlDbType.NVarChar,50),
					new SqlParameter("@probox", SqlDbType.NVarChar,50),
					new SqlParameter("@prosize", SqlDbType.NVarChar,50),
					new SqlParameter("@proboxweight", SqlDbType.Decimal,9),
					new SqlParameter("@proboxlength", SqlDbType.NVarChar, 50),
					new SqlParameter("@proboxwidth", SqlDbType.NVarChar, 50),
					new SqlParameter("@proboxheight", SqlDbType.NVarChar, 50),
                    new SqlParameter("@color", SqlDbType.NVarChar,250),
                    new SqlParameter("@barcode", SqlDbType.NVarChar,50),
                    new SqlParameter("@createtime", SqlDbType.DateTime),
                    new SqlParameter("@ShipFrom_ID", SqlDbType.Int),
                    new SqlParameter("@ShipPartner_ID", SqlDbType.Int),
                    new SqlParameter("@ProductUploadBatchNo", SqlDbType.Int),
                    new SqlParameter("@SupplierShipFee", SqlDbType.Decimal),
                    new SqlParameter("@IsCustomerFreeShip", SqlDbType.TinyInt),
					new SqlParameter("@packageweight", SqlDbType.NVarChar,50),
					new SqlParameter("@packagelength", SqlDbType.NVarChar,50),
					new SqlParameter("@packagewidth", SqlDbType.NVarChar,50),
					new SqlParameter("@packageheight", SqlDbType.NVarChar,50),
					new SqlParameter("@wholesaleprice", SqlDbType.NVarChar,50),
					new SqlParameter("@SupplierShipMethodName", SqlDbType.NVarChar,50)
                                        };
            parameters[0].Value = model.proid;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.proruletitle;
            parameters[3].Value = model.prorule;
            parameters[4].Value = model.prostock;
            parameters[5].Value = model.prosku;
            parameters[6].Value = model.suppliersku;
            parameters[7].Value = model.probulk;
            parameters[8].Value = model.proweight;
            parameters[9].Value = model.prolength;
            parameters[10].Value = model.prowidth;
            parameters[11].Value = model.proheight;
            parameters[12].Value = model.probox;
            parameters[13].Value = model.prosize;
            parameters[14].Value = model.proboxweight;
            parameters[15].Value = model.proboxlength;
            parameters[16].Value = model.proboxwidth;
            parameters[17].Value = model.proboxheight;
            parameters[18].Value = model.procolor;
            parameters[19].Value = model.barcode;
            parameters[20].Value = System.DateTime.Now;
            parameters[21].Value = model.ShipFrom_ID;
            parameters[22].Value = model.ShipPartner_ID;
            if (model.UpLoadBatchNo == -1) model.UpLoadBatchNo = -1;
            parameters[23].Value = model.UpLoadBatchNo;
            parameters[24].Value = model.SupplierShipFee;
            parameters[25].Value = model.isCustomerFreeShip;
            parameters[26].Value = model.packageweight;
            parameters[27].Value = model.packagelength;
            parameters[28].Value = model.packagewidth;
            parameters[29].Value = model.packageheight;
            parameters[30].Value = model.WholeSalePrice;
            parameters[31].Value = model.SupplierShipMethodName;

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
        public bool Update(Twee.Model.proRules model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_proRules set ");
            strSql.Append("proid=@proid,");
            strSql.Append("userid=@userid,");
            strSql.Append("proruletitle=@proruletitle,");
            strSql.Append("prorule=@prorule,");
            strSql.Append("prostock=@prostock,");
            strSql.Append("prosku=@prosku,");
            strSql.Append("probulk=@probulk,");
            strSql.Append("proweight=@proweight,");
            strSql.Append("probox=@probox,");
            strSql.Append("prosize=@prosize,");
            strSql.Append("proboxweight=@proboxweight,");
            strSql.Append("color=@color, ");
            strSql.Append("barcode=@barcode ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@proid", SqlDbType.NVarChar,50),
					new SqlParameter("@userid", SqlDbType.NVarChar,50),
					new SqlParameter("@proruletitle", SqlDbType.Int,4),
					new SqlParameter("@prorule", SqlDbType.NVarChar,50),
					new SqlParameter("@prostock", SqlDbType.NVarChar,50),
					new SqlParameter("@prosku", SqlDbType.NVarChar,50),
					new SqlParameter("@probulk", SqlDbType.NVarChar,50),
					new SqlParameter("@proweight", SqlDbType.NVarChar,50),
					new SqlParameter("@probox", SqlDbType.NVarChar,50),
					new SqlParameter("@prosize", SqlDbType.NVarChar,50),
					new SqlParameter("@proboxweight", SqlDbType.Decimal,9),
                    new SqlParameter("@color", SqlDbType.NVarChar,250),
                    new SqlParameter("@barcode", SqlDbType.NVarChar,50),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.proid;
            parameters[1].Value = model.userid;
            parameters[2].Value = model.proruletitle;
            parameters[3].Value = model.prorule;
            parameters[4].Value = model.prostock;
            parameters[5].Value = model.prosku;
            parameters[6].Value = model.probulk;
            parameters[7].Value = model.proweight;
            parameters[8].Value = model.probox;
            parameters[9].Value = model.prosize;
            parameters[10].Value = model.proboxweight;
            parameters[11].Value = model.procolor;
            parameters[12].Value = model.barcode;
            parameters[13].Value = model.id;

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
            strSql.Append("delete from wn_proRules ");
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
            strSql.Append("delete from wn_proRules ");
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
        public Twee.Model.proRules GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,proid,userid,proruletitle,prorule,prostock,prosku,probulk,proweight,probox,prosize,proboxweight,color,barcode,createtime, SupplierShipMethodName from wn_proRules ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Twee.Model.proRules model = new Twee.Model.proRules();
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
        public Twee.Model.proRules DataRowToModel(DataRow row)
        {
            Twee.Model.proRules model = new Twee.Model.proRules();
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
                if (row["userid"] != null && row["userid"].ToString() != "")
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["proruletitle"] != null && row["proruletitle"].ToString() != "")
                {
                    model.proruletitle = int.Parse(row["proruletitle"].ToString());
                }
                if (row["prorule"] != null)
                {
                    model.prorule = row["prorule"].ToString();
                }
                if (row["prostock"] != null)
                {
                    model.prostock = row["prostock"].ToString();
                }
                if (row["prosku"] != null)
                {
                    model.prosku = row["prosku"].ToString();
                }
                if (row["probulk"] != null && row["probulk"].ToString() != "")
                {
                    model.probulk = row["probulk"].ToString();
                }
                if (row["proweight"] != null && row["proweight"].ToString() != "")
                {
                    model.proweight =row["proweight"].ToString();
                }
                if (row["probox"] != null && row["probox"].ToString() != "")
                {
                    model.probox = row["probox"].ToString();
                }
                if (row["prosize"] != null && row["prosize"].ToString() != "")
                {
                    model.prosize = row["prosize"].ToString();
                }
                if (row["proboxweight"] != null && row["proboxweight"].ToString() != "")
                {
                    model.proboxweight = decimal.Parse(row["proboxweight"].ToString());
                }
                if (row["color"] != null && row["color"].ToString() != "")
                {
                    model.procolor = row["color"].ToString();
                }
                if (row["barcode"] != null && row["barcode"].ToString() != "")
                {
                    model.barcode = row["barcode"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime =Convert.ToDateTime(row["createtime"].ToString());
                }
                if (row["SupplierShipMethodName"] != null && row["SupplierShipMethodName"].ToString() != "")
                {
                    model.SupplierShipMethodName = row["SupplierShipMethodName"].ToString();
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
            strSql.Append("select id,proid,userid,proruletitle,prorule,prostock,prosku,probulk,proweight,probox,prosize,proboxweight,color,barcode,createtime, SupplierShipMethodName ");
            strSql.Append(" FROM wn_proRules ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<Twee.Model.proRules> GetEntityList(string where) {
            List<Twee.Model.proRules> list = new List<Model.proRules>();
            DataTable dt = GetList(where).Tables[0];
            foreach (DataRow row in dt.Rows) {
                list.Add(DataRowToModel(row));
            }
            return list;

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
            strSql.Append(" id,proid,userid,proruletitle,prorule,prostock,prosku,probulk,proweight,probox,prosize,proboxweight,color,barcode,createtime ");
            strSql.Append(" FROM wn_proRules ");
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
            strSql.Append("select count(1) FROM wn_proRules ");
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
            strSql.Append(")AS Row, T.*  from wn_proRules T ");
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
            parameters[0].Value = "wn_proRules";
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

        public int ExecuteSql(string sql) {
            return DbHelperSQL.ExecuteSql(sql);
        }

        public DataTable GetPassedRuleByProId(string proid)
        {
            if (string.IsNullOrEmpty(proid))
                return null;
            DataTable dt = new DataTable();
            string sql = "";
            return dt;
        }

        /// <summary>
        /// 根据userid和prdid 获取某产品的所有规格
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="prdid"></param>
        /// <returns></returns>
        public DataTable GetPrdRules(string userid, string prdid)
        {
            //string strSql = " select * from wn_proRules where proid='" + userid + "' and userid='" + prdid + "'";

            string strSql = " select prosku sku_id, prorule sku_name,sku_img_url='',length='',width='',height='', barcode product_code,Product_Stock_Type='s',is_kit='',category='', flammable='',explosive='',liquid='0',unit_weight='',unit_sell_price='',unit_discount_price='',unit_cost='',unit_purchase_cost='',has_barcode='1' from wn_proRules where proid='" + prdid + "' and userid='" + userid + "'";            
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        #endregion  ExtensionMethod

        #region backend
        /// <summary>
        /// delete a rule and related data
        /// </summary>
        /// <param name="ruleid"></param>
        /// <returns></returns>
        public bool MgeDelete(int iRuleID, out string sErrMsg)
        {
            
            sErrMsg = string.Empty;

            string sPrdGuid = string.Empty;
            string sSupplierUserGuid = string.Empty;

            try
            {
                DB db = new DB();
                db.DBConnect();

                // get prdGuid of this product
                string sSql = "select proid, userid from wn_prorules where id=" + iRuleID.ToString();
                DataSet ds = db.DBQuery(sSql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        sPrdGuid = dr["proid"]._ObjToString();
                        sSupplierUserGuid = dr["userid"]._ObjToString();
                    }
                }
                if (sPrdGuid == string.Empty || sSupplierUserGuid == string.Empty)
                {
                    // the rule does not existed, usually this will not happen
                    db.DBDisconnect();
                    return true;  // take this as normal
                }

                // begin transaction
                db.DBBeginTrans();


                // delete from wn_prorules
                sSql = "delete from wn_prorules where id=" + iRuleID.ToString();
                int iAffectedCnt = db.DBExecute(sSql);

                // delete wn_prdPrice
                sSql = "delete from wn_prdPrice where ruleid=" + iRuleID.ToString();
                iAffectedCnt = db.DBExecute(sSql);


                // delete wn_prodetails if all all rules are deleted for this supplier
                sSql = "select count(*) from wn_proRules where proid='" + sPrdGuid + "' and userid='" + sSupplierUserGuid + "'";
                int iCnt = db.DBQueryCount(sSql);
                if (iCnt == 0)
                {
                    sSql = "delete from wn_proDetails where proid='" + sPrdGuid + "' and userid='" + sSupplierUserGuid + "'";
                    iAffectedCnt = db.DBExecute(sSql);
                }

                db.DBCommitTrans();
                db.DBDisconnect();

                return true;
            }
            catch (Exception ex) {
                //CommUtil.GenernalErrorHandlerEx(ex, "Backend Delete Product Rule Error!" + iRuleID.ToString());
                sErrMsg = ex.Message;
                return false;
            }
        }
       
        /// <summary>
        /// Get Rule Info
        /// </summary>
        /// <param name="ruleid"></param>
        /// <returns>Rule Info</returns>
        public DataTable MgeGetRuleInfo(string sPrdGuid, string sTweebaaSKU)
        {
            string sSql = "select * from wn_proRules where proid='" + sPrdGuid + "' and prosku='" + CommUtil.Quo(sTweebaaSKU) + "'";
            DataSet ds = DbHelperSQL.Query(sSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        #endregion backend

    }
}

