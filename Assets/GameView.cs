using UnityEngine;

public class GameView : MonoBehaviour
{
    [SerializeField] EarnLayout earnLayout;
    [SerializeField] PollutionLayout pollutionLayout;
    [SerializeField] ScrollLayout scrollEntreprise,scrollEco;

    public void Init()
    {
        earnLayout.Init();
        pollutionLayout.Init();
        scrollEntreprise.Init();
        scrollEco.Init();    
    }
}
