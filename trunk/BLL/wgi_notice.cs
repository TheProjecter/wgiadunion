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
	/// 业务逻辑类wgi_notice 的摘要说明。
	/// </summary>
	public class wgi_notice
	{
		private readonly Iwgi_notice dal=(Iwgi_notice)DataAccess.CreateInstance("wgi_notice");
		public wgi_notice()
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
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(wgiAdUnionSystem.Model.wgi_notice model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_notice model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_notice GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_notice GetModelByCache(int id)
        {

            string CacheKey = "wgi_noticeModel-" + id;
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
            return (wgiAdUnionSystem.Model.wgi_notice)objModel;
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
        // public DataSet GetList(int Top,string strWhere,string filedOrder)
        // {
        // return dal.GetList(Top,strWhere,filedOrder);
        // }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_notice> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_notice> DataTableToList(DataTable dt)
        {
            List<wgiAdUnionSystem.Model.wgi_notice> modelList = new List<wgiAdUnionSystem.Model.wgi_notice>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                wgiAdUnionSystem.Model.wgi_notice model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new wgiAdUnionSystem.Model.wgi_notice();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.title = dt.Rows[n]["title"].ToString();
                    model.notice = dt.Rows[n]["notice"].ToString();
                    if (dt.Rows[n]["pubdate"].ToString() != "")
                    {
                        model.pubdate = DateTime.Parse(dt.Rows[n]["pubdate"].ToString());
                    }
                    if (dt.Rows[n]["unread"].ToString() != "")
                    {
                        model.unread = int.Parse(dt.Rows[n]["unread"].ToString());
                    }
                    if (dt.Rows[n]["publisher"].ToString() != "")
                    {
                        model.publisher = int.Parse(dt.Rows[n]["publisher"].ToString());
                    }
                    if (dt.Rows[n]["objid"].ToString() != "")
                    {
                        model.objid = int.Parse(dt.Rows[n]["objid"].ToString());
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
        /// 更新阅读状态
        /// </summary>
        /// <param name="id"></param>
        public void UpdateReadStatus(string ids, int status)
        {
            dal.UpdateReadStatus(ids, status);
        }

        /// <summary>
        /// 删除多条消息
        /// </summary>
        /// <param name="ids"></param>
        public void Delete(string ids)
        {
            dal.DeleteByIds(ids);
        }


        /// <summary>
        /// 得到所有公共消息
        /// </summary>
        /// <returns></returns>
        public DataSet getListOfPublic(int usertype, int userid)
        {
            return dal.getListOfPublic(usertype, userid);
        }

        /// <summary>
        /// 得到私人消息
        /// </summary>
        /// <param name="objid"></param>
        /// <returns></returns>
        public DataSet getLIstOfPrivate(int objid, int objtype)
        {
            return dal.getLIstOfPrivate(objid,objtype);
        }


        /// <summary>
        /// 得到固定组别的所有公共消息
        /// </summary>
        /// <returns></returns>
        public DataSet getListOfGroupPublic(int usertype, int userid)
        {
            return dal.getListOfGroupPublic(usertype, userid);

        }

        public DataSet getPrivateByQuery(string strWhere)
        {
            return dal.getPrivateByQuery(strWhere);
        }

	}
}

