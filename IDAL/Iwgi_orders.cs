using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// �ӿڲ�Iwgi_orders ��ժҪ˵����
	/// </summary>
	public interface Iwgi_orders
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int orderid);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_orders model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_orders model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int orderid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		wgiAdUnionSystem.Model.wgi_orders GetModel(int orderid);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		//DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
