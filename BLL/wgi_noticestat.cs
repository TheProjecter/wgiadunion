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
    /// 业务逻辑类wgi_noticestat 的摘要说明。
    /// </summary>
    public class wgi_noticestat
    {
        private readonly Iwgi_noticestat dal = (Iwgi_noticestat)DataAccess.CreateInstance("wgi_noticestat");
        public wgi_noticestat()
        { }
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
        public void Add(wgiAdUnionSystem.Model.wgi_noticestat model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_noticestat model)
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
        public wgiAdUnionSystem.Model.wgi_noticestat GetModel(int id)
        {

            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_noticestat GetModelByCache(int id)
        {

            string CacheKey = "wgi_noticestatModel-" + id;
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
            return (wgiAdUnionSystem.Model.wgi_noticestat)objModel;
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
        public List<wgiAdUnionSystem.Model.wgi_noticestat> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<wgiAdUnionSystem.Model.wgi_noticestat> DataTableToList(DataTable dt)
        {
            List<wgiAdUnionSystem.Model.wgi_noticestat> modelList = new List<wgiAdUnionSystem.Model.wgi_noticestat>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                wgiAdUnionSystem.Model.wgi_noticestat model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new wgiAdUnionSystem.Model.wgi_noticestat();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    if (dt.Rows[n]["noticeid"].ToString() != "")
                    {
                        model.noticeid = int.Parse(dt.Rows[n]["noticeid"].ToString());
                    }
                    if (dt.Rows[n]["usertype"].ToString() != "")
                    {
                        model.usertype = int.Parse(dt.Rows[n]["usertype"].ToString());
                    }
                    if (dt.Rows[n]["userid"].ToString() != "")
                    {
                        model.userid = int.Parse(dt.Rows[n]["userid"].ToString());
                    }
                    if (dt.Rows[n]["unread"].ToString() != "")
                    {
                        model.unread = int.Parse(dt.Rows[n]["unread"].ToString());
                    }
                    if (dt.Rows[n]["deleted"].ToString() != "")
                    {
                        model.deleted = int.Parse(dt.Rows[n]["deleted"].ToString());
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


        public void UpdateDelete(int noticeid, int userid, int usertype)
        {
            dal.UpdateDelete(noticeid, userid, usertype);
        }

        public void UpdateRead(int noticeid, int status, int userid, int usertype)
        {
            dal.UpdateRead(noticeid, status, userid, usertype);
        }

    }
}

