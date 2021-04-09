using BaseEventBus.Events;
using Formulary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formulary.MessagebusEvents
{
    public class FormularyItemCreatedIntegrationEvent : IntegrationEvent
    {
        public IEnumerable<FormularyItem> FormularyItems { get; set; }


    }
}
