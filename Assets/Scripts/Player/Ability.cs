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
    [SerializeField] private float _maxDistance;

    private WaitForSeconds _cooldown;
    private WaitForSeconds _second = new WaitForSeconds(1);
    private Player _player;

    private float _closestDistance = Mathf.Infinity;
    private Collider2D _closestCollider = null;

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
            Enemy enemy = SearchNearestEnemy();

            if (enemy != null)
                StartCoroutine(LifeDraining(enemy));
            else
                StartCoroutine(DelayingAbility());
        }
    }
    private Enemy SearchNearestEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius, _enemyMask);

        if (colliders != null)
        {
            foreach (Collider2D collider in colliders)
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);

                if (distance < _closestDistance)
                {
                    _closestDistance = distance;
                    _closestCollider = collider;
                }
            }

            return _closestCollider.GetComponent<Enemy>();
        }

        return null;
    }

    private bool CheckDistance(Enemy enemy)
    {
        if (enemy == null)
            return false;

        float distance = Vector3.Distance(transform.position, enemy.transform.position);

        if (distance > _maxDistance)
        {
            return false;
        }

        return true;
    }

    private IEnumerator LifeDraining(Enemy enemy)
    {
        for (int i = 0; i < _duration; i++)
        {
            bool isIncludedRadius = CheckDistance(enemy);

            if (isIncludedRadius && enemy.Health.CurrentHealth > 0)
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
