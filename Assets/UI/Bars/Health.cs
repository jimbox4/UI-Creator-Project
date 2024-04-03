using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _currentValue;
    [Header("Input values")]
    [SerializeField] private int _damage;
    [SerializeField] private int _heal;
    [SerializeField] private int _limitIncrease;
    [SerializeField] private int _limitDecrease;

    public event Action MaxValueChanged;
    public event Action CurrentValueChanged;

    public int CurrentValue => _currentValue;
    public int MaxValue => _maxValue;

    public void IncreaseValue()
    {
        _currentValue = Mathf.Clamp(_currentValue + _heal, 0, _maxValue);
        CurrentValueChanged?.Invoke();
    }

    public void DecreaseValue() 
    {
        _currentValue = Mathf.Clamp(_currentValue - _damage, 0, _maxValue);
        CurrentValueChanged?.Invoke();
    }

    public void IncreaseMaxValue()
    {
        _maxValue += _limitIncrease;
        MaxValueChanged?.Invoke();
    }

    public void DecreaseMaxValue()
    {
        _maxValue -= _limitDecrease;

        if (_maxValue < 0)
        {
            _maxValue = 0;
        }

        _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);
        MaxValueChanged?.Invoke();
    }
}
