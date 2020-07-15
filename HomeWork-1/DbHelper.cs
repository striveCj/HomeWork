using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace HomeWork_1
{
    public class DbHelper<T> where T:BaseModel.BaseModel,new()
    {
        /// <summary>
        /// 链接字符串，需要转到json配置中去
        /// </summary>
        private string _connString = @"Data Source=.;Initial Catalog=HomeWork;User ID=sa;Password=w1!";

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public List<T> FindAll()
        {
            Type t = typeof(T);
            using (SqlConnection conn=new SqlConnection(_connString))
            {
                conn.Open();
                string sql = $"select * from [{t.Name}]";
                SqlCommand comm = new SqlCommand(sql, conn);
                SqlDataReader dr = comm.ExecuteReader();
                return DataReaderToModel<T>(dr);
            }
        }

        public T FindById(int id)
        {
            Type t = typeof(T);
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                string sql = $"select * from [{t.Name}] where id=@id";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue($"@id", id);
                SqlDataReader dr = comm.ExecuteReader();
                return DataReaderToModel<T>(dr)[0];
            }
        }

        /// <summary>
        /// DataReader转实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public List<T> DataReaderToModel<T>(SqlDataReader dr)
        {
            var list = new List<T>();
            T t = default;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    t = (T)Activator.CreateInstance(typeof(T));
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        var p = t.GetType().GetProperty(dr.GetName(i), BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                        if (Convert.IsDBNull(dr.GetValue(i)))
                        {
                            p.SetValue(t, null, null);
                        }
                        else
                        {
                            p.SetValue(t, dr.GetValue(i), null);
                        }
                        list.Add(t);
                    }
                }
            }
            return list;
        }
    
        
        /// <summary>
        /// 获取当前传入实体的所有属性，属性值
        /// </summary>
        /// <param name="t"></param>
        public void GetTypeInfo(T t)
        {
            Type type = t.GetType();

            var properties = type.GetProperties();

            foreach (var item in properties)
            {
                Console.WriteLine($"当前属性:{item.Name}.对应属性值:{item.GetValue(t)}");
            }
        }
    }

}
