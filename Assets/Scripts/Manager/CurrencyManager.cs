using UnityEngine;
using UnityEngine.Events;

public class CurrencyManager : MonoBehaviour
{
    public UnityEvent<float> onCurrencyChanged;
    [Space(10)]
    [SerializeField] protected float startingCurrency;
    [SerializeField] protected float currentCurrency;
    [Space(30)]
    public UnityEvent<float> onModifierChanged;
    [Space(10)]
    [SerializeField] protected float currentModifier;

    protected virtual void Awake()
    {
        currentCurrency = startingCurrency;
        currentModifier = 0;
    }

    protected virtual void FixedUpdate()
    {
        currentCurrency += currentModifier;
    }

    public virtual void AddCurrency(float addedValue)
    {
        currentCurrency += addedValue;
    }

    public void AddModifier(float addedValue)
    {
        onModifierChanged?.Invoke(currentModifier);
        currentModifier += addedValue;
    }

    public float GetCurrency()
    {
        return currentCurrency;
    }

    public float GetChanger()
    {
        return currentModifier;
    }
}