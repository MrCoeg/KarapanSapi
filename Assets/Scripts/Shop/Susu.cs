using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Susu", menuName = "Collectible/Susu")]
public class Susu : Collectible
{
    public int[] speedDuration;
    public int speedAcceleration;
    public override void Use()
    {
        CharacterMovement movement = GameObject.FindGameObjectWithTag("Character").GetComponent<CharacterMovement>();
        movement.Immune(speedDuration[upgradeProgress]);

        movement.manipulate(speedAcceleration, speedDuration[upgradeProgress]);
    }
}
