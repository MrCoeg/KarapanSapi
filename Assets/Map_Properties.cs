using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_Properties : MonoBehaviour
{
    public int level;
    public int mapName;

    public PlayerProperties playerProperties;

    private CurrentPlayerProperties player;

    public Image lockImage;
    public MapInstance instance;


    public void Selected()
    {
        instance.selected = level + 2;
    }

    private void Awake()
    {
        if (level <= playerProperties.progress)
        {
            lockImage.gameObject.SetActive(false);

            gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            lockImage.gameObject.SetActive(true);
            gameObject.GetComponent<Button>().interactable = false;
        }
    }

}
