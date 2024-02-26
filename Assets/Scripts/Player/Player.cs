using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _reboundForce;

    private Rigidbody2D _rigidbody2D;
    private PlayerHealth _health;

    public PlayerHealth Health => _health;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public float ReboundForce => _reboundForce;
    public float Speed => _speed;
    public float JumpForce => _jumpForce;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _health = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Border>())
        {
            transform.position = Vector3.zero;
        }
    }

    public void Bounce(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Crystal crystal))
            crystal.Collect();
    }
}
