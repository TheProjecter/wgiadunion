using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// 接口层Iwgi_adhost 的摘要说明。
	/// </summary>
	public interface Iwgi_adhost
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int companyid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_adhost model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_adhost model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int companyid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		wgiAdUnionSystem.Model.wgi_adhost GetModel(int companyid);
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
