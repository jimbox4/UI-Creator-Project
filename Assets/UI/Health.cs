using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [Header("Input values")]
    [SerializeField] private int _damage;
    [SerializeField] private int _heal;
    [SerializeField] private int _limitIncrease;
    [SerializeField] private int _limitDecrease;

    public event Action Increased;
    public event Action Decreased;
    public event Action MaxValueChanged;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;

    public void IncreaseValue()
    {
        _currentHealth = Mathf.Clamp(_currentHealth + _heal, 0, _maxHealth);
        Increased?.Invoke();
    }

    public void DecreaseValue() 
    {
        _currentHealth = Mathf.Clamp(_currentHealth - _damage, 0, _maxHealth);
        Decreased?.Invoke();
    }

    public void IncreaseMaxValue()
    {
        _maxHealth += _limitIncrease;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        MaxValueChanged?.Invoke();
    }

    public void DecreaseMaxValue()
    {
        _maxHealth -= _limitDecrease;

        if (_maxHealth < 0)
        {
            _maxHealth = 0;
        }

        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        MaxValueChanged?.Invoke();
    }
}
