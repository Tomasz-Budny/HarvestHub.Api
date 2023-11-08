using HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Queries;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Services;
using HarvestHub.Shared.Messaging;

namespace HarvestHub.Modules.Fields.Infrastructure.Persistance.Queries.CultivationHistories.Handlers
{
    internal class GetAllHistoryRecordsByFieldIdQueryHandler : IQueryHandler<GetAllHistoryRecordsByFieldIdQuery, IEnumerable<HarvestHistoryRecordDto>>
    {
        private readonly ICultivationHistoryService _cultivationHistoryService;

        public GetAllHistoryRecordsByFieldIdQueryHandler(ICultivationHistoryService cultivationHistoryService)
        {
            _cultivationHistoryService = cultivationHistoryService;
        }
        public async Task<IEnumerable<HarvestHistoryRecordDto>> Handle(GetAllHistoryRecordsByFieldIdQuery request, CancellationToken cancellationToken)
        {
            var (fieldId, ownerId) = request;

            var cultivationhistory = await _cultivationHistoryService.GetByFieldId(fieldId, ownerId, cancellationToken);

            var historyRecords = cultivationhistory.History;

            return historyRecords;
        }
    }
}
