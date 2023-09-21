using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ssss : MonoBehaviour
{
    public GameObject m_buttonSFX;
    private AudioSource buttonSFX;
    public PlayerProperties playerProperties;
    public Sprite[] sprite;
    public Image imageOnOf;

    private void Awake()
    {
        buttonSFX = Instantiate(m_buttonSFX).GetComponent<AudioSource>();
        playerProperties = Resources.Load<PlayerProperties>("Player Properties");
    }

    public void onOf()
    {
        buttonSFX.Play();

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
