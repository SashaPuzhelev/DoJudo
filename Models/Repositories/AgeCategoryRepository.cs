using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class AgeCategoryRepository : IAgeCategoryRepository
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly DbDoJudo _dbDoJudo;
        public AgeCategoryRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
            _participantRepository = new ParticipantRepository();
        }
        public bool Add(AgeCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(AgeCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(IEnumerable<AgeCategory> entities)
        {
            throw new NotImplementedException();
        }

        public AgeCategory Get(int id)
        {
            throw new NotImplementedException();
        }

        public AgeCategory GetAgeCategory(Participant participant)
        {
            int age = _participantRepository.GetAge(participant);
            var AgeCategoryList = GetAllNoAsync();
            foreach (var item in AgeCategoryList)
            {
                if (age >= item.StartAge && age <= item.EndAge)
                {
                    return item;
                }
            }
            return null;
        }
        public IEnumerable<AgeCategory> GetAllNoAsync()
        {
            return _dbDoJudo.AgeCategories.ToList();
        }
        public Task<IEnumerable<AgeCategory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(AgeCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
