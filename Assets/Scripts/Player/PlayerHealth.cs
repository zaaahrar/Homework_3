using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    private const int NumberScene = 0;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public override void Die()
    {
        SceneManager.LoadScene(NumberScene);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Cherry cherry))
        {
            AddHealth(cherry.Heal);
            Destroy(cherry.gameObject);
        }
    }
}
