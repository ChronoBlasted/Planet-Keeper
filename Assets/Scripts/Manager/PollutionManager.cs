using UnityEngine;
using UnityEngine.Events;

public class PollutionManager : CurrencyManager
{
    private static PollutionManager instance = null;
    public static PollutionManager Instance => instance;


    [SerializeField] private UnityEvent<float> onPollutionLimitReached;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    public override void UpdateCurrency()
    {
        AddCurrency(currentModifier);
    }

    public override void AddCurrency(float addedValue)
    {
        if (addedValue >= 0)
        {
            currentCurrency += addedValue;
            if (currentCurrency >= 100) onPollutionLimitReached?.Invoke(currentCurrency);
        }
        else
        {
            currentCurrency = Mathf.Max(0, currentCurrency + addedValue);
        }

        onCurrencyChanged?.Invoke(currentCurrency);
    }

    public float GetRatio()
    {
        float ratio = (1f - (currentCurrency / 100f)) * 2f - 1f;
        ratio = Mathf.Clamp(ratio, -1f, 1f);
        return ratio * 100f;
    }

}