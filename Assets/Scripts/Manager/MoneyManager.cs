using UnityEngine;
using UnityEngine.Events;

public class MoneyManager : CurrencyManager
{
    private static MoneyManager instance = null;
    public static MoneyManager Instance => instance;

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

    protected override void FixedUpdate()
    {
        AddCurrency(currentModifier);
    }

    public override void AddCurrency(float addedValue)
    {
        if (addedValue >= 0)
        {
            currentCurrency += (addedValue * RatioManager.Instance.GetPollutionMoneyRatioMultiplier());
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