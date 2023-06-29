using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class CompetitionRepository : ICompetitionRepository
    {
        private readonly DbDoJudo _dbDoJudo;
        public CompetitionRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
        }
        public bool Add(Competition entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Competition entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(IEnumerable<Competition> entities)
        {
            throw new NotImplementedException();
        }

        public Competition Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Competition>> GetAll()
        {
            return await _dbDoJudo.Competitions.ToListAsync();
        }

        public bool Update(Competition entity)
        {
            throw new NotImplementedException();
        }
    }
}
