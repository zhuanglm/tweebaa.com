using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// money:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Money
	{
        public Money()
		{}
		#region Model
		private Guid _guid;
		private Guid _userguid;
		private decimal? _amount;
		private DateTime? _addtime= DateTime.Now;
		private DateTime? _edttime;
		private string _paymentno;
		private string _defremark;
		private int? _wntype;
		private int? _wnstate;
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
		public decimal? amount
		{
			set{ _amount=value;}
			get{return _amount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
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
		public string paymentno
		{
			set{ _paymentno=value;}
			get{return _paymentno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string defremark
		{
			set{ _defremark=value;}
			get{return _defremark;}
		}
		/// <summary>
		/// 佣金来源类别()
		/// </summary>
		public int? wntype
		{
			set{ _wntype=value;}
			get{return _wntype;}
		}
		/// <summary>
		/// money类别0申请中1提现2拒绝
		/// </summary>
		public int? wnstate
		{
			set{ _wnstate=value;}
			get{return _wnstate;}
		}
		#endregion Model

	}
}

