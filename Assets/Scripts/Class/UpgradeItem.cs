using UnityEngine;

public class UpgradeItem : MonoBehaviour
{
    [SerializeField] UpgradesObjectsData data;
    public string name;
    public string description;
    public Sprite sprite;
    public float price;
    public float pollutionAdded;
    public Transform rotPos;
    public Animator animator;

    private void Start()
    {
        description = data.description;
        sprite = data.sprite;
        pollutionAdded = data.pollutionAdded;
        animator = data.animator;
    }

    public void Init()
    {
        description = data.description;
        sprite = data.sprite;
        pollutionAdded = data.pollutionAdded;
        if (data.animator != null)
        {
            animator = data.animator;
            animator.SetTrigger(name);
        }
    }


}
