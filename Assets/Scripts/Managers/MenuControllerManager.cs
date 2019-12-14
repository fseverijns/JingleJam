using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerManager : PersistentSingleton<MenuControllerManager>
{
    bool mainMenu = true;

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
        if (mainMenu)
        {
            //mainMenuButtons[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
