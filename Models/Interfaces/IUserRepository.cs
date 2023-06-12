using DoJudo.Models.Database;
using System.Threading.Tasks;

namespace DoJudo.Models.Interfaces
{
    internal interface IUserRepository : IBaseRepository<User>
    {
        Task<User> CheckLogin(string username, string password);
    }
}
