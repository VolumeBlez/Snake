using UnityEngine;

public class EventAudioInvoker : IEventListener
{
    private readonly AudioClip _clip;
    private readonly IAudioPlayer _player;

    public EventType ListenEventType { get; }


    public EventAudioInvoker(EventType eventType, AudioClip clip, IAudioPlayer player)
    {
        this._player = player;
        this._clip = clip;
        this.ListenEventType = eventType;
    }

    public void EventTriggeredAction()
    {
        _player.Play(_clip);
    }


}
