using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// �ӿڲ�Iwgi_sitehost ��ժҪ˵����
	/// </summary>
	public interface Iwgi_sitehost
	{
        #region  ��Ա����
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newpwd"></param>
        void updatePwd(int userid, string newpwd);
        /// <summary>
        /// �����ϴε�¼ʱ��
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="time"></param>
        void updateLoginTime(int userid, string time);
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int userid);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_sitehost model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_sitehost model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int userid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		wgiAdUnionSystem.Model.wgi_sitehost GetModel(int userid);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
        DataSet GetListByUsername(string username);
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
        /// �����������б�
        /// </summary>
        /// <param name="username">�û���</param>
        /// <param name="realname">��ʵ����</param>
        /// <param name="email">����</param>
        /// <param name="sitename">��վ��</param>
        /// <returns></returns>
        DataSet GetListOfSearch(string username, string realname, string email, string sitename);

        void Delete(string ids);
        void UpdateBlance(int userid, decimal c);
	}
}
