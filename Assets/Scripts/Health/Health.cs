using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _currentHealth;

    public event Action Die;
    public event Action<float> DisplayHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        DisplayHealth?.Invoke(_currentHealth);

        if (CurrentHealth == 0)
            Die?.Invoke();
    }

    public void AddHealth(float heal)
    {
        _currentHealth += heal;
        _currentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);
        DisplayHealth?.Invoke(_currentHealth);
    }
}
