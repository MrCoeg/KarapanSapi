using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Stars))]
[RequireComponent(typeof(Map_Properties))]
public class Map : MonoBehaviour
{
    public TextMeshProUGUI mapName;
    public Stars starsProgress;
    public Image mapPlaceholder;

    public void Clicked()
    {

    }
}