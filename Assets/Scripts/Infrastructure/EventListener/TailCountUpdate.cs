using UnityEngine;

public class TailCountUpdate : IEventListener
{
    private readonly Factory<GameObject> _tailFactory;
    private readonly SnakeSegmentsRepository _repository;
    private readonly Snake snake;

    public EventType ListenEventType => EventType.FoodEat;

    public TailCountUpdate(SnakeSegmentsRepository repository, Snake snake) 
    {
        _tailFactory = new Factory<GameObject>("Tail");
        this._repository = repository;
        this.snake = snake;
    }

    public void EventTriggeredAction()
    {
        GameObject segment = _tailFactory.Create();

        segment.transform.position = _repository.SegmentsPositions[_repository.SegmentsPositions.Count - 1];
        //segment.transform.SetParent(snake.transform);
        //segment.transform.position = new Vector3(100, 100, 100);
        _repository.Add(segment.transform);
    }
}
