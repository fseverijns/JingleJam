using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : PersistentSingleton<ScoreManager>
{
    private int player1Score = 0;
    private int player2Score = 0;
    private int player3Score = 0;
    private int player4Score = 0;

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
    }
}
