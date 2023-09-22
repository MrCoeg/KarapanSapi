using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public SceneLoader sceneLoader;
    PlayerProperties playerProperties;
    int id;

    private void Awake()
    {
        playerProperties = Resources.Load<PlayerProperties>("Player Properties");

        if (playerProperties.currentProperties.currentSapi != null)
        {
            id = playerProperties.currentProperties.currentSapi.id;
            var a = GameObject.FindGameObjectsWithTag("BGM");
            for (int i = 0; i < 3; i++)
            {
                if (i != id)
                {
                    a[i].GetComponent<AudioSource>().mute = true;
                }
                else
                {
                    a[i].GetComponent<AudioSource>().mute = false;
                    a[i].GetComponent<AudioSource>().Play();
                }

            }


        }
        else
        {
            id = -1;
        }
    }
    public void Back()
    {
        StartCoroutine(sceneLoader.ChangeScene(1));
    }

    public void Map()
    {
        StartCoroutine(sceneLoader.ChangeScene(2));
    }

    public void Play(int index)
    {
        StartCoroutine(sceneLoader.ChangeSceneAnimation(index));
    }

    public void Inventory()
    {
        StartCoroutine(sceneLoader.ChangeScene(6));
    }

    public void Setting()
    {
        StartCoroutine(sceneLoader.ChangeScene(4));
    }

    private void Update()
    {
        if ( playerProperties.currentProperties.currentSapi != null && id != playerProperties.currentProperties.currentSapi.id) 
        {
            id = playerProperties.currentProperties.currentSapi.id;

            var a = GameObject.FindGameObjectsWithTag("BGM");
            for (int i = 0; i < 3; i++)
            {
                if (i != id)
                {
                    a[i].GetComponent<AudioSource>().mute = true;
                }
                else
                {
                    a[i].GetComponent<AudioSource>().mute = false;
                    a[i].GetComponent<AudioSource>().Play();
                }
                
            }
        }
    }
}
