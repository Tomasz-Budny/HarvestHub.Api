using HarvestHub.Modules.Fields.Core.Fields.Aggregates;

namespace HarvestHub.Modules.Fields.Core.Fields.Repositories
{
    public interface IFieldRepository
    {
        Task AddAsync (Field field);
    }
}
