using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class GroupRepository : IGroupRepository
    {
        private readonly DbDoJudo _dbDoJudo;
        public GroupRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
        }
        public bool Add(Group entity)
        {
            try
            {
                if (IsNoDublicateGroup(entity))
                {
                    _dbDoJudo.Groups.Add(entity);
                    _dbDoJudo.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
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
        public bool IsNoDublicateGroup(Group entity)
        {
            var groupExists = _dbDoJudo.Groups.Find(entity);
            if (groupExists is null)
            {
                return true;
            }
            return false;
        }
        public int AddWithReturnIdGroup(Group entity)
        {
            try
            {
                _dbDoJudo.Groups.Add(entity);
                int id = _dbDoJudo.Groups.Find(entity).Id;
                _dbDoJudo.SaveChanges();
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
