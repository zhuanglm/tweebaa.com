using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// review:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Review
	{
        public Review()
		{}
		#region Model
		private Guid _guid;
		private string _cmdtype;
		private string _cmdtxt;
		private DateTime? _edttime= DateTime.Now;
		private Guid _userguid;
		private Guid _prtguid;
		private int? _wnstat=1;
		private int? _cmdtype2;
        private string _username;//扩展字段（非数据库字段）
        private int  _reviewgrade;
		/// <summary>
		/// 
		/// </summary>
		public Guid guid
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
        ///【1：有兴趣购买该产品（好评）】【2：没兴趣购买该产品】
        ///【3：觉得该产品会畅销（好评）】【4：觉得该产品不会畅销】
		/// </summary>
		public string cmdtype
		{
			set{ _cmdtype=value;}
			get{return _cmdtype;}
		}
		/// <summary>
		/// 评审内容
		/// </summary>
		public string cmdtxt
		{
			set{ _cmdtxt=value;}
			get{return _cmdtxt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? edttime
		{
			set{ _edttime=value;}
			get{return _edttime;}
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
		/// 
		/// </summary>
		public Guid prtguid
		{
			set{ _prtguid=value;}
			get{return _prtguid;}
		}
		/// <summary>
		/// 评论状态：1显示，0：屏蔽
		/// </summary>
		public int? wnstat
		{
			set{ _wnstat=value;}
			get{return _wnstat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? cmdtype2
		{
			set{ _cmdtype2=value;}
			get{return _cmdtype2;}
		}

        /// <summary>
		/// 用户名
		/// </summary>
        public string username
		{
            set { _username = value; }
            get { return _username; }
		}

        /// <summary>
        /// user's review grade
        /// </summary>
        public int reviewgrade
        {
            set { _reviewgrade = value; }
            get { return _reviewgrade; }
        }


        #endregion Model

	}
}

