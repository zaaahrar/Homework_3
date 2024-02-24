using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CheckerPlayerAboveHead checker))
        {
            checker.EnemyDied();
        }
    }
}
