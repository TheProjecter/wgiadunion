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
	/// 数据访问类wgi_discount。
	/// </summary>
	public class wgi_discount:Iwgi_discount
	{
		public wgi_discount()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(id)+1 from wgi_discount";
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
            strSql.Append("select count(1) from wgi_discount where id=@id ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "id", DbType.Int32, id);
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
        public int Add(wgiAdUnionSystem.Model.wgi_discount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wgi_discount(");
            strSql.Append("companyid,payamt,payintro,endtime,addtime)");

            strSql.Append(" values (");
            strSql.Append("@companyid,@payamt,@payintro,@endtime,@addtime)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
            db.AddInParameter(dbCommand, "payamt", DbType.String, model.payamt);
            db.AddInParameter(dbCommand, "payintro", DbType.String, model.payintro);
            db.AddInParameter(dbCommand, "endtime", DbType.DateTime, model.endtime);
            db.AddInParameter(dbCommand, "addtime", DbType.DateTime, model.addtime);
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
        public void Update(wgiAdUnionSystem.Model.wgi_discount model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wgi_discount set ");
            strSql.Append("companyid=@companyid,");
            strSql.Append("payamt=@payamt,");
            strSql.Append("payintro=@payintro,");
            strSql.Append("endtime=@endtime,");
            strSql.Append("addtime=@addtime");
            strSql.Append(" where id=@id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "id", DbType.Int32, model.id);
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
            db.AddInParameter(dbCommand, "payamt", DbType.String, model.payamt);
            db.AddInParameter(dbCommand, "payintro", DbType.String, model.payintro);
            db.AddInParameter(dbCommand, "endtime", DbType.DateTime, model.endtime);
            db.AddInParameter(dbCommand, "addtime", DbType.DateTime, model.addtime);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wgi_discount ");
            strSql.Append(" where id=@id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "id", DbType.Int32, id);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_discount GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,companyid,payamt,payintro,endtime,addtime from wgi_discount ");
            strSql.Append(" where id=@id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "id", DbType.Int32, id);
            wgiAdUnionSystem.Model.wgi_discount model = null;
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
            strSql.Append("select id,companyid,payamt,payintro,endtime,addtime ");
            strSql.Append(" FROM wgi_discount ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_discount");
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
        public List<wgiAdUnionSystem.Model.wgi_discount> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,companyid,payamt,payintro,endtime,addtime ");
            strSql.Append(" FROM wgi_discount ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<wgiAdUnionSystem.Model.wgi_discount> list = new List<wgiAdUnionSystem.Model.wgi_discount>();
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
        public wgiAdUnionSystem.Model.wgi_discount ReaderBind(IDataReader dataReader)
        {
            wgiAdUnionSystem.Model.wgi_discount model = new wgiAdUnionSystem.Model.wgi_discount();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["companyid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.companyid = (int)ojb;
            }
            model.payamt = dataReader["payamt"].ToString();
            model.payintro = dataReader["payintro"].ToString();
            ojb = dataReader["endtime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.endtime = (DateTime)ojb;
            }
            ojb = dataReader["addtime"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.addtime = (DateTime)ojb;
            }
            return model;
        }


		#endregion  成员方法

        /// <summary>
        /// 根据广告主ID和截止日期获取所有佣金标准说明
        /// </summary>
        /// <param name="compid"></param>
        /// <param name="compid"></param>
        /// <param name="compid"></param>
        /// <returns></returns>
        public DataTable GetPaymentListByCompanyID(int compid, string beg_date, string end_date)
        {
            string strsql = "companyid="+compid;
            if (!string.IsNullOrEmpty(beg_date))
            {
                strsql += " and endtime>='"+beg_date+"'";
            }
            if (!string.IsNullOrEmpty(end_date))
            {
                strsql += " and endtime<='" + end_date + "'";
            }

            strsql += " order by endtime asc";
            return this.GetList(strsql).Tables[0];
        }
	}
}

