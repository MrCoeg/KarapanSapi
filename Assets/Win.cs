using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public PlayerProperties playerProperties;
    public SceneLoader loader;
    private void Awake()
    {
        loader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();

        playerProperties = Resources.Load<PlayerProperties>("Player Properties");
       
        this.gameObject.SetActive(false);
    }
    
}
