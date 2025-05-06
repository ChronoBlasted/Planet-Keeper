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
    UpgradesObjectsData currentData;

    public void Init(UpgradesObjectsData newData)
    {
        currentData = newData;

        title.text = currentData.name;
        desc.text = currentData.description;
        ico.sprite = currentData.sprite;

        total = 0;
        totalBuyed.text = total.ToString();

        UpdatePriceText();
        UpdateUI(0);

        MoneyManager.Instance.onCurrencyChanged.AddListener(UpdateUI);
    }

    public void HandleOnClick()
    {
        int priceToPay = currentData.GetPriceAtLevel(total);
        bool canBuy = MoneyManager.Instance.CanSpendMoney(priceToPay);

        if (!canBuy) return;

        // Dépense
        MoneyManager.Instance.SpendMoney(priceToPay);
        total++;
        totalBuyed.text = total.ToString();

        // Pollution / Production
        if (currentData.isEco)
        {
            PollutionManager.Instance.AddModifier(-currentData.pollutionAdded);
        }
        else
        {
            PollutionManager.Instance.AddModifier(currentData.pollutionAdded);
            MoneyManager.Instance.AddModifier(currentData.moneyGenerated);
        }

        // Spawning visuel
        SpawnerManager.Instance.Spawn(currentData.generationType, currentData.prefab);

        UpdatePriceText();
        UpdateUI(0);
    }

    private void UpdatePriceText()
    {
        int p = currentData.GetPriceAtLevel(total);
        price.text = p + "€";
    }

    public void UpdateUI(float _)
    {
        int priceToPay = currentData.GetPriceAtLevel(total);
        bool canBuy = MoneyManager.Instance.CanSpendMoney(priceToPay);
        lockLayout.SetActive(!canBuy);
        price.color = canBuy ? green : red;
    }
}
