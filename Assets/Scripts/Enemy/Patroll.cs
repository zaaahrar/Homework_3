using UnityEngine;

[RequireComponent(typeof(PlayerStalking))]
public class Patroll : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _points = new Transform[2];
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private bool _isStalking;

    private const int NumberTurn = 0;
    private const float TouchDistance = 0.2f;

    private float _rayDistance = 4;
    private int _point = 0;

    private Vector3 _turnLeft = new Vector3(-1, 1, 0);
    private Vector3 _turnRight = new Vector3(1, 1, 0);

    private PlayerStalking _playerStalking;

    public bool IsStalking => _isStalking;

    private void Awake()
    {
        _playerStalking = GetComponent<PlayerStalking>();
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
            MoveThroughPoints();
            _isStalking = false;
        }
    }

    private void MoveThroughPoints()
    {
        transform.position = Vector3.MoveTowards(transform.position, _points[_point].position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, _points[_point].position) < TouchDistance)
        {
            _point++;
            _rayDistance *= -1;

            if (_point == _points.Length)
                _point = 0;

            if (transform.position.x - _points[_point].position.x > NumberTurn)
            {
                transform.localScale = _turnRight;
            }
            else
            {
                transform.localScale = _turnLeft;
            }  
        }
    }
}
