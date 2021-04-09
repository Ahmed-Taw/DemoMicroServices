using BaseEventBus.Abstractions;
using BaseEventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseEventBus
{
   public interface IEventBusSubscriptionsManager
    {

        void AddSubscription<T, TH>()
          where T : IntegrationEvent
          where TH : IIntegrationEventHandler<T>;

        void RemoveSubscription<T, TH>()
             where TH : IIntegrationEventHandler<T>
             where T : IntegrationEvent;

        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;

        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent;
        string GetEventKey<T>();
        Type GetEventTypeByName(string eventName);
        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);
        bool HasSubscriptionsForEvent(string eventName);


    }

    public class SubscriptionInfo
    {
        public Type HandlerType { get; }

        private SubscriptionInfo( Type handlerType)
        {
            HandlerType = handlerType;
        }

       
        public static SubscriptionInfo Typed(Type handlerType)
        {
            return new SubscriptionInfo(handlerType);
        }
    }
}
