using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace HomeWork_1.Attributes
{
    public class AfterAttribute:Attribute
    {
        public Action Invoke(Action action)
        {
            return () =>
            {
        
                action.Invoke();
                Console.WriteLine("方法执行完毕");
            };

        }
    }
}
