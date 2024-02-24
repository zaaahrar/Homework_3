using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Crystal : MonoBehaviour
{
    private readonly float AnimationTime = 0.3f;
    private readonly int IsCollectHash = Animator.StringToHash("isCollect");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
             Collect();
    }

    public void Collect()
    {
        _animator.SetTrigger(IsCollectHash);
        Destroy(gameObject, AnimationTime);
    }
}
