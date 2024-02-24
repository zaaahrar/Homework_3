using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _reboundForce;

    private readonly int NumberScene = 0;
    private Rigidbody2D _rigidbody2D;

    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public float ReboundForce => _reboundForce;
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;
    public float Speed => _speed;
    public float JumpForce => _jumpForce;

    private void Awake()
    {
        _currentHealth = _maxHealth;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Border>())
        {
            transform.position = Vector3.zero;
        }
    }

    public void TakeHealth()
    {
        _currentHealth--;
    }

    public void AddHealth(int value)
    {
        _currentHealth += value;
    }

    public void CheckDie()
    {
        if(_currentHealth <= 0)
        {
            SceneManager.LoadScene(NumberScene);
        }
    }
}
