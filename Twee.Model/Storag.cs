using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// storag:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Storag
	{
        public Storag()
		{}
		#region Model
		private Guid _storagguid;
		private string _storagname;
		private Guid _belongarea;
		private string _sendarea;
		private string _remarktxt;
		private int? _number;
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
		public string storagName
		{
			set{ _storagname=value;}
			get{return _storagname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid belongArea
		{
			set{ _belongarea=value;}
			get{return _belongarea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sendArea
		{
			set{ _sendarea=value;}
			get{return _sendarea;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remarktxt
		{
			set{ _remarktxt=value;}
			get{return _remarktxt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? number
		{
			set{ _number=value;}
			get{return _number;}
		}
		#endregion Model

	}
}

