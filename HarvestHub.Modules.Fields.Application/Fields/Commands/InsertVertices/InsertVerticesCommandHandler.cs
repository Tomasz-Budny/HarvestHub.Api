using HarvestHub.Modules.Fields.Application.Fields.Mappers;
using HarvestHub.Modules.Fields.Core.Fields.Entities;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.InsertVertices
{
    internal class InsertVerticesCommandHandler : ICommandHandler<InsertVerticesCommand>
    {
        private readonly IFieldRepository _fieldRepository;

        public InsertVerticesCommandHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }
        public async Task Handle(InsertVerticesCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, verticesDto) = request;

            var field = await _fieldRepository.GetAsync(fieldId, ownerId);


            if (field is null)
            {
                throw new FieldNotFoundException(fieldId);
            }

            var vertices = verticesDto.Select(x => VertexMapper.Map(x));
            field.InsertVertices(new LinkedList<Vertex>(vertices));

            await _fieldRepository.UpdateAsync(field);
        }
    }
}
