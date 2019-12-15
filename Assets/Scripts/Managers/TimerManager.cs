using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerManager : Singleton<TimerManager>
{
    [SerializeField]
    private List<Player> players;

    [SerializeField]
    private float gameTime;
    private bool timerPlaying = false;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private AudioSource timerRunningOutSound;
    [SerializeField]
    private EndScreen endScreen;

    bool showScreenOnce = false;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (timerPlaying)
            {
                gameTime -= Time.deltaTime;
                timerText.text = "TIME LEFT: " + gameTime.ToString("F0");
                if (gameTime <= 20 && gameTime > 0)
                {
                    timerRunningOutSound.Play();
                }
                if (gameTime <= 0)
                {
                    ShowEndScreen();
                }
            }
        }
    }

    public void ShowEndScreen()
    {
        if (!showScreenOnce)
        {
            showScreenOnce = true;
            timerPlaying = false;
            GameScreen.Instance.gameObject.SetActive(false);
            ScoreManager scoreManager = ScoreManager.Instance;
            endScreen.gameObject.SetActive(true);

            int playerCount = 0;
            if (GameManager.Instance.player1Joined)
            {
                playerCount++;
                endScreen.FillFinishedToys(1, scoreManager.player1Toys);
                endScreen.SetScore(1, scoreManager.player1Score);
            }
            if (GameManager.Instance.player2Joined)
            {
                playerCount++;
                endScreen.FillFinishedToys(2, scoreManager.player2Toys);
                endScreen.SetScore(2, scoreManager.player2Score);
            }
            if (GameManager.Instance.player3Joined)
            {
                playerCount++;
                endScreen.FillFinishedToys(3, scoreManager.player3Toys);
                endScreen.SetScore(3, scoreManager.player3Score);
            }
            if (GameManager.Instance.player4Joined)
            {
                playerCount++;
                endScreen.FillFinishedToys(4, scoreManager.player4Toys);
                endScreen.SetScore(4, scoreManager.player4Score);
            }

            endScreen.SetPlayersActive(playerCount);
            FreezeAllPlayers();
        }
        
    }
    public void FreezeAllPlayers()
    {
        foreach (Player player in players)
        {
            player.FreezePlayer();
        }
    }

    public void UnFreezeAllPlayers()
    {
        foreach (Player player in players)
        {
            player.UnFreezePlayer();
        }
    }
    public void StartGame()
    {
        UnFreezeAllPlayers();
        StartTimer();

        if (GameManager.Instance.player1Joined)
        {
            players[0].gameObject.SetActive(true);
        }
        if (GameManager.Instance.player2Joined)
        {
            players[1].gameObject.SetActive(true);
        }
        if (GameManager.Instance.player3Joined)
        {
            players[2].gameObject.SetActive(true);
        }
        if (GameManager.Instance.player4Joined)
        {
            players[3].gameObject.SetActive(true);
        }
    }

    public void StartTimer()
    {
        timerPlaying = true;
    }
}
