using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSliderBar : Bar
{
    [SerializeField] private Image _image;
    [SerializeField, Range(0,2)] private float _speed;

    private float _fillPercent;
    private float _maxFillValue = 1;
    private int _maxValue;
    private int _currentValue;
    private Coroutine _coroutine;

    public void Initialize()
    {
        _maxValue = Health.MaxValue;
        _currentValue = Health.CurrentValue;

        _fillPercent = _maxFillValue / _maxValue * _currentValue;
        _image.fillAmount = _fillPercent;
    }

    protected override void UpdateCurrentValue()
    {
        UpdateBar();
    }

    protected override void UpdateMaxValue()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        _maxValue = Health.MaxValue;
        _currentValue = Health.CurrentValue;

        _fillPercent = _maxFillValue / _maxValue * _currentValue;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _coroutine = StartCoroutine(ChangineValue());
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
