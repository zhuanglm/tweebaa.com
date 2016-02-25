using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace TweebaaWebApp2.Events.BugsReport
{
    public partial class BugsDetails : TweebaaWebApp2.MasterPages.BasePage
    {
        public string bugs_id;
        private Guid? userGuid;
        public string _userid = string.Empty;
        public string _persent = string.Empty; //根据用户等级取分享比例
        public string _popbox = "block;";
        public string _admin_html="";

        protected void Page_Load(object sender, EventArgs e)
        {

            bugs_id = Request.QueryString["id"];
            bool isLogion = CheckLogion(out userGuid);

            if (null != userGuid)
            {
                _popbox = "none;";
                _userid = userGuid.ToString();
                var persent = new Twee.Mgr.UserGradeCalMgr().GetUserGrade(userGuid).Rows[0]["sratio"];
                if (null != persent && !Convert.IsDBNull(persent))
                    _persent = (((int)persent) / 1000).ToString();

                // 7dc741b1-998b-4791-a047-65a9e3a4087f Lance
                // eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8  
                if ("eff4dca6-fedc-4bd9-bbe5-79dec2bb39d8" == _userid || "7dc741b1-998b-4791-a047-65a9e3a4087f" == _userid)
                {
                    StringBuilder str = new StringBuilder();
                    str.Append("<table><tr><td>Reward Points:&nbsp;<input type='text' id='points_0' />&nbsp;");
                    str.Append("<a href='javascript:void(0)'class='read_post' onclick='give_points(" + bugs_id + ",0,1)'>Give Points</a> </td></tr>");
                    str.Append("<tr><td><a href='javascript:void(0)'class='read_post' onclick='not_a_bugs(" + bugs_id + ",1)'>Not A Bug</a></td></tr>");
                    str.Append("<tr><td><a href='javascript:void(0)' class='read_post'onclick='Dulplicate(" + bugs_id + ",1)'>Dulplicate</a></td></tr>");
                    str.Append("<tr><td><a href='javascript:void(0)'class='read_post' onclick='fixed(" + bugs_id + ",1)'>Fixed</a></td></tr>");
                    str.Append("<tr><td><a href='javascript:void(0)' class='read_post'onclick='Closed(" + bugs_id + ",1)'>Closed</a></td></tr>");                       
                    str.Append("</table>");

                    _admin_html = str.ToString();
                }
            }
            else
            {
                _userid = "";
                _persent = "";

            }
        }
    }
}