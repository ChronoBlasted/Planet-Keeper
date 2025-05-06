using UnityEngine;

public class PollutionManager : CurrencyManager
{
    protected override void Awake()
    {
        base.Awake();
    }
    public override void AddCurrency(float addedValue)
    {
        if (addedValue >= 0)
        {
            currentCurrency += addedValue;
        }
        else
        {
            currentCurrency = Mathf.Max(0, currentCurrency + addedValue);
        }

        onCurrencyChanged?.Invoke(currentCurrency);
    }
}