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
	/// ҵ���߼���wgi_discount ��ժҪ˵����
	/// </summary>
	public class wgi_discount
	{
		private readonly Iwgi_discount dal=(Iwgi_discount)DataAccess.CreateInstance("wgi_discount");
		public wgi_discount()
		{}
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
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(wgiAdUnionSystem.Model.wgi_discount model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_discount model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_discount GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_discount GetModelByCache(int id)
        {

            string CacheKey = "wgi_discountModel-" + id;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (wgiAdUnionSystem.Model.wgi_discount)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
       
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_discount> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_discount> DataTableToList(DataTable dt)
        {
            List<wgiAdUnionSystem.Model.wgi_discount> modelList = new List<wgiAdUnionSystem.Model.wgi_discount>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                wgiAdUnionSystem.Model.wgi_discount model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new wgiAdUnionSystem.Model.wgi_discount();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    model.payamt = dt.Rows[n]["payamt"].ToString();
                    model.payintro = dt.Rows[n]["payintro"].ToString();
                    if (dt.Rows[n]["endtime"].ToString() != "")
                    {
                        model.endtime = DateTime.Parse(dt.Rows[n]["endtime"].ToString());
                    }
                    if (dt.Rows[n]["addtime"].ToString() != "")
                    {
                        model.addtime = DateTime.Parse(dt.Rows[n]["addtime"].ToString());
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
        /// ���ݹ����ID�ͽ�ֹ���ڻ�ȡ����Ӷ���׼˵��
        /// </summary>
        /// <param name="compid"></param>
        /// <param name="compid"></param>
        /// <param name="compid"></param>
        /// <returns></returns>
        public DataTable GetPaymentListByCompanyID(int compid, string beg_date, string end_date)
        {
            return dal.GetPaymentListByCompanyID(compid, beg_date, end_date);
        }
        
	}
}

