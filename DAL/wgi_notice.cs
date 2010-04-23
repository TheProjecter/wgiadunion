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
	/// ���ݷ�����wgi_notice��
	/// </summary>
	public class wgi_notice:Iwgi_notice
	{
		public wgi_notice()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(id)+1 from wgi_notice";
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
			strSql.Append("select count(1) from wgi_notice where id=@id ");
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
		public int Add(wgiAdUnionSystem.Model.wgi_notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_notice(");
			strSql.Append("title,notice,pubdate,unread,publisher)");

			strSql.Append(" values (");
			strSql.Append("@title,@notice,@pubdate,@unread,@publisher)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "title", DbType.String, model.title);
			db.AddInParameter(dbCommand, "notice", DbType.String, model.notice);
			db.AddInParameter(dbCommand, "pubdate", DbType.DateTime, model.pubdate);
			db.AddInParameter(dbCommand, "unread", DbType.Int32, model.unread);
			db.AddInParameter(dbCommand, "publisher", DbType.Int32, model.publisher);
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
		public void Update(wgiAdUnionSystem.Model.wgi_notice model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_notice set ");
			strSql.Append("title=@title,");
			strSql.Append("notice=@notice,");
			strSql.Append("pubdate=@pubdate,");
			strSql.Append("unread=@unread,");
			strSql.Append("publisher=@publisher");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32, model.id);
			db.AddInParameter(dbCommand, "title", DbType.String, model.title);
			db.AddInParameter(dbCommand, "notice", DbType.String, model.notice);
			db.AddInParameter(dbCommand, "pubdate", DbType.DateTime, model.pubdate);
			db.AddInParameter(dbCommand, "unread", DbType.Int32, model.unread);
			db.AddInParameter(dbCommand, "publisher", DbType.Int32, model.publisher);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_notice ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_notice GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,notice,pubdate,unread,publisher from wgi_notice ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			wgiAdUnionSystem.Model.wgi_notice model=null;
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
			strSql.Append("select id,title,notice,pubdate,unread,publisher ");
			strSql.Append(" FROM wgi_notice ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_notice");
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
		public List<wgiAdUnionSystem.Model.wgi_notice> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,notice,pubdate,unread,publisher ");
			strSql.Append(" FROM wgi_notice ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_notice> list = new List<wgiAdUnionSystem.Model.wgi_notice>();
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
		public wgiAdUnionSystem.Model.wgi_notice ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_notice model=new wgiAdUnionSystem.Model.wgi_notice();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.title=dataReader["title"].ToString();
			model.notice=dataReader["notice"].ToString();
			ojb = dataReader["pubdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.pubdate=(DateTime)ojb;
			}
			ojb = dataReader["unread"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.unread=(int)ojb;
			}
			ojb = dataReader["publisher"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.publisher=(int)ojb;
			}
			return model;
		}




        /// <summary>
        /// �����Ķ�״̬
        /// </summary>
        /// <param name="id"></param>
        public void UpdateReadStatus(string ids, int status)
        {
            string strSql = "update wgi_notice set unread=@status where id in ( " + ids + " )";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "status", DbType.Int32, status);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void DeleteByIds(string ids)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wgi_notice ");
            strSql.Append(" where id in( " + ids + " ) ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.ExecuteNonQuery(dbCommand);

        }


		#endregion  ��Ա����
	}
}

