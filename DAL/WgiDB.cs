using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wgiAdUnionSystem.DAL
{
    public class WgiDB
    {
       /// <summary>
       /// 获得数据库的表名全名称
       /// </summary>
       /// <returns></returns>
       public static string GetFullTableName(string tbname)
       {
           return System.Configuration.ConfigurationManager.AppSettings["TabPrefix"] + tbname;
       }
    }
}
