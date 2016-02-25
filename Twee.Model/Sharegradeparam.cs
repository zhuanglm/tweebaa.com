using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// sharegradeparam:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Sharegradeparam
	{
        public Sharegradeparam()
		{}
		#region Model
		private Guid _guid;
		private int _grade;
		private int _integral;
		private int _visitreward;
		private int _buyreward;
		private int _visitcountmin;
		private int _visitcountmax;
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
		/// 链接被访问无购买奖励积分值
		/// </summary>
		public int visitreward
		{
			set{ _visitreward=value;}
			get{return _visitreward;}
		}
		/// <summary>
		/// 链接被访问产生购买奖励积分值
		/// </summary>
		public int buyreward
		{
			set{ _buyreward=value;}
			get{return _buyreward;}
		}
		/// <summary>
		/// 链接被访问无购买的情况获得积分需最少次数
		/// </summary>
		public int visitcountmin
		{
			set{ _visitcountmin=value;}
			get{return _visitcountmin;}
		}
		/// <summary>
		/// 链接被访问无购买的情况获得积分需最大次数
		/// </summary>
		public int visitcountmax
		{
			set{ _visitcountmax=value;}
			get{return _visitcountmax;}
		}
		/// <summary>
		/// 链接被访问产生购买的佣金比例
		/// </summary>
		public int? commissionratio
		{
			set{ _commissionratio=value;}
			get{return _commissionratio;}
		}
		#endregion Model

	}
}

