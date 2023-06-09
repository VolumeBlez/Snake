using System;
using UnityEngine;

public class ScoreUpdate : IEventListener
{
    private int _currentScore = 0;

    public Action<int> ChangedCurrentScore;
    
    public ScoreUpdate()
    {
        ListenEventType = EventType.FoodEat;
    }
    public EventType ListenEventType { get; }
    
    public void EventTriggeredAction()
    {
        Debug.Log("SCORE UPDATE");
        _currentScore++;
        ChangedCurrentScore?.Invoke(_currentScore);
    }
}
