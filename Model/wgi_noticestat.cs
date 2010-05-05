using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// 实体类wgi_noticestat 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wgi_noticestat
	{
		public wgi_noticestat()
		{}
		#region Model
		private int _id;
		private int? _noticeid;
		private int? _usertype;
		private int? _userid;
		private int? _unread;
		private int? _deleted;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? noticeid
		{
			set{ _noticeid=value;}
			get{return _noticeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? usertype
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? unread
		{
			set{ _unread=value;}
			get{return _unread;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? deleted
		{
			set{ _deleted=value;}
			get{return _deleted;}
		}
		#endregion Model

	}
}

