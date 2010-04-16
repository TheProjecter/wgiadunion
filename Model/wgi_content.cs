using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// ʵ����wgi_content ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class wgi_content
	{
		public wgi_content()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _content;
		private string _author;
		private int? _showindex;
		private DateTime? _pubtime;
		private int? _isshow;
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
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? showindex
		{
			set{ _showindex=value;}
			get{return _showindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? pubtime
		{
			set{ _pubtime=value;}
			get{return _pubtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isshow
		{
			set{ _isshow=value;}
			get{return _isshow;}
		}
		#endregion Model

	}
}

