using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twee.Model
{
	/// <summary>
	/// sendArea:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SendArea
	{
        public SendArea()
		{}
		#region Model
		private Guid _areaguid;
		private string _areaname;
		private string _remarktxt;
		/// <summary>
		/// 
		/// </summary>
		public Guid areaGuid
		{
			set{ _areaguid=value;}
			get{return _areaguid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string areaName
		{
			set{ _areaname=value;}
			get{return _areaname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remarkTxt
		{
			set{ _remarktxt=value;}
			get{return _remarktxt;}
		}
		#endregion Model

	}
}

