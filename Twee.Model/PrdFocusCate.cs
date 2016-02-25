using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    [Serializable]
    public partial class PrdFocusCate
    {
        PrdFocusCate()
        { }
        #region Model
        private int _id;
        private string _name;
        private string _note;
        private int _active;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string note
        {
            set { _note = value; }
            get { return _note; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int active
        {
            set { _active = value; }
            get { return _active; }
        }
        #endregion Model

    }
}
