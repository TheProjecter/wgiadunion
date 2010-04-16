/*--------------------------------------------------------------
   // Copyright (C) 2009 www.wingoi.cn ��Ȩ���С� 
   
   // ������Ա��liusylon
   
   // �๦��������
----------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Configuration;

namespace wgiAdUnionSystem.DALFactory
{
   public sealed class DataAccess
    {
       private static readonly string Path = ConfigurationManager.AppSettings["DAL"]; 

        public DataAccess() { }
      
       /// <summary>
       /// �������ݲ�ӿ�
       /// </summary>
       /// <param name="classfile"></param>
       /// <returns></returns>
       public static object CreateInstance(string classfile)
       {
           string CacheKey = Path + "." + classfile;

           object objType = CreateObject(Path, CacheKey);

           return objType;
       }

       #region CreateObject

       //��ʹ�þ���
       private static object CreateObjectNoCache(string path, string CacheKey)
       {
           try
           {
               object objType = Assembly.Load(path).CreateInstance(CacheKey);
               return objType;
           }
           catch//(System.Exception ex)
           {
               //string str=ex.Message;// ��¼������־
               return null;
           }

       }
       //ʹ�þ���
       private static object CreateObject(string path, string CacheKey)
       {
           object objType = DataCache.GetCache(CacheKey);
           if (objType == null)
           {
               try
               {
                   objType = Assembly.Load(path).CreateInstance(CacheKey);
                   DataCache.SetCache(CacheKey, objType);// д�뾏��
               }
               catch//(System.Exception ex)
               {
                   //string str=ex.Message;// ��¼������־
               }
           }
           return objType;
       }
       #endregion
    }
}
