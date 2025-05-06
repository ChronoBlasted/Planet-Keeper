using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSlotLayout : MonoBehaviour
{
    [SerializeField] TMP_Text title, desc, amount, price, totalBuyed;
    [SerializeField] Image ico;
    [SerializeField] GameObject lockLayout;

    [SerializeField] Color red, green;

    int total = 0;
    //Data currentData;

    public void Init()
    {
        title.text = "";
        desc.text = "";
        amount.text = "";
        price.text = "€";
        totalBuyed.text = total.ToString();

        // ico.sprite;

        UpdateUI();
    }

    public void HandleOnClick()
    {
        //if (currentData.cost < CurrencyManager.coin)
        //{

        //}
        //else
        //{
        //    totalBuyed.text = total.ToString();
        //}
    }

    public void UpdateUI()
    {
        //bool canBuy = currentData.cost < CurrencyManager.coin
        //lockLayout.SetActive(canBuy);
        //price.color = canBuy ? green : red;
    }
}
