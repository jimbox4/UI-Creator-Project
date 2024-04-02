using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Increased += IncreaseValues;
        Health.Decreased += DecreaseValues;
        Health.MaxValueChanged += UpdateMaxValue;
    }

    private void OnDisable()
    {
        Health.Increased -= IncreaseValues;
        Health.Decreased -= DecreaseValues;
        Health.MaxValueChanged -= UpdateMaxValue;
    }

    protected abstract void IncreaseValues();
    protected abstract void DecreaseValues();
    protected abstract void UpdateMaxValue();
}
