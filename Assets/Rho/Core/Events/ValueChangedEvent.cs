namespace rho
{
    /// <summary>
    /// Generic Value changed event
    /// </summary>
    public class ValueChangedEvent<T> : IGameEvent
    {
        public T oldValue;
        public T newValue;
    }
}