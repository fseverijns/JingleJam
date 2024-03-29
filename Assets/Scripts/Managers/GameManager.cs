﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : PersistentSingleton<GameManager>
{
    public bool player1Joined = false;
    public bool player2Joined = false;
    public bool player3Joined = false;
    public bool player4Joined = false;

    [SerializeField]
    private GameObject characterImage1;
    [SerializeField]
    private GameObject player1JoinImage;
    [SerializeField]
    private GameObject player1JoinedImage;

    [SerializeField]
    private GameObject characterImage2;
    [SerializeField]
    private GameObject player2JoinImage;
    [SerializeField]
    private GameObject player2JoinedImage;

    [SerializeField]
    private GameObject characterImage3;
    [SerializeField]
    private GameObject player3JoinImage;
    [SerializeField]
    private GameObject player3JoinedImage;

    [SerializeField]
    private GameObject characterImage4;
    [SerializeField]
    private GameObject player4JoinImage;
    [SerializeField]
    private GameObject player4JoinedImage;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            if (Input.GetButtonDown("Player1Pickup"))
            {
                player1Joined = true;

                characterImage1.SetActive(true);
                player1JoinImage.SetActive(false);
                player1JoinedImage.SetActive(true);
            }
            if (Input.GetButtonDown("Player2Pickup"))
            {
                player2Joined = true;

                characterImage2.SetActive(true);
                player2JoinImage.SetActive(false);
                player2JoinedImage.SetActive(true);
            }
            if (Input.GetButtonDown("Player3Pickup"))
            {
                player3Joined = true;

                characterImage3.SetActive(true);
                player3JoinImage.SetActive(false);
                player3JoinedImage.SetActive(true);
            }
            if (Input.GetButtonDown("Player4Pickup"))
            {
                player4Joined = true;

                characterImage4.SetActive(true);
                player4JoinImage.SetActive(false);
                player4JoinedImage.SetActive(true);
            }

            if (Input.GetButtonDown("Player1Back"))
            {
                player1Joined = false;

                characterImage1.SetActive(false);
                player1JoinImage.SetActive(true);
                player1JoinedImage.SetActive(false);
            }
            if (Input.GetButtonDown("Player2Back"))
            {
                player2Joined = false;

                characterImage2.SetActive(false);
                player2JoinImage.SetActive(true);
                player2JoinedImage.SetActive(false);
            }
            if (Input.GetButtonDown("Player3Back"))
            {
                player3Joined = false;

                characterImage3.SetActive(false);
                player3JoinImage.SetActive(true);
                player3JoinedImage.SetActive(false);
            }
            if (Input.GetButtonDown("Player4Back"))
            {
                player4Joined = false;

                characterImage4.SetActive(false);
                player4JoinImage.SetActive(true);
                player4JoinedImage.SetActive(false);
            }

            if (Input.GetButtonDown("StartButton"))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
