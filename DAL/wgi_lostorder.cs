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
	/// 数据访问类wgi_lostorder。
	/// </summary>
	public class wgi_lostorder:Iwgi_lostorder
	{
		public wgi_lostorder()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(id)+1 from wgi_lostorder";
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
			strSql.Append("select count(1) from wgi_lostorder where id=@id ");
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
		public int Add(wgiAdUnionSystem.Model.wgi_lostorder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_lostorder(");
			strSql.Append("companyid,userid,orderno,adhostname,buytime,itemno,consumer,applyreason,applytime,lostreason,result,status)");

			strSql.Append(" values (");
			strSql.Append("@companyid,@userid,@orderno,@adhostname,@buytime,@itemno,@consumer,@applyreason,@applytime,@lostreason,@result,@status)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "orderno", DbType.String, model.orderno);
			db.AddInParameter(dbCommand, "adhostname", DbType.String, model.adhostname);
			db.AddInParameter(dbCommand, "buytime", DbType.DateTime, model.buytime);
			db.AddInParameter(dbCommand, "itemno", DbType.String, model.itemno);
			db.AddInParameter(dbCommand, "consumer", DbType.String, model.consumer);
			db.AddInParameter(dbCommand, "applyreason", DbType.String, model.applyreason);
			db.AddInParameter(dbCommand, "applytime", DbType.DateTime, model.applytime);
			db.AddInParameter(dbCommand, "lostreason", DbType.String, model.lostreason);
			db.AddInParameter(dbCommand, "result", DbType.String, model.result);
			db.AddInParameter(dbCommand, "status", DbType.Int32, model.status);
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
		public void Update(wgiAdUnionSystem.Model.wgi_lostorder model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_lostorder set ");
			strSql.Append("companyid=@companyid,");
			strSql.Append("userid=@userid,");
			strSql.Append("orderno=@orderno,");
			strSql.Append("adhostname=@adhostname,");
			strSql.Append("buytime=@buytime,");
			strSql.Append("itemno=@itemno,");
			strSql.Append("consumer=@consumer,");
			strSql.Append("applyreason=@applyreason,");
			strSql.Append("applytime=@applytime,");
			strSql.Append("lostreason=@lostreason,");
			strSql.Append("result=@result,");
			strSql.Append("status=@status");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32, model.id);
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "orderno", DbType.String, model.orderno);
			db.AddInParameter(dbCommand, "adhostname", DbType.String, model.adhostname);
			db.AddInParameter(dbCommand, "buytime", DbType.DateTime, model.buytime);
			db.AddInParameter(dbCommand, "itemno", DbType.String, model.itemno);
			db.AddInParameter(dbCommand, "consumer", DbType.String, model.consumer);
			db.AddInParameter(dbCommand, "applyreason", DbType.String, model.applyreason);
			db.AddInParameter(dbCommand, "applytime", DbType.DateTime, model.applytime);
			db.AddInParameter(dbCommand, "lostreason", DbType.String, model.lostreason);
			db.AddInParameter(dbCommand, "result", DbType.String, model.result);
			db.AddInParameter(dbCommand, "status", DbType.Int32, model.status);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_lostorder ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_lostorder GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,companyid,userid,orderno,adhostname,buytime,itemno,consumer,applyreason,applytime,lostreason,result,status from wgi_lostorder ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			wgiAdUnionSystem.Model.wgi_lostorder model=null;
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
			strSql.Append("select id,companyid,userid,orderno,adhostname,buytime,itemno,consumer,applyreason,applytime,lostreason,result,status ");
			strSql.Append(" FROM wgi_lostorder ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_lostorder");
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
		public List<wgiAdUnionSystem.Model.wgi_lostorder> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,companyid,userid,orderno,adhostname,buytime,itemno,consumer,applyreason,applytime,lostreason,result,status ");
			strSql.Append(" FROM wgi_lostorder ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_lostorder> list = new List<wgiAdUnionSystem.Model.wgi_lostorder>();
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
		public wgiAdUnionSystem.Model.wgi_lostorder ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_lostorder model=new wgiAdUnionSystem.Model.wgi_lostorder();
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
			model.orderno=dataReader["orderno"].ToString();
			model.adhostname=dataReader["adhostname"].ToString();
			ojb = dataReader["buytime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.buytime=(DateTime)ojb;
			}
			model.itemno=dataReader["itemno"].ToString();
			model.consumer=dataReader["consumer"].ToString();
			model.applyreason=dataReader["applyreason"].ToString();
			ojb = dataReader["applytime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.applytime=(DateTime)ojb;
			}
			model.lostreason=dataReader["lostreason"].ToString();
			model.result=dataReader["result"].ToString();
			ojb = dataReader["status"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.status=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

