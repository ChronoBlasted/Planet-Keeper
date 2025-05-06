using System.Globalization;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "ScriptableObject/UpgradeObject", order = 1)]
public class UpgradesObjectsData : ScriptableObject
{
    public string name;
    public string description;
    public Sprite sprite;
    public float price;
    public float pollutionAdded;
    public Animator animator;
    public bool isInside;
    public bool isEco;
}
