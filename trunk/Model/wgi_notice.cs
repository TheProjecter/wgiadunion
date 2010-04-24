using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// ʵ����wgi_notice ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class wgi_notice
	{
		public wgi_notice()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _notice;
		private DateTime? _pubdate;
		private int? _unread;
		private int? _publisher;
		private int? _objid;
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
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string notice
		{
			set{ _notice=value;}
			get{return _notice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? pubdate
		{
			set{ _pubdate=value;}
			get{return _pubdate;}
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
		public int? publisher
		{
			set{ _publisher=value;}
			get{return _publisher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? objid
		{
			set{ _objid=value;}
			get{return _objid;}
		}
		#endregion Model

	}
}

