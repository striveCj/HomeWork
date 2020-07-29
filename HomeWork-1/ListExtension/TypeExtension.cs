using HomeWork_1.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HomeWork_1.ListExtension
{
    public static class TypeExtension
    {
        /// <summary>
        /// 校验字段长度是否超出规定
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool ValidateNameFieldLength<T>(this T t) where T : BaseModel.BaseModel
        {
            Type t1 = t.GetType();
            PropertyInfo[] propertyInfos = t1.GetProperties();

            bool checkResult = true;

            foreach (var property in propertyInfos)
            {

                object[] attrs = property.GetCustomAttributes(true);

                foreach (var attr in attrs)
                {
                    if (attr is StateValidateAttribute)
                    {
                        StateValidateAttribute stateValidate = (StateValidateAttribute)attr;
                        checkResult = stateValidate.Validate(property.GetValue(t).ToString().Length);
                    }
                }

                if (!checkResult)
                {
                    Console.WriteLine($"{property.Name}字段长度校验失败");
                    break;
                }
            }

            return checkResult;
        }
    }
}
