using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// prdSpec:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PrdSpec
	{
        public PrdSpec()
		{}
		#region Model
		private Guid _specguid;
		private Guid _prdguid;
		private string _colorguid;
		private string _specname;
		private string _specvalue;
		private int _idx;
		private DateTime? _edttime= DateTime.Now;
		private int? _number;
		private decimal? _price;
		/// <summary>
		/// 
		/// </summary>
		public Guid specguid
		{
			set{ _specguid=value;}
			get{return _specguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid prdguid
		{
			set{ _prdguid=value;}
			get{return _prdguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string colorguid
		{
			set{ _colorguid=value;}
			get{return _colorguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specname
		{
			set{ _specname=value;}
			get{return _specname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specvalue
		{
			set{ _specvalue=value;}
			get{return _specvalue;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int idx
		{
			set{ _idx=value;}
			get{return _idx;}
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
		public int? number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		#endregion Model

	}
}

