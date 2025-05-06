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