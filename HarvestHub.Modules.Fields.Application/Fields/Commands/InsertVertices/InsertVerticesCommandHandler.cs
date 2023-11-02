using HarvestHub.Modules.Fields.Application.Fields.Mappers;
using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Modules.Fields.Shared.Events.Fields;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.InsertVertices
{
    internal class InsertVerticesCommandHandler : ICommandHandler<InsertVerticesCommand>
    {
        private readonly IFieldRepository _fieldRepository;
        private readonly IMessageBroker _messageBroker;

        public InsertVerticesCommandHandler(IFieldRepository fieldRepository, IMessageBroker messageBroker)
        {
            _fieldRepository = fieldRepository;
            _messageBroker = messageBroker;
        }
        public async Task Handle(InsertVerticesCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, verticesDto, newArea) = request;

            var field = await _fieldRepository.GetAsync(fieldId, ownerId);


            if (field is null)
            {
                throw new FieldNotFoundException(fieldId);
            }

            var oldArea = field.Area.Value;
            var vertices = verticesDto.Select(x => VertexMapper.Map(x));
            field.InsertVertices(new LinkedList<Vertex>(vertices));
            field.Area = newArea;

            await _fieldRepository.UpdateAsync(field);
            await _messageBroker.PublishAsync(new FieldAreaChanged(fieldId, ownerId, oldArea, newArea));
        }
    }
}
