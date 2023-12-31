using HarvestHub.Modules.Fields.Application.Mappers;
using HarvestHub.Modules.Fields.Application.Owners.Dtos;
using HarvestHub.Modules.Fields.Application.Owners.Queries;
using HarvestHub.Modules.Fields.Core.Owners.Exceptions;
using HarvestHub.Modules.Fields.Core.Owners.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Queries.Owners
{
    internal class GetOwnerStartLocationQueryHandler : IQueryHandler<GetOwnerStartLocationQuery, StartLocationDto>
    {
        private readonly IOwnerRepository _ownerRepository;

        public GetOwnerStartLocationQueryHandler(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        public async Task<StartLocationDto> Handle(GetOwnerStartLocationQuery request, CancellationToken cancellationToken)
        {
            var owner = await _ownerRepository.GetAsync(request.OwnerId, cancellationToken);
            if (owner is null)
            {
                throw new OwnerNotFoundException(request.OwnerId);
            }

            var address = owner.Address;
            var startLocation = owner.StartLocation;

            if(address is null || startLocation is null) 
            {
                throw new StartLocationNotSetException(request.OwnerId);
            }

            var pointDto = PointMapper.MapToDto(startLocation);
            var addressDto = AddressMapper.MapToDto(address);

            return new StartLocationDto(pointDto, addressDto);
        }
    }
}
