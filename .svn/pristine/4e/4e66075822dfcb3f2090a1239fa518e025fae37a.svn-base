using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;

namespace Twee.DataMgr
{
	/// <summary>
	/// 采购单
	/// </summary>
	public partial class PurchaseOrderDataMgr
	{
        public PurchaseOrderDataMgr()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Twee.Model.PurchaseOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wn_PurchaseOrder(");
			strSql.Append("productId,product_code,stock_id,owner_id,purchase_no,transporter_id,out_sid,supplier_id,create_date,plan_ship_date,plan_arrival_date,arrival_date,remark,audit_date,qty,unit_purchase_cost,state,txt1,txt2,txt3,txt4,txt5,txt6,txt7,txt8,txt9,txt10)");
			strSql.Append(" values (");
			strSql.Append("@productId,@product_code,@stock_id,@owner_id,@purchase_no,@transporter_id,@out_sid,@supplier_id,@create_date,@plan_ship_date,@plan_arrival_date,@arrival_date,@remark,@audit_date,@qty,@unit_purchase_cost,@state,@txt1,@txt2,@txt3,@txt4,@txt5,@txt6,@txt7,@txt8,@txt9,@txt10)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@product_code", SqlDbType.NVarChar,50),
					new SqlParameter("@stock_id", SqlDbType.NVarChar,50),
					new SqlParameter("@owner_id", SqlDbType.NVarChar,50),
					new SqlParameter("@purchase_no", SqlDbType.NVarChar,50),
					new SqlParameter("@transporter_id", SqlDbType.NVarChar,50),
					new SqlParameter("@out_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@supplier_id", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@plan_ship_date", SqlDbType.DateTime),
					new SqlParameter("@plan_arrival_date", SqlDbType.DateTime),
					new SqlParameter("@arrival_date", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@audit_date", SqlDbType.DateTime),
					new SqlParameter("@qty", SqlDbType.Int,4),
					new SqlParameter("@unit_purchase_cost", SqlDbType.Decimal,9),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@txt1", SqlDbType.NVarChar,50),
					new SqlParameter("@txt2", SqlDbType.NVarChar,50),
					new SqlParameter("@txt3", SqlDbType.NVarChar,50),
					new SqlParameter("@txt4", SqlDbType.NVarChar,50),
					new SqlParameter("@txt5", SqlDbType.NVarChar,50),
					new SqlParameter("@txt6", SqlDbType.NVarChar,50),
					new SqlParameter("@txt7", SqlDbType.NVarChar,50),
					new SqlParameter("@txt8", SqlDbType.NVarChar,50),
					new SqlParameter("@txt9", SqlDbType.NVarChar,50),
					new SqlParameter("@txt10", SqlDbType.NVarChar,50)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = model.product_code;
			parameters[2].Value = model.stock_id;
			parameters[3].Value = model.owner_id;
			parameters[4].Value = model.purchase_no;
			parameters[5].Value = model.transporter_id;
			parameters[6].Value = model.out_sid;
			parameters[7].Value = model.supplier_id;
			parameters[8].Value = model.create_date;
			parameters[9].Value = model.plan_ship_date;
			parameters[10].Value = model.plan_arrival_date;
			parameters[11].Value = model.arrival_date;
			parameters[12].Value = model.remark;
			parameters[13].Value = model.audit_date;
			parameters[14].Value = model.qty;
			parameters[15].Value = model.unit_purchase_cost;
			parameters[16].Value = model.state;
			parameters[17].Value = model.txt1;
			parameters[18].Value = model.txt2;
			parameters[19].Value = model.txt3;
			parameters[20].Value = model.txt4;
			parameters[21].Value = model.txt5;
			parameters[22].Value = model.txt6;
			parameters[23].Value = model.txt7;
			parameters[24].Value = model.txt8;
			parameters[25].Value = model.txt9;
			parameters[26].Value = model.txt10;

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
		public bool Update(Twee.Model.PurchaseOrder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wn_PurchaseOrder set ");
			strSql.Append("productId=@productId,");
			strSql.Append("product_code=@product_code,");
			strSql.Append("stock_id=@stock_id,");
			strSql.Append("owner_id=@owner_id,");
			strSql.Append("purchase_no=@purchase_no,");
			strSql.Append("transporter_id=@transporter_id,");
			strSql.Append("out_sid=@out_sid,");
			strSql.Append("supplier_id=@supplier_id,");
			strSql.Append("create_date=@create_date,");
			strSql.Append("plan_ship_date=@plan_ship_date,");
			strSql.Append("plan_arrival_date=@plan_arrival_date,");
			strSql.Append("arrival_date=@arrival_date,");
			strSql.Append("remark=@remark,");
			strSql.Append("audit_date=@audit_date,");
			strSql.Append("qty=@qty,");
			strSql.Append("unit_purchase_cost=@unit_purchase_cost,");
			strSql.Append("state=@state,");
			strSql.Append("txt1=@txt1,");
			strSql.Append("txt2=@txt2,");
			strSql.Append("txt3=@txt3,");
			strSql.Append("txt4=@txt4,");
			strSql.Append("txt5=@txt5,");
			strSql.Append("txt6=@txt6,");
			strSql.Append("txt7=@txt7,");
			strSql.Append("txt8=@txt8,");
			strSql.Append("txt9=@txt9,");
			strSql.Append("txt10=@txt10");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@productId", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@product_code", SqlDbType.NVarChar,50),
					new SqlParameter("@stock_id", SqlDbType.NVarChar,50),
					new SqlParameter("@owner_id", SqlDbType.NVarChar,50),
					new SqlParameter("@purchase_no", SqlDbType.NVarChar,50),
					new SqlParameter("@transporter_id", SqlDbType.NVarChar,50),
					new SqlParameter("@out_sid", SqlDbType.NVarChar,50),
					new SqlParameter("@supplier_id", SqlDbType.NVarChar,50),
					new SqlParameter("@create_date", SqlDbType.DateTime),
					new SqlParameter("@plan_ship_date", SqlDbType.DateTime),
					new SqlParameter("@plan_arrival_date", SqlDbType.DateTime),
					new SqlParameter("@arrival_date", SqlDbType.DateTime),
					new SqlParameter("@remark", SqlDbType.NVarChar,500),
					new SqlParameter("@audit_date", SqlDbType.DateTime),
					new SqlParameter("@qty", SqlDbType.Int,4),
					new SqlParameter("@unit_purchase_cost", SqlDbType.Decimal,9),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@txt1", SqlDbType.NVarChar,50),
					new SqlParameter("@txt2", SqlDbType.NVarChar,50),
					new SqlParameter("@txt3", SqlDbType.NVarChar,50),
					new SqlParameter("@txt4", SqlDbType.NVarChar,50),
					new SqlParameter("@txt5", SqlDbType.NVarChar,50),
					new SqlParameter("@txt6", SqlDbType.NVarChar,50),
					new SqlParameter("@txt7", SqlDbType.NVarChar,50),
					new SqlParameter("@txt8", SqlDbType.NVarChar,50),
					new SqlParameter("@txt9", SqlDbType.NVarChar,50),
					new SqlParameter("@txt10", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.productId;
			parameters[1].Value = model.product_code;
			parameters[2].Value = model.stock_id;
			parameters[3].Value = model.owner_id;
			parameters[4].Value = model.purchase_no;
			parameters[5].Value = model.transporter_id;
			parameters[6].Value = model.out_sid;
			parameters[7].Value = model.supplier_id;
			parameters[8].Value = model.create_date;
			parameters[9].Value = model.plan_ship_date;
			parameters[10].Value = model.plan_arrival_date;
			parameters[11].Value = model.arrival_date;
			parameters[12].Value = model.remark;
			parameters[13].Value = model.audit_date;
			parameters[14].Value = model.qty;
			parameters[15].Value = model.unit_purchase_cost;
			parameters[16].Value = model.state;
			parameters[17].Value = model.txt1;
			parameters[18].Value = model.txt2;
			parameters[19].Value = model.txt3;
			parameters[20].Value = model.txt4;
			parameters[21].Value = model.txt5;
			parameters[22].Value = model.txt6;
			parameters[23].Value = model.txt7;
			parameters[24].Value = model.txt8;
			parameters[25].Value = model.txt9;
			parameters[26].Value = model.txt10;
			parameters[27].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_PurchaseOrder ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_PurchaseOrder ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public Twee.Model.PurchaseOrder GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,productId,product_code,stock_id,owner_id,purchase_no,transporter_id,out_sid,supplier_id,create_date,plan_ship_date,plan_arrival_date,arrival_date,remark,audit_date,qty,unit_purchase_cost,state,txt1,txt2,txt3,txt4,txt5,txt6,txt7,txt8,txt9,txt10 from wn_PurchaseOrder ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Twee.Model.PurchaseOrder model=new Twee.Model.PurchaseOrder();
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
		public Twee.Model.PurchaseOrder DataRowToModel(DataRow row)
		{
			Twee.Model.PurchaseOrder model=new Twee.Model.PurchaseOrder();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["productId"]!=null && row["productId"].ToString()!="")
				{
					model.productId= new Guid(row["productId"].ToString());
				}
				if(row["product_code"]!=null)
				{
					model.product_code=row["product_code"].ToString();
				}
				if(row["stock_id"]!=null)
				{
					model.stock_id=row["stock_id"].ToString();
				}
				if(row["owner_id"]!=null)
				{
					model.owner_id=row["owner_id"].ToString();
				}
				if(row["purchase_no"]!=null)
				{
					model.purchase_no=row["purchase_no"].ToString();
				}
				if(row["transporter_id"]!=null)
				{
					model.transporter_id=row["transporter_id"].ToString();
				}
				if(row["out_sid"]!=null)
				{
					model.out_sid=row["out_sid"].ToString();
				}
				if(row["supplier_id"]!=null)
				{
					model.supplier_id=row["supplier_id"].ToString();
				}
				if(row["create_date"]!=null && row["create_date"].ToString()!="")
				{
					model.create_date=DateTime.Parse(row["create_date"].ToString());
				}
				if(row["plan_ship_date"]!=null && row["plan_ship_date"].ToString()!="")
				{
					model.plan_ship_date=DateTime.Parse(row["plan_ship_date"].ToString());
				}
				if(row["plan_arrival_date"]!=null && row["plan_arrival_date"].ToString()!="")
				{
					model.plan_arrival_date=DateTime.Parse(row["plan_arrival_date"].ToString());
				}
				if(row["arrival_date"]!=null && row["arrival_date"].ToString()!="")
				{
					model.arrival_date=DateTime.Parse(row["arrival_date"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["audit_date"]!=null && row["audit_date"].ToString()!="")
				{
					model.audit_date=DateTime.Parse(row["audit_date"].ToString());
				}
				if(row["qty"]!=null && row["qty"].ToString()!="")
				{
					model.qty=int.Parse(row["qty"].ToString());
				}
				if(row["unit_purchase_cost"]!=null && row["unit_purchase_cost"].ToString()!="")
				{
					model.unit_purchase_cost=decimal.Parse(row["unit_purchase_cost"].ToString());
				}
				if(row["state"]!=null && row["state"].ToString()!="")
				{
					model.state=int.Parse(row["state"].ToString());
				}
				if(row["txt1"]!=null)
				{
					model.txt1=row["txt1"].ToString();
				}
				if(row["txt2"]!=null)
				{
					model.txt2=row["txt2"].ToString();
				}
				if(row["txt3"]!=null)
				{
					model.txt3=row["txt3"].ToString();
				}
				if(row["txt4"]!=null)
				{
					model.txt4=row["txt4"].ToString();
				}
				if(row["txt5"]!=null)
				{
					model.txt5=row["txt5"].ToString();
				}
				if(row["txt6"]!=null)
				{
					model.txt6=row["txt6"].ToString();
				}
				if(row["txt7"]!=null)
				{
					model.txt7=row["txt7"].ToString();
				}
				if(row["txt8"]!=null)
				{
					model.txt8=row["txt8"].ToString();
				}
				if(row["txt9"]!=null)
				{
					model.txt9=row["txt9"].ToString();
				}
				if(row["txt10"]!=null)
				{
					model.txt10=row["txt10"].ToString();
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
			strSql.Append("select ID,productId,product_code,stock_id,owner_id,purchase_no,transporter_id,out_sid,supplier_id,create_date,plan_ship_date,plan_arrival_date,arrival_date,remark,audit_date,qty,unit_purchase_cost,state,txt1,txt2,txt3,txt4,txt5,txt6,txt7,txt8,txt9,txt10 ");
			strSql.Append(" FROM wn_PurchaseOrder ");
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
			strSql.Append(" ID,productId,product_code,stock_id,owner_id,purchase_no,transporter_id,out_sid,supplier_id,create_date,plan_ship_date,plan_arrival_date,arrival_date,remark,audit_date,qty,unit_purchase_cost,state,txt1,txt2,txt3,txt4,txt5,txt6,txt7,txt8,txt9,txt10 ");
			strSql.Append(" FROM wn_PurchaseOrder ");
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
			strSql.Append("select count(1) FROM wn_PurchaseOrder ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from wn_PurchaseOrder T ");
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
			parameters[0].Value = "wn_PurchaseOrder";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

