﻿namespace HarvestHub.Shared.Events
{
    public interface IEventDispatcher
    {
        Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken = default)
            where TEvent : class, IEvent;
    }
}
