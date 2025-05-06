using UnityEngine;

public class PollutionManager : CurrencyManager
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void ReducePollution(float amount)
    {
        currentCurrency = Mathf.Max(0, currentCurrency - amount);
    }
}
