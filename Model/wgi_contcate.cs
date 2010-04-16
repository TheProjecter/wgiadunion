using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// 实体类wgi_contcate 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class wgi_contcate
	{
		public wgi_contcate()
		{}
		#region Model
		private int _id;
		private string _cname;
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
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		#endregion Model

	}
}

