using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_1.Repository
{
    public class Repository<T> : IRepository<T> where T:BaseModel.BaseModel
    {
        public int Add(T t)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
