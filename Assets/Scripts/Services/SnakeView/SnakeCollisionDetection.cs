
using UnityEngine;

public class SnakeCollisionDetection : MonoBehaviour
{
    private SnakeEventDispatcher _dispatcher;

    public void Init(SnakeEventDispatcher dispatcher)
    {
        this._dispatcher = dispatcher;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out IEatable food)) 
        {
            food.Eat();
            _dispatcher.Dispatch(EventType.FoodEat);
        }
        else
        {
            _dispatcher.Dispatch(EventType.SnakeDeath);
        }
    }
}
