using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// �ӿڲ�Iwgi_mysite ��ժҪ˵����
	/// </summary>
	public interface Iwgi_mysite
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int siteid);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_mysite model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_mysite model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int siteid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		wgiAdUnionSystem.Model.wgi_mysite GetModel(int siteid);
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
