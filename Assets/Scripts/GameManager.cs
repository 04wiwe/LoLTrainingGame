using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGameOver { get; private set; }
    [SerializeField] private UIManager uiManager;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void GameOver()
    {
        IsGameOver = true;
        Time.timeScale = 0;
        uiManager.ShowGameOverMenu();
    }
    public void RestartGame()
    {
        IsGameOver = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}