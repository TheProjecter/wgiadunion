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
	/// 数据访问类wgi_adhost_usersite。
	/// </summary>
	public class wgi_adhost_usersite:Iwgi_adhost_usersite
	{
		public wgi_adhost_usersite()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(id)+1 from wgi_adhost_usersite";
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
        public bool Exists(int auid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wgi_adhost_usersite where auid=@auid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "auid", DbType.Int32, auid);
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
        public int Add(wgiAdUnionSystem.Model.wgi_adhost_usersite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wgi_adhost_usersite(");
            strSql.Append("companyid,siteid,status,applytime)");

            strSql.Append(" values (");
            strSql.Append("@companyid,@siteid,@status,@applytime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
            db.AddInParameter(dbCommand, "siteid", DbType.Int32, model.siteid);
            db.AddInParameter(dbCommand, "status", DbType.Int32, model.status);
            db.AddInParameter(dbCommand, "applytime", DbType.DateTime, model.applytime);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_adhost_usersite model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wgi_adhost_usersite set ");
            strSql.Append("companyid=@companyid,");
            strSql.Append("siteid=@siteid,");
            strSql.Append("status=@status,");
            strSql.Append("applytime=@applytime");
            strSql.Append(" where auid=@auid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "auid", DbType.Int32, model.auid);
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
            db.AddInParameter(dbCommand, "siteid", DbType.Int32, model.siteid);
            db.AddInParameter(dbCommand, "status", DbType.Int32, model.status);
            db.AddInParameter(dbCommand, "applytime", DbType.DateTime, model.applytime);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int auid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wgi_adhost_usersite ");
            strSql.Append(" where auid=@auid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "auid", DbType.Int32, auid);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_adhost_usersite GetModel(int auid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select auid,companyid,siteid,status,applytime from wgi_adhost_usersite ");
            strSql.Append(" where auid=@auid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "auid", DbType.Int32, auid);
            wgiAdUnionSystem.Model.wgi_adhost_usersite model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select auid,companyid,siteid,status,applytime ");
            strSql.Append(" FROM wgi_adhost_usersite ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_adhost_usersite");
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
        public List<wgiAdUnionSystem.Model.wgi_adhost_usersite> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select auid,companyid,siteid,status,applytime ");
            strSql.Append(" FROM wgi_adhost_usersite ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<wgiAdUnionSystem.Model.wgi_adhost_usersite> list = new List<wgiAdUnionSystem.Model.wgi_adhost_usersite>();
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
        public wgiAdUnionSystem.Model.wgi_adhost_usersite ReaderBind(IDataReader dataReader)
        {
            wgiAdUnionSystem.Model.wgi_adhost_usersite model = new wgiAdUnionSystem.Model.wgi_adhost_usersite();
            object ojb;
            ojb = dataReader["auid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.auid = (int)ojb;
            }
            ojb = dataReader["companyid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.companyid = (int)ojb;
            }
            ojb = dataReader["siteid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.siteid = (int)ojb;
            }
            ojb = dataReader["status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.status = (int)ojb;
            }
            ojb = dataReader["applytime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.applytime = (DateTime)ojb;
            }
            return model;
        }

		#endregion  成员方法

        /// <summary>
        /// 根据广告主ID与审核状态,网站标题查询的申请网站列表
        /// </summary>
        /// <param name="compid">广告主ID</param>
        /// <param name="status">审核状态</param>
        /// <returns></returns>
        public DataTable GetWebSiteWithAdvList(int compid, int status,string sitename)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select us.*,au.*,sc.catename from wgi_usersite us left join wgi_adhost_usersite au on au.siteid=us.siteid");
            sb.AppendLine(" left join wgi_sitecate sc on sc.cateid=us.sitetype");
            sb.AppendLine(" where au.companyid=" + compid + " and au.status=" + status);
            if (!string.IsNullOrEmpty(sitename))
            {
                sb.AppendLine(" and us.sitename like '%"+sitename+"%'");
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, sb.ToString()).Tables[0];
        }

        /// <summary>
        /// 批量修改申请加入推广的网站状态，用于审核，拒绝等操作
        /// </summary>
        /// <param name="ids">选择的网站主</param>
        /// <param name="status"></param>
        public int ChangeApplySiteStatus(List<string> ids, int status)
        {
            StringBuilder sb = new StringBuilder();
            foreach(string id in ids)
            {
                sb.AppendLine("update wgi_adhost_usersite set status=" + status + " where auid=" + id);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteNonQuery(CommandType.Text, sb.ToString());
        }
	}
}

