using System;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score{get; private set;}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gold"))
        {
            Score++;
            PoolManager.Instance.ReturnToPool(ObjectType.Gold, other.gameObject);
        }
    }

    private void ResetScore()
    {
        Score = 0;
    }

    private void SaveScore()
    {
    }
}
