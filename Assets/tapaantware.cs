using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tapaantware : MonoBehaviour
{
    public GameObject a;
    public GameObject[] SceneMenu;
    private void Awake()
    {
    }

    private void Start()
    {
        for (int i = 0; i < SceneMenu.Length; i++)
        {
            SceneMenu[i].SetActive(false);

        }
    }

    public void dee()
    {
        for (int i = 0; i < SceneMenu.Length; i++)
        {
            SceneMenu[i].SetActive(true);

        }
        Destroy(a);
    }
}
