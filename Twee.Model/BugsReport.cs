using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
     [Serializable]
	public partial class BugsReport
    {
         public BugsReport()
		{

        }

     #region Model
		private int _id;
		private short _type;
        private string _browser;
        private short _level;
        private string _title;
        private string _description;
        private Guid _userid;
        private DateTime _createtime;
        private short _status;
        private string _comments;
        private short _assign_to;

   		public int BugsReport_ID
		{
			set{ _id=value;}
			get{return _id;}
		}

    	public short BugsType
		{
			set{ _type=value;}
			get{return _type;}
		}

    	public string BrowserType
		{
			set{ _browser=value;}
			get{return _browser;}
		}

    	public short BugsLevel
		{
			set{ _level=value;}
			get{return _level;}
		}

    	public string BugsTitle
		{
			set{ _title=value;}
			get{return _title;}
		}

    	public string BugsDescription
		{
			set{ _description=value;}
			get{return _description;}
		}

    		public Guid UserGuid
		{
			set{ _userid=value;}
			get{return _userid;}
		}

    		public DateTime CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}

    	public short status
		{
			set{ _status=value;}
			get{return _status;}
		}

    		public string Comments
		{
			set{ _comments=value;}
			get{return _comments;}
		}

            public short assign_to
		{
            set { _assign_to = value; }
            get { return _assign_to; }
		}

      #endregion Model

     }
}
