using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Patroll))]
public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private float _reboundForce;
    [SerializeField] private int _damage;
    [SerializeField] private bool _canAttack;
    [SerializeField] private WaitForSeconds _colldown = new WaitForSeconds(2);

    private const int _firstContact = 0;

    private Vector2 _reboundRight;
    private Vector2 _reboundLeft;

    private Patroll _patrolling;
  
    private void Awake()
    {
        _patrolling = GetComponent<Patroll>();
        _canAttack = true;

        _reboundRight = (Vector2.right + Vector2.up) * _reboundForce;
        _reboundLeft = (Vector2.left + Vector2.up) * _reboundForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            if (_canAttack && _patrolling.IsStalking)
            {
                Vector2 hitDirection = collision.contacts[_firstContact].normal;

                player.Health.TakeDamage(_damage);

                if (hitDirection.x > 0)
                    player.Bounce(_reboundLeft);
                if (hitDirection.x < 0)
                    player.Bounce(_reboundRight);

                _canAttack = false;
                StartCoroutine(DelayFiring());
            }   
        }
    }

    private IEnumerator DelayFiring()
    {
        yield return _colldown;
        _canAttack = true;
    }
}
