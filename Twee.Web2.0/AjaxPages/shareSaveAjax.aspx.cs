using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using Newtonsoft.Json;
using System.Text;


namespace TweebaaWebApp2.AjaxPages
{
    public partial class shareSaveAjax : System.Web.UI.Page
    {
        //保存叠图
        protected void Page_Load(object sender, EventArgs e)
        {            
            Guid? userGuid = CommUtil.IsLogion();
            userGuid = "A4D9C4AA-DBE8-41E2-A1D2-0D1C6AADED4F".ToGuid();
            if (userGuid != null)
            {
                if (!string.IsNullOrEmpty(Request["data"]) && !string.IsNullOrEmpty(Request["type"]))
                {
                    Twee.Mgr.TemplateMgr mgr = new Twee.Mgr.TemplateMgr();
                    Twee.Model.Template model = new Twee.Model.Template();
                    model.result = Request["data"].ToNullString();//叠图结果json
                    model.user_id = userGuid.Value;//用户id
                    model.description = Request["description"].ToNullString();//叠图描述             
                    model.title = CommHelper.GetStrDecode(Request["title"].ToNullString()); //叠图标题
                    model.imgurl = "";//叠图缩略图   
                    //叠图类型:system(系统的), userDraft（用户已保存未发布的）, userPublish（用户已保存已发布的）
                    model.type = Request["type"].ToNullString();
                    int? id = null;
                    bool b = mgr.Add(model, out id);
                    if (b)
                    {
                        string redirect = "http://localhost/data/set.php?id=" + id.Value;
                        StringBuilder strData = new StringBuilder();
                        strData.Append("{");
                        strData.Append("\"userid\": \"" + model.user_id + "\",");
                        strData.Append("\"redirect\": \"" + redirect + "\",");
                        strData.Append("\"status\":{\"ok\":1},");
                        strData.Append("\"event\":\"publish\",");
                        strData.Append("\"redirect_to_set\":1,");
                        strData.Append("\"result\":{");
                        strData.Append("\"visibility\":\"public\",");
                        strData.Append("\"createdon\":\"" + DateTime.Now.ToString() + "\",");
                        strData.Append("\"tid\":\"" + model.id + "\",");
                        strData.Append("\"title\":\"" + model.title + "\",");
                        strData.Append("\"imgurl\":\"" + model.imgurl + "\",");
                        strData.Append("\"description\":\"" + model.description + "\",");
                        strData.Append("\"user_type\":\"client\",");
                        strData.Append("\"age\":\"1\",");
                        strData.Append("\"state\":\"active\",");
                        strData.Append("\"isOwner\": 0,");
                        strData.Append("\"viewport\": null,");
                        strData.Append("\"status_msg\":\"\",");
                        strData.Append("\"country\":\"zh-cn\",");
                        strData.Append("\"occupation\":\"潮人\",");
                        strData.Append("\"user_name\":\"asdf\",");
                        strData.Append("\"object_class\":\"template\",");
                        strData.Append("\"user_age\":\"248131569\",");
                        strData.Append("\"user_state\":\"active\",");
                        strData.Append("\"user_id\":\"" + model.user_id + "\"");
                        strData.Append("}}");
                        Response.Write(strData.ToString());
                        return;


                        //------------------------------------------------------
                        //string jsonStr = Request["data"].ToString();                    
                        //dynamic json = Json.Deserialize(jsonStr);//解析json
                        //if (json != null)
                        //{
                        //    string msg = json.title;                      
                        //    model.result = Request["data"].ToString();//叠图结果json
                        //    model.user_id = userGuid.Value;//用户id
                        //    model.description = json.description;//叠图描述             
                        //    model.title = json.title; //叠图标题
                        //    model.imgurl = "";//叠图缩略图   
                        //    model.type = "";//叠图类型
                        //    mgr.Add(model);                         
                        //}

                    }

                }
            }
        }
    }
}