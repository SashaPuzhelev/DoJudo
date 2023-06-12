using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoJudo.Models.Interfaces
{
    internal interface IBaseRepository<T>
    {
        bool Create(T entity);

        bool Update(T entity);
        bool Delete(T entity);
        T Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
