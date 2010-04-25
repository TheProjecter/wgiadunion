using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

using wgiAdUnionSystem.Model;
using wgiAdUnionSystem.IDAL;

namespace wgiAdUnionSystem.DAL
{
    public class UserManage:IUser
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="msgcode">登录错误代码,0为正常登录,1为用户名错误,2为密码错误,3为用户状态锁定</param>
        /// <param name="userid">用户标识ID</param>
        public bool LoginProcess(string username, string password, out int msgcode, out string userid)
        {
            bool result = false;
            msgcode = 0;//登錄成功
            userid = string.Empty;

            Database db = DatabaseFactory.CreateDatabase();

            try
            {
                string sqlstr = "select * from " + WgiDB.GetFullTableName("sysuser") + " where username='" + username + "'";

                IDataReader reader = db.ExecuteReader(CommandType.Text, sqlstr);

                if (reader.Read())
                {
                    if (reader["password"].ToString() == password)
                    {
                        userid = reader["id"].ToString();

                        result = true;
                    }
                    else
                    {
                        msgcode = 2;//密碼錯誤
                    }
                    //if (reader["status"].ToString() == "0")
                    //{
                    //    msgcode = 3;//用户状态锁定
                    //    result = false;
                    //}
                }
                else
                {
                    msgcode = 1;//用戶賬號錯誤
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 会员登录（网站主）
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="msgcode">登录错误代码,0为正常登录,1为用户名错误,2为密码错误,3为用户状态锁定</param>
        /// <param name="userid">用户标识ID</param>
        public bool LoginMember(string username, string password, out int msgcode, out string userid)
        {
            bool result = false;
            msgcode = 0;//登錄成功
            userid = string.Empty;

            Database db = DatabaseFactory.CreateDatabase();

            try
            {
                string sqlstr = "select * from " + WgiDB.GetFullTableName("sitehost") + " where username='" + username + "'";

                IDataReader reader = db.ExecuteReader(CommandType.Text, sqlstr);

                if (reader.Read())
                {
                    if (reader["password"].ToString() == password)
                    {
                        userid = reader["userid"].ToString();

                        result = true;
                    }
                    else
                    {
                        msgcode = 2;//密碼錯誤
                    }
                    if (reader["status"].ToString() == "0")
                    {
                        msgcode = 3;//用户状态锁定
                        result = false;
                    }
                }
                else
                {
                    msgcode = 1;//用戶賬號錯誤
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
    }
}
