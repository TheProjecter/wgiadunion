using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// 实体类wgi_adv_statis 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wgi_adv_statis
	{
		public wgi_adv_statis()
		{}
		#region Model
		private int? _companyid;
		private int? _userid;
		private int? _siteid;
		private int? _advid;
		private int? _advtype;
		private int? _statistype;
		private DateTime? _recordtime;
		private string _ip;
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
		public int? userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? siteid
		{
			set{ _siteid=value;}
			get{return _siteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? advid
		{
			set{ _advid=value;}
			get{return _advid;}
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
		public int? statistype
		{
			set{ _statistype=value;}
			get{return _statistype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? recordtime
		{
			set{ _recordtime=value;}
			get{return _recordtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		#endregion Model

	}
}

