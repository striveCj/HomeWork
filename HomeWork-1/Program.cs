using HomeWork_1.CodeGenerator;
using HomeWork_1.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using HomeWork_1.Attributes;
using HomeWork_1.ListExtension;

namespace HomeWork_1
{
    class Program
    {

        static void Main(string[] args)
        {

            //CommissionedToUse();
            FindAll();
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
            DbHelper db = Factory.GetDbHelper("sql");
            List<Company> list = db.FindAll<Company>();
            List<User> userList = db.FindAll<User>();

            foreach (var item in list.JakeWhere(item=>item.Id==1))
            {
                db.GetTypeInfo(item);
            }
            foreach (var item in userList.JakeWhere(item=>item.Id==1))
            {
                db.GetTypeInfo(item);
            }
        }

        /// <summary>
        /// 根据ID获取指定数据
        /// </summary>
        public static void FindById()
        {
            DbHelper db = Factory.GetDbHelper("sql");

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
            DbHelper db = Factory.GetDbHelper("sql");
            Company c = new Company
            {
                CreateTime = DateTime.Now,
                CreatorId = 1,
                LastModifierId = 1,
                LastModifyTime = DateTime.Now,
                Name = "昆特牌考提请蛋挞马拉松"
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
            DbHelper db = Factory.GetDbHelper("sql");
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
                Name = "我与春风皆过客1211111111111111211111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111",
                Account = "Account111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111",
                Password = "Password111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111",
                Email = "530216775@qq.com",
                Mobile = "15007140962",
                CreatorId = 21,
                CompanyName = "公司111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111112",
                CompanyId = 2111,
                State = 11111,
                UserType = 21111,
                LastLoginTime = DateTime.Now,
                CreateTime = DateTime.Now,
                LastModifyTime = DateTime.Now,
                LastModifierId = 21111,
                Id=21
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
            DbHelper db = Factory.GetDbHelper("sql");

            Console.WriteLine("user");
            Console.WriteLine(db.Delete<User>(2));
            Console.WriteLine("company");
            Console.WriteLine(db.Delete<Company>(1002));
        }

        /// <summary>
        /// 嵌套委托调用方法
        /// </summary>
        public static void CommissionedToUse()
        {
            DbHelper db = Factory.GetDbHelper("sql");
            Action action = () =>
            {
                foreach (var item in db.FindAll<User>())
                {
                    db.GetTypeInfo(item);
                }
            };
            Type type = db.GetType();
  
                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    var after= method.GetCustomAttributes(typeof(AfterAttribute), true);
                    foreach (AfterAttribute item in after)
                    {
                        action = item.Invoke(action);
                    }
                    var befor = method.GetCustomAttributes(typeof(BeforAttribute), true);
                    foreach (BeforAttribute item in befor)
                    {
                        action = item.Invoke(action);
                    }
                }
                action.Invoke(); 
        }
    }
}
