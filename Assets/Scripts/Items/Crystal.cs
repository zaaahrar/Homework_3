using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Crystal : MonoBehaviour
{
    private float _animationTime = 0.3f;
    private int _isCollectHash = Animator.StringToHash("isCollect");
    private Animator _animator;
    private bool _isCollect = false;

    public bool IsCollect => _isCollect;
    public float AnimationTime => _animationTime;

    private void Awake() => _animator = GetComponent<Animator>();

    public void Collect()
    {
        _animator.SetTrigger(_isCollectHash);
        _isCollect = true;
    }
}
