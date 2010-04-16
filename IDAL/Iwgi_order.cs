using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
    /// <summary>
    /// �ӿڲ�Iwgi_order ��ժҪ˵����
    /// </summary>
    public interface Iwgi_order
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
        int Add(wgiAdUnionSystem.Model.wgi_order model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(wgiAdUnionSystem.Model.wgi_order model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int orderid);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        wgiAdUnionSystem.Model.wgi_order GetModel(int orderid);
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
        /// ��ѯ��涩����Ϣ
        /// </summary>
        /// <param name="compid">�����ID</param>
        /// <param name="status">�����˶�״̬</param>
        /// <param name="orderno">�������</param>
        /// <param name="buyer">����������</param>
        /// <returns></returns>
        DataTable GetAdvOrderList(int compid, int status, string orderno, string buyer);

     /// <summary>
        /// ��ѯ��ö����������б�
        /// </summary>
        /// <param name="compid">�����ID</param>
        /// <param name="status">�����˶�״̬</param>
        /// <param name="member">���˻�Ա����</param>
        /// <param name="orderno">�������</param>
        /// <param name="buyer">����������</param>
        /// <param name="sdate">��ѯ������ʼʱ��</param>
        /// <param name="edate">��ѯ��������ʱ��</param>
        /// <returns></returns>
        DataTable GetAdvOrderList(int compid, int status, string member, string orderno, string buyer, string sdate, string edate);
        /// <summary>
        /// �˶Զ�������
        /// </summary>
        /// <param name="orderid">����ID</param>
        /// <param name="status">0��δ�˶�/1��ʾ��Ч/2��ʾ��Ч����</param>
        /// <param name="reason">��д��Ч����������</param>
        /// <returns></returns>
        int CheckAdvOrderStatus(int orderid, int status, string reason);
    }
}
