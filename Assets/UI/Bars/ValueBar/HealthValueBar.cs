using TMPro;
using UnityEngine;

public class HealthValueBar : Bar
{
    [SerializeField] private TMP_Text _textCurrentValue;
    [SerializeField] private TMP_Text _textMaxValue;

    private int _maxValue;
    private int _currentValue;

    public void Initialize()
    {
        _currentValue = Health.CurrentHealth;
        _maxValue = Health.MaxHealth;

        UpdateValues();
    }

    protected override void DecreaseValues()
    {
        UpdateValues();
    }

    protected override void IncreaseValues()
    {
        UpdateValues();
    }

    protected override void UpdateMaxValue()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        _maxValue = Health.MaxHealth;
        _currentValue = Health.CurrentHealth;

        _textCurrentValue.text = _currentValue.ToString();
        _textMaxValue.text = _maxValue.ToString();
    }
}
