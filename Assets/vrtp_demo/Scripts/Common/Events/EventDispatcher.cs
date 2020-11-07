
using System;
using UniRx;
using UnityEngine;
using vrtp_demo.Scripts.Common.Events;

namespace vrtp_demo.Scripts.Common.Events
{
    public static class EventDispatcher
    {
        public static void Publish<T>(T eventData) where T  : AbstractEvent
        {
            Debug.Log("<color=#ffa500ff>Event: </color>" + eventData.GetType() + eventData.LogInfo());
            MessageBroker.Default.Publish(eventData);
        }
        
        public static void Publish<T>(T eventData, bool silent) where T : AbstractEvent
        {
            if(silent)
                Debug.Log("<color=#ffa500ff>Event: </color>" + eventData.GetType() + eventData.LogInfo());        

            MessageBroker.Default.Publish(eventData);
        }

        public static IObservable<T> Receive<T>()
        {
            return MessageBroker.Default.Receive<T>();
        }
    }
}