using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewGameOver : MonoBehaviour
{
    public static ViewGameOver sharedInstance;
    
    public Text coinsLabel;
    public Text scoreLabel;

    void Awake()
    {
        sharedInstance = this;
    }

    public void UpdateUI()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.gameOver)
        {
            coinsLabel.text = GameManager.sharedInstance.collectedCoin.ToString();
            scoreLabel.text = PlayerController.sharedInstance.GetDistance().ToString("f0");
        }
    }
}
