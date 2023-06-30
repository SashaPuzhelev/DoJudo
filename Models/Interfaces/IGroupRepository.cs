﻿using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Interfaces
{
    internal interface IGroupRepository : IBaseRepository<Group>
    {
        bool IsNoDublicateGroup(Group group);
        void DefiningGroupCategories(Group group, Participant participant, float weight);
    }
}
