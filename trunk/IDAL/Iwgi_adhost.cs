using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// �ӿڲ�Iwgi_adhost ��ժҪ˵����
	/// </summary>
	public interface Iwgi_adhost
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int companyid);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_adhost model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_adhost model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int companyid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		wgiAdUnionSystem.Model.wgi_adhost GetModel(int companyid);
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
