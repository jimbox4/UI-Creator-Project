using UnityEngine;
using UnityEngine.UI;

public class SliderBar : Bar
{
    [SerializeField] private Image _image;

    private int _maxValue;
    private int _currentValue;
    private float _maxFillValue = 1;

    public void Initialize()
    {
        UpdateBar();
    }

    protected override void DecreaseValues()
    {
        UpdateBar();
    }

    protected override void IncreaseValues()
    {
        UpdateBar();
    }

    protected override void UpdateMaxValue()
    {
        UpdateBar();
    }

    private void UpdateBar()
    {
        _maxValue = Health.MaxHealth;
        _currentValue = Health.CurrentHealth;

        float fillPercent = _maxFillValue / _maxValue * _currentValue;

        _image.fillAmount = fillPercent;
    }
}
