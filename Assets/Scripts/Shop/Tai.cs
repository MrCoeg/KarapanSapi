using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tai", menuName = "Collectible/Tai")]
public class Tai : Collectible
{
    public int[] speedDuration;
    public int speedAcceleration;
    public Transform parent;

    public override void Use()
    {
       
        GameObject.FindGameObjectWithTag("Enemy")?.GetComponent<EnemyMovement>().manipulate(speedAcceleration, speedDuration[upgradeProgress]);
    }
}
