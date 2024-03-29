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
        #endregion  成员方法
        /// <summary>
        /// 更新私信状态
        /// </summary>
        /// <param name="id"></param>
        void UpdateReadStatus(string ids, int status);

        /// <summary>
        /// 删除一组私信
        /// </summary>
        void DeleteByIds(string ids);

        /// <summary>
        /// 得到所有公共消息
        /// </summary>
        /// <returns></returns>
        DataSet getListOfPublic(int usertype, int userid);

        /// <summary>
        /// 得到私人消息
        /// </summary>
        /// <param name="objid"></param>
        /// <param name="objtype"></param>
        /// <returns></returns>
        DataSet getLIstOfPrivate(int objid, int objtype);



        /// <summary>
        /// 得到固定组别的所有公共消息
        /// </summary>
        /// <returns></returns>
        DataSet getListOfGroupPublic(int usertype, int userid);

        DataSet getPrivateByQuery(string strWhere);

	}
}
