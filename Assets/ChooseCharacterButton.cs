using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacterButton : MonoBehaviour
{
    public PlayerProperties playerProperties;
    public GameObject[] toShow;
    private void Awake()
    {

        playerProperties = Resources.Load<PlayerProperties>("Player Properties");
        if (playerProperties.currentProperties.currentSapi != null)
        {
            for (int i = 0; i < toShow.Length; i++)
            {
                toShow[i].SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
    }

    public void chooseCharacter(int index)
    {
        playerProperties.ownedSapi.Add(playerProperties.shopShapi[index]);
        GameObject.Find("Button").GetComponent<AudioSource>().Play();
        playerProperties.currentProperties.currentSapi = playerProperties.ownedSapi[0];

        for (int i = 0; i < toShow.Length; i++)
        {
            toShow[i].SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
