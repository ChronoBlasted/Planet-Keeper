

using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObject/UpgradeObject", order = 1)]
public class UpgradesObjectsData : ScriptableObject
{
    public string name;
    [TextArea] public string description;
    public Sprite sprite;

    public bool isEco;
    public GameObject prefab;

    public float basePrice = 100f;
    public float priceGrowth = 1.6f;

    public float pollutionAdded;
    public float moneyGenerated;
    public Animator animator;

    public GenerationtransformType generationType;

    public int GetPriceAtLevel(int level)
    {
        return Mathf.RoundToInt(basePrice * Mathf.Pow(priceGrowth, level));
    }
}