using System;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using Twee.Comm;

namespace TweebaaWebApp2.Manage.Servers
{
    /// <summary>
    /// Administrator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
     [System.Web.Script.Services.ScriptService]
    public class Administrator : System.Web.Services.WebService
    {
        string key = System.Configuration.ConfigurationManager.AppSettings["strKey"].ToString();
        public Administrator()
        {
            //如果使用设计的组件，请取消注释以下行 
            //InitializeComponent(); 
        }

        [WebMethod(EnableSession = true)]
        public string AdministratorLogin(string strKey,
            string strValidateCode,
            string strNameEmailTel,
            string strPass
            )
        {
            try
            {

                string intRes = "-100";//默认错误
                string strLoginGuid = "";
                string sYzm = HttpContext.Current.Session["checkcode"] as string;
                if (key != CommHelper.GetString(strKey, true))
                    intRes = "-99";//非法调用
                else
                {
                    if (strValidateCode.ToUpper() != sYzm.ToUpper())
                        intRes = "-98";//验证码级错误
                    else
                    {
                        //
                        strPass = PasswordHelper.ToUpMd5(strPass);
                        //---
                        using (SqlConnection conn = new SqlConnection(DbHelperSQL.strConn))
                        {
                            using (SqlCommand cmd = new SqlCommand("[Prc_Adm_Login]", conn))
                            {
                                try
                                {
                                    conn.Open();
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    SqlParameter[] parameters = new SqlParameter[] { 
                                new SqlParameter("@wnstat",SqlDbType.Int),
                                new SqlParameter("@guid", SqlDbType.UniqueIdentifier),
                                new SqlParameter("@AdNo",CommHelper.GetString( strNameEmailTel,true)),
                                new SqlParameter("@AdPwd", CommHelper.GetString(strPass,true)),
                                new SqlParameter("@loginIp", CommHelper.GetString("",true))
                            };
                                    parameters[0].Direction = ParameterDirection.Output;
                                    parameters[1].Direction = ParameterDirection.Output;
                                    foreach (SqlParameter parameter in parameters)
                                    {
                                        cmd.Parameters.Add(parameter);
                                    }
                                    cmd.ExecuteNonQuery();
                                    intRes = parameters[0].Value.ToString(); //返回值--方法1
                                    strLoginGuid = parameters[1].Value.ToString();
                                }
                                catch (Exception ex)
                                {
                                    CommHelper.WrtLog(ex.Message);
                                    intRes = "-97";//代码级错误
                                }
                                finally
                                {
                                    conn.Close();
                                }
                            }
                        }
                        //
                        //
                    }
                }
                string s = "{it:'" + intRes + "',d3W6CMlVTocElurgOlGWVQ:'" + strLoginGuid + "', IbrcVLdyQPQ6NgFoHFzfA:'" + (strLoginGuid.Length > 0 ? PasswordHelper.Md5Sign(strLoginGuid) : "") + "'}";
                return Newtonsoft.Json.JsonConvert.SerializeObject(s);
            }
            catch (Exception)
            {
                throw;
            }
        }        
       
    }
}
