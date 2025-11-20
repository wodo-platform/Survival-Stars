using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
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

    public void StartGame()
    {
        IsGameStarted = true;
    }

    public void StopGame()
    {
        IsGameStarted = false;
    }

    public void RestartGame()
    {
        
    }
}
