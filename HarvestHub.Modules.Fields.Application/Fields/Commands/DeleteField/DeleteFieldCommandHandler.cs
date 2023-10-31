using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.DeleteField
{
    internal class DeleteFieldCommandHandler : ICommandHandler<DeleteFieldCommand>
    {
        private readonly IFieldRepository _fieldRepository;

        public DeleteFieldCommandHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }
        public async Task Handle(DeleteFieldCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId) = request;

            var field = await _fieldRepository.GetAsync(fieldId, ownerId);

            if (field == null)
            {
                throw new FieldNotFoundException(fieldId);
            }

            await _fieldRepository.DeleteAsync(field);
        }
    }
}
