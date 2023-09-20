using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public Image imageOnOf;
    public Sprite[] sprite;
    public PlayerProperties playerProperties;

    public SceneLoader loader;
    private void Awake()
    {
        loader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();
        playerProperties = Resources.Load<PlayerProperties>("Player Properties");
        
        if (playerProperties.bgm)
        {
            imageOnOf.sprite = sprite[0];
        }
        else
        {
            imageOnOf.sprite = sprite[1];
        }
        var music = GameObject.FindGameObjectsWithTag("BGM");

        for (int i = 0; i < music.Length; i++)
        {
            music[i].GetComponent<AudioSource>().mute = !playerProperties.bgm;
        }

        this.gameObject.SetActive(false);
    }

    public void Continue()
    {
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
    }

    public void Restart()
    {
        StartCoroutine(loader.ChangeScene(SceneManager.GetActiveScene().buildIndex));
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(loader.ChangeSceneAnimation(1));

    }

    public void onOf()
    {
        playerProperties.bgm = !playerProperties.bgm;

        if (playerProperties.bgm)
        {
            imageOnOf.sprite = sprite[0];
        }
        else
        {
            imageOnOf.sprite = sprite[1];
        }
        var music = GameObject.FindGameObjectsWithTag("BGM");

        for (int i = 0; i < music.Length; i++)
        {
            music[i].GetComponent<AudioSource>().mute = !playerProperties.bgm;
        }
    }

}
