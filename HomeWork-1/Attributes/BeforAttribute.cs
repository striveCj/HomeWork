using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Attributes
{
    public class BeforAttribute:Attribute
    {
        public Action Invoke(Action action)
        {
            return () =>
            {
                Console.WriteLine("方法开始执行了");
                action.Invoke();
            };
        }
    }
}
