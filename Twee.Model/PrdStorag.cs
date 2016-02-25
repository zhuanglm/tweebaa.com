using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// prdStorag:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PrdStorag
	{
        public PrdStorag()
		{}
		#region Model
		private Guid _psguid;
		private Guid _prdguid;
		private Guid _storagguid;
		private int? _number;
		private int? _promptnumber;
        private string  _prostoreinfo;
        private int? _ruleid;

        public int? ruleid
        {
            set { _ruleid = value; }
            get { return _ruleid; }
        }

        public string prostoreinfo
        {
            set { _prostoreinfo = value; }
            get { return _prostoreinfo; }
        }
		/// <summary>
		/// 
		/// </summary>
		public Guid psGuid
		{
			set{ _psguid=value;}
			get{return _psguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid prdGuid
		{
			set{ _prdguid=value;}
			get{return _prdguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid storagGuid
		{
			set{ _storagguid=value;}
			get{return _storagguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? promptNumber
		{
			set{ _promptnumber=value;}
			get{return _promptnumber;}
		}
		#endregion Model

	}
}

