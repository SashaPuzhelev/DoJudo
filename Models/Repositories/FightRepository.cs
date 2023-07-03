using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class FightRepository : IFightRepository
    {
        private readonly DbDoJudo _dbDoJudo;
        public FightRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
        }
        public bool Add(Fight entity)
        {
            try
            {
                _dbDoJudo.Fights.Add(entity);
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Fight entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(IEnumerable<Fight> entities)
        {
            throw new NotImplementedException();
        }

        public Fight Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fight>> GetAll()
        {
            throw new NotImplementedException();
        }
                public bool Update(Fight entity)
        {
            throw new NotImplementedException();
        }
    }
}
