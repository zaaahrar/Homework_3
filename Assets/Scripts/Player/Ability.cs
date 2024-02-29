using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class Ability : MonoBehaviour
{
    [SerializeField] private int _damageInSecond;
    [SerializeField] private int _cooldownTime;
    [SerializeField] private int _duration;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private bool _canConjure = true;
    [SerializeField] private float _radius;

    private WaitForSeconds _cooldown;
    private WaitForSeconds _second = new WaitForSeconds(1);
    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _cooldown = new WaitForSeconds(_cooldownTime);
    }

    public void Use()
    {
        if (_canConjure)
        {
            _canConjure = false;
            Enemy enemy = SearchEnemy();

            if (enemy != null)
            {
                StartCoroutine(LifeDraining(enemy));
            }
            else
            {
                StartCoroutine(DelayingAbility());
            }
        }
    }

    private Enemy SearchEnemy()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _radius, _enemyMask);

        if (collider != null)
        {
            Debug.Log(collider.name);
            return collider.GetComponent<Enemy>();
        }

        return null;
    }

    private IEnumerator LifeDraining(Enemy enemy)
    {
        for (int i = 0; i < _duration; i++)
        {
            Enemy enemyChecker = SearchEnemy();

            if (enemyChecker != null && enemyChecker == enemy && enemy.Health.CurrentHealth > 0)
            {
                if (enemy.Health.CurrentHealth < _damageInSecond)
                {
                    _player.Health.AddHealth(enemy.Health.CurrentHealth);
                    enemy.Health.TakeDamage(enemy.Health.CurrentHealth);
                }
                else
                {
                    _player.Health.AddHealth(_damageInSecond);
                    enemy.Health.TakeDamage(_damageInSecond);
                }
            }
            else
            {
                break;
            }

            yield return _second;
        }

        StartCoroutine(DelayingAbility());
    }

    private IEnumerator DelayingAbility()
    {
        yield return _cooldown;
        _canConjure = true;
    }
}
