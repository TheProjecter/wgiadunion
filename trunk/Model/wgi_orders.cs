using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// 实体类wgi_orders 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wgi_orders
	{
		public wgi_orders()
		{}
		#region Model
		private int _orderid;
		private int? _companyid;
		private int? _siteid;
		private string _orderno;
		private decimal? _cash;
		private DateTime? _time;
		private string _consumer;
		private string _itemno;
		private decimal? _itemprice;
		private decimal? _itemamount;
		private decimal? _pay;
		private int? _ischeck;
		private string _reason;
		private DateTime? _checktime;
		/// <summary>
		/// 
		/// </summary>
		public int orderid
		{
			set{ _orderid=value;}
			get{return _orderid;}
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
		public int? siteid
		{
			set{ _siteid=value;}
			get{return _siteid;}
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
		public decimal? cash
		{
			set{ _cash=value;}
			get{return _cash;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? time
		{
			set{ _time=value;}
			get{return _time;}
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
		public string itemno
		{
			set{ _itemno=value;}
			get{return _itemno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? itemprice
		{
			set{ _itemprice=value;}
			get{return _itemprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? itemamount
		{
			set{ _itemamount=value;}
			get{return _itemamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? pay
		{
			set{ _pay=value;}
			get{return _pay;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ischeck
		{
			set{ _ischeck=value;}
			get{return _ischeck;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string reason
		{
			set{ _reason=value;}
			get{return _reason;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? checktime
		{
			set{ _checktime=value;}
			get{return _checktime;}
		}
		#endregion Model

	}
}

