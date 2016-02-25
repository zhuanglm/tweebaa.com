using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using Twee.Comm;

namespace TweebaaWebApp.AjaxPages
{
    public partial class shareSerchAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // this.Response.Headers.Add("Access-Control-Allow-Origin", "*");//上线要去掉

            string price = "";   //price=100-200
            string color = "";   //color=#505050
            string catid = "";   //类别id
            int page = 1;        //页码
            string text = "";    //搜索关键词
           
            if (!string.IsNullOrEmpty(Request["color"]))
            {
                color = " colorvalue='" + Request["color"].ToString() + "'";
            }
            if (!string.IsNullOrEmpty(Request["price"]))
            {
                price = Request["price"].ToString();
            }
            if (!string.IsNullOrEmpty(Request["catid"]))
            {
                catid = Request["catid"].ToString() ;
            }
            if (!string.IsNullOrEmpty(Request["page"]))
            {
                page = Convert.ToInt32(Request["page"].ToString());
            }
            if (!string.IsNullOrEmpty(Request["text"]))
            {
                text = Request["text"].ToString();
                text = CommHelper.GetStrDecode(text); //供应方式
            }
            GetData(price, color,catid,text,page);
        }

        private void GetData(string price, string color,string catid,string prdname,int page)
        {
            catid = "CF196BB4-A3CD-4E99-AFDD-C6058CFEC8D9";

            //获取搜索颜色列表
            PrdColorMgr colorMgr = new PrdColorMgr();
            DataTable dtColor = colorMgr.GetColor(color).Tables[0];
            string colorInfo = JsonConvert.SerializeObject(dtColor);

            //设定叠图搜索价格区间

            StringBuilder sbStrPrice = new StringBuilder();
            sbStrPrice.Append("\"price\": { \"items\": [");
            sbStrPrice.Append("{ \"text\":\"<100元\",\"value\": \"100\" },");
            sbStrPrice.Append("{ \"text\": \"100-200元\",\"value\": \"100-200\"},");
            sbStrPrice.Append("{ \"text\": \"200-300元\",\"value\": \"200-300\"},");
            sbStrPrice.Append("{ \"text\": \"300-400元\",\"value\": \"300-400\"},");
            sbStrPrice.Append("{ \"text\": \"400-500元\",\"value\": \"400-500\"},");
            sbStrPrice.Append("{ \"text\": \"500-600元\",\"value\": \"500-600\"},");
            sbStrPrice.Append("{ \"text\": \"600-700元\",\"value\": \"600-700\"},");
            sbStrPrice.Append("{ \"text\": \"700-800元\",\"value\": \"700-800\"},");
            sbStrPrice.Append("{ \"text\": \"800-900元\",\"value\": \"800-900\"},");
            sbStrPrice.Append("{ \"text\": \"900-1000元\",\"value\": \"900-1000\"},");
            sbStrPrice.Append("{ \"text\": \"1000元以上\",\"value\": \"1000\"}");
            sbStrPrice.Append("]}");

            //产品列表
            SharePrdMgr sharePrdMgr = new SharePrdMgr();
            string where = " 1=1";
            if(price.Contains("-"))
            {
                string[] arrStr = price.Split('-');
                where += string.Format(" and p.saleprice>={0} and saleprice<={1} ", arrStr[0], arrStr[1]);
            }
            else if (price=="100")
	        {
                where += " and  p.saleprice<=100 ";
	        }
            else if (price == "1000")
            {
                where += " and  p.saleprice>=1000 ";
            }
            if (!string.IsNullOrEmpty(catid))
            {
                where += " and  p.cateGuid='"+catid+"' ";
            }
            if (!string.IsNullOrEmpty(prdname))
            {
                where += " and  p.name like '%"+prdname+"%";
            }

            DataSet ds = sharePrdMgr.GetListByPage(where, " addtime desc", 0, 10);
            string prdInfo = "";
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dtInfo = ds.Tables[0];
                prdInfo = JsonConvert.SerializeObject(ds.Tables[0]);
            }
           //string pages = "\"pageHTML\":\"<a href=\"#\" class=\"up\">&lt;</a><a href=\"#\">1</a><a href=\"#\">2</a><a href=\"#\" class=\"on\">3</a><a href=\"#\">4</a><a href=\"#'>5</a><a href=\"#\">6</a><a href=\"#\">7</a><a href=\"#\">8</a><a href=\"#\" class=\"down\">&gt;</a>\"";

            StringBuilder sbPage = new StringBuilder();
            sbPage.Append("\"pageHTML\":" + "\" <a href='#'  class='up'>&lt;</a>");
            sbPage.Append("<a href='#'>1</a>");
            sbPage.Append("<a href='#'>2</a>");
            sbPage.Append("<a href='#'>3</a>");
            sbPage.Append("<a href='#'>4</a>");
            sbPage.Append("<a href='#'>5</a>\"");

            string pages = sbPage.ToString();

           
            StringBuilder data = new StringBuilder();
            data.Append("{");
            data.Append("\"status\":{\"ok\": 1  },");
            data.Append("\"result\":{\"type\": \"thing\",\"total_pages\": 10,\"page\":1,\"more_pages\":1,\"total_results\":\"100\",\"filters\":{\"text_search\":true,");
            data.Append("\"catid\":" +"\"" +catid + "\",");
            data.Append("\"color\":{\"items\":" + colorInfo + "},");           
            data.Append(sbStrPrice.ToString() + "},");
            data.Append("\"items\":" + prdInfo + ",");          
            data.Append(pages);
            data.Append("}}");

            string resu = data.ToString();
            Response.Write(resu);
            //string prdInfo = JsonConvert.SerializeObject(ds.Tables[0]);  
            // {
            //  "thing_id": "125145656",		//物品ID
            //  "imgurl": "images/80x80.jpg",	//缩略图
            //  "img_mask": "http://ak2.polyvoreimg.com/cgi/img-thing/mask/1/size/orig/tid/125915047.png",	//透底图地址
            //  "img_opaque": "http://ak2.polyvoreimg.com/cgi/img-thing/orig/1/size/orig/tid/125915047.png",	//非透底图地址
            //  "url": "http://www.baidu.com/",	//点击查看网址
            //  "object_class": "editoritem",	//分类，editoritem=编辑选择，useritem=用户上传
            //  "title": "猫盒子",		//标题
            //  "price": "59.99",	//价格
            //  "ow": "64",	//原始图片宽高
            //  "w": "67",	//缩略图宽高
            //  "brand_id": "1234",	//品牌ID
            //  "h": "102",		//缩略图宽高
            //  "oh": "124",	//原始图片宽高
            //  "displayurl": "baidu.com",	//显示出的网址
            //  "seo_title": "box_for_cat",	//SEO标题用于TITLE等
            //  "display_price": "RMB60",	//显示价格
            //  "masking_policy": "default_yes"
            //}



        }
    }

}