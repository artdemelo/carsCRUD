using System.Collections.Generic;

namespace Carros.Interfaces
{
    public interface IRepository<T>
    {
         List<T> Listing();
         T ReturnPerId(int id);
         void Insert(T entity);
         void Delete(int id);
         void Update(int id, T entity);
         int NextId();
    }
}