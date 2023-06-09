public interface IEventListener
{
    public EventType ListenEventType { get; }

    public void EventTriggeredAction();
}
