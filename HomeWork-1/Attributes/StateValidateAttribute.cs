using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Attributes
{
    /// <summary>
    /// 状态范围验证枚举
    /// </summary>
    public class StateValidateAttribute:Attribute
    {
        /// <summary>
        /// 最小值
        /// </summary>
        private int MinValue { get; set; }
        /// <summary>
        /// 最大值
        /// </summary>
        private int MaxValue { get; set; }

        public StateValidateAttribute(int minValue,int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        /// <summary>
        /// 检验值是否合法
        /// </summary>
        /// <param name="checkValue"></param>
        /// <returns></returns>
        public bool Validate(int checkValue)
        {
            return checkValue >= MinValue && checkValue <= MaxValue;
        }

    }
}
