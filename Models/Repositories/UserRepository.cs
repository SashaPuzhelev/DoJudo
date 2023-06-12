using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DbDoJudo _dbDoJudo;
        public UserRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
        }
        public async Task<User> CheckLogin(string username, string password)
        {
            return await _dbDoJudo.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }

        public bool Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(IEnumerable<User> entities)
        {
            throw new NotImplementedException();
        }
    }
}
