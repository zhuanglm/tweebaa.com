using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Reflection;


namespace TweebaaWebApp.ExtendClass
{
    public class RunMethod
    {
        public SqlConnection conn = new SqlConnection(Twee.Comm.DbHelperSQL.strConn);
        public string ExtendConfigPath = AppDomain.CurrentDomain.BaseDirectory + "Config/ExtendConfig.xml";
        public string dllPath = AppDomain.CurrentDomain.BaseDirectory + "ExtendDll/";
        /// <summary>
        /// 根据runId运行配置文件中的方法
        /// </summary>
        /// <param name="runId">配置文件中的run id</param>
        /// <param name="args">传入XML参数</param>
        /// <returns>必须返回XML数据或字符串</returns>
        public RunModel Run(string runId,string args)
        {
            try
            {
                RunModel success = new RunModel();
                XmlDocument doc = new XmlDocument();
                doc.Load(ExtendConfigPath);
                XmlNode node = doc.SelectSingleNode("/extends/run[@id='"+runId.Trim()+"']");
                string dllName = node.Attributes["dllname"].Value.Trim();
                string nameSpace = node.Attributes["namespace"].Value.Trim();
                string className = node.Attributes["classname"].Value.Trim();
                string methodName = node.Attributes["method"].Value.Trim();
                dllPath = dllPath + dllName;//dll path

                Assembly ass;
                Type type;
                object obj;

                //加载程序集
                ass = Assembly.LoadFile(dllPath);
                //获取类
                type = ass.GetType(nameSpace+"."+className);
                //获取方法
                MethodInfo method = type.GetMethod(methodName);
                //创建类的实例
                obj = ass.CreateInstance(nameSpace + "." + className);
                //创建参数
                object[] argArray=new object[2];
                argArray[0] = args; //第一个是自定义参数
                argArray[1] = conn; //第二个是数据库连接字符串

                string xmlResult = method.Invoke(obj,argArray).ToString();

                success.status = 1;
                success.message = string.Empty;
                success.result = xmlResult;
                return success;
            }
            catch (Exception ex)
            {
                RunModel error = new RunModel();
                error.status = 0;
                error.message = ex.Message;
                error.result = string.Empty;
                return error;
            }
           
        }

    }
}