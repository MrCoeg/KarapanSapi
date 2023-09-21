using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Biodata : MonoBehaviour
{
    public Sprite[] biodata;
    public Image image;
    private int id;
    public CharacterSwitchButton switchchar;
    private void Awake()
    {
        id = switchchar.characterId;
        image.sprite = biodata[id];

    }

    private void Update()
    {
        if (switchchar.characterId != id)
        {
            id = switchchar.characterId;
            image.sprite = biodata[id];
        }
    }

}
