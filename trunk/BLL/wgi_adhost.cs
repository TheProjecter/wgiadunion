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
	/// ҵ���߼���wgi_adhost ��ժҪ˵����
	/// </summary>
	public class wgi_adhost
	{
		private readonly Iwgi_adhost dal=(Iwgi_adhost)DataAccess.CreateInstance("wgi_adhost");
		public wgi_adhost()
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
		public bool Exists(int companyid)
		{
			return dal.Exists(companyid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(wgiAdUnionSystem.Model.wgi_adhost model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_adhost model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int companyid)
		{
			
			dal.Delete(companyid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_adhost GetModel(int companyid)
		{
			
			return dal.GetModel(companyid);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_adhost GetModelByCache(int companyid)
		{
			
			string CacheKey = "wgi_adhostModel-" + companyid;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(companyid);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (wgiAdUnionSystem.Model.wgi_adhost)objModel;
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
		public List<wgiAdUnionSystem.Model.wgi_adhost> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_adhost> DataTableToList(DataTable dt)
		{
			List<wgiAdUnionSystem.Model.wgi_adhost> modelList = new List<wgiAdUnionSystem.Model.wgi_adhost>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				wgiAdUnionSystem.Model.wgi_adhost model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new wgiAdUnionSystem.Model.wgi_adhost();
					if(dt.Rows[n]["companyid"].ToString()!="")
					{
						model.companyid=int.Parse(dt.Rows[n]["companyid"].ToString());
					}
                    if (dt.Rows[n]["industryid"].ToString() != "")
					{
                        model.industryid = int.Parse(dt.Rows[n]["industryid"].ToString());
					}
					if(dt.Rows[n]["status"].ToString()!="")
					{
						model.status=int.Parse(dt.Rows[n]["status"].ToString());
					}
					model.username=dt.Rows[n]["username"].ToString();
					model.password=dt.Rows[n]["password"].ToString();
					model.email=dt.Rows[n]["email"].ToString();
					model.company=dt.Rows[n]["company"].ToString();
					model.contact=dt.Rows[n]["contact"].ToString();
					model.tel=dt.Rows[n]["tel"].ToString();
					model.qq=dt.Rows[n]["qq"].ToString();
					model.mobile=dt.Rows[n]["mobile"].ToString();
					model.fax=dt.Rows[n]["fax"].ToString();
					model.address=dt.Rows[n]["address"].ToString();
					model.zipcode=dt.Rows[n]["zipcode"].ToString();
					model.url=dt.Rows[n]["url"].ToString();
					model.intro=dt.Rows[n]["intro"].ToString();
					if(dt.Rows[n]["user_type"].ToString()!="")
					{
						model.user_type=int.Parse(dt.Rows[n]["user_type"].ToString());
					}
					model.owner=dt.Rows[n]["owner"].ToString();
					model.licence=dt.Rows[n]["licence"].ToString();
					model.icp=dt.Rows[n]["icp"].ToString();
					model.sitename=dt.Rows[n]["sitename"].ToString();
					model.remark=dt.Rows[n]["remark"].ToString();
					model.return_day=dt.Rows[n]["return_day"].ToString();
					model.return_type=dt.Rows[n]["return_type"].ToString();
					model.valid_day=dt.Rows[n]["valid_day"].ToString();
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
					if(dt.Rows[n]["balance"].ToString()!="")
					{
						model.balance=decimal.Parse(dt.Rows[n]["balance"].ToString());
					}
					if(dt.Rows[n]["ischeck"].ToString()!="")
					{
						model.ischeck=int.Parse(dt.Rows[n]["ischeck"].ToString());
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

