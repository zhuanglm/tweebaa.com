using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
        [Serializable]
	public partial class CollageComments
    {
            public CollageComments()
            {
            }

            #region Model
            private int _id;
            private int _iDesignID;
            private Guid _userID;
            private string _userName;
            private string _sComments;

            private string _sCreate;
            /// </summary>
            public int id
            {
                set { _id = value; }
                get { return _id; }
            }
            public int CollageDesign_ID
            {
                set { _iDesignID = value; }
                get { return _iDesignID; }
            }

            public Guid UserID 
            {
                set { _userID = value; }
                get { return _userID; }
            }

            /// <summary>
            /// 
            /// </summary>
            public string comments
            {
                set { _sComments = value; }
                get { return _sComments; }
            }
        /// <summary>
            public string CreateTime
            {
                set { _sCreate = value; }
                get { return _sCreate; }
            }
        /// <summary>   
        /// 
            public string UserName
            {
                set { _userName = value; }
                get { return _userName; }
            }
        #endregion Model
    }
}
