using AutoMapper;
using HarvestHub.Modules.Fields.Application.CultivationHistories.Dtos;
using HarvestHub.Modules.Fields.Core.CultivationHistories.Entities;

namespace HarvestHub.Modules.Fields.Application.CultivationHistories.Mappers
{
    internal class CultivationHistoryProfile : Profile
    {
        public CultivationHistoryProfile()
        {
            CreateMap<HarvestHistoryRecord, HarvestHistoryRecordDto>()
                .ForMember(dto => dto.Amount, source => source.MapFrom(x => x.Amount))
                .ForMember(dto => dto.Humidity, source => source.MapFrom(x => x.Humidity));

            CreateMap<FertilizationHistoryRecord, FertilizationHistoryRecordDto>()
                .ForMember(dto => dto.Amount, source => source.MapFrom(x => x.Amount));

            CreateMap<HistoryRecord, HistoryRecordDto>()
                .Include<HarvestHistoryRecord, HarvestHistoryRecordDto>()
                .Include<FertilizationHistoryRecord, FertilizationHistoryRecordDto>()
                .ForMember(dto => dto.Id, source => source.MapFrom(x => x.Id))
                .ForMember(dto => dto.Type, source => source.MapFrom(x => x.GetType().Name.Replace("HistoryRecord", string.Empty)));
        }
    }
}
