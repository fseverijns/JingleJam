using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : Singleton<GameScreen>
{
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    [SerializeField]
    private GameObject player3;
    [SerializeField]
    private GameObject player4;

    public void MakePlayerUITransparent(int playernumber)
    {
        switch (playernumber)
        {
            case 1:
                foreach (Image image in player1.GetComponentsInChildren<Image>())
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
                }
                foreach (Text text in player1.GetComponentsInChildren<Text>())
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0.5f);
                }
                break;
            case 2:
                foreach (Image image in player2.GetComponentsInChildren<Image>())
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
                }
                foreach (Text text in player2.GetComponentsInChildren<Text>())
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0.5f);
                }
                break;
            case 3:
                foreach (Image image in player3.GetComponentsInChildren<Image>())
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
                }
                foreach (Text text in player3.GetComponentsInChildren<Text>())
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0.5f);
                }
                break;
            case 4:
                foreach (Image image in player4.GetComponentsInChildren<Image>())
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
                }
                foreach (Text text in player4.GetComponentsInChildren<Text>())
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0.5f);
                }
                break;
        }
    }

    public void MakePlayerUISolid(int playernumber)
    {
        switch (playernumber)
        {
            case 1:
                foreach (Image image in player1.GetComponentsInChildren<Image>())
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                }
                foreach (Text text in player1.GetComponentsInChildren<Text>())
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                }
                break;
            case 2:
                foreach (Image image in player2.GetComponentsInChildren<Image>())
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                }
                foreach (Text text in player2.GetComponentsInChildren<Text>())
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                }
                break;
            case 3:
                foreach (Image image in player3.GetComponentsInChildren<Image>())
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                }
                foreach (Text text in player3.GetComponentsInChildren<Text>())
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                }
                break;
            case 4:
                foreach (Image image in player4.GetComponentsInChildren<Image>())
                {
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
                }
                foreach (Text text in player4.GetComponentsInChildren<Text>())
                {
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                }
                break;
        }
    }
}
