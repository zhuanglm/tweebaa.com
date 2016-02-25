using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using System.Data;
using Newtonsoft.Json;
using System.Text;

using System.IO;
using System.Runtime.Serialization.Json; 


namespace TweebaaWebApp.AjaxPages
{
    /// <summary>
    /// 叠图模板
    /// </summary>
    public partial class TemplateAjax : System.Web.UI.Page
    {
        private int page = 1;
        string userid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Response.Headers.Add("Access-Control-Allow-Origin", "*");//上线要去掉
           
            string strWhere = "";
            if (!string.IsNullOrEmpty(Request["tid"]))
            {
                int tid = Request["tid"].ToString().ToInt();
                GetTemplateById(tid);
                return;
            }
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                page = Request["page"].ToString().ToInt();
            }
            if (!string.IsNullOrEmpty(Request["type"]))
            {
                string type = Request["type"].ToString();//system, userDraft, userPublish
                if (type == "system")
                {
                    strWhere = " type='system'";
                    GetSystemTemplate(strWhere, page);
                }
                else
                {
                    strWhere = " type='" + type + "' and  user_id='A4D9C4AA-DBE8-41E2-A1D2-0D1C6AADED4F'";//测试
                    GetUserTemplate(strWhere, page);

                    //Guid? userGuid = CommUtil.IsLogion();                   
                    //if (userGuid != null)
                    //{
                    //    strWhere = " type='" + type + "' and  user_id='" + userGuid.Value.ToString() + "'";
                    //    GetUserTemplate(strWhere,page);
                    //}
                }
            }


