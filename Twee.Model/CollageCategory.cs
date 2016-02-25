using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    [Serializable]
	public partial class CollageCategory
    {
        public CollageCategory()
		{
        
        }
		#region Model
		private int _id;
		private string _Category;
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string CategoryName
		{
            set { _Category = value; }
            get { return _Category; }
		}
		/// <summary>
        #endregion Model
    }
    //CollageCate_ID
    //CollageCate_Name


}
