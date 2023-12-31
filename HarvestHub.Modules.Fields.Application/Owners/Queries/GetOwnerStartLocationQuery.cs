using HarvestHub.Modules.Fields.Application.Owners.Dtos;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Owners.Queries
{
    public record GetOwnerStartLocationQuery(Guid OwnerId) : IQuery<StartLocationDto>;
}
