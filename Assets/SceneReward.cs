using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class SceneReward : MonoBehaviour
{
    public PlayerProperties playerProperties;
    public Image orang;
    public Image quotes;

    public SceneLoader loader;
    private void Awake()
    {

        loader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();
        playerProperties = Resources.Load<PlayerProperties>("Player Properties");
        orang.sprite = playerProperties.currentProperties.currentSapi.orang;
        quotes.sprite = playerProperties.currentProperties.currentSapi.winReward;

    }

    public void Lanjut()
    {
        playerProperties.money += 20;
        playerProperties.energy -= 10;
        playerProperties.pusaka += 20;
        var progress = SceneManager.GetActiveScene().buildIndex - 2;

        if (progress >= playerProperties.progress)
        {
            playerProperties.progress += 1;
        }

        StartCoroutine(loader.ChangeScene(2));
    }
}
