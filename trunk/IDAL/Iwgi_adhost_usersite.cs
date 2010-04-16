using System;
using System.Data;
using System.Collections.Generic;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// 接口层Iwgi_adhost_usersite 的摘要说明。
	/// </summary>
	public interface Iwgi_adhost_usersite
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_adhost_usersite model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_adhost_usersite model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		wgiAdUnionSystem.Model.wgi_adhost_usersite GetModel(int id);
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
        /// 根据广告主ID与审核状态获得加入广告主的网站列表
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="status">审核状态</param>
        /// <returns></returns>
        DataTable GetWebSiteWithAdvList(int compid, int status,string sitename);

        /// <summary>
        /// 批量修改申请加入推广的网站状态，用于审核，拒绝等操作
        /// </summary>
        /// <param name="ids">选择的网站主</param>
        /// <param name="status"></param>
        int ChangeApplySiteStatus(List<string> ids, int status);

	}
}
