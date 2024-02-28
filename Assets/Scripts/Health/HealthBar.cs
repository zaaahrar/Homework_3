using System.Collections;
using UnityEngine;

public class HealthBar : Bar
{
    private const float MaxDelta = 3;
    private Coroutine _currentCoroutine;

    public override void OnHealthChanged(float newHealth)
    {
        if(_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeHealthAndText(newHealth));
    }

    private IEnumerator ChangeHealthAndText(float targetHealth)
    {
        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, MaxDelta * Time.deltaTime);
            yield return null;
        }
    }
}
