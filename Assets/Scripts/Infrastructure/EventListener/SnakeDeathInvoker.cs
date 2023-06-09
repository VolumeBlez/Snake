using System;
using UnityEngine;

public class SnakeDeathInvoker : IEventListener
{
    private readonly IUnit _unitToDestroy;
    private readonly GameObject _reloadButtonObject;

    public SnakeDeathInvoker(IUnit unitToDestroy, GameObject reloadButtonObject)
    {
        ListenEventType = EventType.SnakeDeath;
        this._unitToDestroy = unitToDestroy;
        this._reloadButtonObject = reloadButtonObject;
    }

    public EventType ListenEventType { get; }

    public void EventTriggeredAction()
    {
        _unitToDestroy.DestroyUnit(); // можно раскинуть это по разным файлам но мне лень
        _reloadButtonObject.SetActive(true);
    }
}
