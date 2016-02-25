using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TweebaaWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt =Convert.ToDateTime((Convert.ToDateTime("2014-12-18 17:16:09.190") - DateTime.Now));
            Response.Write(dt.ToString());


    //     string conStr = ConfigurationManager.ConnectionStrings["mytest_str"].ConnectionString;
    //    SqlConnection conn = new SqlConnection(conStr);
    //    SqlCommand cmd = new SqlCommand("select * from jg_fund", conn);
    //    //为cmd创建sql依赖
    //    SqlCacheDependency sqldepandendy = new SqlCacheDependency(cmd);
    //    conn.Open();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    DataSet ds=new DataSet();
    //    da.Fill(ds);
    //    da.Dispose();
    //    this.GridView1.DataSource = ds;
    //    this.GridView1.DataBind();
    //    conn.Close();
    //    //使页面缓存和sql缓存相关联，当数据库数据变化时页面缓存过期。当然也可不使用页面缓存，只用数据缓存。
    //    Response.AddCacheDependency(sqldepandendy);
    //    /*设置页面缓存*/
    //    Response.Cache.SetValidUntilExpires(true);//指定ASP.NET 缓存是否应忽略由使缓存无效的客户端发送的HTTP Cache-Control 标头。
    //    Response.Cache.SetExpires(DateTime.Now.AddMinutes(5));
    //    Response.Cache.SetCacheability(HttpCacheability.Public);
    //    /*
    //     *注：
    //     *   （1）Response.Cache.SetValidUntilExpires(true);指定ASP.NET 缓存是否应忽略由使缓存无效的客户端发送的HTTP Cache-Control 标头。
    //     *   当使用了高级<%@ OutputCache - %> 页指令时，SetValidUntilExpires 方法将被自动设置为true。
    //     *   之所以提供此方法，是因为某些浏览器在刷新页视图时会将HTTP 缓存无效标头发送到Web 服务器并从缓存中收回该页。
    //     *   当validUntilExpires 参数为true 时，ASP.NET 会忽略缓存无效标头，而该页将保留在缓存中直到过期为止。
    //     *   （2）Response.Cache.SetCacheability(HttpCacheability.Public);将Cache-Control 标头设置为HttpCacheability 值之一。
    //     *   （3）实现的效果是：对查询进行缓存，直到数据库中相关数据改变或页面缓存过期（分钟过期一次）。
    //     */
    //}
               
        }
    }
}