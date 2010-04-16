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
	/// 数据访问类wgi_content。
	/// </summary>
	public class wgi_content:Iwgi_content
	{
		public wgi_content()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(id)+1 from wgi_content";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from wgi_content where id=@id ");
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
		/// 增加一条数据
		/// </summary>
		public void Add(wgiAdUnionSystem.Model.wgi_content model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_content(");
			strSql.Append("id,title,content,author,showindex,pubtime,isshow)");

			strSql.Append(" values (");
			strSql.Append("@id,@title,@content,@author,@showindex,@pubtime,@isshow)");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32, model.id);
			db.AddInParameter(dbCommand, "title", DbType.String, model.title);
			db.AddInParameter(dbCommand, "content", DbType.String, model.content);
			db.AddInParameter(dbCommand, "author", DbType.String, model.author);
			db.AddInParameter(dbCommand, "showindex", DbType.Int32, model.showindex);
			db.AddInParameter(dbCommand, "pubtime", DbType.DateTime, model.pubtime);
			db.AddInParameter(dbCommand, "isshow", DbType.Int32, model.isshow);
			db.ExecuteNonQuery(dbCommand);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_content model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_content set ");
			strSql.Append("title=@title,");
			strSql.Append("content=@content,");
			strSql.Append("author=@author,");
			strSql.Append("showindex=@showindex,");
			strSql.Append("pubtime=@pubtime,");
			strSql.Append("isshow=@isshow");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32, model.id);
			db.AddInParameter(dbCommand, "title", DbType.String, model.title);
			db.AddInParameter(dbCommand, "content", DbType.String, model.content);
			db.AddInParameter(dbCommand, "author", DbType.String, model.author);
			db.AddInParameter(dbCommand, "showindex", DbType.Int32, model.showindex);
			db.AddInParameter(dbCommand, "pubtime", DbType.DateTime, model.pubtime);
			db.AddInParameter(dbCommand, "isshow", DbType.Int32, model.isshow);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_content ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_content GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,content,author,showindex,pubtime,isshow from wgi_content ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			wgiAdUnionSystem.Model.wgi_content model=null;
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,content,author,showindex,pubtime,isshow ");
			strSql.Append(" FROM wgi_content ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_content");
			db.AddInParameter(dbCommand, "fldName", DbType.String, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.String, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// 获得数据列表（比DataSet效率高，推荐使用）
		/// </summary>
		public List<wgiAdUnionSystem.Model.wgi_content> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,content,author,showindex,pubtime,isshow ");
			strSql.Append(" FROM wgi_content ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_content> list = new List<wgiAdUnionSystem.Model.wgi_content>();
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
		/// 对象实体绑定数据
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_content ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_content model=new wgiAdUnionSystem.Model.wgi_content();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.title=dataReader["title"].ToString();
			model.content=dataReader["content"].ToString();
			model.author=dataReader["author"].ToString();
			ojb = dataReader["showindex"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.showindex=(int)ojb;
			}
			ojb = dataReader["pubtime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.pubtime=(DateTime)ojb;
			}
			ojb = dataReader["isshow"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.isshow=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

