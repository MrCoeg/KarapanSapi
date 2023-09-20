using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Map_Loader : MonoBehaviour
{
    public CurrentPlayerProperties playerProperties;
    public CinemachineVirtualCamera cameara;

    public Transform characterParent;
    public Transform enemyParent;

    public GameObject[] enemyList;
    private void Awake()
    {
        var instantiated = Instantiate(playerProperties.currentSapi.prefabSapiGameplay, characterParent, false);
        cameara.Follow = instantiated.transform;

        for (int i = 0; i < enemyList.Length; i++)
        {
            instantiated = Instantiate(enemyList[i], enemyParent, false);
            if (i != 0)
            {
                instantiated.GetComponent<SpriteRenderer>().sortingOrder = 2;

            }
            else
            {
                instantiated.GetComponent<SpriteRenderer>().sortingOrder = 0;

            }
        }
    }
}
