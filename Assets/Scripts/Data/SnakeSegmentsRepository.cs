using System.Collections.Generic;
using UnityEngine;

public class SnakeSegmentsRepository
{
    private readonly List<Transform> _snakeSegments = new();
    private readonly List<Vector2> _segmentsPositions = new();

    public List<Transform> SnakeSegments => _snakeSegments;
    public List<Vector2> SegmentsPositions => _segmentsPositions; 

    public void Init(Transform snake) 
    {
        _segmentsPositions.Add(snake.position);
    }

    public void Add(Transform newSegment)
    {
        _snakeSegments.Add(newSegment);
        _segmentsPositions.Add(newSegment.position);
    }

    
}
