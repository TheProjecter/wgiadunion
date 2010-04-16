using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// 实体类wgi_lostorder 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wgi_lostorder
	{
		public wgi_lostorder()
		{}
		#region Model
		private int _id;
		private int? _companyid;
		private int? _userid;
		private string _orderno;
		private string _adhostname;
		private DateTime? _buytime;
		private string _itemno;
		private string _consumer;
		private string _applyreason;
		private DateTime? _applytime;
		private string _lostreason;
		private string _result;
		private int? _status;
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
		/// <summary>
		/// 
		/// </summary>
		public string orderno
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string adhostname
		{
			set{ _adhostname=value;}
			get{return _adhostname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? buytime
		{
			set{ _buytime=value;}
			get{return _buytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string itemno
		{
			set{ _itemno=value;}
			get{return _itemno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string consumer
		{
			set{ _consumer=value;}
			get{return _consumer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string applyreason
		{
			set{ _applyreason=value;}
			get{return _applyreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? applytime
		{
			set{ _applytime=value;}
			get{return _applytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lostreason
		{
			set{ _lostreason=value;}
			get{return _lostreason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

