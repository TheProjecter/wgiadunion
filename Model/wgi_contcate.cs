using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// ʵ����wgi_contcate ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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

