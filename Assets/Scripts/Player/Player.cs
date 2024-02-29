using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private LoadScenes _loadScenes;

    private Rigidbody2D _rigidbody2D;
    private Health _health;
    private int _startScene = 0;

    public Health Health => _health;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.Die += Die;
    }

    private void OnDisable()
    {
        _health.Die -= Die;
    }

    public void Bounce(Vector2 direction)
    {
        _rigidbody2D.AddForce(direction, ForceMode2D.Impulse);
    }

    private void Die()
    {
        _loadScenes.LoadScene(_startScene);
    }
}
