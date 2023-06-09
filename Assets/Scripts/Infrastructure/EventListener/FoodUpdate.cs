
using UnityEngine;

public class FoodUpdate : IEventListener
{
    private readonly LevelDataRepository _repository;
    private Factory<GameObject> _foorFactory;

    public EventType ListenEventType => EventType.FoodEat;

    public FoodUpdate(LevelDataRepository repository)
    {
        this._repository = repository;
        _foorFactory = new Factory<GameObject>("Food");
    }

    public void EventTriggeredAction()
    {
        GameObject newFood = _foorFactory.Create();
        newFood.transform.position = new Vector2(
            Random.Range(_repository.MinPositionForSpawnFood.x, _repository.MaxPositionForSpawnFood.x),
            Random.Range(_repository.MinPositionForSpawnFood.y, _repository.MaxPositionForSpawnFood.y)
        );
    }


}
