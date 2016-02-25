using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Twee.Comm
{
    public abstract class DbHelperSQLMobileApp
    {
        //这个类是用于做手机App数据用户同步用的，所以是直接连接App数据库
        //当用户在网站注册，更改密码时，都需要同步App数据库
        // 积分如何??
        public static readonly string strConnMobileApp = "Data Source=67.224.94.82,4108; Initial Catalog=TweebaaEn;User Id=wnTweebaa;Password=Tweebaawebapp2014!2016;max pool size=5000";//"Data Source=67.224.94.82,4108; Initial Catalog=TweeBaa_v2;User Id=wnTweebaa;Password=Tweebaawebapp2014";// 
       
        public DbHelperSQLMobileApp()
        {
        }

        #region 公用方法

        public static void UpdatePassword(string guid, string newPwd)
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
            rows = MobileApp_ExecuteSql(strSql.ToString(), parameters);

        }

        public static void ActiveUserAccount(int state, string userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wn_user set ");
            strSql.Append(" wnstat=@wnstat");

                strSql.Append(" where guid=@guid and wnstat=0; ");
           
            SqlParameter[] parameters = {
             new SqlParameter("@wnstat", SqlDbType.Int),     
		     new SqlParameter("@guid", SqlDbType.UniqueIdentifier,16)
            };
            parameters[0].Value = state;
            parameters[1].Value = userID.ToGuid();

            int rows = MobileApp_ExecuteSql(strSql.ToString(), parameters);
        }
        public static int MobileAppDoRegisterSync(string sUserGuid, string userName, string strNameEmailTel, string phone, string strPass, int countryId, int? knowwayid, string tuijieEmail, bool consent)
        {
            int intRes = -100;//默认错误
            string strLoginGuid = "";
            //string sYzm = HttpContext.Current.Session["checkcode"] as string;                    

            int Strength = (int)PasswordHelper.PasswordStrength(strPass);
            strPass = PasswordHelper.ToUpMd5(strPass);
            using (SqlConnection conn = new SqlConnection(strConnMobileApp))
            {
                using (SqlCommand cmd = new SqlCommand("[spMobileAppRegister]", conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] parameters = new SqlParameter[] { 
                                new SqlParameter("@wnstat",SqlDbType.Int),
                                new SqlParameter("@guid", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@email",CommHelper.GetString( strNameEmailTel,true)),
                                new SqlParameter("@phone",phone),                               
                                new SqlParameter("@strPass", CommHelper.GetString(strPass,true)),
                                new SqlParameter("@Strength", Strength),
                                new SqlParameter("@userName",SqlDbType.NVarChar,50),
                                new SqlParameter("@countryId",SqlDbType.Int),
                                new SqlParameter("@knowwayid",SqlDbType.Int),
                                new SqlParameter("@tuijieEmail",SqlDbType.NVarChar),
                                new SqlParameter("@consenttime",SqlDbType.DateTime),
                            };
                        parameters[0].Direction = ParameterDirection.Output;
                        parameters[1].Value = sUserGuid.ToGuid();
                        parameters[6].Value = userName;
                        parameters[7].Value = countryId;
                        parameters[8].Value = knowwayid;
                        parameters[9].Value = tuijieEmail;
                        if (consent) parameters[10].Value = DateTime.Now;
                        else parameters[10].Value = DBNull.Value;
                        foreach (SqlParameter parameter in parameters)
                        {
                            cmd.Parameters.Add(parameter);
                        }
                        cmd.ExecuteNonQuery();
                        intRes = 1;
                      
                    }
                    catch (Exception ex)
                    {
                        CommHelper.WrtLog(ex.Message);
                        intRes = -97;//代码级错误
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return intRes;
        }

        /// <summary>
        /// 取到最大字段值

        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int MobileApp_GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ") from " + TableName;
            object obj = MobileApp_GetSingle(strsql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        /// <summary>
        /// 是否存在某条记录
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool MobileApp_Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = MobileApp_GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region  执行简单SQL语句

        /// <summary>   
        /// 执行SQL语句，返回影响的记录数   
        /// </summary>   
        /// <param name="SQLString">SQL语句</param>   
        /// <returns>影响的记录数</returns>   
        public static int MobileApp_ExecuteSql(string SQLString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnMobileApp))
                {
                    using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                    {
                        try
                        {
                            connection.Open();
                            int rows = cmd.ExecuteNonQuery();
                            return rows;
                        }
                        catch (System.Data.SqlClient.SqlException E)
                        {
                            Twee.Comm.CommUtil.GenernalErrorHandlerEx(E, SQLString);
                            connection.Close();
                            return 0;
                            //throw new Exception(E.Message);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, SQLString);
            }
            return 0;
        }


        /// <summary>   
        /// Get a new sequenct number by key。   
        /// </summary>   
        public static int MobileApp_GetSeq(string sKey)
        {
            int iSeq = -1;

            using (SqlConnection conn = new SqlConnection(strConnMobileApp))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    // update count
                    string sSql = "update wn_Seq set Seq_Value = Seq_Value + Seq_Increment where Seq_Key = '" + sKey + "'";
                    cmd.CommandText = sSql;
                    cmd.ExecuteNonQuery();

                    // get new sequence number
                    sSql = "select Seq_Value from wn_Seq where Seq_Key = '" + sKey + "'";
                    cmd.CommandText = sSql;
                    SqlDataReader reader = cmd.ExecuteReader();

                    // get seg from reader
                    if (reader.HasRows)
                    {
                        reader.Read();
                        iSeq = reader.GetInt32(0);
                    }
                    reader.Close();

                    // commit
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    Twee.Comm.CommUtil.GenernalErrorHandlerEx(E, sKey);
                    // throw new Exception(E.Message);
                }
                finally
                {
                    conn.Close();
                }

                return iSeq;
            }
        }


        /// <summary>   
        /// 执行多条SQL语句，实现数据库事务。   
        /// </summary>   
        /// <param name="SQLStringList">多条SQL语句</param>        
        public static void MobileApp_ExecuteSqlTran(ArrayList SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(strConnMobileApp))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    //throw new Exception(E.Message);
                    Twee.Comm.CommUtil.GenernalErrorHandler(E);
                    conn.Close();
                }
            }
        }
        /// <summary>   
        /// 执行带一个存储过程参数的的SQL语句。   
        /// </summary>   
        /// <param name="SQLString">SQL语句</param>   
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>   
        /// <returns>影响的记录数</returns>   
        public static int MobileApp_ExecuteSql(string SQLString, string content)
        {
            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@content", SqlDbType.NText);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    //throw new Exception(E.Message);
                    Twee.Comm.CommUtil.GenernalErrorHandlerEx(E, SQLString);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
            return 0;
        }
        /// <summary>   
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)   
        /// </summary>   
        /// <param name="strSQL">SQL语句</param>   
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>   
        /// <returns>影响的记录数</returns>   
        public static int MobileApp_ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                SqlCommand cmd = new SqlCommand(strSQL, connection);
                System.Data.SqlClient.SqlParameter myParameter = new System.Data.SqlClient.SqlParameter("@fs", SqlDbType.Image);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    //throw new Exception(E.Message);
                    Twee.Comm.CommUtil.GenernalErrorHandlerEx(E, strSQL);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
            return 0;
        }
        /// <summary>   
        /// 执行一条计算查询结果语句，返回查询结果（object）。   
        /// </summary>   
        /// <param name="SQLString">计算查询结果语句</param>   
        /// <returns>查询结果（object）</returns>   
        public static object MobileApp_GetSingle(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, SQLString);
                        return null;
                        //throw new Exception(e.Message);
                    }
                }
            }
        }
        /// <summary>   
        /// 执行查询语句，返回SqlDataReader   
        /// </summary>   
        /// <param name="strSQL">查询语句</param>   
        /// <returns>SqlDataReader</returns>   
        public static SqlDataReader MobileApp_ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(strConnMobileApp);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                connection.Close();
                Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, strSQL);
                return null;
                //throw new Exception(e.Message);
            }

        }

        /// <summary>   
        /// 执行查询语句，返回DataSet   
        /// </summary>   
        /// <param name="SQLString">查询语句</param>   
        /// <returns>DataSet</returns>   
        public static DataSet MobileApp_Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Twee.Comm.CommUtil.GenernalErrorHandlerEx(ex, SQLString);
                    // throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }


        /// <summary>   
        /// 执行查询语句 of count    
        /// </summary>   
        /// <param name="SQLString">查询语句</param>   
        /// <returns>int</returns>   
        public static int MobileApp_QueryCount(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    Twee.Comm.CommUtil.GenernalErrorHandlerEx(ex, SQLString);
                    // throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

                int iCount = 0;
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];
                        iCount = dr[0].ToString().ToInt();
                    }
                }
                return iCount;
            }
        }


        #endregion

        #region 执行带参数的SQL语句

        /// <summary>   
        /// 执行SQL语句，返回影响的记录数   
        /// </summary>   
        /// <param name="SQLString">SQL语句</param>   
        /// <returns>影响的记录数</returns>   
        public static int MobileApp_ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        MobileApp_PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        connection.Close();
                        Twee.Comm.CommUtil.GenernalErrorHandlerEx(E, SQLString);
                        return 0;
                        //throw new Exception(E.Message);
                    }
                }
            }
        }


        /// <summary>   
        /// 执行多条SQL语句，实现数据库事务。   
        /// </summary>   
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>   
        public static void MobileApp_ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(strConnMobileApp))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环   
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = myDE.Key.ToString();
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            MobileApp_PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                            trans.Commit();
                        }
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        //trans.Rollback();
                        Twee.Comm.CommUtil.GenernalErrorHandler(E);
                        //throw;
                        conn.Close();
                    }
                }
            }
        }
        /// <summary>   
        /// 执行多条SQL语句，实现数据库事务   
        /// </summary>   
        /// <param name="SQLStringList">SQL语句的哈希表（key为标识，value是该语句的SqlParameter[]）</param>   
        public static void MobileApp_ExecuteSqlTran(string sqltxt, Hashtable SQLStringList)
        {
            using (SqlConnection conn = new SqlConnection(strConnMobileApp))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    SqlCommand cmd = new SqlCommand();
                    try
                    {
                        //循环   
                        foreach (DictionaryEntry myDE in SQLStringList)
                        {
                            string cmdText = sqltxt;
                            SqlParameter[] cmdParms = (SqlParameter[])myDE.Value;
                            MobileApp_PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                        }
                        trans.Commit();
                    }
                    catch (System.Data.SqlClient.SqlException E)
                    {
                        trans.Rollback();
                        Twee.Comm.CommUtil.GenernalErrorHandlerEx(E, sqltxt);
                        conn.Close();
                        //throw;
                    }
                }
            }
        }

        /// <summary>   
        /// 执行一条计算查询结果语句，返回查询结果（object）。   
        /// </summary>   
        /// <param name="SQLString">计算查询结果语句</param>   
        /// <returns>查询结果（object）</returns>   
        public static object MobileApp_GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        MobileApp_PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, SQLString);
                        connection.Close();
                        return null;
                        //throw new Exception(e.Message);
                    }
                }
            }
        }

        /// <summary>   
        /// 执行查询语句，返回SqlDataReader   
        /// </summary>   
        /// <param name="strSQL">查询语句</param>   
        /// <returns>SqlDataReader</returns>   
        public static SqlDataReader MobileApp_ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(strConnMobileApp);
            SqlCommand cmd = new SqlCommand();
            try
            {
                MobileApp_PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, SQLString);
                connection.Close();
                return null;
                //throw new Exception(e.Message);
            }

        }

        /// <summary>   
        /// 执行查询语句，返回DataSet   
        /// </summary>   
        /// <param name="SQLString">查询语句</param>   
        /// <returns>DataSet</returns>   
        public static DataSet MobileApp_Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                SqlCommand cmd = new SqlCommand();
                MobileApp_PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds);
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        Twee.Comm.CommUtil.GenernalErrorHandlerEx(ex, SQLString);
                        connection.Close();
                        return null;
                        //throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        //private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        //{

        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    cmd.Connection = conn;
        //    cmd.CommandText = cmdText;
        //    if (trans != null)
        //        cmd.Transaction = trans;
        //    cmd.CommandType = CommandType.Text;//cmdType;
        //    if (cmdParms != null)
        //    {
        //        foreach (SqlParameter parameter in cmdParms)
        //        {
        //            if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
        //                (parameter.Value == null))
        //            {
        //                parameter.Value = DBNull.Value;
        //            }
        //            cmd.Parameters.Add(parameter);
        //        }
        //    }
        //}

        private static void MobileApp_PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                if (trans != null)
                    cmd.Transaction = trans;
                cmd.CommandType = CommandType.Text;//cmdType;   
                if (cmdParms != null)
                {
                    foreach (SqlParameter parm in cmdParms)
                    {
                        //cmd.Parameters.Add(parm);
                        if ((parm.Direction == ParameterDirection.InputOutput || parm.Direction == ParameterDirection.Input) &&
                            (parm.Value == null))
                        {
                            parm.Value = DBNull.Value;
                        }
                        cmd.Parameters.Add(parm);
                    }
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, cmdText);
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>   
        /// 执行存储过程   
        /// </summary>   
        /// <param name="storedProcName">存储过程名</param>   
        /// <param name="parameters">存储过程参数</param>   
        /// <returns>SqlDataReader</returns>   
        public static SqlDataReader MobileApp_RunProcedure(string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strConnMobileApp);
                SqlDataReader returnReader;
                connection.Open();
                SqlCommand command = MobileApp_BuildQueryCommand(connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                returnReader = command.ExecuteReader();
                return returnReader;
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, storedProcName);
            }
            return null;
        }
        /// <summary>   
        /// 执行带输出参数的存储过程   
        /// </summary>   
        /// <param name="storedProcName">存储过程名</param>   
        /// <param name="parameters">存储过程参数,OutName 输出参数的名字（如果是多个以@为分割符）</param>   
        /// <returns>string(以|分割的输出参数的值)</returns>   
        public static string MobileApp_RunProcedureOut(string storedProcName, IDataParameter[] parameters, string outName)
        {
            try
            {
                SqlConnection connection = new SqlConnection(strConnMobileApp);
                string returnstring = string.Empty;
                connection.Open();
                SqlCommand command = MobileApp_BuildQueryCommand(connection, storedProcName, parameters);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                string str = string.Empty;
                //解析穿过来的参数   
                string[] Arraystr = outName.Split('|');
                foreach (string st in Arraystr)
                {
                    string a = st.ToString();
                    if (str == string.Empty)
                    {
                        str = command.Parameters[a].Value.ToString();
                    }
                    else
                    {
                        str = str + "|" + command.Parameters[a].Value.ToString();
                    }
                }
                return str;
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, storedProcName);
            }
            return "";
        }

        /// <summary>   
        /// 执行存储过程   
        /// </summary>   
        /// <param name="storedProcName">存储过程名</param>   
        /// <param name="parameters">存储过程参数</param>   
        /// <param name="tableName">DataSet结果中的表名</param>   
        /// <returns>DataSet</returns>   
        public static DataSet MobileApp_RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(strConnMobileApp))
                {
                    DataSet dataSet = new DataSet();
                    connection.Open();
                    SqlDataAdapter sqlDA = new SqlDataAdapter();
                    sqlDA.SelectCommand = MobileApp_BuildQueryCommand(connection, storedProcName, parameters);
                    sqlDA.Fill(dataSet, tableName);
                    connection.Close();
                    return dataSet;
                }
            }
            catch (Exception e)
            {

                Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, storedProcName);
            }
            return null;
        }


        /// <summary>   
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)   
        /// </summary>   
        /// <param name="connection">数据库连接</param>   
        /// <param name="storedProcName">存储过程名</param>   
        /// <param name="parameters">存储过程参数</param>   
        /// <returns>SqlCommand</returns>   
        private static SqlCommand MobileApp_BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            try
            {
                SqlCommand command = new SqlCommand(storedProcName, connection);
                command.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
                return command;
            }
            catch (Exception e)
            {
                Twee.Comm.CommUtil.GenernalErrorHandlerEx(e, storedProcName);
            }
            return null;
        }

        /// <summary>   
        /// 执行存储过程，返回影响的行数         
        /// </summary>   
        /// <param name="storedProcName">存储过程名</param>   
        /// <param name="parameters">存储过程参数</param>   
        /// <param name="rowsAffected">影响的行数</param>   
        /// <returns></returns>   
        public static int MobileApp_RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        {

            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                int result = 1;

                connection.Open();
                SqlCommand command = MobileApp_BuildIntCommand(connection, storedProcName, parameters);
                rowsAffected = command.ExecuteNonQuery();
                result = (int)command.Parameters["ReturnValue"].Value;

                //Connection.Close();   
                return result;
            }




        }
        /// <summary>   
        /// 执行存储过程，返回影响行数   
        /// </summary>   
        /// <param name="storedProcName">string类型存储过程名</param>   
        /// <param name="parameters">SqlParameters[]存储过程参数</param>   
        /// <returns>int 影响行数</returns>   
        public static int MobileApp_RunProcedure_NonQuery(string storedProcName, IDataParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(strConnMobileApp))
            {
                connection.Open();
                SqlCommand command = MobileApp_BuildIntCommand(connection, storedProcName, parameters);
                return (command.ExecuteNonQuery());
            }
        }
        /// <summary>   
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)      
        /// </summary>   
        /// <param name="storedProcName">存储过程名</param>   
        /// <param name="parameters">存储过程参数</param>   
        /// <returns>SqlCommand 对象实例</returns>   
        private static SqlCommand MobileApp_BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = MobileApp_BuildIntCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue",
                SqlDbType.Int, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion

    }
}
