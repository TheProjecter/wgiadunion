/*--------------------------------------------------------------
   // Copyright (C) 2009 www.wingoi.com  版权所有。 
   
   // 编码人员：liusylon
   
   // 类功能描述：列表页面的接口
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace wgiAdUnionSystem.IDAL
{
    public interface IUser
    {
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="msgcode">登录错误代码,0为正常登录,1为用户名错误,2为密码错误</param>
        /// <param name="userid">用户标识ID</param>
        bool LoginProcess(string username, string password, out int msgcode, out string userid);
        bool LoginMember(string username, string password, out int msgcode, out string userid);
    }
}
