using UnityEngine;

[RequireComponent(typeof(PlayerStalking))]
[RequireComponent(typeof(Enemy))]
public class Patrolling : MonoBehaviour
{
    [SerializeField] private Transform[] _points = new Transform[2];
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] protected bool _isStalking;

    private readonly int StartPoint = 0;
    private readonly int EndPoint = 1;
    private readonly float Interval = 0.2f;

    private float _rayDistance = 4;
    private int _point;

    private Vector3 _turnLeft = new Vector3(-1, 1, 0);
    private Vector3 _turnRight = new Vector3(1, 1, 0);
    private Vector3 _currentTurn;

    private PlayerStalking _playerStalking;
    private Enemy _enemy;

    public Vector3 CurrentTurn => _currentTurn;

    private void Awake()
    {
        _point = StartPoint;
        _playerStalking = GetComponent<PlayerStalking>();
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right, _rayDistance, _playerMask);

        if (hit.collider != null)
        {
            _playerStalking.CanFollow(hit.collider);
            _isStalking = true;
        }
        else
        {
            _isStalking = false;
        }

        if (!_isStalking)
        {
            transform.position = Vector3.MoveTowards(transform.position, _points[_point].position, _enemy.Speed * Time.deltaTime);
            CheckDistanceToPoint();          
        }
    }

    private void CheckDistanceToPoint()
    {
        if (Vector2.Distance(transform.position, _points[_point].position) < Interval)
        {
            if (_point == StartPoint)
            {
                transform.localScale = _turnRight;
                _currentTurn = _turnRight;
                _point = EndPoint;
            }
            else
            {
                transform.localScale = _turnLeft;
                _currentTurn = _turnLeft;
                _point = StartPoint;
            }

            _rayDistance *= -1;
        }
    }
}
