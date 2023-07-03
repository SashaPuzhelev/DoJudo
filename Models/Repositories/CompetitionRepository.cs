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
            try
            {
                _dbDoJudo.Competitions.Add(entity);
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
        public IEnumerable<Competition> GetAllNoAsync()
        {
            return _dbDoJudo.Competitions.ToList();
        }
        public bool Update(Competition entity)
        {
            throw new NotImplementedException();
        }
    }
}
