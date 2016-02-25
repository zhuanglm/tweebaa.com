using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Twee.Comm;
using Twee.Model;

namespace Twee.DataMgr
{
    public class UserDataMgr
    {
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(Guid guid, string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_user");
            strSql.Append(" where guid=@guid and email=@email ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@email", SqlDbType.NVarChar,50)			};
            parameters[0].Value = guid;
            parameters[1].Value = email;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Twee.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wn_user(");
            strSql.Append("guid,pwd,username,gender,birthday,regtime,acttime,edttime,wnstat,email,phone,paymentno,pwdstrength,headimg,jobid)");
            strSql.Append(" values (");
            strSql.Append("@guid,@pwd,@username,@gender,@birthday,@regtime,@acttime,@edttime,@wnstat,@email,@phone,@paymentno,@pwdstrength,@headimg,@jobid)");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@pwd", SqlDbType.NVarChar,32),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@gender", SqlDbType.TinyInt,1),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@acttime", SqlDbType.DateTime),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@wnstat", SqlDbType.Int,4),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@paymentno", SqlDbType.NVarChar,50),
					new SqlParameter("@pwdstrength", SqlDbType.TinyInt,1),
					new SqlParameter("@headimg", SqlDbType.NVarChar,150),
                    new SqlParameter("@jobid",SqlDbType.Int)};
            parameters[0].Value = Guid.NewGuid();
            parameters[1].Value = model.pwd;
            parameters[2].Value = model.username;
            parameters[3].Value = model.gender;
            parameters[4].Value = model.birthday;
            parameters[5].Value = model.regtime;
            parameters[6].Value = model.acttime;
            parameters[7].Value = model.edttime;
            parameters[8].Value = model.wnstat;
            parameters[9].Value = model.email;
            parameters[10].Value = model.phone;
            parameters[11].Value = model.paymentno;
            parameters[12].Value = model.pwdstrength;
            parameters[13].Value = model.headimg;
            parameters[14].Value = model.jobid;

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
        public bool Update(Twee.Model.User model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_user set ");
            strSql.Append("pwd=@pwd,");
            strSql.Append("username=@username,");
            strSql.Append("gender=@gender,");
            strSql.Append("birthday=@birthday,");
            strSql.Append("regtime=@regtime,");
            strSql.Append("acttime=@acttime,");
            strSql.Append("edttime=@edttime,");
            strSql.Append("wnstat=@wnstat,");
            strSql.Append("phone=@phone,");
            strSql.Append("paymentno=@paymentno,");
            strSql.Append("pwdstrength=@pwdstrength,");
            strSql.Append("headimg=@headimg,");
            strSql.Append("jobid=@jobid");
            strSql.Append(" where guid=@guid and email=@email ");
            SqlParameter[] parameters = {
					new SqlParameter("@pwd", SqlDbType.NVarChar,32),
					new SqlParameter("@username", SqlDbType.NVarChar,50),
					new SqlParameter("@gender", SqlDbType.TinyInt,1),
					new SqlParameter("@birthday", SqlDbType.DateTime),
					new SqlParameter("@regtime", SqlDbType.DateTime),
					new SqlParameter("@acttime", SqlDbType.DateTime),
					new SqlParameter("@edttime", SqlDbType.DateTime),
					new SqlParameter("@wnstat", SqlDbType.Int,4),
					new SqlParameter("@phone", SqlDbType.NVarChar,50),
					new SqlParameter("@paymentno", SqlDbType.NVarChar,50),
					new SqlParameter("@pwdstrength", SqlDbType.TinyInt,1),
					new SqlParameter("@headimg", SqlDbType.NVarChar,150),
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
                    new SqlParameter("@jobid",SqlDbType.Int)};
            parameters[0].Value = model.pwd;
            parameters[1].Value = model.username;
            parameters[2].Value = model.gender;
            parameters[3].Value = model.birthday;
            parameters[4].Value = model.regtime;
            parameters[5].Value = model.acttime;
            parameters[6].Value = model.edttime;
            parameters[7].Value = model.wnstat;
            parameters[8].Value = model.phone;
            parameters[9].Value = model.paymentno;
            parameters[10].Value = model.pwdstrength;
            parameters[11].Value = model.headimg;
            parameters[12].Value = model.guid;
            parameters[13].Value = model.email;
            parameters[14].Value = model.jobid;

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
        public bool Delete(Guid guid, string email)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_user ");
            strSql.Append(" where guid=@guid and email=@email ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@email", SqlDbType.NVarChar,50)			};
            parameters[0].Value = guid;
            parameters[1].Value = email;

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

        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_user ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)
						};
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
        /// 得到一个对象实体
        /// </summary>
        public Twee.Model.User GetModel(Guid guid, string email)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,pwd,username,gender,birthday,regtime,acttime,edttime,wnstat,email,phone,paymentno,pwdstrength,headimg,jobid from wn_user ");
            strSql.Append(" where (guid=@guid and email=@email) or (guid=@guid and phone=@email) ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
					new SqlParameter("@email", SqlDbType.NVarChar,50)			};
            parameters[0].Value = guid;
            parameters[1].Value = email;

            Twee.Model.User model = new Twee.Model.User();
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
        public Twee.Model.User GetModel(Guid guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 guid,pwd,username,gender,birthday,regtime,acttime,edttime,wnstat,email,phone,paymentno,pwdstrength,headimg,jobid from wn_user ");
            strSql.Append(" where guid=@guid  ");
            SqlParameter[] parameters = {
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),};
            parameters[0].Value = guid;

            Twee.Model.User model = new Twee.Model.User();
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
        public Twee.Model.User DataRowToModel(DataRow row)
        {
            Twee.Model.User model = new Twee.Model.User();
            if (row != null)
            {
                if (row["guid"] != null && row["guid"].ToString() != "")
                {
                    model.guid = new Guid(row["guid"].ToString());
                }
                if (row["pwd"] != null)
                {
                    model.pwd = row["pwd"].ToString();
                }
                if (row["username"] != null)
                {
                    model.username = row["username"].ToString();
                }
                if (row["gender"] != null && row["gender"].ToString() != "")
                {
                    model.gender = int.Parse(row["gender"].ToString());
                }
                if (row["birthday"] != null && row["birthday"].ToString() != "")
                {
                    model.birthday = DateTime.Parse(row["birthday"].ToString());
                }
                if (row["regtime"] != null && row["regtime"].ToString() != "")
                {
                    model.regtime = DateTime.Parse(row["regtime"].ToString());
                }
                if (row["acttime"] != null && row["acttime"].ToString() != "")
                {
                    model.acttime = DateTime.Parse(row["acttime"].ToString());
                }
                if (row["edttime"] != null && row["edttime"].ToString() != "")
                {
                    model.edttime = DateTime.Parse(row["edttime"].ToString());
                }
                if (row["wnstat"] != null && row["wnstat"].ToString() != "")
                {
                    model.wnstat = int.Parse(row["wnstat"].ToString());
                }
                if (row["email"] != null)
                {
                    model.email = row["email"].ToString();
                }
                if (row["phone"] != null)
                {
                    model.phone = row["phone"].ToString();
                }
                if (row["paymentno"] != null)
                {
                    model.paymentno = row["paymentno"].ToString();
                }
                if (row["pwdstrength"] != null && row["pwdstrength"].ToString() != "")
                {
                    model.pwdstrength = int.Parse(row["pwdstrength"].ToString());
                }
                if (row["headimg"] != null)
                {
                    model.headimg = row["headimg"].ToString();
                }
                if (row["jobid"] != null && row["jobid"].ToString()!="")
                {    
                    model.jobid = int.Parse(row["jobid"].ToString());
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
            strSql.Append("select guid,pwd,username,gender,birthday,regtime,acttime,edttime,wnstat,email,phone,paymentno,pwdstrength,headimg,jobid ");
            strSql.Append(" FROM wn_user ");
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
            strSql.Append(" guid,pwd,username,gender,birthday,regtime,acttime,edttime,wnstat,email,phone,paymentno,pwdstrength,headimg,jobid ");
            strSql.Append(" FROM wn_user ");
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
            strSql.Append("select count(1) FROM wn_user ");
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
                strSql.Append("order by T.email desc");
            }
            strSql.Append(")AS Row, T.*  from wn_user T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取职业列表
        /// </summary>
        /// <returns></returns>
        public List<Job> GetJobList()
        {
            var strSql = new StringBuilder();
            strSql.Append("select Id,Name ");
            strSql.Append(" FROM wn_job ");

            var ds = DbHelperSQL.Query(strSql.ToString());
            var jobList = new List<Job>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var job = new Job();
                job.Id = int.Parse(row["Id"].ToString());
                job.Name = row["Name"].ToString();

                jobList.Add(job);
            }

            return jobList;
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
            parameters[0].Value = "wn_user";
            parameters[1].Value = "email";
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
        /// 根据邮箱或手机查询是否存在该记录
        /// </summary>
        public bool Exists(string emailorphone)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_user");
            strSql.Append(" where email=@emailorphone or phone=@emailorphone ");
            SqlParameter[] parameters = {				
					new SqlParameter("@emailorphone", SqlDbType.NVarChar,50)			};
            parameters[0].Value = emailorphone;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据邮箱查询是否存在该记录
        /// </summary>
        public bool ExistsByEmail(string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_user");
            strSql.Append(" where email=@email ");
            SqlParameter[] parameters = {				
					new SqlParameter("@email", SqlDbType.NVarChar,50)			};
            parameters[0].Value = email;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public DataTable GetUserInfo4SNSLogin(string email)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select guid,pwd from wn_user");
            strSql.Append(" where email=@email");
            SqlParameter[] parameters = {				
					new SqlParameter("@email", SqlDbType.NVarChar,50)
            };
            parameters[0].Value = email;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        public bool ExistsBySNSLogin(string email,string SNS)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_user");
            strSql.Append(" where email=@email and knowwayid=@knowwayid");
            SqlParameter[] parameters = {				
					new SqlParameter("@email", SqlDbType.NVarChar,50),
                    new SqlParameter("@knowwayid",SqlDbType.Int)
            };
            parameters[0].Value = email;
            parameters[1].Value = SNS.ToInt();
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据用户名查询是否存在该记录
        /// </summary>
        public bool ExistsByUserName(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_user");
            strSql.Append(" where username=@username ");
            SqlParameter[] parameters = {				
					new SqlParameter("@username", SqlDbType.NVarChar,50)			};
            parameters[0].Value = userName;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public string CheckCustomShippingFee(string prdGuid, string address, string sCity, string sState, string sCountry, string sZip)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select shippingfee from wn_CustomShippingFee where prodGuid='" + prdGuid + "' and ");
            strSql.Append("address='" + address + "' and ");
            strSql.Append("City='" + sCity + "' and ");
            strSql.Append("State='" + sState + "' and ");
            strSql.Append("Country='" + sCountry + "' and ");
            strSql.Append("Zip='" + sZip + "'  ");
            object obj2 = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj2 == null)
            {
                return "-1";
            }
            return obj2.ToString();
        }

        public void SlotMachine_WriteSpin(string userGuid,string s)
        {


        }

        public string GetCountryCode(string UserGuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT   top 1  b. code FROM        wn_useraddress a left join wn_country b on a.countyid=b.id where a.userguid='" + UserGuid + "' order by isfirst desc");

            object obj2 = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj2 == null)
            {
                return "";
            }
            return obj2.ToString();

        }
        /// <summary>
        /// 根据用户数据库ID查询是否存在该记录
        /// </summary>
        public bool ExistsByID(string guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_user");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {				
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)			};
            parameters[0].Value = new Guid(guid);
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据用户数据库ID查询是否已经登录
        /// </summary>
        public bool IsLogionByID(string guid, string pwd, out User user)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from wn_user");
            strSql.Append(" where guid=@guid and pwd=@pwd ");
            SqlParameter[] parameters = {				
					new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@pwd", SqlDbType.NVarChar,32)};
            parameters[0].Value = new Guid(guid);
            parameters[1].Value = pwd;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                User userMod = new User();
                userMod.username = ds.Tables[0].Rows[0]["username"].ToString();
                userMod.email = ds.Tables[0].Rows[0]["email"].ToString();
                userMod.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                userMod.headimg = ds.Tables[0].Rows[0]["headimg"].ToString();
                userMod.supplypermission = ds.Tables[0].Rows[0]["supplypermission"].ToString().ToInt();
                user = userMod;
                
                // set user login cookie
                CommUtil.SetUserLoginCookie(guid, userMod.email, pwd);
                
                return true;
            }
            else
            {
                user = null;
                return false;
            }
        }
        /// <summary>
        /// 修改账户状态，用于用户激活、锁定、正常
        /// </summary>
        /// <param name="state"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool UpdateState(int state, Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_user set ");
            strSql.Append(" wnstat=@wnstat");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
             new SqlParameter("@wnstat", SqlDbType.Int),     
		     new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)
        };
            parameters[0].Value = state;
            parameters[1].Value = guid;

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
        /// 修改账户状态，用于用户激活、锁定、正常
        /// </summary>
        /// <param name="state"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool UpdateState(int state, Guid guid,out Twee.Model.User user)
        {
            user = null;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_user set ");
            strSql.Append(" wnstat=@wnstat");
            if (state==1)
            {
                strSql.Append(" where guid=@guid and wnstat=0; ");    
            }
            else
            {
                strSql.Append(" where guid=@guid; ");    
            }                  
            SqlParameter[] parameters = {
             new SqlParameter("@wnstat", SqlDbType.Int),     
		     new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)
        };
            parameters[0].Value = state;
            parameters[1].Value = guid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                user = GetModel(guid);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdatePwd(string email, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_user set ");
            strSql.Append("pwd=@pwd,");
            strSql.Append(" where email=@email ");
            SqlParameter[] parameters = {
             new SqlParameter("@pwd", SqlDbType.NVarChar,32),
		     new SqlParameter("@email", SqlDbType.NVarChar,50)
        };
            parameters[0].Value = PasswordHelper.ToUpMd5(pwd); ;
            parameters[1].Value = email;
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
        /// 通过用户数据库ID重置密码
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdatePwdByID(string guid, string newPwd)
        {
            StringBuilder strSql = new StringBuilder();
            int rows = 0;

            strSql.Append("update wn_user set ");
            strSql.Append("pwd=@pwd ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
                     new SqlParameter("@pwd", SqlDbType.NVarChar,50),
	                 new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)		
                };
            parameters[0].Value = PasswordHelper.ToUpMd5(newPwd);
            parameters[1].Value = new Guid(guid);
            rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

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
        /// 通过邮箱或电话重置密码
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool UpdatePwd(string emailorphone, string pwd, string type)
        {
            StringBuilder strSql = new StringBuilder();
            int rows = 0;
            if (type == "email")
            {
                strSql.Append("update wn_user set ");
                strSql.Append("pwd=@pwd ");
                strSql.Append(" where email=@email ");
                SqlParameter[] parameters = {
                     new SqlParameter("@pwd", SqlDbType.NVarChar,32),
		             new SqlParameter("@email", SqlDbType.NVarChar,50)
                };
                parameters[0].Value = PasswordHelper.ToUpMd5(pwd);
                parameters[1].Value = emailorphone;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }
            else if (type == "phone")
            {
                strSql.Append("update wn_user set ");
                strSql.Append("pwd=@pwd ");
                strSql.Append(" where phone=@email ");
                SqlParameter[] parameters = {
                     new SqlParameter("@pwd", SqlDbType.NVarChar,32),
		             new SqlParameter("@email", SqlDbType.NVarChar,50)
                };
                parameters[0].Value = pwd;
                parameters[1].Value = emailorphone;
                rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            }

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
        /// get user guid by email and password
        /// </summary>     
        /// <param name="email">邮箱</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public string GetUserGuid(string sEmail, string sPassword)
        {
            string sPasswordMD5 = PasswordHelper.ToUpMd5(sPassword);
            string sSql = "select guid from wn_user where email=N'" + CommUtil.Quo(sEmail) 
                + "' and pwd ='" + sPasswordMD5 
                + "' and wnstat=" + ((int)(ConfigParamter.UserStatus.normal)).ToString();  // normal user only
            DataSet ds = DbHelperSQL.Query(sSql);
            if (ds != null && ds.Tables.Count > 0) {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["guid"].ToString();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 用户登录
        /// </summary>     
        /// <param name="email">邮箱</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public string UserLogin(string email, string pwd)
        {
            string userGuid = "";
            //pwd = PasswordHelper.ToUpMd5(pwd);

            SqlParameter[] parameters = new SqlParameter[] { 
                    new SqlParameter("@wnstat",SqlDbType.Int),
                    new SqlParameter("@guid", SqlDbType.UniqueIdentifier),
                    new SqlParameter("@AdNo",CommHelper.GetString(email,true)),
                    new SqlParameter("@AdPwd", CommHelper.GetString(pwd,true)),
                    new SqlParameter("@loginIp",CommHelper.GetString("",true))
                };

            parameters[0].Direction = ParameterDirection.Output;
            parameters[1].Direction = ParameterDirection.Output;
            DbHelperSQL.RunProcedure("[Prc_User_Login]", parameters);
            userGuid = parameters[1].Value.ToString();

            //////////////////
            //get e-mail by user guid
            /////////////////
            string username = "";
            if (userGuid.Length > 10)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT email,username FROM wn_user where guid='" + userGuid + "'");


                using (SqlDataReader rdr = DbHelperSQL.ExecuteReader(strSql.ToString()))
                {
                    while (rdr.Read())
                    {
                        email = rdr["email"].ToString();
                        username = rdr["username"].ToString();
                    }
                }
            }

            // 2016-01-20 Changed by Jack Cao 
            // return "{email:'" + ConvertHelper._EscapeDoubleQuo(email) + "',userGuid:'" + userGuid + "',state:'" + parameters[0].Value.ToString() + "',username:'" + ConvertHelper._EscapeDoubleQuo(username) + "'}";
            return "{email:\"" + ConvertHelper._EscapeDoubleQuo(email) + "\",userGuid:\"" + userGuid + "\",state:\"" + parameters[0].Value.ToString() + "\",username:\"" + ConvertHelper._EscapeDoubleQuo(username) + "\"}";

        }
        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        //public bool CheckLogion(string email, string pwd)
        //{
        //    string sql = "select COUNT(1) from wn_user where email=@email and pwd=@pwd";
        //    SqlParameter[] parameters = new SqlParameter[] {                    
        //            new SqlParameter("@email",email),
        //            new SqlParameter("@pwd", pwd)                   
        //        };
        //   object obj = DbHelperSQL.GetSingle(sql, parameters);
        //   if (obj!=null&&obj.ToString()=="1")
        //   {
        //       return true;
        //   }
        //   else
        //   {
        //       return false;
        //   }          

        //}

        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool CheckLogion(Guid userguid, string pwd)
        {
            string sql = "select COUNT(1) from wn_user where guid=@guid and pwd=@pwd";
            SqlParameter[] parameters = new SqlParameter[] {                    
                    new SqlParameter("@guid",userguid),
                    new SqlParameter("@pwd", pwd)                   
                };
            object obj = DbHelperSQL.GetSingle(sql, parameters);
            if (obj != null && obj.ToString() == "1")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 根据用户ID获取用户名称        
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public string GetUserNameByID(string guid)
        {
            string sql = "select username from wn_user where guid=@guid ";
            SqlParameter[] parameters = new SqlParameter[] {                    
                    new SqlParameter("@guid",guid)                              
                };
            DataSet ds = DbHelperSQL.Query(sql, parameters);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["username"].ToString();
            }
            return "";
        }

        /// <summary>
        /// 更改头像
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="headimg"></param>
        /// <returns></returns>
        public bool UpdateHeadImg(string guid, string headimg)
        {
            StringBuilder strSql = new StringBuilder();
            int rows = 0;

            strSql.Append("update wn_user set ");
            strSql.Append("headimg=@headimg ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
                     new SqlParameter("@headimg", SqlDbType.NVarChar,150),
	                 new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)		
                };
            parameters[0].Value = headimg;
            parameters[1].Value = new Guid(guid);
            rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

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
        /// 更改邮箱
        /// </summary>
        /// <param name="guid"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool UpdateEmail(string guid, string email)
        {
            StringBuilder strSql = new StringBuilder();
            int rows = 0;

            strSql.Append("update wn_user set ");
            strSql.Append("email=@email ");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
                     new SqlParameter("@email", SqlDbType.NVarChar,50),
	                 new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)		
                };
            parameters[0].Value = email;
            parameters[1].Value = new Guid(guid);
            rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

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

        #region 后台方法

        /// <summary>
        /// 是否存在该用户
        /// </summary>
        public bool MgeExists(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wn_user");
            strSql.Append(" where username=@username ");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,20)			};
            parameters[0].Value = username;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool MgeAdd()
        {
            //StringBuilder strSql = new StringBuilder();
            //strSql.Append("insert into wn_user(");
            //strSql.Append("guid)");
            //strSql.Append(" values (");
            //strSql.Append("@guid)");
            //SqlParameter[] parameters = {
            //            new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)};
            //parameters[0].Value = Guid.NewGuid();

            //int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            //if (rows > 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }
        /// <summary>
        /// 更改用户状态
        /// </summary>
        public bool MgeUpdate(int state, string name, string phone, DateTime birth, string pwd, Guid guid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_user set ");
            strSql.Append(" wnstat=@wnstat,");
            strSql.Append(" username=@username,");
            strSql.Append(" phone=@phone,");
            strSql.Append(" birthday=@birth");
            strSql.Append(" where guid=@guid ");
            SqlParameter[] parameters = {
             new SqlParameter("@wnstat", SqlDbType.Int),
             new SqlParameter("@username", SqlDbType.NVarChar,50),
             new SqlParameter("@phone", SqlDbType.NVarChar,20),
             new SqlParameter("@birth", SqlDbType.DateTime),           
		     new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)
        };
            parameters[0].Value = state;
            parameters[1].Value = name;
            parameters[2].Value = phone;
            parameters[3].Value = birth;
            parameters[4].Value = guid;

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
        public bool MgeDelete(Guid guid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_user ");
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
        public bool MgeDeleteList(string guidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wn_user ");
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
        /// 获得数据列表
        /// </summary>
        public DataTable MgeGetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select u.guid, username,email,phone,birthday, gender,headimg,regtime,acttime,wnstat,publishgrade,reviewgrade,sharegrade,publishcount,reviewhcount,sharecount from dbo.wn_user u left join  dbo.wn_usergrade g on u.guid=g.userguid ");
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
        /// 获取记录总数
        /// </summary>
        public int MgeGetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from dbo.wn_user ");
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
        public DataTable MgeGetListByPage(string strWhere1, string strWhere2, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT TT.guid,username,email,phone,birthday,TT.gender,headimg,tuijieEmail,knowwayid,regtime,acttime,wnstat,publishgrade,reviewgrade,sharegrade,publishcount,reviewhcount,sharecount,w.way FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.acttime desc");
            }
            strSql.Append(")AS Row, T.*  from dbo.wn_user T ");
            if (!string.IsNullOrEmpty(strWhere1.Trim()))
            {
                strSql.Append(" WHERE " + strWhere1);
            }
            strSql.Append(" ) TT");
            strSql.Append(" left join  dbo.wn_usergrade g on TT.guid=g.userguid");
            strSql.Append(" left join  dbo.wn_knowTweeWay w on TT.knowwayid=w.id");
            if (!string.IsNullOrEmpty(strWhere2.Trim()))
            {
                strSql.Append(" WHERE " + strWhere2);
            }

            strSql.AppendFormat(" and TT.Row between {0} and {1}", startIndex, endIndex);
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// get user daily register count
        /// </summary>
        public DataTable MgeGetUserDailyRegisterCount()
        {
            StringBuilder sSql = new StringBuilder();

//            sSql.Append("select CONVERT(VARCHAR(10), regtime, 102) as [Date],  count(*) as Count  from wn_user");
//            sSql.Append(" group by  CONVERT(VARCHAR(10), regtime, 102)");
            sSql.Append("select CONVERT(date, regtime) as [Date],  count(*) as Count  from wn_user");
            sSql.Append(" group by CONVERT(date, regtime)");
            sSql.Append(" order by [Date] desc ");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }

        /// <summary>
        /// get activated user daily count
        /// </summary>
        public DataTable MgeGetActivatedUserDailyRegisterCount()
        {
            StringBuilder sSql = new StringBuilder();

            sSql.Append("select CONVERT(VARCHAR(10), regtime, 102) as [Date],  count(*) as Count  from wn_user");
            sSql.Append(" where wnstat = 1");
            sSql.Append(" group by  CONVERT(VARCHAR(10), regtime, 102)");
            sSql.Append(" order by [Date] desc");
            DataSet ds = DbHelperSQL.Query(sSql.ToString());
            if (ds == null || ds.Tables.Count == 0) return null;
            return ds.Tables[0];
        }

        
        #endregion
    }
}
