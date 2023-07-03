using DoJudo.Models.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoJudo.Models.Interfaces
{
    internal interface IBaseRepository<T>
    {
        bool Add(T entity);

        bool Update(T entity);
        bool Delete(T entity);
        T Get(int id);
        Task<IEnumerable<T>> GetAll();
        bool DeleteItems(IEnumerable<T> entities);
    }
}
