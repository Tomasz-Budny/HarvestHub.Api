using HarvestHub.Modules.Fields.Application.Dtos;

namespace HarvestHub.Modules.Fields.Application.Owners.Dtos
{
    public record UpdateStartLocationRequest(
        PointDto Point
    );
}
