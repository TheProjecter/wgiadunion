using System;
namespace wgiAdUnionSystem.Model
{
	/// <summary>
	/// ʵ����wgi_ind_type ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class wgi_ind_type
	{
		public wgi_ind_type()
		{}
		#region Model
		private int _id;
		private int? _pid;
		private string _indname;
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
		public int? pid
		{
			set{ _pid=value;}
			get{return _pid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string indname
		{
			set{ _indname=value;}
			get{return _indname;}
		}
		#endregion Model

	}
}

