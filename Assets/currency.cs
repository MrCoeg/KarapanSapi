using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class currency : MonoBehaviour
{
    public TextMeshProUGUI money;
    public TextMeshProUGUI energy;
    public TextMeshProUGUI pusaka;
    public SceneLoader loader;

    private PlayerProperties playerProperties;

    private void Awake()
    {

        playerProperties = Resources.Load<PlayerProperties>("Player Properties");

    }
    private void Update()
    {
        money.text = playerProperties.money.ToString();        
        energy.text = playerProperties.energy.ToString();
        pusaka.text = playerProperties.pusaka.ToString();

    }



}
