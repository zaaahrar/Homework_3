using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private Health _health;

    public Health Health => _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.IsDead += Die;
    }

    private void OnDisable()
    {
        _health.IsDead -= Die;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
