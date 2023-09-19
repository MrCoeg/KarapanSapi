using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Parallax : MonoBehaviour
{
    public GameObject background;
    public CurrentPlayerProperties playerProperties;
    private Sapi sapi;
    private void Awake()
    {
        playerProperties = Resources.Load<PlayerProperties>("Player Properties").currentProperties; 
        sapi = playerProperties.currentSapi;  
    }

    private void Update()
    {
         
        background.transform.localPosition -= new Vector3(sapi.speed * background.transform.localPosition.z * Time.deltaTime, 0, 0);
    }
}
