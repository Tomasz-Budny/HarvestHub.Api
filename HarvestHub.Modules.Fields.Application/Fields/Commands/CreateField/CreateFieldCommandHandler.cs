﻿using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.CreateField
{
    public class CreateFieldCommandHandler : ICommandHandler<CreateFieldCommand>
    {
        public Task Handle(CreateFieldCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("It is working!");
            return Task.CompletedTask;
        }
    }
}
