using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private HealthValueBar _healthValueBar;
    [SerializeField] private SliderBar _sliderBar;
    [SerializeField] private SmoothSliderBar _smoothSliderBar;

    private void Awake()
    {
        _healthBar.Initialize();
        _healthValueBar.Initialize();
        _sliderBar.Initialize();
        _smoothSliderBar.Initialize();
    }
}
