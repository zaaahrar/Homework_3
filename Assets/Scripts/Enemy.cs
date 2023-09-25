using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points = new Transform[2];

    private int _point;
    private int _startPoint = 0;
    private int _endPoint = 1;
    private float _interval = 0.2f;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _point = _startPoint;
        _spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_point].position, _speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, _points[_point].position) < _interval)
        {
            if (_point == _startPoint)
            {
                _spriteRenderer.flipX = false;
                _point = _endPoint;
            }
            else
            {
                _spriteRenderer.flipX = true;
                _point = _startPoint;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.transform.position = Vector3.zero;
        }
    }
}
