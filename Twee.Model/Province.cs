using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    /// <summary>
    /// 省
    /// </summary>
    [Serializable]
    public class Province
    {
        public Province()
		{}
		#region Model
		private int _proid;
		private string _proname;
		private int? _prosort;
		private string _proremark;
		/// <summary>
		/// 
		/// </summary>
		public int ProID
		{
			set{ _proid=value;}
			get{return _proid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProName
		{
			set{ _proname=value;}
			get{return _proname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProSort
		{
			set{ _prosort=value;}
			get{return _prosort;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProRemark
		{
			set{ _proremark=value;}
			get{return _proremark;}
		}
		#endregion Model
    }
}
