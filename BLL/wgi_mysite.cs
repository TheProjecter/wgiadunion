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
	/// ҵ���߼���wgi_mysite ��ժҪ˵����
	/// </summary>
	public class wgi_mysite
	{
		private readonly Iwgi_mysite dal=(Iwgi_mysite)DataAccess.CreateInstance("wgi_mysite");
		public wgi_mysite()
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
		public bool Exists(int siteid)
		{
			return dal.Exists(siteid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(wgiAdUnionSystem.Model.wgi_mysite model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_mysite model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int siteid)
		{
			
			dal.Delete(siteid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_mysite GetModel(int siteid)
		{
			
			return dal.GetModel(siteid);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_mysite GetModelByCache(int siteid)
		{
			
			string CacheKey = "wgi_mysiteModel-" + siteid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(siteid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (wgiAdUnionSystem.Model.wgi_mysite)objModel;
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
		public List<wgiAdUnionSystem.Model.wgi_mysite> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_mysite> DataTableToList(DataTable dt)
		{
			List<wgiAdUnionSystem.Model.wgi_mysite> modelList = new List<wgiAdUnionSystem.Model.wgi_mysite>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				wgiAdUnionSystem.Model.wgi_mysite model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new wgiAdUnionSystem.Model.wgi_mysite();
					if(dt.Rows[n]["userid"].ToString()!="")
					{
						model.userid=int.Parse(dt.Rows[n]["userid"].ToString());
					}
					if(dt.Rows[n]["siteid"].ToString()!="")
					{
						model.siteid=int.Parse(dt.Rows[n]["siteid"].ToString());
					}
					model.sitename=dt.Rows[n]["sitename"].ToString();
					model.url=dt.Rows[n]["url"].ToString();
					model.siteremark=dt.Rows[n]["siteremark"].ToString();
					if(dt.Rows[n]["ipno"].ToString()!="")
					{
						model.ipno=int.Parse(dt.Rows[n]["ipno"].ToString());
					}
					if(dt.Rows[n]["pvno"].ToString()!="")
					{
						model.pvno=int.Parse(dt.Rows[n]["pvno"].ToString());
					}
					if(dt.Rows[n]["sitetype"].ToString()!="")
					{
						model.sitetype=int.Parse(dt.Rows[n]["sitetype"].ToString());
					}
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

