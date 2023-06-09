
using System.Collections.Generic;
using UnityEngine;

public class SegmentsMovement : MonoBehaviour, IEventListener
{
    private List<Transform> _segments = new();
    private List<Vector2> _segmentsPositions = new();
    
    private Snake _snake;
    private float _diameter = 1f;

    public EventType ListenEventType => EventType.SnakeDeath;

    public void EventTriggeredAction()
    {
        Destroy(gameObject);
    }

    public void Init(SnakeSegmentsRepository repository, Snake snake)
    {
        _segments = repository.SnakeSegments;
        _segmentsPositions = repository.SegmentsPositions;
        this._snake = snake;
    }

    
    void FixedUpdate()
    {
        float distance = new Vector2(_snake.transform.position.x - _segmentsPositions[0].x, _snake.transform.position.y - _segmentsPositions[0].y ).magnitude;
        if(distance > _diameter)
        {
            Vector2 direction = new Vector2(_snake.transform.position.x - _segmentsPositions[0].x, _snake.transform.position.y - _segmentsPositions[0].y).normalized;
            _segmentsPositions.Insert(0, _segmentsPositions[0] + direction * _diameter);
            _segmentsPositions.RemoveAt(_segmentsPositions.Count - 1);

            distance -= _diameter;
        }

        for (int i = 0; i < _segments.Count; i++)
        {
            _segments[i].position = Vector2.Lerp(_segmentsPositions[i+1], _segmentsPositions[i], distance / _diameter);
        }
    }


}
