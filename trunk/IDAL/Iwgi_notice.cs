using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// 接口层Iwgi_notice 的摘要说明。
	/// </summary>
	public interface Iwgi_notice
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
		int Add(wgiAdUnionSystem.Model.wgi_notice model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_notice model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		wgiAdUnionSystem.Model.wgi_notice GetModel(int id);
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
        
        /// <summary>
        /// 更新阅读状态
        /// </summary>
        /// <param name="id"></param>
        void UpdateReadStatus(int id, int status);
		#endregion  成员方法
	}
}
