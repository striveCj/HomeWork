using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using HomeWork_1.Model;

namespace HomeWork_1.CodeGenerator
{
    public class CodeGenerator
    {
        /// <summary>
        /// 链接字符串，需要转到json配置中去
        /// </summary>
        private string _connString = @"Data Source=WH-PC-CHENJ30\sql2014;Initial Catalog=HomeWork;User ID=sa;Password=95938";

        /// <summary>
        /// 查询数据库数据已DataTable返回
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public DataTable GetTableOrFieldName(GetTableOrFieldNameDto dto)
        {
            using (SqlConnection conn=new SqlConnection(_connString))
            {
                conn.Open();
              
                DataTable dt = new DataTable();
                if (dto.HasParames)
                {
                    SqlCommand comm=new SqlCommand(dto.StrSql, conn);
                    comm.Parameters.AddWithValue($"@{nameof(dto.TableName)}", dto.TableName);
                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = comm;
                        adapter.Fill(dt);
                    }
                }
                else
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(dto.StrSql, _connString))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt;
            }
        }

        /// <summary>
        /// 获取数据库中表名
        /// </summary>
        /// <returns></returns>
        public List<string> GetTableNameList()
        {
            var tableNameList = new List<string>();
       
            string getTableSqlStr = "SELECT Name FROM SysObjects Where XType='U' ORDER BY Name";
            DataTable dt = GetTableOrFieldName(new GetTableOrFieldNameDto{StrSql = getTableSqlStr,HasParames = false});
            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    tableNameList.Add(dr[i].ToString());
                }
            }

            return tableNameList;
        }


        /// <summary>
        /// 代码生成
        /// </summary>
        /// <returns></returns>
        public void CodeRun()
        {
            var tableNameList = GetTableNameList();
            var codeTemp=new CodeTemp();
            foreach (var tableName in tableNameList)
            {
                var fieldList = GetFieldInfo(tableName);
                
                var tempStr= codeTemp.GetTempString(new CodeTempDto(){TableName = tableName,DbFieldResultList = fieldList});

                codeTemp.CodeGenerator(new CodeGeneratorDto(){TableName = tableName,TempStr = tempStr});
            }
        }

        /// <summary>
        /// 获取字段信息
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<DbFieldResultDto> GetFieldInfo(string tableName)
        {
            List<DbFieldResultDto> dbFieldResultList=new List<DbFieldResultDto>();
            var strSql = @"select syscolumns.name,systypes.name as type from syscolumns
                        inner join sysobjects on syscolumns.id=sysobjects.id
                        inner join systypes on syscolumns.xtype=systypes.xtype
                        where(sysobjects.name=@TableName) AND (systypes.name<>'sysname')";
            DataTable dt = GetTableOrFieldName(new GetTableOrFieldNameDto { StrSql = strSql, HasParames = true,TableName = tableName});
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string fieldName = dt.Rows[i]["name"].ToString();
                string typeName = ChangeSqlType(dt.Rows[i]["type"].ToString());
                dbFieldResultList.Add(new DbFieldResultDto() {Name = fieldName, Type = typeName});
;            }

            return dbFieldResultList;
        }

        private string ChangeSqlType(string sqlType)
        {
            switch (sqlType)
            {
                case "int":
                    return "int";
                case "datetime":
                    return "DateTime";
                default:
                    return "string";
            }
        }
    }
}
