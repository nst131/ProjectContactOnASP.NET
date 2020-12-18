using System.Collections.Generic;
using System.Linq;

namespace ContactTaskDomain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        int Count();
        void Add(T item);
        ICollection<T> GetCollection();
        IQueryable<T> GetQueryable();
        void Delete(T item);
        void DeleteById(object itemId);
        T Get(object id);
        T Create();
    }
}
