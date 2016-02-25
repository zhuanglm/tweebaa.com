using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Twee.Comm;
using System.Text;


namespace TweebaaWebApp2.Events.Tweebot
{
    public partial class vote_details : TweebaaWebApp2.MasterPages.BasePage
    {
        public string gs_video_title;
        public string gs_video_url;
        public string gs_img_url;
        public string gs_video_description;
        public string gs_submiter;
        public string gs_lastupdate;

        private Guid? userGuid;
        public string _userid = string.Empty;
        public bool gs_IsShowVote;
        public int video_id; 
        protected void Page_Load(object sender, EventArgs e)
        {
             video_id=Request["id"].Trim().ToInt();

             StringBuilder strSql = new StringBuilder();
             strSql.Append("select tweebot_video_id,video_title,video_description,video_url,create_time,total_vote,u.username from wn_tweebot_video s left join wn_user u");
            strSql.Append(" on s.userGuid=u.guid where tweebot_video_id="+video_id.ToString());

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
           // for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            if(ds==null){
                //load error ?
                var response = base.Response;
                response.Redirect("/Events/Tweebot/VideoNotFound.aspx");

            }else{
                gs_video_title = ds.Tables[0].Rows[0]["video_title"].ToString();
                gs_video_url = ds.Tables[0].Rows[0]["video_url"].ToString();
                gs_video_description = ds.Tables[0].Rows[0]["video_description"].ToString();
                gs_submiter = ds.Tables[0].Rows[0]["username"].ToString();
                gs_lastupdate = ds.Tables[0].Rows[0]["create_time"].ToString();

                string video_url = gs_video_url;
                int n = video_url.LastIndexOf(".");
                var img_url = "";
                if (video_url.Length < 2)
                {
                    img_url = "/images/no_thumbnail.png";
                }
                else
                {
                    img_url = "/upload/VideoImg/" + video_url.Substring(0, n) + ".jpg";
                }
                gs_img_url = img_url;
            }

             bool isLogion = CheckLogion(out userGuid);

             if (null != userGuid)
             {
                 _userid = userGuid.ToString();
                 gs_IsShowVote = true;
             }
             else
             {
                 gs_IsShowVote = false;
             }

        }
    }
}