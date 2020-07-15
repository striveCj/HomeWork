using HomeWork_1.CodeGenerator;
using System;
using System.Collections.Generic;
using System.Data;

namespace HomeWork_1
{
    class Program
    {
        static void Main(string[] args)
        {

            FindById();
        }

        /// <summary>
        /// 实体代码生成器
        /// </summary>
        public static void CodeGeerator()
        {
            Console.WriteLine("输入Y生成代码");
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "y")
            {
                new CodeGenerator.CodeGenerator().CodeRun();
            }
        }

        public static void FindAll()
        {
            DbHelper<User> dbu = new DbHelper<User>();
            DbHelper<Company> dbc = new DbHelper<Company>();
            List<Company> list = dbc.FindAll();
            List<User> userList = dbu.FindAll();

            foreach (var item in list)
            {
                dbc.GetTypeInfo(item);
            }
            foreach (var item in userList)
            {
                dbu.GetTypeInfo(item);
            }
        }

        public static void FindById()
        {
            DbHelper<User> dbu = new DbHelper<User>();
            DbHelper<Company> dbc = new DbHelper<Company>();
            Company company = dbc.FindById(1);
            User user = dbu.FindById(1);

            dbc.GetTypeInfo(company);
            dbu.GetTypeInfo(user);
        }

       
    }
}
