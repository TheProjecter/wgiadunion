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
    /// 数据访问类wgi_noticestat。
    /// </summary>
    public class wgi_noticestat : Iwgi_noticestat
    {
        public wgi_noticestat()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(id)+1 from wgi_noticestat";
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
            strSql.Append("select count(1) from wgi_noticestat where id=@id ");
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
        public void Add(wgiAdUnionSystem.Model.wgi_noticestat model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wgi_noticestat(");
            strSql.Append("noticeid,usertype,userid,unread,deleted)");

            strSql.Append(" values (");
            strSql.Append("@noticeid,@usertype,@userid,@unread,@deleted)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            //db.AddInParameter(dbCommand, "id", DbType.Int32, model.id);
            db.AddInParameter(dbCommand, "noticeid", DbType.Int32, model.noticeid);
            db.AddInParameter(dbCommand, "usertype", DbType.Int32, model.usertype);
            db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
            db.AddInParameter(dbCommand, "unread", DbType.Int32, model.unread);
            db.AddInParameter(dbCommand, "deleted", DbType.Int32, model.deleted);
            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(wgiAdUnionSystem.Model.wgi_noticestat model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wgi_noticestat set ");
            strSql.Append("noticeid=@noticeid,");
            strSql.Append("usertype=@usertype,");
            strSql.Append("userid=@userid,");
            strSql.Append("unread=@unread,");
            strSql.Append("deleted=@deleted");
            strSql.Append(" where id=@id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "id", DbType.Int32, model.id);
            db.AddInParameter(dbCommand, "noticeid", DbType.Int32, model.noticeid);
            db.AddInParameter(dbCommand, "usertype", DbType.Int32, model.usertype);
            db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
            db.AddInParameter(dbCommand, "unread", DbType.Int32, model.unread);
            db.AddInParameter(dbCommand, "deleted", DbType.Int32, model.deleted);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wgi_noticestat ");
            strSql.Append(" where id=@id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "id", DbType.Int32, id);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_noticestat GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,noticeid,usertype,userid,unread,deleted from wgi_noticestat ");
            strSql.Append(" where id=@id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "id", DbType.Int32, id);
            wgiAdUnionSystem.Model.wgi_noticestat model = null;
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
            strSql.Append("select id,noticeid,usertype,userid,unread,deleted ");
            strSql.Append(" FROM wgi_noticestat ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_noticestat");
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
        public List<wgiAdUnionSystem.Model.wgi_noticestat> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,noticeid,usertype,userid,unread,deleted ");
            strSql.Append(" FROM wgi_noticestat ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<wgiAdUnionSystem.Model.wgi_noticestat> list = new List<wgiAdUnionSystem.Model.wgi_noticestat>();
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
        public wgiAdUnionSystem.Model.wgi_noticestat ReaderBind(IDataReader dataReader)
        {
            wgiAdUnionSystem.Model.wgi_noticestat model = new wgiAdUnionSystem.Model.wgi_noticestat();
            object ojb;
            ojb = dataReader["id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            }
            ojb = dataReader["noticeid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.noticeid = (int)ojb;
            }
            ojb = dataReader["usertype"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.usertype = (int)ojb;
            }
            ojb = dataReader["userid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.userid = (int)ojb;
            }
            ojb = dataReader["unread"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.unread = (int)ojb;
            }
            ojb = dataReader["deleted"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.deleted = (int)ojb;
            }
            return model;
        }

        #endregion  成员方法


        public void UpdateDelete(int id, int userid, int usertype)
        {
            string strSql = "update wgi_noticestat set deleted=1 where noticeid =" + id + " and usertype=" + usertype + " and userid=" + userid;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.ExecuteNonQuery(cmd);
        }

        public void UpdateRead(int id, int status, int userid, int usertype)
        {
            string strSql = "update wgi_noticestat set unread=" + status + "where noticeid=" + id + " and usertype=" + usertype;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.ExecuteNonQuery(cmd);
        }
    }
}

