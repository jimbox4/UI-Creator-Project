using TMPro;
using UnityEngine;

public class HealthValueBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _textCurrentValue;
    [SerializeField] private TMP_Text _textMaxValue;

    private int _maxValue;
    private int _currentValue;

    private void OnEnable()
    {
        _health.Decreased += UpdateValues;
        _health.Increased += UpdateValues;
        _health.MaxValueChanged += UpdateValues;
    }

    private void OnDestroy()
    {
        _health.Decreased -= UpdateValues;
        _health.Increased -= UpdateValues;
        _health.MaxValueChanged -= UpdateValues;
    }

    public void Initialize()
    {
        _currentValue = _health.CurrentHealth;
        _maxValue = _health.MaxHealth;

        UpdateValues();
    }

    [ContextMenu(nameof(UpdateValues))]
    public void UpdateValues()
    {
        _maxValue = _health.MaxHealth;
        _currentValue = _health.CurrentHealth;

        _textCurrentValue.text = _currentValue.ToString();
        _textMaxValue.text = _maxValue.ToString();
    }
}
