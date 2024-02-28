using UnityEngine;

public class PlayerTriggerChecking : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Cherry cherry))
        {
            collision.enabled = false;
            _player.Health.AddHealth(cherry.Heal);
            Destroy(cherry.gameObject);
        }

        if (collision.TryGetComponent(out Crystal crystal))
        {
            collision.enabled = false;
            crystal.Collect();
            Destroy(crystal.gameObject, crystal.AnimationTime);
        }

        if (collision.TryGetComponent(out Border _))
        {
            transform.position = Vector3.zero;
        }
    }
}
