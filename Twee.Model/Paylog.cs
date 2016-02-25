using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// paylog:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Paylog
	{
        public Paylog()
		{}
		#region Model
		private Guid _guid;
		private Guid _prtguid;
		private string _trade_no;
		private string _trade_status;
		private string _seller_email;
		private string _body;
		private decimal? _total_fee;
		private string _buyer_email;
		private DateTime? _addtime= DateTime.Now;
		private string _cmdtxt;
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
		public Guid prtguid
		{
			set{ _prtguid=value;}
			get{return _prtguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string trade_no
		{
			set{ _trade_no=value;}
			get{return _trade_no;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string trade_status
		{
			set{ _trade_status=value;}
			get{return _trade_status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string seller_email
		{
			set{ _seller_email=value;}
			get{return _seller_email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string body
		{
			set{ _body=value;}
			get{return _body;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? total_fee
		{
			set{ _total_fee=value;}
			get{return _total_fee;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string buyer_email
		{
			set{ _buyer_email=value;}
			get{return _buyer_email;}
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
		public string cmdtxt
		{
			set{ _cmdtxt=value;}
			get{return _cmdtxt;}
		}
		#endregion Model

	}
}

