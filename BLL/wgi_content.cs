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
	/// ҵ���߼���wgi_content ��ժҪ˵����
	/// </summary>
	public class wgi_content
	{
		private readonly Iwgi_content dal=(Iwgi_content)DataAccess.CreateInstance("wgi_content");
		public wgi_content()
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
		public void Add(wgiAdUnionSystem.Model.wgi_content model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_content model)
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
		public wgiAdUnionSystem.Model.wgi_content GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_content GetModelByCache(int id)
		{
			
			string CacheKey = "wgi_contentModel-" + id;
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
			return (wgiAdUnionSystem.Model.wgi_content)objModel;
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
		public List<wgiAdUnionSystem.Model.wgi_content> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_content> DataTableToList(DataTable dt)
		{
			List<wgiAdUnionSystem.Model.wgi_content> modelList = new List<wgiAdUnionSystem.Model.wgi_content>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				wgiAdUnionSystem.Model.wgi_content model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new wgiAdUnionSystem.Model.wgi_content();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.title=dt.Rows[n]["title"].ToString();
					model.content=dt.Rows[n]["content"].ToString();
					model.author=dt.Rows[n]["author"].ToString();
					if(dt.Rows[n]["showindex"].ToString()!="")
					{
						model.showindex=int.Parse(dt.Rows[n]["showindex"].ToString());
					}
					if(dt.Rows[n]["pubtime"].ToString()!="")
					{
						model.pubtime=DateTime.Parse(dt.Rows[n]["pubtime"].ToString());
					}
					if(dt.Rows[n]["isshow"].ToString()!="")
					{
						model.isshow=int.Parse(dt.Rows[n]["isshow"].ToString());
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

