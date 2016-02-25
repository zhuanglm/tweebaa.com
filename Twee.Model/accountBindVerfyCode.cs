using System;
namespace Twee.Model
{
    /// <summary>
    /// accountBindVerfyCode:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class accountBindVerfyCode
    {
        public accountBindVerfyCode()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _code;
        private DateTime _createtime;
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
        public string userid
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}

