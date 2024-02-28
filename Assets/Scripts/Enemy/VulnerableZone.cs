using UnityEngine;

public class VulnerableZone : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _damage;

    public Enemy Enemy => _enemy;
}
