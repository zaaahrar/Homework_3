using UnityEngine;

public class VulnerableZone : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    public void EnemyDied()
    {
        Destroy(enemy.gameObject);
    }
}
