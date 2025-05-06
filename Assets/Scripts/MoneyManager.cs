using UnityEngine;
using UnityEngine.Events;

public class MoneyManager : CurrencyManager
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
            onCurrencyChanged?.Invoke(currentCurrency);
        }
        else if (currentCurrency >= -addedValue)
        {
            CanSpendMoney(addedValue);
        }
    }

    public bool CanSpendMoney(float amount)
    {
        if (currentCurrency >= amount)
        {
            SpendMoney(amount);
            onCurrencyChanged?.Invoke(currentCurrency);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpendMoney(float amount)
    {
        currentCurrency += amount;
    }
}