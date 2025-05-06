using TMPro;
using UnityEngine;

public class EarnLayout : MonoBehaviour
{
    [SerializeField] TMP_Text totalMoney, earnMoneyPerSec;

    private float lastTotalMoney = float.MinValue;
    private float lastEarnMoneyPerSec = float.MinValue;

    public void Init()
    {
        SetTotalMoney(0);
        SetEarnMoneyPerSec(0);

        MoneyManager.Instance.onCurrencyChanged.AddListener(SetTotalMoney);
        MoneyManager.Instance.onModifierChanged.AddListener(SetEarnMoneyPerSec);
    }
    public void SetTotalMoney(float money)
    {
        // Utiliser Mathf.CeilToInt pour arrondir au supérieur
        if (Mathf.Approximately(money, lastTotalMoney)) return;

        lastTotalMoney = money;
        totalMoney.text = Mathf.CeilToInt(money).ToString("#,0") + "€"; // Plafonne la valeur à l'entier supérieur
    }

    public void SetEarnMoneyPerSec(float money)
    {
        // Utiliser Mathf.CeilToInt pour arrondir au supérieur
        if (Mathf.Approximately(money, lastEarnMoneyPerSec)) return;

        lastEarnMoneyPerSec = money;
        earnMoneyPerSec.text = Mathf.CeilToInt(money).ToString("#,0") + "€/sec"; // Plafonne la valeur à l'entier supérieur
    }

}