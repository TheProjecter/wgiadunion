using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// 实体类wgi_adv_site_host 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wgi_adv_site_host
	{
		public wgi_adv_site_host()
		{}
		#region Model
		private int _id;
		private int? _companyid;
		private int? _userid;
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
		#endregion Model

	}
}

