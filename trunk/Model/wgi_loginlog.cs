using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// ʵ����wgi_loginlog ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class wgi_loginlog
	{
		public wgi_loginlog()
		{}
		#region Model
		private int _logid;
		private int? _usertype;
		private DateTime? _logtime;
		private string _logip;
		private string _logname;
		/// <summary>
		/// 
		/// </summary>
		public int logid
		{
			set{ _logid=value;}
			get{return _logid;}
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
		public DateTime? logtime
		{
			set{ _logtime=value;}
			get{return _logtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logip
		{
			set{ _logip=value;}
			get{return _logip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logname
		{
			set{ _logname=value;}
			get{return _logname;}
		}
		#endregion Model

	}
}

