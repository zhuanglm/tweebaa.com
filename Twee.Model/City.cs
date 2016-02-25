using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    /// <summary>
    /// 城市
    /// </summary>
    [Serializable]
    public class City
    {
        public City()
		{}
		#region Model
		private int _cityid;
		private string _cityname;
		private int? _proid;
		private int? _citysort;
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
		public string CityName
		{
			set{ _cityname=value;}
			get{return _cityname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ProID
		{
			set{ _proid=value;}
			get{return _proid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CitySort
		{
			set{ _citysort=value;}
			get{return _citysort;}
		}
		#endregion Model
    }
}
