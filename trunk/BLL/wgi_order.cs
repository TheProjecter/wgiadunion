using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using wgiAdUnionSystem.Model;
using wgiAdUnionSystem.DALFactory;
using wgiAdUnionSystem.IDAL;
namespace wgiAdUnionSystem.BLL
{
    /// <summary>
    /// ҵ���߼���wgi_order ��ժҪ˵����
    /// </summary>
    public class wgi_order
    {
        private readonly Iwgi_order dal = (Iwgi_order)DataAccess.CreateInstance("wgi_order");
        public wgi_order()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int orderid)
        {
            return dal.Exists(orderid);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(wgiAdUnionSystem.Model.wgi_order model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_order model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int orderid)
        {

            dal.Delete(orderid);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_order GetModel(int orderid)
        {

            return dal.GetModel(orderid);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_order GetModelByCache(int orderid)
        {

            string CacheKey = "wgi_orderModel-" + orderid;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(orderid);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (wgiAdUnionSystem.Model.wgi_order)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dal.GetList(Top, strWhere, filedOrder);
        //}
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_order> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_order> DataTableToList(DataTable dt)
        {
            List<wgiAdUnionSystem.Model.wgi_order> modelList = new List<wgiAdUnionSystem.Model.wgi_order>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                wgiAdUnionSystem.Model.wgi_order model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new wgiAdUnionSystem.Model.wgi_order();
                    if (dt.Rows[n]["orderid"].ToString() != "")
                    {
                        model.orderid = int.Parse(dt.Rows[n]["orderid"].ToString());
                    }
                    if (dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    model.username = dt.Rows[n]["username"].ToString();
                    model.orderno = dt.Rows[n]["orderno"].ToString();
                    if (dt.Rows[n]["orderamt"].ToString() != "")
                    {
                        model.orderamt = decimal.Parse(dt.Rows[n]["orderamt"].ToString());
                    }
                    if (dt.Rows[n]["ordertime"].ToString() != "")
                    {
                        model.ordertime = DateTime.Parse(dt.Rows[n]["ordertime"].ToString());
                    }
                    model.consumer = dt.Rows[n]["consumer"].ToString();
                    model.itemno = dt.Rows[n]["itemno"].ToString();
                    if (dt.Rows[n]["payamt"].ToString() != "")
                    {
                        model.payamt = decimal.Parse(dt.Rows[n]["payamt"].ToString());
                    }
                    if (dt.Rows[n]["ischeck"].ToString() != "")
                    {
                        model.ischeck = int.Parse(dt.Rows[n]["ischeck"].ToString());
                    }
                    if (dt.Rows[n]["ispay"].ToString() != "")
                    {
                        model.ispay = int.Parse(dt.Rows[n]["ispay"].ToString());
                    }
                    model.reason = dt.Rows[n]["reason"].ToString();
                    if (dt.Rows[n]["paytime"].ToString() != "")
                    {
                        model.paytime = DateTime.Parse(dt.Rows[n]["paytime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����

          /// <summary>
        /// ��ѯ��涩����Ϣ
        /// </summary>
        /// <param name="compid">�����ID</param>
        /// <param name="status">�����˶�״̬</param>
        /// <param name="orderno">�������</param>
        /// <param name="buyer">����������</param>
        /// <returns></returns>
        public DataTable GetAdvOrderList(int compid, int status, string orderno, string buyer)
        {
            return dal.GetAdvOrderList(compid, status, orderno, buyer);
        }

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
        public DataTable GetAdvOrderList(int compid, int status, string member, string orderno, string buyer, string sdate, string edate)
        {
            return dal.GetAdvOrderList(compid, status, member, orderno, buyer, sdate, edate);
        }
          /// <summary>
        /// �˶Զ�������
        /// </summary>
        /// <param name="orderid">����ID</param>
        /// <param name="status">0��δ��Ч/1��ʾ��Ч</param>
        /// <param name="reason">��д��Ч����������</param>
        /// <returns></returns>
        public int CheckAdvOrderStatus(int orderid, int status, string reason)
        {
            return dal.CheckAdvOrderStatus(orderid, status, reason);
        }
    }
}