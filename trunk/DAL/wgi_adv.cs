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
	/// 数据访问类wgi_adv。
	/// </summary>
	public class wgi_adv:Iwgi_adv
	{
		public wgi_adv()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(advid)+1 from wgi_adv";
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
		public bool Exists(int advid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from wgi_adv where advid=@advid ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "advid", DbType.Int32,advid);
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
		public int Add(wgiAdUnionSystem.Model.wgi_adv model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_adv(");
			strSql.Append("companyid,advname,advtype,advcont,advlink,advwidth,advheight,advuptime,advstatus,advstart,advend,advinvalid,advpaytype)");

			strSql.Append(" values (");
			strSql.Append("@companyid,@advname,@advtype,@advcont,@advlink,@advwidth,@advheight,@advuptime,@advstatus,@advstart,@advend,@advinvalid,@advpaytype)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "advname", DbType.String, model.advname);
			db.AddInParameter(dbCommand, "advtype", DbType.Int32, model.advtype);
			db.AddInParameter(dbCommand, "advcont", DbType.String, model.advcont);
			db.AddInParameter(dbCommand, "advlink", DbType.String, model.advlink);
			db.AddInParameter(dbCommand, "advwidth", DbType.Int32, model.advwidth);
			db.AddInParameter(dbCommand, "advheight", DbType.Int32, model.advheight);
			db.AddInParameter(dbCommand, "advuptime", DbType.DateTime, model.advuptime);
			db.AddInParameter(dbCommand, "advstatus", DbType.Int32, model.advstatus);
			db.AddInParameter(dbCommand, "advstart", DbType.DateTime, model.advstart);
			db.AddInParameter(dbCommand, "advend", DbType.DateTime, model.advend);
			db.AddInParameter(dbCommand, "advinvalid", DbType.Int32, model.advinvalid);
			db.AddInParameter(dbCommand, "advpaytype", DbType.Int32, model.advpaytype);
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
		public void Update(wgiAdUnionSystem.Model.wgi_adv model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_adv set ");
			strSql.Append("companyid=@companyid,");
			strSql.Append("advname=@advname,");
			strSql.Append("advtype=@advtype,");
			strSql.Append("advcont=@advcont,");
			strSql.Append("advlink=@advlink,");
			strSql.Append("advwidth=@advwidth,");
			strSql.Append("advheight=@advheight,");
			strSql.Append("advuptime=@advuptime,");
			strSql.Append("advstatus=@advstatus,");
			strSql.Append("advstart=@advstart,");
			strSql.Append("advend=@advend,");
			strSql.Append("advinvalid=@advinvalid,");
			strSql.Append("advpaytype=@advpaytype");
			strSql.Append(" where advid=@advid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "advid", DbType.Int32, model.advid);
			db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
			db.AddInParameter(dbCommand, "advname", DbType.String, model.advname);
			db.AddInParameter(dbCommand, "advtype", DbType.Int32, model.advtype);
			db.AddInParameter(dbCommand, "advcont", DbType.String, model.advcont);
			db.AddInParameter(dbCommand, "advlink", DbType.String, model.advlink);
			db.AddInParameter(dbCommand, "advwidth", DbType.Int32, model.advwidth);
			db.AddInParameter(dbCommand, "advheight", DbType.Int32, model.advheight);
			db.AddInParameter(dbCommand, "advuptime", DbType.DateTime, model.advuptime);
			db.AddInParameter(dbCommand, "advstatus", DbType.Int32, model.advstatus);
			db.AddInParameter(dbCommand, "advstart", DbType.DateTime, model.advstart);
			db.AddInParameter(dbCommand, "advend", DbType.DateTime, model.advend);
			db.AddInParameter(dbCommand, "advinvalid", DbType.Int32, model.advinvalid);
			db.AddInParameter(dbCommand, "advpaytype", DbType.Int32, model.advpaytype);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int advid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_adv ");
			strSql.Append(" where advid=@advid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "advid", DbType.Int32,advid);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_adv GetModel(int advid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select advid,companyid,advname,advtype,advcont,advlink,advwidth,advheight,advuptime,advstatus,advstart,advend,advinvalid,advpaytype from wgi_adv ");
			strSql.Append(" where advid=@advid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "advid", DbType.Int32,advid);
			wgiAdUnionSystem.Model.wgi_adv model=null;
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
			strSql.Append("select advid,companyid,advname,advtype,advcont,advlink,advwidth,advheight,advuptime,advstatus,advstart,advend,advinvalid,advpaytype ");
			strSql.Append(" FROM wgi_adv ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_adv");
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
		public List<wgiAdUnionSystem.Model.wgi_adv> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select advid,companyid,advname,advtype,advcont,advlink,advwidth,advheight,advuptime,advstatus,advstart,advend,advinvalid,advpaytype ");
			strSql.Append(" FROM wgi_adv ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_adv> list = new List<wgiAdUnionSystem.Model.wgi_adv>();
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
		public wgiAdUnionSystem.Model.wgi_adv ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_adv model=new wgiAdUnionSystem.Model.wgi_adv();
			object ojb; 
			ojb = dataReader["advid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advid=(int)ojb;
			}
			ojb = dataReader["companyid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.companyid=(int)ojb;
			}
			model.advname=dataReader["advname"].ToString();
			ojb = dataReader["advtype"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advtype=(int)ojb;
			}
			model.advcont=dataReader["advcont"].ToString();
			model.advlink=dataReader["advlink"].ToString();
			ojb = dataReader["advwidth"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advwidth=(int)ojb;
			}
			ojb = dataReader["advheight"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advheight=(int)ojb;
			}
			ojb = dataReader["advuptime"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advuptime=(DateTime)ojb;
			}
			ojb = dataReader["advstatus"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advstatus=(int)ojb;
			}
			ojb = dataReader["advstart"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advstart=(DateTime)ojb;
			}
			ojb = dataReader["advend"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advend=(DateTime)ojb;
			}
			ojb = dataReader["advinvalid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advinvalid=(int)ojb;
			}
			ojb = dataReader["advpaytype"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.advpaytype=(int)ojb;
			}
			return model;
		}

		#endregion  成员方法

          /// <summary>
        /// 根据广告主ID获得广告列表
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="paytype">广告付费类型</param>
        /// <param name="display">广告显示类型</param>
        /// <returns></returns>
        public DataTable GetAdvListByCompID(int compid, int? paytype, int? display)
        {
            string sqlstr = "companyid=" + compid;
            if (paytype.HasValue)
            {
                sqlstr += " and advpaytype=" + paytype.Value;
            }
            if (display.HasValue)
            {
                sqlstr += " and advtype=" + display.Value;
            }

            return this.GetList(sqlstr + " order by advuptime desc").Tables[0];
        }
        /// <summary>
        /// 根据广告主ID获得广告列表
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="paytype">广告付费类型</param>
        /// <param name="display">广告显示类型</param>
        ///<param name="display">广告显示开始时间</param>
        /// <param name="display">广告截止时间</param>
        /// <param name="display">广告关键描述</param>
        /// <param name="isaudit">是否只显示通过审核的</param>
        /// <param name="ispublished">是否只显示投放中的</param>
        /// <returns></returns>
        public DataTable GetAdvListByCompID(int compid, int paytype, int display, string beg, string end, string title, int? isaudit, int? ispublished)
        {
            string sqlstr = "companyid=" + compid;

            sqlstr += " and advpaytype=" + paytype;

            sqlstr += " and advtype=" + display;

            if (!string.IsNullOrEmpty(beg))
            {
                sqlstr += " and advend >='" + beg + "'";
            }
            if (!string.IsNullOrEmpty(end))
            {
                sqlstr += " and advend <='" + end + "'";
            }
            if (!string.IsNullOrEmpty(title))
            {
                sqlstr += " and advname  like '%" + title + "%'";
            }
            if (isaudit.HasValue) 
            {
                sqlstr += " and advstatus=" + isaudit;
            }
            if (ispublished.HasValue)
            {
                sqlstr += " and advinvalid=" + ispublished;
            }
            return this.GetList(sqlstr + " order by advuptime desc").Tables[0];
        }
	}
}

