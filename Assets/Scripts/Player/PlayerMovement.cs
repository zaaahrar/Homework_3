using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _ground;
    [SerializeField] private bool _isGround;

    private readonly float RayDistance = 1;

    private Animator _animator;
    private Player _player; 
    private Vector3 _turnLeft = new Vector3(-1, 1, 0);
    private Vector3 _turnRight = new Vector3(1, 1, 0);

    private readonly int IsMovementHash = Animator.StringToHash("isMovement");

    private void Awake()
    {
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
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
            transform.localScale = _turnRight;
            transform.Translate(_player.Speed * Time.deltaTime, 0, 0);
            _animator.SetBool(IsMovementHash, true);

            if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            {
                Jump();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = _turnLeft;
            transform.Translate(-_player.Speed * Time.deltaTime, 0, 0);
            _animator.SetBool(IsMovementHash, true);

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
            _animator.SetBool(IsMovementHash, false);
        }
    }

    private void Jump()
    {
        _player.Rigidbody2D.AddForce(new Vector2(0, _player.JumpForce), ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_player.Rigidbody2D.position, Vector2.down, RayDistance, _ground);

        _isGround = hit.collider != null;
    }
}
