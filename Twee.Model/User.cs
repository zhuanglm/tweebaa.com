using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    public class User
    {
        #region Model
        private Guid _guid;
        private string _pwd;
        private string _username;
        private int? _gender;
        private DateTime? _birthday;
        private DateTime? _regtime = DateTime.Now;
        private DateTime? _acttime = DateTime.Now;
        private DateTime? _edttime = DateTime.Now;
        private int? _wnstat;
        private string _email;
        private string _phone;
        private string _paymentno;
        private int? _pwdstrength;
        private string _headimg;
        private int? _jobid;
        private int? _countryid;
        private int? _knowwayid;
        private string _tuijieEmail;
        private bool? _consent;
        private int? _supplypermission;

        /*
         * knowwayid =99 Mobile APP
         * knowwayid = 100 Facebook
         * knowwayid = 101 Twitter
         */
        public int? knowwayid
        {
            set { _knowwayid = value; }
            get { return _knowwayid; }
        }

        public string tuijieEmail
        {
            set { _tuijieEmail = value; }
            get { return _tuijieEmail; }
        }


        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid guid
        {
            set { _guid = value; }
            get { return _guid; }
        }
        /// <summary>
        /// 登录密码
        /// </summary>
        public string pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 等级
        /// </summary>
        public int? gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime? regtime
        {
            set { _regtime = value; }
            get { return _regtime; }
        }
        /// <summary>
        /// 最近登录时间
        /// </summary>
        public DateTime? acttime
        {
            set { _acttime = value; }
            get { return _acttime; }
        }
        /// <summary>
        /// 最后编辑时间
        /// </summary>
        public DateTime? edttime
        {
            set { _edttime = value; }
            get { return _edttime; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int? wnstat
        {
            set { _wnstat = value; }
            get { return _wnstat; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 支付账号
        /// </summary>
        public string paymentno
        {
            set { _paymentno = value; }
            get { return _paymentno; }
        }
        /// <summary>
        /// 代码安全等级
        /// </summary>
        public int? pwdstrength
        {
            set { _pwdstrength = value; }
            get { return _pwdstrength; }
        }
        /// <summary>
        /// 头像
        /// </summary>
        public string headimg
        {
            set { _headimg = value; }
            get { return _headimg; }
        }

        /// <summary>
        /// 职业
        /// </summary>
        public int? jobid
        {
            set { _jobid = value; }
            get { return _jobid; }
        }

        /// <summary>
        /// 国家
        /// </summary>
        public int? countryid
        {
            set { _countryid = value; }
            get { return _countryid; }
        }

        /// <summary>
        /// Consent
        /// </summary>
        public bool? consent
        {
            set { _consent = value; }
            get { return _consent; }
        }

        /// <summary>
        /// supplu permission in the member center
        /// </summary>
        public int? supplypermission
        {
            set { _supplypermission = value; }
            get { return _supplypermission; }
        }


        #endregion Model
    }
}
