using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button btnPauseOrPlay;
    public Sprite btnPause;
    public Sprite btnPlay;
    private bool isPause;

    public Text[] score;

    public GameObject[] winner;
    public GameObject[] scene;
    public GameObject menu;

    private AudioSource audioSource;
    void Start()
    {
        isPause = false;
        audioSource = gameObject.GetComponent<AudioSource>();
        Time.timeScale = 1;
    }

    public void PauseOrPlayGame()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            btnPauseOrPlay.image.sprite = btnPlay;
            isPause = true;
            audioSource.Pause();
        }
        else
        {
            Time.timeScale = 1;
            btnPauseOrPlay.image.sprite = btnPause;
            isPause = false;
            audioSource.Play();
        }
    }
    public void DisplayScore(int scorePlay, int player)
    {
        score[player].text = scorePlay.ToString() + "/3";
    }

    public void EndGame(int player)
    {
        StartCoroutine(DisplayEndGame(player));
    }
    private IEnumerator DisplayEndGame(int player)
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
        yield return new WaitForSeconds(1);
        menu.SetActive(true);
        if (player == 1)
            DisplayMenu();
        Time.timeScale = 0;
    }

    public void DisplayMenu()
    {
        scene[0].SetActive(false);
        scene[1].SetActive(false);
        scene[2].SetActive(true);
        audioSource.Pause();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
