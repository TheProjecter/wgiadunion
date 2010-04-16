using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// �ӿڲ�Iwgi_adv ��ժҪ˵����
	/// </summary>
	public interface Iwgi_adv
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int advid);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_adv model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_adv model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int advid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		wgiAdUnionSystem.Model.wgi_adv GetModel(int advid);
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
        /// ���ݹ����ID��ù���б�
        /// </summary>
        /// <param name="compid">�����ID</param>
        /// <param name="paytype">��渶������</param>
        /// <param name="display">�����ʾ����</param>
        /// <returns></returns>
        DataTable GetAdvListByCompID(int compid, int? paytype, int? display);
          /// <summary>
        /// ���ݹ����ID��ù���б�
        /// </summary>
        /// <param name="compid">�����ID</param>
        /// <param name="paytype">��渶������</param>
        /// <param name="display">�����ʾ����</param>
        ///<param name="display">�����ʾ��ʼʱ��</param>
        /// <param name="display">����ֹʱ��</param>
        /// <param name="isaudit">�Ƿ�ֻ��ʾͨ����˵�</param>
        /// <param name="ispublished">�Ƿ�ֻ��ʾͶ���е�</param>
        /// <returns></returns>
        DataTable GetAdvListByCompID(int compid, int paytype, int display, string beg, string end, string title, int? isaudit, int? ispublished);
	}
}