            //if (!string.IsNullOrEmpty(Request["userid"]))
            //{
            //    userid = Request["userid"].ToString();
            //    strWhere = " user_id='" + Request["userid"].ToString() + "'";
            //    GetData1(page, strWhere);
            //    return;
            //}
            //else
            //{               
            //    GetData2(page);
            //}
           
        }

        /// <summary>
        /// 获取叠图模板列表 templateUser
        /// </summary>
        /// <param name="price"></param>
        /// <param name="userid"></param>
        private void GetUserTemplate(string where,int page)
        {
            int startIndex = ConfigParamter.templateSize * (page - 1)+1;
            int endIndex = ConfigParamter.templateSize * page;
            Twee.Mgr.TemplateMgr mgr = new Twee.Mgr.TemplateMgr();
            DataSet ds = mgr.GetListByPage(where, "", startIndex, endIndex);
            StringBuilder data = new StringBuilder();
            if (ds!=null&&ds.Tables.Count>0)
            {
                DataTable dtInfo = ds.Tables[0];
                string dataInfo = JsonConvert.SerializeObject(dtInfo);                
                data.Append("{");
                data.Append("\"userid\":\"" + userid + "\",");
                data.Append("\"status\":{\"ok\": 1  },");
                data.Append("\"result\":{\"page\": \"" + page + "\",\"more_pages\": 1,");
                data.Append("\"items\":" + dataInfo);
                data.Append("}}");    
            }
            Response.Clear();
            Response.Write(data.ToString());        
        }

        /// <summary>
        /// 获取叠图模板列表 templateList
        /// </summary>
        /// <param name="price"></param>      
        private void GetSystemTemplate(string where,int page)
        {
            int startIndex = ConfigParamter.templateSize * (page - 1) + 1;
            int endIndex = ConfigParamter.templateSize * page;
            Twee.Mgr.TemplateMgr mgr = new Twee.Mgr.TemplateMgr();
            DataSet ds = mgr.GetListByPage(where, "", startIndex, endIndex);
            StringBuilder data = new StringBuilder();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dtInfo = ds.Tables[0];
                string dataInfo = JsonConvert.SerializeObject(dtInfo);
                data.Append("{");
                data.Append("\"status\":{\"ok\": 1  },");
                data.Append("\"result\":{\"page\": \"" + page + "\",\"more_pages\": 1,");
                data.Append("\"items\":");
                //dataInfo = dataInfo.Replace("{", "{\"sets\":[{\"imgurl\": \"\", \"id\": \"\"},{\"imgurl\": \"\", \"id\": \"\"}],");
                data.Append(dataInfo);
                data.Append("}}");
              
            }
            Response.Clear();
            Response.Write(data.ToString());

        }

        /// <summary>
        /// 选择某一模板时返回的JSON
        /// </summary>
        private void GetTemplateById(int tid)
        {
            Twee.Mgr.TemplateMgr mgr = new Twee.Mgr.TemplateMgr();
            Twee.Model.Template template = mgr.GetModel(tid);
            StringBuilder strData = new StringBuilder();
            strData.Append("{");
            strData.Append("\"template\": {");
            strData.Append("\"tid\": \"" + template.id + "\",");
            strData.Append("\"title\": \"" + template.title + "\",");
            strData.Append("\"imgurl\": \"" + template.imgurl + "\",");
            strData.Append("\"description\": \"" + template.description + "\",");           
            string items = template.result.Substring(template.result.IndexOf("items"), template.result.Length - template.result.IndexOf("items") - 1);
            strData.Append("\"" + items);
            strData.Append("}}");



            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
            //MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(template.result));
            //T jsonObject = (T)ser.ReadObject(ms);
            //ms.Close();
            //return jsonObject;  




            string resu = strData.ToString();
            dynamic json = Json.Deserialize(template.result);//解析json        
            List<object> list = json.items;
            for (int i = 0; i < list.Count; i++)
            {
                try
                {
                    dynamic json2 = (dynamic)list[i];
                    string prdId = json2.content.thing_id;
                    if (!string.IsNullOrEmpty(prdId))
                    {
                        Twee.Mgr.PrdMgr prd = new Twee.Mgr.PrdMgr();
                        DataTable dt = prd.GetPrdBaseInfo(prdId.ToGuid().Value);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //"imgurl": "images/mid/02.jpg",	//图片位置
                            //"thing_id": "85859236",		//预置物品的ID
                            //"title": "标题标题",		//标题
                            //"description": "描述描述",	//描述
                            //"url": "http://baidu.com/",	//网址
                            //"price": "1799",			//价格
                            //"displayurl": "ethanallen.com",	//显示出的URL
                            StringBuilder sbStr = new StringBuilder();
                            string img = System.Configuration.ConfigurationManager.AppSettings["prdImgDomain"] + "/";
                            sbStr.Append("\"type\": \"" + "image" + "\",");
                            sbStr.Append("\"ow\": \"" + "400" + "\",");
                            sbStr.Append("\"oh\": \"" + "400" + "\",");
                            sbStr.Append("\"imgurl\":" + "\"" +img+ dt.Rows[0]["fileurl"].ToString() + "\",");
                            sbStr.Append("\"title\":" + "\"" + dt.Rows[0]["name"].ToString() + "\",");
                            sbStr.Append("\"description\":" + "\"" + dt.Rows[0]["name"].ToString() + "\",");
                            sbStr.Append("\"price\":" + "\"" + dt.Rows[0]["saleprice"].ToString() + "\",");
                            sbStr.Append("\"displayurl\":" + "\"" + img + dt.Rows[0]["fileurl"].ToString() + "\",");
                            sbStr.Append("\"url\":" + "\"" + "www.tweebaa.com");
                            resu = resu.Replace(prdId, "\"," + sbStr.ToString());
                            //resu = resu.Replace("content", "\"," + sbStr.ToString()+",content");
                        }
                    }
                }
                catch (Exception)
                {
                }

            }
          

            Response.Clear();
            Response.Write(resu);
            return;

            //{
            //    "post_share": 1,
            //    "userid": 1234,
            //    "id": null,
            //    "basedon_tid": 3,
            //    "title": "标题标题",
            //    "description": "描述",
            //    "category": [
            //        "a类",
            //        "a-a类",
            //        "a-a-a类"
            //    ],
            //    "items": [       
            //        {           

            //        }
            //    ]
            //}



            //string strItems = JsonConvert.SerializeObject(list);
            //strData.Append("\"user_type\": \"client\",");//*****从此开始为保留项，可选。用户类型:client=消费者，merchant=商家.....，用于筛选
            //strData.Append("\"age\": \"41681509\",");
            //strData.Append("\"state\": \"active\",");
            //strData.Append("\"isOwner\": 0,");
            //strData.Append("\"viewport\": null,");
            //strData.Append("\"status_msg\": \"进入时底部可选信息提示\",");
            //strData.Append("\"country\": \"zh-cn\",");
            //strData.Append("\"occupation\": \"潮人\",");
            //strData.Append("\"user_name\": \"asdf\",");
            //strData.Append("\"object_class\": \"template\",");
            //strData.Append("\"user_age\": \"248131569\",");
            //strData.Append("\"user_state\": \"active\",");
            //strData.Append("\"user_id\": \"27\",");
            //strData.Append("\"invalid_items\": [],");	
            //strData.Append("\"items\": [");



            //if (!string.IsNullOrEmpty(template.result))
            //{
            //    //strData.Append(template.result+",");
            //    strData.Append(template.result);
            //}
            //strData.Append("{");
            //strData.Append("\"w\": \"164.748858447489\",");
            //strData.Append("\"transform\": [");			
            //strData.Append("\"1\",0,0,\"1\"],");
            //strData.Append("\"dropHint\": \"Art\",");	
            //strData.Append("\"x\": \"40.2511415525114\",");
            //strData.Append("\"y\": \"59.6574810127238\",");
            //strData.Append("\"h\": \"179.804020100502\",");
            //strData.Append("\"type\": \"ph\",");			
            //strData.Append("\"z\": \"2\",");			
            //strData.Append("\"state\": \"active\",");			
            //strData.Append("\"visible_ratio\": \"0.208393875643999\"");	 
            //strData.Append("},");

            //strData.Append("{");
            //strData.Append("\"type\": \"image\",");	
            //strData.Append("\"x\": 0,");	
            //strData.Append("\"y\": \"267.994889325682\",");
            //strData.Append("\"w\": \"239\",");			
            //strData.Append("\"h\": \"195.173594132029\",");
            //strData.Append("\"z\": \"5\",");	
            //strData.Append("\"ow\": \"2048\",");	
            //strData.Append("\"oh\": \"1680\",");
            //strData.Append("\"imgurl\": \"images/mid/02.jpg\",");
            //strData.Append("\"thing_id\": \"85859236\",");	
            //strData.Append("\"title\": \"标题标题\",");
            //strData.Append("\"description\": \"描述描述\",");	
            //strData.Append("\"url\": \"http://baidu.com/\",");
            //strData.Append("\"price\": \"1799\",");	
            //strData.Append("\"displayurl\": \"ethanallen.com\",");
            //strData.Append("\"visibility\": \"public\",	");
            //strData.Append("\"paid_url\": null,");
            //strData.Append("\"masking_policy\": \"default_yes\",");
            //strData.Append("\"a\": \"0.8166\",");
            //strData.Append("\"oa\": \"0.8203\",");
            //strData.Append("\"min_price\": \"1799.00\",");
            //strData.Append("\"state\": \"active\",");
            //strData.Append("\"max_sale_price\": \"1839.20\",");
            //strData.Append("\"old_thing_id\": \"85859236\",");
            //strData.Append("\"sale_price\": \"1439.2\",");
            //strData.Append("\"max_price\": \"2299.00\",");
            //strData.Append("\"visible_ratio\": \"0.239222870161613\",");
            //strData.Append("\"brand_id\": \"126015\",");
            //strData.Append("\"brand\": \"Ethan Allen\",");
            //strData.Append("\"currency\": \"USD\",");
            //strData.Append("\"host_type\": \"store\",");
            //strData.Append("\"opacity\": 0,");
            //strData.Append("\"instock\": \"1\",");
            //strData.Append("\"category_id\": \"126\",");
            //strData.Append("\"createdby\": \"4475578\",");
            //strData.Append("\"transform\": [1,0,0,1],");
            //strData.Append("\"feed\": \"1\",");
            //strData.Append("\"bkgd\": 0,");
            //strData.Append("\"min_sale_price\": \"1439.20\",");
            //strData.Append("\"paid\": 0},");
            //strData.Append("{");
            //strData.Append("\"visibility\": \"public\",");
            //strData.Append("\"paid_url\": \"http://www.polyvore.com/cgi/browse.things?uid=2779160\",");
            //strData.Append("\"thing_id\": \"90031173\",");
            //strData.Append("\"masking_policy\": \"default_yes\",");
            //strData.Append("\"a\": \"0.1364\",");
            //strData.Append("\"oa\": \"0.1364\",");
            //strData.Append("\"min_price\": null,");
            //strData.Append("\"state\": \"active\",");
            //strData.Append("\"y\": \"5.85189482206471\",");
            //strData.Append("\"max_sale_price\": null,");
            //strData.Append("\"url\": \"http://baidu.com/\",");
            //strData.Append("\"old_thing_id\": \"90031173\",");
            //strData.Append("\"sale_price\": null,");
            //strData.Append("\"description\": \"Bedroom\\r\\n#bedroom #text\",");
            //strData.Append("\"max_price\": null,");
            //strData.Append("\"imgurl\": \"images/mid/03.jpg\",");
            //strData.Append("\"type\": \"image\",");
            //strData.Append("\"price\": null,");
            //strData.Append("\"title\": \"Interior Text\",");
            //strData.Append("\"z\": \"6\",");
            //strData.Append("\"visible_ratio\": \"0.0137979008487535\",");
            //strData.Append("\"ow\": \"799\",");
            //strData.Append("\"w\": \"233.063666662686\",");
            //strData.Append("\"brand_id\": null,");
            //strData.Append("\"brand\": null,");
            //strData.Append("\"x\": 8,");
            //strData.Append("\"currency\": \"USD\",");
            //strData.Append("\"host_type\": \"other\",");
            //strData.Append("\"opacity\": 0,");
            //strData.Append("\"instock\": \"1\",");
            //strData.Append("\"category_id\": \"73\",");
            //strData.Append("\"h\": \"31.794667917688\",");
            //strData.Append("\"oh\": \"109\",");
            //strData.Append("\"displayurl\": \"baidu.com\",");
            //strData.Append("\"createdby\": \"2779160\",");
            //strData.Append("\"transform\": [1,0,0,1],");
            //strData.Append("\"feed\": 0,");
            //strData.Append("\"bkgd\": 0,");
            //strData.Append("\"min_sale_price\": null,");
            //strData.Append("\"paid\": \"1\" },");
            //strData.Append("{");
            //strData.Append("\"w\": \"182.509245020062\",");
            //strData.Append("\"transform\": [");
            //strData.Append("\"1\",0,0,\"1\"],");
            //strData.Append("\"dropHint\": \"Decor\",");
            //strData.Append("\"x\": \"258.34670579241\",");
            //strData.Append("\"state\": \"active\",");
            //strData.Append(" \"y\": 0,");
            //strData.Append("\"h\": \"123.71255878189\",");
            //strData.Append("\"type\": \"ph\",");
            //strData.Append("\"z\": \"7\",");
            //strData.Append("\"visible_ratio\": \"0.159014334072889\"");
            //strData.Append("}");
            //strData.Append("]},\"status\": {\"ok\": 1}}");
            //Response.Write(strData.ToString());
        }


        //private void GetTemplateById(int tid)
        //{
        //    Twee.Mgr.TemplateMgr mgr = new Twee.Mgr.TemplateMgr();
        //    Twee.Model.Template template = mgr.GetModel(tid);
        //    StringBuilder strData = new StringBuilder();
        //    strData.Append("{");
        //    strData.Append("\"template\": {");
        //    strData.Append("\"tid\": \"" + template.id + "\",");
        //    strData.Append("\"title\": \"" + template.title + "\",");
        //    strData.Append("\"imgurl\": \"" + template.imgurl + "\",");
        //    strData.Append("\"description\": \"" + template.description + "\",");
        //    strData.Append("\"user_type\": \"client\",");//*****从此开始为保留项，可选。用户类型:client=消费者，merchant=商家.....，用于筛选
        //    strData.Append("\"age\": \"41681509\",");
        //    strData.Append("\"state\": \"active\",");
        //    strData.Append("\"isOwner\": 0,");
        //    strData.Append("\"viewport\": null,");
        //    strData.Append("\"status_msg\": \"进入时底部可选信息提示\",");
        //    strData.Append("\"country\": \"zh-cn\",");
        //    strData.Append("\"occupation\": \"潮人\",");
        //    strData.Append("\"user_name\": \"asdf\",");
        //    strData.Append("\"object_class\": \"template\",");
        //    strData.Append("\"user_age\": \"248131569\",");
        //    strData.Append("\"user_state\": \"active\",");
        //    strData.Append("\"user_id\": \"27\",");
        //    strData.Append("\"invalid_items\": [],");
        //    strData.Append("\"items\": [");
        //    strData.Append("{");
        //    strData.Append("\"w\": \"164.748858447489\",");
        //    strData.Append("\"transform\": [");
        //    strData.Append("\"1\",0,0,\"1\"],");
        //    strData.Append("\"dropHint\": \"Art\",");
        //    strData.Append("\"x\": \"40.2511415525114\",");
        //    strData.Append("\"y\": \"59.6574810127238\",");
        //    strData.Append("\"h\": \"179.804020100502\",");
        //    strData.Append("\"type\": \"ph\",");
        //    strData.Append("\"z\": \"2\",");
        //    strData.Append("\"state\": \"active\",");
        //    strData.Append("\"visible_ratio\": \"0.208393875643999\"");
        //    strData.Append("},");
        //    strData.Append("{");
        //    strData.Append("\"w\": \"183.493503630194\",");
        //    strData.Append("\"transform\": [");
        //    strData.Append("\"1\",0,0,\"1\"],");
        //    strData.Append("\"dropHint\": \"Bedding\",");
        //    strData.Append("\"x\": \"257.362447182279\",");
        //    strData.Append("\"state\": \"active\",");
        //    strData.Append("\"y\": \"139.610613546336\",");
        //    strData.Append("\"h\": \"131.074200164027\",");
        //    strData.Append("\"type\": \"ph\",");
        //    strData.Append("\"z\": \"3\",");
        //    strData.Append("\"visible_ratio\": \"0.169133010169672\"");
        //    strData.Append("},{");
        //    strData.Append("\"w\": \"185.99428352689\",");
        //    strData.Append("\"transform\": [");
        //    strData.Append("\"1\",0,0,\"1\"],");
        //    strData.Append("\"dropHint\": \"Table\",");
        //    strData.Append("\"x\": \"254.866772779279\",");
        //    strData.Append("\"state\": \"active\",");
        //    strData.Append("\"y\": \"292.80757871222\",");
        //    strData.Append("\"h\": \"160.99225363961\",");
        //    strData.Append("\"type\": \"ph\",");
        //    strData.Append("\"z\": \"4\",");
        //    strData.Append("\"visible_ratio\": \"0.210438009103074\"");
        //    strData.Append("},");
        //    strData.Append("{");
        //    strData.Append("\"type\": \"image\",");
        //    strData.Append("\"x\": 0,");
        //    strData.Append("\"y\": \"267.994889325682\",");
        //    strData.Append("\"w\": \"239\",");
        //    strData.Append("\"h\": \"195.173594132029\",");
        //    strData.Append("\"z\": \"5\",");
        //    strData.Append("\"ow\": \"2048\",");
        //    strData.Append("\"oh\": \"1680\",");
        //    strData.Append("\"imgurl\": \"images/mid/02.jpg\",");
        //    strData.Append("\"thing_id\": \"85859236\",");
        //    strData.Append("\"title\": \"标题标题\",");
        //    strData.Append("\"description\": \"描述描述\",");
        //    strData.Append("\"url\": \"http://baidu.com/\",");
        //    strData.Append("\"price\": \"1799\",");
        //    strData.Append("\"displayurl\": \"ethanallen.com\",");
        //    strData.Append("\"visibility\": \"public\",	");
        //    strData.Append("\"paid_url\": null,");
        //    strData.Append("\"masking_policy\": \"default_yes\",");
        //    strData.Append("\"a\": \"0.8166\",");
        //    strData.Append("\"oa\": \"0.8203\",");
        //    strData.Append("\"min_price\": \"1799.00\",");
        //    strData.Append("\"state\": \"active\",");
        //    strData.Append("\"max_sale_price\": \"1839.20\",");
        //    strData.Append("\"old_thing_id\": \"85859236\",");
        //    strData.Append("\"sale_price\": \"1439.2\",");
        //    strData.Append("\"max_price\": \"2299.00\",");
        //    strData.Append("\"visible_ratio\": \"0.239222870161613\",");
        //    strData.Append("\"brand_id\": \"126015\",");
        //    strData.Append("\"brand\": \"Ethan Allen\",");
        //    strData.Append("\"currency\": \"USD\",");
        //    strData.Append("\"host_type\": \"store\",");
        //    strData.Append("\"opacity\": 0,");
        //    strData.Append("\"instock\": \"1\",");
        //    strData.Append("\"category_id\": \"126\",");
        //    strData.Append("\"createdby\": \"4475578\",");
        //    strData.Append("\"transform\": [1,0,0,1],");
        //    strData.Append("\"feed\": \"1\",");
        //    strData.Append("\"bkgd\": 0,");
        //    strData.Append("\"min_sale_price\": \"1439.20\",");
        //    strData.Append("\"paid\": 0},");
        //    strData.Append("{");
        //    strData.Append("\"visibility\": \"public\",");
        //    strData.Append("\"paid_url\": \"http://www.polyvore.com/cgi/browse.things?uid=2779160\",");
        //    strData.Append("\"thing_id\": \"90031173\",");
        //    strData.Append("\"masking_policy\": \"default_yes\",");
        //    strData.Append("\"a\": \"0.1364\",");
        //    strData.Append("\"oa\": \"0.1364\",");
        //    strData.Append("\"min_price\": null,");
        //    strData.Append("\"state\": \"active\",");
        //    strData.Append("\"y\": \"5.85189482206471\",");
        //    strData.Append("\"max_sale_price\": null,");
        //    strData.Append("\"url\": \"http://baidu.com/\",");
        //    strData.Append("\"old_thing_id\": \"90031173\",");
        //    strData.Append("\"sale_price\": null,");
        //    strData.Append("\"description\": \"Bedroom\\r\\n#bedroom #text\",");
        //    strData.Append("\"max_price\": null,");
        //    strData.Append("\"imgurl\": \"images/mid/03.jpg\",");
        //    strData.Append("\"type\": \"image\",");
        //    strData.Append("\"price\": null,");
        //    strData.Append("\"title\": \"Interior Text\",");
        //    strData.Append("\"z\": \"6\",");
        //    strData.Append("\"visible_ratio\": \"0.0137979008487535\",");
        //    strData.Append("\"ow\": \"799\",");
        //    strData.Append("\"w\": \"233.063666662686\",");
        //    strData.Append("\"brand_id\": null,");
        //    strData.Append("\"brand\": null,");
        //    strData.Append("\"x\": 8,");
        //    strData.Append("\"currency\": \"USD\",");
        //    strData.Append("\"host_type\": \"other\",");
        //    strData.Append("\"opacity\": 0,");
        //    strData.Append("\"instock\": \"1\",");
        //    strData.Append("\"category_id\": \"73\",");
        //    strData.Append("\"h\": \"31.794667917688\",");
        //    strData.Append("\"oh\": \"109\",");
        //    strData.Append("\"displayurl\": \"baidu.com\",");
        //    strData.Append("\"createdby\": \"2779160\",");
        //    strData.Append("\"transform\": [1,0,0,1],");
        //    strData.Append("\"feed\": 0,");
        //    strData.Append("\"bkgd\": 0,");
        //    strData.Append("\"min_sale_price\": null,");
        //    strData.Append("\"paid\": \"1\" },");
        //    strData.Append("{");
        //    strData.Append("\"w\": \"182.509245020062\",");
        //    strData.Append("\"transform\": [");
        //    strData.Append("\"1\",0,0,\"1\"],");
        //    strData.Append("\"dropHint\": \"Decor\",");
        //    strData.Append("\"x\": \"258.34670579241\",");
        //    strData.Append("\"state\": \"active\",");
        //    strData.Append(" \"y\": 0,");
        //    strData.Append("\"h\": \"123.71255878189\",");
        //    strData.Append("\"type\": \"ph\",");
        //    strData.Append("\"z\": \"7\",");
        //    strData.Append("\"visible_ratio\": \"0.159014334072889\"");
        //    strData.Append("}]},\"status\": {\"ok\": 1}}");

        //    Response.Write(strData.ToString());
        //}
    }
}












