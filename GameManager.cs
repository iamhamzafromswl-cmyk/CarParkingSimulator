using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState { MainMenu, Gameplay, Paused, Win, Lose }
    public GameState currentGameState;

    [Header("Scene Management")]
    public string mainMenuSceneName = "MainMenu";
    public string gameplaySceneName = "GameplayScene";

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        SetGameState(GameState.MainMenu);
        LoadScene(mainMenuSceneName);
    }

    public void SetGameState(GameState newState)
    {
        currentGameState = newState;
        Debug.Log($"Game State Changed to: {currentGameState}");
        // Potentially trigger events or UI updates based on state change
        switch (currentGameState)
        {
            case GameState.MainMenu:
                // Setup main menu UI
                break;
            case GameState.Gameplay:
                // Hide main menu UI, show gameplay UI
                break;
            case GameState.Paused:
                Time.timeScale = 0f; // Pause game time
                // Show pause menu UI
                break;
            case GameState.Win:
                Time.timeScale = 1f; // Resume game time
                // Show win screen UI
                break;
            case GameState.Lose:
                Time.timeScale = 1f; // Resume game time
                // Show lose screen UI
                break;
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void StartGame()
    {
        SetGameState(GameState.Gameplay);
        LoadScene(gameplaySceneName);
    }

    public void PauseGame()
    {
        SetGameState(GameState.Paused);
    }

    public void ResumeGame()
    {
        SetGameState(GameState.Gameplay);
        Time.timeScale = 1f;
    }

    public void EndGame(bool won)
    {
        if (won)
        {
            SetGameState(GameState.Win);
        }
        else
        {
            SetGameState(GameState.Lose);
        }
        // Optionally load a result scene or show overlay
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
