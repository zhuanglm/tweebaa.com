using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Comm;
using System.Data;

namespace TweebaaWebApp.Home
{
    public partial class HomeShare2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 Guid? userGuid = CommUtil.IsLogion();
                 if (userGuid != null)
                 {
                     Twee.Mgr.ShareMgr mgr = new Twee.Mgr.ShareMgr();
                     DataTable dt = mgr.GetShareCounByType(userGuid.ToString());


                     var listType = dt.AsEnumerable().Select(t => t.Field<string>("sharetype")).ToList();
                     foreach (DataRow dr in dt.Rows)
                     {
                         string type = dr[0].ToString();
                         if (type=="facebook")
                         {
                             labFacebook.Text = dr["shareCount"].ToString()+" / " + dr["visitCount"].ToString()+" / " + dr["buyCount"].ToString();
                         }
                         if (type == "google")
                         {
                             labGoogle.Text = dr["shareCount"].ToString() + " / " + dr["visitCount"].ToString() + " / " + dr["buyCount"].ToString();
                         }
                         if (type == "twitter")
                         {
                             labTwitter.Text = dr["shareCount"].ToString() + " / " + dr["visitCount"].ToString() + " / " + dr["buyCount"].ToString();
                         }
                         if (type == "pinterest")
                         {
                             labPintest.Text = dr["shareCount"].ToString() + " / " + dr["visitCount"].ToString() + " / " + dr["buyCount"].ToString();
                         }
                         if (type == "email")
                         {
                             labEmail.Text = dr["shareCount"].ToString() + " / " + dr["visitCount"].ToString() + " / " + dr["buyCount"].ToString();
                         }
                         
                     }
                     //if (listType.Contains("facebook"))
                     //{
                         
                     //}
                     //if (listType.Contains("google"))
                     //{

                     //}
                     //if (listType.Contains("twitter"))
                     //{
                         
                     //}
                     //if (listType.Contains("pinterest"))
                     //{

                     //}
                     //if (listType.Contains("email"))
                     //{

                     //}
                   
                
                 }
            }
        }
    }
}