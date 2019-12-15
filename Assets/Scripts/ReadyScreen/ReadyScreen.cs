using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyScreen : MonoBehaviour
{
    [SerializeField]
    private Text player1ReadyText;
    [SerializeField]
    private Text player2ReadyText;
    [SerializeField]
    private Text player3ReadyText;
    [SerializeField]
    private Text player4ReadyText;

    int playersReady = 0;
    int playersNeeded = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager.player1Joined)
        {
            player1ReadyText.gameObject.SetActive(true);
            playersNeeded++;
        }
        if (gameManager.player2Joined)
        {
            player2ReadyText.gameObject.SetActive(true);
            playersNeeded++;
        }
        if (gameManager.player3Joined)
        {
            player3ReadyText.gameObject.SetActive(true);
            playersNeeded++;
        }
        if (gameManager.player4Joined)
        {
            player4ReadyText.gameObject.SetActive(true);
            playersNeeded++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player1ReadyText.gameObject.activeSelf)
        {
            if (Input.GetButtonDown("Player1Pickup"))
            {
                player1ReadyText.color = Color.green;
                playersReady++;
            }
        }
        if (player2ReadyText.gameObject.activeSelf)
        {
            if (Input.GetButtonDown("Player2Pickup"))
            {
                player2ReadyText.color = Color.green;
                playersReady++;
            }
        }
        if (player3ReadyText.gameObject.activeSelf)
        {
            if (Input.GetButtonDown("Player3Pickup"))
            {
                player3ReadyText.color = Color.green;
                playersReady++;
            }
        }
        if (player4ReadyText.gameObject.activeSelf)
        {
            if (Input.GetButtonDown("Player4Pickup"))
            {
                player1ReadyText.color = Color.green;
                playersReady++;
            }
        }

        if (playersReady == playersNeeded)
        {
            GameManager.Instance.StartGame();
        }
    }
}
