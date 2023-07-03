using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;

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

        public async Task<IEnumerable<Group>> GetAll()
        {
            return await _dbDoJudo.Groups.ToListAsync();
        }
        public bool Update(Group entity)
        {
            throw new NotImplementedException();
        }
        public bool IsNoDublicateGroup(Group entity)
        {
            if (SearchGroup(entity) == null)
            {
                return true;
            }
            return false;
        }
        public Group SearchGroup(Group entity)
        {
            var list = _dbDoJudo.Groups.ToList();
            foreach (var item in list)
            {
                if (entity.AgeCategory == item.AgeCategory && entity.WeightCategory == item.WeightCategory
                    && entity.GenderCategory == item.GenderCategory)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
