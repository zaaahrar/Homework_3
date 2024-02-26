using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    private const int NumberScene = 0;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public override void AddHealth(int heal)
    {
        if (CurrentHealth + heal > MaxHealth)
            CurrentHealth = MaxHealth;
        else
            CurrentHealth += heal;
    }

    public override void TakeDamage(int damage)
    {
        if (CurrentHealth - damage < 0)
        {
            CurrentHealth = 0;
            Die();
        }
        else
        {
            CurrentHealth -= damage;
        }
    }

    public override void Die()
    {
        SceneManager.LoadScene(NumberScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Cherry cherry))
        {
            CurrentHealth++;
            Destroy(cherry.gameObject);
        }
    }
}
