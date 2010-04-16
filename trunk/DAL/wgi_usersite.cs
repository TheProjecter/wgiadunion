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
	/// 数据访问类wgi_usersite。
	/// </summary>
	public class wgi_usersite:Iwgi_usersite
	{
		public wgi_usersite()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(siteid)+1 from wgi_usersite";
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
		public bool Exists(int siteid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from wgi_usersite where siteid=@siteid ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "siteid", DbType.Int32,siteid);
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
		public int Add(wgiAdUnionSystem.Model.wgi_usersite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_usersite(");
			strSql.Append("userid,sitename,url,siteremark,ipno,pvno,sitetype)");

			strSql.Append(" values (");
			strSql.Append("@userid,@sitename,@url,@siteremark,@ipno,@pvno,@sitetype)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "sitename", DbType.String, model.sitename);
			db.AddInParameter(dbCommand, "url", DbType.String, model.url);
			db.AddInParameter(dbCommand, "siteremark", DbType.String, model.siteremark);
			db.AddInParameter(dbCommand, "ipno", DbType.Int32, model.ipno);
			db.AddInParameter(dbCommand, "pvno", DbType.Int32, model.pvno);
			db.AddInParameter(dbCommand, "sitetype", DbType.Int32, model.sitetype);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_usersite model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_usersite set ");
			strSql.Append("userid=@userid,");
			strSql.Append("sitename=@sitename,");
			strSql.Append("url=@url,");
			strSql.Append("siteremark=@siteremark,");
			strSql.Append("ipno=@ipno,");
			strSql.Append("pvno=@pvno,");
			strSql.Append("sitetype=@sitetype");
			strSql.Append(" where siteid=@siteid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "siteid", DbType.Int32, model.siteid);
			db.AddInParameter(dbCommand, "sitename", DbType.String, model.sitename);
			db.AddInParameter(dbCommand, "url", DbType.String, model.url);
			db.AddInParameter(dbCommand, "siteremark", DbType.String, model.siteremark);
			db.AddInParameter(dbCommand, "ipno", DbType.Int32, model.ipno);
			db.AddInParameter(dbCommand, "pvno", DbType.Int32, model.pvno);
			db.AddInParameter(dbCommand, "sitetype", DbType.Int32, model.sitetype);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int siteid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_usersite ");
			strSql.Append(" where siteid=@siteid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "siteid", DbType.Int32,siteid);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_usersite GetModel(int siteid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userid,siteid,sitename,url,siteremark,ipno,pvno,sitetype from wgi_usersite ");
			strSql.Append(" where siteid=@siteid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "siteid", DbType.Int32,siteid);
			wgiAdUnionSystem.Model.wgi_usersite model=null;
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
			strSql.Append("select userid,siteid,sitename,url,siteremark,ipno,pvno,sitetype ");
			strSql.Append(" FROM wgi_usersite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

        public DataSet getListByUserId(int userid)
        {
            string sql = "select userid,siteid,sitename,url,siteremark,ipno,pvno,sitetype from wgi_usersite where userid=@id";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(sql);
            db.AddInParameter(cmd, "id", DbType.Int32, userid);
            return db.ExecuteDataSet(cmd);
            
        }
		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_usersite");
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
		public List<wgiAdUnionSystem.Model.wgi_usersite> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userid,siteid,sitename,url,siteremark,ipno,pvno,sitetype ");
			strSql.Append(" FROM wgi_usersite ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_usersite> list = new List<wgiAdUnionSystem.Model.wgi_usersite>();
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
		public wgiAdUnionSystem.Model.wgi_usersite ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_usersite model=new wgiAdUnionSystem.Model.wgi_usersite();
			object ojb; 
			ojb = dataReader["userid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userid=(int)ojb;
			}
			ojb = dataReader["siteid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.siteid=(int)ojb;
			}
			model.sitename=dataReader["sitename"].ToString();
			model.url=dataReader["url"].ToString();
			model.siteremark=dataReader["siteremark"].ToString();
			ojb = dataReader["ipno"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ipno=(int)ojb;
			}
			ojb = dataReader["pvno"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.pvno=(int)ojb;
			}
			ojb = dataReader["sitetype"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.sitetype=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法

       
	}
}

