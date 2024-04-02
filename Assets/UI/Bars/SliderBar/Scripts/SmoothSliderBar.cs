using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _image;
    [SerializeField, Range(0,2)] private float _speed;

    private float _fillPercent;
    private int _maxValue;
    private int _currentValue;
    private float _maxFillValue = 1;
    private Coroutine coroutine;

    private void OnEnable()
    {
        _health.Decreased += UpdateBar;
        _health.Increased += UpdateBar;
        _health.MaxValueChanged += UpdateBar;
    }

    private void OnDisable()
    {
        _health.Decreased -= UpdateBar;
        _health.Increased -= UpdateBar;
        _health.MaxValueChanged -= UpdateBar;
    }

    public void Initialize()
    {
        _maxValue = _health.MaxHealth;
        _currentValue = _health.CurrentHealth;

        _fillPercent = _maxFillValue / _maxValue * _currentValue;
        _image.fillAmount = _fillPercent;
    }

    private void UpdateBar()
    {
        _maxValue = _health.MaxHealth;
        _currentValue = _health.CurrentHealth;

        _fillPercent = _maxFillValue / _maxValue * _currentValue;

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        
        coroutine = StartCoroutine(ChangineValue());
    }

    private IEnumerator ChangineValue()
    {
        while (_currentValue != _image.fillAmount)
        {
            _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, _fillPercent, Time.deltaTime * _speed);

            yield return null;
        }
    }
}
