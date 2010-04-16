using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
    /// <summary>
    /// 接口层Iwgi_order 的摘要说明。
    /// </summary>
    public interface Iwgi_order
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int orderid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(wgiAdUnionSystem.Model.wgi_order model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(wgiAdUnionSystem.Model.wgi_order model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(int orderid);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        wgiAdUnionSystem.Model.wgi_order GetModel(int orderid);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        //DataSet GetList(int Top,string strWhere,string filedOrder);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法

        /// <summary>
        /// 查询广告订单信息
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="status">订单核对状态</param>
        /// <param name="orderno">订单编号</param>
        /// <param name="buyer">订单购买人</param>
        /// <returns></returns>
        DataTable GetAdvOrderList(int compid, int status, string orderno, string buyer);

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
        DataTable GetAdvOrderList(int compid, int status, string member, string orderno, string buyer, string sdate, string edate);
        /// <summary>
        /// 核对订单操作
        /// </summary>
        /// <param name="orderid">订单ID</param>
        /// <param name="status">0表未核对/1表示有效/2表示无效订单</param>
        /// <param name="reason">填写无效订单的理由</param>
        /// <returns></returns>
        int CheckAdvOrderStatus(int orderid, int status, string reason);
    }
}
