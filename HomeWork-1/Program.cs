using System;
using System.Collections.Generic;
using System.Data;

namespace HomeWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入Y生成代码");
            string userInput = Console.ReadLine();
            if (userInput.ToLower()=="y")
            {
                new CodeGenerator.CodeGenerator().CodeRun();
            }

        }
    }
}
