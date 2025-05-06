using UnityEngine;

public class RatioManager : MonoBehaviour
{
    private static RatioManager instance = null;
    public static RatioManager Instance => instance;

    private MoneyManager moneyManager;
    private PollutionManager pollutionManager;

    public float pollutionImpactFactor = 5;

    private void Awake()
    {
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

    private void Start()
    {
        moneyManager = MoneyManager.Instance;
        pollutionManager = PollutionManager.Instance;
    }

    public float GetPollutionMoneyRatioMultiplier()
    {
        float pollution = Mathf.Clamp(pollutionManager.GetCurrency(), 0f, 100f);
        float money = Mathf.Max(0f, moneyManager.GetCurrency());

        float multiplier = (pollutionImpactFactor - (pollution / 10f));

        return multiplier;
    }
}

