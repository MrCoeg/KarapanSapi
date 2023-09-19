using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Properties", menuName = "Game Manager/Player Properties")]
public class PlayerProperties : ScriptableObject
{
    public int money;
    public int pusaka;
    public int energy;
    public int progress = 1;

    public List<Sapi> ownedSapi;
    public List<Collectible> collectibles;


    public List<Aksesoris> ownedAksesoris;
    public CurrentPlayerProperties currentProperties;

}
