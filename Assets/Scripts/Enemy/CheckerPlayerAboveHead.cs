using UnityEngine;

public class CheckerPlayerAboveHead : MonoBehaviour
{
    [SerializeField] private Enemy enemy;

    public void EnemyDied()
    {
        Destroy(enemy.gameObject);
    }
}
