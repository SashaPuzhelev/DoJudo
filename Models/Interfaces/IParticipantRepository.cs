using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Interfaces
{
    internal interface IParticipantRepository : IBaseRepository<Participant>
    {
        Participant GetByPhone(string phone);
        int GetAge(Participant entity);
    }
}
