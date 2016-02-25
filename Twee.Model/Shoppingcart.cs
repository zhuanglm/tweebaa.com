using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// shoppingcart:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Shoppingcart
	{
        public Shoppingcart()
		{}
		#region Model
		private Guid _guid;
		private Guid _cookieguid;
		private Guid _prdguid;
		private decimal? _quantity;
		private DateTime? _edttime= DateTime.Now;
        private Guid? _userguid;
        private Guid? _shareId;//该购物车记录的来源,分享链接的数据库id
        private int? _ruleid;//订单选择的产品规格id
        private int? _shipmethodid;
        private decimal? _shipfee;

        private string _fileurl;//扩展字段
        private decimal _estimateprice;////扩展字段
        private decimal _saleprice;////扩展字段
        private string _name;////扩展字段
        private string _wnstat;////扩展字段
        private decimal _money;//扩展字段

        /// <summary>
        /// 购物车单款产品金额
        /// </summary>
        public decimal money
        {
            set { _money = value; }
            get { return _money; }
        }

        /// <summary>
        /// 产品状态
        /// </summary>
        public string wnstat
        {
            set { _wnstat = value; }
            get { return _wnstat; }
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 建议零售价
        /// </summary>
        public decimal estimateprice
        {
            set { _estimateprice = value; }
            get { return _estimateprice; }
        }
        /// <summary>
        /// 售价
        /// </summary>
        public decimal saleprice
        {
            set { _saleprice = value; }
            get { return _saleprice; }
        }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string fileurl
        {
            set { _fileurl = value; }
            get { return _fileurl; }
        }
       
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid? userguid
        {
            set { _userguid = value; }
            get { return _userguid; }
        }
        /// <summary>
        /// 分享链接id
        /// </summary>
        public Guid? shareId
        {
            set { _shareId = value; }
            get { return _shareId; }
        }
        /// <summary>
        /// 订单选择的产品规格id
        /// </summary>
        public int? ruleid
        {
            set { _ruleid = value; }
            get { return _ruleid; }
        }

        /// <summary>
        /// ship method id
        /// </summary>
        public int? shipmethodid
        {
            set { _shipmethodid = value; }
            get { return _shipmethodid; }
        }

        /// <summary>
        /// ship fee
        /// </summary>
        public decimal? shipfee
        {
            set { _shipfee= value; }
            get { return _shipfee; }
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
		public Guid cookieguid
		{
			set{ _cookieguid=value;}
			get{return _cookieguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid prdguid
		{
			set{ _prdguid=value;}
			get{return _prdguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
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

