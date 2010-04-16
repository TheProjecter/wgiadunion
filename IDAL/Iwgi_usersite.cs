using System;
using System.Data;
using System.Collections.Generic;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// �ӿڲ�Iwgi_mysite ��ժҪ˵����
	/// </summary>
	public interface Iwgi_usersite
	{
		#region  ��Ա����
        /// <summary>
        /// �����û�ID���������Ǽ���վ
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataSet getListByUserId(int userid);
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
		int Add(wgiAdUnionSystem.Model.wgi_usersite model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_usersite model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int siteid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		wgiAdUnionSystem.Model.wgi_usersite GetModel(int siteid);
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
