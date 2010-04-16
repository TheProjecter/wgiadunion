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
	/// 业务逻辑类wgi_adhost_usersite 的摘要说明。
	/// </summary>
	public class wgi_adhost_usersite
	{
		private readonly Iwgi_adhost_usersite dal=(Iwgi_adhost_usersite)DataAccess.CreateInstance("wgi_adhost_usersite");
		public wgi_adhost_usersite()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int auid)
        {
            return dal.Exists(auid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(wgiAdUnionSystem.Model.wgi_adhost_usersite model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_adhost_usersite model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int auid)
        {

            dal.Delete(auid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_adhost_usersite GetModel(int auid)
        {

            return dal.GetModel(auid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        //public DataSet GetList(int Top, string strWhere, string filedOrder)
        //{
        //    return dal.GetList(Top, strWhere, filedOrder);
        //}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_adhost_usersite> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}


		#endregion  成员方法

        /// <summary>
        /// 根据广告主ID与审核状态获得加入广告主的网站列表
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="status">审核状态</param>
        /// <param name="status">网站名称</param>
        /// <returns></returns>
        public DataTable GetWebSiteWithAdvList(int compid, int status,string sitename)
        {
            return dal.GetWebSiteWithAdvList(compid, status, sitename);
        }

        /// <summary>
        /// 批量修改申请加入推广的网站状态，用于审核，拒绝等操作
        /// </summary>
        /// <param name="ids">选择的网站主</param>
        /// <param name="status"></param>
        public int ChangeApplySiteStatus(List<string> ids, int status)
        {
            return dal.ChangeApplySiteStatus(ids, status);
        }
	}
}

