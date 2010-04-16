using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// 实体类wgi_cash 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wgi_cash
	{
		public wgi_cash()
		{}
		#region Model
		private int _id;
		private int? _userid;
		private decimal? _cash;
		private DateTime? _applydate;
		private int? _status;
		private decimal? _leftcash;
		private string _memo_user;
		private string _memo_admin;
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
		public int? userid
		{
			set{ _userid=value;}
			get{return _userid;}
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
		public DateTime? applydate
		{
			set{ _applydate=value;}
			get{return _applydate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? leftcash
		{
			set{ _leftcash=value;}
			get{return _leftcash;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string memo_user
		{
			set{ _memo_user=value;}
			get{return _memo_user;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string memo_admin
		{
			set{ _memo_admin=value;}
			get{return _memo_admin;}
		}
		#endregion Model

	}
}

