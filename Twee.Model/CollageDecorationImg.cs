using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    [Serializable]
	public partial class CollageDecorationImg
    {
        public CollageDecorationImg()
        {

        }
        #region Model
        private int _id;
        private string _name;
        private string _png_name;
        /// <summary>
        /// 
        /// </summary>
        public int CollageDecorationImg_ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public string CollageDecorationImg_Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public string CollageDecorationImgTransparentName
        {
            set { _png_name = value; }
            get { return _png_name; }
        }

        #endregion Model
    }
}
