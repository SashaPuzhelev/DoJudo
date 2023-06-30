using DoJudo.Models.Database;

namespace DoJudo.Models.Interfaces
{
    internal interface IAgeCategoryRepository : IBaseRepository<AgeCategory>
    {
        AgeCategory GetAgeCategory(Participant participant);
    }
}
