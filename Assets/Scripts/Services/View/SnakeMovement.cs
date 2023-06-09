using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SnakeMovement : MonoBehaviour, IMovable
{

    private Rigidbody2D _rb;
    private float _moveSpeed;

    private Vector3 _movement;

    public void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        _movement = Vector3.up;
    }

    public void SetNewMoveSpeed(float moveSpeed)
    {
        _moveSpeed = moveSpeed;        
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SetMoveDirection(Vector2 direction)
    {
        if (_movement.x + direction.x == 0) return;
        if (_movement.y + direction.y == 0) return;

        _movement = direction;

        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(n < 0) n += 360;
        _rb.transform.eulerAngles = new Vector3(0, 0, n - 90f);
    }

    private void Move()
    {
        _rb.MovePosition(transform.position + _movement * _moveSpeed * Time.deltaTime);
    }

}
