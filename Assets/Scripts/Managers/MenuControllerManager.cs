using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerManager : PersistentSingleton<MenuControllerManager>
{
    bool mainMenu = true;
    int currentItem;

    bool axisInUse = false;

    public Button[] mainMenuButtons;
    public Button[] gameMenuButtons;

    public void SwitchMenu()
    {
        if (mainMenu)
        {
            mainMenu = false;
        }
        else
        {
            mainMenu = true;
        }
    }

    void Start()
    {
        currentItem = 0;

        if (mainMenu)
        {
            mainMenuButtons[currentItem].Select();
        }
        else
        {
            gameMenuButtons[currentItem].Select();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("MenuVertical") > 0 || Input.GetAxis("Player1Vertical") < 0)
        {
            if (!axisInUse)
            {
                axisInUse = true;

                currentItem--;
                if (currentItem < 0)
                {
                    currentItem = 0;
                }
            }
        
        }
        else if (Input.GetAxis("MenuVertical") < 0 || Input.GetAxis("Player1Vertical") > 0)
        {
            if (!axisInUse)
            {
                axisInUse = true;

                currentItem++;
                if (currentItem > mainMenuButtons.Length - 1)
                {
                    currentItem = mainMenuButtons.Length - 1;
                }
            }
            
        }
        else
        {
            axisInUse = false;
        }

        mainMenuButtons[currentItem].Select();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
