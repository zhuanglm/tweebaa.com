using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// regDayTemp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RegDayTemp
	{
        public RegDayTemp()
		{}
		#region Model
		private Guid _userguid;
		private int? _regday;
		/// <summary>
		/// 
		/// </summary>
		public Guid userguid
		{
			set{ _userguid=value;}
			get{return _userguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? regDay
		{
			set{ _regday=value;}
			get{return _regday;}
		}
		#endregion Model

	}
}

