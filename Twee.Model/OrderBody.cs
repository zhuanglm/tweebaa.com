using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// orderBody:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OrderBody
	{
        public OrderBody()
		{}
		#region Model
		private Guid _guid;
		private Guid _headguid;
		private Guid _prdguid;
		private decimal? _quantity;
        private decimal? _buydanjia;//订单单价（下订单后，结算价格就依据订单单价，不受产品价格改变而影响）
		private int _idx;
		private DateTime? _edttime= DateTime.Now;
		private decimal? _logisticscost;
        private Guid? _shareId;//该购物车记录的来源,分享链接的数据库id
        private int? _ruleid;//订单选择的产品规格id
        private int? _shipmethodid;  // shipping method id
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
		public Guid headGuid
		{
			set{ _headguid=value;}
			get{return _headguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid prdGuid
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
		public decimal? buydanJia
		{
			set{ _buydanjia=value;}
			get{return _buydanjia;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int idx
		{
			set{ _idx=value;}
			get{return _idx;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? edtTime
		{
			set{ _edttime=value;}
			get{return _edttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? logisticscost
		{
			set{ _logisticscost=value;}
			get{return _logisticscost;}
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
        /// Ship method id
        /// </summary>
        public int? shipmethodid
        {
            set { _shipmethodid = value; }
            get { return _shipmethodid; }
        }

        #endregion Model

	}
}

