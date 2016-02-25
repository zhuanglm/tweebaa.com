using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    	[Serializable]
	public partial class CollageShare
    {
            public CollageShare()
            {

            }

		#region Model
		private Guid _guid;
		private Guid _prtguid;
		private string _shareurl;
		private string _sharetype;
		private DateTime? _addtime= DateTime.Now;
		private Guid _userguid;
		private int? _visitcount;
		private int? _successcount;
		private int? _prdcount;
		private decimal? _prdsummoney;
        private int _sourcetype;
        private int _CollageDesign_ID;
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
		public string shareurl
		{
			set{ _shareurl=value;}
			get{return _shareurl;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sharetype
		{
			set{ _sharetype=value;}
			get{return _sharetype;}
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
		public Guid userguid
		{
			set{ _userguid=value;}
			get{return _userguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? visitcount
		{
			set{ _visitcount=value;}
			get{return _visitcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? successcount
		{
			set{ _successcount=value;}
			get{return _successcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? prdcount
		{
			set{ _prdcount=value;}
			get{return _prdcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? prdsumMoney
		{
			set{ _prdsummoney=value;}
			get{return _prdsummoney;}
		}

        public int Sourcetype
		{
			set{ _sourcetype=value;}
			get{return _sourcetype;}
		}

		public int CollageDesign_ID
		{
			set{ _CollageDesign_ID=value;}
			get{return _CollageDesign_ID;}
		}
                  
       
		#endregion Model

	}
    


}
