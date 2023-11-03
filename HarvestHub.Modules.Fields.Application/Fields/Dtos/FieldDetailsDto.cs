using HarvestHub.Modules.Fields.Application.Dtos;
using HarvestHub.Modules.Fields.Core.Fields.Primitives;

namespace HarvestHub.Modules.Fields.Application.Fields.Dtos
{
    public record FieldDetailsDto(
        string Name, 
        PointDto Center, 
        DateTime CreatedAt, 
        double Area, 
        FieldClassStatus Class, 
        OwnershipStatus OwnershipStatus,
        AddressDto Address, 
        string Color
    );
}
