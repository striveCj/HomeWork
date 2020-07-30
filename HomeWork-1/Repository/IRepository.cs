using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Repository
{
    public interface IRepository<T> where T:BaseModel.BaseModel
    {
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<T> FindAll();

        /// <summary>
        /// 根据ID获取指定数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T FindById(int id);

        /// <summary>
        /// 新增方法
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Add(T t);

        /// <summary>
        /// 修改方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public int Update(T t);

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id);
    }
}
