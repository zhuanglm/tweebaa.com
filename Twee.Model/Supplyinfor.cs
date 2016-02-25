using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// supplyinfor:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Supplyinfor
	{
        public Supplyinfor()
		{}
		#region Model
		private Guid _guid;
		private Guid _prtguid;
		private DateTime? _edttime= DateTime.Now;
		private string _typelist;
		private string _companyname;
		private string _companyurl;
		private string _industry;
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
		/// 
		/// </summary>
		public DateTime? edttime
		{
			set{ _edttime=value;}
			get{return _edttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string typelist
		{
			set{ _typelist=value;}
			get{return _typelist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyname
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string companyurl
		{
			set{ _companyurl=value;}
			get{return _companyurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string industry
		{
			set{ _industry=value;}
			get{return _industry;}
		}
		#endregion Model

	}
}

