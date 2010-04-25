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
	/// ҵ���߼���wgi_sitehost ��ժҪ˵����
	/// </summary>
	public class wgi_sitehost
	{
		private readonly Iwgi_sitehost dal=(Iwgi_sitehost)DataAccess.CreateInstance("wgi_sitehost");
		public wgi_sitehost()
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
		public bool Exists(int userid)
		{
			return dal.Exists(userid);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(wgiAdUnionSystem.Model.wgi_sitehost model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_sitehost model)
		{
			dal.Update(model);
		}
        
        /// <summary>
        /// �����ϴε�¼ʱ��
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="time"></param>
        public void updateLoginTime(int userid, string time)
        {
            dal.updateLoginTime(userid, time);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newpwd"></param>
        public void updatePwd(int userid, string newpwd)
        {
            dal.updatePwd(userid, newpwd);
        }

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int userid)
		{
			
			dal.Delete(userid);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_sitehost GetModel(int userid)
		{
			
			return dal.GetModel(userid);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
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
		/// ���ǰ��������
		/// </summary>
		// public DataSet GetList(int Top,string strWhere,string filedOrder)
		// {
			// return dal.GetList(Top,strWhere,filedOrder);
		// }
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_sitehost> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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

