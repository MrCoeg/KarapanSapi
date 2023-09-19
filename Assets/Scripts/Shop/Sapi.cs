using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sapi", menuName = "Item/Sapi")]
public class Sapi : Item
{

    public float speed;
    public float acceleration;
    public float speedLimit;
    public int price;

    public float nitroSpeed;

    public GameObject prefabSapi;
    public GameObject prefabSapiGameplay;
    public PlayerProperties playerProperties;
    private void Awake()
    {
        playerProperties = Resources.Load<PlayerProperties>("Player Properties");
    }

    public override void Use()
    {
        if (isOwned)
        {
            playerProperties.currentProperties.currentSapi = this;
        }
        else
        {
            if (playerProperties.money > price)
            {
                isOwned = true;
                playerProperties.ownedSapi.Add(this);
            }
        }
    }
}
