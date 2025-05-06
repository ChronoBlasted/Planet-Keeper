using BaseTemplate.Behaviours;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private void Start()
    {
        UIManager.Instance.Init();
    }
}
