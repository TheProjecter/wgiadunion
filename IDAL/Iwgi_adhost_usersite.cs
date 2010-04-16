using System;
using System.Data;
using System.Collections.Generic;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// �ӿڲ�Iwgi_adhost_usersite ��ժҪ˵����
	/// </summary>
	public interface Iwgi_adhost_usersite
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
		int Add(wgiAdUnionSystem.Model.wgi_adhost_usersite model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_adhost_usersite model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		wgiAdUnionSystem.Model.wgi_adhost_usersite GetModel(int id);
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

        /// <summary>
        /// ���ݹ����ID�����״̬��ü�����������վ�б�
        /// </summary>
        /// <param name="compid">�����ID</param>
        /// <param name="status">���״̬</param>
        /// <returns></returns>
        DataTable GetWebSiteWithAdvList(int compid, int status,string sitename);

        /// <summary>
        /// �����޸���������ƹ����վ״̬��������ˣ��ܾ��Ȳ���
        /// </summary>
        /// <param name="ids">ѡ�����վ��</param>
        /// <param name="status"></param>
        int ChangeApplySiteStatus(List<string> ids, int status);

	}
}
