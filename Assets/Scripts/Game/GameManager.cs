using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private PlayerScore playerScore;
    [SerializeField] private UIController uiController;
    public bool IsGameStarted { get; private set; }

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        uiController.ShowStartPanel();
    }

    public void StartGame()
    {
        IsGameStarted = true;
        uiController.ShowInGamePanel();
    }

    public void EndGame()
    {
        IsGameStarted = false;
        playerScore.SaveScore();
        uiController.ShowGameOverPanel();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
