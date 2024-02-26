using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Patroll))]
public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private bool _canAttack;
    [SerializeField] private WaitForSeconds _colldown = new WaitForSeconds(2);

    private const int rightTurnNumber = 1;
    private const int leftTurnNumber = -1;

    private Patroll _patrolling;
  
    private void Awake()
    {
        _patrolling = GetComponent<Patroll>();
        _canAttack = true;
    }

    private IEnumerator DelayFiring()
    {
        yield return _colldown;
        _canAttack = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            if (_canAttack && _patrolling.IsStalking)
            {
                Vector2 reboundRight = (Vector2.right  + Vector2.up) * player.ReboundForce;
                Vector2 reboundLeft = (Vector2.left + Vector2.up) * player.ReboundForce;

                player.Health.TakeDamage(_damage);    

                if (_patrolling.CurrentTurn.x == rightTurnNumber)
                {
                    player.Bounce(reboundLeft);
                }

                else if (_patrolling.CurrentTurn.x == leftTurnNumber)
                    player.Bounce(reboundRight);

                _canAttack = false;
                StartCoroutine(DelayFiring());
            }   
        }
    }
}
