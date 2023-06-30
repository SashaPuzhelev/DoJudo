using DoJudo.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoJudo.Models.Interfaces
{
    internal interface IWeightCategoryRepository : IBaseRepository<WeightCategory>
    {
        WeightCategory GetWeightCategory(float weight);
    }
}
