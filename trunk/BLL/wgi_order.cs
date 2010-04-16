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
    /// 业务逻辑类wgi_order 的摘要说明。
    /// </summary>
    public class wgi_order
    {
        private readonly Iwgi_order dal = (Iwgi_order)DataAccess.CreateInstance("wgi_order");
        public wgi_order()
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
        public bool Exists(int orderid)
        {
            return dal.Exists(orderid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(wgiAdUnionSystem.Model.wgi_order model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_order model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int orderid)
        {

            dal.Delete(orderid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_order GetModel(int orderid)
        {

            return dal.GetModel(orderid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
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
        public List<wgiAdUnionSystem.Model.wgi_order> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
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
        /// 查询广告订单信息
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="status">订单核对状态</param>
        /// <param name="orderno">订单编号</param>
        /// <param name="buyer">订单购买人</param>
        /// <returns></returns>
        public DataTable GetAdvOrderList(int compid, int status, string orderno, string buyer)
        {
            return dal.GetAdvOrderList(compid, status, orderno, buyer);
        }

        /// <summary>
        /// 查询获得订单的数据列表
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="status">订单核对状态</param>
        /// <param name="member">联盟会员名称</param>
        /// <param name="orderno">订单编号</param>
        /// <param name="buyer">订单购买人</param>
        /// <param name="sdate">查询订单起始时间</param>
        /// <param name="edate">查询订单结束时间</param>
        /// <returns></returns>
        public DataTable GetAdvOrderList(int compid, int status, string member, string orderno, string buyer, string sdate, string edate)
        {
            return dal.GetAdvOrderList(compid, status, member, orderno, buyer, sdate, edate);
        }
          /// <summary>
        /// 核对订单操作
        /// </summary>
        /// <param name="orderid">订单ID</param>
        /// <param name="status">0表未无效/1表示有效</param>
        /// <param name="reason">填写无效订单的理由</param>
        /// <returns></returns>
        public int CheckAdvOrderStatus(int orderid, int status, string reason)
        {
            return dal.CheckAdvOrderStatus(orderid, status, reason);
        }
    }
}
