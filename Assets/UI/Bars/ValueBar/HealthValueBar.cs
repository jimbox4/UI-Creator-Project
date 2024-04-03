using TMPro;
using UnityEngine;

public class HealthValueBar : Bar
{
    [SerializeField] private TMP_Text _textCurrentValue;
    [SerializeField] private TMP_Text _textMaxValue;

    public void Initialize()
    {
        UpdateMaxValue();
        UpdateCurrentValue();
    }

    protected override void UpdateCurrentValue()
    {
        _textCurrentValue.text = Health.CurrentValue.ToString();
    }

    protected override void UpdateMaxValue()
    {
        _textMaxValue.text = Health.MaxValue.ToString();
    }
}
