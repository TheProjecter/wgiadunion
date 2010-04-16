using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// 接口层Iwgi_adv 的摘要说明。
	/// </summary>
	public interface Iwgi_adv
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int advid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_adv model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_adv model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int advid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		wgiAdUnionSystem.Model.wgi_adv GetModel(int advid);
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
        /// 根据广告主ID获得广告列表
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="paytype">广告付费类型</param>
        /// <param name="display">广告显示类型</param>
        /// <returns></returns>
        DataTable GetAdvListByCompID(int compid, int? paytype, int? display);
          /// <summary>
        /// 根据广告主ID获得广告列表
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="paytype">广告付费类型</param>
        /// <param name="display">广告显示类型</param>
        ///<param name="display">广告显示开始时间</param>
        /// <param name="display">广告截止时间</param>
        /// <param name="isaudit">是否只显示通过审核的</param>
        /// <param name="ispublished">是否只显示投放中的</param>
        /// <returns></returns>
        DataTable GetAdvListByCompID(int compid, int paytype, int display, string beg, string end, string title, int? isaudit, int? ispublished);
	}
}
