using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// reviewSuccessCountTemp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ReviewSuccessCountTemp
	{
        public ReviewSuccessCountTemp()
		{}
		#region Model
		private Guid _userguid;
		private int? _reviewsuccesscount;
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
		public int? reviewSuccessCount
		{
			set{ _reviewsuccesscount=value;}
			get{return _reviewsuccesscount;}
		}
		#endregion Model

	}
}

