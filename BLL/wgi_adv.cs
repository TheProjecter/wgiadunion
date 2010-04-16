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
    /// ҵ���߼���wgi_adv ��ժҪ˵����
    /// </summary>
    public class wgi_adv
    {
        private readonly Iwgi_adv dal = (Iwgi_adv)DataAccess.CreateInstance("wgi_adv");
        public wgi_adv()
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
        public bool Exists(int advid)
        {
            return dal.Exists(advid);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(wgiAdUnionSystem.Model.wgi_adv model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_adv model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int advid)
        {

            dal.Delete(advid);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_adv GetModel(int advid)
        {

            return dal.GetModel(advid);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_adv GetModelByCache(int advid)
        {

            string CacheKey = "wgi_advModel-" + advid;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(advid);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (wgiAdUnionSystem.Model.wgi_adv)objModel;
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
        // public DataSet GetList(int Top,string strWhere,string filedOrder)
        // {
        // return dal.GetList(Top,strWhere,filedOrder);
        // }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_adv> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_adv> DataTableToList(DataTable dt)
        {
            List<wgiAdUnionSystem.Model.wgi_adv> modelList = new List<wgiAdUnionSystem.Model.wgi_adv>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                wgiAdUnionSystem.Model.wgi_adv model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new wgiAdUnionSystem.Model.wgi_adv();
                    if (dt.Rows[n]["advid"].ToString() != "")
                    {
                        model.advid = int.Parse(dt.Rows[n]["advid"].ToString());
                    }
                    if (dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    model.advname = dt.Rows[n]["advname"].ToString();
                    if (dt.Rows[n]["advtype"].ToString() != "")
                    {
                        model.advtype = int.Parse(dt.Rows[n]["advtype"].ToString());
                    }
                    model.advcont = dt.Rows[n]["advcont"].ToString();
                    model.advlink = dt.Rows[n]["advlink"].ToString();
                    if (dt.Rows[n]["advwidth"].ToString() != "")
                    {
                        model.advwidth = int.Parse(dt.Rows[n]["advwidth"].ToString());
                    }
                    if (dt.Rows[n]["advheight"].ToString() != "")
                    {
                        model.advheight = int.Parse(dt.Rows[n]["advheight"].ToString());
                    }
                    if (dt.Rows[n]["advuptime"].ToString() != "")
                    {
                        model.advuptime = DateTime.Parse(dt.Rows[n]["advuptime"].ToString());
                    }
                    if (dt.Rows[n]["advstatus"].ToString() != "")
                    {
                        model.advstatus = int.Parse(dt.Rows[n]["advstatus"].ToString());
                    }
                    if (dt.Rows[n]["advstart"].ToString() != "")
                    {
                        model.advstart = DateTime.Parse(dt.Rows[n]["advstart"].ToString());
                    }
                    if (dt.Rows[n]["advend"].ToString() != "")
                    {
                        model.advend = DateTime.Parse(dt.Rows[n]["advend"].ToString());
                    }
                    if (dt.Rows[n]["advinvalid"].ToString() != "")
                    {
                        model.advinvalid = int.Parse(dt.Rows[n]["advinvalid"].ToString());
                    }
                    if (dt.Rows[n]["advpaytype"].ToString() != "")
                    {
                        model.advpaytype = int.Parse(dt.Rows[n]["advpaytype"].ToString());
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
        /// ���ݹ����ID��ù���б�
        /// </summary>
        /// <param name="compid">�����ID</param>
        /// <param name="paytype">��渶������</param>
        /// <param name="display">�����ʾ����</param>
        /// <returns></returns>
        public DataTable GetAdvListByCompID(int compid, int? paytype, int? display)
        {
            return dal.GetAdvListByCompID(compid,paytype,display);
        }
        /// <summary>
        /// ���ݹ����ID��ù���б�
        /// </summary>
        /// <param name="compid">�����ID</param>
        /// <param name="paytype">��渶������</param>
        /// <param name="display">�����ʾ����</param>
        ///<param name="display">�����ʾ��ʼʱ��</param>
        /// <param name="display">����ֹʱ��</param>
        /// <param name="display">���ؼ�����</param>
        /// <param name="isaudit">�Ƿ�ֻ��ʾͨ����˵�</param>
        /// <param name="ispublished">�Ƿ�ֻ��ʾͶ���е�</param>
        /// <returns></returns>
        public DataTable GetAdvListByCompID(int compid, int paytype, int display, string beg, string end, string title, int? isaudit, int? ispublished)
        {
            return dal.GetAdvListByCompID(compid, paytype, display, beg, end, title, isaudit, ispublished);
        }
    }
}

