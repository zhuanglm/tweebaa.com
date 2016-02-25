using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// useraddress:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Useraddress
	{
        public Useraddress()
		{}
		#region Model
		private Guid _guid;
		private Guid _prtguid;
        private Guid _userguid;
		private int? _provinceid;
		private int? _cityid;
        private string _city;
		private int? _countyid;
		private string _zip;
		private string _address;
        private string _address2;
		private string _username;
        private string _lastName;
		private string _phone;
		private string _tel;
		private int? _isfirst;
		private DateTime? _addtime= DateTime.Now;
        private string _proName;//省名
        private string _cityName;//市名
        private string _email;
        /// <summary>
        /// 
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 省名
        /// </summary>
        public string proName
        {
            set { _proName = value; }
            get { return _proName; }
        }
        /// <summary>
        /// 市名
        /// </summary>
        public string cityName
        {
            set { _cityName = value; }
            get { return _cityName; }
        }
		/// <summary>
		/// 
		/// </summary>
		public Guid guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid prtguid
		{
			set{ _prtguid=value;}
			get{return _prtguid;}
		}
        /// <summary>
        /// 地址所属用户
        /// </summary>
        public Guid userguid
        {
            set { _userguid = value; }
            get { return _userguid; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int? provinceid
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cityid
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int? countyid
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zip
		{
			set{ _zip=value;}
			get{return _zip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string address2
        {
            set { _address2 = value; }
            get { return _address2; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string lastName
        {
            set { _lastName = value; }
            get { return _lastName; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isfirst
		{
			set{ _isfirst=value;}
			get{return _isfirst;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

