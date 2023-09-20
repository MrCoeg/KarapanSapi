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
        CharacterMovement movement = GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterMovement>();
        var instantiated = Instantiate(sprite, movement.gameObject.transform, true);
/*        instantiated.AddComponent<Parallax>().background = instantiated;*/
        movement.ManipulateSpeedLimit(speedAcceleration, speedDuration[upgradeProgress]);
    }
}
