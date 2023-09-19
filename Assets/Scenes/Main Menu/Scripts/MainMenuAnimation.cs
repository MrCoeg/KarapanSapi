using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    public Animation menuContainerAnimation;
    public Animation buyContainerAnimation;

    public GameObject[] SettingsToHide;
    private bool isInSettings;
    
    private bool startNextMenuToBuy;
    private bool waitTillendMenu;

    private bool startNextBuyToMenu;
    private bool waitTillendBuy;


    public void MenuToBuy()
    {
        menuContainerAnimation.Play("Menu_To_Buy");
        startNextMenuToBuy = true;
    }

    public void MenuToSettings()
    {
        isInSettings = !isInSettings;
        SettingsToHide[^1].SetActive(isInSettings);

        for (int i = 0; i < SettingsToHide.Length - 1; i++)
        {
            SettingsToHide[i].SetActive(!isInSettings);
        }


    }

    public void BuyToMenu()
    {
        buyContainerAnimation.Play("Buy_To_Menu");
        startNextBuyToMenu = true;

    }

    private void Update()
    {
        if (!startNextBuyToMenu && !startNextMenuToBuy)
        {
            return;
        }

        if (!menuContainerAnimation.IsPlaying("Menu_To_Buy") && startNextMenuToBuy)
        {
            startNextMenuToBuy = false;
            buyContainerAnimation.Play("Buy_To_Buy");

        }

        if (!buyContainerAnimation.IsPlaying("Buy_To_Menu") && startNextBuyToMenu)
        {
            startNextBuyToMenu = false;
            menuContainerAnimation.Play("Menu_To_Menu");

        }
    }
}
