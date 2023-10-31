using HarvestHub.Modules.Fields.Application.Fields.Dtos;
using HarvestHub.Modules.Fields.Application.Fields.Queries;
using HarvestHub.Modules.Fields.Core.Fields.Aggregates;
using HarvestHub.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Modules.Fields.Core.Fields.Exceptions;
using HarvestHub.Modules.Fields.Application.Fields.Mappers;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Queries.Handlers
{
    internal sealed class GetFieldQueryHandler : IQueryHandler<GetFieldQuery, FieldDto>
    {
        private readonly DbSet<Field> _fields;

        public GetFieldQueryHandler(FieldsDbContext dbContext)
        {
            _fields = dbContext.Fields;
        }
        public async Task<FieldDto> Handle(GetFieldQuery request, CancellationToken cancellationToken)
        {
            var field = await _fields.SingleOrDefaultAsync(f => f.Id.Value == request.FieldId);

            if(field == null)
            {
                throw new FieldNotFoundException(request.FieldId);
            }

            return FieldMapper.MapToDto(field);
        }
    }
}
