using System;
using System.Collections.Generic;

namespace GameEngine.Runtime.Module.Event
{
    internal interface IEventHandlers
    {
        public void BroadCast<T>(T e) where T : EventBase;
    }
    internal class EventHandlers<T> : IEventHandlers where T : EventBase
    {
        public List<Action<T>> handlers = new();

        public void AddListener(Action<T> handler)
        {
            if (handler == null)
                return;
            if (handlers.Contains(handler))
                return;

            handlers.Add(handler);
        }

        public void RemoveListener(Action<T> handler)
        {
            if (handler == null)
                return;

            handlers.Remove(handler);
        }

        public void BroadCast<T1>(T1 e) where T1 : EventBase
        {
            foreach (var handler in handlers)
            {
                handler.Invoke(e as T);
            }
        }
   
    }
}
