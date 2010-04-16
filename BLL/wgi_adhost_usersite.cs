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
	/// ҵ���߼���wgi_adhost_usersite ��ժҪ˵����
	/// </summary>
	public class wgi_adhost_usersite
	{
		private readonly Iwgi_adhost_usersite dal=(Iwgi_adhost_usersite)DataAccess.CreateInstance("wgi_adhost_usersite");
		public wgi_adhost_usersite()
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
        public bool Exists(int auid)
        {
            return dal.Exists(auid);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(wgiAdUnionSystem.Model.wgi_adhost_usersite model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_adhost_usersite model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int auid)
        {

            dal.Delete(auid);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_adhost_usersite GetModel(int auid)
        {

            return dal.GetModel(auid);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_adhost_usersite GetModelByCache(int auid)
        {

            string CacheKey = "wgi_adhost_usersiteModel-" + auid;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(auid);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (wgiAdUnionSystem.Model.wgi_adhost_usersite)objModel;
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
        public List<wgiAdUnionSystem.Model.wgi_adhost_usersite> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_adhost_usersite> DataTableToList(DataTable dt)
        {
            List<wgiAdUnionSystem.Model.wgi_adhost_usersite> modelList = new List<wgiAdUnionSystem.Model.wgi_adhost_usersite>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                wgiAdUnionSystem.Model.wgi_adhost_usersite model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new wgiAdUnionSystem.Model.wgi_adhost_usersite();
                    if (dt.Rows[n]["auid"].ToString() != "")
                    {
                        model.auid = int.Parse(dt.Rows[n]["auid"].ToString());
                    }
                    if (dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    if (dt.Rows[n]["siteid"].ToString() != "")
                    {
                        model.siteid = int.Parse(dt.Rows[n]["siteid"].ToString());
                    }
                    if (dt.Rows[n]["status"].ToString() != "")
                    {
                        model.status = int.Parse(dt.Rows[n]["status"].ToString());
                    }
                    if (dt.Rows[n]["applytime"].ToString() != "")
                    {
                        model.applytime = DateTime.Parse(dt.Rows[n]["applytime"].ToString());
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
        /// ���ݹ����ID�����״̬��ü�����������վ�б�
        /// </summary>
        /// <param name="compid">�����ID</param>
        /// <param name="status">���״̬</param>
        /// <param name="status">��վ����</param>
        /// <returns></returns>
        public DataTable GetWebSiteWithAdvList(int compid, int status,string sitename)
        {
            return dal.GetWebSiteWithAdvList(compid, status, sitename);
        }

        /// <summary>
        /// �����޸���������ƹ����վ״̬��������ˣ��ܾ��Ȳ���
        /// </summary>
        /// <param name="ids">ѡ�����վ��</param>
        /// <param name="status"></param>
        public int ChangeApplySiteStatus(List<string> ids, int status)
        {
            return dal.ChangeApplySiteStatus(ids, status);
        }
	}
}

