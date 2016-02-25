using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// favorite:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Favorite
	{
        public Favorite()
		{}
		#region Model
		private Guid _guid;
		private Guid _userguid;
		private Guid _prtguid;

        //Add by Long for Collage Favorite
        private short _sourcetype;
        private int _design_id;
        //Add by Long EOF
		private DateTime? _edttime= DateTime.Now;
        private string _name;//扩展字段
        private string _fileurl;//扩展字段
        private decimal? _estimateprice;//扩展字段
        private string _wnstat;//扩展字段
        private int? _reviewCount;//扩展字段

        private int? _saleCount;//扩展字段：销售数量
        private decimal? _summoney;//扩展字段： 销售总金额
        private DateTime? _presaleendtime;//扩展字段：预售结束时间


        //Add by Long for Collage Favorite
        //Sourcetype =1 Products 
        //           =2 Collage Designs
        public short Sourcetype
        {
            set { _sourcetype = value; }
            get { return _sourcetype; }
        }
        
        public int CollageDesign_ID
        {
            set { _design_id = value; }
            get { return _design_id; }
        }
        //Add by Long EOF
        /// <summary>
        /// 产品名称（扩展字段）
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 图片地址（扩展字段）
        /// </summary>
        public string fileurl
        {
            set { _fileurl = value; }
            get { return _fileurl; }
        }
        /// <summary>
        /// 产品价格（扩展字段）
        /// </summary>
        public decimal? estimateprice
        {
            set { _estimateprice = value; }
            get { return _estimateprice; }
        }
        /// <summary>
        /// 产品状态（扩展字段）
        /// 【屏蔽:-1】【草稿:0】【评审中(大众):1】【预售:2】【销售:3】；
        /// 【评审中(推易吧):4】【评审失败(推易吧):5】
        /// </summary>
        public string wnstat
        {
            set { _wnstat = value; }
            get { return _wnstat; }
        }
        /// <summary>
        /// 评审人数（扩展字段）
        /// </summary>
        public int? reviewCount
        {
            set { _reviewCount = value; }
            get { return _reviewCount; }
        }

        /// <summary>
        /// 销售数量（扩展字段）
        /// </summary>
        public int? saleCount
        {
            set { _saleCount = value; }
            get { return _saleCount; }
        }
        /// <summary>
        /// 销售总金额（扩展字段）
        /// </summary>
        public decimal? summoney
        {
            set { _summoney = value; }
            get { return _summoney; }
        }
        /// <summary>
        /// 预售结束时间（扩展字段）
        /// </summary>
        public DateTime? presaleendtime
        {
            set { _presaleendtime = value; }
            get { return _presaleendtime; }
        }

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
		/// 
		/// </summary>
		public Guid prtguid
		{
			set{ _prtguid=value;}
			get{return _prtguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? edttime
		{
			set{ _edttime=value;}
			get{return _edttime;}
		}
		#endregion Model



	}
}

