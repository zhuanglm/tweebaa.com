using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Comm;
using System.Text;

namespace TweebaaWebApp.Mgr.userMgr
{
    public partial class usersView : System.Web.UI.Page
    {
        public string _userId = string.Empty;

        public string _publishStatus = "[{value:'--请选择--',text:'--请选择--'}]";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request["id"]))
                return;
            _userId = Request["id"].Trim();

            var Publishstatus = Twee.Comm.ConfigParamter.PrdSateDic;
            if (Publishstatus != null && Publishstatus.Count > 0)
            {
                StringBuilder st = new StringBuilder();
                foreach (var item in Publishstatus)
                {
                    st.AppendFormat(",{0}value:'{2}',text:'{3}'{1}", "{", "}", item.Key, item.Value);
                }
                _publishStatus = "[{value:'--请选择--',text:'--请选择--'}";
                _publishStatus += st.ToString();
                _publishStatus += "]";
            }

            if (!IsPostBack)
            {
                BindBasicInfo();
            }

        }

        private void BindBasicInfo()
        {
            UserMgr user = new UserMgr();
            DataTable dt = user.MgeGetList(" u.guid='" + _userId + "'");
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                labName.Text= dr["username"]._ObjToString();
                labEmail.Text = dr["email"]._ObjToString();
                labPhone.Text = dr["phone"]._ObjToString();
                labSex.Text =Gender( dr["gender"]._ObjToString());
                labBirthday.Text = dr["birthday"]._ObjToString();
                labLoginTime.Text = dr["acttime"]._ObjToString();
                labRegTime.Text = dr["regtime"]._ObjToString();
            }
        }

        private string Gender(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "不明";
            if (str == ((int)Twee.Comm.ConfigParamter.Gender.male).ToString())
                return "男";
            if (str == ((int)Twee.Comm.ConfigParamter.Gender.female).ToString())
                return "女";
            if (str == ((int)Twee.Comm.ConfigParamter.Gender.unknow).ToString())
                return "不明";
            return string.Empty;
        }

    }
}