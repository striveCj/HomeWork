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

            Delete();
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

        /// <summary>
        /// 查询所有数据
        /// </summary>
        public static void FindAll()
        {
            DbHelper db = new DbHelper();
            List<Company> list = db.FindAll<Company>();
            List<User> userList = db.FindAll<User>();

            foreach (var item in list)
            {
                db.GetTypeInfo(item);
            }
            foreach (var item in userList)
            {
                db.GetTypeInfo(item);
            }
        }

        /// <summary>
        /// 根据ID获取指定数据
        /// </summary>
        public static void FindById()
        {
            DbHelper db = new DbHelper();

            Company company = db.FindById<Company>(1);
            User user = db.FindById<User>(1);

            db.GetTypeInfo(company);
            db.GetTypeInfo(user);
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        public static void Add()
        {
            DbHelper db = new DbHelper();
            Company c = new Company
            {
                CreateTime = DateTime.Now,
                CreatorId = 1,
                LastModifierId = 1,
                LastModifyTime = DateTime.Now,
                Name = "公司"
            };
            User u=new User
            {
                Name = "我与春风皆过客",
                Account = "Account",
                Password = "Password",
                Email = "530216775@qq.com",
                Mobile = "15007140962",
                CreatorId = 1,
                CompanyName = "公司",
                CompanyId = 1,
                State = 1,
                UserType = 1,
                LastLoginTime = DateTime.Now,
                CreateTime = DateTime.Now,
                LastModifyTime = DateTime.Now,
                LastModifierId = 1
            };
            Console.WriteLine("user");
            Console.WriteLine(db.Add(u));
            Console.WriteLine("company");
            Console.WriteLine(db.Add(c));

        }

        /// <summary>
        /// 修改方法
        /// </summary>
        public static void Update()
        {
            DbHelper db = new DbHelper();
            Company c = new Company
            {
                Id = 1002,
                CreateTime = DateTime.Now,
                CreatorId = 2,
                LastModifierId = 2,
                LastModifyTime = DateTime.Now,
                Name = "2"
            };
            User u = new User
            {
                Name = "我与春风皆过客",
                Account = "Account",
                Password = "Password",
                Email = "530216775@qq.com",
                Mobile = "15007140962",
                CreatorId = 2,
                CompanyName = "公司",
                CompanyId = 2,
                State = 1,
                UserType = 2,
                LastLoginTime = DateTime.Now,
                CreateTime = DateTime.Now,
                LastModifyTime = DateTime.Now,
                LastModifierId = 2,
                Id=2
            };

       
            
            Console.WriteLine("user");
            Console.WriteLine(db.Update(u));
            Console.WriteLine("company");
            Console.WriteLine(db.Update(c));
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        public static void Delete()
        {
            DbHelper db = new DbHelper();
         
            Console.WriteLine("user");
            Console.WriteLine(db.Delete<User>(2));
            Console.WriteLine("company");
            Console.WriteLine(db.Delete<Company>(1002));
        }

    }
}
