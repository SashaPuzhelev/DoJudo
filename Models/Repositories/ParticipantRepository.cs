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
    internal class ParticipantRepository : IParticipantRepository
    {
        private readonly DbDoJudo _dbDoJudo;
        public ParticipantRepository()
        {
            _dbDoJudo = DbDoJudo.GetInstance();
        }

        public bool Create(Participant entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Participant entity)
        {
            throw new NotImplementedException();
        }

        public Participant Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Participant> GetAll()
        {
            return _dbDoJudo.Participants.ToList();
        }

        public Participant GetByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public bool Update(Participant entity)
        {
            throw new NotImplementedException();
        }
    }
}
