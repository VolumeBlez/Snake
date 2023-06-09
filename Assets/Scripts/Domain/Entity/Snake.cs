using UnityEngine;

public class Snake : MonoBehaviour, IUnit
{
    [SerializeField] private SnakeMovement _movement;

    public SnakeMovement Movement => _movement;

    public void DestroyUnit()
    {
        Destroy(gameObject);
    }

}
