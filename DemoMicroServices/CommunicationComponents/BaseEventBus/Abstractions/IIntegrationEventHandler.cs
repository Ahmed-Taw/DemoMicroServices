using BaseEventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BaseEventBus.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> 
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }

}
