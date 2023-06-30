using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class WeightCategoryRepository : IWeightCategoryRepository
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly DbDoJudo _dbDoJudo;
        public WeightCategoryRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
            _participantRepository = new ParticipantRepository();
        }
        public bool Add(WeightCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(WeightCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItems(IEnumerable<WeightCategory> entities)
        {
            throw new NotImplementedException();
        }

        public WeightCategory Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WeightCategory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public WeightCategory GetWeightCategory(float weight)
        {
            var WeightCategoryList = GetAllNoAsync();
            foreach (var item in WeightCategoryList)
            {
                if (weight >= item.StartWeight && weight <= item.EndWeight)
                {
                    return item;
                }
            }
            return null;
        }
        public IEnumerable<WeightCategory> GetAllNoAsync()
        {
            return _dbDoJudo.WeightCategories.ToList();
        }
        public bool Update(WeightCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
