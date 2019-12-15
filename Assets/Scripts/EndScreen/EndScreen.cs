using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : Singleton<EndScreen>
{
    [SerializeField]
    private GameObject Player1UI;
    [SerializeField]
    private GameObject Player2UI;
    [SerializeField]
    private GameObject Player3UI;
    [SerializeField]
    private GameObject Player4UI;

    [SerializeField]
    private GameObject Player1FinishedToysUI;
    [SerializeField]
    private GameObject Player2FinishedToysUI;
    [SerializeField]
    private GameObject Player3FinishedToysUI;
    [SerializeField]
    private GameObject Player4FinishedToysUI;

    [SerializeField]
    private Text player1ScoreText;
    [SerializeField]
    private Text player2ScoreText;
    [SerializeField]
    private Text player3ScoreText;
    [SerializeField]
    private Text player4ScoreText;

    [SerializeField]
    private GameObject FinishedToyPrefab;

    public void SetPlayersActive(int playerCount)
    {
        if (playerCount == 1)
        {
            Player1UI.SetActive(true);
        }
        if (playerCount == 2)
        {
            Player1UI.SetActive(true);
            Player2UI.SetActive(true);
        }
        if (playerCount == 3)
        {
            Player1UI.SetActive(true);
            Player2UI.SetActive(true);
            Player3UI.SetActive(true);
        }
        if (playerCount == 4)
        {
            Player1UI.SetActive(true);
            Player2UI.SetActive(true);
            Player3UI.SetActive(true);
            Player4UI.SetActive(true);
        }
    }

    public void FillFinishedToys(int playernumber, List<FinishedToy> finishedToys)
    {
        if (playernumber == 1 && Player1FinishedToysUI.activeInHierarchy)
        {
            GameObject toy = Instantiate(FinishedToyPrefab, Player1FinishedToysUI.transform);
        }
        if (playernumber == 2 && Player2FinishedToysUI.activeInHierarchy)
        {
            GameObject toy = Instantiate(FinishedToyPrefab, Player2FinishedToysUI.transform);
        }
        if (playernumber == 3 && Player3FinishedToysUI.activeInHierarchy)
        {
            GameObject toy = Instantiate(FinishedToyPrefab, Player3FinishedToysUI.transform);
        }
        if (playernumber == 4 && Player4FinishedToysUI.activeInHierarchy)
        {
            GameObject toy = Instantiate(FinishedToyPrefab, Player4FinishedToysUI.transform);
        }
    }

    public void SetScore(int playernumber, int score)
    {
        if (playernumber == 1)
        {
            player1ScoreText.text = "Score: " + score;
        }
        if (playernumber == 2)
        {
            player2ScoreText.text = "Score: " + score;
        }
        if (playernumber == 3)
        {
            player3ScoreText.text = "Score: " + score;
        }
        if (playernumber == 4)
        {
            player4ScoreText.text = "Score: " + score;
        }
    }
}
