using System;
using System.Data;
namespace wgiAdUnionSystem.IDAL
{
	/// <summary>
	/// 接口层Iwgi_sitehost 的摘要说明。
	/// </summary>
	public interface Iwgi_sitehost
	{
        #region  成员方法
        /// <summary>
        /// 重设密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newpwd"></param>
        void updatePwd(int userid, string newpwd);
        /// <summary>
        /// 更新上次登录时间
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="time"></param>
        void updateLoginTime(int userid, string time);
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int userid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(wgiAdUnionSystem.Model.wgi_sitehost model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(wgiAdUnionSystem.Model.wgi_sitehost model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int userid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		wgiAdUnionSystem.Model.wgi_sitehost GetModel(int userid);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
        DataSet GetListByUsername(string username);
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
        /// 获得搜索结果列表
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="realname">真实姓名</param>
        /// <param name="email">邮箱</param>
        /// <param name="sitename">网站名</param>
        /// <returns></returns>
        DataSet GetListOfSearch(string username, string realname, string email, string sitename);

        void Delete(string ids);
        void UpdateBlance(int userid, decimal c);
	}
}
