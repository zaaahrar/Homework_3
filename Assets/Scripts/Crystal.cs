using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Crystal : MonoBehaviour
{
    [SerializeField] private UnityEvent _collect;
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _collect?.Invoke();
        }
    }

    public void Collect()
    {
        _animator.SetTrigger("isCollect");
        Destroy(gameObject, 0.3f);
    }
}
