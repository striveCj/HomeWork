using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_2
{
    public class Say:IBaseInterface
    {
        public void GetUp()
        {
            Console.WriteLine("鲤鱼上钩了");
        }
    }

    public class SayWork : IBaseInterface
    {
        public void GetUp()
        {
            Console.WriteLine("鲈鱼上钩了");
        }
    }
}
