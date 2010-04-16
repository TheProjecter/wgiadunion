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
	/// ҵ���߼���wgi_loginlog ��ժҪ˵����
	/// </summary>
	public class wgi_loginlog
	{
		private readonly Iwgi_loginlog dal=(Iwgi_loginlog)DataAccess.CreateInstance("wgi_loginlog");
		public wgi_loginlog()
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
		public bool Exists(int logid)
		{
			return dal.Exists(logid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(wgiAdUnionSystem.Model.wgi_loginlog model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_loginlog model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int logid)
		{
			
			dal.Delete(logid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_loginlog GetModel(int logid)
		{
			
			return dal.GetModel(logid);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_loginlog GetModelByCache(int logid)
		{
			
			string CacheKey = "wgi_loginlogModel-" + logid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(logid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (wgiAdUnionSystem.Model.wgi_loginlog)objModel;
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
		public List<wgiAdUnionSystem.Model.wgi_loginlog> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_loginlog> DataTableToList(DataTable dt)
		{
			List<wgiAdUnionSystem.Model.wgi_loginlog> modelList = new List<wgiAdUnionSystem.Model.wgi_loginlog>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				wgiAdUnionSystem.Model.wgi_loginlog model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new wgiAdUnionSystem.Model.wgi_loginlog();
					if(dt.Rows[n]["logid"].ToString()!="")
					{
						model.logid=int.Parse(dt.Rows[n]["logid"].ToString());
					}
					if(dt.Rows[n]["usertype"].ToString()!="")
					{
						model.usertype=int.Parse(dt.Rows[n]["usertype"].ToString());
					}
					if(dt.Rows[n]["logtime"].ToString()!="")
					{
						model.logtime=DateTime.Parse(dt.Rows[n]["logtime"].ToString());
					}
					model.logip=dt.Rows[n]["logip"].ToString();
					model.logname=dt.Rows[n]["logname"].ToString();
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

