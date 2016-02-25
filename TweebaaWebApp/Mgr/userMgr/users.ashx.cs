using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using Twee.Mgr;
using Twee.Comm;
using Newtonsoft.Json;

namespace TweebaaWebApp.Mgr.userMgr
{
    /// <summary>
    /// users1 的摘要说明
    /// </summary>
    public class users1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
             if (string.IsNullOrEmpty(context.Request["action"]))
                context.Response.Write(string.Empty);
            string action=context.Request["action"].ToString().Trim();
            switch (action)
            {
                case "datagrid":
                    context.Response.Write(GetUserList(context));
                    break;
                case "dataPublishGrade":
                    context.Response.Write(GetPunlishGradeParam(context));
                    break;
                case "dataReviewGrade":
                    context.Response.Write(GetReviewGradeParam(context));
                    break;
                case "dataShareGrade":
                    context.Response.Write(GetShareGradeParam(context));
                    break;

                case "userCash":
                    context.Response.Write(GetUserCash(context));
                    break;
                case "payCash":
                    context.Response.Write(GetPayCash(context));
                    break;   

                    
            }
        }

        private string GetUserList(HttpContext context)
        {
            int pageSize = int.Parse(context.Request["rows"]);
            int index = int.Parse(context.Request["page"]) - 1;
            int startId = pageSize * index + 1;
            int endId = startId + pageSize - 1;

            //{ field: 'guid', checkbox: true },
            //                    //{ field: 'prdguid', title: '产品ID', width: 80, hidden: true },
            //                    { field: 'username', title: '会员名称', width: 100 },
            //                    { field: 'gender', title: '性别', width: 50 },
            //                    { field: 'email', title: '邮箱', width: 150 },
            //                    { field: 'phone', title: '联系方式', width: 80 },
            //                    { field: 'regtime', title: '注册时间', width: 80 },
            //                    { field: 'publishgrade', title: '发布等级', width: 80 },
            //                    { field: 'reviewgrade', title: '评审等级', width: 80 },
            //                    { field: 'sharegrade', title: '分享等级', width: 100 },
            //                    { field: 'publishcount', title: '发布个数', width: 100 },
            //                    { field: 'reviewhcount', title: '评审个数', width: 100 },
            //                    { field: 'sharecount', title: '分享个数', width: 100 }, 


            #region MyRegion
            string userName = string.Empty;
            string email = string.Empty;
            string startTime = string.Empty;
            string endTime = string.Empty;
            string state = string.Empty;

            if (!string.IsNullOrEmpty(context.Request["userName"]))
                userName = context.Request["userName"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["email"]))
                email = context.Request["email"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["startTime"]))
                startTime = context.Request["startTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["endTime"]))
                endTime = context.Request["endTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["state"]))
                state = context.Request["state"].ToString().Trim();

            string strWhere1 = " 1=1 ";
            string strWhere2 = " 1=1 ";
            if (!string.IsNullOrEmpty(userName))
            {
                strWhere1 += " and username like '%" + userName + "%' ";
            }
            if (!string.IsNullOrEmpty(email))
            {
                strWhere1 += " and email='" + email + "' ";
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere1 += " and regtime>='" + startTime + "' ";
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere1 += " and regtime<='" + endTime + "' ";
            }
            if (!string.IsNullOrEmpty(state))
            {
                strWhere1 += " and wnstat='" + state + "' ";
            } 
            #endregion
            UserMgr user = new UserMgr();
            int recordCount= user.MgeGetRecordCount(strWhere1);
            DataTable dt = user.MgeGetListByPage(strWhere1, strWhere2, "", startId, endId);
            StringBuilder json = new StringBuilder();
            foreach (DataRow row in dt.Rows)
            {
                json.AppendFormat(",{0}  \"guid\":\"{2}\",\"username\":\"{3}\",\"gender\":\"{4}\",\"email\":\"{5}\",\"phone\":\"{6}\",\"regtime\":\"{7}\",\"publishgrade\":\"{8}\",\"reviewgrade\":\"{9}\",\"publishcount\":\"{10}\",\"reviewhcount\":\"{11}\",\"sharecount\":\"{12}\",\"tuijieemail\":\"{13}\",\"knowway\":\"{14}\"  {1}", "{", "}"
                    , row["guid"]._ObjToString(),
                    row["username"]._ObjToString(),
                    Gender(row["gender"]._ObjToString()),
                    row["email"]._ObjToString(),
                    row["phone"]._ObjToString(),
                    row["regtime"]._ObjToString(),
                    row["publishgrade"]._ObjToString(),
                    row["reviewgrade"]._ObjToString(),
                    row["publishcount"]._ObjToString(),
                    row["reviewhcount"]._ObjToString(),
                    row["sharecount"]._ObjToString(),
                    row["tuijieEmail"]._ObjToString(),
                    row["way"]._ObjToString()
                    );
            }
            string temp_json = string.Empty;
            if (!string.IsNullOrEmpty(json.ToString()))
                temp_json = json.ToString().Substring(1);
            string res = "{\"total\":" + recordCount.ToString() + ",\"rows\":[" + temp_json + "]}";
            return res;

        }
        //发布等级
        private string GetPunlishGradeParam(HttpContext context)
        {
            PublistGradeParamMgr grade = new PublistGradeParamMgr();
            DataTable dt = grade.MgeGetList(" ");
            string resu = JsonConvert.SerializeObject(dt);
            return resu;        
        }
        //评审等级
        private string GetReviewGradeParam(HttpContext context)
        {
            ReviewgradeparamMgr grade = new ReviewgradeparamMgr();
            DataTable dt = grade.MgeGetList(" ");
            string resu = JsonConvert.SerializeObject(dt);
            return resu;
        }
        //分享等级
        private string GetShareGradeParam(HttpContext context)
        {
            SharegradeparamMgr grade = new SharegradeparamMgr();
            DataTable dt = grade.MgeGetList(" ");
            string resu = JsonConvert.SerializeObject(dt);
            return resu;
        }
        //收益
        private string GetUserCash(HttpContext context)
        {

            int pageSize = int.Parse(context.Request["rows"]);
            int index = int.Parse(context.Request["page"]) - 1;
            int startId = pageSize * index + 1;
            int endId = startId + pageSize - 1;

            string email = string.Empty;
            string type = string.Empty;
            string state = string.Empty;
            string startTime = string.Empty;
            string endTime = string.Empty;
            string prdname = string.Empty;  

            if (!string.IsNullOrEmpty(context.Request["email"]))
                email = context.Request["email"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["type"]))
                type = context.Request["type"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["state"]))
                state = context.Request["state"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["startTime"]))
                startTime = context.Request["startTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["endTime"]))
                endTime = context.Request["endTime"].ToString().Trim();

            ProfitMgr mgr = new ProfitMgr();
            //startTime, endTime, 
            int count = 0;
            DataTable dt = mgr.MgrGetUserProfit(null, email, type,state,prdname,startId, endId,startTime,endTime,out count);
            string resu = JsonConvert.SerializeObject(dt);
            return resu;
        }

        //提现申请列表
        private string GetPayCash(HttpContext context)
        {

            int pageSize = int.Parse(context.Request["rows"]);
            int index = int.Parse(context.Request["page"]) - 1;
            int startId = pageSize * index + 1;
            int endId = startId + pageSize - 1;

            string email = string.Empty;
            string type = string.Empty;
            string state = string.Empty;
            string startTime = string.Empty;
            string endTime = string.Empty;
            string prdname = string.Empty;  

            if (!string.IsNullOrEmpty(context.Request["email"]))
                email = context.Request["email"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["startTime"]))
                startTime = context.Request["startTime"].ToString().Trim();
            if (!string.IsNullOrEmpty(context.Request["endTime"]))
                endTime = context.Request["endTime"].ToString().Trim();

            if (!string.IsNullOrEmpty(context.Request["state"]))
                state = context.Request["state"].ToString().Trim();           

            ProfitMgr mgr = new ProfitMgr();        
            int count = 0;
            DataTable dt = mgr.GetPayCash(state,  startId, endId, out count);
            string resu = JsonConvert.SerializeObject(dt);
            return resu;
        }

        
        private string Gender(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "不明";
            if (str == ((int)Twee.Comm.ConfigParamter.Gender.male).ToString())
                return "男";
            if (str == ((int)Twee.Comm.ConfigParamter.Gender.female).ToString())
                return "女";
            if (str == ((int)Twee.Comm.ConfigParamter.Gender.unknow).ToString())
                return "不明";
            return string.Empty;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}