using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// 实体类wgi_adv 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wgi_adv
	{
		public wgi_adv()
		{}
		#region Model
		private int _advid;
		private int? _companyid;
		private string _advname;
		private int? _advtype;
		private string _advcont;
		private string _advlink;
		private int? _advwidth;
		private int? _advheight;
		private DateTime? _advuptime;
		private int? _advstatus;
		private DateTime? _advstart;
		private DateTime? _advend;
		private int? _advinvalid;
		private int? _advpaytype;
		/// <summary>
		/// 
		/// </summary>
		public int advid
		{
			set{ _advid=value;}
			get{return _advid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? companyid
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string advname
		{
			set{ _advname=value;}
			get{return _advname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? advtype
		{
			set{ _advtype=value;}
			get{return _advtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string advcont
		{
			set{ _advcont=value;}
			get{return _advcont;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string advlink
		{
			set{ _advlink=value;}
			get{return _advlink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? advwidth
		{
			set{ _advwidth=value;}
			get{return _advwidth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? advheight
		{
			set{ _advheight=value;}
			get{return _advheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? advuptime
		{
			set{ _advuptime=value;}
			get{return _advuptime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? advstatus
		{
			set{ _advstatus=value;}
			get{return _advstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? advstart
		{
			set{ _advstart=value;}
			get{return _advstart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? advend
		{
			set{ _advend=value;}
			get{return _advend;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? advinvalid
		{
			set{ _advinvalid=value;}
			get{return _advinvalid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? advpaytype
		{
			set{ _advpaytype=value;}
			get{return _advpaytype;}
		}
		#endregion Model

	}
}

