using UnityEngine;

public class MoneyManager : CurrencyManager
{
    protected override void Awake()
    {
        base.Awake();
    }

    public bool CanSpendMoney(float amount)
    {
        if (currentCurrency >= amount)
        {
            SpendMoney(amount);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpendMoney(float amount)
    {
        currentCurrency -= amount;
    }
}