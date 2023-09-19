using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour
{
    public Animation animationaa;

    private void Awake()
    {
        animationaa = gameObject.GetComponent<Animation>();
    }

    public void Buy_To_Buy()
    {

        animationaa.Play("Buy_To_Buy");
    }

    public void Buy_To_Menu()
    {
        animationaa.Play("Buy_To_Menu");

    }
}
