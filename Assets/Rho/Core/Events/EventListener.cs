using UnityEngine;
using UnityEngine.Events;

namespace rho
{
    public class EventListener : MonoBehaviour
    {
        public Event Event;
        public UnityEvent<object[]> Response;

        void OnEnable()
        {
            Event.Register(this);
        }

        void OnDisable()
        {
            Event.Unregister(this);
        }

        public void OnEventRaised(params object[] args)
        {
            Response.Invoke(args);
        }
    }
}