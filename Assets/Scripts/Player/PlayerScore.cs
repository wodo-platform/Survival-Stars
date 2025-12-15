using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private UIController uiController;
    public int Score{get; private set;}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gold"))
        {
            Score++;
            uiController.OnScoreChange(Score);
            PoolManager.Instance.ReturnToPool(ObjectType.Gold, other.gameObject);
            SoundManager.instance.PlaySfx(SoundType.CoinCollectSFX);
        }
    }

    private void ResetScore()
    {
        Score = 0;
    }

    public void SaveScore()
    {
        if(Score > PlayerPrefs.GetInt("HighScore",0))
            PlayerPrefs.SetInt("HighScore", Score);
    }
}
