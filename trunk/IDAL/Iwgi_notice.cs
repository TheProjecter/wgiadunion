using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// �ӿڲ�Iwgi_notice ��ժҪ˵����
	/// </summary>
	public interface Iwgi_notice
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
		int Add(wgiAdUnionSystem.Model.wgi_notice model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_notice model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		wgiAdUnionSystem.Model.wgi_notice GetModel(int id);
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
        
        /// <summary>
        /// �����Ķ�״̬
        /// </summary>
        /// <param name="id"></param>
        void UpdateReadStatus(int id, int status);
		#endregion  ��Ա����
	}
}
