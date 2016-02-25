using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Twee.Comm;
using System.Data;
using Twee.Model;

namespace Twee.DataMgr
{
    public class UserAddressDataMgr
    {
        public UserAddressDataMgr()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Guid guid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from wn_useraddress");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = guid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        public void AddZip2City(string strZip, string strCity, string strState, string strCountry)
        {
            string strSql = "insert into wn_Zip2City(ZipCode,CityName,State,Country) values('";
            strSql += Twee.Comm.CommUtil.Quo(strZip) + "','";
            strSql += Twee.Comm.CommUtil.Quo(strCity) + "','";
            strSql += Twee.Comm.CommUtil.Quo(strState) + "','";
            strSql += Twee.Comm.CommUtil.Quo(strCountry) + "')";
            DbHelperSQL.ExecuteSql(strSql);
        }

        public DataSet GetCityByZipcode(string strZip)
        {
            string strSql = "select * from wn_Zip2City where ZipCode=N'" + Twee.Comm.CommUtil.Quo(strZip) + "'";
            DataSet ds = DbHelperSQL.Query(strSql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Useraddress model)
		{
			StringBuilder strSql=new StringBuilder();
            if (model.isfirst==1)
            {
                strSql.Append(string.Format("update wn_useraddress  set isfirst={0} where userguid='{1}';", 0, model.userguid));
            }
			strSql.Append("insert into wn_useraddress(");
            strSql.Append("guid,prtguid,provinceid,cityid,city,countyid,zip,address,address2,username,lastName,phone,tel,isfirst,addtime,userguid,email)");
			strSql.Append(" values (");
            strSql.Append("@guid,@prtguid,@provinceid,@cityid,@city,@countyid,@zip,@address,@address2,@username,@lastName,@phone,@tel,@isfirst,@addtime,@userguid,@email)");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@provinceid", SqlDbType.Int,4),
					new SqlParameter("@cityid", SqlDbType.Int,4),                  
					new SqlParameter("@countyid", SqlDbType.Int,4),
					new SqlParameter("@zip", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,150),
                   	new SqlParameter("@username", SqlDbType.NVarChar,50),                  
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@tel", SqlDbType.NVarChar,50),
					new SqlParameter("@isfirst", SqlDbType.TinyInt,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
                    new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@city", SqlDbType.NVarChar,50),   
                    new SqlParameter("@address2", SqlDbType.NVarChar,150),
                    new SqlParameter("@lastName", SqlDbType.NVarChar,50),
                    new SqlParameter("@email", SqlDbType.NVarChar,100)};
			parameters[0].Value = Guid.NewGuid();
			parameters[1].Value = null;
			parameters[2].Value = model.provinceid;
			parameters[3].Value = model.cityid;        
			parameters[4].Value = model.countyid;
			parameters[5].Value = model.zip;
			parameters[6].Value = model.address;
			parameters[7].Value = model.username;
			parameters[8].Value = model.phone;
			parameters[9].Value = model.tel;
			parameters[10].Value = model.isfirst;
			parameters[11].Value = model.addtime;
            parameters[12].Value = model.userguid;
            parameters[13].Value = model.city;
            parameters[14].Value = model.address2;
            parameters[15].Value = model.lastName;
            parameters[16].Value = model.email;

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
        /// 增加一条数据
        /// </summary>
        public bool Add(Useraddress model,out string addressGuid)
        {
            addressGuid = "";
            StringBuilder strSql = new StringBuilder();
            if (model.isfirst == 1)
            {
                strSql.Append(string.Format("update wn_useraddress  set isfirst={0} where userguid='{1}';", 0, model.userguid));
            }
            else 
            {
                // check if this user has any default address
                // set this as default if there is no any default address
                bool bHasDefault = false;
                strSql.Append("select count(*) from wn_useraddress where userguid='" + model.userguid + "' and isfirst = 1");
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                if ( ds != null && ds.Tables.Count > 0 ) {
                    DataTable dt = ds.Tables[0];
                    if ( dt != null && dt.Rows.Count > 0 ) {
                        DataRow dr = dt.Rows[0];
                        if (dr[0].ToString().ToInt() > 0 )  bHasDefault = true;  
                    }
                }
                if ( !bHasDefault) model.isfirst = 1;
                strSql.Clear();
            }
            strSql.Append("insert into wn_useraddress(");
            strSql.Append("guid,prtguid,provinceid,cityid,city,countyid,zip,address,address2,username,lastName,phone,tel,isfirst,addtime,userguid,email)");
            strSql.Append(" values (");
            strSql.Append("@guid,@prtguid,@provinceid,@cityid,@city,@countyid,@zip,@address,@address2,@username,@lastName,@phone,@tel,@isfirst,@addtime,@userguid,@email)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@provinceid", SqlDbType.Int,4),
					new SqlParameter("@cityid", SqlDbType.Int,4),                  
					new SqlParameter("@countyid", SqlDbType.Int,4),
					new SqlParameter("@zip", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,150),
                   	new SqlParameter("@username", SqlDbType.NVarChar,50),                  
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@tel", SqlDbType.NVarChar,50),
					new SqlParameter("@isfirst", SqlDbType.TinyInt,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
                    new SqlParameter("@userguid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@city", SqlDbType.NVarChar,50),   
                    new SqlParameter("@address2", SqlDbType.NVarChar,150),
                    new SqlParameter("@lastName", SqlDbType.NVarChar,50),
                    new SqlParameter("@email", SqlDbType.NVarChar,100)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = null;
            parameters[2].Value = model.provinceid;
            parameters[3].Value = model.cityid;
            parameters[4].Value = model.countyid;
            parameters[5].Value = model.zip;
            parameters[6].Value = model.address;
            parameters[7].Value = model.username;
            parameters[8].Value = model.phone;
            parameters[9].Value = model.tel;
            parameters[10].Value = model.isfirst;
            parameters[11].Value = model.addtime;
            parameters[12].Value = model.userguid;
            parameters[13].Value = model.city;
            parameters[14].Value = model.address2;
            parameters[15].Value = model.lastName;
            parameters[16].Value = model.email;         
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                addressGuid = parameters[0].Value.ToString();
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
		public bool Update(Useraddress model)
		{
			StringBuilder strSql=new StringBuilder();
            if (model.isfirst == 1)
            {
                strSql.Append(string.Format("update wn_useraddress  set isfirst={0} where userguid='{1}';", 0, model.userguid));
            }
            else
            {
                // check if this user has any default address except this address
                // set this as default if there is no any other default address
                bool bHasDefault = false;
                strSql.Append("select count(*) from wn_useraddress where userguid='" + model.userguid + "' and isfirst = 1 and guid<>'" + model.guid + "'");
                DataSet ds = DbHelperSQL.Query(strSql.ToString());
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        if (dr[0].ToString().ToInt() > 0) bHasDefault = true;
                    }
                }
                if (!bHasDefault) model.isfirst = 1;
                strSql.Clear();
            }
			strSql.Append("update wn_useraddress set ");
			strSql.Append("prtguid=@prtguid,");
			strSql.Append("provinceid=@provinceid,");
			strSql.Append("cityid=@cityid,");
			strSql.Append("countyid=@countyid,");
			strSql.Append("zip=@zip,");
			strSql.Append("address=@address,");
			strSql.Append("username=@username,");
			strSql.Append("phone=@phone,");
			strSql.Append("tel=@tel,");
			strSql.Append("isfirst=@isfirst,");
			strSql.Append("addtime=@addtime,");
            strSql.Append("city=@city,");
            strSql.Append("address2=@address2,");
            strSql.Append("lastName=@lastName,");
            strSql.Append("email=@email");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@prtguid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@provinceid", SqlDbType.Int,4),
					new SqlParameter("@cityid", SqlDbType.Int,4),
					new SqlParameter("@countyid", SqlDbType.Int,4),
					new SqlParameter("@zip", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,150),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@tel", SqlDbType.NVarChar,50),
					new SqlParameter("@isfirst", SqlDbType.TinyInt,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@city", SqlDbType.NVarChar,50),   
                    new SqlParameter("@address2", SqlDbType.NVarChar,150),
                    new SqlParameter("@lastName", SqlDbType.NVarChar,50),
                    new SqlParameter("@email", SqlDbType.NVarChar,100)};
			parameters[0].Value = model.prtguid;
			parameters[1].Value = model.provinceid;
			parameters[2].Value = model.cityid;
			parameters[3].Value = model.countyid;
			parameters[4].Value = model.zip;
			parameters[5].Value = model.address;
			parameters[6].Value = model.username;
			parameters[7].Value = model.phone;
			parameters[8].Value = model.tel;
			parameters[9].Value = model.isfirst;
			parameters[10].Value = model.addtime;
			parameters[11].Value = model.guid;

            parameters[12].Value = model.city;
            parameters[13].Value = model.address2;
            parameters[14].Value = model.lastName;
            parameters[15].Value = model.email;
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
		public bool Delete(Guid guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_useraddress ");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = guid;

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
		public bool DeleteList(string guidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wn_useraddress ");
			strSql.Append(" where guid in ("+guidlist + ")  ");
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
		public Useraddress GetModel(Guid guid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 guid,prtguid,provinceid,cityid,countyid,zip,address,username,phone,tel,isfirst,addtime from wn_useraddress ");
			strSql.Append(" where guid=@guid ");
			SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
			parameters[0].Value = guid;

			Useraddress model=new Useraddress();
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
		public Useraddress DataRowToModel(DataRow row)
		{
			Useraddress model=new Useraddress();
			if (row != null)
			{
				if(row["guid"]!=null && row["guid"].ToString()!="")
				{
					model.guid= new Guid(row["guid"].ToString());
				}
				if(row["prtguid"]!=null && row["prtguid"].ToString()!="")
				{
					model.prtguid= new Guid(row["prtguid"].ToString());
				}
				if(row["provinceid"]!=null && row["provinceid"].ToString()!="")
				{
					model.provinceid=int.Parse(row["provinceid"].ToString());
				}
				if(row["cityid"]!=null && row["cityid"].ToString()!="")
				{
					model.cityid=int.Parse(row["cityid"].ToString());
				}
				if(row["countyid"]!=null && row["countyid"].ToString()!="")
				{
					model.countyid=int.Parse(row["countyid"].ToString());
				}
				if(row["zip"]!=null)
				{
					model.zip=row["zip"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["username"]!=null)
				{
					model.username=row["username"].ToString();
				}
				if(row["phone"]!=null)
				{
					model.phone=row["phone"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["isfirst"]!=null && row["isfirst"].ToString()!="")
				{
					model.isfirst=int.Parse(row["isfirst"].ToString());
				}
				if(row["addtime"]!=null && row["addtime"].ToString()!="")
				{
					model.addtime=DateTime.Parse(row["addtime"].ToString());
				}
                if (row.Table.Columns.Contains("proName"))
                {
                    if (row["proName"] != null && row["proName"].ToString() != "")
                    {
                        model.proName = row["proName"].ToString();
                    }
                }
                if (row.Table.Columns.Contains("city"))
                {
                    if (row["city"] != null && row["city"].ToString() != "")
                    {
                        model.city = row["city"].ToString();
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
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select guid,prtguid,provinceid,u.cityid,countyid,zip,address,username,lastName,email,phone,tel,isfirst,addtime,p.ProName,city ");
			strSql.Append(" FROM wn_useraddress u ");
            strSql.Append(" left join wn_Province p on  u.provinceid=p.ProID  ");
            //strSql.Append(" left join wn_City c on u.cityid=c.CityID ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            strSql.Append(" order by isfirst desc " );
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
			strSql.Append(" guid,prtguid,provinceid,cityid,countyid,zip,address,username,phone,tel,isfirst,addtime ");
			strSql.Append(" FROM wn_useraddress ");
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
			strSql.Append("select count(1) FROM wn_useraddress ");
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
				strSql.Append("order by T.guid desc");
			}
			strSql.Append(")AS Row, T.*  from wn_useraddress T ");
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
			parameters[0].Value = "wn_useraddress";
			parameters[1].Value = "guid";
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
        /// 获得我的收货地址
        /// </summary>
        public DataTable GetMyAddress(Guid userGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select u.guid,prtguid,provinceid,u.cityid,countyid,zip,address,address2,u.username,lastName,u.phone,u.email as ua_email,tel,isfirst,addtime,p.ProName,city ,users.email,c.country  ");
            strSql.Append(" FROM wn_useraddress u ");
            strSql.Append(" left join wn_Province p on  u.provinceid=p.ProID  ");
            strSql.Append(" left join  wn_user users on  u.userguid=users.guid ");
            strSql.Append(" left join wn_country c on c.id=u.countyid "); 
            //strSql.Append(" left join wn_City c on u.cityid=c.CityID ");
            strSql.Append(string.Format(" where u.userguid='{0}'", userGuid));
            strSql.Append(" order by isfirst desc");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("select guid,prtguid,userguid,username,lastName,provinceid,cityid,city,p.name,countyid,country,zip,address,address2,phone,tel,isfirst,addtime,user.email ");
            //strSql.Append(" FROM wn_useraddress u");
            //strSql.Append(" left join ( select name from  dbo.wn_Area where id=u.provinceid) p ");
            ////strSql.Append(" left join ( select name from  dbo.wn_Area where id=u.cityid) c ");   
            //strSql.Append(" left join  wn_country c on c.id=u.countyid  ");
            //strSql.Append(" left join  wn_user user on user.guid=u.userguid  ");   
            //strSql.Append(string.Format(" where u.userguid='{0}'",userGuid));           
            //DataSet ds = DbHelperSQL.Query(strSql.ToString());
            //if (ds!=null&&ds.Tables.Count>0)
            //{
            //    return ds.Tables[0];
            //}
            //return null;
        }

        /// <summary>
        /// 获得我的收货地址(根据记录guid)
        /// </summary>
        public DataTable GetAddressByGuid(string guid)
        {
            if (guid.Length < 20) return null; //why guid not correct?
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select u.guid,prtguid,provinceid,u.cityid,countyid,zip,address,address2,u.username,lastName,u.phone,tel,isfirst,addtime,p.ProName,city ,users.email,c.country ,u.email as guest_e_mail ");
            strSql.Append(" FROM wn_useraddress u ");
            strSql.Append(" left join wn_Province p on  u.provinceid=p.ProID  ");
            strSql.Append(" left join  wn_user users on  u.userguid=users.guid ");
            strSql.Append(" left join wn_country c on c.id=u.countyid ");
            //strSql.Append(" left join wn_City c on u.cityid=c.CityID ");
            strSql.Append(string.Format(" where u.guid='{0}'", guid));

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;             
        }

        /// <summary>
        /// 设置默认地址
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool SetDefault(Guid guid,Guid userGuid)
        {
            string strSql = string.Format("update wn_useraddress set isfirst=0 where userguid='{0}';update wn_useraddress  set isfirst={1} where guid='{2}'",userGuid, 1, guid);
            int rows = DbHelperSQL.ExecuteSql(strSql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }       
        
        }
		#endregion  ExtensionMethod
    }
}
