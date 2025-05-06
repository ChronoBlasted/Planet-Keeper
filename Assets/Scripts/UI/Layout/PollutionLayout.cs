using TMPro;
using UnityEngine;

public class PollutionLayout : MonoBehaviour
{
    [SerializeField] SliderBar ecoBar, malusBar;
    [SerializeField] TMP_Text amount;

    [SerializeField] Color redColor, greenColor;

    public void Init()
    {
        ecoBar.Init(0, 1);
        malusBar.Init(0, 1);

        SetBar(0);
    }

    public void SetBar(float pollutionRate)
    {
        if (pollutionRate >= 0)
        {
            ecoBar.SetValueSmooth(pollutionRate);
            malusBar.SetValueSmooth(0);

            amount.text = "+" + (int)(pollutionRate * 100) + "%";
            amount.color = greenColor;
        }
        else
        {
            malusBar.SetValueSmooth(pollutionRate);
            ecoBar.SetValueSmooth(0);

            amount.text = "-" + (int)(pollutionRate * 100) + "%";
            amount.color = redColor;
        }

    }
}
