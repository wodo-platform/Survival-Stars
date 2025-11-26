using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject inGamePanel;
    
    [SerializeField] private GameObject[] healthObjects;
    [SerializeField] private TMP_Text scoreText;
    
    [SerializeField] private TMP_Text spHighScoreText;
    [SerializeField] private TMP_Text goHighScoreText;
    [SerializeField] private TMP_Text goScoreText;
    
    [SerializeField] private PlayerScore playerScore;

    public void ShowStartPanel()
    {
        spHighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        inGamePanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        goHighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        ResetGame();
        goScoreText.text = playerScore.Score.ToString();
        gameOverPanel.SetActive(true);
        startPanel.SetActive(false);
        inGamePanel.SetActive(false);
    }

    public void ShowInGamePanel()
    {
        gameOverPanel.SetActive(false);
        startPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }
    
    public void OnHealthChange(int health)
    {
        foreach (GameObject healthObject in healthObjects)
        {
            healthObject.SetActive(false);
        }

        for (int i = 0; i < health; i++)
        {
            healthObjects[i].SetActive(true);
        }
    }

    public void OnScoreChange(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        OnHealthChange(5);
        scoreText.text = "0";
    }
}
