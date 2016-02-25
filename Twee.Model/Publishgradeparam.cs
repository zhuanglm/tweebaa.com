using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// publishgradeparam:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Publishgradeparam
	{
        public Publishgradeparam()
		{}
		#region Model
		private Guid _guid;
		private int _grade;
		private int _integral;
		private int _reviewreward;
		private int _presaleward;
		private int _reviewsupportmin;
		private int _reviewsupportmax;
		private int _presalesupportmin;
		private int _presalesupportmax;
		private int? _commissionratio;
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
		/// 等级所需积分
		/// </summary>
		public int integral
		{
			set{ _integral=value;}
			get{return _integral;}
		}
		/// <summary>
		/// 评审区奖励积分值
		/// </summary>
		public int reviewreward
		{
			set{ _reviewreward=value;}
			get{return _reviewreward;}
		}
		/// <summary>
		/// 预售区奖励积分值
		/// </summary>
		public int presaleward
		{
			set{ _presaleward=value;}
			get{return _presaleward;}
		}
		/// <summary>
		/// 评审区获得积分奖励所需支持数区间最小值
		/// </summary>
		public int reviewsupportmin
		{
			set{ _reviewsupportmin=value;}
			get{return _reviewsupportmin;}
		}
		/// <summary>
		/// 评审区获得积分奖励所需支持数区间最大值
		/// </summary>
		public int reviewsupportmax
		{
			set{ _reviewsupportmax=value;}
			get{return _reviewsupportmax;}
		}
		/// <summary>
		/// 预售区获得积分奖励所需支持数区间最小值
		/// </summary>
		public int presalesupportmin
		{
			set{ _presalesupportmin=value;}
			get{return _presalesupportmin;}
		}
		/// <summary>
		/// 预售区获得积分奖励所需支持数区间最大值
		/// </summary>
		public int presalesupportmax
		{
			set{ _presalesupportmax=value;}
			get{return _presalesupportmax;}
		}
		/// <summary>
		/// 佣金比例
		/// </summary>
		public int? commissionratio
		{
			set{ _commissionratio=value;}
			get{return _commissionratio;}
		}
		#endregion Model

	}
}

