using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// reviewgradeparam:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Reviewgradeparam
	{
        public Reviewgradeparam()
		{}
		#region Model
		private Guid _guid;
		private int _grade;
		private int _integral;
		private int _reviewreward;
		private int? _commissionratio1;
		private int? _commissionratio2;
		private int? _commissionratio3;
		/// <summary>
		/// 
		/// </summary>
		public Guid guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 等级
		/// </summary>
		public int grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}
		/// <summary>
		/// 等级积分
		/// </summary>
		public int integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 评审奖励积分
		/// </summary>
		public int reviewreward
		{
			set{ _reviewreward=value;}
			get{return _reviewreward;}
		}
		/// <summary>
		/// 佣金比例1
		/// </summary>
		public int? commissionratio1
		{
			set{ _commissionratio1=value;}
			get{return _commissionratio1;}
		}
		/// <summary>
		/// 佣金比例2
		/// </summary>
		public int? commissionratio2
		{
			set{ _commissionratio2=value;}
			get{return _commissionratio2;}
		}
		/// <summary>
		/// 佣金比例3
		/// </summary>
		public int? commissionratio3
		{
			set{ _commissionratio3=value;}
			get{return _commissionratio3;}
		}
		#endregion Model

	}
}

