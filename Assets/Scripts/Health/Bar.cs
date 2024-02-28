using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Health _health;

    private void Start()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.MaxHealth;
    }

    private void OnEnable()
    {
        _health.DisplayHealth += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.DisplayHealth -= OnHealthChanged;
    }

    public abstract void OnHealthChanged(float newHealth);
}
