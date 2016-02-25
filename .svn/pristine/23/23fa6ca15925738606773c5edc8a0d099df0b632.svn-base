using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// orderhead:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Orderhead
	{
        public Orderhead()
		{}
		#region Model
		private Guid _guid;
		private Guid _userguid;//订单user
		private DateTime? _edttime= DateTime.Now;
        private int? _wnstat;//订单状态：0 未支付，1待发货，2已发货，3已完成，-1 已作废,-2申请退货中，-3退货中，-4待退款，-5退货完成,-6删除
		private string _address1;
		private string _guidno;//订单编号
		private DateTime? _addtime= DateTime.Now;
		private decimal? _logisticscost;  //物流费用 shipping fee
        private decimal? _taxSum; // total tax
        private decimal? _taxGST; // Canada GST tax
        private decimal? _taxHST; // Canada HST tax
        private decimal? _taxQST; // Canada QST tax
        private string _recivename;
		private string _recivephone;
		private string _recivzipcode;
		private string _messageword;//留言
		private DateTime? _uppricetime= DateTime.Now;
		private string _uppricemeassage= "NULL";
		private string _expressno;//快递单号
        private DateTime? _paytime = DateTime.Now;//支付时间
		private Guid _expresscompanyguid;//快递公司guid
        private Guid _addressguid;//收货地址guid
        private decimal? _userShopingAmount;
        private decimal? _useTweebuckAmount;
        private decimal? _useSharePointAmount;
        //Add by Long for Shipping Address and Billing Address
        private string _sFirstname;
        private string _sLastname;
        private string _sAddress1;
        private string _sAddress2;
        private string _sCity;
        private string _sProvince;
        private string _sCountry;
        private string _sEmail;
        private string _sPhone;
        private string _sZip;
        //Billing Address
        private string _bFirstname;
        private string _bLastname;
        private string _bAddress1;
        private string _bAddress2;
        private string _bCity;
        private string _bProvince;
        private string _bCountry;
        private string _bEmail;
        private string _bPhone;
        private string _bZip;

        //Add by Long 2016/01/15
        private string _CouponAmount;
        private string _CouponCode;
        public string CouponAmount
        {
            set { _CouponAmount = value; }
            get { return _CouponAmount; }
        }
        public string CouponCode
        {
            set { _CouponCode = value; }
            get { return _CouponCode; }
        }


        public string ShippingFirstname
        {
            set { _sFirstname = value; }
            get { return _sFirstname; }
        }
        public string ShippingLastname
        {
            set { _sLastname = value; }
            get { return _sLastname; }
        }
        public string ShippingAddress1
        {
            set { _sAddress1 = value; }
            get { return _sAddress1; }
        }
        public string ShippingAddress2
        {
            set { _sAddress2 = value; }
            get { return _sAddress2; }
        }
        public string ShippingCity
        {
            set { _sCity = value; }
            get { return _sCity; }
        }
        public string ShippingProvince
        {
            set { _sProvince = value; }
            get { return _sProvince; }
        }
        public string ShippingCountry
        {
            set { _sCountry = value; }
            get { return _sCountry; }
        }
        public string ShippingEmail
        {
            set { _sEmail = value; }
            get { return _sEmail; }
        }
        public string ShippingPhone
        {
            set { _sPhone = value; }
            get { return _sPhone; }
        }
        public string ShippingZip
        {
            set { _sZip = value; }
            get { return _sZip; }
        }
        public string BillingFirstname
        {
            set { _bFirstname = value; }
            get { return _bFirstname; }
        }
        public string BillingLastname
        {
            set { _bLastname = value; }
            get { return _bLastname; }
        }
        public string BillingAddress1
        {
            set { _bAddress1 = value; }
            get { return _bAddress1; }
        }
        public string BillingAddress2
        {
            set { _bAddress2 = value; }
            get { return _bAddress2; }
        }
        public string BillingCity
        {
            set { _bCity = value; }
            get { return _bCity; }
        }
        public string BillingProvince
        {
            set { _bProvince = value; }
            get { return _bProvince; }
        }
        public string BillingCountry
        {
            set { _bCountry = value; }
            get { return _bCountry; }
        }
        public string BillingEmail
        {
            set { _bEmail = value; }
            get { return _bEmail; }
        }
        public string BillingPhone
        {
            set { _bPhone = value; }
            get { return _bPhone; }
        }
        public string BillingZip
        {
            set { _bZip = value; }
            get { return _bZip; }
        }
        ////////////////////
        /// <summary>
        /// 订单收货地址
        /// </summary>
        public Guid addressguid
        {
            set { _addressguid = value; }
            get { return _addressguid; }
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
		/// 订单user
		/// </summary>
		public Guid userguid
		{
			set{ _userguid=value;}
			get{return _userguid;}
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
        /// 订单状态：0 未支付，1待发货，2已发货，3已完成，-1 已作废
		/// </summary>
		public int? wnstat
		{
			set{ _wnstat=value;}
			get{return _wnstat;}
		}
		/// <summary>
		/// 收货地址
		/// </summary>
		public string address1
		{
			set{ _address1=value;}
			get{return _address1;}
		}
		/// <summary>
		/// 订单编号
		/// </summary>
		public string guidno
		{
			set{ _guidno=value;}
			get{return _guidno;}
		}
		/// <summary>
		/// 订单创建时间
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 物流费用
		/// </summary>
		public decimal? logisticscost
		{
			set{ _logisticscost=value;}
			get{return _logisticscost;}
		}

        /// <summary>
        /// total amount of tax
        /// </summary>
        public decimal? taxSum
        {
            set { _taxSum = value; }
            get { return _taxSum; }
        }

        /// <summary>
        /// GST of Canada 
        /// </summary>
        public decimal? taxGST
        {
            set { _taxGST = value; }
            get { return _taxGST; }
        }

        /// <summary>
        /// HST of Canada 
        /// </summary>
        public decimal? taxHST
        {
            set { _taxHST = value; }
            get { return _taxHST; }
        }

        /// <summary>
        /// QST of Canada 
        /// </summary>
        public decimal? taxQST
        {
            set { _taxQST = value; }
            get { return _taxQST; }
        }

        /// <summary>
		/// 收货人姓名
		/// </summary>
		public string reciveName
		{
			set{ _recivename=value;}
			get{return _recivename;}
		}
		/// <summary>
		/// 收货人电话
		/// </summary>
		public string recivePhone
		{
			set{ _recivephone=value;}
			get{return _recivephone;}
		}
		/// <summary>
		/// 收货人邮编
		/// </summary>
		public string recivZipCode
		{
			set{ _recivzipcode=value;}
			get{return _recivzipcode;}
		}
		/// <summary>
		/// 订单留言
		/// </summary>
		public string messageWord
		{
			set{ _messageword=value;}
			get{return _messageword;}
		}
		/// <summary>
		/// 改价时间
		/// </summary>
		public DateTime? upPriceTime
		{
			set{ _uppricetime=value;}
			get{return _uppricetime;}
		}
		/// <summary>
		/// 改价备注
		/// </summary>
		public string upPriceMeassage
		{
			set{ _uppricemeassage=value;}
			get{return _uppricemeassage;}
		}
		/// <summary>
		/// 快递单号
		/// </summary>
		public string expressNo
		{
			set{ _expressno=value;}
			get{return _expressno;}
		}
		/// <summary>
		/// 支付时间
		/// </summary>
		public DateTime? payTime
		{
			set{ _paytime=value;}
			get{return _paytime;}
		}
		/// <summary>
		/// 快递公司
		/// </summary>
		public Guid expressCompanyGuid
		{
			set{ _expresscompanyguid=value;}
			get{return _expresscompanyguid;}
		}
        public decimal? userShopingAmount
        {
            set { _userShopingAmount = value; }
            get { return _userShopingAmount; }
        }
        public decimal? useTweebuckAmount
        {
            set { _useTweebuckAmount = value; }
            get { return _useTweebuckAmount; }
        }

        public decimal? useSharePointAmount
        {
            set { _useSharePointAmount = value; }
            get { return _useSharePointAmount; }
        }
		#endregion Model

	}
}

