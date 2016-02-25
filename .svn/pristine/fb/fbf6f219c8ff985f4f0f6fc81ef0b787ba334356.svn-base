using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twee.Mgr;
using Twee.Comm;
using AjaxPro;

namespace TweebaaWebApp.Mgr.userMgr
{
    public partial class usersEdit : System.Web.UI.Page
    {
        public string _sex = "[{value:'--请选择--',text:'--请选择--'}]";
        public string _setSex = string.Empty;
        public string _userId = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            Utility.RegisterTypeForAjax(typeof(usersEdit));
            if (string.IsNullOrEmpty(Request["userid"]))
                return;
            _userId = Request["userid"].ToString().Trim();

            var Sex = Twee.Comm.ConfigParamter.GenderDic;
            if (Sex != null && Sex.Count > 0)
            {
                StringBuilder st = new StringBuilder();
                foreach (var item in Sex)
                {
                    st.AppendFormat(",{0}value:'{2}',text:'{3}'{1}", "{", "}", item.Key, item.Value);
                }
                _sex = "[{value:'--请选择--',text:'--请选择--'}";
                _sex += st.ToString();
                _sex += "]";
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
                labName.Value = dr["username"]._ObjToString();
                labEmail.Value = dr["email"]._ObjToString();
                labPhone.Value = dr["phone"]._ObjToString();
                labBirthday.Value = dr["birthday"]._ObjToString();
                string sexVal = dr["gender"]._ObjToString();
                _setSex = "<script type='text/javascript'>$('#selSex').combobox('select','"+sexVal+"');</script>";
            }
        }

        [AjaxPro.AjaxMethod]
        public string userSave(string id, string name, string sex, string phone, string birthday, string pwd,string email)
        {
            var model = new Twee.Mgr.UserMgr().GetModel(Guid.Parse(id));
            model.email = email;
            model.username = name;
            model.gender =int.Parse( sex);
            model.pwd = PasswordHelper.ToUpMd5(pwd);
            model.birthday = DateTime.Parse(birthday);
            model.phone = phone;
            if (new Twee.Mgr.UserMgr().Update(model))
            {
                return "success";
            }
            else
            {
                return "fail";
            }

        }


    }
}