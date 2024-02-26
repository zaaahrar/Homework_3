using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float CurrentHealth;

    public abstract void TakeDamage(int damage);

    public abstract void AddHealth(int heal);

    public abstract void Die();
}
