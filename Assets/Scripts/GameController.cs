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

    public GameObject[] winner;
    public GameObject[] scene;
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
    public void DisplayEndGame(int player)
    {
        scene[0].SetActive(false);
        scene[1].SetActive(true);
        if (player == 0)
        {
            winner[0].SetActive(true);
            winner[1].SetActive(false);
        }
        else
        {
            winner[0].SetActive(false);
            winner[1].SetActive(true);
        }
        Time.timeScale = 0;
    }
}
