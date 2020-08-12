using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Attributes
{
    /// <summary>
    /// 枚举描述特性
    /// </summary>
    public class EnumRemarkAttribute:Attribute
    {
        public string Remark { get; set; }

        public EnumRemarkAttribute(string remark)
        {
            Remark = remark;
        } 
    }
}
