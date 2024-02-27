using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class PlayerStalking : MonoBehaviour
{
    [SerializeField] private float _speedStalking;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void CanFollow(Collider2D collider)
    {
        transform.position = Vector3.MoveTowards(transform.position, collider.transform.position, _speedStalking * Time.deltaTime);
    }
}