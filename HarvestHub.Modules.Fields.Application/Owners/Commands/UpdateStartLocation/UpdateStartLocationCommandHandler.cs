﻿using HarvestHub.Modules.Fields.Application.Mappers;
using HarvestHub.Modules.Fields.Application.Services;
using HarvestHub.Modules.Fields.Core.Owners.Exceptions;
using HarvestHub.Modules.Fields.Core.Owners.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Owners.Commands.UpdateStartLocation
{
    internal class UpdateStartLocationCommandHandler : ICommandHandler<UpdateStartLocationCommand>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IAddressService _addressService;

        public UpdateStartLocationCommandHandler(IOwnerRepository ownerRepository, IAddressService addressService)
        {
            _ownerRepository = ownerRepository;
            _addressService = addressService;
        }

        public async Task Handle(UpdateStartLocationCommand request, CancellationToken cancellationToken)
        {
            var (ownerId, pointDto) = request;

            var owner = await _ownerRepository.GetAsync(ownerId, cancellationToken);
            if(owner is null) 
            {
                throw new OwnerNotFoundException(ownerId);
            }

            var point = PointMapper.Map(pointDto);
            var address = await _addressService.GetAddressAsync(point.Latitude, point.Longitude);

            owner.ChangeStartLocation(point, address);

            await _ownerRepository.UpdateAsync(owner, cancellationToken);
        }
    }
}
