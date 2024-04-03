using UnityEngine;

public abstract class Bar : MonoBehaviour
{
    [field:SerializeField] protected Health Health { private set; get; }

    private void OnEnable()
    {
        Health.CurrentValueChanged += UpdateCurrentValue;
        Health.MaxValueChanged += UpdateMaxValue;
    }

    private void OnDisable()
    {
        Health.CurrentValueChanged -= UpdateCurrentValue;
        Health.MaxValueChanged -= UpdateMaxValue;
    }

    protected abstract void UpdateMaxValue();
    protected abstract void UpdateCurrentValue();
}
