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
	/// 数据访问类wgi_sitehost。
	/// </summary>
	public class wgi_sitehost:Iwgi_sitehost
	{
		public wgi_sitehost()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(userid)+1 from wgi_sitehost";
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
		public bool Exists(int userid)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from wgi_sitehost where userid=@userid ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);
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
		public int Add(wgiAdUnionSystem.Model.wgi_sitehost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into wgi_sitehost(");
			strSql.Append("username,password,email,mobile,accountname,accountno,bank,branch,usertype,contact,qq,idcard,address,zipcode,tel,balance,regdate,regip,lastdate,lastip,status)");

			strSql.Append(" values (");
			strSql.Append("@username,@password,@email,@mobile,@accountname,@accountno,@bank,@branch,@usertype,@contact,@qq,@idcard,@address,@zipcode,@tel,@balance,@regdate,@regip,@lastdate,@lastip,@status)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "username", DbType.String, model.username);
			db.AddInParameter(dbCommand, "password", DbType.String, model.password);
			db.AddInParameter(dbCommand, "email", DbType.String, model.email);
			db.AddInParameter(dbCommand, "mobile", DbType.String, model.mobile);
			db.AddInParameter(dbCommand, "accountname", DbType.String, model.accountname);
			db.AddInParameter(dbCommand, "accountno", DbType.String, model.accountno);
			db.AddInParameter(dbCommand, "bank", DbType.String, model.bank);
			db.AddInParameter(dbCommand, "branch", DbType.String, model.branch);
			db.AddInParameter(dbCommand, "usertype", DbType.Int32, model.usertype);
			db.AddInParameter(dbCommand, "contact", DbType.String, model.contact);
			db.AddInParameter(dbCommand, "qq", DbType.String, model.qq);
			db.AddInParameter(dbCommand, "idcard", DbType.String, model.idcard);
			db.AddInParameter(dbCommand, "address", DbType.String, model.address);
			db.AddInParameter(dbCommand, "zipcode", DbType.String, model.zipcode);
			db.AddInParameter(dbCommand, "tel", DbType.String, model.tel);
			db.AddInParameter(dbCommand, "balance", DbType.Decimal, model.balance);
			db.AddInParameter(dbCommand, "regdate", DbType.DateTime, model.regdate);
			db.AddInParameter(dbCommand, "regip", DbType.String, model.regip);
			db.AddInParameter(dbCommand, "lastdate", DbType.DateTime, model.lastdate);
			db.AddInParameter(dbCommand, "lastip", DbType.String, model.lastip);
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
		public void Update(wgiAdUnionSystem.Model.wgi_sitehost model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update wgi_sitehost set ");
			strSql.Append("username=@username,");
			strSql.Append("password=@password,");
			strSql.Append("email=@email,");
			strSql.Append("mobile=@mobile,");
			strSql.Append("accountname=@accountname,");
			strSql.Append("accountno=@accountno,");
			strSql.Append("bank=@bank,");
			strSql.Append("branch=@branch,");
			strSql.Append("usertype=@usertype,");
			strSql.Append("contact=@contact,");
			strSql.Append("qq=@qq,");
			strSql.Append("idcard=@idcard,");
			strSql.Append("address=@address,");
			strSql.Append("zipcode=@zipcode,");
			strSql.Append("tel=@tel,");
			strSql.Append("balance=@balance,");
			strSql.Append("regdate=@regdate,");
			strSql.Append("regip=@regip,");
			strSql.Append("lastdate=@lastdate,");
			strSql.Append("lastip=@lastip,");
			strSql.Append("status=@status");
			strSql.Append(" where userid=@userid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "userid", DbType.Int32, model.userid);
			db.AddInParameter(dbCommand, "username", DbType.String, model.username);
			db.AddInParameter(dbCommand, "password", DbType.String, model.password);
			db.AddInParameter(dbCommand, "email", DbType.String, model.email);
			db.AddInParameter(dbCommand, "mobile", DbType.String, model.mobile);
			db.AddInParameter(dbCommand, "accountname", DbType.String, model.accountname);
			db.AddInParameter(dbCommand, "accountno", DbType.String, model.accountno);
			db.AddInParameter(dbCommand, "bank", DbType.String, model.bank);
			db.AddInParameter(dbCommand, "branch", DbType.String, model.branch);
			db.AddInParameter(dbCommand, "usertype", DbType.Int32, model.usertype);
			db.AddInParameter(dbCommand, "contact", DbType.String, model.contact);
			db.AddInParameter(dbCommand, "qq", DbType.String, model.qq);
			db.AddInParameter(dbCommand, "idcard", DbType.String, model.idcard);
			db.AddInParameter(dbCommand, "address", DbType.String, model.address);
			db.AddInParameter(dbCommand, "zipcode", DbType.String, model.zipcode);
			db.AddInParameter(dbCommand, "tel", DbType.String, model.tel);
			db.AddInParameter(dbCommand, "balance", DbType.Decimal, model.balance);
			db.AddInParameter(dbCommand, "regdate", DbType.DateTime, model.regdate);
			db.AddInParameter(dbCommand, "regip", DbType.String, model.regip);
			db.AddInParameter(dbCommand, "lastdate", DbType.DateTime, model.lastdate);
			db.AddInParameter(dbCommand, "lastip", DbType.String, model.lastip);
			db.AddInParameter(dbCommand, "status", DbType.Int32, model.status);
			db.ExecuteNonQuery(dbCommand);

		}


        /// <summary>
        /// 重设密码
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="newpwd"></param>
        public void updatePwd(int userid, string newpwd)
        {
            string strSql = "update wgi_sitehost set password=@password where userid=@userid";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            db.AddInParameter(dbCommand, "userid", DbType.Int32, userid);
            db.AddInParameter(dbCommand, "password", DbType.String, newpwd);
            db.ExecuteNonQuery(dbCommand);
        }

        
        /// <summary>
        /// 更新上次登录时间
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="time"></param>
        public void updateLoginTime(int userid, string time)
        {
            string strSql = "update wgi_sitehost set lastdate=@last where userid=@userid";
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql);
            db.AddInParameter(dbCommand, "userid", DbType.Int32, userid);
            db.AddInParameter(dbCommand, "last", DbType.String, time);
            db.ExecuteNonQuery(dbCommand);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int userid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from wgi_sitehost ");
			strSql.Append(" where userid=@userid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public wgiAdUnionSystem.Model.wgi_sitehost GetModel(int userid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userid,username,password,email,mobile,accountname,accountno,bank,branch,usertype,contact,qq,idcard,address,zipcode,tel,balance,regdate,regip,lastdate,lastip,status from wgi_sitehost ");
			strSql.Append(" where userid=@userid ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "userid", DbType.Int32,userid);
			wgiAdUnionSystem.Model.wgi_sitehost model=null;
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
			strSql.Append("select userid,username,password,email,mobile,accountname,accountno,bank,branch,usertype,contact,qq,idcard,address,zipcode,tel,balance,regdate,regip,lastdate,lastip,status ");
			strSql.Append(" FROM wgi_sitehost ");
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
			db.AddInParameter(dbCommand, "tblName", DbType.String, "wgi_sitehost");
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
		public List<wgiAdUnionSystem.Model.wgi_sitehost> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userid,username,password,email,mobile,accountname,accountno,bank,branch,usertype,contact,qq,idcard,address,zipcode,tel,balance,regdate,regip,lastdate,lastip,status ");
			strSql.Append(" FROM wgi_sitehost ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<wgiAdUnionSystem.Model.wgi_sitehost> list = new List<wgiAdUnionSystem.Model.wgi_sitehost>();
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
		public wgiAdUnionSystem.Model.wgi_sitehost ReaderBind(IDataReader dataReader)
		{
			wgiAdUnionSystem.Model.wgi_sitehost model=new wgiAdUnionSystem.Model.wgi_sitehost();
			object ojb; 
			ojb = dataReader["userid"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.userid=(int)ojb;
			}
			model.username=dataReader["username"].ToString();
			model.password=dataReader["password"].ToString();
			model.email=dataReader["email"].ToString();
			model.mobile=dataReader["mobile"].ToString();
			model.accountname=dataReader["accountname"].ToString();
			model.accountno=dataReader["accountno"].ToString();
			model.bank=dataReader["bank"].ToString();
			model.branch=dataReader["branch"].ToString();
			ojb = dataReader["usertype"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.usertype=(int)ojb;
			}
			model.contact=dataReader["contact"].ToString();
			model.qq=dataReader["qq"].ToString();
			model.idcard=dataReader["idcard"].ToString();
			model.address=dataReader["address"].ToString();
			model.zipcode=dataReader["zipcode"].ToString();
			model.tel=dataReader["tel"].ToString();
			ojb = dataReader["balance"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.balance=(decimal)ojb;
			}
			ojb = dataReader["regdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.regdate=(DateTime)ojb;
			}
			model.regip=dataReader["regip"].ToString();
			ojb = dataReader["lastdate"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.lastdate=(DateTime)ojb;
			}
			model.lastip=dataReader["lastip"].ToString();
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

