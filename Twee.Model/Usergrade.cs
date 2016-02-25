
using System;
namespace Twee.Model
{
	/// <summary>
	/// usergrade:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Usergrade
	{
        public Usergrade()
		{}
		#region Model
		private Guid _guid;
		private Guid _userguid;
		private int? _publishgrade;
		private int? _reviewgrade;
		private int? _sharegrade;
		private int? _publishintegral;
		private int? _reviewintegral;
		private int? _shareintegral;
		private int? _publishcount;
		private int? _reviewhcount;
		private int? _sharecount;
		private DateTime? _updatetime= DateTime.Now;
        private decimal? _shopingPoint;
        private decimal? _tweebuck;
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
		public Guid userguid
		{
			set{ _userguid=value;}
			get{return _userguid;}
		}
		/// <summary>
		/// 发布区等级
		/// </summary>
		public int? publishgrade
		{
			set{ _publishgrade=value;}
			get{return _publishgrade;}
		}
		/// <summary>
		/// 评审区等级
		/// </summary>
		public int? reviewgrade
		{
			set{ _reviewgrade=value;}
			get{return _reviewgrade;}
		}
		/// <summary>
		/// 分享区等级
		/// </summary>
		public int? sharegrade
		{
			set{ _sharegrade=value;}
			get{return _sharegrade;}
		}
		/// <summary>
		/// 发布区积分
		/// </summary>
		public int? publishintegral
		{
			set{ _publishintegral=value;}
			get{return _publishintegral;}
		}
		/// <summary>
		/// 评审区积分
		/// </summary>
		public int? reviewintegral
		{
			set{ _reviewintegral=value;}
			get{return _reviewintegral;}
		}
		/// <summary>
		/// 分享区积分
		/// </summary>
		public int? shareintegral
		{
			set{ _shareintegral=value;}
			get{return _shareintegral;}
		}
		/// <summary>
		/// 发布项目数
		/// </summary>
		public int? publishcount
		{
			set{ _publishcount=value;}
			get{return _publishcount;}
		}
		/// <summary>
		/// 评审项目数
		/// </summary>
		public int? reviewhcount
		{
			set{ _reviewhcount=value;}
			get{return _reviewhcount;}
		}
		/// <summary>
		/// 分享项目数
		/// </summary>
		public int? sharecount
		{
			set{ _sharecount=value;}
			get{return _sharecount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}

        /// <summary>
        /// tweebuck
        /// </summary>
        public decimal? tweebuck
        {
            set { _tweebuck = value; }
            get { return _tweebuck; }
        }
        /// <summary>
        /// 购物积分
        /// </summary>
        public decimal? shopingPoint
        {
            set { _shopingPoint = value; }
            get { return _shopingPoint; }
        }
		#endregion Model

	}
}

