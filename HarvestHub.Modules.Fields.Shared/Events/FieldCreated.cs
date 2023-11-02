using HarvestHub.Shared.Events;

namespace HarvestHub.Modules.Fields.Shared.Events
{
    public record FieldCreated(string Name, double Area) : IEvent;
}
