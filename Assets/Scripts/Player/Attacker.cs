using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private int _colldownTime;
    [SerializeField] private bool _canAttack = true;

    private WaitForSeconds _colldown;

    private void Start()
    {
        _colldown = new WaitForSeconds(_colldownTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out VulnerableZone vulnerableZone))
        {
            if (_canAttack)
            {
                vulnerableZone.Enemy.Health.TakeDamage(_damage);
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
