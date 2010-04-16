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
    /// 数据访问类wgi_adhost。
    /// </summary>
    public class wgi_adhost : Iwgi_adhost
    {
        public wgi_adhost()
        { }
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string strsql = "select max(id)+1 from wgi_adhost";
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
        public bool Exists(int companyid)
        {
            Database db = DatabaseFactory.CreateDatabase();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from wgi_adhost where companyid=@companyid ");
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, companyid);
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
        public int Add(wgiAdUnionSystem.Model.wgi_adhost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into wgi_adhost(");
            strSql.Append("status,username,password,email,company,contact,tel,qq,mobile,fax,address,zipcode,url,intro,user_type,owner,licence,icp,industryid,sitename,remark,return_day,return_type,valid_day,regdate,regip,lastdate,lastip,balance,ischeck)");

            strSql.Append(" values (");
            strSql.Append("@status,@username,@password,@email,@company,@contact,@tel,@qq,@mobile,@fax,@address,@zipcode,@url,@intro,@user_type,@owner,@licence,@icp,@industryid,@sitename,@remark,@return_day,@return_type,@valid_day,@regdate,@regip,@lastdate,@lastip,@balance,@ischeck)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "status", DbType.Int32, model.status);
            db.AddInParameter(dbCommand, "username", DbType.String, model.username);
            db.AddInParameter(dbCommand, "password", DbType.String, model.password);
            db.AddInParameter(dbCommand, "email", DbType.String, model.email);
            db.AddInParameter(dbCommand, "company", DbType.String, model.company);
            db.AddInParameter(dbCommand, "contact", DbType.String, model.contact);
            db.AddInParameter(dbCommand, "tel", DbType.String, model.tel);
            db.AddInParameter(dbCommand, "qq", DbType.String, model.qq);
            db.AddInParameter(dbCommand, "mobile", DbType.String, model.mobile);
            db.AddInParameter(dbCommand, "fax", DbType.String, model.fax);
            db.AddInParameter(dbCommand, "address", DbType.String, model.address);
            db.AddInParameter(dbCommand, "zipcode", DbType.String, model.zipcode);
            db.AddInParameter(dbCommand, "url", DbType.String, model.url);
            db.AddInParameter(dbCommand, "intro", DbType.String, model.intro);
            db.AddInParameter(dbCommand, "user_type", DbType.Int32, model.user_type);
            db.AddInParameter(dbCommand, "owner", DbType.String, model.owner);
            db.AddInParameter(dbCommand, "licence", DbType.String, model.licence);
            db.AddInParameter(dbCommand, "icp", DbType.String, model.icp);
            db.AddInParameter(dbCommand, "industryid", DbType.Int32, model.industryid);
            db.AddInParameter(dbCommand, "sitename", DbType.String, model.sitename);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.AddInParameter(dbCommand, "return_day", DbType.String, model.return_day);
            db.AddInParameter(dbCommand, "return_type", DbType.String, model.return_type);
            db.AddInParameter(dbCommand, "valid_day", DbType.String, model.valid_day);
            db.AddInParameter(dbCommand, "regdate", DbType.DateTime, model.regdate);
            db.AddInParameter(dbCommand, "regip", DbType.String, model.regip);
            db.AddInParameter(dbCommand, "lastdate", DbType.DateTime, model.lastdate);
            db.AddInParameter(dbCommand, "lastip", DbType.String, model.lastip);
            db.AddInParameter(dbCommand, "balance", DbType.Decimal, model.balance);
            db.AddInParameter(dbCommand, "ischeck", DbType.Int32, model.ischeck);
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
        public void Update(wgiAdUnionSystem.Model.wgi_adhost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update wgi_adhost set ");
            strSql.Append("status=@status,");
            strSql.Append("username=@username,");
            strSql.Append("password=@password,");
            strSql.Append("email=@email,");
            strSql.Append("company=@company,");
            strSql.Append("contact=@contact,");
            strSql.Append("tel=@tel,");
            strSql.Append("qq=@qq,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("fax=@fax,");
            strSql.Append("address=@address,");
            strSql.Append("zipcode=@zipcode,");
            strSql.Append("url=@url,");
            strSql.Append("intro=@intro,");
            strSql.Append("user_type=@user_type,");
            strSql.Append("owner=@owner,");
            strSql.Append("licence=@licence,");
            strSql.Append("icp=@icp,");
            strSql.Append("industryid=@industryid,");
            strSql.Append("sitename=@sitename,");
            strSql.Append("remark=@remark,");
            strSql.Append("return_day=@return_day,");
            strSql.Append("return_type=@return_type,");
            strSql.Append("valid_day=@valid_day,");
            strSql.Append("regdate=@regdate,");
            strSql.Append("regip=@regip,");
            strSql.Append("lastdate=@lastdate,");
            strSql.Append("lastip=@lastip,");
            strSql.Append("balance=@balance,");
            strSql.Append("ischeck=@ischeck");
            strSql.Append(" where companyid=@companyid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, model.companyid);
            db.AddInParameter(dbCommand, "status", DbType.Int32, model.status);
            db.AddInParameter(dbCommand, "username", DbType.String, model.username);
            db.AddInParameter(dbCommand, "password", DbType.String, model.password);
            db.AddInParameter(dbCommand, "email", DbType.String, model.email);
            db.AddInParameter(dbCommand, "company", DbType.String, model.company);
            db.AddInParameter(dbCommand, "contact", DbType.String, model.contact);
            db.AddInParameter(dbCommand, "tel", DbType.String, model.tel);
            db.AddInParameter(dbCommand, "qq", DbType.String, model.qq);
            db.AddInParameter(dbCommand, "mobile", DbType.String, model.mobile);
            db.AddInParameter(dbCommand, "fax", DbType.String, model.fax);
            db.AddInParameter(dbCommand, "address", DbType.String, model.address);
            db.AddInParameter(dbCommand, "zipcode", DbType.String, model.zipcode);
            db.AddInParameter(dbCommand, "url", DbType.String, model.url);
            db.AddInParameter(dbCommand, "intro", DbType.String, model.intro);
            db.AddInParameter(dbCommand, "user_type", DbType.Int32, model.user_type);
            db.AddInParameter(dbCommand, "owner", DbType.String, model.owner);
            db.AddInParameter(dbCommand, "licence", DbType.String, model.licence);
            db.AddInParameter(dbCommand, "icp", DbType.String, model.icp);
            db.AddInParameter(dbCommand, "industryid", DbType.Int32, model.industryid);
            db.AddInParameter(dbCommand, "sitename", DbType.String, model.sitename);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.AddInParameter(dbCommand, "return_day", DbType.String, model.return_day);
            db.AddInParameter(dbCommand, "return_type", DbType.String, model.return_type);
            db.AddInParameter(dbCommand, "valid_day", DbType.String, model.valid_day);
            db.AddInParameter(dbCommand, "regdate", DbType.DateTime, model.regdate);
            db.AddInParameter(dbCommand, "regip", DbType.String, model.regip);
            db.AddInParameter(dbCommand, "lastdate", DbType.DateTime, model.lastdate);
            db.AddInParameter(dbCommand, "lastip", DbType.String, model.lastip);
            db.AddInParameter(dbCommand, "balance", DbType.Decimal, model.balance);
            db.AddInParameter(dbCommand, "ischeck", DbType.Int32, model.ischeck);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int companyid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from wgi_adhost ");
            strSql.Append(" where companyid=@companyid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, companyid);
            db.ExecuteNonQuery(dbCommand);

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public wgiAdUnionSystem.Model.wgi_adhost GetModel(int companyid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select companyid,status,username,password,email,company,contact,tel,qq,mobile,fax,address,zipcode,url,intro,user_type,owner,licence,icp,industryid,sitename,remark,return_day,return_type,valid_day,regdate,regip,lastdate,lastip,balance,ischeck from wgi_adhost ");
            strSql.Append(" where companyid=@companyid ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "companyid", DbType.Int32, companyid);
            wgiAdUnionSystem.Model.wgi_adhost model = null;
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
            strSql.Append("select companyid,status,username,password,email,company,contact,tel,qq,mobile,fax,address,zipcode,url,intro,user_type,owner,licence,icp,industryid,sitename,remark,return_day,return_type,valid_day,regdate,regip,lastdate,lastip,balance,ischeck ");
            strSql.Append(" FROM wgi_adhost ");
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
            db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_adhost");
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
        public List<wgiAdUnionSystem.Model.wgi_adhost> GetListArray(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select companyid,status,username,password,email,company,contact,tel,qq,mobile,fax,address,zipcode,url,intro,user_type,owner,licence,icp,industryid,sitename,remark,return_day,return_type,valid_day,regdate,regip,lastdate,lastip,balance,ischeck ");
            strSql.Append(" FROM wgi_adhost ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            List<wgiAdUnionSystem.Model.wgi_adhost> list = new List<wgiAdUnionSystem.Model.wgi_adhost>();
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
        public wgiAdUnionSystem.Model.wgi_adhost ReaderBind(IDataReader dataReader)
        {
            wgiAdUnionSystem.Model.wgi_adhost model = new wgiAdUnionSystem.Model.wgi_adhost();
            object ojb;
            ojb = dataReader["companyid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.companyid = (int)ojb;
            }
            ojb = dataReader["status"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.status = (int)ojb;
            }
            model.username = dataReader["username"].ToString();
            model.password = dataReader["password"].ToString();
            model.email = dataReader["email"].ToString();
            model.company = dataReader["company"].ToString();
            model.contact = dataReader["contact"].ToString();
            model.tel = dataReader["tel"].ToString();
            model.qq = dataReader["qq"].ToString();
            model.mobile = dataReader["mobile"].ToString();
            model.fax = dataReader["fax"].ToString();
            model.address = dataReader["address"].ToString();
            model.zipcode = dataReader["zipcode"].ToString();
            model.url = dataReader["url"].ToString();
            model.intro = dataReader["intro"].ToString();
            ojb = dataReader["user_type"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.user_type = (int)ojb;
            }
            model.owner = dataReader["owner"].ToString();
            model.licence = dataReader["licence"].ToString();
            model.icp = dataReader["icp"].ToString();
            ojb = dataReader["industryid"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.industryid = (int)ojb;
            }
            model.sitename = dataReader["sitename"].ToString();
            model.remark = dataReader["remark"].ToString();
            model.return_day = dataReader["return_day"].ToString();
            model.return_type = dataReader["return_type"].ToString();
            model.valid_day = dataReader["valid_day"].ToString();
            ojb = dataReader["regdate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.regdate = (DateTime)ojb;
            }
            model.regip = dataReader["regip"].ToString();
            ojb = dataReader["lastdate"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.lastdate = (DateTime)ojb;
            }
            model.lastip = dataReader["lastip"].ToString();
            ojb = dataReader["balance"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.balance = (decimal)ojb;
            }
            ojb = dataReader["ischeck"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ischeck = (int)ojb;
            }
            return model;
        }

        #endregion  成员方法
    }
}

