using UnityEngine;

[RequireComponent(typeof(Patrolling))]
public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private bool _isAttack = false;
    [SerializeField] private float _colldown = 2;

    private Patrolling _patrolling;
    private float _time;

    private void Awake()
    {
        _patrolling = GetComponent<Patrolling>();
    }

    private void Update()
    {
        if(_time < _colldown)
        {
            _time += Time.deltaTime;
        }
        else
        {
            _isAttack = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Player player))
        {
            if (_isAttack)
            {
                int turnRight = 1;
                int turnLeft = -1;

                player.TakeHealth();
                player.CheckDie();

                if (_patrolling.CurrentTurn.x == turnRight)
                {
                    player.Rigidbody2D.AddForce(Vector2.left * player.ReboundForce, ForceMode2D.Impulse);
                    player.Rigidbody2D.AddForce(Vector2.up * player.ReboundForce, ForceMode2D.Impulse);
                }
                else if (_patrolling.CurrentTurn.x == turnLeft)
                {
                    player.Rigidbody2D.AddForce(Vector2.right * player.ReboundForce, ForceMode2D.Impulse);
                    player.Rigidbody2D.AddForce(Vector2.up * player.ReboundForce, ForceMode2D.Impulse);
                }

                _isAttack = false;
                _time = 0;
            }   
        }
    }
}
