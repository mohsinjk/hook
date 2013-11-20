using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Data.Contracts
{
    public interface IRepository<T> where T: class 
    {
        IQueryable<T> GetAll();
        T GetById(string key, int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(string key, int id);
    }
}
