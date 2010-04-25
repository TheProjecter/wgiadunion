using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using wgiAdUnionSystem.Model;
using wgiAdUnionSystem.DALFactory;
using wgiAdUnionSystem.IDAL;
namespace wgiAdUnionSystem.BLL
{
	/// <summary>
	/// 业务逻辑类wgi_sitehost 的摘要说明。
	/// </summary>
	public class wgi_sitehost
	{
		private readonly Iwgi_sitehost dal=(Iwgi_sitehost)DataAccess.CreateInstance("wgi_sitehost");
		public wgi_sitehost()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int userid)
		{
			return dal.Exists(userid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(wgiAdUnionSystem.Model.wgi_sitehost model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_sitehost model)
		{
			dal.Update(model);
		}
        
        /// <summary>
        /// 更新上次登录时间
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="time"></param>
        public void updateLoginTime(int userid, string time)
        {
            dal.updateLoginTime(userid, time);
        }

        /// <summary>
        /// 重设密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newpwd"></param>
        public void updatePwd(int userid, string newpwd)
        {
            dal.updatePwd(userid, newpwd);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userid)
		{
			
			dal.Delete(userid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_sitehost GetModel(int userid)
		{
			
			return dal.GetModel(userid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_sitehost GetModelByCache(int userid)
		{
			
			string CacheKey = "wgi_sitehostModel-" + userid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(userid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (wgiAdUnionSystem.Model.wgi_sitehost)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        public DataSet GetListByUsername(string username)
        {
            return dal.GetListByUsername(username);
        }
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		// public DataSet GetList(int Top,string strWhere,string filedOrder)
		// {
			// return dal.GetList(Top,strWhere,filedOrder);
		// }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_sitehost> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_sitehost> DataTableToList(DataTable dt)
		{
			List<wgiAdUnionSystem.Model.wgi_sitehost> modelList = new List<wgiAdUnionSystem.Model.wgi_sitehost>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				wgiAdUnionSystem.Model.wgi_sitehost model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new wgiAdUnionSystem.Model.wgi_sitehost();
					if(dt.Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
					}
					model.username=dt.Rows[n]["username"].ToString();
					model.password=dt.Rows[n]["password"].ToString();
					model.email=dt.Rows[n]["email"].ToString();
					model.mobile=dt.Rows[n]["mobile"].ToString();
					model.accountname=dt.Rows[n]["accountname"].ToString();
					model.accountno=dt.Rows[n]["accountno"].ToString();
					model.bank=dt.Rows[n]["bank"].ToString();
					model.branch=dt.Rows[n]["branch"].ToString();
					if(dt.Rows[n]["usertype"].ToString()!="")
					{
						model.usertype=int.Parse(dt.Rows[n]["usertype"].ToString());
					}
					model.contact=dt.Rows[n]["contact"].ToString();
					model.qq=dt.Rows[n]["qq"].ToString();
					model.idcard=dt.Rows[n]["idcard"].ToString();
					model.address=dt.Rows[n]["address"].ToString();
					model.zipcode=dt.Rows[n]["zipcode"].ToString();
					model.tel=dt.Rows[n]["tel"].ToString();
					if(dt.Rows[n]["balance"].ToString()!="")
					{
						model.balance=decimal.Parse(dt.Rows[n]["balance"].ToString());
					}
					if(dt.Rows[n]["regdate"].ToString()!="")
					{
						model.regdate=DateTime.Parse(dt.Rows[n]["regdate"].ToString());
					}
					model.regip=dt.Rows[n]["regip"].ToString();
					if(dt.Rows[n]["lastdate"].ToString()!="")
					{
						model.lastdate=DateTime.Parse(dt.Rows[n]["lastdate"].ToString());
					}
					model.lastip=dt.Rows[n]["lastip"].ToString();
					if(dt.Rows[n]["status"].ToString()!="")
					{
						model.status=int.Parse(dt.Rows[n]["status"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}


		#endregion  成员方法
	}
}

