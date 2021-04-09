using BaseEventBus.Abstractions;
using BaseEventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseEventBus
{
    public class InMemoryEventBusSubscriptionsManager : IEventBusSubscriptionsManager
    {
        private readonly Dictionary<string, List<SubscriptionInfo>> _handlers;
        private readonly List<Type> _eventTypes;

        public event EventHandler<string> OnEventRemoved;

        public InMemoryEventBusSubscriptionsManager()
        {
            _handlers = new Dictionary<string, List<SubscriptionInfo>>();
            _eventTypes = new List<Type>();

        }
        public void AddSubscription<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventName = GetEventKey<T>();

            DoAddSubscription(typeof(TH), eventName, isDynamic: false);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }
        }

        private void DoAddSubscription(Type type, string eventName, bool isDynamic)
        {

            if (!_handlers.ContainsKey(eventName))
            {
                _handlers.Add(eventName, new List<SubscriptionInfo>());
            }

            if(_handlers[eventName].Find(s => s.HandlerType == type) != null)
            {
                throw new Exception($"Handler with type {type} already exist");
            }

            _handlers[eventName].Add(SubscriptionInfo.Typed(type));

        }

        public string GetEventKey<T>()
        {
            return typeof(T).Name;
        }

        public IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent
        {
            var eventName = GetEventKey<T>();

            if (!_handlers.ContainsKey(eventName))
                return new List<SubscriptionInfo>();

            return _handlers[eventName].ToList();

        }

        public bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent
        {
            var key = GetEventKey<T>();
            return HasSubscriptionsForEvent(key);
        }

        public void RemoveSubscription<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {

            var eventName = GetEventKey<T>();
            var subInfo = FindSubscriptionToRemove(eventName, typeof(TH));
            DoRemoveHandler(eventName, subInfo);
        }


        private void DoRemoveHandler(string eventName, SubscriptionInfo subsToRemove)
        {
            if (subsToRemove != null)
            {
                _handlers[eventName].Remove(subsToRemove);
                if (!_handlers[eventName].Any())
                {
                    _handlers.Remove(eventName);
                    var eventType = _eventTypes.SingleOrDefault(e => e.Name == eventName);
                    if (eventType != null)
                    {
                        _eventTypes.Remove(eventType);
                    }
                }

            }
        }


        private SubscriptionInfo FindSubscriptionToRemove(string eventName, Type handlerType)
        {
            if (!_handlers.ContainsKey(eventName))
            {
                return null;
            }
            return _handlers[eventName].SingleOrDefault(s => s.HandlerType == handlerType);
        }

        public Type GetEventTypeByName(string eventName) => _eventTypes.SingleOrDefault(t => t.Name == eventName);


        public IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName) => _handlers[eventName];


        public bool HasSubscriptionsForEvent(string eventName) => _handlers.ContainsKey(eventName);
    }
}
