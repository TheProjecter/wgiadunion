using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// �ӿڲ�Iwgi_contcate ��ժҪ˵����
	/// </summary>
	public interface Iwgi_contcate
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_contcate model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_contcate model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		wgiAdUnionSystem.Model.wgi_contcate GetModel(int id);
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
