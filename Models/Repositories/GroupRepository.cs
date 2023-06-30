using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class GroupRepository : IGroupRepository
    {
        public bool Add(Group entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(IEnumerable<Group> entities)
        {
            throw new NotImplementedException();
        }

        public Group Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
