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
	/// 数据访问类wgi_adv_statis。
	/// </summary>
	public class wgi_adv_statis:Iwgi_adv_statis
	{
		public wgi_adv_statis()
		{}
		#region  成员方法



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(wgiAdUnionSystem.Model.wgi_adv_statis model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_adv_statis(");
			strSql.Append("companyid,userid,siteid,advid,advtype,statistype,recordtime,ip)");

			strSql.Append(" values (");
			strSql.Append("@companyid,@userid,@siteid,@advid,@advtype,@statistype,@recordtime,@ip)");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "siteid", DbType.Int32, model.siteid);
			db.AddInParameter(dbCommand, "advid", DbType.Int32, model.advid);
			db.AddInParameter(dbCommand, "advtype", DbType.Int32, model.advtype);
			db.AddInParameter(dbCommand, "statistype", DbType.Int32, model.statistype);
			db.AddInParameter(dbCommand, "recordtime", DbType.DateTime, model.recordtime);
			db.AddInParameter(dbCommand, "ip", DbType.String, model.ip);
			db.ExecuteNonQuery(dbCommand);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(wgiAdUnionSystem.Model.wgi_adv_statis model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_adv_statis set ");
			strSql.Append("companyid=@companyid,");
			strSql.Append("userid=@userid,");
			strSql.Append("siteid=@siteid,");
			strSql.Append("advid=@advid,");
			strSql.Append("advtype=@advtype,");
			strSql.Append("statistype=@statistype,");
			strSql.Append("recordtime=@recordtime,");
			strSql.Append("ip=@ip");
			strSql.Append(" where ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "siteid", DbType.Int32, model.siteid);
			db.AddInParameter(dbCommand, "advid", DbType.Int32, model.advid);
			db.AddInParameter(dbCommand, "advtype", DbType.Int32, model.advtype);
			db.AddInParameter(dbCommand, "statistype", DbType.Int32, model.statistype);
			db.AddInParameter(dbCommand, "recordtime", DbType.DateTime, model.recordtime);
			db.AddInParameter(dbCommand, "ip", DbType.String, model.ip);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_adv_statis ");
			strSql.Append(" where ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_adv_statis GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select companyid,userid,siteid,advid,advtype,statistype,recordtime,ip from wgi_adv_statis ");
			strSql.Append(" where ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			wgiAdUnionSystem.Model.wgi_adv_statis model=null;
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
			strSql.Append("select companyid,userid,siteid,advid,advtype,statistype,recordtime,ip ");
			strSql.Append(" FROM wgi_adv_statis ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_adv_statis");
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
		public List<wgiAdUnionSystem.Model.wgi_adv_statis> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select companyid,userid,siteid,advid,advtype,statistype,recordtime,ip ");
			strSql.Append(" FROM wgi_adv_statis ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_adv_statis> list = new List<wgiAdUnionSystem.Model.wgi_adv_statis>();
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
		public wgiAdUnionSystem.Model.wgi_adv_statis ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_adv_statis model=new wgiAdUnionSystem.Model.wgi_adv_statis();
			object ojb; 
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
			ojb = dataReader["siteid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.siteid=(int)ojb;
			}
			ojb = dataReader["advid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advid=(int)ojb;
			}
			ojb = dataReader["advtype"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advtype=(int)ojb;
			}
			ojb = dataReader["statistype"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.statistype=(int)ojb;
			}
			ojb = dataReader["recordtime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.recordtime=(DateTime)ojb;
			}
			model.ip=dataReader["ip"].ToString();
			return model;
		}

		#endregion  成员方法
	}
}

