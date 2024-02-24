using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedStalking;

    public float SpeedStalking => _speedStalking;
    public float Speed => _speed; 
}
