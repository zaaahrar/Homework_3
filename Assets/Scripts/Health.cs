using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public event Action IsDead;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if (CurrentHealth == 0)
            IsDead?.Invoke();
    }

    public void AddHealth(int heal)
    {
        _currentHealth += heal;
        _currentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
    }
}
