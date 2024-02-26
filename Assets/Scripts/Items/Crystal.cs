using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Crystal : MonoBehaviour
{
    private const float AnimationTime = 0.3f;

    private int _isCollectHash = Animator.StringToHash("isCollect");
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Collect()
    {
        _animator.SetTrigger(_isCollectHash);
        Destroy(this);
        Destroy(gameObject, AnimationTime);
    }
}
