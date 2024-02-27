using UnityEngine;

public class PlayerTriggerChecking : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Cherry cherry))
        {
            collision.GetComponent<Collider2D>().enabled = false;
            _player.Health.AddHealth(cherry.Heal);
            Destroy(cherry.gameObject);
        }

        if (collision.TryGetComponent(out Crystal crystal))
        {
            collision.GetComponent<Collider2D>().enabled = false;
            crystal.Collect();
            Destroy(crystal.gameObject, crystal.AnimationTime);
        }

        if (collision.TryGetComponent(out Border _))
        {
            transform.position = Vector3.zero;
        }
    }
}
