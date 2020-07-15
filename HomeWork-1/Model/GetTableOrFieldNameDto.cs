using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Model
{
    /// <summary>
    /// sql查询条件
    /// </summary>
   public class GetTableOrFieldNameDto
    {
        /// <summary>
        /// 查询字符串
        /// </summary>
        public string StrSql { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 是否拥有参数
        /// </summary>
        public bool HasParames { get; set; }
    }
}
