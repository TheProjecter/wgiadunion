using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// 实体类wgi_mysite 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wgi_mysite
	{
		public wgi_mysite()
		{}
		#region Model
		private int? _userid;
		private int _siteid;
		private string _sitename;
		private string _url;
		private string _siteremark;
		private int? _ipno;
		private int? _pvno;
		private int? _sitetype;
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
		public int siteid
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string sitename
		{
			set{ _sitename=value;}
			get{return _sitename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string url
		{
			set{ _url=value;}
			get{return _url;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string siteremark
		{
			set{ _siteremark=value;}
			get{return _siteremark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ipno
		{
			set{ _ipno=value;}
			get{return _ipno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? pvno
		{
			set{ _pvno=value;}
			get{return _pvno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sitetype
		{
			set{ _sitetype=value;}
			get{return _sitetype;}
		}
		#endregion Model

	}
}

