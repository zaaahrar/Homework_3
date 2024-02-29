using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Ability _ability;

    private void Update()
    {
        _playerMovement.MoveHorizontally();

        if (Input.GetKeyDown(KeyCode.F))
            _ability.Use();

        if (Input.GetKeyDown(KeyCode.Space))
            _playerMovement.TryJump();        
    }
}
