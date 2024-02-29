using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Ability _ability;

    private const string AxisHorizontal = "Horizontal";

    private float _horizontalDirection;

    public float HorizontalDirection => _horizontalDirection;

    private void Update()
    {
        _horizontalDirection = Input.GetAxisRaw(AxisHorizontal);

        if (Input.GetKeyDown(KeyCode.F))
            _ability.Use();

        if (Input.GetKeyDown(KeyCode.Space))
            _playerMovement.TryJump();        
    }
}
