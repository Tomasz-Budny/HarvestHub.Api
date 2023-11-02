using HarvestHub.Modules.Fields.Application.Fields.Mappers;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Shared.Events.Fields;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.ReplaceVertices
{
    internal class ReplaceVerticesCommandHandler : ICommandHandler<ReplaceVerticesCommand>
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMessageBroker _messageBroker;

        public ReplaceVerticesCommandHandler(IFieldRepository fieldRepository, IMessageBroker messageBroker)
        {
            _fieldRepository = fieldRepository;
            _messageBroker = messageBroker;
        }
        public async Task Handle(ReplaceVerticesCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, verticesDto, newArea) = request;

            var field = await _fieldRepository.GetAsync(fieldId, ownerId);

            if (field is null)
            {
                throw new FieldNotFoundException(fieldId);
            }

            var oldArea = field.Area.Value;
            var vertices = verticesDto.Select(x => VertexMapper.Map(x));
            field.SetVertices(vertices);
            field.Area = newArea;

            await _fieldRepository.UpdateAsync(field);
            await _messageBroker.PublishAsync(new FieldAreaChanged(fieldId, ownerId, oldArea, newArea));
        }
    }
}
