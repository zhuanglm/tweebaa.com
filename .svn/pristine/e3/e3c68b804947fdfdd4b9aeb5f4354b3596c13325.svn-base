using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using System.Reflection;


namespace TweebaaWebApp
{
public partial class study : System.Web.UI.Page
{ 
ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
protected void Page_Load(object sender, EventArgs e)
{
//try
//{
//a(); 
//}
//catch (Exception ex)
//{
//Response.Write(ex.Message+"<br/>");

//Response.Write(ex);

//}
//log.Error("error", new Exception("发生了一个异常"));
//Server.Transfer("~/error.aspx?id=1");
}

protected void btn1_click(object sender, EventArgs e)
{
decimal weit = Convert.ToDecimal(txt1.Text);//重量
decimal meike = Convert.ToDecimal(txt2.Text);//每克续重费
decimal a = 50;
decimal b = 0.09M;
txt3.Text = ((weit -a ) * b + 13).ToString()+" 元";
}

protected void btn2_click(object sender, EventArgs e)
{
decimal weit = Convert.ToDecimal(txt11.Text);//重量
decimal meike = Convert.ToDecimal(txt22.Text);//每克费用   
txt33.Text = (weit * meike + 8).ToString() + " 元";
}

private void a()
{
try
{
int a = Convert.ToInt32("");
}
catch (Exception ex)
{

throw new Exception("ddddddddddd",ex);
}
}
}
}






















//{ "post_share": 1,  "userid": 1234,  "id": null,  "basedon_tid": 3,  "title": "标题标题",  "description": "描述", "category": ["a类","a-a类","a-a-a类"  ],  "items": [{"x": 40,"y": 59,"w": 165,"h": 179,"z": "2","transform": ["1","0","0","1"],"type": "ph","dropHint": "Art","content": {"x": 0,"y": 17,"w": 165,"h": 145,"type": "thing","thing_id": "8d4da026-c517-4b2a-851f-f4a72e292b08"}},   {"x": 258,"y": 0,"w": 183,"h": 124,"z": "2","transform": ["1","0","0","1"],"type": "ph","dropHint": "Decor","content": {"x": 60,"y": 0,"w": 64,"h": 124,"type": "thing",
//"thing_id": "8d4da026-c517-4b2a-851f-f4a72e292b08"}}]}
