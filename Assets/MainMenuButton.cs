using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public SceneLoader sceneLoader;

    private void Awake()
    {
        var playerProperties = Resources.Load<PlayerProperties>("Player Properties");
        var music = GameObject.FindGameObjectsWithTag("BGM");

        for (int i = 0; i < music.Length; i++)
        {
            music[i].GetComponent<AudioSource>().mute = !playerProperties.bgm;
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
}
