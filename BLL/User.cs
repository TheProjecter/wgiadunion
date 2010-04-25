/*--------------------------------------------------------------
   // Copyright (C) 2009 www.wingoi.com ��Ȩ���С� 
   
   // ������Ա��liusylon
   
   // �๦��������
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using wgiAdUnionSystem.Model;
using wgiAdUnionSystem.IDAL;

namespace wgiAdUnionSystem.BLL
{
    public class BUser
    {
        private static readonly IUser dal = (wgiAdUnionSystem.IDAL.IUser)wgiAdUnionSystem.DALFactory.DataAccess.CreateInstance("UserManage");

        /// <summary>
        /// �û���¼(����Ա)
        /// </summary>
        /// <param name="username">�û���</param>
        /// <param name="password">����</param>
        /// <param name="msgcode">��¼�������,0Ϊ������¼,1Ϊ�û�������,2Ϊ�������,3Ϊ�û�״̬����</param>
        /// <param name="userid">�û���ʶID</param>
        public bool ProcessLogin(string username, string password, out int msgcode, out string userid)
        {
            return dal.LoginProcess(username, password, out msgcode, out userid);
        }
        /// <summary>
        /// ��Ա��¼(�����)
        /// </summary>
        /// <param name="username">�û���</param>
        /// <param name="password">����</param>
        /// <param name="msgcode">��¼�������,0Ϊ������¼,1Ϊ�û�������,2Ϊ�������,3Ϊ�û�״̬����</param>
        /// <param name="userid">�û���ʶID</param>
        public bool MemberLogin(string username, string password, out int msgcode, out string userid)
        {
            return dal.LoginMember(username, password, out msgcode, out userid);
        }

    }



    public class UserPrincipal : System.Security.Principal.IPrincipal
    {
        private System.Security.Principal.IIdentity identity;

        private ArrayList roleList;

        public UserPrincipal(string userID, string password)
        {

            identity = new UserIdentity(userID, password, out checkstatus, out userid);

            if (identity.IsAuthenticated)
            {

                //���ͨ����֤���ȡ���û���Role����������޸�Ϊ�����ݿ���

                //��ȡָ���û���Role��������ӵ�Role�У�������ֱ��Ϊ�û����һ��Admin��ɫ

                roleList = new ArrayList();

                roleList.Add("Admin");

            }

        }
        public UserPrincipal(string userID, string password, int membertype)
        {

            identity = new UserIdentity(userID, password, membertype, out checkstatus, out userid);

            if (identity.IsAuthenticated)
            {

                //���ͨ����֤���ȡ���û���Role����������޸�Ϊ�����ݿ���

                //��ȡָ���û���Role��������ӵ�Role�У�������ֱ��Ϊ�û����һ��Admin��ɫ

                roleList = new ArrayList();

                roleList.Add("Admin");

            }

        }

        /// <summary>
        /// �Ѿ���¼����֤
        /// </summary>
        /// <param name="userid"></param>
        public UserPrincipal(string userid)
        {
            identity = new UserIdentity(userid);
        }

        public ArrayList RoleList
        {

            get { return roleList; }
            set { roleList = value; }
        }

        private int checkstatus;

        /// <summary>
        /// ��¼��״̬
        /// </summary>
        public int CheckStatus
        {
            get
            {
                return checkstatus;
            }
        }

        private string userid;

        /// <summary>
        /// ��¼�˵ı�ʶID
        /// </summary>
        public string UserID
        {
            get
            {
                return userid;
            }
        }

        #region IPrincipal ��Ա

        public System.Security.Principal.IIdentity Identity
        {

            get
            {

                // TODO: ��� MyPrincipal.Identity getter ʵ��

                return identity;

            }

            set
            {

                identity = value;

            }

        }

        public bool IsInRole(string role)
        {
            // TODO: ��� MyPrincipal.IsInRole ʵ��
            return roleList.Contains(role); ;

        }



        #endregion

    }

    public class UserIdentity : System.Security.Principal.IIdentity
    {

        private string userID;

        private string password;

        private bool isAuthenticated;

        private int membertype = 0;//0��ϵͳ����Ա�� 1��������� 2����վ��

        public UserIdentity(string currentUserID, string currentPassword, out int msgcode, out string userid)
        {

            userID = currentUserID;

            password = currentPassword;

            isAuthenticated = CanPass(out msgcode, out userid);

        }
        public UserIdentity(string currentUserID, string currentPassword,int mtype, out int msgcode, out string userid)
        {

            userID = currentUserID;

            password = currentPassword;

            membertype = mtype;

            isAuthenticated = CanPass(out msgcode, out userid);

        }
        public UserIdentity(string currentUserID)
        {
            userID = currentUserID;
            isAuthenticated = true;
        }
        private bool CanPass(out int msgcode, out string userid)
        {

            //���������ǿ��Ը����Լ�����Ҫ��Ϊ�����ݿ�����֤�û��������룬

            //����Ϊ�˷�����ֱ��ָ�����ַ���
            BUser user = new BUser();
            if (membertype == 0) return user.ProcessLogin(this.userID, password, out msgcode, out userid);
            //else if (membertype == 2) return user.MemberLogin(this.userID, password, out msgcode, out userid);
            else return user.MemberLogin(this.userID, password, out msgcode, out userid);
        }

        public string Password
        {

            get
            {

                return password;

            }

            set
            {

                password = value;

            }

        }

        #region IIdentity ��Ա


        public bool IsAuthenticated
        {
            get
            {
                return isAuthenticated;

            }
            set {
                isAuthenticated = value;
            }
        }


        public string Name
        {

            get
            {

                // TODO: ��� MyIdentity.Name getter ʵ��

                return userID;

            }

        }



        //����������ǿ��Ը����Լ�����Ҫ�����ʹ��,�ڱ�����û���õ���

        public string AuthenticationType
        {

            get
            {

                // TODO: ��� MyIdentity.AuthenticationType getter ʵ��

                return null;

            }

        }

        #endregion

    }

    
}
