using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Twee.Comm;

namespace TweebaaWebApp2.Events.Tweebot
{
    public partial class Vote : System.Web.UI.Page
    {
        public string sHtml = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder strSql = new StringBuilder();
            if (string.IsNullOrEmpty(Request["action"]))
            {
                strSql.Append("select tweebot_video_id,video_title,video_url,create_time,total_vote,u.username from wn_tweebot_video s left join wn_user u");
                strSql.Append(" on s.userGuid=u.guid");
            }
            else
            {
                //keyword search 
                if(Request["action"].ToString()=="search"){
                    string strKeyword = Request.Form["txtKeywords"];
                    strKeyword = Twee.Comm.CommUtil.Quo(strKeyword);
                    strSql.Append("select tweebot_video_id,video_title,video_url,create_time,total_vote,u.username from wn_tweebot_video s left join wn_user u");
                    strSql.Append(" on s.userGuid=u.guid");
                    strSql.Append(" where video_title like '%" + strKeyword + "%'");
                }
            }


            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string  video_url = ds.Tables[0].Rows[i]["video_url"].ToString();;
                int n = video_url.LastIndexOf(".");
                var img_url = "";
                if (video_url.Length < 2)
                {
                    img_url = "https://www.tweebaa.com/images/no_thumbnail.png";
                }
                else
                {
                    img_url = "https://www.tweebaa.com/upload/VideoImg/" + video_url.Substring(0, n) + ".jpg";
                }
                 
                //remove extennsion
                sHtml = sHtml + "<li class=\"cbp-item buynow\">";
                sHtml = sHtml + "<a href=\"#\" onclick=\"window.location.href='/Events/Tweebot/vote_details.aspx?id=" + ds.Tables[0].Rows[i]["tweebot_video_id"].ToString() + "'\" class=\"cbp-caption cbp-lightbox\" data-title=\"" + ds.Tables[0].Rows[i]["video_title"].ToString() + "\">";
                sHtml = sHtml + "<div class=\"cbp-caption-defaultWrap\">";
                sHtml = sHtml + "<img src=\"" + img_url + "\" alt=\"\" width=\"100%\">";
                sHtml = sHtml + "</div>";
                sHtml = sHtml + "<div class=\"cbp-caption-activeWrap\">";
                sHtml = sHtml + "<div class=\"cbp-l-caption-alignCenter\">";
                sHtml = sHtml + "<div class=\"cbp-l-caption-body\">";
                sHtml = sHtml + "<div>";
                sHtml = sHtml + "<button class=\"btn rounded btn-lg btn-twitter fa-fixed\"><i class=\"fa fa-twitter\"></i> </button>";
                sHtml = sHtml + "<button class=\"btn rounded btn-lg btn-facebook fa-fixed\"><i class=\"fa fa-facebook\"></i></button>";
                sHtml = sHtml + "<button class=\"btn rounded btn-lg btn-youtube fa-fixed\"><i class=\"fa fa fa-youtube-play\"></i></button>";
                sHtml = sHtml + "</div>";
                sHtml = sHtml + "</div>";
                sHtml = sHtml + "</div>";
                sHtml = sHtml + "</div>";
                sHtml = sHtml + "</a>";
                sHtml = sHtml + "<div class=\"product-description\">";
                sHtml = sHtml + "<h3><a href=\"/Events/Tweebot/vote_details.aspx?id=" + ds.Tables[0].Rows[i]["tweebot_video_id"].ToString() + "\">"+ ds.Tables[0].Rows[i]["video_title"].ToString() +"</a></h3>";
                sHtml = sHtml + "<p class=\"cbp-l-caption-desc\">Submitter: " + ds.Tables[0].Rows[i]["username"].ToString() + "  <br> Submit Date: " + ds.Tables[0].Rows[i]["create_time"].ToString() ;
               // sHtml = sHtml + "<button class=\"btn btn-default\" type=\"button\" onclick=\"window.location.href='/Events/Tweebot/vote_details.aspx?id=" + ds.Tables[0].Rows[i]["tweebot_video_id"].ToString() + "'\"> WATCH </button> <button class=\"btn btn-default\" type=\"button\" onclick=\"window.location.href='/Events/Tweebot/vote_details.aspx?id=" + ds.Tables[0].Rows[i]["tweebot_video_id"].ToString() + "'\">VOTE NOW</button>";
                sHtml = sHtml + "<br>Votes:" + ds.Tables[0].Rows[i]["total_vote"].ToString() + "</p> ";
                sHtml = sHtml + "</div>";
                sHtml = sHtml + "</li>";
                /*
                sHtml = sHtml + "<li class=\"cbp-item motion\">";
                sHtml = sHtml + "<a href=\"/Events/Tweebot/vote_details.aspx?id=" + ds.Tables[0].Rows[i]["tweebot_video_id"].ToString() + "\" class=\"cbp-caption\">";
                sHtml = sHtml + "<div class=\"cbp-caption-defaultWrap\">";
                sHtml = sHtml + "<img src=\"" + img_url + "\" alt=\"\" width=\"100%\">";
                sHtml = sHtml + "</div>";
                sHtml = sHtml + "                <div class=\"cbp-caption-activeWrap\">";
                sHtml = sHtml + "                    <div class=\"cbp-l-caption-alignCenter\">";
                sHtml = sHtml + "                        <div class=\"cbp-l-caption-body\">";
                sHtml = sHtml + "                            <div class=\"cbp-l-caption-text\">" + ds.Tables[0].Rows[i]["video_title"].ToString() + "</div>";
                sHtml = sHtml + "                            <p class=\"cbp-l-caption-desc\">Uploader: " + ds.Tables[0].Rows[i]["username"].ToString() + " <br> Submit Time: " + ds.Tables[0].Rows[i]["create_time"].ToString() + "</p>";
                sHtml = sHtml + "                            <button class=\"btn btn-default\" type=\"button\">Vote</button>";
                sHtml = sHtml + "                            <p class=\"cbp-l-caption-desc\">" + ds.Tables[0].Rows[i]["total_vote"].ToString() + " voted</p>";
                sHtml = sHtml + "                            <hr>";
                sHtml = sHtml + "                            <div>";
                sHtml = sHtml + "                           <button class=\"btn rounded btn-xs btn-twitter fa-fixed\"><i class=\"fa fa-twitter\"></i> </button>";
                sHtml = sHtml + "                           <button class=\"btn rounded btn-xs btn-facebook fa-fixed\"><i class=\"fa fa-facebook\"></i></button>";
                sHtml = sHtml + "                           <button class=\"btn rounded btn-xs btn-youtube fa-fixed\"><i class=\"fa fa fa-youtube-play\"></i></button>";
                sHtml = sHtml + "                           </div>";
                sHtml = sHtml + "                        </div>";
                sHtml = sHtml + "                    </div>";
                sHtml = sHtml + "                </div>";
                sHtml = sHtml + "</a>";
                sHtml = sHtml + "</li>";
                 * */
            }
        }
    }
}