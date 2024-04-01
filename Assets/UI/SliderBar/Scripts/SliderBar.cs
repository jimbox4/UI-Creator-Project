using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _image;

    private int _maxValue;
    private int _currentValue;
    private float _maxFillValue = 1;

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
        UpdateBar();
    }

    private void UpdateBar()
    {
        _maxValue = _health.MaxHealth;
        _currentValue = _health.CurrentHealth;

        float fillPercent = _maxFillValue / _maxValue * _currentValue;

        _image.fillAmount = fillPercent;
    }
}
