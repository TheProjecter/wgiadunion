/*--------------------------------------------------------------
   // Copyright (C) 2009 www.wingoi.com  ��Ȩ���С� 
   
   // ������Ա��liusylon
   
   // �๦���������б�ҳ��Ľӿ�
----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;

namespace wgiAdUnionSystem.IDAL
{
    public interface IUser
    {
        /// <summary>
        /// �û���¼
        /// </summary>
        /// <param name="username">�û���</param>
        /// <param name="password">����</param>
        /// <param name="msgcode">��¼�������,0Ϊ������¼,1Ϊ�û�������,2Ϊ�������</param>
        /// <param name="userid">�û���ʶID</param>
        bool LoginProcess(string username, string password, out int msgcode, out string userid);
        bool LoginMember(string username, string password, out int msgcode, out string userid);
    }
}
