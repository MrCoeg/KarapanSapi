using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyButton : MonoBehaviour
{
    public Button bioButton;
    public Button itemButton;

    public GameObject containerBio;
    public GameObject containerItem;

    public Button tingkatkanSusu;
    public Button tingkatkanTai;

    public Sprite[] tingkatkanSprite;

    private Image tingkatkanSusuImage;
    private Image tingkatkanTaiImage;

    public Transform taiParent;
    public Transform susuParent;

    public GameObject greenBarProgress;

    public PlayerProperties playerProperties;



    public TextMeshProUGUI susuCurrentProgress;
    public TextMeshProUGUI susuNextProgress;

    public TextMeshProUGUI TaiCurrentProgress;
    public TextMeshProUGUI TaiNextProgress;

    private void Awake()
    {
        playerProperties = Resources.Load<PlayerProperties>("Player Properties");

        tingkatkanSusuImage = tingkatkanSusu.GetComponent<Image>();
        tingkatkanTaiImage = tingkatkanTai.GetComponent<Image>();



        setUpTingkatkan();

    }

    public void setUpTingkatkan()
    {




        for (int i = 0; i < playerProperties.collectibles[0].upgradeProgress; i++)
        {
            Instantiate(greenBarProgress, susuParent, false);
        }

        for (int i = 0; i < playerProperties.collectibles[1].upgradeProgress; i++)
        {
            Instantiate(greenBarProgress, taiParent, false);
        }
        var susu = (Susu)playerProperties.collectibles[0];
        var tai = (Tai)playerProperties.collectibles[1];




        if (playerProperties.collectibles[0].upgradeProgress >= 3)
        {
            tingkatkanSusuImage.sprite = tingkatkanSprite[1];
            susuCurrentProgress.text = "Durasi : " + susu.speedDuration[susu.upgradeProgress].ToString();
            susuNextProgress.text = "Max";
        }
        else
        {
            susuCurrentProgress.text = "Durasi : " + susu.speedDuration[susu.upgradeProgress].ToString();
            susuNextProgress.text = "Durasi Selanjutnya: " + susu.speedDuration[susu.upgradeProgress + 1].ToString();
        }


        if (playerProperties.collectibles[1].upgradeProgress >= 3)
        {
            tingkatkanTaiImage.sprite = tingkatkanSprite[1];
            TaiCurrentProgress.text = "Durasi : " + tai.speedDuration[tai.upgradeProgress].ToString();
            TaiNextProgress.text = "Max";
        }
        else
        {
            TaiCurrentProgress.text = "Durasi : " + tai.speedDuration[tai.upgradeProgress].ToString();
            TaiNextProgress.text = "Durasi Selanjutnya : " + tai.speedDuration[tai.upgradeProgress + 1].ToString();
        }
    }


    public void Tingkatkan(int index)
    {
        playerProperties.collectibles[index].upgradeProgress += 1;
        var susu = (Susu)playerProperties.collectibles[0];
        var tai = (Tai)playerProperties.collectibles[1];
        if (playerProperties.collectibles[index].upgradeProgress >= 3)
        {
            if (index == 0)
            {
                
                tingkatkanSusuImage.sprite = tingkatkanSprite[1];
                susuCurrentProgress.text = "Durasi : " + susu.speedDuration[susu.upgradeProgress].ToString();
                susuNextProgress.text = "Max";
            }
            else
            {
                
                tingkatkanTaiImage.sprite = tingkatkanSprite[1];
                TaiCurrentProgress.text = "Durasi : " + tai.speedDuration[tai.upgradeProgress].ToString();
                TaiNextProgress.text = "Max";
            }
        }

        if (index == 0)
        {


            Instantiate(greenBarProgress, susuParent, false);
            susuCurrentProgress.text = "Durasi : " + susu.speedDuration[susu.upgradeProgress].ToString();
            susuNextProgress.text = "Durasi Selanjutnya : " + susu.speedDuration[susu.upgradeProgress + 1].ToString();
        }
        else
        {
            Instantiate(greenBarProgress, taiParent, false);
            TaiCurrentProgress.text = "Durasi : " + tai.speedDuration[tai.upgradeProgress].ToString();
            TaiNextProgress.text = "Durasi Selanjutnya : " + tai.speedDuration[tai.upgradeProgress + 1].ToString();
        }

    }

    public void Bio()
    {
        containerBio.SetActive(true);
        containerItem.SetActive(false);

    }   
    
    public void Item()
    {
        containerBio.SetActive(false);
        containerItem.SetActive(true);
    }

}
