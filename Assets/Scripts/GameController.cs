using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Button btnPauseOrPlay;
    public Sprite btnPause;
    public Sprite btnPlay;
    private bool isPause;

    public Text[] score;
    void Start()
    {
        isPause = false;
    }

    public void PauseOrPlayGame()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            btnPauseOrPlay.image.sprite = btnPlay;
            isPause = true;
        }
        else
        {
            Time.timeScale = 1;
            btnPauseOrPlay.image.sprite = btnPause;
            isPause = false;
        }
    }
    public void DisplayScore(int scorePlay, int player)
    {
        score[player].text = scorePlay.ToString() + "/3";
    }
}
