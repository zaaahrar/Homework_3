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
    private Enemy _enemy;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _cooldown = new WaitForSeconds(_cooldownTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canConjure)
        {
            _canConjure = false;
            Collider2D collider = Physics2D.OverlapCircle(transform.position, _radius, _enemyMask);

            if (collider != null)
            {
                _enemy = collider.GetComponent<Enemy>();
                StartCoroutine(LifeDrain(_enemy));
            }
            else
            {
                StartCoroutine(DelayingAbility());
            }
        }
    }

    private IEnumerator LifeDrain(Enemy enemy)
    {
        for (int i = 0; i < _duration; i++)
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, _radius, _enemyMask);

            if (collider != null)
            {
                _player.Health.AddHealth(_damageInSecond);
                enemy.Health.TakeDamage(_damageInSecond);
            }
            else
            {
                i = _duration;
            }

            yield return _second;
        }

        _canConjure = false;
        StartCoroutine(DelayingAbility());
    }

    private IEnumerator DelayingAbility()
    {
        yield return _cooldown;
        _canConjure = true;
    }
}
