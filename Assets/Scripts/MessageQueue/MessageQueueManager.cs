using System;
using System.Collections.Generic;
using MessageQueue.Message;
using UnityEngine;

namespace MessageQueue {
    public class MessageQueueManager {
        private readonly Dictionary<Type, List<Delegate>> _listeners;
        private static MessageQueueManager _instance;

        public static MessageQueueManager Instance
        {
            get { return _instance ?? (_instance = new MessageQueueManager()); }
        }

        private MessageQueueManager() {
            _listeners = new Dictionary<Type, List<Delegate>>();
        }

        public void AddListener<T>(Action<T> listener) where T : IMessage {
            List<Delegate> listeners = null;
            if (_listeners.TryGetValue(typeof(T), out listeners)) {
                listeners.Add(listener);
            }
            else {
                Delegate castDelegate = listener as Delegate;
                listeners = new List<Delegate> { listener };
                _listeners.Add(typeof(T), listeners);
            }
        }

        public void RemoveListener<T>(Action<T> listener) where T : IMessage {
            List<Delegate> listeners = null;
            if (_listeners.TryGetValue(typeof(T), out listeners)) {
                listeners.Remove(listener);
            }
        }
        public void SendMessage(IMessage message) {
            if (_listeners.TryGetValue(message.GetType(), out List<Delegate> listeners)) {
                for (int i = 0; i < listeners.Count; i++) {
                    Delegate listener = listeners[i];
                    listener.DynamicInvoke(message);
                }
            }
        }
    }
}