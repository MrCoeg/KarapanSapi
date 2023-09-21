using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutoralButton : MonoBehaviour
{
    public Sprite[] sprites;
    public int counter;
    public Image image;

    public GameObject[] toShow;
    private void Awake()
    {
        counter = 0;
    }

    public void Kembali()
    {
        for (int i = 0; i < toShow.Length; i++)
        {
            toShow[i].SetActive(true);
        }
        this.gameObject.SetActive(false);
    }

    public void Left()
    {
        counter -= 1;
        if (counter < 0)
        {
            counter = sprites.Length-1;
        }

        image.sprite = sprites[counter];
    }

    public void Right()
    {
        counter += 1;
        counter %= sprites.Length;

        image.sprite = sprites[counter];
    }

}
