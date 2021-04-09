using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseEventBus.Events
{
   public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;

        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime timeStamp)
        {
            Id = id;
            Timestamp = timeStamp;
        }

        [JsonProperty]
        public Guid Id { get; set; }
        [JsonProperty]
        public DateTime Timestamp { get; set; }

    }
}
