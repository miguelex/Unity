﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewInGame : MonoBehaviour
{
    public static ViewInGame sharedInstance;
    public Text coinsLabel;
    public Text scoreLabel;
    public Text highScoreLabel;

    private void Awake()
    {
        sharedInstance = this;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            scoreLabel.text = PlayerController.sharedInstance.GetDistance().ToString("f0");
        }
    }

    public void UpdateHigScoreLabel()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            highScoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
    }

    public void UpdateCoinLabe()
    {
        if (GameManager.sharedInstance.currentGameState == GameState.inTheGame)
        {
            coinsLabel.text = GameManager.sharedInstance.collectedCoin.ToString();
        }
    }
}
