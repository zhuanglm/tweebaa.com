using System;
namespace Twee.Model
{
	/// <summary>
	/// wn_Profit:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Profit
	{
        public Profit()
		{}
		#region Model
		private int _id;
		private string _type;
		private Guid _userid;
		private decimal? _money;
		private Guid _prdid;
		private string _orderno;
		private int? _state;
		private string _remark;
		private DateTime? _addtime;
		private DateTime? _edittime;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 收益者ID
		/// </summary>
		public Guid userId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 收益金额
		/// </summary>
		public decimal? money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 收益来源的产品id
		/// </summary>
		public Guid prdId
		{
			set{ _prdid=value;}
			get{return _prdid;}
		}
		/// <summary>
		/// 收益的来源订单号
		/// </summary>
		public string orderNo
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
        /// 该收益的状态：0已创建，1可提取，2已提取现金，3已作废（作废的可能原因：该产品退货、作弊。方案：每个收益需在退货期已过之后，才可以提取） 4 是Pending
		/// </summary>
		public int? state
		{
			set{ _state=value;}
			get{return _state;}
		}
		/// <summary>
		/// 收益说明
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 收益创建时间
		/// </summary>
		public DateTime? addTime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 该收益记录最后更新时间
		/// </summary>
		public DateTime? editTime
		{
			set{ _edittime=value;}
			get{return _edittime;}
		}
		#endregion Model

	}
}

