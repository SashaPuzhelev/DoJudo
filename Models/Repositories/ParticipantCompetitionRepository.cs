using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class ParticipantCompetitionRepository : IParticipantCompetitionRepository
    {
        private readonly DbDoJudo _dbDoJudo;
        public ParticipantCompetitionRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
        }
        public bool Add(ParticipantCompetition entity)
        {
            try
            {
                _dbDoJudo.ParticipantCompetitions.Add(entity);
                _dbDoJudo.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(ParticipantCompetition entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(IEnumerable<ParticipantCompetition> entities)
        {
            throw new NotImplementedException();
        }

        public ParticipantCompetition Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParticipantCompetition>> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(ParticipantCompetition entity)
        {
            throw new NotImplementedException();
        }
    }
}
