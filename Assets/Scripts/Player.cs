using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private bool _isGround;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private float _rayDistance = 1f;

    private int _isMovementHash = Animator.StringToHash("isMovement");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        CheckGround();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetBool(_isMovementHash, true);

            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            {
                Jump();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
            _animator.SetBool(_isMovementHash, true);

            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            {
                Jump();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            Jump();
        }
        else
        {
            _animator.SetBool(_isMovementHash, false);
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _rayDistance, _ground);

        _isGround = hit.collider != null ? true : false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Border>(out Border border))
        {
            transform.position = Vector3.zero;
        }
    }
}
