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
	/// ҵ���߼���wgi_cash ��ժҪ˵����
	/// </summary>
	public class wgi_cash
	{
		private readonly Iwgi_cash dal=(Iwgi_cash)DataAccess.CreateInstance("wgi_cash");
		public wgi_cash()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(wgiAdUnionSystem.Model.wgi_cash model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_cash model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_cash GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_cash GetModelByCache(int id)
		{
			
			string CacheKey = "wgi_cashModel-" + id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (wgiAdUnionSystem.Model.wgi_cash)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		// public DataSet GetList(int Top,string strWhere,string filedOrder)
		// {
			// return dal.GetList(Top,strWhere,filedOrder);
		// }
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_cash> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_cash> DataTableToList(DataTable dt)
		{
			List<wgiAdUnionSystem.Model.wgi_cash> modelList = new List<wgiAdUnionSystem.Model.wgi_cash>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				wgiAdUnionSystem.Model.wgi_cash model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new wgiAdUnionSystem.Model.wgi_cash();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
					}
					if(dt.Rows[n]["cash"].ToString()!="")
					{
						model.cash=decimal.Parse(dt.Rows[n]["cash"].ToString());
					}
					if(dt.Rows[n]["applydate"].ToString()!="")
					{
						model.applydate=DateTime.Parse(dt.Rows[n]["applydate"].ToString());
					}
					if(dt.Rows[n]["status"].ToString()!="")
					{
						model.status=int.Parse(dt.Rows[n]["status"].ToString());
					}
					if(dt.Rows[n]["leftcash"].ToString()!="")
					{
						model.leftcash=decimal.Parse(dt.Rows[n]["leftcash"].ToString());
					}
					model.memo_user=dt.Rows[n]["memo_user"].ToString();
					model.memo_admin=dt.Rows[n]["memo_admin"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}
