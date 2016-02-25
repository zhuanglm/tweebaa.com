using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
    /// <summary>
    /// VistLog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VistLog
    {
        public VistLog()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _prdid;
        private DateTime? _addtime;
        private bool _isBig30Second;
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
        public string userId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string prdID
        {
            set { _prdid = value; }
            get { return _prdid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? addTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 是否访问超过30秒
        /// </summary>
        public bool isBig30Second
        {
            set { _isBig30Second = value; }
            get { return _isBig30Second; }
        }
        #endregion Model

    }
}
