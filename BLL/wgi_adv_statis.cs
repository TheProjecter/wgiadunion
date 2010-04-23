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
	/// 业务逻辑类wgi_adv_statis 的摘要说明。
	/// </summary>
	public class wgi_adv_statis
	{
		private readonly Iwgi_adv_statis dal=(Iwgi_adv_statis)DataAccess.CreateInstance("wgi_adv_statis");
		public wgi_adv_statis()
		{}
		#region  成员方法

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(wgiAdUnionSystem.Model.wgi_adv_statis model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_adv_statis model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_adv_statis GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_adv_statis GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "wgi_adv_statisModel-" ;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (wgiAdUnionSystem.Model.wgi_adv_statis)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
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
		public List<wgiAdUnionSystem.Model.wgi_adv_statis> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_adv_statis> DataTableToList(DataTable dt)
		{
			List<wgiAdUnionSystem.Model.wgi_adv_statis> modelList = new List<wgiAdUnionSystem.Model.wgi_adv_statis>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				wgiAdUnionSystem.Model.wgi_adv_statis model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new wgiAdUnionSystem.Model.wgi_adv_statis();
					if(dt.Rows[n]["companyid"].ToString()!="")
					{
						model.companyid=int.Parse(dt.Rows[n]["companyid"].ToString());
					}
					if(dt.Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
					}
					if(dt.Rows[n]["siteid"].ToString()!="")
					{
						model.siteid=int.Parse(dt.Rows[n]["siteid"].ToString());
					}
					if(dt.Rows[n]["advid"].ToString()!="")
					{
						model.advid=int.Parse(dt.Rows[n]["advid"].ToString());
					}
					if(dt.Rows[n]["advtype"].ToString()!="")
					{
						model.advtype=int.Parse(dt.Rows[n]["advtype"].ToString());
					}
					if(dt.Rows[n]["statistype"].ToString()!="")
					{
						model.statistype=int.Parse(dt.Rows[n]["statistype"].ToString());
					}
					if(dt.Rows[n]["recordtime"].ToString()!="")
					{
						model.recordtime=DateTime.Parse(dt.Rows[n]["recordtime"].ToString());
					}
					model.ip=dt.Rows[n]["ip"].ToString();
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

