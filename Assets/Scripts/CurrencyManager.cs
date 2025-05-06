using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] protected float startingCurrency;
    [SerializeField] protected float currentCurrency;
    [Space(10)]
    [SerializeField] protected float currentChanger;

    protected virtual void Awake()
    {
        currentCurrency = startingCurrency;
        currentChanger = 0;
    }

    protected virtual void FixedUpdate()
    {
        currentCurrency += currentChanger;
    }

    public void AddCurrency(float addedValue)
    {
        currentCurrency += addedValue;
    }

    public void AddChanger(float addedValue)
    {
        currentChanger += addedValue;
    }

    public float GetCurrency()
    {
        return currentCurrency;
    }

    public float GetChanger()
    {
        return currentChanger;
    }
}
