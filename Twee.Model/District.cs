using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    /// <summary>
    /// 县
    /// </summary>
    [Serializable]
    public class District
    {
        public District()
		{}
		#region Model
		private int _id;
		private string _disname;
		private int _cityid;
		private int? _dissort;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisName
		{
			set{ _disname=value;}
			get{return _disname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CityID
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DisSort
		{
			set{ _dissort=value;}
			get{return _dissort;}
		}
		#endregion Model
    }
}
