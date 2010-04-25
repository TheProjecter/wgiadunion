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
        /// �û���¼
        /// </summary>
        /// <param name="username">�û���</param>
        /// <param name="password">����</param>
        /// <param name="msgcode">��¼�������,0Ϊ������¼,1Ϊ�û�������,2Ϊ�������,3Ϊ�û�״̬����</param>
        /// <param name="userid">�û���ʶID</param>
        public bool LoginProcess(string username, string password, out int msgcode, out string userid)
        {
            bool result = false;
            msgcode = 0;//��䛳ɹ�
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
                        msgcode = 2;//�ܴa�e�`
                    }
                    //if (reader["status"].ToString() == "0")
                    //{
                    //    msgcode = 3;//�û�״̬����
                    //    result = false;
                    //}
                }
                else
                {
                    msgcode = 1;//�Ñ��~̖�e�`
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// ��Ա��¼����վ����
        /// </summary>
        /// <param name="username">�û���</param>
        /// <param name="password">����</param>
        /// <param name="msgcode">��¼�������,0Ϊ������¼,1Ϊ�û�������,2Ϊ�������,3Ϊ�û�״̬����</param>
        /// <param name="userid">�û���ʶID</param>
        public bool LoginMember(string username, string password, out int msgcode, out string userid)
        {
            bool result = false;
            msgcode = 0;//��䛳ɹ�
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
                        msgcode = 2;//�ܴa�e�`
                    }
                    if (reader["status"].ToString() == "0")
                    {
                        msgcode = 3;//�û�״̬����
                        result = false;
                    }
                }
                else
                {
                    msgcode = 1;//�Ñ��~̖�e�`
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
