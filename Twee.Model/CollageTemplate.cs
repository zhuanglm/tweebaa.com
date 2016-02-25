using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    [Serializable]
	public partial class CollageTemplate
    {
        public CollageTemplate()
        {

        }

        #region Model
        private int _id;
        private string _name;
        private string _thumbnail;
        private string _innerHTML;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public string Thumbnail
        {
            set { _thumbnail = value; }
            get { return _thumbnail; }
        }
        public string innerHTML
        {
            set { _innerHTML = value; }
            get { return _innerHTML; }
        }
        #endregion Model

    }
   

}
