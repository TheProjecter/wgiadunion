using System;
using System.Data;
using System.Collections.Generic;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// 接口层Iwgi_mysite 的摘要说明。
	/// </summary>
	public interface Iwgi_usersite
	{
		#region  成员方法
        /// <summary>
        /// 根据用户ID获得所有其登记网站
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        DataSet getListByUserId(int userid);
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int siteid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_usersite model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_usersite model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int siteid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		wgiAdUnionSystem.Model.wgi_usersite GetModel(int siteid);
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

       
	}
}
