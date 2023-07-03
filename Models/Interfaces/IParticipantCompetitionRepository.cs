using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Interfaces
{
    internal interface IParticipantCompetitionRepository : IBaseRepository<ParticipantCompetition>
    {
        Task<IEnumerable<ParticipantCompetition>> GetByGroup(Group group);
    }
}
