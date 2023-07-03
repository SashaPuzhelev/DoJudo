using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

        public async Task<IEnumerable<ParticipantCompetition>> GetAll()
        {
            return await _dbDoJudo.ParticipantCompetitions.ToListAsync();
        }

        public async Task<IEnumerable<ParticipantCompetition>> GetAllByCompetition(Competition competition)
        {
            var list = await GetAll();
            List<ParticipantCompetition> result = new List<ParticipantCompetition>();
            foreach (var item in list)
            {
                if (item.Group.Competition == competition)
                    result.Add(item);
            }
            return result;
        }

        public async Task<IEnumerable<ParticipantCompetition>> GetByGroup(Group group)
        {
            var list  = await  GetAll();
            List<ParticipantCompetition> result = new List<ParticipantCompetition>();
            foreach (var item in list)
            {
                if (item.Group == group)
                    result.Add(item);
            }
            return result;
        }

        public bool IsParticipantCompetition(Participant entity)
        {
            var list = _dbDoJudo.ParticipantCompetitions.ToList();
            foreach (var item in list)
            {
                if (entity.Id == item.IdParticipant)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Update(ParticipantCompetition entity)
        {
            throw new NotImplementedException();
        }
    }
}
