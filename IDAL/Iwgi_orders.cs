using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// 接口层Iwgi_orders 的摘要说明。
	/// </summary>
	public interface Iwgi_orders
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
		int Add(wgiAdUnionSystem.Model.wgi_orders model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_orders model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int orderid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		wgiAdUnionSystem.Model.wgi_orders GetModel(int orderid);
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
        /// 从视图获得所有记录
        /// </summary>
        /// <returns></returns>
        DataSet GetListFromView(string viewname, string strWhere);
	}
}
