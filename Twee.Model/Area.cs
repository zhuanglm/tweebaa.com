using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// Area:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Area
	{
		public Area()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _parentid;
		private string _fullid;
		private int? _grade;
		private bool _underlingflag= false;
		private int? _sequence;
		private string _code;
		private string _cityid;
		private string _provinceid;
		private int? _areaflag;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ParentID
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FullID
		{
			set{ _fullid=value;}
			get{return _fullid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool UnderlingFlag
		{
			set{ _underlingflag=value;}
			get{return _underlingflag;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Sequence
		{
			set{ _sequence=value;}
			get{return _sequence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cityId
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string provinceId
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 1华东地区2华北东北3华南西南4华中西北港澳台
		/// </summary>
		public int? areaflag
		{
			set{ _areaflag=value;}
			get{return _areaflag;}
		}
		#endregion Model

	}
}

