using BaseTemplate.Behaviours;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] GameView gameView;
    public void Init()
    {
        gameView.Init();
    }
}
