using System.Collections.Generic;

public class SnakeEventDispatcher
{
    private readonly List<IEventListener> _listeners = new();

    public void Register(IEventListener newListener)
    {
        if(newListener == null) return;
        if(_listeners.Contains(newListener)) return;

        _listeners.Add(newListener);
    }


    public void Dispatch(EventType @event) 
    {
        foreach (IEventListener listener in _listeners)
        {
            if(listener.ListenEventType == @event)
                listener.EventTriggeredAction();
        }
    }
}
