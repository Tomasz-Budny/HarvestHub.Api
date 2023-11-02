using HarvestHub.Modules.Fields.Application.Fields.Mappers;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Core.Fields.Repositories;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Application.Fields.Commands.ReplaceVertices
{
    internal class ReplaceVerticesCommandHandler : ICommandHandler<ReplaceVerticesCommand>
    {
        private readonly IFieldRepository _fieldRepository;

        public ReplaceVerticesCommandHandler(IFieldRepository fieldRepository)
        {
            _fieldRepository = fieldRepository;
        }
        public async Task Handle(ReplaceVerticesCommand request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId, verticesDto, area) = request;

            var field = await _fieldRepository.GetAsync(fieldId, ownerId);

            if (field is null)
            {
                throw new FieldNotFoundException(fieldId);
            }

            var vertices = verticesDto.Select(x => VertexMapper.Map(x));
            field.SetVertices(vertices);
            field.Area = area;
            await _fieldRepository.UpdateAsync(field);
        }
    }
}
