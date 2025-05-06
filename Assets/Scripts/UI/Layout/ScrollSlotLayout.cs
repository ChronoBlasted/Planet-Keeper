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

    public int GetPrice()
    {
        return (int)Mathf.Pow(currentData.price, (total * 0.1f) + 1);
    }

    public void Init(UpgradesObjectsData newData)
    {
        currentData = newData;

        title.text = currentData.name;
        desc.text = currentData.description;
        amount.text = "+" + currentData.pollutionAdded;
        price.text = GetPrice() + "€";
        totalBuyed.text = total.ToString();

        ico.sprite = currentData.sprite;

        UpdateUI(0);

        MoneyManager.Instance.onCurrencyChanged.AddListener(UpdateUI);
    }

    public void HandleOnClick()
    {
        bool canBuy = MoneyManager.Instance.CanSpendMoney(GetPrice());

        if (canBuy)
        {
            total++;
            totalBuyed.text = total.ToString();

            MoneyManager.Instance.SpendMoney(currentData.price);

            if (currentData.isEco)
            {
                PollutionManager.Instance.AddModifier(-currentData.pollutionAdded);
            }
            else
            {
                PollutionManager.Instance.AddModifier(currentData.pollutionAdded);
                MoneyManager.Instance.AddModifier(currentData.price);
            }

            SpawnerManager.Instance.Spawn(currentData.generationType, currentData.prefab);
        }
        else
        {
        }
    }

    public void UpdateUI(float moneyChanged)
    {
        bool canBuy = MoneyManager.Instance.CanSpendMoney(GetPrice());
        lockLayout.SetActive(!canBuy);
        price.text = GetPrice() + "€";
        price.color = canBuy ? green : red;
    }
}
