﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : PersistentSingleton<ScoreManager>
{
    private int player1Score = 0;
    private int player2Score = 0;
    private int player3Score = 0;
    private int player4Score = 0;

    [SerializeField]
    private Text player1ScoreText;
    [SerializeField]
    private Text player2ScoreText;
    [SerializeField]
    private Text player3ScoreText;
    [SerializeField]
    private Text player4ScoreText;


    [SerializeField]
    private int brokenScorePerPart;
    [SerializeField]
    private int fixedScorePerPart;

    public void IncreasePlayerScore(int playerNumber, int brokenParts, int fixedParts, bool setCompleted, bool wishlistComplete)
    {
        if (wishlistComplete)
        {
            switch (playerNumber)
            {
                case 1:
                    player1Score += ((brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart) * 3);
                    break;
                case 2:
                    player2Score += ((brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart) * 3);
                    break;
                case 3:
                    player3Score += ((brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart) * 3);
                    break;
                case 4:
                    player4Score += ((brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart) * 3);
                    break;
            }
        }
        else if (setCompleted)
        {
            switch (playerNumber)
            {
                case 1:
                    player1Score += ((brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart) * 2);
                    break;
                case 2:
                    player2Score += ((brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart) * 2);
                    break;
                case 3:
                    player3Score += ((brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart) * 2);
                    break;
                case 4:
                    player4Score += ((brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart) * 2);
                    break;
            }
        }
        else
        {
            switch (playerNumber)
            {
                case 1:
                    player1Score += (brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart);
                    break;
                case 2:
                    player2Score += (brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart);
                    break;
                case 3:
                    player3Score += (brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart);
                    break;
                case 4:
                    player4Score += (brokenParts * brokenScorePerPart) + (fixedParts * fixedScorePerPart);
                    break;
            }
        }

        WriteScoreToText();
    }

    private void WriteScoreToText()
    {
        player1ScoreText.text = "Score: " + player1Score;
        player2ScoreText.text = "Score: " + player2Score;
        player3ScoreText.text = "Score: " + player3Score;
        player4ScoreText.text = "Score: " + player4Score;
    }
}
