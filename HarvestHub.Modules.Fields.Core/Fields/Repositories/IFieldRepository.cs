using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Modules.Fields.Core.Fields.ValueObjects;
using HarvestHub.Modules.Fields.Core.SharedKernel.ValueObjects;

namespace HarvestHub.Modules.Fields.Core.Fields.Repositories
{
    public interface IFieldRepository
    {
        Task AddAsync (Field field);
        Task DeleteAsync (Field field);
        Task UpdateAsync (Field field);
        Task<Field?> GetAsync (FieldId fieldId, OwnerId ownerId);
    }
}
