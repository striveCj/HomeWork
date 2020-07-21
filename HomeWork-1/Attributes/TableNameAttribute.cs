using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Attributes
{
    /// <summary>
    /// 数据表名特性
    /// </summary>
    public class TableNameAttribute:Attribute
    {
        public TableNameAttribute(string tableName)
        {
            TableName = tableName;
        }
        public string TableName { get; set; }
    }
}
