using System.Collections.Generic;
using UnityEngine;

public class UserInputService : MonoBehaviour, IEventListener
{
    private List<IMovable> _movableList = new();
    private Input _input;

    public Input Input 
    {
        get 
        {
            if(_input != null) return _input;
            return _input = new Input();
        }
    }

    public EventType ListenEventType => EventType.SnakeDeath;

    public void InitInput()
    {
        Input.Enable();

        Input.GamePlay.Move.performed += ctx => _movableList.ForEach(x => x.SetMoveDirection(ctx.ReadValue<Vector2>()));
        //Input.GamePlay.Move.performed += ctx => _movableList.ForEach(x => x.SetMoveDirection(ctx.ReadValue<>()))
    }


    private void OnDisable()
    {
        Input.Disable();
    }
    
    public void RegisterMovableListener(IMovable movable)
    {
        if(_movableList.Contains(movable)) return;

        _movableList.Add(movable);
    }

    public void EventTriggeredAction()
    {
        Input.Disable();
    }
}
