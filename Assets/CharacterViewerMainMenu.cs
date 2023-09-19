using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterViewerMainMenu : MonoBehaviour
{
    public CurrentPlayerProperties player;
    private int playerId;
    
    
    private void Awake()
    {
        playerId = -1;
    }
    private void Update()
    {
        if (playerId != player.currentSapi.id)
        {
            playerId = player.currentSapi.id;
            Instantiate(player.currentSapi.prefabSapi, this.transform, false);
            
        }
    }
}
