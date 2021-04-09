using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventBusRabbitMQ.Interfaces
{
    public interface IRabbitMQPersistentConnection : IDisposable
    {
        public bool IsConnected { get;}
        bool TryConnect();

        IModel CreateModel();
    }
}
