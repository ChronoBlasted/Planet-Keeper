using BaseTemplate.Behaviours;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private void Awake()
    {
        UIManager.Instance.Init();
    }
}
