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

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private bool _isGround;
    private float _rayDistance = 1f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
        CheckGround();
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _animator.SetBool("isMovement", true);

            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            {
                Jump();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _spriteRenderer.flipX = true;
            transform.Translate(-_speed * Time.deltaTime, 0, 0);
            _animator.SetBool("isMovement", true);

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
            _animator.SetBool("isMovement", false);
        }
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rigidbody2D.position, Vector2.down, _rayDistance, _ground);

        if(hit.collider != null)
        {
            _isGround = true;
        }
        else
        {
            _isGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Border"))
        {
            transform.position = Vector3.zero;
        }
    }
}
