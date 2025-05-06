using TMPro;
using UnityEditor.Localization.Plugins.XLIFF.V12;
using UnityEngine;

public class EarnLayout : MonoBehaviour
{
    [SerializeField] TMP_Text totalMoney, earnMoneyPerSec;

    public void Init()
    {
        SetTotalMoney(0);
        SetEarnMoneyPerSec(0);
    }

    public void SetTotalMoney(float money)
    {
        totalMoney.text = money.ToString("#,0") + "€";
    }

    public void SetEarnMoneyPerSec(float money)
    {
        earnMoneyPerSec.text = money.ToString("#,0") + "€/sec";
    }
}
