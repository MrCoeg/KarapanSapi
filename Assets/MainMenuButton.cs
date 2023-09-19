using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public SceneLoader sceneLoader;

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
        StartCoroutine(sceneLoader.ChangeScene(3));
    }

    public void Setting()
    {
        StartCoroutine(sceneLoader.ChangeScene(4));
    }
}
