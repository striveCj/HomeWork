using HomeWork_1.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Enum
{
    /// <summary>
    /// 状态枚举
    /// </summary>
    public enum StateEnum
    {
        [EnumRemark("启用")]
        Enable=1,
        [EnumRemark("不启用")]
        UnEnable=0
    }
}
