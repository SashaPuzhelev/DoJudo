using DoJudo.Models.Database;
using DoJudo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Repositories
{
    internal class GroupRepository : IGroupRepository
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly DbDoJudo _dbDoJudo;
        public GroupRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
            _participantRepository = new ParticipantRepository();
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
        public void DefiningGroupCategories(Group entity, Participant participant, float weight)
        {
            entity.GenderCategory = participant.Gender;
            if (_participantRepository.GetAge(participant) > 0)
            {

            }
        }
    }
}
