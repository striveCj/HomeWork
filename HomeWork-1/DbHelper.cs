﻿using HomeWork_1.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace HomeWork_1
{
    public class DbHelper
    {
        /// <summary>
        /// 链接字符串，需要转到json配置中去
        /// </summary>
        private string _connString = Factory.GetConfigInfo();

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public List<T> FindAll<T>() where T:BaseModel.BaseModel
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

        /// <summary>
        /// 更具主键获取参数
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById<T>(int id) where T : BaseModel.BaseModel, new()
        {
            var t = typeof(T);
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                string tableName = t.Name;
                tableName = GetDbTableName<T>();
                string sql = $"select * from [{tableName}] where id=@id";
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue($"@id", id);
                SqlDataReader dr = comm.ExecuteReader();
                return DataReaderToModel<T>(dr)[0];
            }
        }

        /// <summary>
        /// 获取数据库表名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private string GetDbTableName<T>() where T : BaseModel.BaseModel, new()
        {
            var t = typeof(T);
            object[] customAttrs = t.GetCustomAttributes(true);
            string tableName = "";
            for (int i = 0; i < customAttrs.Length; i++)
            {
                if (customAttrs[i] is TableNameAttribute)
                {
                    TableNameAttribute tnAttr = (TableNameAttribute)customAttrs[i];
                    tableName = tnAttr.TableName;
                }
            }
            return tableName;
        }

        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add<T>(T t) where T : BaseModel.BaseModel
        {
            if (!ValidateNameFieldLength<T>())
            {
                Console.WriteLine("校验失败");
                return 0;
            }
            var modelType = t.GetType();
            var properties = modelType.GetProperties();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                var sql = GetInsertSql(modelType, properties);
                SqlCommand comm = new SqlCommand(sql, conn);
                foreach (var propertied in properties)
                {
                    comm.Parameters.AddWithValue($"@{propertied.Name}", propertied.GetValue(t));
                }
                return comm.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 校验name字符长度
        /// </summary>
        /// <returns></returns>
        private bool ValidateNameFieldLength<T>()
        {
            Type t = typeof(T);
            PropertyInfo[] propertyInfos = t.GetProperties();

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

        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update<T>(T t) where T : BaseModel.BaseModel
        {
            var modelType = t.GetType();
            var properties = modelType.GetProperties();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                var sql = GetUpdateSql(modelType, properties);
                SqlCommand comm = new SqlCommand(sql, conn);

                foreach (var propertied in properties)
                {
                    comm.Parameters.AddWithValue($"@{propertied.Name}", propertied.GetValue(t));
                }

                return comm.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete<T>(int id) where T : BaseModel.BaseModel
        {
            var modelType = typeof(T);
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                conn.Open();
                var sql = GetDeleteSql(modelType);
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.Parameters.AddWithValue($"@Id",id);
                return comm.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 获取新增sql
        /// </summary>
        /// <param name="modelType"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        private  string GetInsertSql(Type modelType, PropertyInfo[] properties)
        {
            StringBuilder sb = new StringBuilder();
            string valueSql = "";
            sb.Append($"insert [{modelType.Name}] (");

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name.ToLower() == "id") continue;

                sb.Append(i == properties.Length - 2 ? properties[i].Name : $"{properties[i].Name},");
                valueSql += i == properties.Length - 2 ? $"@{properties[i].Name}" : $"@{properties[i].Name},";
            }

            sb.Append(") Values(");
            sb.Append(valueSql);
            sb.Append(")");
            return sb.ToString();
        }

        /// <summary>
        /// 获取修改sql
        /// </summary>
        /// <param name="modelType"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        private string GetUpdateSql(Type modelType, PropertyInfo[] properties)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Update [{modelType.Name}] set ");

            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].Name.ToLower() == "id") continue;

                sb.Append(i == properties.Length - 2 ? $"{properties[i].Name}=@{properties[i].Name}" : $"{properties[i].Name}=@{properties[i].Name},");
            }
            sb.Append(" where Id=@Id ");
            return sb.ToString();
        }

        /// <summary>
        /// 获取删除sql
        /// </summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        private string GetDeleteSql(Type modelType)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Delete FROM [{modelType.Name}] ");
            sb.Append("where Id=@Id");
            return sb.ToString();
        }


        /// <summary>
        /// DataReader转实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        public List<T> DataReaderToModel<T>(SqlDataReader dr) where T : BaseModel.BaseModel
        {
            var list = new List<T>();
            if (!dr.HasRows) return list;
            while (dr.Read())
            {
                var t = (T)Activator.CreateInstance(typeof(T));
                for (var i = 0; i < dr.FieldCount; i++)
                {
                    var p = t.GetType().GetProperty(dr.GetName(i), BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                    if (p != null) p.SetValue(t, Convert.IsDBNull(dr.GetValue(i)) ? null : dr.GetValue(i), null);
                    list.Add(t);
                }
            }
            return list;
        }
    
        
        /// <summary>
        /// 获取当前传入实体的所有属性，属性值
        /// </summary>
        /// <param name="t"></param>
        public void GetTypeInfo<T>(T t) where T : BaseModel.BaseModel
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
