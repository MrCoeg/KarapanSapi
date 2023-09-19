using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testanimasi : MonoBehaviour
{
    public Animation animationaa;

    private void Awake()
    {
        animationaa = gameObject.GetComponent<Animation>();
    }

    public void Menu_To_Buy()
    {

        animationaa.Play("Menu_To_Buy");
    }

    public void Menu_To_Menu()
    {
        animationaa.Play("Menu_To_Menu");

    }
}
