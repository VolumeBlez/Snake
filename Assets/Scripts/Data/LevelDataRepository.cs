using UnityEngine;

[CreateAssetMenu(fileName = "Level Data")]
public class LevelDataRepository : ScriptableObject
{
    [SerializeField] private Vector2 _maxPositionForSpawnFood;
    [SerializeField] private Vector2 _minPositionForSpawnFood;

    [SerializeField] private float _startSnakeSpeed;

    public Vector2 MaxPositionForSpawnFood => _maxPositionForSpawnFood;
    public Vector2 MinPositionForSpawnFood => _minPositionForSpawnFood;

    public float StartSnakeSpeed => _startSnakeSpeed; 
}
