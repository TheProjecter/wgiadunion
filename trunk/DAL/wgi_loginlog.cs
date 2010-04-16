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
	/// 数据访问类wgi_loginlog。
	/// </summary>
	public class wgi_loginlog:Iwgi_loginlog
	{
		public wgi_loginlog()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(logid)+1 from wgi_loginlog";
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
		public bool Exists(int logid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from wgi_loginlog where logid=@logid ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "logid", DbType.Int32,logid);
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
		public void Add(wgiAdUnionSystem.Model.wgi_loginlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_loginlog(");
			strSql.Append("logid,usertype,logtime,logip,logname)");

			strSql.Append(" values (");
			strSql.Append("@logid,@usertype,@logtime,@logip,@logname)");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "logid", DbType.Int32, model.logid);
			db.AddInParameter(dbCommand, "usertype", DbType.Int32, model.usertype);
			db.AddInParameter(dbCommand, "logtime", DbType.DateTime, model.logtime);
			db.AddInParameter(dbCommand, "logip", DbType.String, model.logip);
			db.AddInParameter(dbCommand, "logname", DbType.String, model.logname);
			db.ExecuteNonQuery(dbCommand);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_loginlog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_loginlog set ");
			strSql.Append("usertype=@usertype,");
			strSql.Append("logtime=@logtime,");
			strSql.Append("logip=@logip,");
			strSql.Append("logname=@logname");
			strSql.Append(" where logid=@logid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "logid", DbType.Int32, model.logid);
			db.AddInParameter(dbCommand, "usertype", DbType.Int32, model.usertype);
			db.AddInParameter(dbCommand, "logtime", DbType.DateTime, model.logtime);
			db.AddInParameter(dbCommand, "logip", DbType.String, model.logip);
			db.AddInParameter(dbCommand, "logname", DbType.String, model.logname);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int logid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_loginlog ");
			strSql.Append(" where logid=@logid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "logid", DbType.Int32,logid);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_loginlog GetModel(int logid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select logid,usertype,logtime,logip,logname from wgi_loginlog ");
			strSql.Append(" where logid=@logid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "logid", DbType.Int32,logid);
			wgiAdUnionSystem.Model.wgi_loginlog model=null;
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
			strSql.Append("select logid,usertype,logtime,logip,logname ");
			strSql.Append(" FROM wgi_loginlog ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_loginlog");
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
		public List<wgiAdUnionSystem.Model.wgi_loginlog> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select logid,usertype,logtime,logip,logname ");
			strSql.Append(" FROM wgi_loginlog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_loginlog> list = new List<wgiAdUnionSystem.Model.wgi_loginlog>();
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
		public wgiAdUnionSystem.Model.wgi_loginlog ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_loginlog model=new wgiAdUnionSystem.Model.wgi_loginlog();
			object ojb; 
			ojb = dataReader["logid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.logid=(int)ojb;
			}
			ojb = dataReader["usertype"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.usertype=(int)ojb;
			}
			ojb = dataReader["logtime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.logtime=(DateTime)ojb;
			}
			model.logip=dataReader["logip"].ToString();
			model.logname=dataReader["logname"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

