using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using System.Text;

namespace TweebaaWebApp2.AjaxPages
{
    /// <summary>
    /// 叠图：产品类别、背景列表（共用）
    /// </summary>
    public partial class picCatAjax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Response.Headers.Add("Access-Control-Allow-Origin", "*");//上线要去掉
            GetData();
        }

        private void GetData()
        {
            Twee.Mgr.PrdCateMgr mgr=new Twee.Mgr.PrdCateMgr();
            Twee.Mgr.PicbgMgr bgMgr=new Twee.Mgr.PicbgMgr();
            DataSet ds = mgr.GePicCate("");
            DataSet ds2 = bgMgr.GetAllList();
            StringBuilder data = new StringBuilder();
            if (ds!=null&&ds.Tables.Count>0)
	        {
		        string cateInfo = JsonConvert.SerializeObject(ds.Tables[0]);
	            data.Append("{");
                data.Append("\"show_promoted_items\":1,");
                data.Append("\"max_set_items\":50,");
                data.Append("\"categories\":{\"类别\":{");
                data.Append("\"items\":" + cateInfo);
                if (ds2!=null&&ds2.Tables.Count>0)
	            {
                    string bgInfo = JsonConvert.SerializeObject(ds2.Tables[0]);
                    data.Append("}," + "\"装饰元素\":{");
                    data.Append("\"items\":" + bgInfo);                  
	            }   
                else
	            {
                    data.Append("}");
	            }
                data.Append("}}}");    
            }
            Response.Clear();
            Response.Write(data.ToString());      
        }


    }
}