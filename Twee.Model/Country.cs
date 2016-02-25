using System;
namespace Twee.Model
{
	/// <summary>
	/// wn_country:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Country
	{
        public Country()
		{}
		#region Model
		private int _id;
		private string _country;
		private string _txt1;
		private string _txt2;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string txt1
		{
			set{ _txt1=value;}
			get{return _txt1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string txt2
		{
			set{ _txt2=value;}
			get{return _txt2;}
		}
		#endregion Model

	}
}

