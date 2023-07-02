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
    internal class HistoryLoginRepository : IHistoryLoginRepository
    {
        private readonly DbDoJudo _dbDoJudo;
        public HistoryLoginRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
        }
        public bool Add(HistoryLogin entity)
        {
            try
            {
                _dbDoJudo.HistoryLogins.Add(entity);
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(HistoryLogin entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(IEnumerable<HistoryLogin> entities)
        {
            throw new NotImplementedException();
        }

        public HistoryLogin Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HistoryLogin>> GetAll()
        {
            return await _dbDoJudo.HistoryLogins.ToListAsync();
        }

        public bool Update(HistoryLogin entity)
        {
            throw new NotImplementedException();
        }
    }
}
