using UnityEngine;

public class AddItemToGame : MonoBehaviour
{
    public UpgradeItem itemToSpawn;
    public void OnClick()
    {
        itemToSpawn = Instantiate(itemToSpawn);
        itemToSpawn.Init();
    }
}
