/*--------------------------------------------------------------
   // Copyright (C) 2009 www.wingoi.com 版权所有。 
   
   // 编码人员：liusylon
   
   // 类功能描述：
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
        /// 用户登录(管理员)
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="msgcode">登录错误代码,0为正常登录,1为用户名错误,2为密码错误,3为用户状态锁定</param>
        /// <param name="userid">用户标识ID</param>
        public bool ProcessLogin(string username, string password, out int msgcode, out string userid)
        {
            return dal.LoginProcess(username, password, out msgcode, out userid);
        }
        /// <summary>
        /// 会员登录(广告主)
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="msgcode">登录错误代码,0为正常登录,1为用户名错误,2为密码错误,3为用户状态锁定</param>
        /// <param name="userid">用户标识ID</param>
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

                //如果通过验证则获取该用户的Role，这里可以修改为从数据库中

                //读取指定用户的Role并将其添加到Role中，本例中直接为用户添加一个Admin角色

                roleList = new ArrayList();

                roleList.Add("Admin");

            }

        }
        public UserPrincipal(string userID, string password, int membertype)
        {

            identity = new UserIdentity(userID, password, membertype, out checkstatus, out userid);

            if (identity.IsAuthenticated)
            {

                //如果通过验证则获取该用户的Role，这里可以修改为从数据库中

                //读取指定用户的Role并将其添加到Role中，本例中直接为用户添加一个Admin角色

                roleList = new ArrayList();

                roleList.Add("Admin");

            }

        }

        /// <summary>
        /// 已经登录的验证
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
        /// 登录的状态
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
        /// 登录人的标识ID
        /// </summary>
        public string UserID
        {
            get
            {
                return userid;
            }
        }

        #region IPrincipal 成员

        public System.Security.Principal.IIdentity Identity
        {

            get
            {

                // TODO: 添加 MyPrincipal.Identity getter 实现

                return identity;

            }

            set
            {

                identity = value;

            }

        }

        public bool IsInRole(string role)
        {
            // TODO: 添加 MyPrincipal.IsInRole 实现
            return roleList.Contains(role); ;

        }



        #endregion

    }

    public class UserIdentity : System.Security.Principal.IIdentity
    {

        private string userID;

        private string password;

        private bool isAuthenticated;

        private int membertype = 0;//0：系统管理员； 1：广告主； 2：网站主

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

            //这里朋友们可以根据自己的需要改为从数据库中验证用户名和密码，

            //这里为了方便我直接指定的字符串
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

        #region IIdentity 成员


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

                // TODO: 添加 MyIdentity.Name getter 实现

                return userID;

            }

        }



        //这个属性我们可以根据自己的需要来灵活使用,在本例中没有用到它

        public string AuthenticationType
        {

            get
            {

                // TODO: 添加 MyIdentity.AuthenticationType getter 实现

                return null;

            }

        }

        #endregion

    }

    
}
