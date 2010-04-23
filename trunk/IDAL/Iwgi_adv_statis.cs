using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// 接口层Iwgi_adv_statis 的摘要说明。
	/// </summary>
	public interface Iwgi_adv_statis
	{
		#region  成员方法
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(wgiAdUnionSystem.Model.wgi_adv_statis model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_adv_statis model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete();
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		wgiAdUnionSystem.Model.wgi_adv_statis GetModel();
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
	}
}
