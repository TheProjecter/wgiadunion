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
	/// 数据访问类wgi_orders。
	/// </summary>
	public class wgi_orders:Iwgi_orders
	{
		public wgi_orders()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(orderid)+1 from wgi_orders";
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
		public bool Exists(int orderid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from wgi_orders where orderid=@orderid ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "orderid", DbType.Int32,orderid);
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
		public int Add(wgiAdUnionSystem.Model.wgi_orders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_orders(");
			strSql.Append("companyid,siteid,orderno,cash,time,consumer,itemno,itemprice,itemamount,pay,ischeck,reason,checktime)");

			strSql.Append(" values (");
			strSql.Append("@companyid,@siteid,@orderno,@cash,@time,@consumer,@itemno,@itemprice,@itemamount,@pay,@ischeck,@reason,@checktime)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "siteid", DbType.Int32, model.siteid);
			db.AddInParameter(dbCommand, "orderno", DbType.String, model.orderno);
			db.AddInParameter(dbCommand, "cash", DbType.Decimal, model.cash);
			db.AddInParameter(dbCommand, "time", DbType.DateTime, model.time);
			db.AddInParameter(dbCommand, "consumer", DbType.String, model.consumer);
			db.AddInParameter(dbCommand, "itemno", DbType.String, model.itemno);
			db.AddInParameter(dbCommand, "itemprice", DbType.Decimal, model.itemprice);
			db.AddInParameter(dbCommand, "itemamount", DbType.Decimal, model.itemamount);
			db.AddInParameter(dbCommand, "pay", DbType.Decimal, model.pay);
			db.AddInParameter(dbCommand, "ischeck", DbType.Int32, model.ischeck);
			db.AddInParameter(dbCommand, "reason", DbType.String, model.reason);
			db.AddInParameter(dbCommand, "checktime", DbType.DateTime, model.checktime);
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
		public void Update(wgiAdUnionSystem.Model.wgi_orders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_orders set ");
			strSql.Append("companyid=@companyid,");
			strSql.Append("siteid=@siteid,");
			strSql.Append("orderno=@orderno,");
			strSql.Append("cash=@cash,");
			strSql.Append("time=@time,");
			strSql.Append("consumer=@consumer,");
			strSql.Append("itemno=@itemno,");
			strSql.Append("itemprice=@itemprice,");
			strSql.Append("itemamount=@itemamount,");
			strSql.Append("pay=@pay,");
			strSql.Append("ischeck=@ischeck,");
			strSql.Append("reason=@reason,");
			strSql.Append("checktime=@checktime");
			strSql.Append(" where orderid=@orderid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "orderid", DbType.Int32, model.orderid);
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "siteid", DbType.Int32, model.siteid);
			db.AddInParameter(dbCommand, "orderno", DbType.String, model.orderno);
			db.AddInParameter(dbCommand, "cash", DbType.Decimal, model.cash);
			db.AddInParameter(dbCommand, "time", DbType.DateTime, model.time);
			db.AddInParameter(dbCommand, "consumer", DbType.String, model.consumer);
			db.AddInParameter(dbCommand, "itemno", DbType.String, model.itemno);
			db.AddInParameter(dbCommand, "itemprice", DbType.Decimal, model.itemprice);
			db.AddInParameter(dbCommand, "itemamount", DbType.Decimal, model.itemamount);
			db.AddInParameter(dbCommand, "pay", DbType.Decimal, model.pay);
			db.AddInParameter(dbCommand, "ischeck", DbType.Int32, model.ischeck);
			db.AddInParameter(dbCommand, "reason", DbType.String, model.reason);
			db.AddInParameter(dbCommand, "checktime", DbType.DateTime, model.checktime);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int orderid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_orders ");
			strSql.Append(" where orderid=@orderid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "orderid", DbType.Int32,orderid);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_orders GetModel(int orderid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select orderid,companyid,siteid,orderno,cash,time,consumer,itemno,itemprice,itemamount,pay,ischeck,reason,checktime from wgi_orders ");
			strSql.Append(" where orderid=@orderid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "orderid", DbType.Int32,orderid);
			wgiAdUnionSystem.Model.wgi_orders model=null;
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
			strSql.Append("select orderid,companyid,siteid,orderno,cash,time,consumer,itemno,itemprice,itemamount,pay,ischeck,reason,checktime ");
			strSql.Append(" FROM wgi_orders ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_orders");
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
		public List<wgiAdUnionSystem.Model.wgi_orders> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select orderid,companyid,siteid,orderno,cash,time,consumer,itemno,itemprice,itemamount,pay,ischeck,reason,checktime ");
			strSql.Append(" FROM wgi_orders ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_orders> list = new List<wgiAdUnionSystem.Model.wgi_orders>();
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
		public wgiAdUnionSystem.Model.wgi_orders ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_orders model=new wgiAdUnionSystem.Model.wgi_orders();
			object ojb; 
			ojb = dataReader["orderid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.orderid=(int)ojb;
			}
			ojb = dataReader["companyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.companyid=(int)ojb;
			}
			ojb = dataReader["siteid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.siteid=(int)ojb;
			}
			model.orderno=dataReader["orderno"].ToString();
			ojb = dataReader["cash"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.cash=(decimal)ojb;
			}
			ojb = dataReader["time"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.time=(DateTime)ojb;
			}
			model.consumer=dataReader["consumer"].ToString();
			model.itemno=dataReader["itemno"].ToString();
			ojb = dataReader["itemprice"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.itemprice=(decimal)ojb;
			}
			ojb = dataReader["itemamount"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.itemamount=(decimal)ojb;
			}
			ojb = dataReader["pay"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.pay=(decimal)ojb;
			}
			ojb = dataReader["ischeck"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.ischeck=(int)ojb;
			}
			model.reason=dataReader["reason"].ToString();
			ojb = dataReader["checktime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.checktime=(DateTime)ojb;
			}
			return model;
		}

		#endregion  成员方法
	}
}

