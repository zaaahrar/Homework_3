using UnityEngine;

public class Cherry : MonoBehaviour
{
    [SerializeField] private int _addHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Player player))
        {
            player.AddHealth(_addHealth);
            Destroy(gameObject);
        }
    }
}