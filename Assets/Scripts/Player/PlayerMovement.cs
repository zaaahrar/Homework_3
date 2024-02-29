using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private LayerMask _ground;
    [SerializeField] private bool _isGround;
    [SerializeField] private PlayerInput _playerInput;

    private const float RayDistance = 1;

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
        CheckGround();
        MoveHorizontally(_playerInput.HorizontalDirection);
    }

    public void TryJump()
    {
        if(_isGround)
            _player.Rigidbody2D.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
    }

    public void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_player.Rigidbody2D.position, Vector2.down, RayDistance, _ground);
        _isGround = hit.collider != null;
    }

    public void MoveHorizontally(float horizontalDirection)
    {
        _animator.SetBool(IsMovementHash, true);

        if (horizontalDirection > 0)
            transform.localScale = _turnRight;
        else if(horizontalDirection < 0)
            transform.localScale = _turnLeft;
        else
            _animator.SetBool(IsMovementHash, false);

        transform.Translate(_speed * horizontalDirection * Time.deltaTime, 0, 0);
    }
}
