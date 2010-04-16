/*--------------------------------------------------------------
   // Copyright (C) 2009 www.wingoi.cn 版权所有。 
   
   // 编码人员：liusylon
   
   // 类功能描述：
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
       /// 创建数据层接口
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

       //不使用緩存
       private static object CreateObjectNoCache(string path, string CacheKey)
       {
           try
           {
               object objType = Assembly.Load(path).CreateInstance(CacheKey);
               return objType;
           }
           catch//(System.Exception ex)
           {
               //string str=ex.Message;// 记录错误日志
               return null;
           }

       }
       //使用緩存
       private static object CreateObject(string path, string CacheKey)
       {
           object objType = DataCache.GetCache(CacheKey);
           if (objType == null)
           {
               try
               {
                   objType = Assembly.Load(path).CreateInstance(CacheKey);
                   DataCache.SetCache(CacheKey, objType);// 写入緩存
               }
               catch//(System.Exception ex)
               {
                   //string str=ex.Message;// 记录错误日志
               }
           }
           return objType;
       }
       #endregion
    }
}
