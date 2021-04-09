using BaseEventBus.Abstractions;
using Mapping.MessagebusEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mapping.MessagebusEventsHandlers
{
    public class FormularyItemCreatedIntegrationEventHandler : IIntegrationEventHandler<FormularyItemCreatedIntegrationEvent>
    {
        public Task Handle(FormularyItemCreatedIntegrationEvent @event)
        {

          return Task.Run(() =>
           {
               if (@event.FormularyItems.Count() > 0)
               {
                   Console.WriteLine("Message Recieved");
               }
           });
        }
    }
}
