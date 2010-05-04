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
	/// 业务逻辑类wgi_orders 的摘要说明。
	/// </summary>
	public class wgi_orders
	{
		private readonly Iwgi_orders dal=(Iwgi_orders)DataAccess.CreateInstance("wgi_orders");
		public wgi_orders()
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
		public bool Exists(int orderid)
		{
			return dal.Exists(orderid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(wgiAdUnionSystem.Model.wgi_orders model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_orders model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int orderid)
		{
			
			dal.Delete(orderid);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_orders GetModel(int orderid)
		{
			
			return dal.GetModel(orderid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_orders GetModelByCache(int orderid)
		{
			
			string CacheKey = "wgi_ordersModel-" + orderid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(orderid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (wgiAdUnionSystem.Model.wgi_orders)objModel;
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
		public List<wgiAdUnionSystem.Model.wgi_orders> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_orders> DataTableToList(DataTable dt)
		{
			List<wgiAdUnionSystem.Model.wgi_orders> modelList = new List<wgiAdUnionSystem.Model.wgi_orders>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				wgiAdUnionSystem.Model.wgi_orders model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new wgiAdUnionSystem.Model.wgi_orders();
					if(dt.Rows[n]["orderid"].ToString()!="")
					{
						model.orderid=int.Parse(dt.Rows[n]["orderid"].ToString());
					}
					if(dt.Rows[n]["companyid"].ToString()!="")
					{
						model.companyid=int.Parse(dt.Rows[n]["companyid"].ToString());
					}
					if(dt.Rows[n]["siteid"].ToString()!="")
					{
						model.siteid=int.Parse(dt.Rows[n]["siteid"].ToString());
					}
					model.orderno=dt.Rows[n]["orderno"].ToString();
					if(dt.Rows[n]["cash"].ToString()!="")
					{
						model.cash=decimal.Parse(dt.Rows[n]["cash"].ToString());
					}
					if(dt.Rows[n]["time"].ToString()!="")
					{
						model.time=DateTime.Parse(dt.Rows[n]["time"].ToString());
					}
					model.consumer=dt.Rows[n]["consumer"].ToString();
					model.itemno=dt.Rows[n]["itemno"].ToString();
					if(dt.Rows[n]["itemprice"].ToString()!="")
					{
						model.itemprice=decimal.Parse(dt.Rows[n]["itemprice"].ToString());
					}
					if(dt.Rows[n]["itemamount"].ToString()!="")
					{
						model.itemamount=decimal.Parse(dt.Rows[n]["itemamount"].ToString());
					}
					if(dt.Rows[n]["pay"].ToString()!="")
					{
						model.pay=decimal.Parse(dt.Rows[n]["pay"].ToString());
					}
					if(dt.Rows[n]["ischeck"].ToString()!="")
					{
						model.ischeck=int.Parse(dt.Rows[n]["ischeck"].ToString());
					}
					model.reason=dt.Rows[n]["reason"].ToString();
					if(dt.Rows[n]["checktime"].ToString()!="")
					{
						model.checktime=DateTime.Parse(dt.Rows[n]["checktime"].ToString());
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


        /// <summary>
        /// 从视图获得所有记录
        /// </summary>
        /// <returns></returns>
        public DataSet GetListFromView(string viewname, string strWhere)
        {
            return dal.GetListFromView(viewname, strWhere);
        }
	}
}

