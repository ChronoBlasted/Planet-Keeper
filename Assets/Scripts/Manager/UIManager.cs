using BaseTemplate.Behaviours;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] GameView gameView;
    [SerializeField] GameObject gameOverView;
    public void Init()
    {
        gameView.Init();
    }

    public void ShowGameOver()
    {
        gameOverView.SetActive(true);
    }
}
