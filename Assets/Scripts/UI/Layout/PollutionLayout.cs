using TMPro;
using UnityEngine;

public class PollutionLayout : MonoBehaviour
{
    [SerializeField] SliderBar ecoBar, malusBar;
    [SerializeField] TMP_Text amount;

    [SerializeField] Color redColor, greenColor;

    public void Init()
    {
        ecoBar.Init(0, 100);
        malusBar.Init(0, 100);

        SetBar(0);

        PollutionManager.Instance.onCurrencyChanged.AddListener(SetBar);
    }
    public void SetBar(float newValue)
    {
        float pollutionRate = PollutionManager.Instance.GetRatio();

        amount.text = $"{pollutionRate:+0;-0}%";

        if (pollutionRate >= 0)
        {
            ecoBar.SetValueSmooth(pollutionRate);
            malusBar.SetValueSmooth(0);

            amount.color = greenColor;
        }
        else
        {
            malusBar.SetValueSmooth(Mathf.Abs(pollutionRate));
            ecoBar.SetValueSmooth(0);

            amount.color = redColor;
        }
    }

}
