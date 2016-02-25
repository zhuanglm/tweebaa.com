using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// prdCate:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PrdCate
	{
        public PrdCate()
		{}
		#region Model
		private Guid _guid;
		private string _name;
		private int? _layer;
		private Guid _prtguid;
		private int? _idx;
		private string _icos;
		private int? _wnstate;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? layer
		{
			set{ _layer=value;}
			get{return _layer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid prtGuid
		{
			set{ _prtguid=value;}
			get{return _prtguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? idx
		{
			set{ _idx=value;}
			get{return _idx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string icos
		{
			set{ _icos=value;}
			get{return _icos;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? wnstate
		{
			set{ _wnstate=value;}
			get{return _wnstate;}
		}
		#endregion Model

	}
}

