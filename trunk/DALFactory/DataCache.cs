/*--------------------------------------------------------------
   // Copyright (C) 2009 www.wingoi.cn 版权所有。 
   
   // 编码人员：liusylon
   
   // 类功能描述：
----------------------------------------------------------------*/
using System;
using System.Web;
namespace wgiAdUnionSystem.DALFactory
{
    /// <summary>
    /// 緩存操作类
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// 獲取當前應用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// 設置當前應用程序指定CacheKey的Cache值
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }
    }
}
