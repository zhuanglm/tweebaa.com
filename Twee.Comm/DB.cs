using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Twee.Comm
{
    public class DB
    {
        public static readonly string m_sConn = DbHelperSQL.GetSQLConnectionString();// System.Configuration.ConfigurationManager.ConnectionStrings["strConn"].ToString();
        public static int m_iTimeout = 120; // 2 minutes

        public SqlConnection m_cn;
        public SqlDataAdapter m_da;
        private SqlTransaction m_tn;
        private SqlCommand m_cmd;
        public DB() { m_tn = null;  }

        public bool DBConnectBeginTrans()
        {
            try
            {
                DBConnect();
                DBBeginTrans();

                return true;
            }
            catch (SqlException ex)
            {
                DBError("DB ConnectBeginTrans", ex, string.Empty);
                return false;
            }
        }


        public bool DBDisconnectCommitTrans()
        {
            try
            {
                DBCommitTrans();
                DBDisconnect();
                return true;
            }
            catch (SqlException ex)
            {
                DBError("DB DisconnectCommitTrans", ex, string.Empty);
                return false;
            }
        }

        public bool DBConnect()
        {
            try
            {
                m_cn = new SqlConnection(m_sConn);
                m_cn.Open();
                
                return true;

            }
            catch (SqlException ex) 
            {
                DBError("DB Connect", ex, string.Empty);        
                return false;
            }
        }

        public bool DBDisconnect()
        {
            if (m_cn.State == ConnectionState.Open)
            {
                m_cn.Close();
                m_cn.Dispose();
            }
            return true;
        }

        public bool DBBeginTrans()
        {
            m_tn = m_cn.BeginTransaction();
            return true;
        }

        public bool DBCommitTrans()
        {
            m_tn.Commit();
            m_tn.Dispose();
            m_tn = null;
            return true;
        }

        public bool DBRollbackTrans()
        {
            if (m_tn == null) return true;
            m_tn.Rollback();
            m_tn = null;
            return true;
        }

        public DataSet DBQuery(string sSql)
        {

            DataSet ds = new DataSet();
            
            // create a Sql data Adapter
            try
            {
                m_da = new SqlDataAdapter(sSql, m_cn);
                if ( m_tn != null) m_da.SelectCommand.Transaction = m_tn;
                m_da.SelectCommand.CommandTimeout = m_iTimeout;

                // file data set	
                m_da.Fill(ds);

                // dispose Sql data Adapter
                m_da.Dispose();

                return ds;
            }
            catch (SqlException ex)
            {
                DBError("DB Query", ex, sSql);
                return null;
            }
        }

        public int DBExecute(string sSql)
        {
            int iAffectedRow = 0;

            try
            {
                m_cmd = new SqlCommand(sSql, m_cn);
                m_cmd.CommandTimeout = m_iTimeout;
                if ( m_tn != null) m_cmd.Transaction = m_tn;
                iAffectedRow = m_cmd.ExecuteNonQuery();
                m_cmd.Dispose();
                return iAffectedRow; ;
            }
            catch (SqlException ex)
            {
                DBError("DB Execute" , ex, sSql);
                return 0;
            }
        }

        public int DBExecute(string sSql, params SqlParameter[] cmdParms)
        {
            int iAffectedRow = 0;
            try {
                m_cmd = new SqlCommand(sSql, m_cn);
                m_cmd.CommandTimeout = m_iTimeout;
                m_cmd.CommandType = CommandType.Text;   //cmdType;   
                if ( m_tn != null) m_cmd.Transaction = m_tn;
                
                if (cmdParms != null) {
                    foreach (SqlParameter parm in cmdParms) {
                        if ((parm.Direction == ParameterDirection.InputOutput || parm.Direction == ParameterDirection.Input) &&
                            (parm.Value == null)) {
                            parm.Value = DBNull.Value;
                        }
                        m_cmd.Parameters.Add(parm);
                    }
                }
                iAffectedRow  = m_cmd.ExecuteNonQuery();
                m_cmd.Parameters.Clear();

                return iAffectedRow;
            }
            catch (SqlException ex)
            {
                DBError("DB Execute" , ex, sSql);
                return 0;
            }
        }

        public int DBGetIdentity()
        {
                       // get the identity;
            string sSql = "select @@IDENTITY";
            DataSet ds = DBQuery(sSql);
            return GetDataSetCount(ds);
        }

        public int DBQueryCount(string sSql)
        {
            DataSet ds = DBQuery(sSql);
            return GetDataSetCount(ds);
        }


        public int GetDataSetCount(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return dr[0].ToString().ToInt();
                }
            }
            return 0;
        }

        public int DBGetSeq(string sKey)
        {
            int iSeq;

            try
            {
                string sSql = "update wn_seq set Seq_Value = Seq_Value + Seq_Increment where Seq_Key = '" + sKey + "'";
                int iRow = DBExecute(sSql);

                sSql = "select Seq_Value from wn_Seq where Seq_Key = '" + sKey + "'";
                DataSet ds = DBQuery(sSql);
                iSeq = (int)ds.Tables[0].Rows[0]["Seq_Value"];
                ds.Dispose();
                return iSeq;
            }
            catch (Exception ex)
            {
                DBError("Get Seq", ex, string.Empty);
                return (-1);    
            }
        }


        private void DBError(string sTitle, Exception ex, string sMsg)
        {
            DBRollbackTrans();
            DBDisconnect();
            string sErrorMsg = sTitle + "\n" + ex.Message + "\n" + sMsg;
            CommUtil.GenernalErrorHandler(ex);
            //throw new Exception(sErrorMsg);
        }
    }
}
