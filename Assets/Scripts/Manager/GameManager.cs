using BaseTemplate.Behaviours;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] GameObject planet;
    private void Start()
    {
        UIManager.Instance.Init();
    }

    public void EndGame()
    {
        planet.SetActive(false);
        UIManager.Instance.ShowGameOver();

    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
