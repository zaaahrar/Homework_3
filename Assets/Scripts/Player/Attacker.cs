using UnityEngine;

public class Attacker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out VulnerableZone checker))
        {
            checker.EnemyDied();
        }
    }
}
