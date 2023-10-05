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
    private float _animationTime = 0.3f;
    private int _isCollectHash = Animator.StringToHash("isCollect");

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
        _animator.SetTrigger(_isCollectHash);
        Destroy(gameObject, _animationTime);
    }
}
