using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Map_Loader : MonoBehaviour
{
    public CurrentPlayerProperties playerProperties;
    public CinemachineVirtualCamera cameara;

    public Transform characterParent;
    private void Awake()
    {
        var instantiated = Instantiate(playerProperties.currentSapi.prefabSapiGameplay, characterParent, false);
        cameara.Follow = instantiated.transform;
    }
}
