using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using wgiAdUnionSystem.IDAL;
namespace wgiAdUnionSystem.DAL
{
	/// <summary>
	/// ���ݷ�����wgi_adv_site_host��
	/// </summary>
	public class wgi_adv_site_host:Iwgi_adv_site_host
	{
		public wgi_adv_site_host()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(id)+1 from wgi_adv_site_host";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from wgi_adv_site_host where id=@id ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			int cmdresult;
			object obj = db.ExecuteScalar(dbCommand);
			if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = int.Parse(obj.ToString());
			}
			if (cmdresult == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(wgiAdUnionSystem.Model.wgi_adv_site_host model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_adv_site_host(");
			strSql.Append("companyid,userid)");

			strSql.Append(" values (");
			strSql.Append("@companyid,@userid)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_adv_site_host model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_adv_site_host set ");
			strSql.Append("companyid=@companyid,");
			strSql.Append("userid=@userid");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32, model.id);
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_adv_site_host ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_adv_site_host GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,companyid,userid from wgi_adv_site_host ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			wgiAdUnionSystem.Model.wgi_adv_site_host model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,companyid,userid ");
			strSql.Append(" FROM wgi_adv_site_host ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_adv_site_host");
			db.AddInParameter(dbCommand, "fldName", DbType.String, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.String, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_adv_site_host> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,companyid,userid ");
			strSql.Append(" FROM wgi_adv_site_host ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_adv_site_host> list = new List<wgiAdUnionSystem.Model.wgi_adv_site_host>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}


		/// <summary>
		/// ����ʵ�������
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_adv_site_host ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_adv_site_host model=new wgiAdUnionSystem.Model.wgi_adv_site_host();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			ojb = dataReader["companyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.companyid=(int)ojb;
			}
			ojb = dataReader["userid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userid=(int)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

