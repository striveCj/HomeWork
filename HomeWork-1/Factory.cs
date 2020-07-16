using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace HomeWork_1
{
    public static class Factory
    {
        public static DbHelper GetDbHelper(string sql)
        {
            if (sql.Equals("sql"))
            {
                return new DbHelper();
            }
            else
            {
                throw  new ArgumentException("暂时不支持");
            }
        }

        public static string GetConfigInfo()
        {
            var build = new ConfigurationBuilder();
                       build.SetBasePath(Directory.GetCurrentDirectory());
               build.AddJsonFile("Setting.json", true, true);
              var dbConfig = build.Build(); 
              string dbConn = dbConfig.GetSection("ConnectionStrings").GetSection("HomeWork").Value;
              return dbConn;
        }
    }
}
