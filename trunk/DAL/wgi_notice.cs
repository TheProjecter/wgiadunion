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
	/// 数据访问类wgi_notice。
	/// </summary>
	public class wgi_notice:Iwgi_notice
	{
		public wgi_notice()
		{}
		#region  成员方法

        ///// <summary>
        ///// 得到最大ID
        ///// </summary>
        //public int GetMaxId()
        //{
        //return DbHelperSQL.GetMaxID("id", "wgi_notice"); 
        //}

        ///// <summary>
        ///// 是否存在该记录
        ///// </summary>
        //public bool Exists(int id)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from wgi_notice");
        //    strSql.Append(" where id=@id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4)};
        //    parameters[0].Value = id;

        //    return DbHelperSQL.Exists(strSql.ToString(),parameters);
        //}


        ///// <summary>
        ///// 增加一条数据
        ///// </summary>
        //public int Add(wgiAdUnionSystem.Model.wgi_notice model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("insert into wgi_notice(");
        //    strSql.Append("title,notice,pubdate,unread,publisher)");
        //    strSql.Append(" values (");
        //    strSql.Append("@title,@notice,@pubdate,@unread,@publisher)");
        //    strSql.Append(";select @@IDENTITY");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@title", SqlDbType.NVarChar,100),
        //            new SqlParameter("@notice", SqlDbType.NText),
        //            new SqlParameter("@pubdate", SqlDbType.DateTime),
        //            new SqlParameter("@unread", SqlDbType.Int,4),
        //            new SqlParameter("@publisher", SqlDbType.Int,4)};
        //    parameters[0].Value = model.title;
        //    parameters[1].Value = model.notice;
        //    parameters[2].Value = model.pubdate;
        //    parameters[3].Value = model.unread;
        //    parameters[4].Value = model.publisher;

        //    object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
        //    if (obj == null)
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        return Convert.ToInt32(obj);
        //    }
        //}
        ///// <summary>
        ///// 更新一条数据
        ///// </summary>
        //public void Update(wgiAdUnionSystem.Model.wgi_notice model)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("update wgi_notice set ");
        //    strSql.Append("title=@title,");
        //    strSql.Append("notice=@notice,");
        //    strSql.Append("pubdate=@pubdate,");
        //    strSql.Append("unread=@unread,");
        //    strSql.Append("publisher=@publisher");
        //    strSql.Append(" where id=@id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4),
        //            new SqlParameter("@title", SqlDbType.NVarChar,100),
        //            new SqlParameter("@notice", SqlDbType.NText),
        //            new SqlParameter("@pubdate", SqlDbType.DateTime),
        //            new SqlParameter("@unread", SqlDbType.Int,4),
        //            new SqlParameter("@publisher", SqlDbType.Int,4)};
        //    parameters[0].Value = model.id;
        //    parameters[1].Value = model.title;
        //    parameters[2].Value = model.notice;
        //    parameters[3].Value = model.pubdate;
        //    parameters[4].Value = model.unread;
        //    parameters[5].Value = model.publisher;

        //    DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //}

        ///// <summary>
        ///// 删除一条数据
        ///// </summary>
        //public void Delete(int id)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("delete from wgi_notice ");
        //    strSql.Append(" where id=@id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4)};
        //    parameters[0].Value = id;

        //    DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
        //}


        ///// <summary>
        ///// 得到一个对象实体
        ///// </summary>
        //public wgiAdUnionSystem.Model.wgi_notice GetModel(int id)
        //{
			
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select  top 1 id,title,notice,pubdate,unread,publisher from wgi_notice ");
        //    strSql.Append(" where id=@id ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@id", SqlDbType.Int,4)};
        //    parameters[0].Value = id;

        //    wgiAdUnionSystem.Model.wgi_notice model=new wgiAdUnionSystem.Model.wgi_notice();
        //    DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
        //    if(ds.Tables[0].Rows.Count>0)
        //    {
        //        if(ds.Tables[0].Rows[0]["id"].ToString()!="")
        //        {
        //            model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
        //        }
        //        model.title=ds.Tables[0].Rows[0]["title"].ToString();
        //        model.notice=ds.Tables[0].Rows[0]["notice"].ToString();
        //        if(ds.Tables[0].Rows[0]["pubdate"].ToString()!="")
        //        {
        //            model.pubdate=DateTime.Parse(ds.Tables[0].Rows[0]["pubdate"].ToString());
        //        }
        //        if(ds.Tables[0].Rows[0]["unread"].ToString()!="")
        //        {
        //            model.unread=int.Parse(ds.Tables[0].Rows[0]["unread"].ToString());
        //        }
        //        if(ds.Tables[0].Rows[0]["publisher"].ToString()!="")
        //        {
        //            model.publisher=int.Parse(ds.Tables[0].Rows[0]["publisher"].ToString());
        //        }
        //        return model;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        ///// <summary>
        ///// 获得数据列表
        ///// </summary>
        //public DataSet GetList(string strWhere)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select id,title,notice,pubdate,unread,publisher ");
        //    strSql.Append(" FROM wgi_notice ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///// <summary>
        ///// 获得前几行数据
        ///// </summary>
        //public DataSet GetList(int Top,string strWhere,string filedOrder)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select ");
        //    if(Top>0)
        //    {
        //        strSql.Append(" top "+Top.ToString());
        //    }
        //    strSql.Append(" id,title,notice,pubdate,unread,publisher ");
        //    strSql.Append(" FROM wgi_notice ");
        //    if(strWhere.Trim()!="")
        //    {
        //        strSql.Append(" where "+strWhere);
        //    }
        //    strSql.Append(" order by " + filedOrder);
        //    return DbHelperSQL.Query(strSql.ToString());
        //}

        ///*
        ///// <summary>
        ///// 分页获取数据列表
        ///// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@tblName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@fldName", SqlDbType.VarChar, 255),
        //            new SqlParameter("@PageSize", SqlDbType.Int),
        //            new SqlParameter("@PageIndex", SqlDbType.Int),
        //            new SqlParameter("@IsReCount", SqlDbType.Bit),
        //            new SqlParameter("@OrderType", SqlDbType.Bit),
        //            new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
        //            };
        //    parameters[0].Value = "wgi_notice";
        //    parameters[1].Value = "ID";
        //    parameters[2].Value = PageSize;
        //    parameters[3].Value = PageIndex;
        //    parameters[4].Value = 0;
        //    parameters[5].Value = 0;
        //    parameters[6].Value = strWhere;	
        //    return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        //}*/


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,notice,pubdate,unread,publisher ");
            strSql.Append(" FROM wgi_notice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 更新阅读状态
        /// </summary>
        /// <param name="id"></param>
        public void UpdateReadStatus(int id, int status)
        {
            string strSql = "update wgi_notice set unread=@status where id=@id";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand cmd = db.GetSqlStringCommand(strSql);
            db.AddInParameter(cmd, "status", DbType.Int32, status);
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
        }

		#endregion  成员方法
	}
}

